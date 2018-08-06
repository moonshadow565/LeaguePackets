using System;
namespace LeaguePackets.Common
{
    public enum SpectatorChunkType : byte
    {
        None = 0x0,
        Common = 0x1,
        Snapshot = 0x2,
        EndStartup = 0x3,
        GameStart = 0x4,
        Startup = 0x5,
    }
}
