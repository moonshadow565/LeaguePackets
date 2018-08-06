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
    public class S2C_SetCircularMovementRestriction : GamePacket // 0x6
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCircularMovementRestriction;
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public bool Unk1 { get; set; }
        public static S2C_SetCircularMovementRestriction CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetCircularMovementRestriction();
            result.SenderNetID = senderNetID;
            result.Center = reader.ReadVector3();
            result.Radius = reader.ReadFloat();

            var bitfield = reader.ReadByte();
            result.Unk1 = (bitfield & 0x01u) != 0; 

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Center);
            writer.WriteFloat(Radius);

            byte bitfield = 0;
            if (Unk1) 
                bitfield |= 1;
            
            writer.WriteByte(bitfield);
        }
    }
}
