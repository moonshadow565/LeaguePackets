using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class C2S_TutorialAudioEventFinished : GamePacket // 0x5
    {
        public override GamePacketID ID => GamePacketID.C2S_TutorialAudioEventFinished;
        public NetID AudioEventNetID { get; set; }

        public static C2S_TutorialAudioEventFinished CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new C2S_TutorialAudioEventFinished();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.AudioEventNetID = reader.ReadNetID();

            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(AudioEventNetID);
        }
    }
}
