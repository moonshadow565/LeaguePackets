
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_CreateFollowerObject : GamePacket // 0xF1
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateFollowerObject;
        public uint NetID { get; set; }
        public byte NetNodeID { get; set; }
        public int SkinID { get; set; }
        public string InternalName { get; set; } = "";
        public string CharacterName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.SkinID = reader.ReadInt32();
            this.InternalName = reader.ReadFixedString(64);
            this.CharacterName = reader.ReadFixedStringLast(64);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteInt32(SkinID);
            writer.WriteFixedString(InternalName, 64);
            writer.WriteFixedStringLast(CharacterName, 64);
        }
    }
}
