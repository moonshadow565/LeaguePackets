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
    public class S2C_ActivateMinionCamp : GamePacket // 0xE9
    {
        public override GamePacketID ID => GamePacketID.S2C_ActivateMinionCamp;
        public Vector3 Position { get; set; }
        public float SpawnDuration { get; set; }
        public byte CampIndex { get; set; }
        public int TimerType { get; set; }
        public S2C_ActivateMinionCamp(){}

        public S2C_ActivateMinionCamp(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector3();
            this.SpawnDuration = reader.ReadFloat();
            this.CampIndex = reader.ReadByte();
            this.TimerType = reader.ReadInt32();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteFloat(SpawnDuration);
            writer.WriteByte(CampIndex);
            writer.WriteInt32(TimerType);
        }
    }
}
