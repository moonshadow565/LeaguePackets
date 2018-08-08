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
    public class AddRegion : GamePacket // 0x23
    {
        public override GamePacketID ID => GamePacketID.AddRegion;
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

        public static AddRegion CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new AddRegion();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TeamID = reader.ReadTeamID();
            result.RegionType = reader.ReadInt32();
            result.ClientID = reader.ReadClientID();
            result.UnitNetID = reader.ReadNetID();
            result.BubbleNetID = reader.ReadNetID();
            result.VisionTargetNetID = reader.ReadNetID();
            result.Position = reader.ReadVector2();
            result.TimeToLive = reader.ReadFloat();
            result.ColisionRadius = reader.ReadFloat();
            result.GrassRadius = reader.ReadFloat();
            result.SizeMultiplier = reader.ReadFloat();
            result.SizeAdditive = reader.ReadFloat();
            uint flags = reader.ReadUInt32();
            result.HasCollision = (flags & 1) != 0;
            result.GrantVision = (flags & 2) != 0;
            result.RevealStealth = (flags & 4) != 0;

            result.BaseRadius = reader.ReadFloat();
        
            return result;
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
            uint flags = 0;
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
            writer.WriteUInt32(flags);
            writer.WriteFloat(BaseRadius);
        }
    }
}
