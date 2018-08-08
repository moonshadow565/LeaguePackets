using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetInputLockFlag : GamePacket // 0x84
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInputLockFlag;
        public InputLockFlags InputLockFlag { get; set; }
        public bool Value { get; set; }
        public S2C_SetInputLockFlag(){}

        public S2C_SetInputLockFlag(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.InputLockFlag = reader.ReadInputLockFlags();
            byte bitfield = reader.ReadByte();
            this.Value = (bitfield & 1) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInputLockFlags(InputLockFlag);
            byte bitfield = 0;
            if (Value)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
