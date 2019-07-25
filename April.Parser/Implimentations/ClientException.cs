using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace April.Parser.Implimentations
{
    public static class ClientException
    {
        public static void Process(object sender, UnhandledExceptionEventArgs e)
        {

            string debugImagesPath = "DebugScreen"; 
            bool exists = System.IO.Directory.Exists(debugImagesPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(debugImagesPath);

            var screen = ScreenshotTaker.getScreen();
            var imgPath = $@"{Environment.CurrentDirectory}\{debugImagesPath}\{Guid.NewGuid().ToString()}.jpg";
            screen.Save(imgPath);

            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine("ClientException.Process caught : " + ex.Message);
            Console.WriteLine("Runtime terminating: {0}", e.IsTerminating);
            var htmlMessage = $@"<p>Exception code: {ex.HResult}</p>
                                 <p>Exception message: {ex.Message}</p>
                                 <p>Version OS: {Environment.OSVersion}</p>
                                 <p>User Name OS: {Environment.UserName}</p>
                                 <p>dot.Net Version: {Environment.Version}</p>";
            Attachment attachData = new Attachment(imgPath);

            MailAddress mFrom = new MailAddress("<senders_mail>", Environment.UserDomainName);
            MailAddress mTo = new MailAddress("<recipients_mail>", Environment.UserDomainName);
            EmailSender es = new EmailSender(mFrom, mTo, "ClientException", htmlMessage, true);
            es.Message.Attachments.Add(attachData);
            es.send();
            
        }


    }
}
