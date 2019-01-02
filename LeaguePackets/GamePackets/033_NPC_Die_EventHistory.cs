using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class EventData
    {
        public float Timestamp { get; set; }
        public ushort Count { get; set; }
        public Event Event { get; set; }
    }

    public class NPC_Die_EventHistory : GamePacket // 0x21
    {
        public override GamePacketID ID => GamePacketID.NPC_Die_EventHistory;
        public NetID KillerNetID { get; set; }
        public float Duration { get; set; }
        public EventSourceType EventSourceType { get; set; }
        public List<EventData> Events { get; set; } = new List<EventData>();


        public NPC_Die_EventHistory(){}

        public NPC_Die_EventHistory(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.EventSourceType = reader.ReadEventSourceType();
            this.KillerNetID = reader.ReadNetID();
            this.Duration = reader.ReadFloat();
            int events = reader.ReadInt32();
            for (int i = 0; i < events; i++)
            {
                var data = new EventData();
                data.Timestamp = reader.ReadFloat();
                data.Count = reader.ReadUInt16();
                data.Event = reader.ReadEvent();
            }

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteEventSourceType(EventSourceType);
            writer.WriteNetID(KillerNetID);
            writer.WriteFloat(Duration);
            writer.WriteInt32(Events.Count);
            foreach (var data in Events )
            {
                writer.WriteFloat(data.Timestamp);
                writer.WriteUInt16(data.Count);
                writer.WriteEvent(data.Event);
            }

        }
    }
}
