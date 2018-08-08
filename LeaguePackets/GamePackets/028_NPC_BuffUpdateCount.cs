using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffUpdateCount : GamePacket // 0x1C
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCount;
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public NetID CasterNetID { get; set; }
        public NPC_BuffUpdateCount(){}

        public NPC_BuffUpdateCount(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BuffSlot = reader.ReadByte();
            this.Count = reader.ReadByte();
            this.Duration = reader.ReadFloat();
            this.RunningTime = reader.ReadFloat();
            this.CasterNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteByte(Count);
            writer.WriteFloat(Duration);
            writer.WriteFloat(RunningTime);
            writer.WriteNetID(CasterNetID);
        }
    }
}
