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
    public class WaypointGroupWithSpeed : GamePacket // 0x64
    {
        public override GamePacketID ID => GamePacketID.WaypointGroupWithSpeed;
        public int SyncID { get; set; }
        public List<MovementDataWithSpeed> Movements { get; set; } = new List<MovementDataWithSpeed>();
        public WaypointGroupWithSpeed(){}

        public WaypointGroupWithSpeed(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SyncID = reader.ReadInt32();
            int count = reader.ReadInt16();
            for (int i = 0; i < count; i++)
            {
                this.Movements.Add(new MovementDataWithSpeed(reader));
            }
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            int count = Movements.Count;
            if (count > 0x7FFF)
            {
                throw new IOException("Too many movementdata!");
            }
            writer.WriteInt32(SyncID);
            writer.WriteInt16((short)count);
            foreach (var data in Movements)
            {
                data.Write(writer);
            }
        }
    }
}
