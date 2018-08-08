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
        public ModifyShield(){}

        public ModifyShield(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Physical = (bitfield & 1) != 0;
            this.Magical = (bitfield & 2) != 0;
            this.StopShieldFade = (bitfield & 4) != 0;
            this.Ammount = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
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
