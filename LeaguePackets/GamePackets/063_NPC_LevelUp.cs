using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_LevelUp : GamePacket // 0x3F
    {
        public override GamePacketID ID => GamePacketID.NPC_LevelUp;
        public byte Level { get; set; }
        public byte AveliablePoints { get; set; }
        public static NPC_LevelUp CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_LevelUp();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Level = reader.ReadByte();
            result.AveliablePoints = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Level);
            writer.WriteByte(AveliablePoints);
        }
    }
}
