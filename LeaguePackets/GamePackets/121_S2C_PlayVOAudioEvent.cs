using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayVOAudioEvent : GamePacket // 0x79
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayVOAudioEvent;
        public string FolderName { get; set; } = "";
        public string EventID { get; set; } = "";
        public byte AudioCallbackType { get; set; }
        public AudioVOEventType AudioEventType { get; set; }
        public NetID AudioEventNetID { get; set; }
        public S2C_PlayVOAudioEvent(){}

        public S2C_PlayVOAudioEvent(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.FolderName = reader.ReadFixedString(64);
            this.EventID = reader.ReadFixedString(64);
            this.AudioCallbackType = reader.ReadByte();
            this.AudioEventType = reader.ReadAudioVOEventType();
            this.AudioEventNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(FolderName, 64);
            writer.WriteFixedString(EventID, 64);
            writer.WriteByte(AudioCallbackType);
            writer.WriteAudioVOEventType(AudioEventType);
            writer.WriteNetID(AudioEventNetID);
        }
    }
}
