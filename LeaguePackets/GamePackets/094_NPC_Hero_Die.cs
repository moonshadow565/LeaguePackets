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
    public class NPC_Hero_Die : GamePacket // 0x5E
    {
        public override GamePacketID ID => GamePacketID.NPC_Hero_Die;
        public DeathDataPacket DeathData { get; set; } = new DeathDataPacket();
        public static NPC_Hero_Die CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_Hero_Die();
            result.SenderNetID = senderNetID;
            result.DeathData = reader.ReadDeathDataPacket();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteDeathDataPacket(DeathData);
        }
    }
}
