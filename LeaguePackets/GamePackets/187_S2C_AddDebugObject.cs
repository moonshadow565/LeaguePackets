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
        public static S2C_AddDebugObject CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_AddDebugObject();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.DebugID = reader.ReadInt32();
            result.Lifetime = reader.ReadFloat();
            result.Type = reader.ReadByte();
            result.NetID1 = reader.ReadNetID();
            result.NetID2 = reader.ReadNetID();
            result.Radius = reader.ReadFloat();
            result.Point1 = reader.ReadVector3();
            result.Point2 = reader.ReadVector3();
            result.Color = reader.ReadColor();
            result.MaxSize = reader.ReadUInt32();
            result.Bitfield = reader.ReadByte();
            result.StringBuffer = reader.ReadFixedString(128);

            return result;
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
