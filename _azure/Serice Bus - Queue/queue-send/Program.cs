using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace queue_send
{
    class Program
    {
        private static string _bus_connectionstring = "DefaultEndpointsProtocol=https;AccountName=fiap1scjr;AccountKey=dPGTcL8gc4TS+L95ZqjqPv6+M03g8crMYQHij6++GqZda13a03Cdi0/5yb+n+I9QatEIM92tgzYM+AStn/D0eQ==;EndpointSuffix=core.windows.net";
        private static string _queue_name = "fiap-queue";
        static async Task Main(string[] args)
        {
            IQueueClient _client;
            _client = new QueueClient(_bus_connectionstring, _queue_name);
            Console.WriteLine("Sending Messages");
            for (int i = 1; i <=10; i++)
            {
                Order obj = new Order();
                var _message = new Message(Encoding.UTF8.GetBytes(obj.ToString()));
                await _client.SendAsync(_message);
                Console.WriteLine($"Sending Message : {obj.Id} ");
            }
        }
        }
}
