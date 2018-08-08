using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ChangeEmitterGroup : GamePacket // 0xF8
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeEmitterGroup;
        public string GroupName { get; set; } = "";
        public int OperationData { get; set; }
        public byte GroupOperation { get; set; }
        public static S2C_ChangeEmitterGroup CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ChangeEmitterGroup();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.GroupName = reader.ReadFixedString(256);
            result.OperationData = reader.ReadInt32();
            result.GroupOperation = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(GroupName, 256);
            writer.WriteInt32(OperationData);
            writer.WriteByte(GroupOperation);
        }
    }
}
