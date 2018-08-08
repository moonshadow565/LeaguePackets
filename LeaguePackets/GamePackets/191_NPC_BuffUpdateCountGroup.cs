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
    public class NPC_BuffUpdateCountGroup : GamePacket // 0xBF
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCountGroup;
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public List<BuffInGroupUpdateCount> Buffs { get; set; } = new List<BuffInGroupUpdateCount>();
        public static NPC_BuffUpdateCountGroup CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffUpdateCountGroup();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.Duration = reader.ReadFloat();
            result.RunningTime = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                result.Buffs.Add(reader.ReadBuffInGroupUpdateCount());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteFloat(Duration);
            writer.WriteFloat(RunningTime);
            int numInGroup = Buffs.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupUpdateCount(Buffs[i]);
            }
        }
    }
}
