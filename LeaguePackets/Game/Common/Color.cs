using System;
namespace LeaguePackets.Game.Common
{
    public struct Color
    {
        public byte Blue { set; get; }
        public byte Green { get; set; }
        public byte Red { get; set; }
        public byte Alpha { get; set; }

        public static explicit operator Color(uint packed)
        {
            return new Color
            {
                Blue = (byte)((packed >> 0) & 0xFF),
                Green = (byte)((packed >> 8) & 0xFF),
                Red = (byte)((packed >> 16) & 0xFF),
                Alpha = (byte)((packed >> 24) & 0xFF),
            };
        }
        public static explicit operator uint(Color c)
        {
            return 
                ((uint)c.Blue) |
                ((uint)c.Green << 8)|
                ((uint)c.Red << 16) |
                ((uint)c.Alpha << 24);
        }
        public static bool operator ==(Color a, Color b)
        {
            return a.Blue == b.Blue &&
                   a.Green == b.Green &&
                   a.Red == b.Red &&
                   a.Alpha == b.Alpha;
        }
        public static bool operator !=(Color a, Color b) => !(a == b);
        public override bool Equals(Object obj) => (obj is Color b) && this == b;
        public override int GetHashCode()
        {
            return (int)(uint)this;
        }
    }

    public static class ColorExtension
    {
        public static Color ReadColor(this ByteReader reader)
        {
            return (Color)reader.ReadUInt32();
        }

        public static void WriteColor(this ByteWriter writer, Color data)
        {
            writer.WriteUInt32((uint)data);
        }
    }
}
