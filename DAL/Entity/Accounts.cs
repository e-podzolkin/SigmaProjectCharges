using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Accounts
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string MiddleName { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Mail { get; set; }

        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public bool Activation { get; set; }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; }

        [MinLength(6)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public virtual RolesAccounts RolesAccount { get; set; }
    }
}
