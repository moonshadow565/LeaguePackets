
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_UnitSetSpellLevelOverrides : GamePacket // 0x111
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetSpellLevelOverrides;
        private byte[] _spellMaxLevels = new byte[4];
        private byte[,] _spellUpgradeLevels = new byte[4, 6];
        public byte[] SpellMaxLevels => _spellMaxLevels;
        public byte[,] SpellUpgradeLevels => _spellUpgradeLevels;

        protected override void ReadBody(ByteReader reader)
        {

            for (var i = 0; i < this.SpellMaxLevels.Length; i++)
                this.SpellMaxLevels[i] = reader.ReadByte();
            for (var i = 0; i < this.SpellUpgradeLevels.GetLength(0); i++)
                for (var c = 0; c < this.SpellUpgradeLevels.GetLength(1); c++)
                    this.SpellUpgradeLevels[i, c] = reader.ReadByte();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            for (var i = 0; i < SpellMaxLevels.Length; i++)
                writer.WriteByte(SpellMaxLevels[i]);
            for (var i = 0; i < SpellUpgradeLevels.GetLength(0); i++)
                for (var c = 0; c < SpellUpgradeLevels.GetLength(1); c++)
                    writer.WriteByte(SpellUpgradeLevels[i, c]);
        }
    }
}
