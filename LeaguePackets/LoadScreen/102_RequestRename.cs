
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public sealed class RequestRename : LoadScreenPacket // 0x66
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestRename;
        public long PlayerID { get; set; }
        public int SkinID { get; set; }
        public string PlayerName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {
            PlayerID = reader.ReadInt64();
            SkinID = reader.ReadInt32();
            PlayerName = reader.ReadSizedStringLast();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt64(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedStringLast(PlayerName);
        }
    }
}
