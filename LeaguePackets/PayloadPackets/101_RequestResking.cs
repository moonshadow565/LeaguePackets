using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class RequestReskin : PayloadPacket // 0x65
    {
        public override PayloadPacketID ID => PayloadPacketID.RequestResking;
        public PlayerID PlayerID { get; set; }
        public int SkinID { get; set; }
        public string SkinName { get; set; } = "";

        public static RequestReskin CreateBody(PacketReader reader, ChannelID channelID)
        {
            var result = new RequestReskin();
            result.ChannelID = channelID;
            result.PlayerID = reader.ReadPlayerID();
            result.SkinID = reader.ReadInt32();
            result.SkinName = reader.ReadSizedFixedString(128);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedFixedString(SkinName, 128);
        }
    }
}
