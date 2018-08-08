using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetSpellLevel : GamePacket // 0x5B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellLevel;
        public int SpellSlot { get; set; }
        public int SpellLevel { get; set; }
        public S2C_SetSpellLevel(){}

        public S2C_SetSpellLevel(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SpellSlot = reader.ReadInt32();
            this.SpellLevel = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SpellSlot);
            writer.WriteInt32(SpellLevel);
        }
    }
}
