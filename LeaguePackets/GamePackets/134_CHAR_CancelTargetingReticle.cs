using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class CHAR_CancelTargetingReticle : GamePacket // 0x86
    {
        public override GamePacketID ID => GamePacketID.CHAR_CancelTargetingReticle;
        public byte SpellSlot { get; set; }
        public bool Unknown1 { get; set; }
        public CHAR_CancelTargetingReticle(){}

        public CHAR_CancelTargetingReticle(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.SpellSlot = (byte)(bitfield & 0x3F);
            this.Unknown1 = (bitfield & 0x40) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)SpellSlot & 0x3F);
            if (Unknown1)
                bitfield |= 0x40;
            writer.WriteByte(bitfield);
        }
    }
}
