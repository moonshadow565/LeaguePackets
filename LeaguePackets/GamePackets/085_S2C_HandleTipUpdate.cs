using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HandleTipUpdate : GamePacket // 0x55
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleTipUpdate;
        public string TipName { get; set; } = "";
        public string TipOther { get; set; } = "";
        public string TipImagePath { get; set; } = "";
        public TipCommand TipCommand { get; set; }
        public TipID TipID { get; set; }
        public S2C_HandleTipUpdate(){}

        public S2C_HandleTipUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TipName = reader.ReadFixedString(128);
            this.TipOther = reader.ReadFixedString(128);
            this.TipImagePath = reader.ReadFixedString(128);
            this.TipCommand = reader.ReadTipCommand();
            this.TipID = reader.ReadTipID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFixedString(TipName, 128);
            writer.WriteFixedString(TipOther, 128);
            writer.WriteFixedString(TipImagePath, 128);
            writer.WriteTipCommand(TipCommand);
            writer.WriteTipID(TipID);
        }
    }
}
