
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class OnEnterLocalVisiblityClient : GamePacket, IGamePacketsList // 0xAE
    {
        public override GamePacketID ID => GamePacketID.OnEnterLocalVisiblityClient;
        public List<GamePacket> Packets { get; set; } = new List<GamePacket>();

        public float MaxHealth { get; set; }
        public float Health { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            int totalSize = (ushort)(reader.ReadUInt16() & 0x1FFF);
            for (; totalSize > 0;)
            {
                ushort size = reader.ReadUInt16();
                byte[] data = reader.ReadBytes(size);
                this.Packets.Add(GamePacket.Create(data));
                totalSize -= 2;
                totalSize -= size;
            }

            if (reader.BytesLeft > 0)
            {
                MaxHealth = reader.ReadFloat();
                Health = reader.ReadFloat();
            }
        }

        protected override void WriteBody(ByteWriter writer)
        {
            using (var writer2 = new ByteWriter())
            {
                foreach (var packet in Packets)
                {
                    var data = packet.GetBytes();
                    if (data.Length > 0x1FFF)
                    {
                        throw new IOException("Packet too big!");
                    }
                    writer.WriteUInt16((ushort)data.Length);
                    writer.WriteBytes(data);
                }
                var buffer = writer2.GetBytes();
                if (buffer.Length > 0x1FFF)
                {
                    throw new IOException("Packet data too big!");
                }
                writer.WriteUInt16((ushort)(buffer.Length & 0x1FFF));
                writer.WriteBytes(buffer);
            }

            writer.WriteFloat(MaxHealth);
            writer.WriteFloat(Health);
        }
    }
}
