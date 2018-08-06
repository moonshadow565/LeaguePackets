using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ModifyDebugObjectColor : GamePacket // 0x90
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugObjectColor;
        public int ObjectID { get; set; }
        public Color Color { get; set; }
        public static S2C_ModifyDebugObjectColor CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_ModifyDebugObjectColor();
            result.SenderNetID = senderNetID;
            result.ObjectID = reader.ReadInt32();
            result.Color = reader.ReadColor();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(ObjectID);
            writer.WriteColor(Color);
        }
    }
}
