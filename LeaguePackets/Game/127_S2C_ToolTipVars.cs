
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class S2C_ToolTipVars : GamePacket // 0x7F
    {
        public override GamePacketID ID => GamePacketID.S2C_ToolTipVars;
        public List<TooltipVars> Tooltips { get; set; } = new List<TooltipVars>();

        protected override void ReadBody(ByteReader reader)
        {

            int size = reader.ReadUInt16();
            for (int i = 0; i < size; i++)
            {
                this.Tooltips.Add(reader.ReadTooltipValues());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            int size = Tooltips.Count;
            if(size > 0xFFFF)
            {
                throw new IOException("Tooltips list too big!");
            }
            writer.WriteUInt16((ushort)size);
            for (int i = 0; i < size; i++)
            {
                writer.WriteTooltipValues(Tooltips[i]);
            }
        }
    }
}
