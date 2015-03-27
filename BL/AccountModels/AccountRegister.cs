using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace BL.AccountModels
{
    public class AccountRegister
    {
        [LocalizedDisplayName("LastName", NameResourceType = typeof(ResAccount.Account))]
        public string LastName { get; set; }

        [LocalizedDisplayName("FirstName", NameResourceType = typeof(ResAccount.Account))]
        public string FirstName { get; set; }

        [LocalizedDisplayName("MiddleName", NameResourceType = typeof(ResAccount.Account))]
        public string MiddleName { get; set; }

        [LocalizedDisplayName("Mail", NameResourceType = typeof(ResAccount.Account))]
        public string Mail { get; set; }

        [LocalizedDisplayName("PhoneNumber", NameResourceType = typeof(ResAccount.Account))]
        public string PhoneNumber { get; set; }

        [LocalizedDisplayName("Comment", NameResourceType = typeof(ResAccount.Account))]
        public string Comment { get; set; }

        [LocalizedDisplayName("Activation", NameResourceType = typeof(ResAccount.Account))]
        public bool Activation { get; set; }

        //[Remote("CheckUserName", "Account")]
        [LocalizedDisplayName("Login", NameResourceType = typeof(ResAccount.Account))]
        public string Login { get; set; }

        [LocalizedDisplayName("Password", NameResourceType = typeof(ResAccount.Account))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resx.Charges),
    ErrorMessageResourceName = "Required")]
        public string ConfirmPassword { get; set; }

        public AccountRegister()
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.Mail = Mail;
            this.PhoneNumber = PhoneNumber;
            this.Comment = Comment;
            this.Activation = Activation;
            this.Login = Login;
            this.Password = Password;
        }

        public AccountRegister(string LastName, string FirstName, string MiddleName, string Mail, string PhoneNumber, string Comment, string Login, string Password, bool Activation)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.Mail = Mail;
            this.PhoneNumber = PhoneNumber;
            this.Comment = Comment;
            this.Activation = Activation;
            this.Login = Login;
            this.Password = Password;
        }
    }
}
