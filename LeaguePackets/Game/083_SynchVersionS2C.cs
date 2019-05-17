
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class SynchVersionS2C : GamePacket // 0x54
    {
        public override GamePacketID ID => GamePacketID.SynchVersionS2C;
        private string[] _mutators = new string[8];
        private uint[] _disabledItems = new uint[64];
        private bool[] _enabledDradisMessages = new bool[19];
        private PlayerLoadInfo[] _playerInfo = new PlayerLoadInfo[12];

        public bool VersionMatches { get; set; }
        public bool WriteToClientFile { get; set; }
        public bool MatchedGame { get; set; }
        public bool DradisInit { get; set; }

        public int MapToLoad { get; set; }
        public PlayerLoadInfo[] PlayerInfo => _playerInfo;
        public string VersionString { get; set; } = "";
        public string MapMode { get; set; } = "";
        public string PlatformID { get; set; } = "";
        public string[] Mutators => _mutators;
        public byte MutatorsNum { get; set; }            
        public string OrderRankedTeamName { get; set; } = "";
        public string OrderRankedTeamTag { get; set; } = "";
        public string ChaosRankedTeamName { get; set; } = "";
        public string ChaosRankedTeamTag { get; set; } = "";
        public string MetricsServerWebAddress { get; set; } = "";
        public string MetricsServerWebPath { get; set; } = "";
        public ushort MetricsServerPort { get; set; }
        public string DradisProdAddress { get; set; } = "";
        public string DradisProdResource { get; set; } = "";
        public ushort DradisProdPort { get; set; }
        public string DradisTestAddress { get; set; } = "";
        public string DradisTestResource { get; set; } = "";
        public ushort DradisTestPort { get; set; }
        public TipConfig TipConfig { get; set; } = new TipConfig();
        public ulong GameFeatures { get; set; }
        public uint[] DisabledItems => _disabledItems;
        public bool[] EnabledDradisMessages => _enabledDradisMessages;

        protected override void ReadBody(ByteReader reader)
        {

            byte bitfield = reader.ReadByte();
            this.VersionMatches = (bitfield & 1) != 0;
            this.WriteToClientFile = (bitfield & 2) != 0;
            this.MatchedGame = (bitfield & 4) != 0;
            this.DradisInit = (bitfield & 8) != 0;

            this.MapToLoad = reader.ReadInt32();
            for (var i = 0; i < this.PlayerInfo.Length; i++)
            {
                this.PlayerInfo[i] = reader.ReadPlayerInfo();
            }
            this.VersionString = reader.ReadFixedString(256);
            this.MapMode = reader.ReadFixedString(128);
            this.PlatformID = reader.ReadFixedString(32);
            for (var i = 0; i < this.Mutators.Length; i++)
                this.Mutators[i] = reader.ReadFixedString(64);
            this.MutatorsNum = reader.ReadByte();
            this.OrderRankedTeamName = reader.ReadFixedString(97);
            this.OrderRankedTeamTag = reader.ReadFixedString(25);
            this.ChaosRankedTeamName = reader.ReadFixedString(97);
            this.ChaosRankedTeamTag = reader.ReadFixedString(25);
            this.MetricsServerWebAddress = reader.ReadFixedString(256);
            this.MetricsServerWebPath = reader.ReadFixedString(256);
            this.MetricsServerPort = reader.ReadUInt16();
            this.DradisProdAddress = reader.ReadFixedString(256);
            this.DradisProdResource = reader.ReadFixedString(256);
            this.DradisProdPort = reader.ReadUInt16();
            this.DradisTestAddress = reader.ReadFixedString(256);
            this.DradisTestResource = reader.ReadFixedString(256);
            this.DradisTestPort = reader.ReadUInt16();
            this.TipConfig = reader.ReadTipConfig();
            this.GameFeatures = reader.ReadUInt64();
            for (var i = 0; i < this.DisabledItems.Length; i++)
                this.DisabledItems[i] = reader.ReadUInt32();
            for (var i = 0; i < this.EnabledDradisMessages.Length; i++)
                this.EnabledDradisMessages[i] = reader.ReadBool();
        }

        protected override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (VersionMatches)
                bitfield |= 1;
            if (WriteToClientFile)
                bitfield |= 2;
            if (MatchedGame)
                bitfield |= 4;
            if (DradisInit)
                bitfield |= 8;
            writer.WriteByte(bitfield);

            writer.WriteInt32(MapToLoad);
            for (var i = 0; i < PlayerInfo.Length; i++)
                writer.WritePlayerInfo(PlayerInfo[i]);
            writer.WriteFixedString(VersionString, 256);
            writer.WriteFixedString(MapMode, 128);
            writer.WriteFixedString(PlatformID, 32);
            for (var i = 0; i < Mutators.Length; i++)
                writer.WriteFixedString(Mutators[i], 64);
            writer.WriteByte(MutatorsNum);
            writer.WriteFixedString(OrderRankedTeamName, 97);
            writer.WriteFixedString(OrderRankedTeamTag, 25);
            writer.WriteFixedString(ChaosRankedTeamName, 97);
            writer.WriteFixedString(ChaosRankedTeamTag, 25);
            writer.WriteFixedString(MetricsServerWebAddress, 256);
            writer.WriteFixedString(MetricsServerWebPath, 256);
            writer.WriteUInt16(MetricsServerPort);
            writer.WriteFixedString(DradisProdAddress, 256);
            writer.WriteFixedString(DradisProdResource, 256);
            writer.WriteUInt16(DradisProdPort);
            writer.WriteFixedString(DradisTestAddress, 256);
            writer.WriteFixedString(DradisTestResource, 256);
            writer.WriteUInt16(DradisTestPort);
            writer.WriteTipConfig(TipConfig);
            writer.WriteUInt64(GameFeatures);
            for (var i = 0; i < DisabledItems.Length; i++)
                writer.WriteUInt32(DisabledItems[i]);
            for (var i = 0; i < EnabledDradisMessages.Length; i++)
                writer.WriteBool(EnabledDradisMessages[i]);

        }
    }
}
