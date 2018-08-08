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
    //NOTE: content varies on gamemode so its up to consumer of packet how to process/read it
    public class S2C_HeroStats : GamePacket // 0x46
    {
        public override GamePacketID ID => GamePacketID.S2C_HeroStats;
        public byte[] Data { get; set; } = new byte[0];

        public void WriteData(List<HeroStat> stats)
        {
            using(var stream = new MemoryStream())
            {
                using (var writer = new PacketWriter(stream, true))
                {
                    foreach(var stat in stats)
                    {
                        stat.Write(writer);
                    }
                }
            }
        }

        public void ReadData(List<HeroStat> stats)
        {
            using (var stream = new MemoryStream())
            {
                using (var reader = new PacketReader(stream, true))
                {
                    foreach (var stat in stats)
                    {
                        stat.Read(reader);
                    }
                }
                if(stream.Position != stream.Length)
                {
                    throw new IOException("Failed to read stats correctly!");
                }
            }
        }

        public static S2C_HeroStats CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_HeroStats();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            int size = reader.ReadInt32();
            result.Data = reader.ReadBytes(size);
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteInt32(Data.Length);
            writer.WriteBytes(Data);
        }
    }
}
