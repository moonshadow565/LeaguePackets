using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_IncrementPlayerScore : GamePacket // 0xD9
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerScore;
        public NetID PlayerNetID { get; set; }
        public ScoreCategory ScoreCategory { get; set; }
        public ScoreEvent ScoreEvent { get; set; }
        public bool ShouldCallout { get; set; }
        public float PointValue { get; set; }
        public float TotalPointValue { get; set; }
        public S2C_IncrementPlayerScore(){}

        public S2C_IncrementPlayerScore(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.PlayerNetID = reader.ReadNetID();
            this.ScoreCategory = reader.ReadScoreCategory();
            this.ScoreEvent = reader.ReadScoreEvent();
            byte bitfield = reader.ReadByte();
            this.ShouldCallout = (bitfield & 1) != 0;
            this.PointValue = reader.ReadFloat();
            this.TotalPointValue = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(PlayerNetID);
            writer.WriteScoreCategory(ScoreCategory);
            writer.WriteScoreEvent(ScoreEvent);
            byte bitfield = 0;
            if (ShouldCallout)
                bitfield |= 1;
            writer.WriteByte(bitfield);
            writer.WriteFloat(PointValue);
            writer.WriteFloat(TotalPointValue);
        }
    }
}
