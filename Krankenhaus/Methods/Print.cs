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
            lock ("")
            {


                using (StreamWriter st = File.AppendText("Krankenhaus.txt"))
                {
                    foreach (var P in patients)
                    {
                        Console.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3} Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                        st.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);

                        Thread.Sleep(100);

                    }
                }
            }
        }
       public static void printpatientsToqueue(List<Patient> patients)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Vi placerar alla patienterna i kö enligt Symtomnivå och ålder!");
            Thread.Sleep(1000);
            Console.WriteLine(" Vi jobbar så bäst som vi kan");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            using (var DB = new Context())
            {
                lock ("")
                {
                    using (StreamWriter st = File.AppendText("Krankenhaus.txt"))
                    {
                        foreach (var P in patients.ToList())
                        {
                            Console.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3} Ålder : {4} placerade i kö", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                            st.WriteLine(" patient Namn: {0}  {1}  Symptomnivå : {2} personnummer : {3}  Ålder : {4} placerade i kö", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);

                            Thread.Sleep(100);

                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Alla Patienter har  placerat i kö  !");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void SendPatientToIva(Patient patient)
        {
            lock ("")
            {
                using (StreamWriter ST = File.AppendText("Krankenhaus.txt"))
                {

                    Console.WriteLine("Flyttade patient Namn: {0}  {1} till IVA från Kön  Symptomnivå : {2} personnummer : {3} Ålder : {4}", patient.FirstName, patient.LastName, patient.Symptomnivå, patient.Personnnmmer, patient.Age);
                    ST.WriteLine("Flyttade patient Namn: {0}  {1} till IVA från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", patient.FirstName, patient.LastName, patient.Symptomnivå, patient.Personnnmmer, patient.Age);
                    Thread.Sleep(100);
                }
            }

        }
        public static void SendPatientToSanatorium(Patient patient)
        {
            lock ("")
            {
                using (StreamWriter ST = File.AppendText("Krankenhaus.txt"))
                {
                    Console.WriteLine("Flyttade patient Namn: {0}  {1} till Sanatorium från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", patient.FirstName, patient.LastName, patient.Symptomnivå, patient.Personnnmmer, patient.Age);
                    ST.WriteLine("Flyttade patient Namn: {0}  {1} till Sanatorium från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", patient.FirstName, patient.LastName, patient.Symptomnivå, patient.Personnnmmer, patient.Age);
                    Thread.Sleep(100);
                }
            }
        }
        public static void UpdateSymptomLevel(int Point, Patient patient)
        {
            lock ("")
            {
                using (StreamWriter ST = File.AppendText("Krankenhaus.txt"))
                {
                    if (Point == -1)
                    {
                        Console.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har sänks med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                        ST.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har sänks med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);

                    }
                    if (Point == 1)
                    {
                        Console.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                        ST.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);

                    }
                    if (Point == 3)
                    {
                        Console.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                        ST.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                    }
                    if (Point == -3)
                    {
                        Console.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har sänks med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                        ST.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har sänks med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                    }
                    if (Point == 2)
                    {
                        Console.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);
                        ST.WriteLine("Patienten : {0} {1}  Personnummer : {2} Symptomnivå har höjs med {3} ", patient.FirstName, patient.LastName, patient.Personnnmmer, Point);

                    }

                }
            }
        }
        public static void DismissedPatients(int numoftable, Patient patient)
        {
            lock ("")
            {
                using (StreamWriter St = File.AppendText("Krankenhaus.txt"))
                {
                    if (numoftable == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Patienten : {0} {1} peronnummer : {2} gick frisk hem", patient.FirstName, patient.LastName, patient.Personnnmmer);
                        St.WriteLine("Patienten : {0} {1} peronnummer : {2} gick frisk hem", patient.FirstName, patient.LastName, patient.Personnnmmer);

                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (numoftable == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Patienten : {0} {1} peronnummer : {2} gick till afterlife", patient.FirstName, patient.LastName, patient.Personnnmmer);
                        St.WriteLine("Patienten : {0} {1} peronnummer : {2}gick till afterlife", patient.FirstName, patient.LastName, patient.Personnnmmer);

                        Console.ForegroundColor = ConsoleColor.White;

                    }

                }
            }
        }
        
    }
}
