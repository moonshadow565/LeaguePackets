using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffAdd2 : GamePacket // 0xB7
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffAdd2;
        public byte BuffSlot { get; set; }
        public BuffType BuffType { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
        public uint BuffNameHash { get; set; }
        public uint PackageHash { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public NetID CasterNetID { get; set; } 
        public NPC_BuffAdd2(){}

        public NPC_BuffAdd2(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.BuffSlot = reader.ReadByte();
            this.BuffType = reader.ReadBuffType();
            this.Count = reader.ReadByte();
            this.IsHidden = reader.ReadBool();
            this.BuffNameHash = reader.ReadUInt32();
            this.PackageHash = reader.ReadUInt32();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.CasterNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(BuffSlot);
            writer.WriteBuffType(BuffType);
            writer.WriteByte(Count);
            writer.WriteBool(IsHidden);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteUInt32(PackageHash);
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            writer.WriteNetID(CasterNetID);
        }
    }
}
