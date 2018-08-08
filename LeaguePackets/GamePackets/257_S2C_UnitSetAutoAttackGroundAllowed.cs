using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetAutoAttackGroundAllowed : GamePacket // 0x101
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetAutoAttackGroundAllowed;
        public NetID NetID { get; set; }
        public GroundAttackMode CanAutoAttackGroundState { get; set; }
        public static S2C_UnitSetAutoAttackGroundAllowed CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetAutoAttackGroundAllowed();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.CanAutoAttackGroundState = reader.ReadGroundAttackMode();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteGroundAttackMode(CanAutoAttackGroundState);
        }
    }
}
