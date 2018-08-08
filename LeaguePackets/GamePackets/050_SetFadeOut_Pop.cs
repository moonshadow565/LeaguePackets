using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SetFadeOut_Pop : GamePacket // 0x32
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Pop;
        public short StackID { get; set; }
        public SetFadeOut_Pop(){}

        public SetFadeOut_Pop(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.StackID = reader.ReadInt16();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt16(StackID);
        }
    }
}
