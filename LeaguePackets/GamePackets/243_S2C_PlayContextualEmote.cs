using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayContextualEmote : GamePacket // 0xF3
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayContextualEmote;
        public ContextualEmoteID EmoteID { get; set; }
        public uint HashedParam { get; set; }
        public ContextualEmoteFlags EmoteFlags { get; set; }
        public S2C_PlayContextualEmote(){}

        public S2C_PlayContextualEmote(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.EmoteID = reader.ReadContextualEmoteID();
            this.HashedParam = reader.ReadUInt32();
            this.EmoteFlags = reader.ReadContextualEmoteFlags();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteContextualEmoteID(EmoteID);
            writer.WriteUInt32(HashedParam);
            writer.WriteContextualEmoteFlags(EmoteFlags);
        }
    }
}
