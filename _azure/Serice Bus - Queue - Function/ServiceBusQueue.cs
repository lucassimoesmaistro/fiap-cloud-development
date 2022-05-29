using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Serice_Bus___Queue___Function
{
    public static class ServiceBusQueue
    {
        [FunctionName("GetMessages")]
        public static void Run([ServiceBusTrigger("fiapqueue", Connection = "connectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
