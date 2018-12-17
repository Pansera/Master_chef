using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Salle
{
    public class Observer
    {
       

        private List<IObservateur> m_observateurs;

        public Observer()
        {
            m_observateurs = new List<IObservateur>();
        }

        public void notifierObservateurs(String str)
        {
            foreach (IObservateur observateur in m_observateurs)
            {
                observateur.Notifier(str);
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
        private static ManualResetEvent connectDone =
                new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
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
