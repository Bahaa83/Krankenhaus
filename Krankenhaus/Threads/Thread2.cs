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
    public static class Thread2
    {
       
        

        public static void SendpatientsToIvaAndSanatorium()
        {
            IVA iva = new IVA();
            iva.Patients = new List<Patient>();
            Sanatorium sanatorium = new Sanatorium();
            sanatorium.Patients = new List<Patient>();
           
            using (var DB = new Context())
            {

                Queue patientInqueue = DB.Queues.FirstOrDefault(q => q.Patients.Count > 0);
                IVA patientInIva = DB.Ivas.FirstOrDefault(P => P.Patients.Count > 0);
                Sanatorium patientInSanatorium = DB.Sanatoria.FirstOrDefault(P => P.Patients.Count > 0);

                if (patientInqueue != null && patientInqueue.Patients.Count > 0)
                {
                    DB.Entry(patientInqueue).Collection(p => p.Patients).Load();
                    patientInqueue.Patients = patientInqueue.Patients.OrderByDescending(p => p.Symptomnivå).ThenBy(p => p.Age).ToList();

                }
                if (patientInSanatorium != null && patientInSanatorium.Patients.Count > 0)
                {
                    DB.Entry(patientInSanatorium).Collection(p => p.Patients).Load();
                    patientInSanatorium.Patients = patientInSanatorium.Patients.OrderByDescending(p => p.Symptomnivå).ThenBy(p => p.Age).ToList();
                }
                if (patientInIva != null && patientInqueue != null || patientInIva != null && patientInSanatorium != null)
                {
                    while (patientInIva.Patients.Count < 5 )
                    {
                        //0 för Sanatorium 1 för Iva
                        int numOfTable = Method.FindSickestPatient();
                        Patient patient;

                        if (numOfTable == 0)
                        {
                            patient = patientInSanatorium.Patients.FirstOrDefault();
                            patientInIva.Patients.Add(patient);
                            EventsManager.OnSendPatientsInIVA(patient);

                            patientInSanatorium.Patients.Remove(patient);

                        }
                        else
                        {
                            patient = patientInqueue.Patients.FirstOrDefault();
                            patientInIva.Patients.Add(patient);
                            EventsManager.OnSendPatientsInIVA(patient);
                            patientInqueue.Patients.Remove(patient);

                        }
                    }
                    DB.SaveChanges();
                }
                // för första gången....
                else if (patientInIva == null && patientInqueue != null || patientInIva == null && patientInSanatorium != null)
                {
                    while (iva.Patients.Count < 5 )
                    {
                        //0 för Sanatorium 1 för Iva
                        int numOfTable = Method.FindSickestPatient();
                        Patient patient;

                        if (numOfTable == 0)
                        {
                            patient = patientInSanatorium.Patients.FirstOrDefault();
                            iva.Patients.Add(patient);
                            DB.Ivas.Add(iva);

                            EventsManager.OnSendPatientsInIVA(patient);

                            patientInSanatorium.Patients.Remove(patient);
                        }
                        else
                        {
                            patient = patientInqueue.Patients.FirstOrDefault();
                            iva.Patients.Add(patient);
                            DB.Ivas.Add(iva);

                            EventsManager.OnSendPatientsInIVA(patient);
                            patientInqueue.Patients.Remove(patient);
                        }

                    }
                    DB.SaveChanges();


                }
                if (patientInSanatorium != null && patientInqueue != null)
                {


                    while (patientInSanatorium.Patients.Count < 10 )
                    {
                        var patient = patientInqueue.Patients.FirstOrDefault();
                        patientInSanatorium.Patients.Add(patient);
                        EventsManager.OnSendpatientsToSanatorium(patient);
                        patientInqueue.Patients.Remove(patient);
                    }
                    DB.SaveChanges();

                }
                else if (patientInSanatorium == null && patientInqueue != null)    // för första gången
                {
                    while (sanatorium.Patients.Count < 10 )
                    {
                        var patient = patientInqueue.Patients.FirstOrDefault();
                        sanatorium.Patients.Add(patient);
                        DB.Sanatoria.Add(sanatorium);
                        EventsManager.OnSendpatientsToSanatorium(patient);
                        patientInqueue.Patients.Remove(patient);

                    }
                    DB.SaveChanges();
                }

            }
        }




    }
}