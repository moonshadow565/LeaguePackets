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
        public static S2C_SetInputLockFlag CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SetInputLockFlag();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.InputLockFlag = reader.ReadInputLockFlags();
            byte bitfield = reader.ReadByte();
            result.Value = (bitfield & 1) != 0;
        
            return result;
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
