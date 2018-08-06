using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SpectatorMetaData : GamePacket // 0xEB
    {
        public override GamePacketID ID => GamePacketID.S2C_SpectatorMetaData;
        public string JsonMetaData { get; set; } = "";
        public static S2C_SpectatorMetaData CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SpectatorMetaData();
            result.SenderNetID = senderNetID;
            result.JsonMetaData = reader.ReadSizedString();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteSizedString(JsonMetaData);
        }
    }
}
