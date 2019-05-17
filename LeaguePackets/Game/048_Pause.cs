
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class Pause : GamePacket // 0x31
    {
        public override GamePacketID ID => GamePacketID.Pause;
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public int SyncID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector3();
            this.Forward = reader.ReadVector3();
            this.SyncID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteVector3(Forward);
            writer.WriteInt32(SyncID);
        }
    }
}
