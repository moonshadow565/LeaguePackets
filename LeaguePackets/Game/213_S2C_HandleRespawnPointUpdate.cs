
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class S2C_HandleRespawnPointUpdate : GamePacket // 0xD5
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleRespawnPointUpdate;
        public byte RespawnPointCommand { get; set; }
        public byte RespawnPointUIID { get; set; }
        public uint TeamID { get; set; }
        public int ClientID { get; set; }
        public Vector3 Position { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.RespawnPointCommand = reader.ReadByte();
            this.RespawnPointUIID = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
            this.ClientID = reader.ReadInt32();
            this.Position = reader.ReadVector3();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(RespawnPointCommand);
            writer.WriteByte(RespawnPointUIID);
            writer.WriteUInt32(TeamID);
            writer.WriteInt32(ClientID);
            writer.WriteVector3(Position);
        }
    }
}
