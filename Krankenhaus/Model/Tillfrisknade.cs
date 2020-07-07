using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus.Model
{
   public class Tillfrisknade
    {
        [Key]
        public int ID { get; set; }
        public virtual List<Patient> Patients { get; set; }
        public Tillfrisknade()
        {
            Patients = new List<Patient>();
        }
    }
}
