using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
namespace LeaguePackets
{
    public class PacketWriter : IDisposable
    {
        private BinaryWriter _writer;
        public Stream Stream => _writer.BaseStream;
        public PacketWriter(Stream stream, bool leaveOpen = false)
        {
            _writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen);
        }
        public PacketWriter() : this(new MemoryStream(), false) { }

        public void Dispose()
        {
            ((IDisposable)_writer).Dispose();
        }

        public void WriteBool(bool data) => _writer.Write(data);
        public void WriteSByte(SByte data) => _writer.Write(data);
        public void WriteByte(byte data) => _writer.Write(data);
        public void WriteInt16(short data) => _writer.Write(data);
        public void WriteUInt16(ushort data) => _writer.Write(data);
        public void WriteInt32(int data) => _writer.Write(data);
        public void WriteUInt32(uint data) => _writer.Write(data);
        public void WriteInt64(long data) => _writer.Write(data);
        public void WriteUInt64(ulong data) => _writer.Write(data);
        public void WriteFloat(float data) => _writer.Write(data);
        public void WriteDouble(double data) => _writer.Write(data);
        public void WriteBytes(byte[] data) => _writer.Write(data);
        public void WritePad(int count) => _writer.Write(new byte[count]);

        public void WriteFixedString(string str, int maxLength)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.ASCII.GetBytes(str);
            var count = data.Length;
            if (count >= (maxLength - 1))
            {
                throw new IOException("Too much data!");
            }
            WriteBytes(data);
            WritePad(maxLength - count);
        }

        public void WriteSizedString(string str)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.ASCII.GetBytes(str);
            var count = data.Length;
            WriteInt32(count);
            WriteBytes(data);
        }

        public  void WriteSizedFixedString(string str, int maxLength)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.ASCII.GetBytes(str);
            var count = data.Length;
            if (count >= (maxLength - 1))
            {
                throw new IOException("Data count too big!");
            }
            WriteInt32(count);
            WriteBytes(data);
            WritePad(maxLength - count);
        }

        public void WriteSizedFixedStringLast(string str, int maxLength)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.ASCII.GetBytes(str);
            var count = data.Length;
            if (count >= (maxLength - 1))
            {
                throw new IOException("Data count too big!");
            }
            WriteInt32(count);
            WriteBytes(data);
            WritePad(1);
            //WritePad(maxLength - count);
        }

        public void WriteZeroTerminatedString(string str)
        {
            WriteBytes(string.IsNullOrEmpty(str) ? new byte[0] : Encoding.ASCII.GetBytes(str));
            WriteByte(0);
        }

        public void WriteFixedStringLast(string str, int maxLength)
        {
            WriteZeroTerminatedString(str);
        }

        public void WriteVector2(Vector2 data)
        {
            WriteFloat(data.X);
            WriteFloat(data.Y);
        }

        public void WriteVector3(Vector3 data)
        {
            WriteFloat(data.X);
            WriteFloat(data.Y);
            WriteFloat(data.Z);
        }

        public void WriteVector4(Vector4 data)
        {
            WriteFloat(data.X);
            WriteFloat(data.Y);
            WriteFloat(data.Z);
            WriteFloat(data.W);
        }

        public void WritePackedUInt32(uint data)
        {
            var num = data;
            while (num >= 0x80)
            {
                WriteByte((byte)(num | 0x80));
                num >>= 7;
            }
            WriteByte((byte)num);
        }

        public void WritePackedInt32(int data)
        {
            WritePackedUInt32((uint)data);
        }

        public void WritePackedFloat(float data)
        {
            var bytes = BitConverter.GetBytes(data);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            if(bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0 && bytes[3] == 0)
            {
                WriteByte(0xFF);
            }
            else if(bytes[0] >= 0xFE)
            {
                WriteByte(0xFE);
                WriteBytes(bytes);
            }
            else
            {
                WriteBytes(bytes);
            }
        }
    }
}
