using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class FX_Create_Group : GamePacket // 0x87
    {
        public override GamePacketID ID => GamePacketID.FX_Create_Group;
        public List<FXCreateGroupData> FXCreateGroup { get; set; } = new List<FXCreateGroupData>();
        public static FX_Create_Group CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new FX_Create_Group();
            result.SenderNetID = senderNetID;
            int count = reader.ReadByte();
            for (int i = 0; i < count; i ++)
            {
                result.FXCreateGroup.Add(reader.ReadFXCreateGroupData());
            }
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            int count = FXCreateGroup.Count;
            if(count > 0xFF)
            {
                throw new IOException("FXCreateGroup list too big > 255!");
            }
            writer.WriteByte((byte)count);
            foreach(var fxgroup in FXCreateGroup)
            {
                writer.WriteFXCreateGroupData(fxgroup);
            }
        }
    }
}
