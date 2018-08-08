using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_UpgradeSpellReq : GamePacket // 0x39
    {
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellReq;
        public byte Slot { get; set; }
        public bool IsEvolve { get; set; }
        public NPC_UpgradeSpellReq(){}

        public NPC_UpgradeSpellReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.IsEvolve = (bitfield & 1) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            byte bitfield = 0;
            if (IsEvolve)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
