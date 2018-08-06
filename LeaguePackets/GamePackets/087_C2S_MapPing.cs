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
    public class C2S_MapPing : GamePacket // 0x57
    {
        public override GamePacketID ID => GamePacketID.C2S_MapPing;
        public Vector2 Position { get; set; }
        public NetID TargetNetID { get; set; }
        public PingCategory PingCategory { get; set; }
        public static C2S_MapPing CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new C2S_MapPing();
            result.SenderNetID = senderNetID;
            result.Position = reader.ReadVector2();
            result.TargetNetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            result.PingCategory = (PingCategory)(bitfield & 0x0F);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteNetID(TargetNetID);
            byte bitfield = 0;
            bitfield |= (byte)((byte)PingCategory & 0x0F);
            writer.WriteByte(bitfield);
        }
    }
}
