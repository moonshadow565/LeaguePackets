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
        public static S2C_FadeMinions CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_FadeMinions();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Team = (TeamID)reader.ReadByte();
            result.FadeAmount = reader.ReadFloat();
            result.FadeTime = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte((byte)Team);
            writer.WriteFloat(FadeAmount);
            writer.WriteFloat(FadeTime);
        }
    }
}
