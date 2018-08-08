using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_PlayEmote : GamePacket // 0x48
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayEmote;
        public EmoteID EmoteID { get; set; }
        public C2S_PlayEmote(){}

        public C2S_PlayEmote(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
