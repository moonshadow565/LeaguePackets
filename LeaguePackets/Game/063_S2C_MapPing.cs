
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_MapPing : GamePacket // 0x40
    {
        public override GamePacketID ID => GamePacketID.S2C_MapPing;
        public Vector2 Position { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }

        public byte PingCategory { get; set; }
        public bool PlayAudio { get; set; }
        public bool ShowChat { get; set; }
        public bool PingThrottled { get; set; }
        public bool PlayVO { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector2();
            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.PingCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.PlayAudio = (bitfield & 0x01) != 0;
            this.ShowChat = (bitfield & 0x02) != 0;
            this.PingThrottled = (bitfield & 0x04) != 0;
            this.PlayVO = (bitfield & 0x08) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteUInt32(TargetNetID);
            writer.WriteUInt32(SourceNetID);
            writer.WriteByte(PingCategory);
            byte bitfield = 0;
            if (PlayAudio)
                bitfield |= 0x01;
            if (ShowChat)
                bitfield |= 0x02;
            if (PingThrottled)
                bitfield |= 0x04;
            if (PlayVO)
                bitfield |= 0x08;
            writer.WriteByte(bitfield);
        }
    }
}
