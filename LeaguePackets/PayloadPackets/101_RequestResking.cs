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

        public RequestReskin(){}

        public RequestReskin(PacketReader reader, ChannelID channelID)
        {
            ChannelID = channelID;
            PlayerID = reader.ReadPlayerID();
            SkinID = reader.ReadInt32();
            SkinName = reader.ReadSizedFixedString(128);
            ExtraBytes = reader.ReadLeft();
        }

        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedFixedString(SkinName, 128);
        }
    }
}
