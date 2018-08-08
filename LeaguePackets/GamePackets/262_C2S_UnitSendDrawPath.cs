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
        public C2S_UnitSendDrawPath(){}

        public C2S_UnitSendDrawPath(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.DrawPathNodeType = reader.ReadDrawPathNodeType();
            this.Point = reader.ReadVector3();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteDrawPathNodeType(DrawPathNodeType);
            writer.WriteVector3(Point);
        }
    }
}
