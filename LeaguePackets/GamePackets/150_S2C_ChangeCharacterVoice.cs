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
        public static S2C_ChangeCharacterVoice CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ChangeCharacterVoice();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Unknown1 = (bitfield) != 0;
            result.VoiceOverride = reader.ReadFixedString(128);
        
            return result;
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
