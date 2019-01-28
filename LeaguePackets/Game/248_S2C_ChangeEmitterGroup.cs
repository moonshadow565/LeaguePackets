
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ChangeEmitterGroup : GamePacket // 0xF8
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeEmitterGroup;
        public string GroupName { get; set; } = "";
        public int OperationData { get; set; }
        public int GroupOperation { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.GroupName = reader.ReadFixedString(256);
            this.OperationData = reader.ReadInt32();
            this.GroupOperation = reader.ReadInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(GroupName, 256);
            writer.WriteInt32(OperationData);
            writer.WriteInt32(GroupOperation);
        }
    }
}
