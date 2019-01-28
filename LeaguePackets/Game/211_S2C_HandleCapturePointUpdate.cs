
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_HandleCapturePointUpdate : GamePacket // 0xD3
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleCapturePointUpdate;
        public byte CapturePointIndex { get; set; }
        public uint OtherNetID { get; set; }
        public byte PARType { get; set; }
        public uint AttackTeam { get; set; }
        public byte CapturePointUpdateCommand { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.CapturePointIndex = reader.ReadByte();
            this.OtherNetID = reader.ReadUInt32();
            this.PARType = reader.ReadByte();
            this.AttackTeam = reader.ReadUInt32();
            this.CapturePointUpdateCommand = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(CapturePointIndex);
            writer.WriteUInt32(OtherNetID);
            writer.WriteByte(PARType);
            writer.WriteUInt32(AttackTeam);
            writer.WriteByte(CapturePointUpdateCommand);
        }
    }
}
