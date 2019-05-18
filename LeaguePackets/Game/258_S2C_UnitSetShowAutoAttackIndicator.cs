
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
            this.ShowIndicator = reader.ReadBool();
            this.ShowMinimapIndicator = reader.ReadBool();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteBool(ShowIndicator);
            writer.WriteBool(ShowMinimapIndicator);
        }
    }
}
