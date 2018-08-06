using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public abstract class UpdateLevelPropS2C : GamePacket // 0xD1
    {
        public override GamePacketID ID => GamePacketID.UpdateLevelPropS2C;
        protected string _stringParam1 = "";
        protected float _floatParam1;
        protected float _floatParam2;
        public NetID NetID { get; set; }
        protected uint _flags1;
        protected abstract byte Command { get; }
        protected byte _byteParam1;
        protected byte _byteParam2;
        protected byte _byteParam3;

        public static UpdateLevelPropS2C CreateBody(PacketReader reader, NetID senderNetID)
        {
            string stringParam1 = reader.ReadFixedString(64);
            float floatParam1 = reader.ReadFloat();
            float floatParam2 = reader.ReadFloat();
            NetID netID = reader.ReadNetID();
            uint flags1 = reader.ReadUInt32();
            byte command = reader.ReadByte();
            byte byteParam1 = reader.ReadByte();
            byte byteParam2 = reader.ReadByte();
            byte byteParam3 = reader.ReadByte();

            UpdateLevelPropS2C result;
            switch(command)
            {
                case 2:
                    result = new UpdateLevelPropS2CChangeSkin();
                    break;
                case 1:
                    result = new UpdateLevelPropS2CSetParticleValue();
                    break;
                case 0:
                    result = new UpdateLevelPropS2CPlayAnimation();
                    break;
                default:
                    throw new IOException("Unknown UpdateLevelProp!");
            }

            result.SenderNetID = senderNetID;
            result._stringParam1 = stringParam1;
            result._floatParam1 = floatParam1;
            result._floatParam2 = floatParam2;
            result.NetID = netID;
            result._flags1 = flags1;
            result._byteParam1 = byteParam1;
            result._byteParam2 = byteParam2;
            result._byteParam3 = byteParam3;

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(_stringParam1, 64);
            writer.WriteFloat(_floatParam1);
            writer.WriteFloat(_floatParam2);
            writer.WriteNetID(NetID);
            writer.WriteUInt32(_flags1);
            writer.WriteByte(Command);
            writer.WriteByte(_byteParam1);
            writer.WriteByte(_byteParam2);
            writer.WriteByte(_byteParam3);
        }

    }

    public class UpdateLevelPropS2CChangeSkin : UpdateLevelPropS2C
    {
        protected override byte Command => 2;
        public string SkinName { get => _stringParam1; set => _stringParam1 = value; }
        public uint SkinID { get => _flags1; set => _flags1 = value;}
    }

    public class UpdateLevelPropS2CSetParticleValue : UpdateLevelPropS2C
    {
        protected override byte Command => 1;
        public bool DestroyPropAfterAnimation { get => _byteParam1 != 0; set => _byteParam1 = (byte)(value ? 1 : 0); }
        public byte FlexID { get => _byteParam2; set => _byteParam2 = value; }
        public byte CapPointIndex { get => _byteParam3; set => _byteParam3 = value; }
    }

    public class UpdateLevelPropS2CPlayAnimation : UpdateLevelPropS2C
    {
        protected override byte Command => 0;
        public string AnimationName { get => _stringParam1; set => _stringParam1 = value; }
        public uint AnimationFlags { get => _flags1; set => _flags1 = value; }
        public float StartMissionTime { get => _floatParam1; set => _floatParam1 = value; }
        public float Duration { get => _floatParam2; set => _floatParam2 = value; }
        public bool DestroyPropAfterAnimation { get => _byteParam1 != 0; set => _byteParam1 = (byte)(value ? 1 : 0); }
    }
}
