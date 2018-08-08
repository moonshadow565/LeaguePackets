using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SpectatorDataChunk : GamePacket // 0xED
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorDataChunk;
        public int ChunkID { get; set; }
        public int TotalSubChunks { get; set; }
        public int SubChunkID { get; set; }
        public SpectatorChunkType Type { get; set; }
        public int TotalSize { get; set; }
        public int Duration { get; set; }
        public int NextChunkID { get; set; }
        public byte[] Data { get; set; }
        public S2C_SpectatorDataChunk(){}

        public S2C_SpectatorDataChunk(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ChunkID = reader.ReadInt32();
            this.TotalSubChunks = reader.ReadInt32();
            this.SubChunkID = reader.ReadInt32();
            this.Type = reader.ReadSpectatorChunkType();
            this.TotalSize = reader.ReadInt32();
            this.Duration = reader.ReadInt32();
            this.NextChunkID = reader.ReadInt32();
            this.Data = reader.ReadLeft();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ChunkID);
            writer.WriteInt32(TotalSubChunks);
            writer.WriteInt32(SubChunkID);
            writer.WriteSpectatorChunkType(Type);
            writer.WriteInt32(TotalSize);
            writer.WriteInt32(Duration);
            writer.WriteInt32(NextChunkID);
            writer.WriteBytes(Data);
        }
    }
}
