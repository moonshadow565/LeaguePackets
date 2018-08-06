using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class S2C_MoveCameraToPoint : GamePacket // 0x25
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveCameraToPoint;
        // TODO: change bitfield to variables
        public byte Bitfield { get; set; }
        public Vector3 StartPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public float TravelTime { get; set; }
        public static S2C_MoveCameraToPoint CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_MoveCameraToPoint();
            result.SenderNetID = senderNetID;
            result.Bitfield = reader.ReadByte();
            result.StartPosition = reader.ReadVector3();
            result.TargetPosition = reader.ReadVector3();
            result.TravelTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Bitfield);
            writer.WriteVector3(StartPosition);
            writer.WriteVector3(TargetPosition);
            writer.WriteFloat(TravelTime);
        }
    }
}
