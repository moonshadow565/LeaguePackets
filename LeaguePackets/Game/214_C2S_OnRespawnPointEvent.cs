
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_OnRespawnPointEvent : GamePacket // 0xD6
    {
        public override GamePacketID ID => GamePacketID.C2S_OnRespawnPointEvent;
        public byte RespawnPointEvent { get; set; }
        public byte RespawnPointUIID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.RespawnPointEvent = reader.ReadByte();
            this.RespawnPointUIID = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(RespawnPointEvent);
            writer.WriteByte(RespawnPointUIID);
        }
    }
}
