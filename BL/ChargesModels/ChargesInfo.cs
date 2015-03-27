using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ChargesModels
{
    public class ChargesInfo
    {
        public int ChargesID;
        public string PaymentType;
        public string AmountOfPayment;
        public DateTime Date;
        public string CharactOfPayment;
        public string LFMName;
        public string Search;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SearchDate;

        public ChargesInfo(int ChargesID, string PaymentType, string AmountOfPayment, DateTime Date, string CharactOfPayment, string LastName, string FirstName, string MiddleName)
        {
            this.ChargesID = ChargesID;
            this.PaymentType = PaymentType;
            this.AmountOfPayment = AmountOfPayment;
            this.Date = Date;
            this.CharactOfPayment = CharactOfPayment;
            this.LFMName = LastName + " " + FirstName + " " + MiddleName;
        }
    }
}
