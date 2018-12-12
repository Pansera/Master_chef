using Cuisine.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuisine.Controler
{
    class ReceptionCommande
    {

        // ManualResetEvent instances signal completion.  

        private Socket client;
        private String data;
        // The response from the remote device.  
        private static String response = String.Empty;

        public ReceptionCommande(Socket client)
        {
            Observable.ResetReceive();
            Console.WriteLine("Reciving");
            this.client = client;

            Thread newThread = new Thread(new ThreadStart(this.Receive));
            newThread.Start();
        }



        public void Receive()
        {
            try
            {


                // Create the state object.  
                Observable state = new Observable();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, Observable.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            Observable state = (Observable)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf(".") > -1)
                {
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);

                    // Echo the data back to the client.  
                    Observable.OnReceive();
                    //Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, Observable.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }
    }
}
