
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class OnReplication : GamePacket // 0xC4
    {
        public override GamePacketID ID => GamePacketID.OnReplication;
        public uint SyncID { get; set; }
        public List<ReplicationData> ReplicationData { get; set; } = new List<Common.ReplicationData>();

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadUInt32();
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                this.ReplicationData.Add(reader.ReadReplicationData());
            }
        }

        protected override void WriteBody(ByteWriter writer)
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
