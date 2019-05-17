
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_LineMissileHitList : GamePacket // 0x26
    {
        public override GamePacketID ID => GamePacketID.S2C_LineMissileHitList;
        public List<uint> Targets { get; set; } = new List<uint>();

        protected override void ReadBody(ByteReader reader)
        {

            int size = reader.ReadInt16();
            for (int i = 0; i < size; i++)
            {
                this.Targets.Add(reader.ReadUInt32());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            int size = Targets.Count;
            if(size > 0x7FFF)
            {
                throw new IOException("Target list too big!");
            }
            writer.WriteInt16((short)size);
            for (int i = 0; i < size; i++)
            {
                writer.WriteUInt32(Targets[i]);
            }
        }
    }
}
