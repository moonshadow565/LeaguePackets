using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SpectatorDataChunkInfo : GamePacket // 0xEC
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorDataChunkInfo;
        public int StartGameChunkId { get; set; }
        public int EndGameChunkId { get; set; }
        public S2C_SpectatorDataChunkInfo(){}

        public S2C_SpectatorDataChunkInfo(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.StartGameChunkId = reader.ReadInt32();
            this.EndGameChunkId = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(StartGameChunkId);
            writer.WriteInt32(EndGameChunkId);
        }
    }
}
