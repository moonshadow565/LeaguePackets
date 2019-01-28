
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_BuffRemoveGroup : GamePacket // 0x94
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffRemoveGroup;
        public uint BuffNameHash { get; set; }
        public List<BuffRemoveGroupEntry> Entries { get; set; } = new List<BuffRemoveGroupEntry>();

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffNameHash = reader.ReadUInt32();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffInGroupRemove());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(BuffNameHash);
            int numInGroup = Entries.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs in list!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupRemove(Entries[i]);
            }
        }
    }
}
