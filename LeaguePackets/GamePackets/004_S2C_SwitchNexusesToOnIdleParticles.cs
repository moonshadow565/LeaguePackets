using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SwitchNexusesToOnIdleParticles : GamePacket // 0x4
    {
        public override GamePacketID ID => GamePacketID.S2C_SwitchNexusesToOnIdleParticles;
        public static S2C_SwitchNexusesToOnIdleParticles CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_SwitchNexusesToOnIdleParticles();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            return result;
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
