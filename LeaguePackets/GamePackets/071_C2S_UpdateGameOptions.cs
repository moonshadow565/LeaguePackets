using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_UpdateGameOptions : GamePacket // 0x47
    {
        public override GamePacketID ID => GamePacketID.C2S_UpdateGameOptions;
        public bool AutoAttackEnabled { get;set; }
        public C2S_UpdateGameOptions(){}

        public C2S_UpdateGameOptions(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.AutoAttackEnabled = reader.ReadBool();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteBool(AutoAttackEnabled);
        }
    }
}
