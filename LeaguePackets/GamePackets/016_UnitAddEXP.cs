using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    /// <summary>
    /// Shows visual indicator of adding exp to unit
    /// </summary>
    /// <remarks>
    /// Doesn't actually add any exp to unit only shows indicator and only if its enabled on client
    /// </remarks>
    public class UnitAddEXP : GamePacket // 0x10
    {
        public override GamePacketID ID => GamePacketID.UnitAddEXP;
        public NetID TargetNetID { get; set; }
        public float ExpAmmount { get; set; }
        public static UnitAddEXP CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new UnitAddEXP();
            result.SenderNetID = senderNetID;
            result.TargetNetID = reader.ReadNetID();
            result.ExpAmmount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteFloat(ExpAmmount);
        }
    }
}
