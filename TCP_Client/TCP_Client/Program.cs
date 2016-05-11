/* File name: program.cs
 * Description:
 * TCP Client.
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

namespace TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create socket to send data over TCP
            Socket sclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket server port
            const int client_port = 4444;
            //IP address
            IPAddress client_ip = new IPAddress(new byte[] { 10, 6, 2, 7 });
            //Init a new instance for IPEndPoint class
            IPEndPoint ep = new IPEndPoint(client_ip, client_port);

            try
            {
                sclient.Connect(ep);
                Console.WriteLine("Conectado.");
            }
            catch
            {
                Console.WriteLine("Error de conexión.");
            }

            Console.ReadKey();
            sclient.Close();
        }
    }
}
