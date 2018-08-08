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
        public static NPC_BuffAdd2 CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffAdd2();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BuffSlot = reader.ReadByte();
            result.BuffType = reader.ReadBuffType();
            result.Count = reader.ReadByte();
            result.IsHidden = reader.ReadBool();
            result.BuffNameHash = reader.ReadUInt32();
            result.PackageHash = reader.ReadUInt32();
            result.RunningTime = reader.ReadFloat();
            result.Duration = reader.ReadFloat();
            result.CasterNetID = reader.ReadNetID();
        
            return result;
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
