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
        public static NPC_UpgradeSpellAns CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_UpgradeSpellAns();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Slot = reader.ReadByte();
            result.SpellLevel = reader.ReadByte();
            result.SkillPoints = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(SpellLevel);
            writer.WriteByte(SkillPoints);
        }
    }
}
