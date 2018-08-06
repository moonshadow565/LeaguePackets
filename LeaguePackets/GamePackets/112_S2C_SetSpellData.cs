using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetSpellData : GamePacket // 0x70
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellData;
        public NetID ObjectNetID { get; set; }
        public uint HashedSpellName { get; set; }
        public byte SpellSlot { get; set; }
        public static S2C_SetSpellData CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetSpellData();
            result.SenderNetID = senderNetID;
            throw new NotImplementedException("S2C_SetSpellData.Read");
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            throw new NotImplementedException("S2C_SetSpellData.Write");
        }
    }
}
