using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlaySound : GamePacket // 0x43
    {
        public override GamePacketID ID => GamePacketID.S2C_PlaySound;
        public string SoundName { get; set; } = "";
        public NetID OwnerNetID { get; set; }
        public S2C_PlaySound(){}

        public S2C_PlaySound(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SoundName = reader.ReadFixedString(1024);
            this.OwnerNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(SoundName, 1024);
            writer.WriteNetID(OwnerNetID);
        }
    }
}
