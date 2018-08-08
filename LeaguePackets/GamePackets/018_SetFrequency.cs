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
        public SetFrequency(){}

        public SetFrequency(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NewFrequency = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(NewFrequency);
        }
    }
}
