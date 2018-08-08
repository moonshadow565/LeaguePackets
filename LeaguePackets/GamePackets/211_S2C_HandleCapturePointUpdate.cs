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
        public S2C_HandleCapturePointUpdate(){}

        public S2C_HandleCapturePointUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.CapturePointIndex = reader.ReadByte();
            this.OtherNetID = reader.ReadNetID();
            this.PARType = reader.ReadPARType();
            this.AttackTeam = reader.ReadTeamID();
            this.Command = reader.ReadCapturePointUpdateCommand();
        
            this.ExtraBytes = reader.ReadLeft();
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
