using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_PlayContextualEmote : GamePacket // 0xF4
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayContextualEmote;
        public C2S_PlayContextualEmote(){}

        public C2S_PlayContextualEmote(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_PlayContextualEmote(); 
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) { }
    }
}
