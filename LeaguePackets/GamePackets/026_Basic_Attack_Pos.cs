using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class Basic_Attack_Pos : GamePacket // 0x1A
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack_Pos;
        public BasicAttackDataPacket Attack { get; set; } = new BasicAttackDataPacket();
        public Vector2 Position { get; set; }
        public static Basic_Attack_Pos CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new Basic_Attack_Pos();
            result.SenderNetID = senderNetID;
            result.Attack = reader.ReadBasicAttackDataPacket();
            result.Position = reader.ReadVector2();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
            writer.WriteVector2(Position);
        }
    }
}
