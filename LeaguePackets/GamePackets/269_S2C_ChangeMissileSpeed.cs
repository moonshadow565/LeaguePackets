using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ChangeMissileSpeed : GamePacket // 0x10D
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeMissileSpeed;
        public float Speed { get; set; }
        public float Delay { get; set; }
        public static S2C_ChangeMissileSpeed CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ChangeMissileSpeed();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Speed = reader.ReadFloat();
            result.Delay = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Speed);
            writer.WriteFloat(Delay);
        }
    }
}
