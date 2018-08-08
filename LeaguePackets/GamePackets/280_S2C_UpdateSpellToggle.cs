using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UpdateSpellToggle : GamePacket // 0x118
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateSpellToggle;
        public int SpellSlot { get; set; }
        public bool ToggleValue { get; set; }
        public S2C_UpdateSpellToggle(){}

        public S2C_UpdateSpellToggle(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SpellSlot = reader.ReadInt32();
            this.ToggleValue = reader.ReadBool();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SpellSlot);
            writer.WriteBool(ToggleValue);
        }
    }
}
