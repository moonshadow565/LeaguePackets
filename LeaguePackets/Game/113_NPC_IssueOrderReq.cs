
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_IssueOrderReq : GamePacket // 0x72
    {
        public override GamePacketID ID => GamePacketID.NPC_IssueOrderReq;
        public byte OrderType { get; set; }
        public Vector2 Position { get; set; }
        public uint TargetNetID { get; set; }
        public MovementDataNormal MovementData { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.OrderType = reader.ReadByte();
            this.Position = reader.ReadVector2();
            this.TargetNetID = reader.ReadUInt32();
            if(reader.BytesLeft > 4)
            {
                this.MovementData = new MovementDataNormal(reader, 0);
            }
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(OrderType);
            writer.WriteVector2(Position);
            writer.WriteUInt32(TargetNetID);
            if(MovementData != null)
            {
                MovementData.Write(writer);
            }
        }
    }
}
