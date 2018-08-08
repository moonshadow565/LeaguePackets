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
    public class S2C_ChangeMissileTarget : GamePacket // 0xEE
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeMissileTarget;
        public NetID TargetNetID { get; set; }
        public Vector3 TargetPosition { get; set; }
        public static S2C_ChangeMissileTarget CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ChangeMissileTarget();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TargetNetID = reader.ReadNetID();
            result.TargetPosition = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteVector3(TargetPosition);
        }
    }
}
