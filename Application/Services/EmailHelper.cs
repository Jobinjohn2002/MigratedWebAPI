using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// EmailHelper
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// SendEmail operation
        /// </summary>
        public static void SendEmail(string template, object model, string from, string to, string subject, string SMTPHost, int SMTPPort)
        {
            var codeBaseuri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var templateFolderPath = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(codeBaseuri.Path)), "EmailTemplates");
            var templateFilePath = Path.Combine(templateFolderPath, template);
            var emailHtmlBody = Razor.Parse(File.ReadAllText(templateFilePath), model, template);
            SendEmail(emailHtmlBody, from, to, subject, SMTPHost, SMTPPort);
        }

        /// <summary>
        /// SendEmail operation
        /// </summary>
        public static void SendEmail(string body, string from, string to, string subject, string SMTPHost, int SMTPPort)
        {
            var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            };
          
            if (!string.IsNullOrEmpty(message.Body))
            {
                message.IsBodyHtml = true;

                var smtp = new SmtpClient(SMTPHost, SMTPPort);
                smtp.Send(message);
            }
        }
    }
}
