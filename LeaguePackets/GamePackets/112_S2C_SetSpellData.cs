using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetSpellData : GamePacket // 0x70
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellData;
        public NetID ObjectNetID { get; set; }
        public uint HashedSpellName { get; set; }
        public byte SpellSlot { get; set; }
        public S2C_SetSpellData(){}

        public S2C_SetSpellData(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.ObjectNetID = reader.ReadNetID();
            this.HashedSpellName = reader.ReadUInt32();
            this.SpellSlot = reader.ReadByte();
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(ObjectNetID);
            writer.WriteUInt32(HashedSpellName);
            writer.WriteByte(SpellSlot);
        }
    }
}
