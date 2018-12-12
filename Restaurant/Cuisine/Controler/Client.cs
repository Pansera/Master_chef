using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Cuisine.Observer;

namespace Cuisine.Controler
{

    class Client : Observable
    {
        private const int port = 11000;
        public static Thread t1, t2;

        public static Socket client = null;

        public Client()
        {
            Thread newThread = new Thread(new ThreadStart(StartClient));
            newThread.Start();
        }


        public void StartClient()
        {
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the   
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);


                // Create a TCP/IP socket.  
                client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);


                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                Observable.WaitConnect();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                Observable.OnConnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Send(string data)
        {
            Observable.WaitConnect();
            // Send test data to the remote device.  
            t1 = new Thread(() => new EnvoiePlat(client, data));
            t1.Start();
            Observable.WaitSend();

        }

        public void Receive()
        {
            Observer.Observable.WaitConnect();
            Observable.ResetReceive();
            // Receive the response from the remote device. 
            t2 = new Thread(() => new ReceptionCommande(client));
            t2.Start();
            Observable.WaitReceive();
        }




    }
}
