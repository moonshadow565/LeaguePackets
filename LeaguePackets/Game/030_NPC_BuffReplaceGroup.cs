
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_BuffReplaceGroup : GamePacket // 0x1E
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplaceGroup;
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<BuffReplaceGroupEntry> Entries{ get; set; } = new List<BuffReplaceGroupEntry>();

        protected override void ReadBody(ByteReader reader)
        {

            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffInGroupReplace());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            int numInGroup = Entries.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs insidde!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupReplace(Entries[i]);
            }
        }
    }
}
