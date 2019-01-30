using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsDamage: ArgsBase
    {
        public uint ScriptNameHash { get; set; }
        public byte EventSource { get; set; }
        // FIXME: new byte or EventSource bigger ?
        public byte Unknown { get; set; }
        public uint SourceObjectNetID { get; set; }
        public float PhysicalDamage { get; set; }
        public float MagicalDamage { get; set; }
        public float TrueDamage { get; set; }
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
            PhysicalDamage = reader.ReadFloat();
            MagicalDamage = reader.ReadFloat();
            TrueDamage = reader.ReadFloat();
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
            writer.WriteFloat(PhysicalDamage);
            writer.WriteFloat(MagicalDamage);
            writer.WriteFloat(TrueDamage);
            writer.WriteUInt32(ParentScriptNameHash);
            writer.WriteUInt32(ParentCasterNetID);
            writer.WriteUInt16(Bitfield);
        }
    }
}
