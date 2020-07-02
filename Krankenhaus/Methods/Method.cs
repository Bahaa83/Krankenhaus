using Krankenhaus.Data;
using Krankenhaus.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus.Methods
{
  public static  class Method
    {
        public static IVA iva = new IVA();
        public static Sanatorium sanatorium = new Sanatorium();
        public static void SendPatientToIva(List<Patient> patients)
        {
            lock ("")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Följande patienter överförs till intensivvården");
                Thread.Sleep(1000);
                iva.Patients = new List<Patient>();
                Patient newpatient;
                using (var DB = new Context())
                {
                    using (StreamWriter ST = File.AppendText("Krankenhaus.txt"))
                    {
                        foreach (var P in patients)
                        {
                            Console.WriteLine("Flyttade patient Namn: {0}  {1} till IVA från Kön  Symptomnivå : {2} personnummer : {3} Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                            ST.WriteLine("Flyttade patient Namn: {0}  {1} till IVA från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                            Thread.Sleep(500);
                            newpatient = new Patient() { FirstName = P.FirstName, LastName = P.LastName, Personnnmmer = P.Personnnmmer, Symptomnivå = P.Symptomnivå, Age = P.Age };
                            iva.Patients.Add(newpatient);
                            Console.Clear();
                        }
                    }
                    DB.Ivas.Add(iva);
                    DB.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
        public static void SendPatientToSanatorium(List<Patient> patients)
        {
            lock ("")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Följande patienter överförs till sanatorium");
                Thread.Sleep(500);
                sanatorium.Patients = new List<Patient>();
                Patient newpatient;
                using (var DB = new Context())
                {
                    using (StreamWriter ST = File.AppendText("Krankenhaus.txt"))
                    {
                        foreach (var P in patients)
                        {
                            Console.WriteLine("Flyttade patient Namn: {0}  {1} till Sanatorium från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);
                            ST.WriteLine("Flyttade patient Namn: {0}  {1} till Sanatorium från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);

                            Thread.Sleep(500);
                            newpatient = new Patient() { FirstName = P.FirstName, LastName = P.LastName, Personnnmmer = P.Personnnmmer, Symptomnivå = P.Symptomnivå, Age = P.Age };
                            sanatorium.Patients.Add(newpatient);
                          
                            Console.Clear();
                        }
                     
                    }

                    DB.Sanatoria.Add(sanatorium);
                    DB.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }


        }
        public static int Levelchanging(int table)
        {
            int chance = 0;
            int  levelchanging = 0;
            Random random = new Random();

            if (table == 1)//om de är i queue
            {
                chance = random.Next(1, 100);
                if (chance <= 50)
                {
                    levelchanging = 0;
                }
                if (chance > 50 && chance <= 60)
                {
                    levelchanging =-1;
                }
                if (chance > 60 && chance <= 90)
                {
                    levelchanging = 1;
                }
                if (chance > 90 && chance <= 99)
                {
                    levelchanging = 3;
                }
            }
            if (table == 2)//om de är i Sanatoruim
            {
                chance = random.Next(1, 100);
                if (chance <= 40)
                {
                    levelchanging = 0;
                }
                if (chance >40 && chance <= 60)
                {
                    levelchanging =-1;
                }
                if (chance > 60 && chance <= 70)
                {
                    levelchanging = 1;
                }
                if (chance > 70 && chance <= 75)
                {
                    levelchanging = 3;
                }
            }
            if (table == 3)//om de är i IVA
            {
                chance = random.Next(1, 100);
                if (chance <= 20)
                {
                    levelchanging = 0;
                }
                if (chance > 20 && chance <= 80)
                {
                    levelchanging =-3;
                }
                if (chance > 80 && chance <= 90)
                {
                    levelchanging = 1;
                }
                if (chance > 90 && chance <= 99)
                {
                    levelchanging = +2;
                }
            }

            return levelchanging;
        }
        public static void UpdateSymptomLevel( int Point,Patient patient)
        {
            Thread.Sleep(500);
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
                Thread.Sleep(500);
            }
        }
    }
}
