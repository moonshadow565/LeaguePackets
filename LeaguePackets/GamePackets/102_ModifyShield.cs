using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class ModifyShield : GamePacket // 0x66
    {
        public override GamePacketID ID => GamePacketID.ModifyShield;
        public bool Physical { get; set; }
        public bool Magical { get; set; }
        public bool StopShieldFade { get; set; }
        public float Ammount { get; set; }
        public static ModifyShield CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new ModifyShield();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.Physical = (bitfield & 1) != 0;
            result.Magical = (bitfield & 2) != 0;
            result.StopShieldFade = (bitfield & 4) != 0;
            result.Ammount = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (Physical)
                bitfield |= 1;
            if (Magical)
                bitfield |= 2;
            if (StopShieldFade)
                bitfield |= 4;
            writer.WriteByte(bitfield);
            writer.WriteFloat(Ammount);
        }
    }
}
