﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus.Methods
{
    public static class EventsManager
    {
        public delegate void RegisterPatients(List<Patient> patients);
        public delegate void SendpatientsToqueue(List<Patient> patients);
        public delegate void SendPatientsInIVA(Patient patient);
        public delegate void SendpatientsToSanatorium(Patient patient);
        public delegate void UpdateSymptomLevel(int Point, Patient patient);
        public delegate void DismissedPatients(int numoftable, Patient patient);

        public static event RegisterPatients eventRegisterPatients;
        public static event SendpatientsToqueue eventSendpatientsToqueue;
        public static event SendPatientsInIVA eventSendPatientsInIVA;
        public static event SendpatientsToSanatorium eventSendpatientsToSanatorium;
        public static event UpdateSymptomLevel eventUpdateSymptomLevel;
        public static event DismissedPatients eventDismissedPatients;
        public static void OnRegisterPatients(List<Patient> patients)
        {
            if (patients != null)
              eventRegisterPatients.Invoke(patients);

        }
        public static void OnSendpatientsinqueue(List<Patient> patients)
        {
            if (patients != null)
                eventSendpatientsToqueue.Invoke(patients);
        }
        public static void OnSendPatientsInIVA (Patient patient)
        {
            if (patient != null)
                eventSendPatientsInIVA.Invoke(patient);

        }
        public static void OnSendpatientsToSanatorium(Patient patient)
        {
            if (patient != null)
                eventSendpatientsToSanatorium.Invoke(patient);

        }
        public static void OnUpdateSymptomLevel(int Point,Patient patient)
        {
            if (patient != null)
                eventUpdateSymptomLevel.Invoke( Point, patient);

        }
        public static void OnDismissedPatients(int numoftable,Patient patient)
        {
            if (patient != null)
                eventDismissedPatients.Invoke(numoftable, patient);
        }
    }
}
