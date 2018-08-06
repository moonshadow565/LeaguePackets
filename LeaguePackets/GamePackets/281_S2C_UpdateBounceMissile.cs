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
        public static S2C_UpdateBounceMissile CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_UpdateBounceMissile();
            result.SenderNetID = senderNetID;
            result.TargetNetID = reader.ReadNetID();
            result.CasterPosition = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteVector3(CasterPosition);
        }
    }
}
