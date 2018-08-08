using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_AI_TargetSelection : GamePacket // 0x69
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_TargetSelection;
        private NetID[] _targetNetIDs = new NetID[5];
        public NetID[] TargetNetIDs => _targetNetIDs;
        public S2C_AI_TargetSelection(){}

        public S2C_AI_TargetSelection(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            for (var i = 0; i < this.TargetNetIDs.Length; i++)
                this.TargetNetIDs[i] = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            for (var i = 0; i < TargetNetIDs.Length; i++)
                writer.WriteNetID(TargetNetIDs[i]);
        }
    }
}
