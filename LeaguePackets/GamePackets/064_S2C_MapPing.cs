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

        public S2C_MapPing(){}

        public S2C_MapPing(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector2();
            this.TargetNetID = reader.ReadNetID();
            this.SourceNetID = reader.ReadNetID();
            byte bitfield = reader.ReadByte();
            this.PingCategory = (PingCategory)(bitfield & 0x0F);
            this.PlayAudio = (bitfield & 0x10) != 0;
            this.ShowChat = (bitfield & 0x20) != 0;
            this.PingThrottled = (bitfield & 0x40) != 0;
            this.PlayVO = (bitfield & 0x80) != 0;
        
            this.ExtraBytes = reader.ReadLeft();
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
