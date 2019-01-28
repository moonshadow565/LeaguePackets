
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_CreateMinionCamp : GamePacket // 0x122
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateMinionCamp;
        public Vector3 Position { get; set; }
        public string MinimapIcon { get; set; } = "";
        public byte CampIndex { get; set; }
        public byte RevealAudioVOComponentEvent { get; set; }
        public byte SideTeamID { get; set; }
        public int TimerType { get; set; }
        public float Expire { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.Position = reader.ReadVector3();
            this.MinimapIcon = reader.ReadFixedString(64);
            this.CampIndex = reader.ReadByte();
            this.RevealAudioVOComponentEvent = reader.ReadByte();
            this.SideTeamID = reader.ReadByte();
            this.TimerType = reader.ReadInt32();
            this.Expire = reader.ReadFloat();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFixedString(MinimapIcon, 64);
            writer.WriteByte(CampIndex);
            writer.WriteByte(RevealAudioVOComponentEvent);
            writer.WriteByte(SideTeamID);
            writer.WriteInt32(TimerType);
            writer.WriteFloat(Expire);
        }
    }
}
