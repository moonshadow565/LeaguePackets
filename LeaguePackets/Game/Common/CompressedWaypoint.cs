using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game.Common
{
    public struct CompressedWaypoint
    {
        public short X;
        public short Y;
        public CompressedWaypoint(short x, short y)
        {
            X = x;
            Y = y;
        }
    }

    public static class CompressedWaypointExtension
    {
        public static List<CompressedWaypoint> ReadCompressedWaypoints(this ByteReader reader, uint size)
        {
            var data = new List<CompressedWaypoint>();
            BitArray flags;
            if (size > 1)
            {
                byte[] flagsBuffer = reader.ReadBytes((int)((size - 2) / 4 + 1));
                flags = new BitArray(flagsBuffer);
            }
            else
            {
                flags = new BitArray(new byte[1]);
            }
            short lastX = reader.ReadInt16();
            short lastZ = reader.ReadInt16();
            data.Add(new CompressedWaypoint(lastX, lastZ));

            for (int i = 1, flag = 0; i < size; i++)
            {
                if (flags[flag])
                {
                    lastX += reader.ReadSByte();
                }
                else
                {
                    lastX = reader.ReadInt16();
                }
                flag++;
                if (flags[flag])
                {
                    lastZ += reader.ReadSByte();
                }
                else
                {
                    lastZ = reader.ReadInt16();
                }
                flag++;
                data.Add(new CompressedWaypoint(lastX, lastZ));
            }
            return data;
        }

        public static void WriteCompressedWaypoints(this ByteWriter writer, List<CompressedWaypoint> data)
        {
            if(data == null)
            {
                data = new List<CompressedWaypoint>();
            }
            int size = data.Count;
            if (size < 1)
            {
                throw new IOException("Need at least 1 waypoint!");
            }
            byte[] flagsBuffer;
            if (size > 1)
            {
                flagsBuffer = new byte[(size - 2) / 4 + 1u];
            }
            else
            {
                flagsBuffer = new byte[0];
            }
            var flags = new BitArray(flagsBuffer);
            for (int i = 1, flag = 0; i < size; i++)
            {
                int relativeX = data[i].X - data[i - 1].X;
                flags[flag] = (relativeX <= SByte.MaxValue && relativeX >= SByte.MinValue);
                flag++;

                int realtiveZ = data[i].Y - data[i - 1].Y;
                flags[flag] = (realtiveZ <= SByte.MaxValue && realtiveZ >= SByte.MinValue);
                flag++;
            }
            flags.CopyTo(flagsBuffer, 0);
            writer.WriteBytes(flagsBuffer);
            writer.WriteInt16(data[0].X);
            writer.WriteInt16(data[0].Y);
            for (int i = 1, flag = 0; i < size; i++)
            {
                if (flags[flag])
                {
                    writer.WriteSByte((SByte)(data[i].X - data[i - 1].X));
                }
                else
                {
                    writer.WriteInt16(data[i].X);
                }
                flag++;
                if (flags[flag])
                {
                    writer.WriteSByte((SByte)(data[i].Y - data[i - 1].Y));
                }
                else
                {
                    writer.WriteInt16(data[i].Y);
                }
                flag++;
            }
        }
    }
}
