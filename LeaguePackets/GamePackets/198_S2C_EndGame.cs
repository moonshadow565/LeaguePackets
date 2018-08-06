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
        public static S2C_EndGame CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_EndGame();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.IsTeamOrderWin = (bitfield & 1) != 0;
        
            return result;
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
