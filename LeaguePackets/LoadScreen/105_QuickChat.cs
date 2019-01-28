
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public sealed class QuickChat : LoadScreenPacket // 0x69
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.QuickChat;
        public int ClientID { get; set; }
        public short MessageId { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            ClientID = reader.ReadInt32();
            MessageId = reader.ReadInt16();
            ExtraBytes = reader.ReadLeft();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteInt16(MessageId);
        }
    }
}
