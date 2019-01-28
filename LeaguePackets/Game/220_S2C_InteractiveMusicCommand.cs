
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_InteractiveMusicCommand : GamePacket // 0xDC
    {
        public override GamePacketID ID => GamePacketID.S2C_InteractiveMusicCommand;
        public byte MusicCommand { get; set; }
        public uint MusicEventAudioEventID { get; set; }
        public uint MusicParamAudioEventID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.MusicCommand = reader.ReadByte();
            this.MusicEventAudioEventID = reader.ReadUInt32();
            this.MusicParamAudioEventID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(MusicCommand);
            writer.WriteUInt32(MusicEventAudioEventID);
            writer.WriteUInt32(MusicParamAudioEventID);
        }
    }
}
