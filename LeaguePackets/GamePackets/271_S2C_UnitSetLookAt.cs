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
    public class S2C_UnitSetLookAt : GamePacket // 0x10F
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetLookAt;
        public LookAtType LookAtType { get; set; }
        public Vector3 TargetPosition { get; set; }
        public NetID TargetNetID { get; set; }
        public static S2C_UnitSetLookAt CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetLookAt();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.LookAtType = reader.ReadLookAtType();
            result.TargetPosition = reader.ReadVector3();
            result.TargetNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteLookAtType(LookAtType);
            writer.WriteVector3(TargetPosition);
            writer.WriteNetID(TargetNetID);
        }
    }
}
