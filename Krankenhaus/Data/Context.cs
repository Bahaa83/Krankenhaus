using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krankenhaus.Data
{
   public class Context : DbContext
    {
        public DbSet<Patient> Patients  { get; set; }
        public DbSet<Queue> Queues { get; set; }


    }
}
