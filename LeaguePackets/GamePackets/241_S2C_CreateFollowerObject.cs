using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_CreateFollowerObject : GamePacket // 0xF1
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateFollowerObject;
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public int SkinID { get; set; }
        public string InternalName { get; set; } = "";
        public string CharacterName { get; set; } = "";
        public static S2C_CreateFollowerObject CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_CreateFollowerObject();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.SkinID = reader.ReadInt32();
            result.InternalName = reader.ReadFixedString(64);
            result.CharacterName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(InternalName, 64);
            writer.WriteFixedString(CharacterName, 64);
        }
    }
}
