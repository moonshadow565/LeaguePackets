
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class S2C_SetInventory_Broadcast : GamePacket // 0x10C
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInventory_Broadcast;
        private ItemData[] _items = new ItemData[10];
        private float[] _itemCooldowns = new float[10];
        public ItemData[] Items => _items;
        public float[] ItemCooldowns => _itemCooldowns;

        protected override void ReadBody(ByteReader reader)
        {
            for (var i = 0; i < this.Items.Length; i++)
            {
                this.Items[i] = reader.ReadItemPacket();
            }
            for (var i = 0; i < this.ItemCooldowns.Length; i++)
            {
                this.ItemCooldowns[i] = reader.ReadFloat();
            }
        }
        protected override void WriteBody(ByteWriter writer)
        {
            for (var i = 0; i < Items.Length; i++)
            {
                writer.WriteItemPacket(Items[i]);
            }
            for (var i = 0; i < ItemCooldowns.Length; i++)
            {
                writer.WriteFloat(ItemCooldowns[i]);
            }
        }
    }
}
