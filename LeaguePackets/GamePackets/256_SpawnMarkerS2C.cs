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
        public static SpawnMarkerS2C CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SpawnMarkerS2C();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Position = reader.ReadVector3();
            result.VisibilitySize = reader.ReadFloat();
        
            return result;
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
