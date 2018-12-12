using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuisine.Observer
{
    class Observable 
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();

        
        private List<IObservateur> m_observateurs;

        public Observable()
        {
            m_observateurs = new List<IObservateur>();
        }

        public void notifierObservateurs()
        {
            foreach (IObservateur observateur in m_observateurs)
            {
                observateur.Notifier();
            }
        }

        public void addObservateur(IObservateur observateur)
        {
            m_observateurs.Add(observateur);
        }

        public void delObservateur(IObservateur observateur)
        {
            m_observateurs.Remove(observateur);
        }



        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

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

        public static void OnConnect()
        {
            connectDone.Set();
        }

        public static void WaitConnect()
        {
            connectDone.WaitOne();
        }


    }
}
