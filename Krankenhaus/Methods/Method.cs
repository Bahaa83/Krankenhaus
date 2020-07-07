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
      
     
        public static int FindSickestPatient()
        {
            Patient patient1 = null;
            Patient patient2 = null;

            using (var DB = new Context())
            {
                var patientInsanatorium = DB.Sanatoria.FirstOrDefault(S => S.Patients.Count > 0);
                var PatientInqueue = DB.Queues.FirstOrDefault(q => q.Patients.Count > 0);



                if (patientInsanatorium != null && patientInsanatorium.Patients.Count > 0)
                {
                    DB.Entry(patientInsanatorium).Collection(x => x.Patients).Load();
                    patientInsanatorium.Patients = patientInsanatorium.Patients.OrderByDescending(x => x.Symptomnivå).ThenBy(x => x.Age).ToList();
                    patient1 = patientInsanatorium.Patients.First();
                }
                if (PatientInqueue != null && PatientInqueue.Patients.Count > 0)
                {
                    DB.Entry(PatientInqueue).Collection(x => x.Patients).Load();
                    PatientInqueue.Patients = PatientInqueue.Patients.OrderByDescending(x => x.Symptomnivå).ThenBy(x => x.Age).ToList();
                    patient2 = PatientInqueue.Patients.First();
                }

                //Returnerar 0 för sanatorium och 1 för kön.

                if (patient1 != null && patient2 != null)
                {
                    if (patient1.Symptomnivå.CompareTo(patient2.Symptomnivå) == 0)//om de är lika så tar vi den yngre
                    {
                        if (patient1.Age < patient2.Age) return 0;

                        else
                        {
                            return 1;
                        }
                    }

                    return patient1.Symptomnivå > patient2.Symptomnivå ? 0 : 1;

                }
                else if (patient1 != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
