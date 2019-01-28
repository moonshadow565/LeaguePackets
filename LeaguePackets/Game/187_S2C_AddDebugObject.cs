
using LeaguePackets.Game.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_AddDebugObject : GamePacket, IUnusedPacket // 0xBB
    {
        public override GamePacketID ID => GamePacketID.S2C_AddDebugObject;
        public int DebugID { get; set; }
        public float Lifetime { get; set; }
        public byte Type { get; set; }
        public uint NetID1 { get; set; }
        public uint NetID2 { get; set; }
        public float Radius { get; set; }
        public Vector3 Point1 { get; set; }
        public Vector3 Point2 { get; set; }
        public Color Color { get; set; }
        public uint MaxSize { get; set; }
        public byte Bitfield { get; set; }
        public string StringBuffer { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.DebugID = reader.ReadInt32();
            this.Lifetime = reader.ReadFloat();
            this.Type = reader.ReadByte();
            this.NetID1 = reader.ReadUInt32();
            this.NetID2 = reader.ReadUInt32();
            this.Radius = reader.ReadFloat();
            this.Point1 = reader.ReadVector3();
            this.Point2 = reader.ReadVector3();
            this.Color = reader.ReadColor();
            this.MaxSize = reader.ReadUInt32();
            this.Bitfield = reader.ReadByte();
            this.StringBuffer = reader.ReadFixedStringLast(128);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(DebugID);
            writer.WriteFloat(Lifetime);
            writer.WriteByte(Type);
            writer.WriteUInt32(NetID1);
            writer.WriteUInt32(NetID2);
            writer.WriteFloat(Radius);
            writer.WriteVector3(Point1);
            writer.WriteVector3(Point2);
            writer.WriteColor(Color);
            writer.WriteUInt32(MaxSize);
            writer.WriteByte(Bitfield);
            writer.WriteFixedStringLast(StringBuffer, 128);
        }
    }
}
