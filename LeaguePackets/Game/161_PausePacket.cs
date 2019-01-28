
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class PausePacket : GamePacket // 0xA1
    {
        public override GamePacketID ID => GamePacketID.PausePacket;
        public int ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool IsTournament { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ClientID = reader.ReadInt32();
            this.PauseTimeRemaining = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            this.IsTournament = (bitfield & 1) != 0;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteInt32(PauseTimeRemaining);
            byte bitfield = 0;
            if (IsTournament)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
