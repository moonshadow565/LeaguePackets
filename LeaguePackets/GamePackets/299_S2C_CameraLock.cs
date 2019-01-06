using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_CameraLock : GamePacket // 0x12B
    {
        public override GamePacketID ID => GamePacketID.S2C_CameraLock;
        //FIXME: toggle lock?
        public bool Unknown0 { get; set; }
        //FIXME: distance?
        public float Unknown1 { get; set; }
        public float Unknown2 { get; set; }
        public float Unknown3 { get; set; }
        public bool Unknown4 { get; set; }

        public S2C_CameraLock(){}

        public S2C_CameraLock(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            byte bitfield1 = reader.ReadByte();
            Unknown0 = (bitfield1 & 0x01) != 0;

            Unknown1 = reader.ReadFloat();
            Unknown2 = reader.ReadFloat();
            Unknown3 = reader.ReadFloat();

            byte bitfield2 = reader.ReadByte();
            Unknown4 = (bitfield2 & 0x01) != 0;
            
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield1 = 0;
            if (Unknown0)
                bitfield1 |= 0x01;
            writer.WriteByte(bitfield1);

            writer.WriteFloat(Unknown1);
            writer.WriteFloat(Unknown2);
            writer.WriteFloat(Unknown3);

            byte bitfield2 = 0;
            if (Unknown4)
                bitfield2 |= 0x01;
            writer.WriteByte(bitfield2);
        }
    }
}
