using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ReplayOnly_MultiKillCountUpdate : GamePacket // 0x115
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_MultiKillCountUpdate;
        public NetID OwnerNetID { get; set; }
        public byte MultiKillCount { get; set; }
        public static ReplayOnly_MultiKillCountUpdate CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new ReplayOnly_MultiKillCountUpdate();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.OwnerNetID = reader.ReadNetID();
            result.MultiKillCount = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(OwnerNetID);
            writer.WriteByte(MultiKillCount);
        }
    }
}
