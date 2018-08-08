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
        public NPC_LevelUp(){}

        public NPC_LevelUp(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Level = reader.ReadByte();
            this.AveliablePoints = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Level);
            writer.WriteByte(AveliablePoints);
        }
    }
}
