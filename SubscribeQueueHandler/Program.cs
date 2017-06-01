using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SubscribeQueueHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueAddresss = @".\private$\subscribe2";
            using (var queue = new MessageQueue(queueAddresss))
            {
                queue.MulticastAddress = "234.1.1.1:8001";
                while (true)
                {
                    Console.WriteLine("Listening on: {0}", queueAddresss);
                    var message = queue.Receive();
                    //message.AcknowledgeType = AcknowledgeTypes.FullReceive;

                }
            }
        }
    }
}
