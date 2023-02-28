using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpServer
{
    class TcpClientBox
    {
        public TcpClient Client { get; set; }
        public StreamWriter Writer { get; }
        public StreamReader Reader { get; }
        public TcpClientBox(TcpClient client)
        {
            this.Client = client;
            this.Writer = new StreamWriter(client.GetStream());
            this.Reader = new StreamReader(client.GetStream());
        }
    }
    class Program
    {
        private static TcpListener server;
        private static List<TcpClientBox> clientBoxList = new List<TcpClientBox>();
        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Any, 9000);
            server.Start();
            var thread = new Thread(HandleConnections);
            thread.Start();
            var menuText = "Main menu:\n" +
                "1. Get connections\n" +
                "0. Exit\n";
            while (true)
            {

                Console.WriteLine(menuText);
                int choice = -1;
                try
                {
                    var userInput = Console.ReadLine();
                    choice = Int32.Parse(userInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (choice < 0)
                {
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        foreach (var cli in clientBoxList)
                        {
                            Console.WriteLine(cli.Client.Client.RemoteEndPoint.ToString());
                        }
                        break;
                }
            }

        }
        public static void HandleConnections()
        {
            while (true)
            {
                var client = server.AcceptTcpClient();
                var box = new TcpClientBox(client);
                clientBoxList.Add(box);
                var thread = new Thread(HandleClient);
                thread.Start(box);
            }
        }
        public static void HandleClient(object clientBoxObj)
        {
            var box = (TcpClientBox)clientBoxObj;

            while (true)
            {
                if (!box.Client.Connected)
                {
                    continue;
                }
                try
                {
                    string received = box.Reader.ReadLine();
                    if (received == null)
                    {
                        clientBoxList.Remove(box);
                        break;
                    }
                    if (received.Equals("/connections"))
                    {
                        var msg = "";
                        int i = 0;
                        foreach (var cli in clientBoxList)
                        {
                            msg += cli.Client.Client.RemoteEndPoint.ToString();
                            if (i != clientBoxList.Count - 1)
                            {
                                msg += ";";
                            }
                            i++;
                        }
                        box.Writer.WriteLine("/connections");
                        box.Writer.WriteLine(msg);
                    }
                    else if (received.Equals("/send"))
                    {
                        string acceptor = box.Reader.ReadLine();
                        string text = box.Reader.ReadLine();
                        if (String.IsNullOrEmpty(acceptor) || String.IsNullOrEmpty(text))
                        {
                            box.Writer.WriteLine("No text or acceptor!");
                        }
                        foreach (var b in clientBoxList)
                        {
                            if (b.Client.Client.RemoteEndPoint.ToString().Equals(acceptor))
                            {
                                b.Writer.WriteLine("/receive");
                                b.Writer.WriteLine(box.Client.Client.RemoteEndPoint.ToString());
                                b.Writer.WriteLine(text);
                                b.Writer.Flush();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Получено: " + received);
                        box.Writer.WriteLine(received);

                    }
                    box.Writer.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
        }
    }
}
