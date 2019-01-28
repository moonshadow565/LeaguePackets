
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class S2C_WriteNavFlags : GamePacket // 0x41
    {
        public override GamePacketID ID => GamePacketID.S2C_WriteNavFlags;
        public int SyncID { get; set; }
        public List<NavFlagCricle> NavFlagCricles { get; set; } = new List<NavFlagCricle>();

        protected override void ReadBody(ByteReader reader)
        {

            this.SyncID = reader.ReadInt32();
            int size = reader.ReadInt16();
            for (var i = 0; i < size; i += 16)
            {
                this.NavFlagCricles.Add(reader.ReadNavFlagCricle());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
            int size = NavFlagCricles.Count * 16;
            if(size > 0xFFFF)
            {
                throw new IOException("NavFlagCircles list too big!");   
            }
            for (int i = 0; i < NavFlagCricles.Count; i++)
            {
                writer.WriteNavFlagCricle(NavFlagCricles[i]);
            }
        }
    }
}
