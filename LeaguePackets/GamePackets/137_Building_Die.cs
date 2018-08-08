using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Building_Die : GamePacket // 0x89
    {
        public override GamePacketID ID => GamePacketID.Building_Die;
        public NetID AttackerNetID { get; set; }
        public NetID LastHeroNetID { get; set; }
        public Building_Die(){}

        public Building_Die(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AttackerNetID = reader.ReadNetID();
            this.LastHeroNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(AttackerNetID);
            writer.WriteNetID(LastHeroNetID);
        }
    }
}
