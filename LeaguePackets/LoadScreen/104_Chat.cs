
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LeaguePackets.LoadScreen
{
    public sealed class Chat : LoadScreenPacket // 0x68
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.Chat;

        public int ClientID { get; set; }
        public uint NetID { get; set; }
        public bool Localized { get; set; }
        public uint ChatType { get; set; }
        public string Params { get; set; } = "";
        public string Message { get; set; } = "";

        protected override void ReadBody(ByteReader reader)
        {
            ClientID = reader.ReadInt32();
            NetID = reader.ReadUInt32();
            Localized = reader.ReadBool();
            ChatType = reader.ReadUInt32();
            var paramsSize = reader.ReadInt32();
            var messageSize = reader.ReadInt32();
            if (paramsSize > 32)
                throw new IOException("Params size too big!");
            if (messageSize > 1024)
                throw new IOException("Message size too big!");
            var pars = reader.ReadBytes(32).Take(paramsSize).ToArray();
            var msg = reader.ReadBytes(messageSize);
            if (Localized)
            {
                Params = Encoding.UTF8.GetString(pars);
                Message = Encoding.UTF8.GetString(msg);
                reader.ReadPad(1);
            }
            else
            {
                Params = Encoding.ASCII.GetString(pars);
                Message = Encoding.ASCII.GetString(msg);
                reader.ReadPad(1);
            }
        }

        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(ClientID);
            writer.WriteUInt32(NetID);
            writer.WriteBool(Localized);
            writer.WriteUInt32(ChatType);
            byte[] pars;
            byte[] message;
            if (Localized)
            {
                pars = Encoding.UTF8.GetBytes(Params);
                message = Encoding.UTF8.GetBytes(Message);
            }
            else
            {
                pars = Encoding.ASCII.GetBytes(Params);
                message = Encoding.ASCII.GetBytes(Message);
            }
            var paramsSize = pars.Length;
            if (paramsSize > 32)
                throw new IOException("Params size too big!");
            var messageSize = message.Length;
            if (messageSize > 1024)
                throw new IOException("Message size too big!");
            writer.WriteInt32(paramsSize);
            writer.WriteInt32(messageSize);
            writer.WriteBytes(pars);
            writer.WritePad(32 - paramsSize);
            writer.WriteBytes(message);
            writer.WritePad(1);
        }
    }
}
