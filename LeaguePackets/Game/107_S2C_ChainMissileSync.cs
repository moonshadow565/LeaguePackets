using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_ChainMissileSync : GamePacket // 0x6C
    {
        public override GamePacketID ID => GamePacketID.S2C_ChainMissileSync;
        private uint[] _targetNetIDs = new uint[32];
        public int TargetCount { get; set; }
        public uint OwnerNetworkID { get; set; }
        public uint[] TargetNetIDs => _targetNetIDs;

        protected override void ReadBody(ByteReader reader)
        {

            this.TargetCount = reader.ReadInt32();
            this.OwnerNetworkID = reader.ReadUInt32();
            var left = reader.BytesLeft;

            // FIXME: not sure what to make of this
            // Maybe they write it variable when its not chain missile??
            var toread = this.TargetCount;
            if(left > (toread * 4) && left == (this.TargetNetIDs.Length * 4))
            {
                toread = this.TargetNetIDs.Length;
            }

            for (var i = 0; i < toread; i++)
                this.TargetNetIDs[i] = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(TargetCount);
            writer.WriteUInt32(OwnerNetworkID);
            for (var i = 0; i < TargetNetIDs.Length; i++)
                writer.WriteUInt32(TargetNetIDs[i]);
        }
    }
}
