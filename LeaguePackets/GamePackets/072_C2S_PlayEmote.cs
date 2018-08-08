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
        public static C2S_PlayEmote CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_PlayEmote();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.EmoteID = reader.ReadEmoteID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteEmoteID(EmoteID);
        }
    }
}
