using Krankenhaus.Data;
using Krankenhaus.Methods;
using Krankenhaus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus.Threads
{
    public static class ThreadsManager
    {
        static Afterlife afterlife = new Afterlife();
        static Tillfrisknade tillfrisknade = new Tillfrisknade();
        static int Checkouthospital = 0;


        public static void RandomGeneratorPatients()
        {
            Thread1.GeneratePatients();
        }
        public static void SendPatientsToTheSections()
        {

            while (Checkouthospital < 30)
            {
                lock ("")
                {
               
                    Thread2.SendpatientsToIvaAndSanatorium();
                }
            }
            Thread.Sleep(2000);
        }
        public static void UpdatesThePatientsSymptomLevel()
        {
            while (Checkouthospital < 30)
            {


                lock (" ")
                {
                   

                    Thread3.UpdatesThePatientsCondition();
                }
            }
            Thread.Sleep(2000);

        }
        public static void SendDismissedPatientsToAfterlifeorRecovery()
        {
            while (Checkouthospital < 30)
            {

                lock ("")
                {
                 

                    SendPatientsToAfterlifeAndRecovery();
                }
            }
            Thread.Sleep(2000);

        }

        public static void SendPatientsToAfterlifeAndRecovery()
        {
          
            tillfrisknade.Patients = new List<Patient>();
            afterlife.Patients = new List<Patient>();
         
                    using (var DB = new Context())
                    {


                            var patientsinIVA = DB.Ivas.FirstOrDefault(P => P.Patients.Count > 0);
                            if (patientsinIVA != null &&   patientsinIVA.Patients.Count > 0)
                            {
                                DB.Entry(patientsinIVA).Collection(x => x.Patients).Load();
                                foreach (var P in patientsinIVA.Patients.ToList())
                                {
                                    if (P.Symptomnivå <= 0)
                                    {
                                        tillfrisknade.Patients.Add(P);
                                        DB.Tillfrisknades.Add(tillfrisknade);
                                        EventsManager.OnDismissedPatients(5, P);
                                        patientsinIVA.Patients.Remove(P);
                            Checkouthospital += 1;
                                    }
                                    if (P.Symptomnivå >= 10)
                                    {
                                        afterlife.Patients.Add(P);
                                        DB.Afterlives.Add(afterlife);
                                        EventsManager.OnDismissedPatients(6, P);
                                        patientsinIVA.Patients.Remove(P);
                            Checkouthospital += 1;
                                    }
                                }
                            }
                            var patientInqueue = DB.Queues.SingleOrDefault(P => P.Patients.Count > 0);
                            if (patientInqueue!= null && patientInqueue.Patients.Count > 0)
                            {
                                DB.Entry(patientInqueue).Collection(x => x.Patients).Load();
                                foreach (var P in patientInqueue.Patients.ToList())
                                {
                                    if (P.Symptomnivå <= 0)
                                    {
                                        tillfrisknade.Patients.Add(P);
                                        DB.Tillfrisknades.Add(tillfrisknade);
                                        EventsManager.OnDismissedPatients(5, P);
                                        patientInqueue.Patients.Remove(P);
                            Checkouthospital += 1;
                                    }
                                    if (P.Symptomnivå >= 10)
                                    {
                                        afterlife.Patients.Add(P);
                                        DB.Afterlives.Add(afterlife);
                                        EventsManager.OnDismissedPatients(6, P);
                                        patientInqueue.Patients.Remove(P);
                            Checkouthospital += 1;
                                         
                                    }
                                }
                            }
                            var patientInSanatorium = DB.Sanatoria.SingleOrDefault(P => P.Patients.Count > 0);
                            if (patientInSanatorium!=null &&  patientInSanatorium.Patients.Count > 0)
                            {
                                DB.Entry(patientInSanatorium).Collection(x => x.Patients).Load();
                                foreach (var P in patientInSanatorium.Patients.ToList())
                                {
                                    if (P.Symptomnivå <= 0)
                                    {
                                        tillfrisknade.Patients.Add(P);
                                        DB.Tillfrisknades.Add(tillfrisknade);
                                        EventsManager.OnDismissedPatients(5, P);
                                        patientInSanatorium.Patients.Remove(P);
                            Checkouthospital += 1;
                                    }
                                    if (P.Symptomnivå >= 10)
                                    {
                                        afterlife.Patients.Add(P);
                                        DB.Afterlives.Add(afterlife);
                                        EventsManager.OnDismissedPatients(6, P);
                                        patientInSanatorium.Patients.Remove(P);
                            Checkouthospital += 1;
                                    }
                                }
                            }
                        
                        DB.SaveChanges();
                    }
           

        }
               
    }
 }  


