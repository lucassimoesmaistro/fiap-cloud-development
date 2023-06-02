using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace queue_send
{
    class Program
    {
        private static string queue_connection_string = "DefaultEndpointsProtocol=https;AccountName=fiap1scjr;AccountKey=dPGTcL8gc4TS+L95ZqjqPv6+M03g8crMYQHij6++GqZda13a03Cdi0/5yb+n+I9QatEIM92tgzYM+AStn/D0eQ==;EndpointSuffix=core.windows.net";
        private static string queue_name = "fiap-queue";
        static void Main(string[] args)
        {
            
            CloudStorageAccount queue_acc = CloudStorageAccount.Parse(queue_connection_string);
            
            CloudQueueClient queue_client = queue_acc.CreateCloudQueueClient();
            
            CloudQueue _queue = queue_client.GetQueueReference(queue_name);

            for (int i = 1; i < 10; i++)
            {
                Customer obj = new Customer();
                CloudQueueMessage _message = new CloudQueueMessage(obj.ToString());
                _queue.AddMessage(_message);
            }

            Console.WriteLine("All messages sent");
            Console.ReadLine();


        }
    }
}
