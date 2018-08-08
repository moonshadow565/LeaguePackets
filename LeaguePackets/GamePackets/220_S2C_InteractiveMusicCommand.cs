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
        public S2C_InteractiveMusicCommand(){}

        public S2C_InteractiveMusicCommand(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MusicCommand = reader.ReadMusicCommand();
            this.MusicEventID = reader.ReadAudioEventID();
            this.MusicParamID = reader.ReadAudioEventID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteMusicCommand(MusicCommand);
            writer.WriteAudioEventID(MusicEventID);
            writer.WriteAudioEventID(MusicParamID);
        }
    }
}
