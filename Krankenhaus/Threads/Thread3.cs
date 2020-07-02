using Krankenhaus.Data;
using Krankenhaus.Methods;
using Krankenhaus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                DB.Entry(patientsinqueue).Collection(p => p.Patients).Load();
                foreach (var patient in patientsinqueue.Patients)
                {
                    point = Method.Levelchanging(1);
                    patient.Symptomnivå += point;
                    DB.SaveChanges();

                    EventsManager.OnUpdateSymptomLevel(point, patient);
                }
                var patientinsanatorium = DB.Sanatoria.SingleOrDefault(P => P.Patients.Count != 0);
                DB.Entry(patientinsanatorium).Collection(P => P.Patients).Load();
                foreach (var patient in patientinsanatorium.Patients)
                {
                    point=Method.Levelchanging(2);
                    patient.Symptomnivå += point;
                    DB.SaveChanges();
                    EventsManager.OnUpdateSymptomLevel(point, patient);
                }

                var patientiniva = DB.Ivas.SingleOrDefault(P => P.Patients.Count != 0);
                DB.Entry(patientiniva).Collection(P => P.Patients).Load();
                foreach (var patient in patientiniva.Patients)
                {
                    point = Method.Levelchanging(3);
                    patient.Symptomnivå += point;
                    DB.SaveChanges();
                    EventsManager.OnUpdateSymptomLevel(point, patient);


                }
            }
        }
    }
}
    

