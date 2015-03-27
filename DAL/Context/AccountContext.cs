using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Context
{
    public class AccountContext : DbContext
    {
        public DbSet<DAL.Entity.Accounts> Account { get; set; }
        public DbSet<DAL.Entity.RolesAccounts> RoleAccount { get; set; }
    }
}
