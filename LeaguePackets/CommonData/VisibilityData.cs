using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public abstract class VisibilityData
    {
        public abstract void ReadBodyInternal(PacketReader reader);
        public abstract void WriteBodyInternal(PacketWriter writer);
    }

    public static class VisibilityDataExtension
    {
        public static VisibilityData ReadVisibilityData(this PacketReader reader)
        {
            var result = new VisibilityDataUnknown();
            result.ReadBodyInternal(reader);
            return result;
        }
        public static void WriteVisibilityData(this PacketWriter writer, VisibilityData data)
        {
            data.WriteBodyInternal(writer);
        }
    }

    public class VisibilityDataUnknown : VisibilityData
    {
        public byte[] Data { get; set; } = new byte[0];
        public override void ReadBodyInternal(PacketReader reader) 
        {
            Data = reader.ReadLeft();
        }
        public override void WriteBodyInternal(PacketWriter writer) 
        {
            writer.WriteBytes(Data);
        }
    }

    public class VisibilityDataNeutralMinionHUD : VisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class VisibilityDataSpellMissile : VisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class VisibilityDataBuilding : VisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class VisibilityDataAILevelProp : VisibilityData
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        public override void WriteBodyInternal(PacketWriter writer) { }
    }


    public class ShieldValues
    {
        public float Magical { get; set; }
        public float Phyisical { get; set; }
        public float MagicalAndPhysical { get; set; }
    }

    public class VisibilityDataAIBase : VisibilityData
    {
        public List<ItemDataPacket> Items { get; set; } = new List<ItemDataPacket>();
        public ShieldValues ShieldValues { get; set; }
        //TODO: should be same structure as in S2C_ChangeCharacterData
        public List<CharacterStackData> CharacterDataStack { get; set; } = new List<CharacterStackData>();
        public NetID LookAtNetID { get; set; }
        public LookAtType LookAtType { get; set; }
        public Vector3 LookAtPosition { get; set; }
        public List<KeyValuePair<byte, int>> BuffCount { get; set; } = new List<KeyValuePair<byte, int>>();
        public bool UnknownIsHero { get; set; }


        public override void ReadBodyInternal(PacketReader reader)
        {
            byte itemCount = reader.ReadByte();
            for (int i = 0; i < itemCount; i++)
            {
                var item = new ItemDataPacket();
                item.Slot = reader.ReadByte();
                item.ItemsInSlot = reader.ReadByte();
                item.SpellCharges = reader.ReadByte();
                item.ItemID = reader.ReadItemID();
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

            LookAtNetID = reader.ReadNetID();
            LookAtType = reader.ReadLookAtType();
            LookAtPosition = reader.ReadVector3();

            int numOfBuffCount = reader.ReadInt32();
            for (int i = 0; i < numOfBuffCount; i++)
            {
                byte slot = reader.ReadByte();
                int count = reader.ReadInt32();
                BuffCount.Add(new KeyValuePair<byte, int>(slot, count));
            }

            UnknownIsHero = reader.ReadBool();
        }

        public override void WriteBodyInternal(PacketWriter writer)
        {
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
                writer.WriteItemID(item.ItemID);
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

            writer.WriteNetID(LookAtNetID);
            writer.WriteLookAtType(LookAtType);
            writer.WriteVector3(LookAtPosition);

            writer.WriteInt32(BuffCount.Count);
            foreach (var kvp in BuffCount)
            {
                writer.WriteByte(kvp.Key);
                writer.WriteInt32(kvp.Value);
            }

            writer.WriteBool(UnknownIsHero);
        }
    }

    public abstract class VisibilityDataAIBaseWithMovement : VisibilityDataAIBase
    {
        public int MovementSyncID { get; set; }
        public MovementData MovementData { get; set; } = new MovementDataNone();

        public override void ReadBodyInternal(PacketReader reader)
        {
            base.ReadBodyInternal(reader);
            MovementDataType movementType = reader.ReadMovementDataType();
            MovementSyncID = reader.ReadInt32();
            MovementData = reader.ReadMovementData(movementType);
        }

        public override void WriteBodyInternal(PacketWriter writer)
        {
            base.WriteBodyInternal(writer);
            writer.WriteMovementDataType(MovementData.Type);
            writer.WriteInt32(MovementSyncID);
            writer.WriteMovementData(MovementData);
        }
    }

    public class VisibilityDataAIHero : VisibilityDataAIBaseWithMovement { }

    public class VisibilityDataAIMinion : VisibilityDataAIBaseWithMovement { }
}
