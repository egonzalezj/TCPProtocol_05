/* File name: program.cs
 * Description:
 * TCP Server.
 * Show a message if the client was connected succesfully.
 * Date: May 10th, 2016.
 * Version: 1.0.
 * 
 * History:
 * v1.0 10/05/2016  Sockets connection.
 * v1.1 11/05/2016  Socket objects deleted,TCPListener used instead.
 */

using System;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{
    class Program
    {
        static void Main()
        {
            TcpListener server = null;
            try
            {
                //Set the TCPListener on port 4444
                const int port = 4444;
                IPAddress ip = new IPAddress(new byte[] { 10, 6, 2, 7 });
                server = new TcpListener(ip, port);
                //Start listening for client requests
                server.Start();
                //int numberOfConnection = 0;
                //Listening loop
                while (true)
                {
                    Console.WriteLine("Esperando conexión...");
                    Socket socket = server.AcceptSocket();
                    //++numberOfConnection;
                    IPAddress clientIP = IPAddress.Parse(((IPEndPoint)socket.RemoteEndPoint).Address.ToString());
                    string clientPort = ((IPEndPoint)socket.RemoteEndPoint).Port.ToString();
                    Console.WriteLine(clientIP + ":" + clientPort + " conectado!");
                    socket.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                
            }
            finally
            {
                //Stop listening for new clients
                server.Stop();
            }

            Console.ReadKey();
        }
    }
}
