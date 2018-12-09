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
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                Observable state = (Observable)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, Observable.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.  
                    Observable.OnReceive();

                    // Write the response to the console.  
                    Console.WriteLine("Response received : {0}", response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
    }
}
