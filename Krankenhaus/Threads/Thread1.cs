using Krankenhaus.Data;
using Krankenhaus.Methods;
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
       
        public static void GeneratePatients()
        {
            lock ("")
            {
                using (var DB = new Context())
                {
                    Random random = new Random();
                    var patients = new List<Patient>();
                    for (int i = 1; i <= 30; i++)
                    {

                        Patient newpatient = new Patient();

                        newpatient.FirstName = RandomGenerator.RandomFirstName(random);
                        newpatient.LastName = RandomGenerator.RandomLastName(random);
                        newpatient.Personnnmmer = RandomGenerator.RandomSSN(random);
                        newpatient.Symptomnivå = RandomGenerator.Randomsymptomlevel(random);
                        newpatient.Age = RandomGenerator.GetAge(newpatient.Personnnmmer);
                        Thread.Sleep(500);
                        patients.Add( newpatient);
                       
                    }
                    EventsManager.OnRegisterPatients(patients);
                    EventsManager.OnSendpatientsinqueue(patients);
                   

                }
            }

           
        }
       
    }
}
