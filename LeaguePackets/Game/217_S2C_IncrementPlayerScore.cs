
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_IncrementPlayerScore : GamePacket // 0xD9
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerScore;
        public uint PlayerNetID { get; set; }
        public byte ScoreCategory { get; set; }
        public byte ScoreEvent { get; set; }
        public bool ShouldCallout { get; set; }
        public float PointValue { get; set; }
        public float TotalPointValue { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.PlayerNetID = reader.ReadUInt32();
            this.ScoreCategory = reader.ReadByte();
            this.ScoreEvent = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.ShouldCallout = (bitfield & 1) != 0;
            this.PointValue = reader.ReadFloat();
            this.TotalPointValue = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(PlayerNetID);
            writer.WriteByte(ScoreCategory);
            writer.WriteByte(ScoreEvent);
            byte bitfield = 0;
            if (ShouldCallout)
                bitfield |= 1;
            writer.WriteByte(bitfield);
            writer.WriteFloat(PointValue);
            writer.WriteFloat(TotalPointValue);
        }
    }
}
