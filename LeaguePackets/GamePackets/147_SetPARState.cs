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
        public static SetPARState CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new SetPARState();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.UnitNetID = reader.ReadNetID();
            result.PARState = reader.ReadPARState();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(UnitNetID);
            writer.WritePARState(PARState);
        }
    }
}
