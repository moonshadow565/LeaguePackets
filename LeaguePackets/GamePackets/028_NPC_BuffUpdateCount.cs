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
        public static NPC_BuffUpdateCount CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffUpdateCount();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BuffSlot = reader.ReadByte();
            result.Count = reader.ReadByte();
            result.Duration = reader.ReadFloat();
            result.RunningTime = reader.ReadFloat();
            result.CasterNetID = reader.ReadNetID();
        
            return result;
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
