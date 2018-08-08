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

        public S2C_SetInventory(){}

        public S2C_SetInventory(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            for (var i = 0; i < this.Items.Length; i++)
            {
                this.Items[i] = reader.ReadItemPacket();
            }
            for (var i = 0; i < this.ItemCooldowns.Length; i++)
            {
                this.ItemCooldowns[i] = reader.ReadFloat();
            }
            for (var i = 0; i < this.ItemMaxCooldowns.Length; i++)
            {
                this.ItemMaxCooldowns[i] = reader.ReadFloat();
            }
        
            this.ExtraBytes = reader.ReadLeft();
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
