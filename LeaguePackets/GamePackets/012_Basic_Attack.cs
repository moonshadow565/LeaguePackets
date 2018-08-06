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
    public class Basic_Attack : GamePacket // 0xC
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack;
        public BasicAttackDataPacket Attack { get; set; } = new BasicAttackDataPacket();
        public static Basic_Attack CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new Basic_Attack();
            result.SenderNetID = senderNetID;
            result.Attack = reader.ReadBasicAttackDataPacket();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
        }
    }
}
