
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_PlayVOAudioEvent : GamePacket // 0x79
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayVOAudioEvent;
        public string FolderName { get; set; } = "";
        public string EventID { get; set; } = "";
        public byte AudioCallbackType { get; set; }
        public byte AudioVOEventType { get; set; }
        public uint AudioEventNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.FolderName = reader.ReadFixedString(64);
            this.EventID = reader.ReadFixedString(64);
            this.AudioCallbackType = reader.ReadByte();
            this.AudioVOEventType = reader.ReadByte();
            this.AudioEventNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(FolderName, 64);
            writer.WriteFixedString(EventID, 64);
            writer.WriteByte(AudioCallbackType);
            writer.WriteByte(AudioVOEventType);
            writer.WriteUInt32(AudioEventNetID);
        }
    }
}
