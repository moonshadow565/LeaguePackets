using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_PopCharacterData : GamePacket // 0x67
    {
        public override GamePacketID ID => GamePacketID.S2C_PopCharacterData;
        public uint PopID { get; set; }
        public S2C_PopCharacterData(){}

        public S2C_PopCharacterData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.PopID = reader.ReadUInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(PopID);
        }
    }
}
