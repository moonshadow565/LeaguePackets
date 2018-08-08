using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class AI_Command : GamePacket // 0x7A
    {
        public override GamePacketID ID => GamePacketID.AI_Command;
        public string Command { get; set; } = "";
        public AI_Command(){}

        public AI_Command(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Command = reader.ReadFixedStringLast(128);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedStringLast(Command, 128);
        }
    }
}
