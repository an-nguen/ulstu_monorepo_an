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
            var rnd = new Random();
            var msg = "";
            for (uint i = 0; i < 5; i++)
            {
                msg += rnd.Next() + ";";
            }
            var writer = new StreamWriter(client.GetStream());
            writer.WriteLine(msg);
            writer.Close();
            client.Close();
        }
    }
}
