using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsBuff : ArgsBase
    {
        public uint ScriptNameHash { get; set; }
        public byte EventSource { get; set; }
        // FIXME: new byte appeared here
        public byte Unknown { get; set; }
        public uint SourceObjectNetID { get; set; }
        public uint ParentScriptNameHash { get; set; }
        public uint ParentCasterNetID { get; set; }
        public ushort Bitfield { get; set; }

        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            ScriptNameHash = reader.ReadUInt32();
            EventSource = reader.ReadByte();
            Unknown = reader.ReadByte();
            SourceObjectNetID = reader.ReadUInt32();
            ParentScriptNameHash = reader.ReadUInt32();
            ParentCasterNetID = reader.ReadUInt32();
            Bitfield = reader.ReadUInt16();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteUInt32(ScriptNameHash);
            writer.WriteByte(EventSource);
            writer.WriteByte(Unknown);
            writer.WriteUInt32(SourceObjectNetID);
            writer.WriteUInt32(ParentScriptNameHash);
            writer.WriteUInt32(ParentCasterNetID);
            writer.WriteUInt16(Bitfield);
        }
    }
}
