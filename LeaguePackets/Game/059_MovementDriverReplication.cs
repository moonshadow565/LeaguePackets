
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class MovementDriverReplication : GamePacket // 0x3C
    {
        public override GamePacketID ID => GamePacketID.MovementDriverReplication;
        // TODO: change this to enum ?
        public byte MovementTypeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public MovementDriverHomingData MovementDriverHomingData { get; set; } = null;

        protected override void ReadBody(ByteReader reader)
        {

            this.MovementTypeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.Velocity = reader.ReadVector3();
            int movementDriverParamType = reader.ReadInt32();
            if (movementDriverParamType == 1)
            {
                this.MovementDriverHomingData = reader.ReadMovementDriverHomingData();
            }
            else
            {
                this.MovementDriverHomingData = null;
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(MovementTypeID);
            writer.WriteVector3(Position);
            writer.WriteVector3(Velocity);
            if (MovementDriverHomingData == null)
            {
                writer.WriteInt32(0);
            }
            else
            {
                writer.WriteInt32(1);
                writer.WriteMovementDriverHomingData(MovementDriverHomingData);
            }
        }
    }
}
