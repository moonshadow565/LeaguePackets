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
        public static S2C_ToolTipVars CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ToolTipVars();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            int size = reader.ReadUInt16() / 85;
            for (int i = 0; i < size; i++)
            {
                result.Tooltips.Add(reader.ReadTooltipValues());
            }

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            int size = Tooltips.Count * 85;
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
