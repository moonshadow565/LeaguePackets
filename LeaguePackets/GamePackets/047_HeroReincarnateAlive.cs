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
    public class HeroReincarnateAlive : GamePacket // 0x2F
    {
        public override GamePacketID ID => GamePacketID.HeroReincarnateAlive;
        public Vector2 Position { get; set; }
        public float PARValue { get; set; }
        public static HeroReincarnateAlive CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new HeroReincarnateAlive();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Position = reader.ReadVector2();
            result.PARValue = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteFloat(PARValue);
        }
    }
}
