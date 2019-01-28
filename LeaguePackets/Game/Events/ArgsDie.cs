using System;

namespace LeaguePackets.Game.Events
{
    public class ArgsDie : ArgsBase
    {
        private uint[] _assists = new uint[12];
        public float GoldGiven { get; set; }
        public int AssistCount { get; set; }
        public uint[] Assists => _assists;

        public override void ReadArgs(ByteReader reader) 
        {
            base.ReadArgs(reader);
            GoldGiven = reader.ReadFloat();
            AssistCount = reader.ReadInt32();
            for (int i = 0; i < Assists.Length; i++)
            {
                Assists[i] = reader.ReadUInt32();
            }
        }
        public override void WriteArgs(ByteWriter writer) 
        {
            base.WriteArgs(writer);
            writer.WriteFloat(GoldGiven);
            writer.WriteInt32(AssistCount);
            for (int i = 0; i < Assists.Length; i++)
            {
                writer.WriteUInt32(Assists[i]);
            }
        }
    }
}
