using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_OnLeaveTeamVisiblity : GamePacket // 0xE1
    {
        public override GamePacketID ID => GamePacketID.S2C_OnLeaveTeamVisiblity;
        public VisibilityTeam VisibilityTeam { get; set; }
        public S2C_OnLeaveTeamVisiblity(){}

        public S2C_OnLeaveTeamVisiblity(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.VisibilityTeam = reader.ReadVisibilityTeam();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVisibilityTeam(VisibilityTeam);
        }
    }
}
