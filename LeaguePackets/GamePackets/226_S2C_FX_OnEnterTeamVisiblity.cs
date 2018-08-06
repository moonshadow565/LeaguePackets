using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_FX_OnEnterTeamVisiblity : GamePacket, IUnusedPacket // 0xE2
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_OnEnterTeamVisiblity;
        public NetID NetID { get; set; }
        public TeamID Team { get; set; }
        public static S2C_FX_OnEnterTeamVisiblity CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_FX_OnEnterTeamVisiblity();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
            result.Team = reader.ReadTeamID();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteTeamID(Team);
        }
    }
}
