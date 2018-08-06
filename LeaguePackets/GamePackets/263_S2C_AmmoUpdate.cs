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
        public static S2C_AmmoUpdate CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_AmmoUpdate();
            result.SenderNetID = senderNetID;
            result.IsSummonerSpell = reader.ReadBool();
            result.SpellSlot = reader.ReadInt32();
            result.CurrentAmmo = reader.ReadInt32();
            result.MaxAmmo = reader.ReadInt32();
            result.AmmoRecharge = reader.ReadFloat();
            result.AmmoRechargeTotalTime = reader.ReadFloat();
        
            return result;
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
