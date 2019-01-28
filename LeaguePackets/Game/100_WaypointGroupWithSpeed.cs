
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class WaypointGroupWithSpeed : GamePacket // 0x64
    {
        public override GamePacketID ID => GamePacketID.WaypointGroupWithSpeed;
        public int SyncID { get; set; }
        public List<MovementDataWithSpeed> Movements { get; set; } = new List<MovementDataWithSpeed>();

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
            int count = reader.ReadInt16();
            for (int i = 0; i < count; i++)
            {
                this.Movements.Add(new MovementDataWithSpeed(reader, this.SyncID));
            }
        }
        protected override void WriteBody(ByteWriter writer)
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
