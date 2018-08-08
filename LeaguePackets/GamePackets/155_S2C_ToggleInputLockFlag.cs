using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ToggleInputLockFlag : GamePacket // 0x9B
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleInputLockFlag;
        public InputLockFlags InputLockingFlags { get; set; }
        public S2C_ToggleInputLockFlag(){}

        public S2C_ToggleInputLockFlag(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.InputLockingFlags = reader.ReadInputLockFlags();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInputLockFlags(InputLockingFlags);
        }
    }
}
