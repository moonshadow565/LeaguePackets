using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetDrawPathMode : GamePacket // 0x105
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetDrawPathMode;
        public NetID TargetNetID { get; set; }
        public DrawPathMode DrawPathMode { get; set; }
        public float UpdateRate { get; set; }
        public S2C_UnitSetDrawPathMode(){}

        public S2C_UnitSetDrawPathMode(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();
            this.DrawPathMode = reader.ReadDrawPathMode();
            this.UpdateRate = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteDrawPathMode(DrawPathMode);
            writer.WriteFloat(UpdateRate);
        }
    }
}
