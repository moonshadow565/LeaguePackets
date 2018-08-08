using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_UnitSetSpellLevelOverrides : GamePacket // 0x111
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetSpellLevelOverrides;
        private byte[] _spellMaxLevels = new byte[4];
        private byte[,] _spellUpgradeLevels = new byte[4, 6];
        public byte[] SpellMaxLevels => _spellMaxLevels;
        public byte[,] SpellUpgradeLevels => _spellUpgradeLevels;

        public static S2C_UnitSetSpellLevelOverrides CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_UnitSetSpellLevelOverrides();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            for (var i = 0; i < result.SpellMaxLevels.Length; i++)
                result.SpellMaxLevels[i] = reader.ReadByte();
            for (var i = 0; i < result.SpellUpgradeLevels.GetLength(0); i++)
                for (var c = 0; c < result.SpellUpgradeLevels.GetLength(1); c++)
                    result.SpellUpgradeLevels[i, c] = reader.ReadByte();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            for (var i = 0; i < SpellMaxLevels.Length; i++)
                writer.WriteByte(SpellMaxLevels[i]);
            for (var i = 0; i < SpellUpgradeLevels.GetLength(0); i++)
                for (var c = 0; c < SpellUpgradeLevels.GetLength(1); c++)
                    writer.WriteByte(SpellUpgradeLevels[i, c]);
        }
    }
}
