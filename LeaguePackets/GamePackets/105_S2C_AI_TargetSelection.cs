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
        public static S2C_AI_TargetSelection CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_AI_TargetSelection();
            result.SenderNetID = senderNetID;
            for (var i = 0; i < result.TargetNetIDs.Length; i++)
                result.TargetNetIDs[i] = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            for (var i = 0; i < TargetNetIDs.Length; i++)
                writer.WriteNetID(TargetNetIDs[i]);
        }
    }
}
