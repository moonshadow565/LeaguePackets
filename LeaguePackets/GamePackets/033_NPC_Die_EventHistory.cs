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


        public static NPC_Die_EventHistory CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_Die_EventHistory();
            result.SenderNetID = senderNetID;
            result.KillerNetID = reader.ReadNetID();
            result.Duration = reader.ReadFloat();
            result.EventSourceType = reader.ReadEventSourceType();
            int events = reader.ReadInt32();
            for (int i = 0; i < events; i++)
            {
                var data = new EventData();
                data.Timestamp = reader.ReadFloat();
                data.Count = reader.ReadUInt16();
                data.Event = Event.Create(reader);
            }

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(KillerNetID);
            writer.WriteFloat(Duration);
            writer.WriteEventSourceType(EventSourceType);
            writer.WriteInt32(Events.Count);
            foreach (var data in Events )
            {
                writer.WriteFloat(data.Timestamp);
                writer.WriteUInt16(data.Count);
                data.Event.Write(writer);
            }

        }
    }
}
