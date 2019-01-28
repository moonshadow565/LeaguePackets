
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class FX_Create_Group : GamePacket // 0x87
    {
        public override GamePacketID ID => GamePacketID.FX_Create_Group;
        public List<FXCreateGroupData> FXCreateGroup { get; set; } = new List<FXCreateGroupData>();

        protected override void ReadBody(ByteReader reader)
        {

            int count = reader.ReadByte();
            for (int i = 0; i < count; i ++)
            {
                this.FXCreateGroup.Add(reader.ReadFXCreateGroupData());
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            int count = FXCreateGroup.Count;
            if(count > 0xFF)
            {
                throw new IOException("FXCreateGroup list too big > 255!");
            }
            writer.WriteByte((byte)count);
            foreach(var fxgroup in FXCreateGroup)
            {
                writer.WriteFXCreateGroupData(fxgroup);
            }
        }
    }
}
