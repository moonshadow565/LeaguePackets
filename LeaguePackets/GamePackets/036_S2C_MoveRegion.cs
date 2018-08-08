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
    public class S2C_MoveRegion : GamePacket // 0x24
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveRegion;
        public NetID RegionNetID { get; set; }
        public Vector2 Position { get; set; }
        public static S2C_MoveRegion CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_MoveRegion();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.RegionNetID = reader.ReadNetID();
            result.Position = reader.ReadVector2();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(RegionNetID);
            writer.WriteVector2(Position);
        }
    }
}
