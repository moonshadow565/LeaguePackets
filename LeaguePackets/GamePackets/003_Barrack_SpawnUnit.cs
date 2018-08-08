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
        public Barrack_SpawnUnit(){}

        public Barrack_SpawnUnit(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectID = reader.ReadNetID();
            this.ObjectNodeID = reader.ReadNetNodeID();
            this.BarracksNetID = reader.ReadNetID();
            this.WaveCount = reader.ReadByte();
            this.MinionType = reader.ReadByte();
            this.DamageBonus = reader.ReadInt16();
            this.HealthBonus = reader.ReadInt16();
            this.MinionLevel = reader.ReadByte();

            this.ExtraBytes = reader.ReadLeft();
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
