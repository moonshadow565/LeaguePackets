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
        public static S2C_CreateTurret CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new S2C_CreateTurret();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.NetID = reader.ReadNetID();
            result.NetNodeID = reader.ReadNetNodeID();
            result.Name = reader.ReadFixedString(64);
            byte bitfield = reader.ReadByte();
            result.IsTargetable = (bitfield & 1) != 0;

            result.IsTargetableToTeam = reader.ReadSpellFlags();
        
            return result;
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
