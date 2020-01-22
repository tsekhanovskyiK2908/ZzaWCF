using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zza.Services;

namespace Zza.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(ZzaService));
                var principal = Thread.CurrentPrincipal;
                host.Open();
                Console.WriteLine("Host is opened. Press the key to end");
                Console.ReadKey();
                host.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }
    }
}
