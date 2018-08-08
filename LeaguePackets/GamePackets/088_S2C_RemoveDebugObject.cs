using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_RemoveDebugObject : GamePacket, IUnusedPacket // 0x58
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveDebugObject;
        public int ObjectID { get; set; }
        public S2C_RemoveDebugObject(){}

        public S2C_RemoveDebugObject(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectID = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
        }
    }
}
