using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class MovementDriverReplication : GamePacket // 0x3C
    {
        public override GamePacketID ID => GamePacketID.MovementDriverReplication;
        // TODO: change this to enum ?
        public byte MovementTypeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public MovementDriverHomingData MovementDriverHomingData { get; set; } = null;

        public static MovementDriverReplication CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new MovementDriverReplication();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.MovementTypeID = reader.ReadByte();
            result.Position = reader.ReadVector3();
            result.Velocity = reader.ReadVector3();
            int movementDriverParamType = reader.ReadInt32();
            if (movementDriverParamType == 1)
            {
                result.MovementDriverHomingData = reader.ReadMovementDriverHomingData();
            }
            else
            {
                result.MovementDriverHomingData = null;
            }
            return result;
        }
        public override void WriteBody(PacketWriter writer)
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
