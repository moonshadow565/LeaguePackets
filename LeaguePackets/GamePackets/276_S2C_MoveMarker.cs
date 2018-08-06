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
    public class S2C_MoveMarker : GamePacket // 0x114
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveMarker;
        public Vector2 Position { get; set; }
        public Vector2 Goal { get; set; }
        public float Speed { get; set; }
        public bool FaceGoalPosition { get; set; }
        public static S2C_MoveMarker CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_MoveMarker();
            result.SenderNetID = senderNetID;
            result.Position = reader.ReadVector2();
            result.Goal = reader.ReadVector2();
            result.Speed = reader.ReadFloat();
            result.FaceGoalPosition = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteVector2(Goal);
            writer.WriteFloat(Speed);
            writer.WriteBool(FaceGoalPosition);
        }
    }
}
