using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_EndOfGameEvent : GamePacket // 0xC5
    {
        public override GamePacketID ID => GamePacketID.S2C_EndOfGameEvent;
        public bool TeamIsOrder { get; set; }
        public static S2C_EndOfGameEvent CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_EndOfGameEvent();
            result.SenderNetID = senderNetID;
            result.TeamIsOrder = reader.ReadBool();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(TeamIsOrder);
        }
    }
}
