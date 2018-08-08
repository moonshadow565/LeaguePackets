using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PlayThemeMusic : GamePacket // 0x60
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayThemeMusic;
        public NetID SourceNetID { get; set; }
        public MusicID MusicID { get; set; }
        public S2C_PlayThemeMusic(){}

        public S2C_PlayThemeMusic(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SourceNetID = reader.ReadNetID();
            this.MusicID = reader.ReadMusicID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(SourceNetID);
            writer.WriteMusicID(MusicID);
        }
    }
}
