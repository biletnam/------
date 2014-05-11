using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPop.Common.Logging;
using OpenPop.Mime;
using OpenPop.Mime.Decode;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

namespace kursach
{
    class EmailPriem
    {
        public void priem(string login, string pass) 
        {
            using (OpenPop.Pop3.Pop3Client client = new Pop3Client()) 
            {
                client.Connect("pop3.mail.ru", 110, false); 
                client.Authenticate(login, pass, AuthenticationMethod.UsernameAndPassword);
                if (client.Connected)
                {
                    int messageCount = client.GetMessageCount();  //получаем список айдишников писем в почте
                List<Message> allMessages = new List<Message>(messageCount); 
                for (int i = messageCount; i > 0; i--) 
                { 
                    allMessages.Add(client.GetMessage(i)); 
                }
                int schet =0;
                foreach (Message msg in allMessages) 
                {
                    schet += 1;
                    var att = msg.FindAllAttachments(); 
                    foreach (var ado in att) 
                    { 
                        ado.Save(new System.IO.FileInfo(System.IO.Path.Combine("c:\\", ado.FileName)));
                        client.DeleteMessage(schet);  
                    } 
                } 
                } 
            } 
        }
        //Извлечение сообщений
        public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
		{
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<Message> allMessages = new List<Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }
       //Удаление сообщений
        public bool DeleteMessageByMessageId(Pop3Client client, string messageId)
        {
            // Get the number of messages on the POP3 server
            int messageCount = client.GetMessageCount();

            // Run trough each of these messages and download the headers
            for (int messageItem = messageCount; messageItem > 0; messageItem--)
            {
                // If the Message ID of the current message is the same as the parameter given, delete that message
                if (client.GetMessageHeaders(messageItem).MessageId == messageId)
                {
                    // Delete
                    client.DeleteMessage(messageItem);
                    return true;
                }
            }

            // We did not find any message with the given messageId, report this back
            return false;
        }

    
    }
}
