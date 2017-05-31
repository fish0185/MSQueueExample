using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TransactionQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            // batched
            var queue = new MessageQueue(@".\private$\transactional-queue");
            var sp = Stopwatch.StartNew();
            var tx = new MessageQueueTransaction();
            tx.Begin();
            for (int i = 0; i < 1000; i++)
            {
                //var tx = new MessageQueueTransaction();
                //tx.Begin();
                queue.Send("Message: " + i, tx);
                //tx.Commit();
            }
            tx.Commit();
            Console.WriteLine(sp.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
