
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class SendSelectedObjID : GamePacket // 0xAF
    {
        public override GamePacketID ID => GamePacketID.SendSelectedObjID;
        public int ClientID { get; set; }
        public uint SelectedNetID { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.ClientID = reader.ReadInt32();
            this.SelectedNetID = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteUInt32(SelectedNetID);
        }
    }
}
