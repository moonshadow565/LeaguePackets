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

        public static NPC_IssueOrderReq CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_IssueOrderReq();
            result.SenderNetID = senderNetID;
            result.OrderType = reader.ReadOrderType();
            result.Position = reader.ReadVector2();
            result.TargetNetID = reader.ReadNetID();
            //TODO: do switch on OrderType to detrimine if we need to read waypoints and make child classes
            if((reader.Stream.Length - reader.Stream.Position) >= 5)
            {
                byte count = reader.ReadByte();
                result.WaypointsNetID = reader.ReadNetID();
                result.Waypoints = reader.ReadCompressedWaypoints(count / 2u);
            }
            return result;
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
