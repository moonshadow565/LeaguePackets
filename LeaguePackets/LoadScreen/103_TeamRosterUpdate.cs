
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public sealed class TeamRosterUpdate : LoadScreenPacket // 0x67
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.TeamRosterUpdate;
        private long[] _orderMembers = new long[24];
        private long[] _chaosMembers = new long[24];
        public uint TeamSizeOrder { get; set; }
        public uint TeamSizeChaos { get; set; }
        public long[] OrderMembers => _orderMembers;
        public long[] ChaosMembers => _chaosMembers;
        public uint TeamSizeOrderCurrent { get; set; }
        public uint TeamSIzeChaosCurrent { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            TeamSizeOrder = reader.ReadUInt32();
            TeamSizeChaos = reader.ReadUInt32();
            for (int i = 0; i < OrderMembers.Length; i++)
            {
                OrderMembers[i] = reader.ReadInt64(); 
            }
            for (int i = 0; i < ChaosMembers.Length; i++)
            {
                ChaosMembers[i] = reader.ReadInt64();
            }
            TeamSizeOrderCurrent = reader.ReadUInt32();
            TeamSIzeChaosCurrent = reader.ReadUInt32();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TeamSizeOrder);
            writer.WriteUInt32(TeamSizeChaos);
            for (int i = 0; i < OrderMembers.Length; i++)
            {
                writer.WriteInt64(OrderMembers[i]);
            }
            for (int i = 0; i < ChaosMembers.Length; i++)
            {
                writer.WriteInt64(ChaosMembers[i]);
            }
            writer.WriteUInt32(TeamSizeOrderCurrent);
            writer.WriteUInt32(TeamSIzeChaosCurrent);
        }
    }
}
