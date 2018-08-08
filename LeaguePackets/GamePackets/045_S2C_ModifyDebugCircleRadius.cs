using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ModifyDebugCircleRadius : GamePacket, IUnusedPacket // 0x2D
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleRadius;
        public int ObjectID { get; set; }
        public float Radius { get; set; }
        public S2C_ModifyDebugCircleRadius(){}

        public S2C_ModifyDebugCircleRadius(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectID = reader.ReadInt32();
            this.Radius = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteFloat(Radius);
        }
    }
}
