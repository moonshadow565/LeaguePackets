using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_InteractiveMusicCommand : GamePacket // 0xDC
    {
        public override GamePacketID ID => GamePacketID.S2C_InteractiveMusicCommand;
        public MusicCommand MusicCommand { get; set; }
        public AudioEventID MusicEventID { get; set; }
        public AudioEventID MusicParamID { get; set; }
        public static S2C_InteractiveMusicCommand CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_InteractiveMusicCommand();
            result.SenderNetID = senderNetID;
            result.MusicCommand = reader.ReadMusicCommand();
            result.MusicEventID = reader.ReadAudioEventID();
            result.MusicParamID = reader.ReadAudioEventID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteMusicCommand(MusicCommand);
            writer.WriteAudioEventID(MusicEventID);
            writer.WriteAudioEventID(MusicParamID);
        }
    }
}
