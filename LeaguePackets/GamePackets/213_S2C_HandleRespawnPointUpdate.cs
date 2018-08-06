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
    public class S2C_HandleRespawnPointUpdate : GamePacket // 0xD5
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleRespawnPointUpdate;
        public RespawnPointCommand RespawnPointCommand { get; set; }
        public RespawnPointUIID RespawnPointUIID { get; set; }
        public TeamID TeamID { get; set; }
        public ClientID ClientID { get; set; }
        public Vector3 Position { get; set; }
        public static S2C_HandleRespawnPointUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_HandleRespawnPointUpdate();
            result.SenderNetID = senderNetID;
            result.RespawnPointCommand = reader.ReadRespawnPointCommand();
            result.RespawnPointUIID = reader.ReadRespawnPointUIID();
            result.TeamID = reader.ReadTeamID();
            result.ClientID = reader.ReadClientID();
            result.Position = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteRespawnPointCommand(RespawnPointCommand);
            writer.WriteRespawnPointUIID(RespawnPointUIID);
            writer.WriteTeamID(TeamID);
            writer.WriteClientID(ClientID);
            writer.WriteVector3(Position);
        }
    }
}
