
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_HandleTipUpdate : GamePacket // 0x55
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleTipUpdate;
        public string TipName { get; set; } = "";
        public string TipOther { get; set; } = "";
        public string TipImagePath { get; set; } = "";
        public byte TipCommand { get; set; }
        public uint TipID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TipName = reader.ReadFixedString(128);
            this.TipOther = reader.ReadFixedString(128);
            this.TipImagePath = reader.ReadFixedString(128);
            this.TipCommand = reader.ReadByte();
            this.TipID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(TipName, 128);
            writer.WriteFixedString(TipOther, 128);
            writer.WriteFixedString(TipImagePath, 128);
            writer.WriteByte(TipCommand);
            writer.WriteUInt32(TipID);
        }
    }
}
