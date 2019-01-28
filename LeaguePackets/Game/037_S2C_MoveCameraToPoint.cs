
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_MoveCameraToPoint : GamePacket // 0x25
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveCameraToPoint;
        public bool StartFromCurrentPosition { get; set; }
        // This is applied only when StartFromCurrentPosition is true
        public bool UnlockCamera { get; set; }
        // This is used only when StartFromCurrentPosition is false
        public Vector3 StartPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public float TravelTime { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.StartFromCurrentPosition = (bitfield & 0x01) != 0;
            this.UnlockCamera = (bitfield & 0x02) != 0; 

            this.StartPosition = reader.ReadVector3();
            this.TargetPosition = reader.ReadVector3();
            this.TravelTime = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (StartFromCurrentPosition)
                bitfield |= 0x01;
            if (UnlockCamera)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);

            writer.WriteVector3(StartPosition);
            writer.WriteVector3(TargetPosition);
            writer.WriteFloat(TravelTime);
        }
    }
}
