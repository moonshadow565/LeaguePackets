using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetShowAutoAttackIndicator : GamePacket // 0x102
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetShowAutoAttackIndicator;
        public NetID NetID { get; set; }
        public bool ShowIndicator { get; set; }
        public bool ShowMinimapIndicator { get; set; }
        public static S2C_UnitSetShowAutoAttackIndicator CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_UnitSetShowAutoAttackIndicator();
            result.SenderNetID = senderNetID;
            result.NetID = reader.ReadNetID();
            result.ShowIndicator = reader.ReadBool();
            result.ShowMinimapIndicator = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteBool(ShowIndicator);
            writer.WriteBool(ShowMinimapIndicator);
        }
    }
}
