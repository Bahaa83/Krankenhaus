using Krankenhaus.Data;
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
        public static  void DeleteAll()
        {
            using(var DB= new Context())
            {
                var patients = DB.Patients.Take(30).ToList();
                if (patients == null)
                {
                    run();
                }
                else
                {
                    foreach (var P in patients)
                    {
                        DB.Patients.Remove(P);
                    }
                    DB.SaveChanges();
                    run();
                }
               


            }
            
        }
        public static void run()
        {
            Thread Tråd1 = new Thread(Thread1.GeneratePatients);
            Tråd1.Start();
            Tråd1.Join();
            Thread Tråd2 = new Thread(Thread2.SendpatientsToIvaAndSanatorium);
            Tråd2.Start();
            Tråd2.Join();
            Thread Tråd3 = new Thread(Thread3.UpdatesThePatientsCondition);
            Tråd3.Start();

            Console.ReadKey();
        }

    }
}
