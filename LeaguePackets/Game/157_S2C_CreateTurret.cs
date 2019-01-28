
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.Game
{
    public class S2C_CreateTurret : GamePacket // 0x9D
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateTurret;
        public uint NetID { get; set; }
        public byte NetNodeID { get; set; }
        public string Name { get; set; } = "";
        public bool IsTargetable { get; set; }

        public uint IsTargetableToTeamSpellFlags { get; set; }

        protected override void ReadBody(ByteReader reader)
        {

            this.NetID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.Name = reader.ReadFixedString(64);
            byte bitfield = reader.ReadByte();
            this.IsTargetable = (bitfield & 1) != 0;

            this.IsTargetableToTeamSpellFlags = reader.ReadUInt32();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(NetID);
            writer.WriteByte(NetNodeID);
            writer.WriteFixedString(Name, 64);
            byte bitfield = 0;
            if (IsTargetable)
                bitfield |= 1;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(IsTargetableToTeamSpellFlags);
        }
    }
}
