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
        public S2C_UnitSetAutoAttackGroundAllowed(){}

        public S2C_UnitSetAutoAttackGroundAllowed(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.CanAutoAttackGroundState = reader.ReadGroundAttackMode();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteGroundAttackMode(CanAutoAttackGroundState);
        }
    }
}
