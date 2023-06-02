using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;

namespace queue_send
{
    class Program
    {
        private static string _bus_connectionstring= "BlobEndpoint=https://fiap1scjr.blob.core.windows.net/;QueueEndpoint=https://fiap1scjr.queue.core.windows.net/;FileEndpoint=https://fiap1scjr.file.core.windows.net/;TableEndpoint=https://fiap1scjr.table.core.windows.net/;SharedAccessSignature=sv=2022-11-02&ss=bfqt&srt=s&sp=rwdlacupiytfx&se=2023-06-01T07:21:04Z&st=2023-05-31T23:21:04Z&spr=https&sig=i2M7fahKd2XKj2nWYYbu%2B5X4m4GXdOCaBtHlPFRwF3g%3D";
        private static string _queue_name = "fiapqueue";
        static async Task Main(string[] args)
        {
            CreateQueue("fiapqueue").Wait();
            Console.WriteLine("Queue created");
        }

        static async Task CreateQueue(string p_queuename)
        {
            ManagementClient _client = new ManagementClient(_bus_connectionstring);

            var _description = new QueueDescription(p_queuename)
            {
                EnableBatchedOperations = false,
                LockDuration=TimeSpan.FromMinutes(2),
                MaxDeliveryCount=2,
                DefaultMessageTimeToLive=TimeSpan.FromMinutes(2)
            };
            var queue = await _client.CreateQueueAsync(_description);
        }
        }
}
