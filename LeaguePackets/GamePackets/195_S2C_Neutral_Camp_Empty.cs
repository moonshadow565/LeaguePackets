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
        public S2C_Neutral_Camp_Empty(){}

        public S2C_Neutral_Camp_Empty(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.KillerNetID = reader.ReadNetID();
            this.CampIndex = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            this.DoPlayVO = (bitfield & 1) != 0;

            this.TimerType = reader.ReadInt32();
            this.TimerExpire = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
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
