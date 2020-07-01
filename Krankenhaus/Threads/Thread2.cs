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
  public static  class Thread2
    {
        
        public static void SendpatientsToIvaAndSanatorium()
        {
            
            using (var DB= new Context())
            {

                var sickestpatientsToIva = DB.Patients.Take(5).ToList();

                foreach (var P in sickestpatientsToIva)
                {
                    DB.Patients.Remove(P);
                }

                DB.SaveChanges();
                EventsManager.OnSendPatientsInIVA(sickestpatientsToIva);
              
                
                var sickestpatientsToSanatorium = DB.Patients.Take(10).ToList();

                foreach (var P in sickestpatientsToSanatorium)
                {
                    DB.Patients.Remove(P);
                }

                DB.SaveChanges();
                EventsManager.OnSendpatientsToSanatorium(sickestpatientsToSanatorium);
                //SendMethod.SendPatientToSanatorium(sickestpatientsToSanatorium);
              

               

            }
            
        }
       

    }
}
