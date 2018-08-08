using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class S2C_AddDebugObject : GamePacket, IUnusedPacket // 0xBB
    {
        public override GamePacketID ID => GamePacketID.S2C_AddDebugObject;
        public int DebugID { get; set; }
        public float Lifetime { get; set; }
        public byte Type { get; set; }
        public NetID NetID1 { get; set; }
        public NetID NetID2 { get; set; }
        public float Radius { get; set; }
        public Vector3 Point1 { get; set; }
        public Vector3 Point2 { get; set; }
        public Color Color { get; set; }
        public uint MaxSize { get; set; }
        public byte Bitfield { get; set; }
        public string StringBuffer { get; set; } = "";
        public S2C_AddDebugObject(){}

        public S2C_AddDebugObject(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.DebugID = reader.ReadInt32();
            this.Lifetime = reader.ReadFloat();
            this.Type = reader.ReadByte();
            this.NetID1 = reader.ReadNetID();
            this.NetID2 = reader.ReadNetID();
            this.Radius = reader.ReadFloat();
            this.Point1 = reader.ReadVector3();
            this.Point2 = reader.ReadVector3();
            this.Color = reader.ReadColor();
            this.MaxSize = reader.ReadUInt32();
            this.Bitfield = reader.ReadByte();
            this.StringBuffer = reader.ReadFixedString(128);

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(DebugID);
            writer.WriteFloat(Lifetime);
            writer.WriteByte(Type);
            writer.WriteNetID(NetID1);
            writer.WriteNetID(NetID2);
            writer.WriteFloat(Radius);
            writer.WriteVector3(Point1);
            writer.WriteVector3(Point2);
            writer.WriteColor(Color);
            writer.WriteUInt32(MaxSize);
            writer.WriteByte(Bitfield);
            writer.WriteFixedString(StringBuffer, 128);
        }
    }
}
