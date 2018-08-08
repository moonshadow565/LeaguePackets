using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class UpdateGoldRedirectTarget : GamePacket // 0x7
    {
        public override GamePacketID ID => GamePacketID.UpdateGoldRedirectTarget;
        public NetID TargetNetID { get; set; }

        public UpdateGoldRedirectTarget(){}

        public UpdateGoldRedirectTarget(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetNetID = reader.ReadNetID();

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(TargetNetID);
        }
    }
}
