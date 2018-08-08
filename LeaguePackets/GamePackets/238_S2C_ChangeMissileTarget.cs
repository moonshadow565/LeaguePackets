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
        public S2C_ChangeMissileTarget(){}

        public S2C_ChangeMissileTarget(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.TargetPosition = reader.ReadVector3();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteVector3(TargetPosition);
        }
    }
}
