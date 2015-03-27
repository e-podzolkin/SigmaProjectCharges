using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Charges
    {
        [Key]
        public int ChargesID { get; set; }

        [Required]
        public string PaymentType { get; set; } //тип платежа

        [Required]
        public string AmountOfPayment { get; set; } //Сумма платежа

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string CharactOfPayment { get; set; } //характеристика платежа

        [Required]
        public string LastName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string AddedUser { get; set; }
    }
}
