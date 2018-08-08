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

        public static S2C_UnitSetMinimapIcon CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetMinimapIcon();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.UnitNetID = reader.ReadNetID();
            result.ChangeIcon = reader.ReadBool();
            result.IconCategory = reader.ReadFixedString(64);
            result.ChangeBorder = reader.ReadBool();
            result.BorderCategory = reader.ReadFixedString(64);
            result.BorderScriptName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WriteBool(ChangeIcon);
            writer.WriteFixedString(IconCategory, 64);
            writer.WriteBool(ChangeBorder);
            writer.WriteFixedString(BorderCategory, 64);
            writer.WriteFixedString(BorderScriptName, 64);
        }
    }
}
