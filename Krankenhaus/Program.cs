using Krankenhaus.Methods;
using Krankenhaus.PrintMethod;
using Krankenhaus.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krankenhaus
{
    class Program
    {
        static void Main(string[] args)
        {
            EventsManager.eventRegisterPatients += Print.Registerpatients;
            EventsManager.eventSendpatientsToqueue += Print.SendpatientsToqueue;
            EventsManager.eventSendPatientsInIVA += Method.SendPatientToIva;
            EventsManager.eventSendpatientsToSanatorium += Method.SendPatientToSanatorium;
            EventsManager.eventUpdateSymptomLevel += Method.UpdateSymptomLevel;
            Run.DeleteAll();
            
        }
    }
}
