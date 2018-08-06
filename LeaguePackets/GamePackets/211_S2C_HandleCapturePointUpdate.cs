using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_HandleCapturePointUpdate : GamePacket // 0xD3
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleCapturePointUpdate;
        public byte CapturePointIndex { get; set; }
        public NetID OtherNetID { get; set; }
        public PARType PARType { get; set; }
        public TeamID AttackTeam { get; set; }
        public CapturePointUpdateCommand Command { get; set; }
        public static S2C_HandleCapturePointUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_HandleCapturePointUpdate();
            result.SenderNetID = senderNetID;
            result.CapturePointIndex = reader.ReadByte();
            result.OtherNetID = reader.ReadNetID();
            result.PARType = reader.ReadPARType();
            result.AttackTeam = reader.ReadTeamID();
            result.Command = reader.ReadCapturePointUpdateCommand();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(CapturePointIndex);
            writer.WriteNetID(OtherNetID);
            writer.WritePARType(PARType);
            writer.WriteTeamID(AttackTeam);
            writer.WriteCapturePointUpdateCommand(Command);
        }
    }
}
