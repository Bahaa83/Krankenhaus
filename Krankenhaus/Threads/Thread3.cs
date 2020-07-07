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
    public static class Thread3
    {


        public static void UpdatesThePatientsCondition()
        {
           
            using (var DB = new Context())
            {
                int point = 0;
                var patientsinqueue = DB.Queues.SingleOrDefault(P=>P.Patients.Count!=0);
                if (patientsinqueue != null)
                {
                    DB.Entry(patientsinqueue).Collection(p => p.Patients).Load();
                    foreach (var patient in patientsinqueue.Patients)
                    {
                        Thread.Sleep(150);
                        point = Method.Levelchanging(1);
                        patient.Symptomnivå += point;

                        EventsManager.OnUpdateSymptomLevel(point, patient);
                    }
                }
               
                var patientinsanatorium = DB.Sanatoria.SingleOrDefault(P => P.Patients.Count != 0);
                if (patientinsanatorium != null)
                {
                    DB.Entry(patientinsanatorium).Collection(P => P.Patients).Load();
                    foreach (var patient in patientinsanatorium.Patients)
                    {
                        Thread.Sleep(150);
                        point = Method.Levelchanging(2);
                        patient.Symptomnivå += point;
                        EventsManager.OnUpdateSymptomLevel(point, patient);
                    }
                }
                
                var patientiniva = DB.Ivas.SingleOrDefault(P => P.Patients.Count != 0);
                if (patientiniva != null)
                {
                    DB.Entry(patientiniva).Collection(P => P.Patients).Load();
                    foreach (var patient in patientiniva.Patients)
                    {
                        Thread.Sleep(150);
                        point = Method.Levelchanging(3);
                        patient.Symptomnivå += point;

                        EventsManager.OnUpdateSymptomLevel(point, patient);

                    }
                }
               
                DB.SaveChanges();
            }
        }
    }
}
    

