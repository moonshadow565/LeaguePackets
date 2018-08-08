using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class NPC_CastSpellReq : GamePacket // 0x9A
    {
        public override GamePacketID ID => GamePacketID.NPC_CastSpellReq;
        public byte Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        public bool IsHudClickCast { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 EndPosition { get; set; }
        public NetID TargetNetID { get; set; }

        public static NPC_CastSpellReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_CastSpellReq();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Slot = (byte)(bitfield & 0x3F);
            result.IsSummonerSpellBook = (bitfield & 0x40) != 0;
            result.IsHudClickCast = (bitfield & 0x80) != 0;
            result.Position = reader.ReadVector2();
            result.EndPosition = reader.ReadVector2();
            result.TargetNetID = reader.ReadNetID();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(Slot & 0x3F);
            if (IsSummonerSpellBook)
                bitfield |= 0x40;
            if (IsHudClickCast)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);
            writer.WriteVector2(Position);
            writer.WriteVector2(EndPosition);
            writer.WriteNetID(TargetNetID);
        }
    }
}
