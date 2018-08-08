using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class SpawnMarkerS2C : GamePacket // 0x100
    {
        public override GamePacketID ID => GamePacketID.SpawnMarkerS2C;
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public float VisibilitySize { get; set; }
        public SpawnMarkerS2C(){}

        public SpawnMarkerS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Position = reader.ReadVector3();
            this.VisibilitySize = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteFloat(VisibilitySize);
        }
    }
}
