using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle
{
    // State object for reading client data asynchronously  
    public class StateObject
    {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();


        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);
        private static ManualResetEvent firstDone =
            new ManualResetEvent(false);



        public static void OnSend()
        {
            sendDone.Set();
        }

        public static void OnReceive()
        {
            receiveDone.Set();
        }

        public static void WaitSend()
        {
            sendDone.WaitOne();
        }

        public static void WaitReceive()
        {
            receiveDone.WaitOne();
        }

        public static void ResetReceive()
        {
            receiveDone.Reset();
        }

        public static void ResetConnect()
        {
            connectDone.Reset();
        }

        public static void OnConnect()
        {
            connectDone.Set();
        }

        public static void WaitConnect()
        {
            connectDone.WaitOne();
        }

        public static void OnFirstCo()
        {
            firstDone.Set();
        }

        public static void WaitFirstCo()
        {
            firstDone.WaitOne();
        }
    }

 

}
