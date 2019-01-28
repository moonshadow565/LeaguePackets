
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class SpawnBotS2C : GamePacket // 0xCF
    {
        public override GamePacketID ID => GamePacketID.SpawnBotS2C;
        public uint NetID { get; set; }
        public byte NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public byte BotRank { get; set; }
        public ushort TeamID { get; set; }

        public int SkinID { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.BotRank = reader.ReadByte();
            ushort bitfield = reader.ReadUInt16();
            this.TeamID = (ushort)(bitfield & 0x1FF);

            this.SkinID = reader.ReadInt32();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteByte(BotRank);
            ushort bitfield = 0;
            bitfield = (ushort)(TeamID & 0x1FF);
            writer.WriteUInt16(bitfield);

            writer.WriteInt32(SkinID);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedStringLast(SkinName, 64);
        }
    }
}
