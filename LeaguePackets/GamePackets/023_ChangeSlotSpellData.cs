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

        public static ChangeSlotSpellData CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new ChangeSlotSpellData();
            result.ChannelID = channelID;
            result.SenderNetID = senderNetID;

            byte bitfield = reader.ReadByte();
            byte spellSlot = (byte)(bitfield & 0x3F);
            bool isSummonerSpell = (bitfield & 0x40) != 0;
            result.SpellSlot = spellSlot;
            result.IsSummonerSpell = isSummonerSpell;
            result.ChangeSpellData = reader.ReadChangeSpellData();
            return result;
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
