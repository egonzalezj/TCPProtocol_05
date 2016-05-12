/* File name: program.cs
 * Description:
 * TCP Client.
 * Show a message if the client was connected succesfully.
 * Date: May 10th, 2016.
 * Version: 1.0.
 * 
 * History:
 * v1.0     10/05/2016  Sockets connection.
 * v1.1     11/05/2016  SocketException added.
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
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket client port
            const int port = 4444;
            //IP address
            IPAddress ip = new IPAddress(new byte[] { 10, 6, 2, 7 });
            //Init a new instance for IPEndPoint class
            IPEndPoint ep = new IPEndPoint(ip, port);

            try
            {
                client.Connect(ep);
                Console.WriteLine("Conectado.");
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.ReadKey();
            client.Close();
        }
    }
}
