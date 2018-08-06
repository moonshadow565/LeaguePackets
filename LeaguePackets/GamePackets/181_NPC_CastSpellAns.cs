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
    public class NPC_CastSpellAns : GamePacket // 0xB5
    {
        public override GamePacketID ID => GamePacketID.NPC_CastSpellAns;
        public int CasterPositionSyncID { get; set; }
        public bool Unknown1 { get; set; } //if this is false CasterPositionSyncID is used ?
        public CastInfo CastInfo { get; set; } = new CastInfo();

        public static NPC_CastSpellAns CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new NPC_CastSpellAns();
            result.SenderNetID = senderNetID;
            result.CasterPositionSyncID = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            result.Unknown1 = (bitfield & 1) != 0;

            result.CastInfo = reader.ReadCastInfo();
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(CasterPositionSyncID);

            byte bitfield = 0;
            if(Unknown1)
            {
                bitfield |= 1;
            }
            writer.WriteByte(bitfield);

            writer.WriteCastInfo(CastInfo);
        }
    }
}
