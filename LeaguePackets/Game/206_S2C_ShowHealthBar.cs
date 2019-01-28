
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ShowHealthBar : GamePacket // 0xCE
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowHealthBar;
        public bool ShowHealthBar { get; set;}
        public bool ChangeHealthBarType { get; set; }
        // TODO: make HealthBarType optional instead of using a bool
        public byte HealthBarType { get; set; }
        public uint ObserverTeamID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.ShowHealthBar = (bitfield & 1) != 0;
            this.ChangeHealthBarType = (bitfield & 2) != 0;
            this.HealthBarType = reader.ReadByte(); // should be writen only when ObserverTeam
            if (this.ChangeHealthBarType)
            {
                this.ObserverTeamID = reader.ReadUInt32();
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if(ShowHealthBar)
            {
                bitfield |= 1;
            }
            if(ChangeHealthBarType)
            {
                bitfield |= 2;
            }
            writer.WriteByte(bitfield);
            writer.WriteByte(HealthBarType);
            if (ChangeHealthBarType)
            {
                writer.WriteUInt32(ObserverTeamID);
            }
        }
    }
}
