
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class World_SendCamera_Server : GamePacket // 0x2E
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server;
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public int ClientID { get; set; }
        public byte SyncID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.CameraPosition = reader.ReadVector3();
            this.CameraDirection = reader.ReadVector3();
            this.ClientID = reader.ReadInt32();
            this.SyncID = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(CameraPosition);
            writer.WriteVector3(CameraDirection);
            writer.WriteInt32(ClientID);
            writer.WriteByte(SyncID);
        }
    }
}
