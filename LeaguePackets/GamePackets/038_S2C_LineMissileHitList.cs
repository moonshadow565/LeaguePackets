using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_LineMissileHitList : GamePacket // 0x26
    {
        public override GamePacketID ID => GamePacketID.S2C_LineMissileHitList;
        public List<NetID> Targets { get; set; } = new List<NetID>();
        public S2C_LineMissileHitList(){}

        public S2C_LineMissileHitList(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            int size = reader.ReadInt16();
            for (int i = 0; i < size; i++)
            {
                this.Targets.Add(reader.ReadNetID());
            }
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            int size = Targets.Count;
            if(size > 0x7FFF)
            {
                throw new IOException("Target list too big!");
            }
            writer.WriteInt16((short)size);
            for (int i = 0; i < size; i++)
            {
                writer.WriteNetID(Targets[i]);
            }
        }
    }
}
