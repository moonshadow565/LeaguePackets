using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetMinimapIcon : GamePacket // 0xD8
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetMinimapIcon;
        public NetID UnitNetID { get; set; }
        public bool ChangeIcon { get; set; }
        public string IconCategory { get; set; } = "";
        public bool ChangeBorder { get; set; }
        public string BorderCategory { get; set; } = "";
        public string BorderScriptName { get; set; } = "";

        public S2C_UnitSetMinimapIcon(){}

        public S2C_UnitSetMinimapIcon(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.UnitNetID = reader.ReadNetID();
            this.ChangeIcon = (reader.ReadByte() & 0x01) != 0;
            this.IconCategory = reader.ReadFixedString(64);
            this.ChangeBorder = (reader.ReadByte() & 0x01) != 0;
            this.BorderCategory = reader.ReadFixedString(64);
            this.BorderScriptName = reader.ReadFixedStringLast(64);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WriteBool(ChangeIcon);
            writer.WriteFixedString(IconCategory, 64);
            writer.WriteBool(ChangeBorder);
            writer.WriteFixedString(BorderCategory, 64);
            writer.WriteFixedStringLast(BorderScriptName, 64);
        }
    }
}
