using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class SetPARState : GamePacket // 0x93
    {
        public override GamePacketID ID => GamePacketID.SetPARState;
        public NetID UnitNetID { get; set; }
        public PARState PARState { get; set; }
        public SetPARState(){}

        public SetPARState(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.UnitNetID = reader.ReadNetID();
            this.PARState = reader.ReadPARState();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WritePARState(PARState);
        }
    }
}
