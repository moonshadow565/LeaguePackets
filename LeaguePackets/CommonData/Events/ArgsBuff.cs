using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsBuff : ArgsBase
    {
        public uint ScriptNameHash { get; set; }
        public byte EventSource { get; set; }
        public NetID SourceObjectNetID { get; set; }
        public uint ParentScriptNameHash { get; set; }
        public NetID ParentCasterNetID { get; set; }
        public ushort Bitfield { get; set; }

        public override void ReadArgs(PacketReader reader)
        {
            ScriptNameHash = reader.ReadUInt32();
            EventSource = reader.ReadByte();
            SourceObjectNetID = reader.ReadNetID();
            ParentScriptNameHash = reader.ReadUInt32();
            ParentCasterNetID = reader.ReadNetID();
            Bitfield = reader.ReadUInt16();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            writer.WriteUInt32(ScriptNameHash);
            writer.WriteByte(EventSource);
            writer.WriteNetID(SourceObjectNetID);
            writer.WriteUInt32(ParentScriptNameHash);
            writer.WriteNetID(ParentCasterNetID);
            writer.WriteUInt16(Bitfield);
        }
    }
}
