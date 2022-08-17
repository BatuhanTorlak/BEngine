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
    public unsafe class Server
    {
        public static Server server;
        TcpListener listener;
        List<ServerClient> clients;
        int LeastID;

        bool DidDataGet;
        string DataGet;
        string DataSender;

        EncodingType encodingType;

        public ServerClient this[int index]
        {
            get
            {
                foreach (var x in clients)
                {
                    if (x.ID == index)
                        return x;
                }
                throw new Exception("Client ID Cannot Found");
            }
        }

        public Server(IPAddress address, int port)
        {
            encodingType = EncodingType.UTF32;
            server = this;
            listener = new TcpListener(address, port);
            clients = new List<ServerClient>();
            LeastID = 0;
            listener.Start();

            listener.BeginAcceptTcpClient(StartListening, null);
        }
        public Server(IPAddress address, int port, EncodingType encdType)
        {
            encodingType = encdType;
            server = this;
            listener = new TcpListener(address, port);
            clients = new List<ServerClient>();
            LeastID = 0;
            listener.Start();

            listener.BeginAcceptTcpClient(StartListening, null);
        }
        ~Server()
        {
            foreach(var x in clients)
            {
                Disconnect(x);
            }
            listener.Stop();
        }

        void StartListening(IAsyncResult result)
        {
            TcpClient i = listener.EndAcceptTcpClient(result);
            var d = new ServerClient(this, i, LeastID++, encodingType);
            clients.Add(d);

            onConnect.Invoke(d);

            listener.BeginAcceptTcpClient(StartListening, null);
        }

        public bool DataAv()
        {
            return DidDataGet;
        }
        public string[] Data()
        {
            DidDataGet = false;
            return new string[] { DataSender, DataGet };
        }

        public void SetData(string data, ServerClient sender)
        {
            OnDataArrive.Invoke(sender, data);
            DataSender = sender.ID.ToString();
            DataGet = data;
            DidDataGet = true;
        }

        public void SetData(ServerClient sender, string data)
        {
            SetData(data, sender);
            SendDataToEveryone(sender, data);
        }

        void SendDataToEveryone(ServerClient sender, string data)
        {
            for (var i = 0; i < clients.Count; i++)
            {
                var x = clients[i];
                if (!x._client.Connected)
                {
                    x._client.Close();
                    clients.RemoveAt(i);
                    if (i == clients.Count - 1)
                        break;
                    i--;
                    continue;
                }
                if (x != sender)
                    x.WriteData(data);
            }
        }

        public void SendDataToEveryone(string data, params int?[] filter)
        {
            for (var i = 0; i < clients.Count; i++)
            {
                var x = clients[i];
                if (!x._client.Connected)
                {
                    x._client.Close();
                    clients.RemoveAt(i);
                    if (i == clients.Count - 1)
                        break;
                    i--;
                    continue;
                }
                if (!filter.Contains(x.ID))
                    x.WriteData(data);
            }
        }

        public void Disconnect(ServerClient client)
        {
            client._client.Close();
            client._stream.Close();
            clients.Remove(client);
            onDisconnect.Invoke();
        }

        public event Action<ServerClient, string> OnDataArrive;
        public event Action<ServerClient> onConnect;
        public event Action onDisconnect;
    }
}
