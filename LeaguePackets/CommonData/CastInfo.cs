using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class CastInfo
    {
        public uint SpellHash { get; set; } //2 - 6
        public NetID SpellNetID { get; set; } //6 - 10
        public byte SpellLevel { get; set; } //10 - 11
        public float AttackSpeedModifier { get; set; } //11 - 15
        public NetID CasterNetID { get; set; } //15 - 19
        public NetID SpellChainOwnerNetID { get; set; } //19 - 23
        public uint PackageHash { get; set; } //23-27
        public NetID MissileNetID { get; set; } //27-31
        public Vector3 TargetPosition { get; set; } //31-35, 35-39, 39-43
        public Vector3 TargetPositionEnd { get; set; } //43-47, 47-51, 51-55
        //55 - 56 byte TargetCount
        //56 + Tupple<NetID, HitResult>  ???? is this really hit result

        public List<Tuple<NetID, HitResult>> Targets { get; set; } = new List<Tuple<NetID, HitResult>>();

        public float DesignerCastTime { get; set; } //0-4
        public float ExtraCastTime { get; set; } //4-8
        public float DesignerTotalTime { get; set; } //8-12
        public float Cooldown { get; set; } //12-16
        public float StartCastTime { get; set; } //16-20

        //bitfield byte //20-21
        public bool IsAutoAttack { get; set; }
        public bool IsSecondAutoAttack { get; set; }
        public bool IsForceCastingOrChannel { get; set; }
        public bool IsOverrideCastPosition { get; set; }
        public bool IsClickCasted { get; set; }

        public byte SpellSlot { get; set; } //21-22
        public float ManaCost { get; set; } //22-26
        public Vector3 SpellCastLaunchPosition { get; set; }//26-30,30-34,34-38
        public int AmmoUsed { get; set; }//38-42
        public float AmmoRechargeTime { get; set; }//42-46
    }

    public static class CastInfoExtension
    {
        public static CastInfo ReadCastInfo(this PacketReader reader)
        {
            var data = new CastInfo();
            var size = reader.ReadUInt16();
            var startPos = reader.Stream.Position;

            data.SpellHash = reader.ReadUInt32();
            data.SpellNetID = reader.ReadNetID();
            data.SpellLevel = reader.ReadByte();
            data.AttackSpeedModifier = reader.ReadFloat();
            data.CasterNetID = reader.ReadNetID();
            data.SpellChainOwnerNetID = reader.ReadNetID();
            data.PackageHash = reader.ReadUInt32();
            data.MissileNetID = reader.ReadNetID();
            data.TargetPosition = reader.ReadVector3();
            data.TargetPositionEnd = reader.ReadVector3();

            int targetCount = reader.ReadByte();
            for (int i = 0; i < targetCount; i++)
            {
                NetID target = reader.ReadNetID();
                HitResult hitResult = reader.ReadHitResult();
                data.Targets.Add(new Tuple<NetID, HitResult>(target, hitResult));
            }

            data.DesignerCastTime = reader.ReadFloat();
            data.ExtraCastTime = reader.ReadFloat();
            data.DesignerTotalTime = reader.ReadFloat();
            data.Cooldown = reader.ReadFloat();
            data.StartCastTime = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            data.IsAutoAttack = (bitfield & 1) != 0;
            data.IsSecondAutoAttack = (bitfield & 2) != 0;
            data.IsForceCastingOrChannel = (bitfield & 4) != 0;
            data.IsOverrideCastPosition = (bitfield & 8) != 0;
            data.IsClickCasted = (bitfield & 16) != 0;

            data.SpellSlot = reader.ReadByte();
            data.ManaCost = reader.ReadFloat();
            data.SpellCastLaunchPosition = reader.ReadVector3();
            data.AmmoUsed = reader.ReadInt32();
            data.AmmoRechargeTime = reader.ReadFloat();

            if((reader.Stream.Position - startPos) != size)
            {
                throw new IOException("CastInfo size read doesn't match size sent!");
            }
            return data; 
        }

        public static void WriteCastInfo(this PacketWriter writerOrg, CastInfo data)
        {
            byte[] buffer;
            using(var stream = new MemoryStream())
            {
                using(var writer = new PacketWriter(stream, true))
                {
                    writer.WriteUInt32(data.SpellHash);
                    writer.WriteNetID(data.SpellNetID);
                    writer.WriteByte(data.SpellLevel);
                    writer.WriteFloat(data.AttackSpeedModifier);
                    writer.WriteNetID(data.CasterNetID);
                    writer.WriteNetID(data.SpellChainOwnerNetID);
                    writer.WriteUInt32(data.PackageHash);
                    writer.WriteNetID(data.MissileNetID);
                    writer.WriteVector3(data.TargetPosition);
                    writer.WriteVector3(data.TargetPositionEnd);

                    int targetCount = data.Targets.Count;
                    if(targetCount > 32)
                    {
                        throw new IOException("CastInfo targets > 32!!!");
                    }
                    writer.WriteByte((byte)targetCount);
                    foreach(var target in data.Targets)
                    {
                        writer.WriteNetID(target.Item1);
                        writer.WriteHitResult(target.Item2);
                    }

                    writer.WriteFloat(data.DesignerCastTime);
                    writer.WriteFloat(data.ExtraCastTime);
                    writer.WriteFloat(data.DesignerTotalTime);
                    writer.WriteFloat(data.Cooldown);
                    writer.WriteFloat(data.StartCastTime);

                    byte bitfield = 0;
                    if(data.IsAutoAttack)
                    {
                        bitfield |= 1;
                    }
                    if(data.IsSecondAutoAttack)
                    {
                        bitfield |= 2;
                    }
                    if(data.IsForceCastingOrChannel)
                    {
                        bitfield |= 4;
                    }
                    if(data.IsOverrideCastPosition)
                    {
                        bitfield |= 8;
                    }
                    if(data.IsClickCasted)
                    {
                        bitfield |= 16;
                    }
                    writer.WriteByte(bitfield);

                    writer.WriteByte(data.SpellSlot);
                    writer.WriteFloat(data.ManaCost);
                    writer.WriteVector3(data.SpellCastLaunchPosition);
                    writer.WriteInt32(data.AmmoUsed);
                    writer.WriteFloat(data.AmmoRechargeTime);
                }
                buffer = new byte[stream.Length];
                Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, buffer.Length);
            }
            writerOrg.WriteUInt16((ushort)(buffer.Length + 2));
            writerOrg.WriteBytes(buffer);
        }
    }
}
