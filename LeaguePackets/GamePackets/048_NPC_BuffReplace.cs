using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffReplace : GamePacket // 0x30
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplace;
        public byte BuffSlot { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public NetID CasterNetID { get; set; }
        public static NPC_BuffReplace CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffReplace();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BuffSlot = reader.ReadByte();
            result.RunningTime = reader.ReadFloat();
            result.Duration = reader.ReadFloat();
            result.CasterNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            writer.WriteNetID(CasterNetID);
        }
    }
}
