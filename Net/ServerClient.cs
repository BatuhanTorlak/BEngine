using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text.Encodings;
using System.Text;
using System.Buffers;
using System.Threading.Tasks;
using System.Threading;

namespace BEngine.Net
{
    public class ServerClient
    {
        Server server;
        public TcpClient _client
        {
            get
            {
                return client;
            }
        }
        TcpClient client;
        public NetworkStream _stream
        {
            get
            {
                return stream;
            }
        }
        NetworkStream stream;
        public int ID { private set; get; }
        byte[] buffer;
        int bufferSize = 1024;

        EncodingType encodingType;

        public ServerClient(Server sv, TcpClient tcp, int id, EncodingType encdType)
        {
            encodingType = encdType;
            client = tcp;
            ID = id;
            server = sv;

            bufferSize *= 10;

            if (encodingType == EncodingType.UTF32)
            {
                bufferSize *= 5;
            }

            buffer = new byte[bufferSize]; 
            
            stream = client.GetStream();
            stream.BeginRead(buffer, 0, bufferSize, GetDatas, null);
        }
        ~ServerClient()
        {
            server.Disconnect(this);
        }

        void GetDatas(IAsyncResult result)
        {
            try
            {
                var lmt = stream.EndRead(result);
                var metin = "";

                switch (encodingType)
                {
                    case (EncodingType.UTF32):
                        metin = Encoding.UTF32.GetString(buffer);
                        break;
                    case (EncodingType.UTF8):
                        metin = Encoding.UTF8.GetString(buffer);
                        break;
                    case EncodingType.UTF7:
                        metin = Encoding.UTF7.GetString(buffer);
                        break;
                }

                server.SetData(this, metin);

                buffer = new byte[bufferSize];

                stream.BeginRead(buffer, 0, bufferSize, GetDatas, null);
            }
            catch
            {
                server.Disconnect(this);
            }
        }

        public void WriteData(string Text)
        {
            var i = new byte[0];
            switch (encodingType)
            {
                case EncodingType.UTF32:
                    i = Encoding.UTF32.GetBytes(Text);
                    break;
                case EncodingType.UTF8:
                    i = Encoding.UTF8.GetBytes(Text);
                    break;
                case EncodingType.UTF7:
                    i = Encoding.UTF7.GetBytes(Text);
                    break;
            }
            byte[] vs = new byte[bufferSize];
            Array.Copy(i, vs, i.Length);
            stream.BeginWrite(vs, 0, bufferSize, SetDatas, null);
        }

        void SetDatas(IAsyncResult result)
        {
            stream.EndWrite(result);
        }
    }
}