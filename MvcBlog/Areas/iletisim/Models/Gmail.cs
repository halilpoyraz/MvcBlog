using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MvcBlog.Areas.iletisim.Models
{
        public static class Gmail
        {
            public static void SendMail(string body)
            {
                var fromAddress = new MailAddress("h.ibrahimpoyraz@gmail.com", "Mvc Blog Geri Bildirim");
                var toAddress = new MailAddress("h.ibrahimpoyraz@gmail.com");
                const string subject = "Mvc Blog Geri Bildirim";
                using (var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, "poyraz4134")
                    //trololol kısmı e-posta adresinin şifresi
                })
                {
                    using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                    {
                        smtp.Send(message);
                    }
                }
            }
        }  
}