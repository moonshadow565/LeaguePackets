using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class World_LockCamera_Server : GamePacket // 0x81
    {
        public override GamePacketID ID => GamePacketID.World_LockCamera_Server;
        public bool Locked { get; set; }
        public ClientID ClientID { get; set; }
        public World_LockCamera_Server(){}

        public World_LockCamera_Server(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Locked = reader.ReadBool();
            this.ClientID = reader.ReadClientID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(Locked);
            writer.WriteClientID(ClientID);
        }
    }
}
