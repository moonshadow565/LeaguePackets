
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_SpectatorDataChunk : GamePacket // 0xED
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorDataChunk;
        public int ChunkID { get; set; }
        public int TotalSubChunks { get; set; }
        public int SubChunkID { get; set; }
        public byte SpectatorChunkType { get; set; }
        public int TotalSize { get; set; }
        public int Duration { get; set; }
        public int NextChunkID { get; set; }
        public byte[] Data { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ChunkID = reader.ReadInt32();
            this.TotalSubChunks = reader.ReadInt32();
            this.SubChunkID = reader.ReadInt32();
            this.SpectatorChunkType = reader.ReadByte();
            this.TotalSize = reader.ReadInt32();
            this.Duration = reader.ReadInt32();
            this.NextChunkID = reader.ReadInt32();
            this.Data = reader.ReadLeft();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ChunkID);
            writer.WriteInt32(TotalSubChunks);
            writer.WriteInt32(SubChunkID);
            writer.WriteByte(SpectatorChunkType);
            writer.WriteInt32(TotalSize);
            writer.WriteInt32(Duration);
            writer.WriteInt32(NextChunkID);
            writer.WriteBytes(Data);
        }
    }
}
