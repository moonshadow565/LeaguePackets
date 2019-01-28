
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlayContextualEmote : GamePacket // 0xF3
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayContextualEmote;
        public byte ContextualEmoteID { get; set; }
        public uint HashedParam { get; set; }
        public byte ContextualEmoteFlags { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ContextualEmoteID = reader.ReadByte();
            this.HashedParam = reader.ReadUInt32();
            this.ContextualEmoteFlags = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(ContextualEmoteID);
            writer.WriteUInt32(HashedParam);
            writer.WriteByte(ContextualEmoteFlags);
        }
    }
}
