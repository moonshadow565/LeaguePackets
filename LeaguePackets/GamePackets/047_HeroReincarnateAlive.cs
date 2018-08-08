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
        public HeroReincarnateAlive(){}

        public HeroReincarnateAlive(PacketReader reader, ChannelID channelID, NetID senderNetID)
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
