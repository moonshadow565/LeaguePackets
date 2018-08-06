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

        public static RequestRename CreateBody(PacketReader reader)
        {
            var result = new RequestRename();
            result.PlayerID = reader.ReadPlayerID();
            result.SkinID = reader.ReadInt32();
            result.PlayerName = reader.ReadSizedFixedString(128);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePlayerID(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedFixedString(PlayerName, 128);
        }
    }
}
