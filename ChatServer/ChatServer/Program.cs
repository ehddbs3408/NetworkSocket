using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;

namespace ConsoleApplication
{
    class Program
    {
        public static Hashtable clientList = new Hashtable();
        private static int userCount = 0;
        private static Mutex mut = new Mutex();

        static void Main(string[] args)
        {
            try
            {
                TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;
                byte[] bytesFrom = new byte[1024];
                string detaFromClient = "";

                serverSocket.Start();
                Console.WriteLine("C# Server started...");
                counter = 0;
                while(true)
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();

                    counter = userCount;
                    userCount++;

                    HandleClient client = new HandleClient();
                    clientList.Add(counter, clientSocket);

                    client.startClient(clientSocket, clientList, counter);

                }
                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine("Exit");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static TcpClient GetSocket(int id)
        {
            TcpClient socket = null;
            if(clientList.ContainsKey(id))
            {
                HandleClient hc = (HandleClient)clientList[id];
                socket = hc.clientSocket;
            }
            return socket;
        }

        public static void broadcast(string msg,string uName, bool flag)
        {
            mut.WaitOne();
            Byte[] broadcastBytes = null;

            if(flag == true) //클라이언트
            {
                broadcastBytes = Encoding.UTF8.GetBytes(uName + "$" + msg);
            }
            else //server
            {
                broadcastBytes = Encoding.UTF8.GetBytes(msg);
            }

            foreach(DictionaryEntry Item in clientList)
            {
                TcpClient broadcastSocket;
                HandleClient hc = (HandleClient)Item.Value;
                broadcastSocket = hc.clientSocket;

                NetworkStream broadcastStream = broadcastSocket.GetStream();
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
            mut.ReleaseMutex();
        }

        public static void UserAdd(string clientNo,TcpClient clientSocket)
        {
            broadcast(clientNo + "Joined", "", false);
            Console.WriteLine(clientNo+"Joined chat room");
        }

        public static void UserLeft(int userID,string clientID)
        {
            if(clientList.ContainsKey(userID))
            {
                broadcast(clientID + "$#Left", clientID, false);
                Console.WriteLine("client Left:" + clientID);

                TcpClient clientSocket = GetSocket(userID);

                clientList.Remove(userID);
                clientSocket.Close();
            }
        }
    }

    public class HandleClient
    {
        const string COMMAND_ENTER = "#ENTER#";
        const string COMMAND_HISTORY = "#HISTORY#";

        public TcpClient clientSocket;
        public int userID;
        public string ClientID;

        private Hashtable clientList;
        private bool noConnection = false;

        public void startClient(TcpClient inClientSocket,Hashtable cList,int userSerial)
        {
            userID = userSerial;
            clientSocket = inClientSocket;
            clientList = cList;

            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }
        private void doChat()
        {
            byte[] bytesFrom = new byte[1024];
            string dataFromClient = "";
            NetworkStream networkStream = clientSocket.GetStream();


            while(!noConnection)
            {
                try
                {
                    int numBytesRead;
                    if(!socketConnected(clientSocket.Client))
                    {
                        noConnection = true;
                    }
                    else
                    {
                        if(networkStream.DataAvailable)
                        {
                            dataFromClient = "";
                            while(networkStream.DataAvailable)
                            {
                                numBytesRead = networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                                dataFromClient = Encoding.UTF8.GetString(bytesFrom, 0, numBytesRead);
                            }
                            int idx = dataFromClient.IndexOf("$");
                            if(ClientID == null && idx>0)
                            {
                                ClientID = dataFromClient.Substring(0, idx);
                                Program.UserAdd(ClientID,clientSocket);
                            }
                            else if(idx >0)
                            {
                                dataFromClient = dataFromClient.Substring(0, dataFromClient.Length - 1);
                                Console.WriteLine("From Client - "+ClientID + ": ",dataFromClient);
                                Program.broadcast(dataFromClient, ClientID, true);
                            }
                            else
                            {
                                dataFromClient = "";
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    noConnection = true;
                    Console.WriteLine("Error: "+ e,ToString());
                }
            }
            Program.UserLeft(userID, ClientID);
        }
    }
}