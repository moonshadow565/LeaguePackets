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
    public class UNK_0x12E_AddRegion : GamePacket // 0x12E
    {
        public override GamePacketID ID => GamePacketID.UNK_0x12E_AddRegion;
        public TeamID TeamID { get; set; }
        public int RegionType { get; set; }
        public ClientID ClientID { get; set; }
        public NetID UnitNetID { get; set; }
        public NetID BubbleNetID { get; set; }
        public NetID VisionTargetNetID { get; set; }
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

        // FIXME:  unknowns
        public float Unknown1 { get; set; }
        public float Unknown2 { get; set; }
        public float Unknown3 { get; set; }

        public UNK_0x12E_AddRegion(){}

        public UNK_0x12E_AddRegion(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;
            
            this.TeamID = reader.ReadTeamID();
            this.RegionType = reader.ReadInt32();
            this.ClientID = reader.ReadClientID();
            this.UnitNetID = reader.ReadNetID();
            this.BubbleNetID = reader.ReadNetID();
            this.VisionTargetNetID = reader.ReadNetID();
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

            this.Unknown1 = reader.ReadFloat();
            this.Unknown2 = reader.ReadFloat();
            this.Unknown3 = reader.ReadFloat();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteTeamID(TeamID);
            writer.WriteInt32(RegionType);
            writer.WriteClientID(ClientID);
            writer.WriteNetID(UnitNetID);
            writer.WriteNetID(BubbleNetID);
            writer.WriteNetID(VisionTargetNetID);
            writer.WriteVector2(Position);
            writer.WriteFloat(TimeToLive);
            writer.WriteFloat(ColisionRadius);
            writer.WriteFloat(GrassRadius);
            writer.WriteFloat(SizeMultiplier);
            writer.WriteFloat(SizeAdditive);

            byte flags = 0;
            if (HasCollision)
            {
                flags |= 1;
            }
            if (GrantVision)
            {
                flags |= 2;
            }
            if (RevealStealth)
            {
                flags |= 4;
            }
            writer.WriteByte(flags);

            writer.WriteFloat(BaseRadius);

            writer.WriteFloat(Unknown1);
            writer.WriteFloat(Unknown2);
            writer.WriteFloat(Unknown3);
        }
    }
}
