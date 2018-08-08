using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_UpgradeSpellAns : GamePacket // 0x15
    {
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellAns;
        public byte Slot { get; set; }
        public byte SpellLevel { get; set; }
        public byte SkillPoints { get; set; }
        public NPC_UpgradeSpellAns(){}

        public NPC_UpgradeSpellAns(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Slot = reader.ReadByte();
            this.SpellLevel = reader.ReadByte();
            this.SkillPoints = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellLevel);
            writer.WriteByte(SkillPoints);
        }
    }
}
