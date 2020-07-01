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
  public static  class SendMethod
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
                            ST.WriteLine("Flyttade patient Namn: {0}  {1} till IVA från Kön  Symptomnivå : {2} personnummer : {3}  Ålder : {4}", P.FirstName, P.LastName, P.Symptomnivå, P.Personnnmmer, P.Age);

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
    }
}
