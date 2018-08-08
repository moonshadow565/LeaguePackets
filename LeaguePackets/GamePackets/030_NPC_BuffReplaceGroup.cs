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
        public NPC_BuffReplaceGroup(){}

        public NPC_BuffReplaceGroup(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                this.Buffs.Add(reader.ReadBuffInGroupReplace());
            }
        
            this.ExtraBytes = reader.ReadLeft();
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
