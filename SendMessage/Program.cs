using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace SendMessage
{
    public class LogMessage
    {
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var msg = new LogMessage
            {
                MessageText = "This is a test message.",
                MessageTime = DateTime.Now
            };

            SendMessage(@".\Private$\IDGLog", msg);
        }

        private static void SendMessage(string queueName, LogMessage msg)
        {
            MessageQueue messageQueue = null;
            if (!MessageQueue.Exists(queueName))
            {
                messageQueue = MessageQueue.Create(queueName);
            }
            else
            {
                messageQueue = new MessageQueue(queueName);
            }

            try
            {
                messageQueue.Formatter = new XmlMessageFormatter(new Type[]{typeof(LogMessage)});
                messageQueue.Send(msg);
            }
            catch
            {
                throw;
            }
            finally
            {
                messageQueue.Close();
            }
        }

        private static LogMessage ReceiveMessage(string queueName)
        {
            if (!MessageQueue.Exists(queueName)) return null;

            var messageQueue = new MessageQueue(queueName);
            LogMessage logMessage = null;

            try
            {
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(LogMessage)});

                logMessage = (LogMessage) messageQueue.Receive().Body;
            }
            catch
            {
            }
            finally
            {
                messageQueue.Close();
            }

            return logMessage;
        }
    }
}
