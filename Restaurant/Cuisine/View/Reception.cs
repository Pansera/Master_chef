using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Restaurant.View;
using Restaurant.Controler;

namespace Restaurant
{
    class Reception
    {
          
        private static String response = String.Empty;
        private Socket client;
        private String data;
        private AbstractControler controler;
              
        public Reception(Socket client, AbstractControler controler)
        {
            this.controler = controler;
            Observer.ResetReceive();
            Console.WriteLine("Reciving");
            this.client = client;
            Thread newThread = new Thread(new ThreadStart(this.Receive));
            newThread.Start();
        }

        public void Receive()
        {
            try
            {
                // Crée l'objet socket 
                StateObject state = new StateObject();
                state.workSocket = client;
                // Commencer de recevoir  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public void ReadCallback(IAsyncResult ar)
        {            
            //Récupère la socket 
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

              
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                //Regarde si le . de fin de string est présent
                response = state.sb.ToString();
                if (response.IndexOf(".") > -1)
                {
                    //Tout est lue, l'afficher 
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", response.Length, response);

                    //Envoyer la commande au controler 
                    controler.addCommande(response);
                    Observer.OnReceive();                   
                }
                else
                {
                    // Tout n'est pas lue 
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }           
        }               
    }
}
