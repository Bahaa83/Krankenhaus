using Krankenhaus.Model;
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
        public Context() : base(@" Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Kranken_Database; Integrated Security = True;")
        {
        }
        public DbSet<Patient> Patients  { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<IVA>  Ivas { get; set; }
        public DbSet<Sanatorium>  Sanatoria { get; set; }
        public DbSet<Tillfrisknade> Tillfrisknades { get; set; }
        public DbSet<Afterlife> Afterlives { get; set; }

    }
}
