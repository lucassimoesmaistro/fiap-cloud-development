using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Collections;

namespace queue_receive
{
    class Program
    {
        private static string queue_connection_string = "DefaultEndpointsProtocol=https;AccountName=0storage80808lsm;AccountKey=k3y2n/XE1E/Y+SokUHkoIMpFVbwkX5F7l17/beh1XXyDtm2cWC+AlW6KdRM0a/zaAqVkd4Pwd+C6GY6tgkxRaA==;EndpointSuffix=core.windows.net";
        private static string queue_name = "appqueue";

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
