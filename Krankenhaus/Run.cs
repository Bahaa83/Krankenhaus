using Krankenhaus.Data;
using Krankenhaus.Threads;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("Dont worry ... vi kommer strax  ;)");
            using(var DB= new Context())
            {
                var patients = DB.Patients.ToList();
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread Tråd1 = new Thread(ThreadsManager.RandomGeneratorPatients);
            Thread Tråd2 = new Thread(ThreadsManager.SendPatientsToTheSections);
            Thread Tråd3 = new Thread(ThreadsManager.UpdatesThePatientsSymptomLevel);
            Thread Tråd4 = new Thread(ThreadsManager.SendDismissedPatientsToAfterlifeorRecovery);
            Tråd1.Start();
            Tråd1.Join();
            Thread.Sleep(5000);
            Tråd2.Start();
            Thread.Sleep(3000);
            Tråd3.Start();
            Thread.Sleep(5000);
            Tråd4.Start();
            Tråd4.Join();
            stopwatch.Stop();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Simulering Klar.");
            Console.WriteLine("Tid för simulering : {0} Millisekunder", stopwatch.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

    }
}
