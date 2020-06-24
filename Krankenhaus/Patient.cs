using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus
{
   public class Patient
    {
        [Key]
        public int ID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Personnnmmer { get; set; }

        [Range (1,10)]
        public int Symptomnivå { get; set; }
        public virtual Queue queue { get; set; }
    }
}
