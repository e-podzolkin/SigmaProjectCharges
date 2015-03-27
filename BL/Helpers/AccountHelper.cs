using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL.Helpers
{
    public class AccountHelper
    {
        public bool RegAccount(BL.AccountModels.AccountRegister account)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            RolesHelper helper = new RolesHelper();
            DAL.Entity.RolesAccounts role = helper.RoleUser();
            DAL.Entity.Accounts newR = new DAL.Entity.Accounts
            {
                LastName = account.LastName,
                FirstName = account.FirstName,
                MiddleName = account.MiddleName,
                Mail = account.Mail,
                PhoneNumber = account.PhoneNumber,
                Comment = account.Comment,
                Login = account.Login,
                Password = account.Password,
                Activation = false,
                RolesAccount = role
            };
            repo.RegAccount(newR);
            return true;
        }

        public bool LogAccount(string _login, string _password)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            return repo.Account.Any(a => a.Login.Equals(_login) && a.Password.Equals(_password));
        }

        public BL.AccountModels.AccountProfile GetUsersList(string username)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            DAL.Entity.Accounts user = repo.Account.Where(u => u.Login == username).FirstOrDefault();
            return new BL.AccountModels.AccountProfile(user.UserID, user.LastName, user.FirstName, user.MiddleName, user.Mail, user.PhoneNumber, user.Comment,
                                                        user.RolesAccount != null ? user.RolesAccount.RolesName : "");
        }

        public bool CheckActivation(string login)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            List<DAL.Entity.Accounts> activ = repo.Account.Where(b => b.Login == login && b.Activation == true).ToList();
            if (activ.Count() > 0)
                return true;
            else
                return false;
        }

        public BL.AccountModels.ActivationModel GetActivationList(string username)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            DAL.Entity.Accounts user = repo.Account.Where(u => u.Login == username).FirstOrDefault();
            return new BL.AccountModels.ActivationModel(user.UserID, user.LastName, user.FirstName, user.MiddleName, user.Mail, user.PhoneNumber, user.Comment, user.Login, user.Password, user.Activation);
        }

        public bool ActivationMail(BL.AccountModels.ActivationModel account)
        {
            DAL.Entity.Accounts activation = new DAL.Entity.Accounts
            {
                UserID = account.UserID,
                LastName = account.LastName,
                FirstName = account.FirstName,
                MiddleName = account.MiddleName,
                Mail = account.Mail,
                PhoneNumber = account.PhoneNumber,
                Comment = account.Comment,
                Login = account.Login,
                Password = account.Password,
                Activation = true
            };
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            repo.ActivationAccount(activation);
            return true;
        }

        public BL.AccountModels.ForgotPasswordModel GetForgotPasswordList(string login)
        {
            DAL.Repository.AccountRepo repo = new DAL.Repository.AccountRepo();
            DAL.Entity.Accounts user = repo.Account.Where(u => u.Login == login).FirstOrDefault();
            return new BL.AccountModels.ForgotPasswordModel(user.Mail, user.Login, user.Password);
        }
    }
}
