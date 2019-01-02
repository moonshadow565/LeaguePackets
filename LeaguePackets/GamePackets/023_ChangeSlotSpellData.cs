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

            this.SpellSlot = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            bool isSummonerSpell = (bitfield & 0x01) != 0;

            this.IsSummonerSpell = isSummonerSpell;
            this.ChangeSpellData = reader.ReadChangeSpellData();
            this.ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(SpellSlot);

            byte bitfield = 0;
            if (IsSummonerSpell)
                bitfield |= 0x01;

            writer.WriteByte(bitfield);
            ChangeSpellData.WriteBodyInternal(writer);
        }
    }
}
