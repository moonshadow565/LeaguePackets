using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_CreateTurret : GamePacket // 0x9D
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateTurret;
        public NetID NetID { get; set; }
        public NetNodeID NetNodeID { get; set; }
        public string Name { get; set; } = "";
        public bool IsTargetable { get; set; }

        public SpellFlags IsTargetableToTeam { get; set; }
        public S2C_CreateTurret(){}

        public S2C_CreateTurret(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.NetID = reader.ReadNetID();
            this.NetNodeID = reader.ReadNetNodeID();
            this.Name = reader.ReadFixedString(64);
            byte bitfield = reader.ReadByte();
            this.IsTargetable = (bitfield & 1) != 0;

            this.IsTargetableToTeam = reader.ReadSpellFlags();
        
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteNetID(NetID);
            writer.WriteNetNodeID(NetNodeID);
            writer.WriteFixedString(Name, 64);
            byte bitfield = 0;
            if (IsTargetable)
                bitfield |= 1;
            writer.WriteByte(bitfield);

            writer.WriteSpellFlags(IsTargetableToTeam);
        }
    }
}
