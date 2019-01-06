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
    public class ChangeSlotSpellData_OwnerOnly : GamePacket // 0x125
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData_OwnerOnly;
        public ChangeSpellData ChangeSpellData { get; set; } = null;

        public ChangeSlotSpellData_OwnerOnly(){}

        public ChangeSlotSpellData_OwnerOnly(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ChangeSpellData = reader.ReadChangeSpellData();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteChangeSpellData(ChangeSpellData);
        }
    }
}
