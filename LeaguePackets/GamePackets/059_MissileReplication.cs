using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class MissileReplication : GamePacket // 0x3B
    {
        public override GamePacketID ID => GamePacketID.MissileReplication;
        public Vector3 Position { get; set; }
        public Vector3 CasterPosition { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 StartPoint { get; set; }
        public Vector3 EndPoint { get; set; }
        public Vector3 UnitPosition { get; set; }
        public float TimeFromCreation { get; set; }
        public float Speed { get; set; }
        public float LifePercentage { get; set; }
        public float TimedSpeedDelta { get; set; }
        public float TimedSpeedDeltaTime { get; set; }

        // TODO: verify bitfield
        public bool Bounced { get; set; }

        public CastInfo CastInfo { get; set; } = new CastInfo();

        public MissileReplication(){}

        public MissileReplication(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            this.SenderNetID = senderNetID;
            this.ChannelID = channelID;

            this.Position = reader.ReadVector3();
            this.CasterPosition = reader.ReadVector3();
            this.Direction = reader.ReadVector3();
            this.Velocity = reader.ReadVector3();
            this.StartPoint = reader.ReadVector3();
            this.EndPoint = reader.ReadVector3();
            this.UnitPosition = reader.ReadVector3();
            this.TimeFromCreation = reader.ReadFloat();
            this.Speed = reader.ReadFloat();
            this.LifePercentage = reader.ReadFloat();
            this.TimedSpeedDelta = reader.ReadFloat();
            this.TimedSpeedDeltaTime = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            this.Bounced = (bitfield & 1) != 0;

            this.CastInfo = reader.ReadCastInfo();
            //TODO: read pad bytes if any(should be 512 byte buffer)?
            this.ExtraBytes = reader.ReadLeft();
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteVector3(Position);
            writer.WriteVector3(CasterPosition);
            writer.WriteVector3(Direction);
            writer.WriteVector3(Velocity);
            writer.WriteVector3(StartPoint);
            writer.WriteVector3(EndPoint);
            writer.WriteVector3(UnitPosition);
            writer.WriteFloat(TimeFromCreation);
            writer.WriteFloat(Speed);
            writer.WriteFloat(LifePercentage);
            writer.WriteFloat(TimedSpeedDelta);
            writer.WriteFloat(TimedSpeedDeltaTime);

            byte bitfield = 0;
            if(Bounced)
            {
                bitfield |= 1;
            }

            writer.WriteCastInfo(CastInfo);
        }
    }
}
