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
        public S2C_CreateFollowerObject(){}

        public S2C_CreateFollowerObject(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.SkinID = reader.ReadInt32();
            this.InternalName = reader.ReadFixedString(64);
            this.CharacterName = reader.ReadFixedString(64);
        
            this.ExtraBytes = reader.ReadLeft();
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
