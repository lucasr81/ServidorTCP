using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Endereço e porta onde o servidor TCP vai escutar
        IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
        int port = 80;

        // Cria o servidor TCP
        TcpListener server = new TcpListener(ipAddress, port);
        server.Start();
        Console.WriteLine("Servidor TCP iniciado... Aguardando conexões...");

        while (true)
        {
            // Aguarda a conexão do rastreador
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Cliente conectado!");

            // Lê os dados enviados pelo rastreador
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string dadosRecebidos = reader.ReadToEnd();
            Console.WriteLine("Dados recebidos: " + dadosRecebidos);

            // Aqui, você pode processar os dados e enviar para a API
            // Por exemplo, enviar para sua API usando HTTP

            // Feche a conexão com o cliente
            client.Close();
        }
    }
}
