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
        /*
        public uint IDToChange { get; set; }
        public bool UseSpells { get; set; }
        public bool ModelOnly { get; set; }
        public bool ReplaceCharacterPackage { get; set; }
        public uint SkinID { get; set; }
        public string SkinName { get; set; } = "";
        */
        public static S2C_ChangeCharacterData CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_ChangeCharacterData();
            result.SenderNetID = senderNetID;
            result.Data.ID = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            result.Data.OverrideSpells = (bitfield & 1) != 0;
            result.Data.ModelOnly = (bitfield & 2) != 0;
            result.Data.ReplaceCharacterPackage = (bitfield & 4) != 0;

            result.Data.SkinID = reader.ReadUInt32();
            result.Data.SkinName = reader.ReadFixedString(64);
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(Data.ID);
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

            writer.WriteUInt32(Data.SkinID);
            writer.WriteFixedString(Data.SkinName, 64);
        }
    }
}
