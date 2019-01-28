
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class NPC_CastSpellReq : GamePacket // 0x9A
    {
        public override GamePacketID ID => GamePacketID.NPC_CastSpellReq;
        public byte Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        public bool IsHudClickCast { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 EndPosition { get; set; }
        public uint TargetNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.IsSummonerSpellBook = (bitfield & 0x01) != 0;
            this.IsHudClickCast = (bitfield & 0x02) != 0;

            this.Slot = reader.ReadByte();
            this.Position = reader.ReadVector2();
            this.EndPosition = reader.ReadVector2();
            this.TargetNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (IsSummonerSpellBook)
                bitfield |= 0x01;
            if (IsHudClickCast)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);

            writer.WriteByte(Slot);
            writer.WriteVector2(Position);
            writer.WriteVector2(EndPosition);
            writer.WriteUInt32(TargetNetID);
        }
    }
}
