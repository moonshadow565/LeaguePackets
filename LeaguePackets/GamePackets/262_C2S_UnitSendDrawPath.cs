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
    public class C2S_UnitSendDrawPath : GamePacket // 0x106
    {
        public override GamePacketID ID => GamePacketID.C2S_UnitSendDrawPath;
        public NetID TargetNetID { get; set; }
        public DrawPathNodeType DrawPathNodeType { get; set; }
        public Vector3 Point { get; set; }
        public static C2S_UnitSendDrawPath CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_UnitSendDrawPath();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TargetNetID = reader.ReadNetID();
            result.DrawPathNodeType = reader.ReadDrawPathNodeType();
            result.Point = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteDrawPathNodeType(DrawPathNodeType);
            writer.WriteVector3(Point);
        }
    }
}
