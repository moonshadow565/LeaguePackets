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
    public class S2C_ChangeCharacterData : GamePacket // 0x97
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterData;
        public CharacterStackData Data { get; set; } = new CharacterStackData();
        public S2C_ChangeCharacterData(){}

        public S2C_ChangeCharacterData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            this.Data.OverrideSpells = (bitfield & 1) != 0;
            this.Data.ModelOnly = (bitfield & 2) != 0;
            this.Data.ReplaceCharacterPackage = (bitfield & 4) != 0;

            this.Data.ID = reader.ReadUInt32();
            this.Data.SkinID = reader.ReadUInt32();
            this.Data.SkinName = reader.ReadFixedStringLast(64);
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if(Data.OverrideSpells)
            {
                bitfield |= 1;
            }
            if(Data.ModelOnly)
            {
                bitfield |= 2;
            }
            if(Data.ReplaceCharacterPackage)
            {
                bitfield |= 4;
            }
            writer.WriteByte(bitfield);

            writer.WriteUInt32(Data.ID);
            writer.WriteUInt32(Data.SkinID);
            writer.WriteFixedStringLast(Data.SkinName, 64);
        }
    }
}
