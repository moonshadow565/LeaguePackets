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
        public NPC_BuffReplace(){}

        public NPC_BuffReplace(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BuffSlot = reader.ReadByte();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.CasterNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
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
