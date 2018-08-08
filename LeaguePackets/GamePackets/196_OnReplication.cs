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
    public class OnReplication : GamePacket // 0xC4
    {
        public override GamePacketID ID => GamePacketID.OnReplication;
        public uint SyncID { get; set; }
        public List<ReplicationData> ReplicationData { get; set; } = new List<CommonData.ReplicationData>();
        public static OnReplication CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new OnReplication();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SyncID = reader.ReadUInt32();
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                result.ReplicationData.Add(reader.ReadReplicationData());
            }
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(SyncID);
            int count = ReplicationData.Count;
            if(count > 0xFF)
            {
                throw new IOException("Too many replication data in list > 0xFF");
            }
            writer.WriteByte((byte)count);
            for (int i = 0; i < count; i++)
            {
                writer.WriteReplicationData(ReplicationData[i]);
            }
        }
    }
}
