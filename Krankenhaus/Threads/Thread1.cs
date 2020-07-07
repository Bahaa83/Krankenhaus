using Krankenhaus.Data;
using Krankenhaus.Methods;
using Krankenhaus.Model;
using Krankenhaus.PrintMethod;
using RandomPersonalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Krankenhaus.Threads
{
  public static class Thread1
    {

        public static Queue queue = new Queue();
        public static IVA iva = new IVA();
        public static Sanatorium sanatorium = new Sanatorium();
        public static Afterlife afterlife = new Afterlife();
        public static Tillfrisknade tillfrisknade = new Tillfrisknade();

        public static void GeneratePatients()
        {
            
                using (var DB = new Context())
                {
                    Random random = new Random();
                    var patients = new List<Patient>();
                    for (int i = 1; i <= 30; i++)
                    {
                        Thread.Sleep(500);//för att undvika duplicera.
                        Patient newpatient = new Patient();
                        newpatient.FirstName = RandomGenerator.RandomFirstName(random);
                        newpatient.LastName = RandomGenerator.RandomLastName(random);
                        newpatient.Personnnmmer = RandomGenerator.RandomSSN(random);
                        newpatient.Symptomnivå = RandomGenerator.Randomsymptomlevel(random);
                        newpatient.Age = RandomGenerator.GetAge(newpatient.Personnnmmer);
                        patients.Add( newpatient);
                    }
                    EventsManager.OnRegisterPatients(patients);
                      SendpatientsToqueue(patients);
                }
        }
        public static void SendpatientsToqueue(List<Patient> patients)
        {
            queue.Patients = new List<Patient>();
            iva.Patients = new List<Patient>();
            sanatorium.Patients = new List<Patient>();
            tillfrisknade.Patients = new List<Patient>();
            afterlife.Patients = new List<Patient>();
            var patientinqueue = patients.OrderByDescending(P => P.Symptomnivå).ThenBy(P => P.Age);
         
            using (var DB = new Context())
            {
                    foreach (var P in patientinqueue.ToList())
                    {
                        DB.Patients.Add(P);
                        queue.Patients.Add(P);
                    }
                DB.Queues.Add(queue);
                DB.Sanatoria.Add(sanatorium);
                DB.Ivas.Add(iva);
                DB.Afterlives.Add(afterlife);
                DB.Tillfrisknades.Add(tillfrisknade);
                DB.SaveChanges();
            }
            EventsManager.OnSendpatientsinqueue(queue.Patients);
        }

    }
}
