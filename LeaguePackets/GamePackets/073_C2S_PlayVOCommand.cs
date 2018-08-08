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
        public static C2S_PlayVOCommand CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_PlayVOCommand();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.CommandID = reader.ReadUInt32();
            result.TargetNetID = reader.ReadNetID();
            result.EventHash = reader.ReadUInt32();
            byte bitfield = reader.ReadByte();
            result.HighlightPlayerIcon = (bitfield & 1) != 0;
            result.FromPing = (bitfield & 2) != 0;
            result.AlliesOnly = (bitfield & 4) != 0;
            reader.ReadPad(3);
        
            return result;
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
