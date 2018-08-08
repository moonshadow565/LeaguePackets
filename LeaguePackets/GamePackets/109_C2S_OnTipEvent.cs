using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_OnTipEvent : GamePacket // 0x6D
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTipEvent;
        public TipCommand TipCommand { get; set; }
        public TipID TipID { get; set; }

        public C2S_OnTipEvent(){}

        public C2S_OnTipEvent(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TipCommand = reader.ReadTipCommand();
            this.TipID = reader.ReadTipID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteTipCommand(TipCommand);
            writer.WriteTipID(TipID);
        }
    }
}
