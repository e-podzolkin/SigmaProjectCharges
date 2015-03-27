using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace DAL.Initializer
{
    public class ChargesInitializer : DropCreateDatabaseIfModelChanges<Context.ChargesContext>
    {
        protected override void Seed(Context.ChargesContext contextC)
        {
            var charges = new List<Entity.Charges>
            {
                new Entity.Charges {ChargesID = 1, PaymentType= "Коммунальный платеж", AmountOfPayment = "100", Date = new DateTime(2014,10,12), LastName = "Подзолкин"},
            };
            charges.ForEach(s => contextC.Charges.Add(s));
            contextC.SaveChanges();
        }
    }
}
