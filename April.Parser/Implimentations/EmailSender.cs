using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace April.Parser.Implimentations
{
    public class EmailSender
    {
        MailAddress From { get; set; }
        MailAddress To { get; set; }

        string Subject { get; set; }
        string Body { get; set; }

        bool IsBodyHtml { get; set; }
        public MailMessage Message
        {
            get
            {
                var message = new MailMessage(From, To);

                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsBodyHtml;

                return message;
            }
        }
        public EmailSender()
        {

        }
        public EmailSender(MailAddress from, MailAddress to, string subject, string body, bool isBodyHtml)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
            IsBodyHtml = isBodyHtml;
        }
        public void send()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); 
            smtp.Credentials = new NetworkCredential("<your_login>", "<your_pass>");

            smtp.EnableSsl = true;
            smtp.Send(Message);
        }
    }
}
