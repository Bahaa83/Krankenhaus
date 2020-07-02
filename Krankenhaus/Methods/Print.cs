using Krankenhaus.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus.PrintMethod
{
  public static  class Print
    {
        public static Queue queue = new Queue();
        public static void Registerpatients(List<Patient> patients)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vi registrerar alla patienter !");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1500);
            using (StreamWriter st = File.AppendText("Krankenhaus.txt"))
            {
                foreach (var P in patients)
                {
                    Console.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3} Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                    st.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                  
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
        }
       public static void SendpatientsToqueue(List<Patient> patients)
        {
            Console.Clear();
            queue.Patients = new List<Patient>();
            var patientinqueue = patients.OrderByDescending(P => P.Symptomnivå).ThenByDescending(P => P.Age);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Vi placerar alla patienterna i kö enligt Symtomnivå och ålder!");
            Thread.Sleep(1000);
            Console.WriteLine(" Vi jobbar så bäst som vi kan");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.White;
            using (var DB = new Context())
            {
                using (StreamWriter st = File.AppendText("Krankenhaus.txt"))
                {
                    Thread.Sleep(1000);
                    foreach (var P in patientinqueue)
                    {
                        Console.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3} Ålder : {4} placerade i kö", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                        st.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3}  Ålder : {4} placerade i kö", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                        DB.Patients.Add(P);
                        queue.Patients.Add(P);
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                }
                DB.Queues.Add(queue);
                DB.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Alla Patienter har  placerat i kö  !");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
