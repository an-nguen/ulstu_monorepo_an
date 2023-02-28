using System;
using System.IO;

namespace TcpClient
{
    class Program
    {
        const string server = "127.0.0.1";
        const int port = 9000;

        static void Main(string[] args)
        {
            var client = new System.Net.Sockets.TcpClient(server, port);
            var writer = new StreamWriter(client.GetStream());

            var menuText = "Main menu:\n" +
                            "1. Send message\n" +
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
                        client.Close();
                        Environment.Exit(0);
                        break;
                    case 1:
                        var rnd = new Random();
                        var msg = "";
                        for (uint i = 0; i < 5; i++)
                        {
                            msg += rnd.Next() + ";";
                        }
                        writer.WriteLine(msg);
                        writer.Flush();
                        break;
                }
            }


        }
    }
}
