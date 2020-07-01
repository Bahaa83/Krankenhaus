using Krankenhaus.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus
{
   public  class Run
    {
        public static void run()
        {
            Thread Tråd1 = new Thread(Thread1.GeneratePatients);
            Tråd1.Start();
            Tråd1.Join();
            Thread Tråd2 = new Thread(Thread2.SendpatientsToIvaAndSanatorium);
            Tråd2.Start();


            Console.ReadKey();
        }
    }
}
