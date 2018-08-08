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
    public class S2C_MapPing : GamePacket // 0x40
    {
        public override GamePacketID ID => GamePacketID.S2C_MapPing;
        public Vector2 Position { get; set; }
        public NetID TargetNetID { get; set; }
        public NetID SourceNetID { get; set; }

        public PingCategory PingCategory { get; set; }
        public bool PlayAudio { get; set; }
        public bool ShowChat { get; set; }
        public bool PingThrottled { get; set; }
        public bool PlayVO { get; set; }

        public static S2C_MapPing CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_MapPing();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Position = reader.ReadVector2();
            result.TargetNetID = reader.ReadNetID();
            result.SourceNetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            result.PingCategory = (PingCategory)(bitfield & 0x0F);
            result.PlayAudio = (bitfield & 0x10) != 0;
            result.ShowChat = (bitfield & 0x20) != 0;
            result.PingThrottled = (bitfield & 0x40) != 0;
            result.PlayVO = (bitfield & 0x80) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteNetID(TargetNetID);
            writer.WriteNetID(SourceNetID);
            byte bitfield = 0;
            bitfield |= (byte)((byte)PingCategory & 0x0F);
            if (PlayAudio)
                bitfield |= 0x10;
            if (ShowChat)
                bitfield |= 0x20;
            if (PingThrottled)
                bitfield |= 0x40;
            if (PlayVO)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);
        }
    }
}
