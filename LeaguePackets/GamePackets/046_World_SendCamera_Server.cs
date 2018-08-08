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
    public class World_SendCamera_Server : GamePacket // 0x2E
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server;
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public ClientID ClientID { get; set; }
        public byte SyncID { get; set; }
        public World_SendCamera_Server(){}

        public World_SendCamera_Server(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.CameraPosition = reader.ReadVector3();
            this.CameraDirection = reader.ReadVector3();
            this.ClientID = reader.ReadClientID();
            this.SyncID = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(CameraPosition);
            writer.WriteVector3(CameraDirection);
            writer.WriteClientID(ClientID);
            writer.WriteByte(SyncID);
        }
    }
}
