using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetShowAutoAttackIndicator : GamePacket // 0x102
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetShowAutoAttackIndicator;
        public NetID NetID { get; set; }
        public bool ShowIndicator { get; set; }
        public bool ShowMinimapIndicator { get; set; }
        public S2C_UnitSetShowAutoAttackIndicator(){}

        public S2C_UnitSetShowAutoAttackIndicator(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();

            byte bitfield = reader.ReadByte();
            this.ShowIndicator = (bitfield & 0x01) != 0;
            this.ShowMinimapIndicator = (bitfield & 0x02) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);

            byte bitfield = 0;
            if (ShowIndicator)
                bitfield |= 0x01;
            if (ShowMinimapIndicator)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);
        }
    }
}
