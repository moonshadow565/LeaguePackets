
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_IncrementPlayerStat : GamePacket // 0xDA
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerStat;
        public uint PlayerNetID { get; set; }
        public byte StatEvent { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.PlayerNetID = reader.ReadUInt32();
            this.StatEvent = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(PlayerNetID);
            writer.WriteByte(StatEvent);
        }
    }
}
