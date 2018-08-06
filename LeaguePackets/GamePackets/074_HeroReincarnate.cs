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
    public class HeroReincarnate : GamePacket // 0x4A
    {
        public override GamePacketID ID => GamePacketID.HeroReincarnate;
        public Vector2 Position { get; set; }
        public float PARValue { get; set; }
        public static HeroReincarnate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new HeroReincarnate();
            result.SenderNetID = senderNetID;
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
