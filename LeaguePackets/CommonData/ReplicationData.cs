using System;
using System.Collections;
using LeaguePackets.Common;

namespace LeaguePackets.CommonData
{
    public class ReplicationData
    {
        private Tuple<BitArray, byte[]>[] _data = new Tuple<BitArray, byte[]>[]
        {
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
            new Tuple<BitArray, byte[]>(new BitArray(32), new byte[0]),
        };
        public NetID UnitNetID { get; set; }
        public Tuple<BitArray, byte[]>[] Data => _data;
    }

    public static class ReplicationDataExtension
    {
        public static ReplicationData ReadReplicationData(this PacketReader reader)
        {
            var result = new ReplicationData();
            var primaryIdArray = new BitArray(reader.ReadByte());
            result.UnitNetID = reader.ReadNetID();
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                var seconadaryIdArray = new BitArray(reader.ReadBytes(1));
                reader.ReadPad(3);
                var dataCount = reader.ReadByte();
                var data = reader.ReadBytes(dataCount);
                result.Data[primaryId] = new Tuple<BitArray, byte[]>(seconadaryIdArray, data);
            }
            return result;
        }

        public static void WriteReplicationData(this PacketWriter writer, ReplicationData result)
        {
            byte primaryIdArray = 0;
            byte[] seconadaryIdArray = new byte[result.Data.Length];
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                byte[] tmpBuffer = new byte[(result.Data[primaryId].Item1.Length / 8) + 1];
                result.Data[primaryId].Item1.CopyTo(tmpBuffer, 0);
                seconadaryIdArray[primaryId] = tmpBuffer[0];
                if(seconadaryIdArray[primaryId] != 0)
                {
                    primaryIdArray |= (byte)(1u << primaryId);
                }
            }
            writer.WriteByte(primaryIdArray);
            writer.WriteNetID(result.UnitNetID);
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                if(seconadaryIdArray[primaryId] != 0)
                {
                    writer.WriteByte(seconadaryIdArray[primaryId]);
                    writer.WritePad(3);
                    writer.WriteByte((byte)result.Data[primaryId].Item2.Length);
                    writer.WriteBytes(result.Data[primaryId].Item2);
                }
            }
        }
    }
}
