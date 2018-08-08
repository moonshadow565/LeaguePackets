using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.PayloadPackets
{
    public class RequestRename : PayloadPacket // 0x66
    {
        public override PayloadPacketID ID => PayloadPacketID.RequestRename;
        public PlayerID PlayerID { get; set; }
        public int SkinID { get; set; }
        public string PlayerName { get; set; } = "";

        public RequestRename(){}

        public RequestRename(PacketReader reader, ChannelID channelID)
        {
            ChannelID = channelID;
            PlayerID = reader.ReadPlayerID();
            SkinID = reader.ReadInt32();
            PlayerName = reader.ReadSizedFixedStringLast(128);
            ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedFixedStringLast(PlayerName, 128);
        }
    }
}
