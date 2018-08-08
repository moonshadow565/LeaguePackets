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
    public class Pause : GamePacket // 0x31
    {
        public override GamePacketID ID => GamePacketID.Pause;
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public int SyncID { get; set; }
        public Pause(){}

        public Pause(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector3();
            this.Forward = reader.ReadVector3();
            this.SyncID = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteVector3(Forward);
            writer.WriteInt32(SyncID);
        }
    }
}
