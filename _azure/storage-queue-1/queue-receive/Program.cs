using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Collections;

namespace queue_receive
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

            _queue.FetchAttributes();
            int? _count = _queue.ApproximateMessageCount;

            for (int i = 0; i < _count; i++)
            {
                CloudQueueMessage _message = _queue.GetMessage();
                Console.WriteLine(_message.AsString);
                _queue.DeleteMessage(_message);
            }
            Console.ReadLine();
        }
        
    }
}
