using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayEmote : GamePacket // 0x42
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayEmote;
        public EmoteID EmoteID { get; set; }
        public S2C_PlayEmote(){}

        public S2C_PlayEmote(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.EmoteID = reader.ReadEmoteID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteEmoteID(EmoteID);
        }
    }
}
