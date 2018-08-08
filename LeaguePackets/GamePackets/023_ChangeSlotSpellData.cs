using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class ChangeSlotSpellData : GamePacket // 0x17
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData;
        public byte SpellSlot { get; set; }
        public bool IsSummonerSpell { get; set; }
        public IChangeSpellData ChangeSpellData { get; set; } = null;

        public ChangeSlotSpellData(){}

        public ChangeSlotSpellData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.ChannelID = channelID;
            this.SenderNetID = senderNetID;

            byte bitfield = reader.ReadByte();
            byte spellSlot = (byte)(bitfield & 0x3F);
            bool isSummonerSpell = (bitfield & 0x40) != 0;
            this.SpellSlot = spellSlot;
            this.IsSummonerSpell = isSummonerSpell;
            this.ChangeSpellData = reader.ReadChangeSpellData();
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)((byte)SpellSlot & 0x3F);
            if (IsSummonerSpell)
                bitfield |= 0x40;

            writer.WriteByte(bitfield);
            ChangeSpellData.WriteBodyInternal(writer);
        }
    }
}
