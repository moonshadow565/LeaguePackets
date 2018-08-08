using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_ChainMissileSync : GamePacket // 0x6C
    {
        public override GamePacketID ID => GamePacketID.S2C_ChainMissileSync;
        private NetID[] _targetNetIDs = new NetID[32];
        public int TargetCount { get; set; }
        public NetID OwnerNetworkID { get; set; }
        public NetID[] TargetNetIDs => _targetNetIDs;
        public static S2C_ChainMissileSync CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_ChainMissileSync();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TargetCount = reader.ReadInt32();
            result.OwnerNetworkID = reader.ReadNetID();
            for (var i = 0; i < result.TargetNetIDs.Length; i++)
                result.TargetNetIDs[i] = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(TargetCount);
            writer.WriteNetID(OwnerNetworkID);
            for (var i = 0; i < TargetNetIDs.Length; i++)
                writer.WriteNetID(TargetNetIDs[i]);
        }
    }
}
