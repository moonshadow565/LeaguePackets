
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetShowAutoAttackIndicator : GamePacket // 0x102
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetShowAutoAttackIndicator;
        public uint NetID { get; set; }
        public bool ShowIndicator { get; set; }
        public bool ShowMinimapIndicator { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.ShowIndicator = (bitfield & 0x01) != 0;
            this.ShowMinimapIndicator = (bitfield & 0x02) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);

            byte bitfield = 0;
            if (ShowIndicator)
                bitfield |= 0x01;
            if (ShowMinimapIndicator)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);
        }
    }
}
