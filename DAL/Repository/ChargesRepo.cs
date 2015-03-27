using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repository
{
    public class ChargesRepo
    {
        private readonly Context.ChargesContext contextC = new Context.ChargesContext();
        public IEnumerable<Entity.Charges> Charges
        {
            get { return contextC.Charges; }
        }

        public bool AddCharges(Entity.Charges charges)
        {
            contextC.Charges.Add(charges);
            contextC.SaveChanges();
            return true;
        }

        public bool EditCharges(Entity.Charges charges)
        {
            contextC.Entry(charges).State = System.Data.Entity.EntityState.Modified;
            contextC.SaveChanges();
            return true;
        }

        public bool DeleteCharges(Entity.Charges charges)
        {
            contextC.Charges.Remove(charges);
            contextC.SaveChanges();
            return true;
        }
    }
}
