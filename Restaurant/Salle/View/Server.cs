using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Salle
{


    class Server
    {
        public static Thread t1, t2;

        public static Socket handler = null;
        public Server()
        {
            Thread newThread = new Thread(new ThreadStart(StartListening));
            newThread.Start();
        }

        public static void StartListening()
        {
            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    StateObject.ResetConnect();

                    // Start an asynchronous socket to listen for connections.  
                    Console.WriteLine("Waiting for a connection...");
                    Thread.Sleep(2000);
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                       listener);

                    // Wait until a connection is made before continuing.  
                    StateObject.WaitConnect();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            StateObject.OnConnect();
            StateObject.OnFirstCo();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            handler = listener.EndAccept(ar);

            // Create the state object.  
           /* StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);*/
        }




        public void Send(string data)
        {
            StateObject.WaitFirstCo();
            StateObject.ResetReceive();
            // Send test data to the remote device.  
            t1 = new Thread(() => new Emmission(handler, data));
            t1.Start();
            StateObject.WaitSend();

        }

        public void Receive()
        {
            StateObject.WaitFirstCo();
            StateObject.ResetReceive();
            // Receive the response from the remote device. 
            t2 = new Thread(() => new Reception(handler));
            t2.Start();
            StateObject.WaitReceive();
        }
    }
}
