using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ForceTargetSpell : GamePacket, IUnusedPacket // 0x129
    {
        public override GamePacketID ID => GamePacketID.S2C_ForceTargetSpell;
        //FIXME: 4.18+
        public S2C_ForceTargetSpell(){}

        public S2C_ForceTargetSpell(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
