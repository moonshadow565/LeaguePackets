using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_PlayVOCommand : GamePacket // 0x49
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayVOCommand;
        public uint CommandID { get; set; }
        public NetID TargetNetID { get; set; }
        public uint EventHash { get; set; }
        public bool HighlightPlayerIcon { get; set; }
        public bool FromPing { get; set; }
        public bool AlliesOnly { get; set; }
        public C2S_PlayVOCommand(){}

        public C2S_PlayVOCommand(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.CommandID = reader.ReadUInt32();
            this.TargetNetID = reader.ReadNetID();
            this.EventHash = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            this.HighlightPlayerIcon = (bitfield & 1) != 0;
            this.FromPing = (bitfield & 2) != 0;
            this.AlliesOnly = (bitfield & 4) != 0;
            reader.ReadPad(3);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(CommandID);
            writer.WriteNetID(TargetNetID);
            writer.WriteUInt32(EventHash);
            byte bitfield = 0;
            if (HighlightPlayerIcon)
                bitfield |= (byte)1;
            if (FromPing)
                bitfield |= (byte)2;
            if (AlliesOnly)
                bitfield |= (byte)4;
            writer.WriteByte(bitfield);
            writer.WritePad(3);
        }
    }
}
