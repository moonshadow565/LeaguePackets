using System;
using System.Collections.Generic;
using System.IO;

using LeaguePackets.Game;
using LeaguePackets.LoadScreen;

namespace LeaguePackets
{
    public sealed class Batched : GamePacket, IGamePacketsList
    {
        public override GamePacketID ID => GamePacketID.Batched;

        public List<GamePacket> Packets { get; set; } = new List<GamePacket>();

        protected override void ReadHeader(ByteReader reader)
        {
            reader.ReadPad(1);
        }

        protected override void ReadBody(ByteReader reader)
        {
            int count = reader.ReadByte();
            long totalSize = reader.Length - 2;
            if(totalSize < 1 || count == 0)
            {
                return;
            }

            byte packetSize = reader.ReadByte();
            if(packetSize < 5)
            {
                throw new IOException("Too small packet in batch!");
            }
            byte packetLastID = reader.ReadByte();
            int packetLastNetID = reader.ReadInt32();
            byte[] packetData = reader.ReadBytes(packetSize - 5);

            using(var packetWriter = new ByteWriter())
            {
                packetWriter.WriteByte(packetLastID);
                packetWriter.WriteInt32(packetLastNetID);
                packetWriter.WriteBytes(packetData);
                this.Packets.Add(GamePacket.Create(packetWriter.GetBytes()));
            }

            for (int i = 1; i < count; i++)
            {
                byte bitfield = reader.ReadByte();
                if((bitfield & 1) == 0) //if this is true re-use old packetID
                {
                    packetLastID = reader.ReadByte();
                }
                if((bitfield & 2) != 0)
                {
                    packetLastNetID += reader.ReadSByte();
                }
                else
                {
                    packetLastNetID = reader.ReadInt32();
                }
                packetSize = (byte)(bitfield >> 2);
                if(packetSize == 63)
                {
                    packetSize = reader.ReadByte();
                }
                packetData = reader.ReadBytes(packetSize);

                using (var packetWriter = new ByteWriter())
                {
                    packetWriter.WriteByte(packetLastID);
                    packetWriter.WriteInt32(packetLastNetID);
                    packetWriter.WriteBytes(packetData);
                    this.Packets.Add(GamePacket.Create(packetWriter.GetBytes()));
                }
            }
        }

        protected override void WriteHeader(ByteWriter writer)
        {
            writer.WriteByte((byte)GamePacketID.Batched);
        }

        protected override void WriteBody(ByteWriter writer)
        {
            int packetCount = Packets.Count;
            if(packetCount > 255)
            {
                throw new IOException("Too many packets inside batch packet!");
            }
            writer.WriteByte((byte)packetCount);
            byte packetLastId = 0;
            int packetLastNetId = 0;
            for (int i = 0; i < packetCount; i ++)
            {
                var packet = Packets[i];
                var packetData = packet.GetBytes();
                var newPacketId = packetData[0];
                byte[] newPacketNetIdBuffer = new byte[4];
                Buffer.BlockCopy(packetData, 1, newPacketNetIdBuffer, 0, 4);
                if(!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(newPacketNetIdBuffer);
                }
                int newPacketNetId = BitConverter.ToInt32(newPacketNetIdBuffer, 0);


                if(packetData.Length < 5)
                {
                    throw new IOException("Packet too small for batch < 5!");
                }
                if(i == 0)
                {
                    if (packetData.Length > 255)
                    {
                        throw new IOException("First packet too big for batch > 255!");
                    }
                    writer.WriteByte((byte)packetData.Length);
                    writer.WriteBytes(packetData);
                }
                else
                {
                    if (packetData.Length > 260)
                    {
                        throw new IOException("Non-first packet too big for batch > 260!");
                    }

                    bool hasId = true;
                    bool hasNetId = true;
                    bool hasSize = true;

                    int packetSize = packetData.Length - 5;
                    byte bitfield = 0;
                    if (newPacketId == packetLastId)
                    {
                        hasId = false;
                        bitfield |= 1;
                    }
                    else
                    {
                        hasId = true;
                    }

                    int packetNetIdDiff = newPacketNetId - packetLastNetId;
                    if(packetNetIdDiff <= SByte.MaxValue && packetNetIdDiff >= SByte.MinValue)
                    {
                        hasNetId = false;
                        bitfield |= 2;
                    }
                    else
                    {
                        hasNetId = true;
                    }


                    if(packetSize < 63)
                    {
                        hasSize = false;
                        bitfield |= (byte)((byte)packetSize << 2);
                    }
                    else
                    {
                        hasSize = true;
                        bitfield |= (63 << 2);
                    }

                    writer.WriteByte(bitfield);
                    if(hasId)
                    {
                        writer.WriteByte(newPacketId);
                    }
                    if(hasNetId)
                    {
                        writer.WriteInt32(newPacketNetId);
                    }
                    else
                    {
                        writer.WriteSByte((SByte)packetNetIdDiff);
                    }
                    if(hasSize)
                    {
                        writer.WriteByte((byte)packetSize);
                    }
                    byte[] remainData = new byte[packetSize];
                    Buffer.BlockCopy(packetData, 5, remainData, 0, packetSize);
                    writer.WriteBytes(remainData);
                }
                packetLastId = newPacketId;
                packetLastNetId = newPacketNetId;
            }
        }
    }
}
