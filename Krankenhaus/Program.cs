using Krankenhaus.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus
{
    class Program
    {
        static void Main(string[] args)
        {
          Thread Tråd1= new Thread(Thread1.GeneratePatients);
            Tråd1.Start();
            Console.ReadKey();
        }
    }
}
