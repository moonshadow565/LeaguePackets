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
    public class NPC_BuffRemoveGroup : GamePacket // 0x94
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffRemoveGroup;
        public uint BuffNameHash { get; set; }
        public List<BuffInGroupRemove> Buffs { get; set; } = new List<BuffInGroupRemove>();

        public static NPC_BuffRemoveGroup CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_BuffRemoveGroup();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.BuffNameHash = reader.ReadUInt32();
            int numInGroup = reader.ReadByte();
            for (int i = 0; i < numInGroup; i++)
            {
                result.Buffs.Add(reader.ReadBuffInGroupRemove());
            }
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteUInt32(BuffNameHash);
            int numInGroup = Buffs.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many buffs in list!");
            }
            writer.WriteByte((byte)numInGroup);
            for (int i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffInGroupRemove(Buffs[i]);
            }
        }
    }
}
