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
        public S2C_HandleRespawnPointUpdate(){}

        public S2C_HandleRespawnPointUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.RespawnPointCommand = reader.ReadRespawnPointCommand();
            this.RespawnPointUIID = reader.ReadRespawnPointUIID();
            this.TeamID = reader.ReadTeamID();
            this.ClientID = reader.ReadClientID();
            this.Position = reader.ReadVector3();
        
            this.ExtraBytes = reader.ReadLeft();
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
