using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helpers
{
    public class RolesHelper
    {
        public bool RoleAdmin(string login)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            List<DAL.Entity.Accounts> role = repo.Account.Where(b => b.Login == login && b.RolesAccount.RolesName == "Admin").ToList();
            if (role.Count() > 0)
                return true;
            else
                return false;
        }

        public DAL.Entity.RolesAccounts RoleUser()
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            DAL.Entity.RolesAccounts roleuser = repo.RoleAccount.Where(u => u.RolesID == 2).FirstOrDefault();
            return new DAL.Entity.RolesAccounts(roleuser.RolesID, roleuser.RolesName);
        }
    }
}
