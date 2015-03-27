using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class AccountProfile
    {
        [LocalizedDisplayName("UserID", NameResourceType = typeof(ResAccount.Account))]
        public int UserID { get; set; }

        [LocalizedDisplayName("LFMName", NameResourceType = typeof(ResAccount.Account))]
        public string LFMName { get; set; }

        [LocalizedDisplayName("Mail", NameResourceType = typeof(ResAccount.Account))]
        public string Mail { get; set; }

        [LocalizedDisplayName("PhoneNumber", NameResourceType = typeof(ResAccount.Account))]
        public string PhoneNumber { get; set; }

        [LocalizedDisplayName("Comment", NameResourceType = typeof(ResAccount.Account))]
        public string Comment { get; set; }

        [LocalizedDisplayName("RolesAccount", NameResourceType = typeof(ResAccount.Account))]
        public string RolesAccount { get; set; }
        public AccountProfile(int UserID, string LastName, string FirstName, string MiddleName, string Mail, string PhoneNumber, string Comment, string RolesName)
        {
            this.UserID = UserID;
            this.LFMName = LastName + " " + FirstName + " " + MiddleName;
            this.PhoneNumber = PhoneNumber;
            this.Comment = Comment;
            this.RolesAccount = RolesName;
        }
    }
}
