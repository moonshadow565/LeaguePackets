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
        public static S2C_ShowHealthBar CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ShowHealthBar();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.ShowHealthBar = (bitfield & 1) != 0;
            result.ChangeHealthBarType = (bitfield & 2) != 0;
            result.HealthBarType = reader.ReadHealthBarType();
            result.ObserverTeam = reader.ReadTeamID();

            return result;
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
