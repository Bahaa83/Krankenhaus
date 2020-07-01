using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus
{
   public class Queue
    {
        [Key]
        public int ID { get; set; }
        
        public virtual List<Patient> Patients { get; set; }
    }
}
