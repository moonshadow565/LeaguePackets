
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;
using System.Numerics;

namespace LeaguePackets.Game
{
    public class ShieldValues
    {
        public float Magical { get; set; }
        public float Phyisical { get; set; }
        public float MagicalAndPhysical { get; set; }
    }

    public class OnEnterVisiblityClient : GamePacket, IGamePacketsList // 0xBA
    {
        public override GamePacketID ID => GamePacketID.OnEnterVisiblityClient;
        public List<GamePacket> Packets { get; set; } = new List<GamePacket>();

        public List<ItemData> Items { get; set; } = new List<ItemData>();
        public ShieldValues ShieldValues { get; set; }
        public List<CharacterStackData> CharacterDataStack { get; set; } = new List<CharacterStackData>();
        public uint LookAtNetID { get; set; }
        public byte LookAtType { get; set; }
        public Vector3 LookAtPosition { get; set; }
        public List<KeyValuePair<byte, int>> BuffCount { get; set; } = new List<KeyValuePair<byte, int>>();
        public bool UnknownIsHero { get; set; }
        public MovementData MovementData { get; set; } = new MovementDataNone();

        protected override void ReadBody(ByteReader reader)
        {
            int totalSize = (ushort)(reader.ReadUInt16() & 0x1FFF);
            for (; totalSize > 0;)
            {
                ushort size = reader.ReadUInt16();
                byte[] data = reader.ReadBytes(size);
                this.Packets.Add(GamePacket.Create(data));
                totalSize -= 2;
                totalSize -= size;
            }

            if(reader.BytesLeft > 8) 
            {
                
                byte itemCount = reader.ReadByte();
                for (int i = 0; i < itemCount; i++)
                {
                    var item = new ItemData();
                    item.Slot = reader.ReadByte();
                    item.ItemsInSlot = reader.ReadByte();
                    item.SpellCharges = reader.ReadByte();
                    item.ItemID = reader.ReadUInt32();
                }

                bool hasShield = reader.ReadBool();
                if (hasShield)
                {
                    ShieldValues = new ShieldValues();
                    ShieldValues.Magical = reader.ReadFloat();
                    ShieldValues.Phyisical = reader.ReadFloat();
                    ShieldValues.MagicalAndPhysical = reader.ReadFloat();
                }

                int countCharStack = reader.ReadInt32();
                for (int i = 0; i < countCharStack; i++)
                {
                    var data = new CharacterStackData();
                    data.SkinName = reader.ReadSizedString();
                    data.SkinID = reader.ReadUInt32();
                    byte bitfield = reader.ReadByte();
                    data.OverrideSpells = (bitfield & 1) != 0;
                    data.ModelOnly = (bitfield & 2) != 0;
                    data.ReplaceCharacterPackage = (bitfield & 4) != 0;
                    data.ID = reader.ReadUInt32();
                    CharacterDataStack.Add(data);
                }

                LookAtNetID = reader.ReadUInt32();
                LookAtType = reader.ReadByte();
                LookAtPosition = reader.ReadVector3();

                int numOfBuffCount = reader.ReadInt32();
                for (int i = 0; i < numOfBuffCount; i++)
                {
                    byte slot = reader.ReadByte();
                    int count = reader.ReadInt32();
                    BuffCount.Add(new KeyValuePair<byte, int>(slot, count));
                }

                UnknownIsHero = reader.ReadBool();

                if(reader.BytesLeft > 4)
                {
                    MovementData = reader.ReadMovementDataWithHeader();
                }
            }
        }

        protected override void WriteBody(ByteWriter writer)
        {
            using (var writer2 = new ByteWriter())
            {
                foreach (var packet in Packets)
                {
                    var data = packet.GetBytes();
                    if (data.Length > 0x1FFF)
                    {
                        throw new IOException("Packet too big!");
                    }
                    writer.WriteUInt16((ushort)data.Length);
                    writer.WriteBytes(data);
                }
                var buffer = writer2.GetBytes();
                if (buffer.Length > 0x1FFF)
                {
                    throw new IOException("Packet data too big!");
                }
                writer.WriteUInt16((ushort)(buffer.Length & 0x1FFF));
                writer.WriteBytes(buffer);
            }

            int itemCount = Items.Count;
            if (itemCount > 0xFF)
            {
                throw new IOException("More than 255 items!");
            }
            writer.WriteByte((byte)itemCount);
            foreach (var item in Items)
            {
                writer.WriteByte(item.Slot);
                writer.WriteByte(item.ItemsInSlot);
                writer.WriteByte(item.SpellCharges);
                writer.WriteUInt32(item.ItemID);
            }

            if (ShieldValues != null)
            {
                writer.WriteBool(true);
                writer.WriteFloat(ShieldValues.Magical);
                writer.WriteFloat(ShieldValues.Phyisical);
                writer.WriteFloat(ShieldValues.MagicalAndPhysical);
            }
            else
            {
                writer.WriteBool(false);
            }

            writer.WriteInt32(CharacterDataStack.Count);
            foreach (var data in CharacterDataStack)
            {
                writer.WriteSizedString(data.SkinName);
                writer.WriteUInt32(data.SkinID);
                byte bitfield = 0;
                if (data.OverrideSpells)
                    bitfield |= 1;
                if (data.ModelOnly)
                    bitfield |= 2;
                if (data.ReplaceCharacterPackage)
                {
                    bitfield |= 4;
                }
                writer.WriteByte(bitfield);
                writer.WriteUInt32(data.ID);
            }

            writer.WriteUInt32(LookAtNetID);
            writer.WriteByte(LookAtType);
            writer.WriteVector3(LookAtPosition);

            writer.WriteInt32(BuffCount.Count);
            foreach (var kvp in BuffCount)
            {
                writer.WriteByte(kvp.Key);
                writer.WriteInt32(kvp.Value);
            }

            writer.WriteBool(UnknownIsHero);

            writer.WriteMovementDataWithHeader(MovementData);
        }
    }
}
