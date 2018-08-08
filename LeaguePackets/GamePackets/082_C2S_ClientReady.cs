using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class C2S_ClientReady : GamePacket // 0x52
    {
        public override GamePacketID ID => GamePacketID.C2S_ClientReady;
        public TipConfig TipConfig { get; set; } = new TipConfig();
        public C2S_ClientReady(){}

        public C2S_ClientReady(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            reader.ReadPad(4);
            this.TipConfig = reader.ReadTipConfig();
            reader.ReadPad(8);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WritePad(4);
            writer.WriteTipConfig(TipConfig);
            writer.WritePad(8);
        }
    }
}
