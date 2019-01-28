using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
namespace LeaguePackets
{
    public class ByteWriter : IDisposable
    {
        private BinaryWriter _writer;
        private MemoryStream _stream;

        public ByteWriter()
        {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        public void Dispose()
        {
            ((IDisposable)_writer).Dispose();
        }

        public int Position => (int)_stream.Position;
        public int Seek(int offset, SeekOrigin origin = SeekOrigin.Current)
        {
            return (int)_stream.Seek(offset, origin);
        }
        public int Length => (int)_stream.Length;
        public byte[] GetBytes()
        {
            byte[] result = new byte[_stream.Length];
            Buffer.BlockCopy(_stream.GetBuffer(), 0, result, 0, result.Length);
            return result;
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
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            var count = data.Length;
            if (count >= (maxLength - 1))
            {
                throw new IOException("Too much data!");
            }
            WriteBytes(data);
            WritePad(maxLength - count);
        }

        public void WriteFixedStringLast(string str, int maxLength)
        {
            WriteFixedString(str, maxLength);
        }

        public void WriteSizedString(string str)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            var count = data.Length;
            WriteInt32(count);
            WriteBytes(data);
        }

        public void WriteSizedStringLast(string str)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            var count = data.Length;
            WriteInt32(count + 1);
            WriteBytes(data);
            WritePad(1);
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
