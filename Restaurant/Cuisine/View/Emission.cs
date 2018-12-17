using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Restaurant
{
    class Emission
    {

        // ManualResetEvent instances signal completion.  
        private Socket client;
        private String data;
        public Emission(Socket client, String data)
        {
            Console.WriteLine("Sending...");
            this.data = data;
            this.client = client;
            Thread newThread = new Thread(new ThreadStart(this.Send));
            newThread.Start();
        }

        public void Send()
        {
            //Converti le string
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Envoie les données 
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                //Récupère le socket 
                Socket client = (Socket)ar.AsyncState;

                // Complete l'envoie 
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal l'envoie
                Observer.OnSend();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


    }
}
