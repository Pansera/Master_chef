using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Salle.Controller
{
    public class StateObject
    {
        // Socket du client.  
        public Socket workSocket = null;
        // Taille du buffer qui recoit les messages.  
        public const int BufferSize = 1024;
        // Buffer qui recevera les messages.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        // allDone permet de libérer les threads manuellement.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        //Constructeur
        public AsynchronousSocketListener()
        {
        }

        public static void StartListening()
        {
            // IPHostEntry contient les info d'adresse DNS de mon ordi local  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            // Affiche l'IP locale
            string localIP = "";
            foreach (IPAddress ip in ipHostInfo.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                    localIP = ip.ToString();
            }
            Console.WriteLine("Votre adresse IP: " + localIP);

            IPAddress ipAddress = ipHostInfo.AddressList[0];

            //Création d'un nouveau point d'accès avec l'adresse IP local + numéro de port 11000
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Création de socket TCP
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

    
            // Lie le socket listener au point d'accès local et écoute les connection entrante
            try
            {
                listener.Bind(localEndPoint);
                // Socket en état d'écoute
                // 100 représente le nombre maximale de connection en attente
                listener.Listen(100);

                while (true)
                {
                    // le MRE se met en false
                    allDone.Reset();

                    // Début de l'opération asynchrone d'écoute
                    Console.WriteLine("Waiting for a connection...");
                    // AsyncCallback est le délégué qui référence l'opération asynchrone qui se termine
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Thread se bloque jusqu'à qu'il y ai une connection
                    allDone.WaitOne();
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
            // Termine le thread
            allDone.Set();

            // Récupère le Socket qui prend en charge les requêtes clients
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Création de l'objet StateObject
            StateObject state = new StateObject();
            state.workSocket = handler;
            //Réception de données de manière asynchrone par le socket handler
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        // Lecture des données
        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retourne le state object et le socket handler du State Object asynchrone
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Lit les données du socket client
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // Stockage des données recu
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Vérification d'un End Of File
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // Toutes les données ont été lues, ont les affiche
                  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Envoie des données aux clients
                    Send(handler, content);
                }
                else
                {
                    // Dans le cas ou toutes les données n'ont pas été recues 
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Conversion des données en bytedata
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Envoie des données aux clients distants
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                //Retourne le socket du state object
                Socket handler = (Socket)ar.AsyncState;

                // Fini d'envoyer des données aux clients distants
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
