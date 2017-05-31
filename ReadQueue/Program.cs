using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ReadQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @".\Private$\IDG";
            var lstMessage = ReadQueue(path);
        }

        private static List<string> ReadQueue(string path)
        {
            List<string> lstMessage = new List<string>();

            using (var messageQueue = new MessageQueue(path))
            {
                var messages = messageQueue.GetAllMessages();

                foreach (var message in messages)
                {
                    message.Formatter = new XmlMessageFormatter(new string[]{"System.String, mscorlib"});
                    var msg = message.Body.ToString();
                    lstMessage.Add(msg);
                }
            }
            return lstMessage;
        }
    }
}
