using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BL.Helpers
{
    public class EmailHelper
    {
        //public bool SendingActivation(BL.AccountModels.AccountRegister account)
        //{
        //    // наш email с заголовком письма
        //    MailAddress from = new MailAddress("mailprojectactivation@yandex.ru", "Web Registration");
        //    // кому отправляем
        //    MailAddress to = new MailAddress(account.Mail);
        //    // создаем объект сообщения
        //    MailMessage m = new MailMessage(from, to);
        //    // тема письма
        //    m.Subject = "Email confirmation";
        //    // текст письма - включаем в него ссылку
        //    m.Body = string.Format("Для завершения регистрации перейдите по ссылке:" +
        //                    "<a href=\"{0}\" title=\"Подтвердить регистрацию\">{0}</a>",
        //        Url.Action("ConfirmEmail", "Account", new { Token = account.Login, Email = account.Mail }, Request.Url.Scheme));
        //    m.IsBodyHtml = true;
        //    // адрес smtp-сервера, с которого мы и будем отправлять письмо
        //    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.yandex.ru", 25);
        //    // логин и пароль
        //    smtp.Credentials = new System.Net.NetworkCredential("mailprojectactivation@yandex.ru", "qwerty123456");
        //    smtp.EnableSsl = true;
        //    smtp.Send(m);
        //}
    }
}
