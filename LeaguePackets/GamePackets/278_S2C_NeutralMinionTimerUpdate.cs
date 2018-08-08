using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_NeutralMinionTimerUpdate : GamePacket // 0x116
    {
        public override GamePacketID ID => GamePacketID.S2C_NeutralMinionTimerUpdate;
        public int TypeHash { get; set; }
        public float Expire { get; set; }
        public static S2C_NeutralMinionTimerUpdate CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_NeutralMinionTimerUpdate();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.TypeHash = reader.ReadInt32();
            result.Expire = reader.ReadFloat();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(TypeHash);
            writer.WriteFloat(Expire);
        }
    }
}
