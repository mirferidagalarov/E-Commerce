using E_commerce_.NET5_.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace E_commerce_.NET5_.AppCode.Extensions
{
    static public partial class Extension
    {
        static public bool SendEmail(this IConfiguration _configuration, string to, string subject, string body, bool appendCC = false)
        {
            try
            {
                string fromMail = _configuration["emailAccount:userName"];
                string displayName = _configuration["emailAccount:displayName"];
                string smtpServer = _configuration["emailAccount:smtpServer"];
                int smtpPort = Convert.ToInt32(_configuration["emailAccount:smtpPort"]);
                string password = _configuration["emailAccount:password"];
                string cc = _configuration["emailAccount:cc"];  

                using (MailMessage message = new MailMessage(new MailAddress(fromMail, displayName), new MailAddress(to))
                {

                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    if (!string.IsNullOrEmpty(cc) && appendCC)
                        message.CC.Add(cc);

                    SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                    smtpClient.Credentials = new NetworkCredential(fromMail, password);       
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
