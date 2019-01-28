
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetMinimapIcon : GamePacket // 0xD8
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetMinimapIcon;
        public uint UnitNetID { get; set; }
        public bool ChangeIcon { get; set; }
        public string IconCategory { get; set; } = "";
        public bool ChangeBorder { get; set; }
        public string BorderCategory { get; set; } = "";
        public string BorderScriptName { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {

            this.UnitNetID = reader.ReadUInt32();
            this.ChangeIcon = (reader.ReadByte() & 0x01) != 0;
            this.IconCategory = reader.ReadFixedString(64);
            this.ChangeBorder = (reader.ReadByte() & 0x01) != 0;
            this.BorderCategory = reader.ReadFixedString(64);
            this.BorderScriptName = reader.ReadFixedStringLast(64);
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(UnitNetID);
            writer.WriteBool(ChangeIcon);
            writer.WriteFixedString(IconCategory, 64);
            writer.WriteBool(ChangeBorder);
            writer.WriteFixedString(BorderCategory, 64);
            writer.WriteFixedStringLast(BorderScriptName, 64);
        }
    }
}
