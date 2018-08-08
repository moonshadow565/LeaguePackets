using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_FX_OnLeaveTeamVisiblity : GamePacket // 0xE3
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_OnLeaveTeamVisiblity;
        public NetID NetID { get; set; }
        public VisibilityTeam VisibilityTeam { get; set; }
        public S2C_FX_OnLeaveTeamVisiblity(){}

        public S2C_FX_OnLeaveTeamVisiblity(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.VisibilityTeam = reader.ReadVisibilityTeam();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteVisibilityTeam(VisibilityTeam);
        }
    }
}
