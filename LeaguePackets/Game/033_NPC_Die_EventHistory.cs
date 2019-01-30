using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;
using LeaguePackets.Game.Events;

namespace LeaguePackets.Game
{
    public class NPC_Die_EventHistory : GamePacket // 0x21
    {
        public override GamePacketID ID => GamePacketID.NPC_Die_EventHistory;
        public uint KillerNetID { get; set; }
        public float Duration { get; set; }
        public byte EventSourceType { get; set; }
        public List<EventHistoryEntry> Entries { get; set; } = new List<EventHistoryEntry>();

        protected override void ReadBody(ByteReader reader)
        {

            this.EventSourceType = reader.ReadByte();
            this.KillerNetID = reader.ReadUInt32();
            this.Duration = reader.ReadFloat();
            int events = reader.ReadInt32();
            for (int i = 0; i < events; i++)
            {
                Entries.Add(reader.ReadEventHistoryEntry());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(EventSourceType);
            writer.WriteUInt32(KillerNetID);
            writer.WriteFloat(Duration);
            writer.WriteInt32(Entries.Count);
            foreach (var ev in Entries)
            {
                writer.WriteEventHistoryEntry(ev);
            }
        }
    }
}
