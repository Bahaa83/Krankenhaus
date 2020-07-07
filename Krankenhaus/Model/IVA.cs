using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus.Model
{
  public  class IVA
    {
        [Key]
        public int ID { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public IVA()
        {
            Patients = new List<Patient>();
        }
    }
}
