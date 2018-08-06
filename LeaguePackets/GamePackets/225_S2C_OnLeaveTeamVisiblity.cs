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
        public static S2C_OnLeaveTeamVisiblity CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_OnLeaveTeamVisiblity();
            result.SenderNetID = senderNetID;
            result.VisibilityTeam = reader.ReadVisibilityTeam();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVisibilityTeam(VisibilityTeam);
        }
    }
}
