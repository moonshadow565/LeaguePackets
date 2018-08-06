using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PreloadCharacterData : GamePacket // 0x8A
    {
        public override GamePacketID ID => GamePacketID.S2C_PreloadCharacterData;
        public int SkinID { get; set; }
        public string SkinName { get; set; } = "";
        public static S2C_PreloadCharacterData CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_PreloadCharacterData();
            result.SenderNetID = senderNetID;
            result.SkinID = reader.ReadInt32();
            result.SkinName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(SkinName, 64);
        }
    }
}
