using System;


namespace LeaguePackets.Game.Common
{
    public abstract class UpdateLevelPropData
    {
        protected string _stringParam1 = "";
        protected float _floatParam1;
        protected float _floatParam2;
        public uint NetID { get; set; }
        protected uint _flags1;
        protected abstract uint _command { get; }
        protected byte _byteParam1;
        protected byte _byteParam2;
        protected byte _byteParam3;

        public static UpdateLevelPropData CreateBody(ByteReader reader)
        {
            string stringParam1 = reader.ReadFixedString(64);
            float floatParam1 = reader.ReadFloat();
            float floatParam2 = reader.ReadFloat();
            uint netID = reader.ReadUInt32();
            uint flags1 = reader.ReadUInt32();
            uint command = reader.ReadUInt32();
            byte byteParam1 = reader.ReadByte();
            byte byteParam2 = reader.ReadByte();
            byte byteParam3 = reader.ReadByte();

            UpdateLevelPropData result;
            switch (command)
            {
                case 3:
                    result = new UpdateLevelPropDataChangeSkin();
                    break;
                case 2:
                    result = new UpdateLevelPropDataSetParticleValue();
                    break;
                case 1:
                    result = new UpdateLevelPropDataPlayAnimation();
                    break;
                default:
                    result = new UpdateLevelPropDataUnknown
                    {
                        Command = command
                    };
                    break;
            }

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

        public void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(_stringParam1, 64);
            writer.WriteFloat(_floatParam1);
            writer.WriteFloat(_floatParam2);
            writer.WriteUInt32(NetID);
            writer.WriteUInt32(_flags1);
            writer.WriteUInt32(_command);
            writer.WriteByte(_byteParam1);
            writer.WriteByte(_byteParam2);
            writer.WriteByte(_byteParam3);
        }
    }

    public static class UpdateLevelPropDataExtension
    {
        public static UpdateLevelPropData ReadUpdateLevelPropData(this ByteReader reader)
        {
            return UpdateLevelPropData.CreateBody(reader);
        }
        public static void WriteUpdateLevelPropData(this ByteWriter writer, UpdateLevelPropData data)
        {
            data.WriteBody(writer);
        }
    }

    public class UpdateLevelPropDataChangeSkin : UpdateLevelPropData
    {
        protected override uint _command => 3;
        public string SkinName { get => _stringParam1; set => _stringParam1 = value; }
        public uint SkinID { get => _flags1; set => _flags1 = value; }
    }

    public class UpdateLevelPropDataSetParticleValue : UpdateLevelPropData
    {
        protected override uint _command => 2;
        public bool DestroyPropAfterAnimation { get => _byteParam1 != 0; set => _byteParam1 = (byte)(value ? 1 : 0); }
        public byte FlexID { get => _byteParam2; set => _byteParam2 = value; }
        public byte CapPointIndex { get => _byteParam3; set => _byteParam3 = value; }
    }

    public class UpdateLevelPropDataPlayAnimation : UpdateLevelPropData
    {
        protected override uint _command => 1;
        public string AnimationName { get => _stringParam1; set => _stringParam1 = value; }
        public uint AnimationFlags { get => _flags1; set => _flags1 = value; }
        public float StartMissionTime { get => _floatParam1; set => _floatParam1 = value; }
        public float Duration { get => _floatParam2; set => _floatParam2 = value; }
        public bool DestroyPropAfterAnimation { get => _byteParam1 != 0; set => _byteParam1 = (byte)(value ? 1 : 0); }
    }

    public class UpdateLevelPropDataUnknown : UpdateLevelPropData
    {
        public string StringParam1 { get => _stringParam1; set => _stringParam1 = value; }
        public float FloatParam1 { get => _floatParam1; set => _floatParam1 = value; }
        public float FloatParam2 { get => _floatParam2; set => _floatParam2 = value; }
        public uint Flags1 { get => _flags1; set => _flags1 = value; }
        public uint Command { get; set; }
        public byte ByteParam1 { get => _byteParam1; set => _byteParam1 = value; }
        public byte ByteParam2 { get => _byteParam2; set => _byteParam2 = value; }
        public byte ByteParam3 { get => _byteParam3; set => _byteParam3 = value; }

        protected override uint _command => Command;
    }
}
