using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class TeamRosterUpdate : PayloadPacket // 0x67
    {
        public override PayloadPacketID ID => PayloadPacketID.TeamRosterUpdate;
        private PlayerID[] _orderMembers = new PlayerID[24];
        private PlayerID[] _chaosMembers = new PlayerID[24];

        public uint TeamSizeOrder { get; set; }
        public uint TeamSizeChaos { get; set; }
        public PlayerID[] OrderMembers => _orderMembers;
        public PlayerID[] ChaosMembers => _chaosMembers;
        public uint TeamSizeOrderCurrent { get; set; }
        public uint TeamSIzeChaosCurrent { get; set; }

        public static TeamRosterUpdate CreateBody(PacketReader reader)
        {
            var result = new TeamRosterUpdate();
            result.TeamSizeOrder = reader.ReadUInt32();
            result.TeamSizeChaos = reader.ReadUInt32();
            for (int i = 0; i < result.OrderMembers.Length; i++)
            {
                result.OrderMembers[i] = reader.ReadPlayerID(); 
            }
            for (int i = 0; i < result.ChaosMembers.Length; i++)
            {
                result.ChaosMembers[i] = reader.ReadPlayerID();
            }
            result.TeamSizeOrderCurrent = reader.ReadUInt32();
            result.TeamSIzeChaosCurrent = reader.ReadUInt32();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(TeamSizeOrder);
            writer.WriteUInt32(TeamSizeChaos);
            for (int i = 0; i < OrderMembers.Length; i++)
            {
                writer.WritePlayerID(OrderMembers[i]);
            }
            for (int i = 0; i < ChaosMembers.Length; i++)
            {
                writer.WritePlayerID(ChaosMembers[i]);
            }
            writer.WriteUInt32(TeamSizeOrderCurrent);
            writer.WriteUInt32(TeamSIzeChaosCurrent);
        }
    }
}
