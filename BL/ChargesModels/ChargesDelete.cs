using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ChargesModels
{
    public class ChargesDelete
    {
        public int ChargesID { get; set; }

        [LocalizedDisplayName("PaymentType", NameResourceType = typeof(Resx.Charges))]
        public string PaymentType { get; set; }

        [LocalizedDisplayName("AmountOfPayment", NameResourceType = typeof(Resx.Charges))]
        public string AmountOfPayment { get; set; }

        [LocalizedDisplayName("Date", NameResourceType = typeof(Resx.Charges))]
        public DateTime Date { get; set; }

        [LocalizedDisplayName("CharactOfPayment", NameResourceType = typeof(Resx.Charges))]
        public string CharactOfPayment { get; set; }

        [LocalizedDisplayName("LastName", NameResourceType = typeof(Resx.Charges))]
        public string LastName { get; set; }

        [LocalizedDisplayName("FirstName", NameResourceType = typeof(Resx.Charges))]
        public string FirstName { get; set; }

        [LocalizedDisplayName("MiddleName", NameResourceType = typeof(Resx.Charges))]
        public string MiddleName { get; set; }

        public ChargesDelete(int ChargesID, string PaymentType, string AmountOfPayment, DateTime Date, string CharactOfPayment, string LastName, string FirstName, string MiddleName)
        {
            this.ChargesID = ChargesID;
            this.PaymentType = PaymentType;
            this.AmountOfPayment = AmountOfPayment;
            this.Date = Date;
            this.CharactOfPayment = CharactOfPayment;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
        }
    }
}