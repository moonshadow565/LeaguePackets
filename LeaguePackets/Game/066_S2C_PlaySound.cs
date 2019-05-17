
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlaySound : GamePacket // 0x43
    {
        public override GamePacketID ID => GamePacketID.S2C_PlaySound;
        public string SoundName { get; set; } = "";
        public uint OwnerNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.SoundName = reader.ReadFixedString(1024);
            this.OwnerNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(SoundName, 1024);
            writer.WriteUInt32(OwnerNetID);
        }
    }
}
