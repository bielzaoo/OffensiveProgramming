using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace C2Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 7070); // criando um listener

            server.Start(); // iniciando o listener

            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); // aceita a conexão do cliente

                NetworkStream stream = client.GetStream(); // inicia um stream para troca de dados

                byte[] banner = new byte[100];

                banner = Encoding.Default.GetBytes("[+] C2 Server in action...\n");

                stream.Write(banner, 0, banner.Length); // Escreve a mensagem acima, como um banner

                while (client.Connected)
                {
                    byte[] res = new byte[1024];
                    Encoding encASCII = Encoding.ASCII;
                    stream.Read(res, 0, res.Length); // usa o stream para receber dados do cliente
                    Console.WriteLine(encASCII.GetString(res)); // imprime o que o cliente enviou.
                }
            }
        }
    }
}
