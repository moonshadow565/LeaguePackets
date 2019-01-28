
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_SpectatorDataReq : GamePacket // 0xEA
    {
        public override GamePacketID ID => GamePacketID.C2S_SpectatorDataReq;
        public bool SendMetaData { get; set; }
        public bool JumpToLatest { get; set; }
        public int StartChunkID { get; set; }
        public int StartKeyFrameID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SendMetaData = reader.ReadBool();
            this.JumpToLatest = reader.ReadBool();
            this.StartChunkID = reader.ReadInt32();
            this.StartKeyFrameID = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(SendMetaData);
            writer.WriteBool(JumpToLatest);
            writer.WriteInt32(StartChunkID);
            writer.WriteInt32(StartKeyFrameID);
        }
    }
}
