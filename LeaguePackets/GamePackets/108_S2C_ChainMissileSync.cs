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
        public S2C_ChainMissileSync(){}

        public S2C_ChainMissileSync(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.TargetCount = reader.ReadInt32();
            this.OwnerNetworkID = reader.ReadNetID();
            var left = reader.Stream.Length - reader.Stream.Position;

            // FIXME: not sure what to make of this
            // Maybe they write it variable when its not chain missile??
            var toread = this.TargetCount;
            if(left > (toread * 4) && left == (this.TargetNetIDs.Length * 4))
            {
                toread = this.TargetNetIDs.Length;
            }

            for (var i = 0; i < toread; i++)
                this.TargetNetIDs[i] = reader.ReadNetID();
        
            this.ExtraBytes = reader.ReadLeft();
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
