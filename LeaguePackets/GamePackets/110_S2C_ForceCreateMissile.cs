using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ForceCreateMissile : GamePacket // 0x6E
    {
        public override GamePacketID ID => GamePacketID.S2C_ForceCreateMissile;
        public NetID MissileNetID { get; set; }
        public S2C_ForceCreateMissile(){}

        public S2C_ForceCreateMissile(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.MissileNetID = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(MissileNetID);
        }
    }
}
