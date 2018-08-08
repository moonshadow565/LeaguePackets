using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_Neutral_Camp_Empty : GamePacket // 0xC3
    {
        public override GamePacketID ID => GamePacketID.S2C_Neutral_Camp_Empty;
        public NetID KillerNetID { get; set; }
        public int CampIndex { get; set; }
        public bool DoPlayVO { get; set; } 
        public int TimerType { get; set; }
        public float TimerExpire { get; set; }
        public static S2C_Neutral_Camp_Empty CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_Neutral_Camp_Empty();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.KillerNetID = reader.ReadNetID();
            result.CampIndex = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            result.DoPlayVO = (bitfield & 1) != 0;

            result.TimerType = reader.ReadInt32();
            result.TimerExpire = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(KillerNetID);
            writer.WriteInt32(CampIndex);
            byte bitfield = 0;
            if (DoPlayVO)
                bitfield |= 1;
            writer.WriteByte(bitfield);

            writer.WriteInt32(TimerType);
            writer.WriteFloat(TimerExpire);
        }
    }
}
