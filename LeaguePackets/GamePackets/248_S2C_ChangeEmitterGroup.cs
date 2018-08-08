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
        public S2C_ChangeEmitterGroup(){}

        public S2C_ChangeEmitterGroup(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.GroupName = reader.ReadFixedString(256);
            this.OperationData = reader.ReadInt32();
            this.GroupOperation = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(GroupName, 256);
            writer.WriteInt32(OperationData);
            writer.WriteByte(GroupOperation);
        }
    }
}
