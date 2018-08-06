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
        public static S2C_LineMissileHitList CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_LineMissileHitList();
            result.SenderNetID = senderNetID;
            int size = reader.ReadInt16();
            for (int i = 0; i < size; i++)
            {
                result.Targets.Add(reader.ReadNetID());
            }
        
            return result;
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
