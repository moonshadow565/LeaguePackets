using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.GamePackets
{
    public class S2C_StartGame : GamePacket // 0x5C
    {
        public override GamePacketID ID => GamePacketID.S2C_StartGame;
        public bool EnablePause { get; set; }
        public static S2C_StartGame CreateBody(PacketReader reader, NetID senderNetID)
        {
            var result = new S2C_StartGame();
            result.SenderNetID = senderNetID;
            byte bitfield = reader.ReadByte();
            result.EnablePause |= (bitfield & 1) != 0;
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            byte bitfield = 0;
            if (EnablePause)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}
