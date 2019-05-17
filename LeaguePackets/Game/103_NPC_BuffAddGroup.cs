
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class NPC_BuffAddGroup : GamePacket // 0x68
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffAddGroup;
        public byte BuffType { get; set; }
        public uint BuffNameHash { get; set; }
        public uint PackageHash { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<BuffAddGroupEntry> Entries { get; set; } = new List<BuffAddGroupEntry>();

        protected override void ReadBody(ByteReader reader)
        {

            this.BuffType = reader.ReadByte();
            this.BuffNameHash = reader.ReadUInt32();
            this.PackageHash = reader.ReadUInt32();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffInGroupAdd());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BuffType);
            writer.WriteUInt32(BuffNameHash);
            writer.WriteUInt32(PackageHash);
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            int numInGroup = Entries.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs in list!");
            }
            writer.WriteByte((byte)numInGroup);
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupAdd(Entries[i]);
            }
        }
    }
}
