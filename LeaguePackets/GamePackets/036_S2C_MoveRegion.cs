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
        public S2C_MoveRegion(){}

        public S2C_MoveRegion(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.RegionNetID = reader.ReadNetID();
            this.Position = reader.ReadVector2();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(RegionNetID);
            writer.WriteVector2(Position);
        }
    }
}
