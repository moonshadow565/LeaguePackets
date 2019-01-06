using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ModifyDebugObjectColor : GamePacket, IUnusedPacket // 0x90
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugObjectColor;
        public int ObjectID { get; set; }
        public Color Color { get; set; }
        public S2C_ModifyDebugObjectColor(){}

        public S2C_ModifyDebugObjectColor(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectID = reader.ReadInt32();
            this.Color = reader.ReadColor();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteColor(Color);
        }
    }
}
