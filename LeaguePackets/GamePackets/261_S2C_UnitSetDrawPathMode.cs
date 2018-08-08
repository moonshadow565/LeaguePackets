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
        public static S2C_UnitSetDrawPathMode CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetDrawPathMode();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TargetNetID = reader.ReadNetID();
            result.DrawPathMode = reader.ReadDrawPathMode();
            result.UpdateRate = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
            writer.WriteDrawPathMode(DrawPathMode);
            writer.WriteFloat(UpdateRate);
        }
    }
}
