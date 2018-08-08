using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffRemove2 : GamePacket // 0x7B
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffRemove2;
        public byte BuffSlot { get; set; }
        public uint BuffNameHash { get; set; }
        public float RunTimeRemove { get; set; }
        public NPC_BuffRemove2(){}

        public NPC_BuffRemove2(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BuffSlot = reader.ReadByte();
            this.BuffNameHash = reader.ReadUInt32();
            this.RunTimeRemove = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteFloat(RunTimeRemove);
        }
    }
}
