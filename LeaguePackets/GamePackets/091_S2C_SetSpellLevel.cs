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
        public static S2C_SetSpellLevel CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetSpellLevel();
            result.SenderNetID = senderNetID;
            result.SpellSlot = reader.ReadInt32();
            result.SpellLevel = reader.ReadInt32();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SpellSlot);
            writer.WriteInt32(SpellLevel);
        }
    }
}
