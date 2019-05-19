using System;


namespace LeaguePackets.Game.Common
{
    public class TooltipVars
    {
        private float[] _values = new float[5];
        public uint OwnerNetID { get; set; }
        public byte SlotIndex { get; set; }
        public float[] Values => _values;
    }

    public static class TooltipVarsExtension
    {
        public static TooltipVars ReadTooltipValues(this ByteReader reader)
        {
            var data = new TooltipVars();
            data.OwnerNetID = reader.ReadUInt32();
            data.SlotIndex = reader.ReadByte();
            for (int i = 0; i < data.Values.Length; i++)
            {
                data.Values[i] = reader.ReadFloat();
            }
            return data;
        }

        public static void WriteTooltipValues(this ByteWriter writer, TooltipVars data)
        {
            if(data == null)
            {
                data = new TooltipVars();   
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteByte(data.SlotIndex);
            for (int i = 0; i < data.Values.Length; i++)
            {
                writer.WriteFloat(data.Values[i]);
            }
        }
    }
}
