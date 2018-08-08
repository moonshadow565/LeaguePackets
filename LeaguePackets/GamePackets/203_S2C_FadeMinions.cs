using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_FadeMinions : GamePacket // 0xCB
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeMinions;
        public TeamID Team { get; set; }
        public float FadeAmount { get; set; }
        public float FadeTime { get; set; }
        public S2C_FadeMinions(){}

        public S2C_FadeMinions(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Team = (TeamID)reader.ReadByte();
            this.FadeAmount = reader.ReadFloat();
            this.FadeTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte((byte)Team);
            writer.WriteFloat(FadeAmount);
            writer.WriteFloat(FadeTime);
        }
    }
}
