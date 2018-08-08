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
        public S2C_PreloadCharacterData(){}

        public S2C_PreloadCharacterData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.SkinID = reader.ReadInt32();
            this.SkinName = reader.ReadFixedString(64);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(SkinName, 64);
        }
    }
}
