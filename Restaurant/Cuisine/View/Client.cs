using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Controler;

namespace Restaurant
{


    class Client 
    {
        private const int port = 11000;
        public static Thread t1, t2;
       
        public static Socket client = null;
        
        
        public Client() 
        {
            //Demarre le client dans un nouveau Thread
            Thread newThread = new Thread(new ThreadStart(StartClient));
            newThread.Start();
        }


        public void StartClient()
        {
            //Ce connect au serveur 
            try
            {          
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);


                // Cree un socket TCP/IP.  
                client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                

                // Connecte au serveur en lançant une tâche asychrone
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                // Attend la connexion
                Observer.WaitConnect();


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
                //Récupère le socket  
                Socket client = (Socket)ar.AsyncState;

                // Complete la connexion.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal la connexion 
                Observer.OnConnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Send(string data)
        {
            Observer.WaitConnect();
            //Envoie les plats
            t1 = new Thread(() => new Emission(client, data));
            t1.Start();
            //Attend l'envoie
            Observer.WaitSend();

        }

        public void Receive(AbstractControler controler)
        {
            Observer.WaitConnect();
            Observer.ResetReceive();
            //Thread de reception des commandes
            t2 = new Thread(() => new Reception(client, controler));
            t2.Start();
            Observer.WaitReceive();
        }

      

    }
}
