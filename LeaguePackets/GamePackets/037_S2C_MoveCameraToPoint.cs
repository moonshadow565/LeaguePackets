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
        public S2C_MoveCameraToPoint(){}

        public S2C_MoveCameraToPoint(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Bitfield = reader.ReadByte();
            this.StartPosition = reader.ReadVector3();
            this.TargetPosition = reader.ReadVector3();
            this.TravelTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
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
