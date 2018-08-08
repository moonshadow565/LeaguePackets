using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SetFrequency : GamePacket // 0x12
    {
        public override GamePacketID ID => GamePacketID.SetFrequency;
        public float NewFrequency { get; set; }
        public static SetFrequency CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SetFrequency();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NewFrequency = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(NewFrequency);
        }
    }
}
