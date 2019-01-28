
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class C2S_MapPing : GamePacket // 0x57
    {
        public override GamePacketID ID => GamePacketID.C2S_MapPing;
        public Vector2 Position { get; set; }
        public uint TargetNetID { get; set; }
        public byte PingCategory { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector2();
            this.TargetNetID = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.PingCategory = (byte)(bitfield & 0x0F);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteUInt32(TargetNetID);
            byte bitfield = 0;
            bitfield |= (byte)(PingCategory & 0x0F);
            writer.WriteByte(bitfield);
        }
    }
}
