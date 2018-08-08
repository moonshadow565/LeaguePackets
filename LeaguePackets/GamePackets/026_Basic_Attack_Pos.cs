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
        public Basic_Attack_Pos(){}

        public Basic_Attack_Pos(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Attack = reader.ReadBasicAttackDataPacket();
            this.Position = reader.ReadVector2();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
            writer.WriteVector2(Position);
        }
    }
}
