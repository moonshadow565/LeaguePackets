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
        public static C2S_SpectatorDataReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_SpectatorDataReq();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SendMetaData = reader.ReadBool();
            result.JumpToLatest = reader.ReadBool();
            result.StartChunkID = reader.ReadInt32();
            result.StartKeyFrameID = reader.ReadInt32();
        
            return result;
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
