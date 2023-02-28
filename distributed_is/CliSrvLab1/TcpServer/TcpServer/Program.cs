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
            // var thread = new Thread(HandleConnections);
            // thread.Start();
            // var menuText = "Main menu:\n" +
            //     "1. Get connections\n" +
            //     "0. Exit\n";
            while(true)
            {
                var client = server.AcceptTcpClient();  // ожидаем подключение клиента
                var stream = client.GetStream(); // для получения и отправки сообщений
                var reader = new StreamReader(stream);
                string received = reader.ReadLine();
                Console.WriteLine("Получено: " + received);

                var writer = new StreamWriter(stream);
                writer.WriteLine(received);
                writer.Close();
                reader.Close();
                client.Close();
                // Console.WriteLine(menuText);
                // int choice = -1;
                // try
                // {
                //     var userInput = Console.ReadLine();
                //     choice = Int32.Parse(userInput);
                // } catch (Exception e)
                // {
                //     Console.WriteLine(e.Message);
                //     continue;
                // }
                // if (choice < 0)
                // {
                //     continue;
                // }
                // switch (choice)
                // {
                //     case 0:
                //         Environment.Exit(0);
                //         break;
                // }
            }

        }
        // public static void HandleConnections()
        // {
        //     while (true)
        //     {
        //         var client = server.AcceptTcpClient();  // ожидаем подключение клиента
        //         var stream = client.GetStream(); // для получения и отправки сообщений
        //         var reader = new StreamReader(stream);
        //         string received = reader.ReadLine();
        //         Console.WriteLine("Получено: " + received);

        //         var writer = new StreamWriter(stream);
        //         writer.WriteLine(received);
        //         writer.Close();
        //         reader.Close();
        //         client.Close();
        //     }
        // }
    }
}
