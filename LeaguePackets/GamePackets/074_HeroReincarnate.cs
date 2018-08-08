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
        public HeroReincarnate(){}

        public HeroReincarnate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector2();
            this.PARValue = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteFloat(PARValue);
        }
    }
}
