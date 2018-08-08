using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_UndoItemReq : GamePacket // 0x10A
    {
        public override GamePacketID ID => GamePacketID.C2S_UndoItemReq;
        public C2S_UndoItemReq(){}

        public C2S_UndoItemReq(PacketReader reader, ChannelID channelID, NetID senderNetID) 
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer) {}
    }
}
