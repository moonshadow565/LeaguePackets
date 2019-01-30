using LeaguePackets;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePacketsSerializer
{
    class Program
    {
        [Flags]
        public enum ENetPacketFlags
        {
            Reliable = (1 << 7),
            Unsequenced = (1 << 6),
            ReliableUnsequenced = Reliable | Unsequenced,
            None = 0,
        }
        public class ENetPacket
        {
            public float Time { get; set; }
            public byte[] Bytes { get; set; }
            public byte Channel { get; set; }
            public ENetPacketFlags Flags { get; set; }
        }

        public class SerializedPacket
        {
            public int RawID { get; set; }
            public BasePacket Packet { get; set; }
            public float Time { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public ChannelID? ChannelID { get; set; }
            public byte RawChannel { get; set; }
        }

        public class BadPacket
        {
            public int RawID { get; set; }
            public byte[] Raw { get; set; }
            public byte RawChannel { get; set; }
            public string Error { get; set; }
        }

        public static void SerializeToFile(object what, string fileName)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Serialize(file, what);
            }
        }

        static void Main(string[] args)
        {
            var fileName = "test.rlp.json";
            if (args.Length > 0)
                fileName = args[0];
            Console.WriteLine("Reading file...");
            var json = File.ReadAllText(fileName);
            Console.WriteLine("Parsing json...");
            var rawPackets = JsonConvert.DeserializeObject<List<ENetPacket>>(json);
            var serializedPackets = new List<SerializedPacket>();
            var hardBadPackets = new List<BadPacket>();
            var softBadPackets = new List<BadPacket>();
            Console.WriteLine("Processing raw packets...");
            foreach (var rPacket in rawPackets)
            {
                if (rPacket.Channel < 8)
                {
                    int rawID = rPacket.Bytes[0];
                    if (rawID == 254)
                    {
                        rawID = rPacket.Bytes[5] | rPacket.Bytes[6] << 8;
                    }
                    try
                    {
                        var packet = BasePacket.Create(rPacket.Bytes, (ChannelID)rPacket.Channel);
                        serializedPackets.Add(new SerializedPacket
                        {
                            RawID = rawID,
                            Packet = packet,
                            Time = rPacket.Time,
                            ChannelID = rPacket.Channel < 8 ? (ChannelID)rPacket.Channel : (ChannelID?)null,
                            RawChannel = rPacket.Channel,
                        });
                        if (rPacket.Channel > 0 && packet.ExtraBytes.Length > 0)
                        {
                            softBadPackets.Add(new BadPacket()
                            {
                                RawID = rawID,
                                Raw = rPacket.Bytes,
                                RawChannel = rPacket.Channel,
                                Error = $"Extra bytes: {Convert.ToBase64String(packet.ExtraBytes)}",
                            });
                        }
                        if(packet is IGamePacketsList list)
                        {
                            foreach(var packet2 in list.Packets)
                            {
                                if (rPacket.Channel > 0 && packet2.ExtraBytes.Length > 0)
                                {
                                    softBadPackets.Add(new BadPacket()
                                    {
                                        RawID = (int)packet2.ID,
                                        Raw = rPacket.Bytes,
                                        RawChannel = rPacket.Channel,
                                        Error = $"Extra bytes in {packet2.GetType().Name}: {Convert.ToBase64String(packet2.ExtraBytes)}",
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        hardBadPackets.Add(new BadPacket()
                        {
                            RawID = rawID,
                            Raw = rPacket.Bytes,
                            RawChannel = rPacket.Channel,
                            Error = exception.ToString(),
                        });
                    }
                }

            }

            Console.WriteLine($"Processed! Good: {serializedPackets.Count}, Soft Error: {softBadPackets.Count}, Hard Error: {hardBadPackets.Count}");
            Console.WriteLine($"Soft bad IDs:{string.Join(",", softBadPackets.Select(x => x.RawID.ToString()).Distinct())}");
            Console.WriteLine($"Hard bad IDs:{string.Join(",", hardBadPackets.Select(x => x.RawID.ToString()).Distinct())}");

            Console.WriteLine("Writing hard bad to file .hardbad.json");
            SerializeToFile(hardBadPackets, fileName.Replace(".rlp.json", ".rlp.hardbad.json"));

            Console.WriteLine("Writing soft bad to file .softbad.json");
            SerializeToFile(softBadPackets, fileName.Replace(".rlp.json", ".rlp.softbad.json"));

            Console.WriteLine("Writing serialized to .rlp.serialized.json...");
            SerializeToFile(serializedPackets, fileName.Replace(".rlp.json", ".rlp.serialized.json"));

            Console.WriteLine("Done!");
            return;
        }
    }
}
