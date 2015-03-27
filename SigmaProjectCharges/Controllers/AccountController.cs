using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using DAL;
using System.Web.Security;
using System.Net.Mail;

namespace SigmaProjectCharges.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BL.AccountModels.AccountRegister account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.AccountHelper h = new BL.Helpers.AccountHelper();
                    h.RegAccount(account);
                    //BL.Helpers.EmailHelper helpermail = new BL.Helpers.EmailHelper();
                    //helpermail.SendingActivation(account);
                    // наш email с заголовком письма
                    MailAddress from = new MailAddress("mailprojectactivation@yandex.ru", "Web Registration");
                    // кому отправляем
                    MailAddress to = new MailAddress(account.Mail);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Email confirmation";
                    // текст письма - включаем в него ссылку
                    m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
                                    "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
                        Url.Action("ConfirmEmail", "Account", new { Token = account.Login, Email = account.Mail }, Request.Url.Scheme));
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера, с которого мы и будем отправлять письмо
                    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 25);
                    // логин и пароль
                    smtp.Credentials = new System.Net.NetworkCredential("mailprojectactivation@yandex.ru", "qwerty123456");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return RedirectToAction("Confirm", "Account", new { Email = account.Mail });
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return View(account);
        }

        [AllowAnonymous]
        public string Confirm(string Email)
        {
            return @Resx.AccountStrings.ConfirmText1 + Email + @Resx.AccountStrings.ConfirmText2;
        }

        [AllowAnonymous]
        public ActionResult ConfirmEmail(string Token, string Email)
        {
            if (Token != null)
            {
                BL.Helpers.AccountHelper h = new BL.Helpers.AccountHelper();
                BL.AccountModels.ActivationModel activation = h.GetActivationList(Token);
                return View(activation);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmEmail(BL.AccountModels.ActivationModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.AccountHelper h = new BL.Helpers.AccountHelper();
                    h.ActivationMail(account);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return View(account);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(BL.AccountModels.AccountLogin user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.AccountHelper h = new BL.Helpers.AccountHelper();
                    if (h.LogAccount(user.Login, user.Password))
                    {
                        if (h.CheckActivation(user.Login) == true)
                        {
                            FormsAuthentication.SetAuthCookie(user.Login, createPersistentCookie: true);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", Resx.AccountStrings.erroractivationemail);
                            return View(user);
                        }
                    }
                }
            }
            catch (DataException)
            {
            }
            ModelState.AddModelError("", Resx.AccountStrings.inputvalidationloginpassword);
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            BL.Helpers.AccountHelper helper = new BL.Helpers.AccountHelper();
            BL.AccountModels.AccountProfile profile = helper.GetUsersList(User.Identity.Name);
            return View(profile);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(BL.AccountModels.ForgotPasswordModel account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BL.Helpers.AccountHelper helper = new BL.Helpers.AccountHelper();
                    BL.AccountModels.ForgotPasswordModel forgotpassword = helper.GetForgotPasswordList(account.Login);
                    MailAddress from = new MailAddress("mailprojectactivation@yandex.ru", "Напоминание пароля");
                    MailAddress to = new MailAddress(forgotpassword.Mail);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Ваш пароль: "+ forgotpassword.Password);
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 25);
                    smtp.Credentials = new System.Net.NetworkCredential("mailprojectactivation@yandex.ru", "qwerty123456");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", @Resx.HomeStrings.errormodel);
            }
            return View(account);
        }
    }
}
