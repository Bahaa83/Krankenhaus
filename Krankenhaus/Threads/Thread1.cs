using Krankenhaus.Data;
using RandomPersonalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Krankenhaus.Threads
{
  public  static class Thread1
    {
        public static void GeneratePatients()
        {
            using(var DB = new Context() )
            {
                Queue PatientInqueue = new Queue();
                PatientInqueue.Patients = new List<Patient>();
                Random random = new Random();
                for (int i = 1; i <= 30; i++)
                {
                    Patient newpatient = new Patient()
                    {
                        FirstName = RandomGenerator.RandomFirstName(random),
                        LastName = RandomGenerator.RandomLastName(random),
                        Personnnmmer = RandomGenerator.RandomSSN(random),
                        Symptomnivå = RandomGenerator.Randomsymptomlevel(random)
                    };
                    PatientInqueue.Patients.Add(newpatient);
                    DB.Queues.Add(PatientInqueue);
                }
             
                DB.SaveChanges();
                var patients = PatientInqueue.Patients.ToList();
                Welcome(patients);

            }
           
        }
        static void Welcome(List<Patient> patients)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Vi placerar alla patienterna i kö !");
            Thread.Sleep(500);
            Console.WriteLine(" Vi jobbar så bäst som vi kan");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            foreach (var P in patients)
            {
                Console.WriteLine(P.FirstName + " " + P.LastName + "  " + P.Personnnmmer + " " + P.Symptomnivå);
                Thread.Sleep(500);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Alla Patienter har  placerat i kö  !");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
