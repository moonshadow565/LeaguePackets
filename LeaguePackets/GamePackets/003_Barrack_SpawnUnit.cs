using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class Barrack_SpawnUnit : GamePacket // 0x3
    {
        public override GamePacketID ID => GamePacketID.Barrack_SpawnUnit;
        public NetID ObjectID { get; set; }
        public NetNodeID ObjectNodeID { get; set; }
        public NetID BarracksNetID { get; set; }
        public byte WaveCount { get; set; }
        public byte MinionType { get; set; }
        public short DamageBonus { get; set; }
        public short HealthBonus { get; set; }
        public byte MinionLevel { get; set; }
        public static Barrack_SpawnUnit CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new Barrack_SpawnUnit();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.ObjectID = reader.ReadNetID();
            result.ObjectNodeID = reader.ReadNetNodeID();
            result.BarracksNetID = reader.ReadNetID();
            result.WaveCount = reader.ReadByte();
            result.MinionType = reader.ReadByte();
            result.DamageBonus = reader.ReadInt16();
            result.HealthBonus = reader.ReadInt16();
            result.MinionLevel = reader.ReadByte();

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(ObjectID);
            writer.WriteNetNodeID(ObjectNodeID);
            writer.WriteNetID(BarracksNetID);
            writer.WriteByte(WaveCount);
            writer.WriteByte(MinionType);
            writer.WriteInt16(DamageBonus);
            writer.WriteInt16(HealthBonus);
            writer.WriteByte(MinionLevel);
        }
    }
}
