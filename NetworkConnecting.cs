using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    delegate void VoidDel();

    enum NetworkState
    {
        online, offline, error
    }

    class NetworkConnecting
    {
        VoidDel vd;
        NetworkState NetState;
        private TcpClient client;
        private static NetworkStream netStream;
        StringBuilder messages = new StringBuilder();
        private Thread work_thread;
        private string login;
        private string serverIP;
        private int port;

        public string Login
        {
            get { return login; }
            set
            {
                if (value.Length < 14)
                    login = value;
            }
        }
        public string ServerIP
        {
            get { return serverIP; }
            set
            {
                serverIP = value;
            }
        }
        public int Port
        {
            get { return port; }
            set
            {
                port = Convert.ToInt32(value);
            }
        }
        public NetworkState netState
        {
            get { return NetState; }
            set { NetState = value; } 
        }

        public bool ConnectToServer()
        {
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse(serverIP), port);
                netStream = client.GetStream();
                NetState = NetworkState.online;
                work_thread = new Thread(new ThreadStart(Work));
                work_thread.Start();
            }
            catch (Exception ex)
            {
                NetState = NetworkState.error;
                GameExceptions.SaveExceptions(ex.Message);
                return false;
            }
            return true;
        }

        public bool DisconnectServer()
        {
            try
            {
                NetState = NetworkState.offline;
                work_thread.Abort();
                netStream.Close();
                client.Close();
                return true;
            }
            catch (Exception ex)
            {
                GameExceptions.SaveExceptions(ex.Message);
                return false;
            }
        }

        public bool ClientIsConnected()
        {
            return client.Connected;
        }

        public bool WriteToServer(string response)
        {
            try
            {
                byte[] toBytes = Encoding.Unicode.GetBytes(response);
                netStream.Write(toBytes, 0, toBytes.Length);
            }
            catch (Exception ex)
            {
                NetState = NetworkState.error;
                GameExceptions.SaveExceptions(ex.Message);
                return false;
            }
            return true;
        }

        public bool DataIsAvailable()
        {
            if (messages != null)
                return true;
            else return false;
        }

        public void NewNotifications(VoidDel newVD)
        {
            vd += newVD;
        }

        public string ReadServer()
        {
            string msg;
            lock (messages)
            {
                msg = messages.ToString();
                messages.Clear();
            }
            return msg;
        }

        public void Work()
        {

            try
            {
                while (true)
                {
                    byte[] data = new byte[400];
                    int bytes = netStream.Read(data, 0, data.Length); // получаем количество считанных байтов
                    lock (messages)
                    {
                        messages.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    vd();
                }
            }
            catch (ThreadAbortException ex)
            {
                GameExceptions.SaveExceptions(ex.Message);
            }
            catch (Exception exep)
            {
                GameExceptions.SaveExceptions(exep.Message);
                NetState = NetworkState.error;
                return;
            }
        }
    }
}
