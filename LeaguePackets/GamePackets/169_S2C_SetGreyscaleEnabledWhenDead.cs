using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetGreyscaleEnabledWhenDead : GamePacket // 0xA9
    {
        public override GamePacketID ID => GamePacketID.S2C_SetGreyscaleEnabledWhenDead;
        public bool Enabled { get; set; }
        public static S2C_SetGreyscaleEnabledWhenDead CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetGreyscaleEnabledWhenDead();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.Enabled = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Enabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
