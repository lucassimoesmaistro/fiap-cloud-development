using Microsoft.Azure.ServiceBus;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace queue_receive
{
    class Program
    {
        private static string _bus_connectionstring = "Endpoint=sb://messagebrokerfiap.servicebus.windows.net/;SharedAccessKeyName=policyqueue;SharedAccessKey=gmlUyhfMH2i9xVqTlLh2QOR/1D5K7/GcMYIEaOKctjs=";
        private static string _queue_name = "fiapqueue";
        private static QueueClient _client;

        static void Main(string[] args)
        {
            QueueFunction().GetAwaiter().GetResult();
        }

        static async Task QueueFunction()
        {
                _client = new QueueClient(_bus_connectionstring, _queue_name);

                var _options = new MessageHandlerOptions(ExceptionReceived)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };

                _client.RegisterMessageHandler(Process_Message, _options);
            Console.ReadKey();
            }
        

        static async Task Process_Message(Message _message,CancellationToken _token)
        {
            Console.WriteLine(Encoding.UTF8.GetString(_message.Body));
            

            await _client.CompleteAsync(_message.SystemProperties.LockToken);
        }

        static Task ExceptionReceived(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine(args.Exception);
            return Task.CompletedTask;
        }

    }
}
