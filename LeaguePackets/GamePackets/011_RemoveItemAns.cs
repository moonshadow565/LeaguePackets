using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class RemoveItemAns : GamePacket // 0xB
    {
        public override GamePacketID ID => GamePacketID.RemoveItemAns;
        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }
        public bool NotifyInventoryChange { get; set; }
        public RemoveItemAns(){}

        public RemoveItemAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.NotifyInventoryChange = (bitfield & 0x01) != 0;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);

            byte bitfield = 0;
            if (NotifyInventoryChange)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}
