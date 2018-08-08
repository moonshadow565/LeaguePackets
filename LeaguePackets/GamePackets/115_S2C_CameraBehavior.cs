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
        public static S2C_CameraBehavior CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_CameraBehavior();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Position = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
        }
    }
}
