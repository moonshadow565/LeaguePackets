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
        public static S2C_IncrementPlayerScore CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_IncrementPlayerScore();
            result.SenderNetID = senderNetID;
            result.PlayerNetID = reader.ReadNetID();
            result.ScoreCategory = reader.ReadScoreCategory();
            result.ScoreEvent = reader.ReadScoreEvent();
            byte bitfield = reader.ReadByte();
            result.ShouldCallout = (bitfield & 1) != 0;
            result.PointValue = reader.ReadFloat();
            result.TotalPointValue = reader.ReadFloat();
        
            return result;
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
