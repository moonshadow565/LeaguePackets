using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetCursorReticle : GamePacket // 0x108
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetCursorReticle;
        public float Radius { get; set; }
        public float SecondaryRadius { get; set; }
        public S2C_UnitSetCursorReticle(){}

        public S2C_UnitSetCursorReticle(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Radius = reader.ReadFloat();
            this.SecondaryRadius = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Radius);
            writer.WriteFloat(SecondaryRadius);
        }
    }
}
