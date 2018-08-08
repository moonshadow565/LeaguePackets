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
    public class S2C_UpdateBounceMissile : GamePacket // 0x119
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateBounceMissile;
        public NetID TargetNetID { get; set; }
        public Vector3 CasterPosition { get; set; }
        public S2C_UpdateBounceMissile(){}

        public S2C_UpdateBounceMissile(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.CasterPosition = reader.ReadVector3();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteVector3(CasterPosition);
        }
    }
}
