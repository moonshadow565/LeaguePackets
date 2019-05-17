using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_AI_TargetSelection : GamePacket // 0x69
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_TargetSelection;
        private uint[] _targetNetIDs = new uint[5];
        public uint[] TargetNetIDs => _targetNetIDs;

        protected override void ReadBody(ByteReader reader)
        {

            for (var i = 0; i < this.TargetNetIDs.Length; i++)
                this.TargetNetIDs[i] = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            for (var i = 0; i < TargetNetIDs.Length; i++)
                writer.WriteUInt32(TargetNetIDs[i]);
        }
    }
}
