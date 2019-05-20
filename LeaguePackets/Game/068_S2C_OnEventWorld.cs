
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;
using LeaguePackets.Game.Events;

namespace LeaguePackets.Game
{
    public class S2C_OnEventWorld : GamePacket // 0x45
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEventWorld;

        public uint SourceNetID { get; set; }
        public IEvent Event { get; set; } = new OnDelete();

        protected override void ReadBody(ByteReader reader)
        {
            var id = reader.ReadByte();
            var source = reader.ReadUInt32();
            var ev = EventExtension.CreateEvent(id);
            ev.ReadArgs(reader);

            SourceNetID = source;
            Event = ev;
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte((byte)Event.ID);
            writer.WriteUInt32(SourceNetID);
            Event.WriteArgs(writer);
        }
    }
}
