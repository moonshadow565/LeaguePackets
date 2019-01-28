using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;


namespace LeaguePackets.Game.Common
{
    public class CastInfo
    {
        public struct Target
        {
            public uint UnitNetID { get; set; }
            public byte HitResult { get; set; }
        }

        public uint SpellHash { get; set; } //2 - 6
        public uint SpellNetID { get; set; } //6 - 10
        public byte SpellLevel { get; set; } //10 - 11
        public float AttackSpeedModifier { get; set; } //11 - 15
        public uint CasterNetID { get; set; } //15 - 19
        public uint SpellChainOwnerNetID { get; set; } //19 - 23
        public uint PackageHash { get; set; } //23-27
        public uint MissileNetID { get; set; } //27-31
        public Vector3 TargetPosition { get; set; } //31-35, 35-39, 39-43
        public Vector3 TargetPositionEnd { get; set; } //43-47, 47-51, 51-55
        //55 - 56 byte TargetCount
        //56 + Tupple<NetID, HitResult>  ???? is this really hit result

        public List<Target> Targets { get; set; } = new List<Target>();

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
        public static CastInfo ReadCastInfo(this ByteReader reader)
        {
            var data = new CastInfo();
            var startPos = reader.Position;
            var size = reader.ReadUInt16();

            data.SpellHash = reader.ReadUInt32();
            data.SpellNetID = reader.ReadUInt32();
            data.SpellLevel = reader.ReadByte();
            data.AttackSpeedModifier = reader.ReadFloat();
            data.CasterNetID = reader.ReadUInt32();
            data.SpellChainOwnerNetID = reader.ReadUInt32();
            data.PackageHash = reader.ReadUInt32();
            data.MissileNetID = reader.ReadUInt32();
            data.TargetPosition = reader.ReadVector3();
            data.TargetPositionEnd = reader.ReadVector3();

            int targetCount = reader.ReadByte();
            for (int i = 0; i < targetCount; i++)
            {
                var unit = reader.ReadUInt32();
                var hitResult = reader.ReadByte();
                data.Targets.Add(new CastInfo.Target
                {
                    UnitNetID = unit,
                    HitResult = hitResult,
                });

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

            if((reader.Position - startPos) != size)
            {
                throw new IOException("CastInfo size read doesn't match size sent!");
            }
            return data; 
        }

        public static void WriteCastInfo(this ByteWriter writerOrg, CastInfo data)
        {
            using(var writer = new ByteWriter())
            {
                writer.WriteUInt32(data.SpellHash);
                writer.WriteUInt32(data.SpellNetID);
                writer.WriteByte(data.SpellLevel);
                writer.WriteFloat(data.AttackSpeedModifier);
                writer.WriteUInt32(data.CasterNetID);
                writer.WriteUInt32(data.SpellChainOwnerNetID);
                writer.WriteUInt32(data.PackageHash);
                writer.WriteUInt32(data.MissileNetID);
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
                    writer.WriteUInt32(target.UnitNetID);
                    writer.WriteByte(target.HitResult);
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

                var buffer = writer.GetBytes();
                writerOrg.WriteUInt16((ushort)(buffer.Length + 2));
                writerOrg.WriteBytes(buffer);
            }
        }
    }
}
