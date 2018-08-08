using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class NPC_IssueOrderReq : GamePacket // 0x72
    {
        public override GamePacketID ID => GamePacketID.NPC_IssueOrderReq;
        public OrderType OrderType { get; set; }
        public Vector2 Position { get; set; }
        public NetID TargetNetID { get; set; }
        public NetID WaypointsNetID { get; set; }
        public List<Tuple<short, short>> Waypoints { get; set; } = new List<Tuple<short, short>>();

        public NPC_IssueOrderReq(){}

        public NPC_IssueOrderReq(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.OrderType = reader.ReadOrderType();
            this.Position = reader.ReadVector2();
            this.TargetNetID = reader.ReadNetID();
            //TODO: do switch on OrderType to detrimine if we need to read waypoints and make child classes
            if((reader.Stream.Length - reader.Stream.Position) >= 5)
            {
                byte count = reader.ReadByte();
                this.WaypointsNetID = reader.ReadNetID();
                this.Waypoints = reader.ReadCompressedWaypoints(count / 2u);
            }
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteOrderType(OrderType);
            writer.WriteVector2(Position);
            writer.WriteNetID(TargetNetID);
            int waypointsCount = Waypoints.Count;
            if(waypointsCount > 0x80)
            {
                throw new IOException("Too many waypoints to write!");
            }
            //TODO: do switch on OrderType to detrimine if we need to write waypoints and make child classes
            writer.WriteByte((byte)(waypointsCount * 2u));
            writer.WriteNetID(WaypointsNetID);
            writer.WriteCompressedWaypoints(Waypoints);
        }
    }
}
