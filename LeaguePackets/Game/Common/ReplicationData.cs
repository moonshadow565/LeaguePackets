using System;
using System.Collections;


namespace LeaguePackets.Game.Common
{
    public class ReplicationData
    {
        private Tuple<uint, byte[]>[] _data = new Tuple<uint, byte[]>[]
        {
            new Tuple<uint, byte[]>(0, new byte[0]),
            new Tuple<uint, byte[]>(0, new byte[0]),
            new Tuple<uint, byte[]>(0, new byte[0]),
            new Tuple<uint, byte[]>(0, new byte[0]),
            new Tuple<uint, byte[]>(0, new byte[0]),
            new Tuple<uint, byte[]>(0, new byte[0]),
        };
        public uint UnitNetID { get; set; }
        public Tuple<uint, byte[]>[] Data => _data;
    }

    public static class ReplicationDataExtension
    {
        public static ReplicationData ReadReplicationData(this ByteReader reader)
        {
            var result = new ReplicationData();
            byte primaryIdArray = reader.ReadByte();
            result.UnitNetID = reader.ReadUInt32();
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                if ((primaryIdArray & (1 << primaryId)) == 0)
                {
                    continue;
                }
                var seconadaryIdArray = reader.ReadUInt32();
                var dataCount = reader.ReadByte();
                var data = reader.ReadBytes(dataCount);
                result.Data[primaryId] = new Tuple<uint, byte[]>(seconadaryIdArray, data);
            }
            return result;
        }

        public static void WriteReplicationData(this ByteWriter writer, ReplicationData result)
        {
            byte primaryIdArray = 0;
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                if(result.Data[primaryId].Item1 != 0)
                {
                    primaryIdArray |= (byte)(1 << primaryId); 
                }
            }
            writer.WriteByte(primaryIdArray);
            writer.WriteUInt32(result.UnitNetID);
            for (var primaryId = 0; primaryId < result.Data.Length; primaryId++)
            {
                if(result.Data[primaryId].Item1 != 0)
                {
                    writer.WriteUInt32(result.Data[primaryId].Item1);
                    writer.WriteByte((byte)result.Data[primaryId].Item2.Length);
                    writer.WriteBytes(result.Data[primaryId].Item2);
                }
            }
        }
    }
}
