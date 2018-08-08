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
    public class S2C_CreateMinionCamp : GamePacket // 0x122
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateMinionCamp;
        public Vector3 Position { get; set; }
        public string MinimapIcon { get; set; } = "";
        public byte CampIndex { get; set; }
        public AudioVOComponentEvent VOComponentRevealEvent { get; set; }
        public TeamID TeamSide { get; set; }
        public int TimerType { get; set; }
        public float Expire { get; set; }

        public S2C_CreateMinionCamp(){}

        public S2C_CreateMinionCamp(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector3();
            this.MinimapIcon = reader.ReadFixedString(64);
            this.CampIndex = reader.ReadByte();
            this.VOComponentRevealEvent = reader.ReadAudioVOComponentEvent();
            this.TeamSide = (TeamID)reader.ReadByte();
            this.TimerType = reader.ReadInt32();
            this.Expire = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFixedString(MinimapIcon, 64);
            writer.WriteByte(CampIndex);
            writer.WriteAudioVOComponentEvent(VOComponentRevealEvent);
            writer.WriteByte((byte)TeamSide);
            writer.WriteInt32(TimerType);
            writer.WriteFloat(Expire);
        }
    }
}
