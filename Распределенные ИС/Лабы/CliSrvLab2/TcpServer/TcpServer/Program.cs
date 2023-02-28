using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpServer
{
    class Program
    {
        private static TcpListener server;
        private static List<TcpClient> connections = new List<TcpClient>();
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
                }
            }

        }
        public static void HandleConnections()
        {
            while (true)
            {
                var client = server.AcceptTcpClient();
                connections.Add(client);
                var thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }
        public static void HandleClient(object clientObj)
        {
            var client = (TcpClient)clientObj;
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);

            while (true)
            {
                if (!client.Connected)
                {
                    continue;
                }
                try
                {
                    string received = reader.ReadLine();

                    if (received.Equals("/connections"))
                    {
                        var msg = "";
                        foreach (var cli in connections)
                        {
                            msg += cli.Client.RemoteEndPoint.ToString() + "\n";
                        }
                        writer.WriteLine(msg);
                    }
                    else
                    {
                        Console.WriteLine("Получено: " + received);
                        writer.WriteLine(received);

                    }
                    writer.Flush();
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                    return;
                }
            }
        }
    }
}
