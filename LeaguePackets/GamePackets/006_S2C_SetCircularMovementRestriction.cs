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
        public S2C_SetCircularMovementRestriction(){}

        public S2C_SetCircularMovementRestriction(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Center = reader.ReadVector3();
            this.Radius = reader.ReadFloat();

            var bitfield = reader.ReadByte();
            this.Unk1 = (bitfield & 0x01u) != 0; 

            this.ExtraBytes = reader.ReadLeft();
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
