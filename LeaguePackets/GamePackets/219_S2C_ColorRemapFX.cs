using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ColorRemapFX : GamePacket // 0xDB
    {
        public override GamePacketID ID => GamePacketID.S2C_ColorRemapFX;
        public bool IsFadingIn { get; set; }
        public float FadeTime { get; set; }
        public TeamID TeamID { get; set; }
        public Color Color { get; set; }
        public float MaxWeight { get; set; }
        public S2C_ColorRemapFX(){}

        public S2C_ColorRemapFX(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.IsFadingIn = reader.ReadBool();
            this.FadeTime = reader.ReadFloat();
            this.TeamID = reader.ReadTeamID();
            this.Color = reader.ReadColor();
            this.MaxWeight = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(IsFadingIn);
            writer.WriteFloat(FadeTime);
            writer.WriteTeamID(TeamID);
            writer.WriteColor(Color);
            writer.WriteFloat(MaxWeight);
        }
    }
}
