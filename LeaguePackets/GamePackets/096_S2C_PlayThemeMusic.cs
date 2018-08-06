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
        public static S2C_PlayThemeMusic CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_PlayThemeMusic();
            result.SenderNetID = senderNetID;
            result.SourceNetID = reader.ReadNetID();
            result.MusicID = reader.ReadMusicID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(SourceNetID);
            writer.WriteMusicID(MusicID);
        }
    }
}
