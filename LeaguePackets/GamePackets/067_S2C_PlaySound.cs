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
        public static S2C_PlaySound CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_PlaySound();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.SoundName = reader.ReadFixedString(1024);
            result.OwnerNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(SoundName, 1024);
            writer.WriteNetID(OwnerNetID);
        }
    }
}
