
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    /// <summary>
    /// Shows visual indicator of adding exp to unit
    /// </summary>
    /// <remarks>
    /// Doesn't actually add any exp to unit only shows indicator and only if its enabled on client
    /// </remarks>
    public class UnitAddEXP : GamePacket // 0x10
    {
        public override GamePacketID ID => GamePacketID.UnitAddEXP;
        public uint TargetNetID { get; set; }
        public float ExpAmmount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetNetID = reader.ReadUInt32();
            this.ExpAmmount = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
            writer.WriteFloat(ExpAmmount);
        }
    }
}
