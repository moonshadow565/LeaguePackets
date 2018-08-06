using System;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData.Events
{
    public class ArgsDie : ArgsBase
    {
        private NetID[] _assists = new NetID[12];
        public float GoldGiven { get; set; }
        public int AssistCount { get; set; }
        public NetID[] Assists => _assists;

        public override void ReadArgs(PacketReader reader) 
        {
            GoldGiven = reader.ReadFloat();
            AssistCount = reader.ReadInt32();
            for (int i = 0; i < Assists.Length; i++)
            {
                Assists[i] = reader.ReadNetID();
            }
        }
        public override void WriteArgs(PacketWriter writer) 
        {
            writer.WriteFloat(GoldGiven);
            writer.WriteInt32(AssistCount);
            for (int i = 0; i < Assists.Length; i++)
            {
                writer.WriteNetID(Assists[i]);
            }
        }
    }
}
