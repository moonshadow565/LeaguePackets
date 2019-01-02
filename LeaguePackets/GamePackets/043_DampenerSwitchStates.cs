using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class DampenerSwitchStates : GamePacket // 0x2B
    {
        public override GamePacketID ID => GamePacketID.DampenerSwitchStates;
        public byte State { get; set; }
        public ushort Duration { get; set; }
        public DampenerSwitchStates(){}

        public DampenerSwitchStates(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.State = reader.ReadByte();
            this.Duration = reader.ReadUInt16();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(State);
            writer.WriteUInt16(Duration);
        }
    }
}
