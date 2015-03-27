using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL.Helpers
{
    public class ChargesHelper
    {
        public IEnumerable<ChargesModels.ChargesInfo> GetChargesList(int OrderBy = 0)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            IEnumerable<ChargesModels.ChargesInfo> List = repo.Charges.ToList().Select(w => new ChargesModels.ChargesInfo(w.ChargesID, w.PaymentType, 
                                                                                                                            w.AmountOfPayment, w.Date, w.CharactOfPayment, 
                                                                                                                            w.LastName, w.FirstName, w.MiddleName));

            switch (OrderBy)
            {
                case 1:
                    return List.OrderBy(w => w.LFMName);
                case 2:
                    return List.OrderBy(w => w.PaymentType);
                case 3:
                    return List.OrderBy(w => w.Date);
                default:
                    return List;
            }
        }

        public bool AddCharges(BL.ChargesModels.ChargesCreate charges, string user)
        {
            DAL.Entity.Charges newC = new DAL.Entity.Charges { ChargesID = charges.ChargesID, PaymentType = charges.PaymentType, AmountOfPayment = charges.AmountOfPayment, 
                                                                Date = charges.Date, CharactOfPayment = charges.CharactOfPayment, LastName = charges.LastName, 
                                                                FirstName = charges.FirstName, MiddleName = charges.MiddleName, AddedUser = user };
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            repo.AddCharges(newC);
            return true;
        }

        public BL.ChargesModels.ChargesEdit GetEditList(string user, int id = 1)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            DAL.Entity.Charges charg = repo.Charges.Where(ed => ed.ChargesID == id).First();
            if (charg.AddedUser == user)
            {
                return new BL.ChargesModels.ChargesEdit(charg.ChargesID, charg.PaymentType, charg.AmountOfPayment, charg.Date, charg.CharactOfPayment, charg.LastName, 
                                                        charg.FirstName, charg.MiddleName, charg.AddedUser);
            }
            else
            {
                return null;
            }
        }

        public BL.ChargesModels.ChargesEdit GetEditAdminList(int id = 1)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            DAL.Entity.Charges charg = repo.Charges.Where(ed => ed.ChargesID == id).First();
            return new BL.ChargesModels.ChargesEdit(charg.ChargesID, charg.PaymentType, charg.AmountOfPayment, charg.Date, charg.CharactOfPayment, charg.LastName,
                                                    charg.FirstName, charg.MiddleName, charg.AddedUser);
        }

        public bool EditCharges(BL.ChargesModels.ChargesEdit charges)
        {
            DAL.Entity.Charges editC = new DAL.Entity.Charges { ChargesID = charges.ChargesID, PaymentType = charges.PaymentType, AmountOfPayment = charges.AmountOfPayment, 
                                                                Date = charges.Date, CharactOfPayment = charges.CharactOfPayment, LastName = charges.LastName, 
                                                                FirstName = charges.FirstName, MiddleName = charges.MiddleName, AddedUser = charges.AddedUser};
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            repo.EditCharges(editC);
            return true;
        }

        public BL.ChargesModels.ChargesDelete GetDeleteList(string user, int id = 1)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            DAL.Entity.Charges charg = repo.Charges.Where(ed => ed.ChargesID == id).First();
            if (charg.AddedUser == user)
            {
                return new BL.ChargesModels.ChargesDelete(charg.ChargesID, charg.PaymentType, charg.AmountOfPayment, charg.Date, charg.CharactOfPayment, charg.LastName,
                                                            charg.FirstName, charg.MiddleName);
            }
            else
            {
                return null;
            }
        }

        public BL.ChargesModels.ChargesDelete GetDeleteAdminList(int id = 1)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            DAL.Entity.Charges charg = repo.Charges.Where(ed => ed.ChargesID == id).First();
            return new BL.ChargesModels.ChargesDelete(charg.ChargesID, charg.PaymentType, charg.AmountOfPayment, charg.Date, charg.CharactOfPayment, charg.LastName,
                                                        charg.FirstName, charg.MiddleName);
        }
            

        public bool DeleteCharges(int id)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            DAL.Entity.Charges charg = repo.Charges.Where(ed => ed.ChargesID == id).First();
            repo.DeleteCharges(charg);
            return true;
        }

        public IEnumerable<BL.ChargesModels.ChargesInfo> GetSearchList(char search)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            List<DAL.Entity.Charges> sear = repo.Charges.Where(b => b.LastName[0] == search).ToList();
            if (sear.Count() > 0)
                return sear.Select(w => new ChargesModels.ChargesInfo(w.ChargesID, w.PaymentType, w.AmountOfPayment, w.Date, w.CharactOfPayment,
                                                                                        w.LastName, w.FirstName, w.MiddleName));
            else
                return null;
        }

        public IEnumerable<BL.ChargesModels.ChargesInfo> GetSearchDateList(DateTime search)
        {
            DAL.Repository.ChargesRepo repo = new DAL.Repository.ChargesRepo();
            List<DAL.Entity.Charges> sear = repo.Charges.Where(b => b.Date == search).ToList();
            if (sear.Count() > 0)
                return sear.Select(w => new ChargesModels.ChargesInfo(w.ChargesID, w.PaymentType, w.AmountOfPayment, w.Date, w.CharactOfPayment,
                                                                                        w.LastName, w.FirstName, w.MiddleName));
            else
                return null;
        }
    }
}
