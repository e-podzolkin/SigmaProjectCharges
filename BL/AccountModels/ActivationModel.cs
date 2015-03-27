using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class ActivationModel
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public bool Activation { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ActivationModel()
        {
            this.UserID = UserID;
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

        public ActivationModel(int UserID, string LastName, string FirstName, string MiddleName, string Mail, string PhoneNumber, string Comment, string Login, string Password, bool Activation)
        {
            this.UserID = UserID;
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
