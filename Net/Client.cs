#define BNET

using System;
using System.Net.Sockets;
using System.Text;

namespace BEngine.Net
{
    public class Client
    {
        TcpClient server;
        NetworkStream stream;
        byte[] buffer;
        int bufferSize = 1024;

        bool DataGetAv;
        string Data;

        EncodingType encodingType;

        public Client(string hostname, int port)
        {
            encodingType = EncodingType.UTF8;
            server = new TcpClient(hostname, port);
            stream = server.GetStream();
            bufferSize *= 10;

            if (encodingType == EncodingType.UTF32)
            {
                bufferSize *= 5;
            }

            buffer = new byte[bufferSize];

            stream.BeginRead(buffer, 0, bufferSize, GetDatas, 0);
        }

        public Client(string hostname, int port, EncodingType encdType)
        {
            encodingType = encdType;
            server = new TcpClient(hostname, port);
            stream = server.GetStream();
            bufferSize *= 10;

            buffer = new byte[bufferSize];

            stream.BeginRead(buffer, 0, bufferSize, GetDatas, 0);
        }

        void GetDatas(IAsyncResult result)
        {
            try
            {
                var lmt = stream.EndRead(result);

                var metin = "";

                switch (encodingType)
                {
                    case EncodingType.UTF32:
                        metin = Encoding.UTF32.GetString(buffer, 0, lmt);
                        break;
                    case EncodingType.UTF8:
                        metin = Encoding.UTF8.GetString(buffer, 0, lmt);
                        break;
                    case EncodingType.UTF7:
                        metin = Encoding.UTF7.GetString(buffer, 0, lmt);
                        break;
                }

                SetData(metin);

                buffer = new byte[bufferSize];

                stream.BeginRead(buffer, 0, bufferSize, GetDatas, null);
            }
            catch
            {
                Disconnect();
            }
        }

        public void SendData(string data)
        {
            var i = new byte[0];

            switch (encodingType)
            {
                case EncodingType.UTF32:
                    i = Encoding.UTF32.GetBytes(data);
                    break;
                case EncodingType.UTF8:
                    i = Encoding.UTF8.GetBytes(data);
                    break;
                case EncodingType.UTF7:
                    i = Encoding.UTF7.GetBytes(data);
                    break;
            }
            byte[] vs = new byte[bufferSize];
            Array.Copy(i, vs, i.Length);
            stream.BeginWrite(vs, 0, bufferSize, SendDataCallBack, null);
        }

        void SendDataCallBack(IAsyncResult result)
        {
            stream.EndRead(result);
        }

        void SetData(string data)
        {
            OnDataArrive.Invoke(data);
            Data = data;
            DataGetAv = true;
        }

        void Disconnect()
        {
            Console.WriteLine("Bağlantı Kesildi!");
            onDisconnect.Invoke();
        }

        public bool DataAviable()
        {
            return DataGetAv;
        }

        public string GetData()
        {
            DataGetAv = false;
            return Data;
        }

        public event Action onConnect;
        public event Action<string> OnDataArrive;
        public event Action onDisconnect;
    }
}
