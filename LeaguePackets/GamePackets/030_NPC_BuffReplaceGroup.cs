using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class NPC_BuffReplaceGroup : GamePacket // 0x1E
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplaceGroup;
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<BuffInGroupReplace> Buffs { get; set; } = new List<BuffInGroupReplace>();
        public static NPC_BuffReplaceGroup CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffReplaceGroup();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.RunningTime = reader.ReadFloat();
            result.Duration = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                result.Buffs.Add(reader.ReadBuffInGroupReplace());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(RunningTime);
            writer.WriteFloat(Duration);
            int numInGroup = Buffs.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs insidde!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupReplace(Buffs[i]);
            }
        }
    }
}
