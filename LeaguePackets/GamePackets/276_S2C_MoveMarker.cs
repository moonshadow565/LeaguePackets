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
        public S2C_MoveMarker(){}

        public S2C_MoveMarker(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector2();
            this.Goal = reader.ReadVector2();
            this.Speed = reader.ReadFloat();
            this.FaceGoalPosition = reader.ReadBool();
        
            this.ExtraBytes = reader.ReadLeft();
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
