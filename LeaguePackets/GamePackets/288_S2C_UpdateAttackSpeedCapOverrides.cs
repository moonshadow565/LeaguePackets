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

            this.DoOverrideMax = reader.ReadBool();
            this.DoOverrideMin = reader.ReadBool();
            this.MaxAttackSpeedOverride = reader.ReadFloat();
            this.MinAttackSpeedOverride = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(DoOverrideMax);
            writer.WriteBool(DoOverrideMin);
            writer.WriteFloat(MaxAttackSpeedOverride);
            writer.WriteFloat(MinAttackSpeedOverride);
        }
    }
}
