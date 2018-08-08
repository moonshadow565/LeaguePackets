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
        public bool AudioCallbackType { get; set; } //should be enum but its used as bool
        public AudioVOEventType AudioEventType { get; set; }
        public NetID AudioEventNetID { get; set; }
        public static S2C_PlayVOAudioEvent CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_PlayVOAudioEvent();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.FolderName = reader.ReadFixedString(64);
            result.EventID = reader.ReadFixedString(64);
            result.AudioCallbackType = reader.ReadBool();
            result.AudioEventType = reader.ReadAudioVOEventType();
            result.AudioEventNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(FolderName, 64);
            writer.WriteFixedString(EventID, 64);
            writer.WriteBool(AudioCallbackType);
            writer.WriteAudioVOEventType(AudioEventType);
            writer.WriteNetID(AudioEventNetID);
        }
    }
}
