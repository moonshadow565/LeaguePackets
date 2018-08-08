using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_AmmoUpdate : GamePacket // 0x107
    {
        public override GamePacketID ID => GamePacketID.S2C_AmmoUpdate;
        public bool IsSummonerSpell { get; set; }
        public int SpellSlot { get; set; }
        public int CurrentAmmo { get; set; }
        public int MaxAmmo { get; set; }
        public float AmmoRecharge { get; set; }
        public float AmmoRechargeTotalTime { get; set; }
        public S2C_AmmoUpdate(){}

        public S2C_AmmoUpdate(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.IsSummonerSpell = reader.ReadBool();
            this.SpellSlot = reader.ReadInt32();
            this.CurrentAmmo = reader.ReadInt32();
            this.MaxAmmo = reader.ReadInt32();
            this.AmmoRecharge = reader.ReadFloat();
            this.AmmoRechargeTotalTime = reader.ReadFloat();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(IsSummonerSpell);
            writer.WriteInt32(SpellSlot);
            writer.WriteInt32(CurrentAmmo);
            writer.WriteInt32(MaxAmmo);
            writer.WriteFloat(AmmoRecharge);
            writer.WriteFloat(AmmoRechargeTotalTime);
        }
    }
}
