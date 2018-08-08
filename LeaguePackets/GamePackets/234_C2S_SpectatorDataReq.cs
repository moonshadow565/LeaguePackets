using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_SpectatorDataReq : GamePacket // 0xEA
    {
        public override GamePacketID ID => GamePacketID.C2S_SpectatorDataReq;
        public bool SendMetaData { get; set; }
        public bool JumpToLatest { get; set; }
        public int StartChunkID { get; set; }
        public int StartKeyFrameID { get; set; }
        public C2S_SpectatorDataReq(){}

        public C2S_SpectatorDataReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SendMetaData = reader.ReadBool();
            this.JumpToLatest = reader.ReadBool();
            this.StartChunkID = reader.ReadInt32();
            this.StartKeyFrameID = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(SendMetaData);
            writer.WriteBool(JumpToLatest);
            writer.WriteInt32(StartChunkID);
            writer.WriteInt32(StartKeyFrameID);
        }
    }
}
