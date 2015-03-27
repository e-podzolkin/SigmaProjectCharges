using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class RolesAccounts
    {
        [Key]
        public int RolesID { get; set; }
        public string RolesName { get; set; }

        public RolesAccounts()
        {
            this.RolesID = RolesID;
            this.RolesName = RolesName;
        }

        public RolesAccounts(int RolesID, string RolesName)
        {
            this.RolesID = RolesID;
            this.RolesName = RolesName;
        }
    }
}
