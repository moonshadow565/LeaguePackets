
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_BuffUpdateCountGroup : GamePacket // 0xBF
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCountGroup;
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public List<BuffUpdateCountGroupEntry> Entries { get; set; } = new List<BuffUpdateCountGroupEntry>();

        protected override void ReadBody(ByteReader reader)
        {

            this.Duration = reader.ReadFloat();
            this.RunningTime = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffInGroupUpdateCount());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(Duration);
            writer.WriteFloat(RunningTime);
            int numInGroup = Entries.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupUpdateCount(Entries[i]);
            }
        }
    }
}
