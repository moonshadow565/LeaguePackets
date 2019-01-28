
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_CastSpellAns : GamePacket // 0xB5
    {
        public override GamePacketID ID => GamePacketID.NPC_CastSpellAns;
        public int CasterPositionSyncID { get; set; }
        public bool Unknown1 { get; set; } //if this is false CasterPositionSyncID is used ?
        public CastInfo CastInfo { get; set; } = new CastInfo();

        protected override void ReadBody(ByteReader reader)
        {

            this.CasterPositionSyncID = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            this.Unknown1 = (bitfield & 1) != 0;

            this.CastInfo = reader.ReadCastInfo();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(CasterPositionSyncID);

            byte bitfield = 0;
            if(Unknown1)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);

            writer.WriteCastInfo(CastInfo);
        }
    }
}
