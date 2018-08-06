using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetHoverIndicatorEnabled : GamePacket // 0xF6
    {
        public override GamePacketID ID => GamePacketID.S2C_SetHoverIndicatorEnabled;
        public bool Enabled { get; set; }
        public static S2C_SetHoverIndicatorEnabled CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetHoverIndicatorEnabled();
            result.SenderNetID = senderNetID;
            result.Enabled = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(Enabled);
        }
    }
}
