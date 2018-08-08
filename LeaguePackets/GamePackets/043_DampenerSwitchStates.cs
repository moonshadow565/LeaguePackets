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
        public ushort Duration { get; set; }
        public bool State { get; set; }
        public DampenerSwitchStates(){}

        public DampenerSwitchStates(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            ushort bitfield = reader.ReadUInt16();
            this.Duration = (ushort)(bitfield & 0x7FFF);
            this.State = (bitfield & 0x8000) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            ushort bitfield = 0;
            bitfield |= (ushort)(Duration & 0x7FFF);
            if (State)
                bitfield |= 0x8000;
            writer.WriteUInt16(bitfield);
        }
    }
}
