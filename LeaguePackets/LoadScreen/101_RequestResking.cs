
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public sealed class RequestReskin : LoadScreenPacket // 0x65
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestResking;
        public long PlayerID { get; set; }
        public int SkinID { get; set; }
        public string SkinName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {
            PlayerID = reader.ReadInt64();
            SkinID = reader.ReadInt32();
            SkinName = reader.ReadSizedStringLast();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt64(PlayerID);
            writer.WriteInt32(SkinID);
            writer.WriteSizedStringLast(SkinName);
        }
    }
}
