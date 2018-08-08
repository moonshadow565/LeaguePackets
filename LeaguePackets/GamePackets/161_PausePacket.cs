using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class PausePacket : GamePacket // 0xA1
    {
        public override GamePacketID ID => GamePacketID.PausePacket;
        public ClientID ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool IsTournament { get; set; }
        public PausePacket(){}

        public PausePacket(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ClientID = reader.ReadClientID();
            this.PauseTimeRemaining = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            this.IsTournament = (bitfield & 1) != 0;

            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteClientID(ClientID);
            writer.WriteInt32(PauseTimeRemaining);
            byte bitfield = 0;
            if (IsTournament)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
