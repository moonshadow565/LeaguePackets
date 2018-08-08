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
        public S2C_ChangeMissileSpeed(){}

        public S2C_ChangeMissileSpeed(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Speed = reader.ReadFloat();
            this.Delay = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Speed);
            writer.WriteFloat(Delay);
        }
    }
}
