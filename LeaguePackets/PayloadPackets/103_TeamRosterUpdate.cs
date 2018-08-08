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

        public TeamRosterUpdate(){}

        public TeamRosterUpdate(PacketReader reader, ChannelID channelID)
        {
            ChannelID = channelID;
            TeamSizeOrder = reader.ReadUInt32();
            TeamSizeChaos = reader.ReadUInt32();
            for (int i = 0; i < OrderMembers.Length; i++)
            {
                OrderMembers[i] = reader.ReadPlayerID(); 
            }
            for (int i = 0; i < ChaosMembers.Length; i++)
            {
                ChaosMembers[i] = reader.ReadPlayerID();
            }
            TeamSizeOrderCurrent = reader.ReadUInt32();
            TeamSIzeChaosCurrent = reader.ReadUInt32();
            ExtraBytes = reader.ReadLeft();
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
