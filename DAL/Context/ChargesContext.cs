using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Context
{
    public class ChargesContext : DbContext
    {
        public DbSet<Entity.Charges> Charges { get; set; }
    }
}
