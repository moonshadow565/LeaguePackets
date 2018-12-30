using System;
namespace LeaguePackets.CommonData.Events
{
    public class ArgsGoldEarned : ArgsBase
    {
        public float Ammount { get; set; }
        public override void ReadArgs(PacketReader reader)
        {
            base.ReadArgs(reader);
            Ammount = reader.ReadFloat();
            reader.ReadUInt64();
        }
        public override void WriteArgs(PacketWriter writer)
        {
            base.WriteArgs(writer);
            writer.WriteFloat(Ammount);
            writer.WriteUInt64(0);
        }
    }
}
