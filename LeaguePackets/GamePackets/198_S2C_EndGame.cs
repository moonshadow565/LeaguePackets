using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_EndGame : GamePacket // 0xC6
    {
        public override GamePacketID ID => GamePacketID.S2C_EndGame;
        public bool IsTeamOrderWin { get; set; }
        public S2C_EndGame(){}

        public S2C_EndGame(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.IsTeamOrderWin = (bitfield & 1) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (IsTeamOrderWin)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
