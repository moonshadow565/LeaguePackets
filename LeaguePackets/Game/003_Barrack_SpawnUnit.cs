
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class Barrack_SpawnUnit : GamePacket // 0x3
    {
        public override GamePacketID ID => GamePacketID.Barrack_SpawnUnit;
        public uint ObjectID { get; set; }
        public byte ObjectNodeID { get; set; }
        public uint BarracksNetID { get; set; }
        public byte WaveCount { get; set; }
        public byte MinionType { get; set; }
        public short DamageBonus { get; set; }
        public short HealthBonus { get; set; }
        public byte MinionLevel { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ObjectID = reader.ReadUInt32();
            this.ObjectNodeID = reader.ReadByte();
            this.BarracksNetID = reader.ReadUInt32();
            this.WaveCount = reader.ReadByte();
            this.MinionType = reader.ReadByte();
            this.DamageBonus = reader.ReadInt16();
            this.HealthBonus = reader.ReadInt16();
            this.MinionLevel = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(ObjectID);
            writer.WriteByte(ObjectNodeID);
            writer.WriteUInt32(BarracksNetID);
            writer.WriteByte(WaveCount);
            writer.WriteByte(MinionType);
            writer.WriteInt16(DamageBonus);
            writer.WriteInt16(HealthBonus);
            writer.WriteByte(MinionLevel);
        }
    }
}
