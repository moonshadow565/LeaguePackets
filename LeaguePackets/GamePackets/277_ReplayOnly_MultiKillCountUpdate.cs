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
        public ReplayOnly_MultiKillCountUpdate(){}

        public ReplayOnly_MultiKillCountUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OwnerNetID = reader.ReadNetID();
            this.MultiKillCount = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(OwnerNetID);
            writer.WriteByte(MultiKillCount);
        }
    }
}
