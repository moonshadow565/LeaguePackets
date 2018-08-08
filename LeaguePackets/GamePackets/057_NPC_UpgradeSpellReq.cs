using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class NPC_UpgradeSpellReq : GamePacket // 0x39
    {
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellReq;
        public byte Slot { get; set; }
        public bool IsEvolve { get; set; }
        public static NPC_UpgradeSpellReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_UpgradeSpellReq();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Slot = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            result.IsEvolve = (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(Slot);
            byte bitfield = 0;
            if (IsEvolve)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
