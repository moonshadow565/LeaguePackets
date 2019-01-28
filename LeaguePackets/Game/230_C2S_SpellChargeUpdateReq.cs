
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class C2S_SpellChargeUpdateReq : GamePacket // 0xE6
    {
        public override GamePacketID ID => GamePacketID.C2S_SpellChargeUpdateReq;
        public byte Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        // FIXME: ForceStop deprecated ?
        public bool ForceStop { get; set; }

        public Vector3 Position { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.IsSummonerSpellBook = (bitfield & 0x01) != 0;
            this.ForceStop = (bitfield & 0x02) != 0;

            this.Slot = reader.ReadByte();
            this.Position = reader.ReadVector3();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (IsSummonerSpellBook)
                bitfield |= 0x01;
            if (ForceStop)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);

            writer.WriteByte(Slot);
            writer.WriteVector3(Position);
        }
    }
}
