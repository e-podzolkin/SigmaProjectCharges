using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace DAL.Repository
{
    public class AccountRepo
    {
        private readonly DAL.Context.AccountContext contextAc = new DAL.Context.AccountContext();
        public IEnumerable<DAL.Entity.Accounts> Account
        {
            get { return contextAc.Account; }
        }
        public IEnumerable<DAL.Entity.RolesAccounts> RoleAccount
        {
            get { return contextAc.RoleAccount; }
        }

        public bool RegAccount(DAL.Entity.Accounts account)
        {
            DAL.Entity.RolesAccounts role;
            role = account.RolesAccount;
            contextAc.Account.Add(account);
            account.RolesAccount = role;
            contextAc.Entry(account.RolesAccount).State = System.Data.Entity.EntityState.Modified;
            contextAc.SaveChanges();
            return true;
        }

        public bool ActivationAccount(Entity.Accounts account)
        {
            contextAc.Entry(account).State = System.Data.Entity.EntityState.Modified;
            contextAc.SaveChanges();
            return true;
        }
    }
}
