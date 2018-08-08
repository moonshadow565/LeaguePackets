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
        public Basic_Attack(){}

        public Basic_Attack(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Attack = reader.ReadBasicAttackDataPacket();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBasicAttackDataPacket(Attack);
        }
    }
}
