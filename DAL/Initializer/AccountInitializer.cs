using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace DAL.Initializer
{
    public class AccountInitializer : DropCreateDatabaseIfModelChanges<DAL.Context.AccountContext>
    {
        protected override void Seed(DAL.Context.AccountContext contextAc)
        {
            var account = new List<DAL.Entity.Accounts>
            {
                new DAL.Entity.Accounts {UserID = 1, LastName= "Подзолкин", FirstName= "Евгений", MiddleName= "Николаевич", Mail="zhenj97@mail.ru", PhoneNumber="0938664876", Comment= "test test", Login= "e.podzolkin", Password= "qwerty", Activation= true},
            };
            account.ForEach(s => contextAc.Account.Add(s));
            var roleaccount = new List<DAL.Entity.RolesAccounts>
            {
                new DAL.Entity.RolesAccounts {RolesID= 1, RolesName="Admin"},
                new DAL.Entity.RolesAccounts {RolesID= 2, RolesName="User"},
            };
            roleaccount.ForEach(s => contextAc.RoleAccount.Add(s));
            contextAc.SaveChanges();
        }
    }
}
