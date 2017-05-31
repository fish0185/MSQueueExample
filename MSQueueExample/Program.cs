using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace MSQueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = FetchOrCreateQueue(@".\Private$\IDG");

            messageQueue.Label = "This is a test queue";
            messageQueue.Send("This is a test message.", "IDG");
        }

        private static MessageQueue FetchOrCreateQueue(string queueName)
        {
            MessageQueue messageQueue;
            if (!MessageQueue.Exists(queueName))
            {
                messageQueue = MessageQueue.Create(queueName);
            }
            else
            {
                messageQueue = new MessageQueue(queueName);
            }
            return messageQueue;
        }
    }
}
