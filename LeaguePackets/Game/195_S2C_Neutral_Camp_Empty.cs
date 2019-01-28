
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_Neutral_Camp_Empty : GamePacket // 0xC3
    {
        public override GamePacketID ID => GamePacketID.S2C_Neutral_Camp_Empty;
        public uint KillerNetID { get; set; }
        public int CampIndex { get; set; }
        public int TimerType { get; set; }
        public float TimerExpire { get; set; }
        public bool DoPlayVO { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.KillerNetID = reader.ReadUInt32();
            this.CampIndex = reader.ReadInt32();
            this.TimerType = reader.ReadInt32();
            this.TimerExpire = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            this.DoPlayVO = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(KillerNetID);
            writer.WriteInt32(CampIndex);
            writer.WriteInt32(TimerType);
            writer.WriteFloat(TimerExpire);
            
            byte bitfield = 0;
            if (DoPlayVO)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
