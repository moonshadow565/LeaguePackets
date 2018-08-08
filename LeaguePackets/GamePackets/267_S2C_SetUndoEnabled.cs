using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_SetUndoEnabled : GamePacket // 0x10B
    {
        public override GamePacketID ID => GamePacketID.S2C_SetUndoEnabled;
        public byte UndoStackSize { get; set; }
        public S2C_SetUndoEnabled(){}

        public S2C_SetUndoEnabled(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.UndoStackSize = reader.ReadByte();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteByte(UndoStackSize);
        }
    }
}
