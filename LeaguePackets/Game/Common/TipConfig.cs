using System;
namespace LeaguePackets.Game.Common
{
    public class TipConfig
    {
        public sbyte TipID { get; set; }
        public sbyte ColorID { get; set; }
        public sbyte DurationID { get; set; }
        public sbyte Flags { get; set; }
    }
    public static class TipConfigExtension
    {
        public static TipConfig ReadTipConfig(this ByteReader reader)
        {
            var tip = new TipConfig();
            tip.TipID = reader.ReadSByte();
            tip.ColorID = reader.ReadSByte();
            tip.DurationID = reader.ReadSByte();
            tip.Flags = reader.ReadSByte();
            return tip;
        }

        public static void WriteTipConfig(this ByteWriter writer, TipConfig tip)
        {
            if(tip == null)
            {
                tip = new TipConfig();
            }
            writer.WriteSByte(tip.TipID);
            writer.WriteSByte(tip.ColorID);
            writer.WriteSByte(tip.DurationID);
            writer.WriteSByte(tip.Flags);
        }
    }
}
