using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TcpClient
{
    class TcpClientBox
    {
        public System.Net.Sockets.TcpClient Client { get; }
        public StreamReader Reader { get; }
        public StreamWriter Writer { get; }

        public TcpClientBox(string server, int port)
        {
            Client = new System.Net.Sockets.TcpClient(server, port);
            Reader = new StreamReader(Client.GetStream());
            Writer = new StreamWriter(Client.GetStream());
        }
    }
    class Program
    {
        const string server = "127.0.0.1";
        const int port = 9000;
        static TcpClientBox ClientBox;
        static List<string> Addresses;
        static string ClientIp;

        static void Main(string[] args)
        {
            ClientBox = new TcpClientBox(server, port);
            ClientIp = ClientBox.Client.Client.LocalEndPoint.ToString();
            var menuText = $"Ваш IP: {ClientIp}\nГлавное меню:\n" +
                            "1. Отправить 5 случайно сгенерированных чисел\n" +
                            "2. Написать кому-то...\n" +
                            "0. Выход\n";
            var thread = new Thread(HandleReceived);
            thread.Start();
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
                        ClientBox.Client.Close();
                        Environment.Exit(0);
                        break;
                    case 1:
                        var rnd = new Random();
                        var msg = "";
                        for (uint i = 0; i < 5; i++)
                        {
                            msg += rnd.Next() + ";";
                        }
                        ClientBox.Writer.WriteLine(msg);
                        ClientBox.Writer.Flush();
                        break;
                    case 2:
                        ClientBox.Writer.WriteLine("/connections");
                        ClientBox.Writer.Flush();
                        do
                        {
                            try
                            {
                                var userInput = Console.ReadLine();
                                choice = Int32.Parse(userInput);
                                if (choice > 0 && choice <= Addresses.Count)
                                {
                                    Console.Write($"Write text to {Addresses[choice - 1]}: ");
                                    var text = Console.ReadLine();
                                    ClientBox.Writer.WriteLine("/send");
                                    ClientBox.Writer.WriteLine(Addresses[choice - 1]);
                                    ClientBox.Writer.WriteLine(text);
                                    ClientBox.Writer.Flush();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                        } while (choice < 1 || choice > Addresses.Count);
                        break;
                }
            }


        }

        public static void HandleReceived()
        {
            while (true)
            {
                var receivedMessage = ClientBox.Reader.ReadLine();
                if (receivedMessage.StartsWith("/receive"))
                {
                    var sender = ClientBox.Reader.ReadLine();
                    var text = ClientBox.Reader.ReadLine();
                    if (String.IsNullOrEmpty(sender) || String.IsNullOrEmpty(text))
                    {
                        ClientBox.Writer.WriteLine("Неверные параметры команды /receive");
                    }
                    else
                    {
                        Console.WriteLine("От: " + sender + "\nТекст: " + text + "\n");
                    }
                    ClientBox.Writer.Flush();
                }
                else if (receivedMessage.StartsWith("/connections"))
                {
                    var addressesString = ClientBox.Reader.ReadLine();
                    var addresses = addressesString.Split(";");
                    Addresses = new List<string>(Array.FindAll(addresses, (v) => v != ClientIp));
                    for (int i = 1; i <= Addresses.Count; i++)
                    {
                        Console.WriteLine($"{i}: {Addresses[i - 1]}");
                    }
                    Console.Write(">> ");
                } else
                {
                    Console.Write(receivedMessage);
                }
            }
        }
    }
}
