using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace LeaguePackets.GamePackets
{
    public class UnknownGamePacket : GamePacket
    {
        private GamePacketID _id;
        public override GamePacketID ID => _id;
        public GamePacketID GamePacketIDRaw 
        {
            get => _id;
            set => _id = value;
        }
        public UnknownGamePacket(GamePacketID id) => _id = id;
        public UnknownGamePacket() {}

        public static UnknownGamePacket CreateBody(PacketReader reader, NetID senderNetID, GamePacketID id)
        {
            var result = new UnknownGamePacket(id);
            result.SenderNetID = senderNetID;
            return result;
        }

        public override void WriteBody(PacketWriter writer)
        {
        }
    }
}
