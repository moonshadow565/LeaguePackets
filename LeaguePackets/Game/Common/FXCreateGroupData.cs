using System;
using System.Collections.Generic;
using System.IO;

namespace LeaguePackets.Game.Common
{
    public class FXCreateGroupData
    {
        public uint PackageHash { get; set; }
        public uint EffectNameHash { get; set; }
        public ushort Flags { get; set; }
        public uint TargetBoneNameHash { get; set; }
        public uint BoneNameHash { get; set; }
        public List<FXCreateData> FXCreateData { get; set; } = new List<FXCreateData>();
    }

    public static class FXCreateGroupDataExtension
    {
        public static FXCreateGroupData ReadFXCreateGroupData(this ByteReader reader)
        {
            var data = new FXCreateGroupData();
            data.PackageHash = reader.ReadUInt32();
            data.EffectNameHash = reader.ReadUInt32();
            data.Flags = reader.ReadUInt16();
            data.TargetBoneNameHash = reader.ReadUInt32();
            data.BoneNameHash = reader.ReadUInt32();
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                data.FXCreateData.Add(reader.ReadFXCreateData());
            }
            return data;
        }

        public static void WriteFXCreateGroupData(this ByteWriter writer, FXCreateGroupData data)
        {
            writer.WriteUInt32(data.PackageHash);
            writer.WriteUInt32(data.EffectNameHash);
            writer.WriteUInt16(data.Flags);
            writer.WriteUInt32(data.TargetBoneNameHash);
            writer.WriteUInt32(data.BoneNameHash);
            int count = data.FXCreateData.Count;
            if(count > 0xFF)
            {
                throw new IOException("FXCreateData list too big > 255!");
            }
            writer.WriteByte((byte)count);
            foreach(var fx in data.FXCreateData)
            {
                writer.WriteFXCreateData(fx);
            }
        }
    }
}
