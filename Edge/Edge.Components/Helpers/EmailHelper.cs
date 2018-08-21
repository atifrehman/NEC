using Edge.Components.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NEC.Components.Helpers
{
    public class EmailHelper
    {
        public void Send(string subject, string body, List<string> toList, List<string> ccList = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationHelper.Email);
                mail.Subject = subject;
                mail.Body = body;
                foreach (var item in toList)
                {
                    mail.To.Add(item);
                }
                if (ccList != null)
                {
                    foreach (var cc in ccList)
                    {
                        mail.CC.Add(cc);
                    }
                }

                SmtpClient SmtpServer = new SmtpClient(ConfigurationHelper.SmtpHost);
                SmtpServer.Port = ConfigurationHelper.SmtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationHelper.Email, ConfigurationHelper.Password);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
            }
        }
    }
}
