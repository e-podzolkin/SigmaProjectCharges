using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class ForgotPasswordModel
    {
        [LocalizedDisplayName("Mail", NameResourceType = typeof(ResAccount.Account))]
        public string Mail { get; set; }

        [LocalizedDisplayName("Login", NameResourceType = typeof(ResAccount.Account))]
        public string Login { get; set; }

        [LocalizedDisplayName("Password", NameResourceType = typeof(ResAccount.Account))]
        public string Password { get; set; }

        public ForgotPasswordModel(string Mail, string Login, string Password)
        {
            this.Login = Login;
            this.Mail = Mail;
            this.Password = Password;
        }
        public ForgotPasswordModel()
        {
            this.Login = Login;
            this.Mail = Mail;
            this.Password = Password;
        }
    }
}
