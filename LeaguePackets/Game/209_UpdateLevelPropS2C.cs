
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class UpdateLevelPropS2C : GamePacket // 0xD1
    {
        public override GamePacketID ID => GamePacketID.UpdateLevelPropS2C;
        public UpdateLevelPropData UpdateLevelPropData { get; set; }

        protected override void ReadBody(ByteReader reader)
        {
            this.UpdateLevelPropData = reader.ReadUpdateLevelPropData();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUpdateLevelPropData(UpdateLevelPropData);
        }
    }
}
