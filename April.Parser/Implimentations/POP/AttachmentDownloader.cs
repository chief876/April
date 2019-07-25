using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;

namespace April.Parser.Implimentations.POP
{
    public class AttachmentDownloader : IDisposable
    {
        private bool disposed;
        private Pop3Client client;
        public AttachmentDownloader(string hostname, int port, bool useSsl)
        {
            client = new Pop3Client();
            client.Connect(hostname, port, useSsl);
        }
        public bool authenticate(string login, string pass)
        {
            try
            {
                client.Authenticate(login, pass, AuthenticationMethod.UsernameAndPassword);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void download()
        {
            string downloadPath = "Download";
            bool exists = System.IO.Directory.Exists(downloadPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(downloadPath);

            int messageCount = client.GetMessageCount();
            List<Message> allMessages = new List<Message>(messageCount);
            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(client.GetMessage(i));
            }
            foreach (Message msg in allMessages)
            {
                var att = msg.FindAllAttachments();
                foreach (var ado in att)
                {
                    //TODO проверка на rar и zip
                    if (ado.ContentType.MediaType.Equals("application/octet-stream") || ado.ContentType.MediaType.Equals("application/x-zip-compressed"))
                    {
                        Console.WriteLine($"Загрузка файла: {ado.FileName}");
                        ado.Save(new System.IO.FileInfo(System.IO.Path.Combine($"{Environment.CurrentDirectory}/{downloadPath}/", ado.FileName)));
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if(client != null)
                    { 
                        client.Dispose();
                    }
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        ~AttachmentDownloader()
        {
            Dispose(false);
        }
    }
}
