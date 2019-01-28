
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class ReplayOnly_MultiKillCountUpdate : GamePacket // 0x115
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_MultiKillCountUpdate;
        public uint OwnerNetID { get; set; }
        public byte MultiKillCount { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.OwnerNetID = reader.ReadUInt32();
            this.MultiKillCount = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(OwnerNetID);
            writer.WriteByte(MultiKillCount);
        }
    }
}
