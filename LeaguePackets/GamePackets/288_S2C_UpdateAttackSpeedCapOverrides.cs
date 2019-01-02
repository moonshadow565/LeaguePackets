using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UpdateAttackSpeedCapOverrides : GamePacket // 0x120
    {
        public override GamePacketID ID => GamePacketID.S2C_UpdateAttackSpeedCapOverrides;
        public bool DoOverrideMax { get; set; }
        public bool DoOverrideMin { get; set; }
        public float MaxAttackSpeedOverride { get; set; }
        public float MinAttackSpeedOverride { get; set; }
        public S2C_UpdateAttackSpeedCapOverrides(){}

        public S2C_UpdateAttackSpeedCapOverrides(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;
            byte bitfield = reader.ReadByte();
            this.DoOverrideMax = (bitfield & 1) != 0;
            this.DoOverrideMin = (bitfield & 2) != 0;
            this.MaxAttackSpeedOverride = reader.ReadFloat();
            this.MinAttackSpeedOverride = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (DoOverrideMax)
            {
                bitfield |= 0x01;
            }
            if (DoOverrideMin)
            {
                bitfield |= 0x02;
            }
            writer.WriteByte(bitfield);
            writer.WriteFloat(MaxAttackSpeedOverride);
            writer.WriteFloat(MinAttackSpeedOverride);
        }
    }
}
