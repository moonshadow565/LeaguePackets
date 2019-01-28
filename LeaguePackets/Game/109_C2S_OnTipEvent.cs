
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_OnTipEvent : GamePacket // 0x6D
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTipEvent;
        public byte TipCommand { get; set; }
        public uint TipID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TipCommand = reader.ReadByte();
            this.TipID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(TipCommand);
            writer.WriteUInt32(TipID);
        }
    }
}
