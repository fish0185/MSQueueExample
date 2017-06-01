
using System;
using System.Messaging;

namespace PublishSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var queue = new MessageQueue("FormatName:MULTICAST=234.1.1.1:8001"))
            {
                queue.DefaultPropertiesToSend.Recoverable = true;
                queue.Send(string.Format("Publishing at: {0}", DateTime.Now));
            }

            Console.ReadLine();
        }
    }
}
