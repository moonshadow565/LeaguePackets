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
    public class C2S_SpellChargeUpdateReq : GamePacket // 0xE6
    {
        public override GamePacketID ID => GamePacketID.C2S_SpellChargeUpdateReq;
        public byte Slot { get; set; }
        public bool IsSummonerSpellBook { get; set; }
        public bool ForceStop { get; set; }

        public Vector3 Position { get; set; }
        public static C2S_SpellChargeUpdateReq CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_SpellChargeUpdateReq();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            byte bitfield = reader.ReadByte();
            result.Slot = (byte)(bitfield & 0x3F);
            result.IsSummonerSpellBook = (bitfield & 0x40) != 0;
            result.ForceStop = (bitfield & 0x80) != 0; 
            result.Position = reader.ReadVector3();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(Slot & 0x3F);
            if (IsSummonerSpellBook)
                bitfield |= 0x40;
            if (ForceStop)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);
            writer.WriteVector3(Position);
        }
    }
}
