using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetInventory : GamePacket // 0x10C
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInventory;
        private ItemDataPacket[] _items = new ItemDataPacket[10];
        private float[] _itemCooldowns = new float[10];
        private float[] _itemMaxCooldowns = new float[10];
        public ItemDataPacket[] Items => _items;
        public float[] ItemCooldowns => _itemCooldowns;
        public float[] ItemMaxCooldowns => _itemMaxCooldowns;

        public static S2C_SetInventory CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_SetInventory();
            result.SenderNetID = senderNetID;
            for (var i = 0; i < result.Items.Length; i++)
            {
                result.Items[i] = reader.ReadItemPacket();
            }
            for (var i = 0; i < result.ItemCooldowns.Length; i++)
            {
                result.ItemCooldowns[i] = reader.ReadFloat();
            }
            for (var i = 0; i < result.ItemMaxCooldowns.Length; i++)
            {
                result.ItemMaxCooldowns[i] = reader.ReadFloat();
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            for (var i = 0; i < Items.Length; i++)
            {
                writer.WriteItemPacket(Items[i]);
            }
            for (var i = 0; i < ItemCooldowns.Length; i++)
            {
                writer.WriteFloat(ItemCooldowns[i]);
            }
            for (var i = 0; i < ItemMaxCooldowns.Length; i++)
            {
                writer.WriteFloat(ItemMaxCooldowns[i]);
            }
        }
    }
}
