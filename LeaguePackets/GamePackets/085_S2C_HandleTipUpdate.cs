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
        public static S2C_HandleTipUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_HandleTipUpdate();
            result.SenderNetID = senderNetID;
            result.TipName = reader.ReadFixedString(128);
            result.TipOther = reader.ReadFixedString(128);
            result.TipImagePath = reader.ReadFixedString(128);
            result.TipCommand = reader.ReadTipCommand();
            result.TipID = reader.ReadTipID();
        
            return result;
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
