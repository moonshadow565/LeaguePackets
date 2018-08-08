using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ChangeCharacterVoice : GamePacket // 0x96
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterVoice;
        public bool Unknown1 { get; set; } // set to default/zero? 
        public string VoiceOverride { get; set; } = "";
        public S2C_ChangeCharacterVoice(){}

        public S2C_ChangeCharacterVoice(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Unknown1 = (bitfield) != 0;
            this.VoiceOverride = reader.ReadFixedString(128);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Unknown1)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);
            writer.WriteFixedString(VoiceOverride, 128);
        }
    }
}
