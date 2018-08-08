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
    public class S2C_FaceDirection : GamePacket // 0x50
    {
        public override GamePacketID ID => GamePacketID.S2C_FaceDirection;
        public Vector3 Direction { get; set; }
        public bool DoLerpTime { get; set; }
        public float LerpTime { get; set; }
        public S2C_FaceDirection(){}

        public S2C_FaceDirection(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Direction = reader.ReadVector3();
            byte flags = reader.ReadByte();
            this.DoLerpTime = (flags & 1) != 0;
            this.LerpTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Direction);
            byte flags = 0;
            if (DoLerpTime)
                flags |= 1;
            writer.WriteByte(flags);
            writer.WriteFloat(LerpTime);
        }
    }
}
