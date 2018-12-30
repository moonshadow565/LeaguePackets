using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class S2C_ToolTipVars : GamePacket // 0x7F
    {
        public override GamePacketID ID => GamePacketID.S2C_ToolTipVars;
        public List<TooltipVars> Tooltips { get; set; } = new List<TooltipVars>();
        public S2C_ToolTipVars(){}

        public S2C_ToolTipVars(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            int size = reader.ReadUInt16();
            for (int i = 0; i < size; i++)
            {
                this.Tooltips.Add(reader.ReadTooltipValues());
            }

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
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
