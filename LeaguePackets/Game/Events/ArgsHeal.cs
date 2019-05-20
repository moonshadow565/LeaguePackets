using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsHeal : ArgsBase
    {
        public float HealAmmount { get; set; }
        public byte EventSource { get; set; }
        public uint SourceScriptNameHash { get; set; }
        public uint ParentScriptNameHash { get; set; }
        public uint ParentCasterNetID { get; set; }
        public ushort Bitfield { get; set; }
        public override void ReadArgs(ByteReader reader)
        {
            base.ReadArgs(reader);
            HealAmmount = reader.ReadFloat();
            EventSource = reader.ReadByte();
            SourceScriptNameHash = reader.ReadUInt32();
            ParentScriptNameHash = reader.ReadUInt32();
            ParentCasterNetID = reader.ReadUInt32();
            Bitfield = reader.ReadUInt16();
        }
        public override void WriteArgs(ByteWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(HealAmmount);
            writer.WriteByte(EventSource);
            writer.WriteUInt32(SourceScriptNameHash);
            writer.WriteUInt32(ParentScriptNameHash);
            writer.WriteUInt32(ParentCasterNetID);
            writer.WriteUInt16(Bitfield);
        }
    }
}
