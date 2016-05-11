/* File name: program.cs
 * Description:
 * TCP Server.
 * Show a message if the client was connected succesfully.
 * Date: May 10th, 2016.
 * Version: 1.0.
 * 
 * History:
 * 
 */

using System;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create socket to send data over TCP
            Socket sserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket server port
            const int server_port = 4444;
            //Init a new instance for IPEndPoint class
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, server_port);

            try
            {
                Console.WriteLine("Esperando conexión...");
                //Asociates a Socket object with a local endpoint
                sserver.Bind(ep);
                //Places a Socket object in a listening state
                sserver.Listen(5);
                //Esablishes a connection to a remote host
                sserver.Accept();
                //sserver.Connect(ep);
                Console.WriteLine("Conectado a: " + IPAddress.Parse(((IPEndPoint)sserver.LocalEndPoint).Address.ToString()) + ":" + ((IPEndPoint)sserver.LocalEndPoint).Port.ToString());
            }
            catch
            {
                Console.WriteLine("Error de conexión.");
            }

            Console.ReadKey();
            sserver.Close();
        }
    }
}
