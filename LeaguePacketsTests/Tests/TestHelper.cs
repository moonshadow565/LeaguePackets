using LeaguePackets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePacketsTests.Tests
{
    public static class TestHelper
    {
        [DebuggerHidden]
        public static void WriteRead(Action<BinaryWriter> write, Action<BinaryReader> read)
        {
            long expectedPosition;
            long actualPosition;
            try
            {
                using (var stream = new MemoryStream())
                {
                    using (var writer = new BinaryWriter(stream, Encoding.ASCII, true))
                    {
                        write(writer);
                    }
                    expectedPosition = stream.Position;
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var reader = new BinaryReader(stream, Encoding.ASCII, true))
                    {
                        read(reader);
                    }
                    actualPosition = stream.Position;
                }
            }
            catch(Exception exc)
            {
                throw exc;
            }
            if (expectedPosition != actualPosition)
            {
                throw new AssertionException("Bytes left to read!");
            }
        }
    }
}
