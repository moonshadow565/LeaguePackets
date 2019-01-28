
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class AddRegion : GamePacket // 0x23
    {
        public override GamePacketID ID => GamePacketID.AddRegion;
        public uint TeamID { get; set; }
        public int RegionType { get; set; }
        public int ClientID { get; set; }
        public uint UnitNetID { get; set; }
        public uint BubbleNetID { get; set; }
        public uint VisionTargetNetID { get; set; }
        public Vector2 Position { get; set; }
        public float TimeToLive { get; set; }
        public float ColisionRadius { get; set; }
        public float GrassRadius { get; set; }
        public float SizeMultiplier { get; set; }
        public float SizeAdditive { get; set; }

        public bool HasCollision { get; set; }
        public bool GrantVision { get; set; }
        public bool RevealStealth { get; set; }

        public float BaseRadius { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.TeamID = reader.ReadUInt32();
            this.RegionType = reader.ReadInt32();
            this.ClientID = reader.ReadInt32();
            this.UnitNetID = reader.ReadUInt32();
            this.BubbleNetID = reader.ReadUInt32();
            this.VisionTargetNetID = reader.ReadUInt32();
            this.Position = reader.ReadVector2();
            this.TimeToLive = reader.ReadFloat();
            this.ColisionRadius = reader.ReadFloat();
            this.GrassRadius = reader.ReadFloat();
            this.SizeMultiplier = reader.ReadFloat();
            this.SizeAdditive = reader.ReadFloat();
            byte flags = reader.ReadByte();
            this.HasCollision = (flags & 1) != 0;
            this.GrantVision = (flags & 2) != 0;
            this.RevealStealth = (flags & 4) != 0;

            this.BaseRadius = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TeamID);
            writer.WriteInt32(RegionType);
            writer.WriteInt32(ClientID);
            writer.WriteUInt32(UnitNetID);
            writer.WriteUInt32(BubbleNetID);
            writer.WriteUInt32(VisionTargetNetID);
            writer.WriteVector2(Position);
            writer.WriteFloat(TimeToLive);
            writer.WriteFloat(ColisionRadius);
            writer.WriteFloat(GrassRadius);
            writer.WriteFloat(SizeMultiplier);
            writer.WriteFloat(SizeAdditive);
            byte flags = 0;
            if(HasCollision)
            {
                flags |= 1;
            }
            if(GrantVision)
            {
                flags |= 2;
            }
            if(RevealStealth)
            {
                flags |= 4;
            }
            writer.WriteByte(flags);
            writer.WriteFloat(BaseRadius);
        }
    }
}
