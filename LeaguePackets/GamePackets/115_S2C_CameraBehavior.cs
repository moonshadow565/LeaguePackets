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
    public class S2C_CameraBehavior : GamePacket // 0x73
    {
        public override GamePacketID ID => GamePacketID.S2C_CameraBehavior;
        public Vector3 Position { get; set; }
        public S2C_CameraBehavior(){}

        public S2C_CameraBehavior(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector3();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
        }
    }
}
