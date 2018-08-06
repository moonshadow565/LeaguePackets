using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;
using System.Numerics;

namespace LeaguePackets.GamePackets
{

    public abstract class OnEnterVisiblityClient : GamePacket // 0xBA
    {
        public override GamePacketID ID => GamePacketID.OnEnterVisiblityClient;
        public List<GamePacket> Packets { get; set; } = new List<GamePacket>();

        public abstract void ReadBodyInternal(PacketReader reader);
        protected abstract void WriteBodyInternal(PacketWriter writer);


        public static OnEnterVisiblityClient CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new OnEnterVisiblityClientUnknown();
            result.SenderNetID = senderNetID;
            int totalSize = (ushort)(reader.ReadUInt16() & 0x1FFF);
            for (; totalSize > 0;)
            {
                ushort size = reader.ReadUInt16();
                byte[] data = reader.ReadBytes(size);
                using (var reader2 = new PacketReader(new MemoryStream(data)))
                {
                    result.Packets.Add(GamePacket.Create(reader2));
                }
                totalSize -= 2;
                totalSize -= size;
            }
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
            byte[] buffer = new byte[0];
            using (var stream = new MemoryStream())
            {
                using (var writer2 = new PacketWriter(stream, true))
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
                }
                buffer = new byte[stream.Length];
                Buffer.BlockCopy(stream.GetBuffer(), 0, buffer, 0, buffer.Length);
            }
            if (buffer.Length > 0x1FFF)
            {
                throw new IOException("Packet data too big!");
            }
            writer.WriteUInt16((ushort)(buffer.Length & 0x1FFF));
            writer.WriteBytes(buffer);
            WriteBodyInternal(writer);
        }
    }

    public class ShieldValues
    {
        public float Magical { get; set; }
        public float Phyisical { get; set; }
        public float MagicalAndPhysical { get; set; }
    }

    public class OnEnterVisiblityClientUnknown : OnEnterVisiblityClient
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class OnEnterVisiblityClientNeutralMinionHUD : OnEnterVisiblityClient
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class OnEnterVisiblityClientAILevelProp : OnEnterVisiblityClient
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class OnEnterVisiblityClientSpellMissile : OnEnterVisiblityClient
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class OnEnterVisiblityClientBuilding : OnEnterVisiblityClient
    {
        public override void ReadBodyInternal(PacketReader reader) { }
        protected override void WriteBodyInternal(PacketWriter writer) { }
    }

    public class OnEnterVisibilityClientAIBase : OnEnterVisiblityClient
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
            if(hasShield)
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
        protected override void WriteBodyInternal(PacketWriter writer) 
        {
            int itemCount = Items.Count;
            if(itemCount > 0xFF)
            {
                throw new IOException("More than 255 items!");
            }
            writer.WriteByte((byte)itemCount);
            foreach(var item in Items)
            {
                writer.WriteByte(item.Slot);
                writer.WriteByte(item.ItemsInSlot);
                writer.WriteByte(item.SpellCharges);
                writer.WriteItemID(item.ItemID);
            }

            if(ShieldValues != null)
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
            foreach(var data in CharacterDataStack)
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
            foreach(var kvp in BuffCount)
            {
                writer.WriteByte(kvp.Key);
                writer.WriteInt32(kvp.Value);
            }

            writer.WriteBool(UnknownIsHero);
        }
    }

    public abstract class OnEnterVisibilityClientAIBaseWithMovement : OnEnterVisibilityClientAIBase
    {
        public int MovementSyncID { get; set; }
        public MovementData MovementData { get; set; } = new MovementDataNone();

        public override void ReadBodyInternal(PacketReader reader)
        {
            base.ReadBodyInternal(reader);
            MovementDataType movementType = reader.ReadMovementDataType();
            MovementSyncID = reader.ReadInt32();
            MovementData = MovementData.Create(reader, movementType);
        }
        protected override void WriteBodyInternal(PacketWriter writer)
        {
            base.WriteBodyInternal(writer);
            writer.WriteMovementDataType(MovementData.Type);
            writer.WriteInt32(MovementSyncID);
            MovementData.Write(writer);
        }
    }

    public class OnEnterVisibilityClientAIHero : OnEnterVisibilityClientAIBaseWithMovement
    {
    }

    public class OnEnterVisibilityClientAIMinion : OnEnterVisibilityClientAIBaseWithMovement
    {
    }
}
