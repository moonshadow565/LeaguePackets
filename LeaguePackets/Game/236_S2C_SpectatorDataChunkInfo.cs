
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SpectatorDataChunkInfo : GamePacket // 0xEC
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorDataChunkInfo;
        public int StartGameChunkId { get; set; }
        public int EndGameChunkId { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.StartGameChunkId = reader.ReadInt32();
            this.EndGameChunkId = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(StartGameChunkId);
            writer.WriteInt32(EndGameChunkId);
        }
    }
}
