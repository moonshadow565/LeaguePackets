using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ShowHealthBar : GamePacket // 0xCE
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowHealthBar;
        public bool ShowHealthBar { get; set;}
        public bool ChangeHealthBarType { get; set; }
        public HealthBarType HealthBarType { get; set; }
        public TeamID ObserverTeam { get; set; }
        public S2C_ShowHealthBar(){}

        public S2C_ShowHealthBar(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.ShowHealthBar = (bitfield & 1) != 0;
            this.ChangeHealthBarType = (bitfield & 2) != 0;
            this.HealthBarType = reader.ReadHealthBarType();
            this.ObserverTeam = reader.ReadTeamID();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
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
            writer.WriteHealthBarType(HealthBarType);
            writer.WriteTeamID(ObserverTeam);
        }
    }
}
