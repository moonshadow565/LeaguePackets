using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_OnEnterTeamVisiblity : GamePacket // 0xE0
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEnterTeamVisiblity;
        public VisibilityTeam VisibilityTeam { get; set; }

        public static S2C_OnEnterTeamVisiblity CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_OnEnterTeamVisiblity();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.VisibilityTeam = reader.ReadVisibilityTeam();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVisibilityTeam(VisibilityTeam);
        }
    }
}
