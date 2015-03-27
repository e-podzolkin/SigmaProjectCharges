using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class AccountLogin
    {
        public int UserID { get; set; }

        [LocalizedDisplayName("Login", NameResourceType = typeof(ResAccount.Account))]
        public string Login { get; set; }

        [LocalizedDisplayName("Password", NameResourceType = typeof(ResAccount.Account))]
        public string Password { get; set; }
    }
}
