using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LeaguePackets.GamePackets
{
    public class SpawnBotS2C : GamePacket // 0xCF
    {
        public override GamePacketID ID => GamePacketID.SpawnBotS2C;
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public byte BotRank { get; set; }
        public TeamID TeamID { get; set; }

        public int SkinID { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public SpawnBotS2C(){}

        public SpawnBotS2C(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Position = reader.ReadVector3();
            this.BotRank = reader.ReadByte();
            ushort bitfield = reader.ReadUInt16();
            this.TeamID = (TeamID)(bitfield & 0x1FF);

            this.SkinID = reader.ReadInt32();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteVector3(Position);
            writer.WriteByte(BotRank);
            ushort bitfield = 0;
            bitfield = (ushort)((ushort)TeamID & 0x1FF);
            writer.WriteUInt16(bitfield);

            writer.WriteInt32(SkinID);
            writer.WriteFixedString(Name, 64);
            writer.WriteFixedString(SkinName, 64);
        }
    }
}
