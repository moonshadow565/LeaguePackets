
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class C2S_TutorialAudioEventFinished : GamePacket // 0x5
    {
        public override GamePacketID ID => GamePacketID.C2S_TutorialAudioEventFinished;
        public uint AudioEventNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.AudioEventNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(AudioEventNetID);
        }
    }
}
