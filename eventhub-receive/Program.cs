using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eventhub_receive
{
    class Program
    {
        private static string connstring = "Endpoint=sb://pruebas2304.servicebus.windows.net/;SharedAccessKeyName=poli;SharedAccessKey=PkVpDO/y6Y2TuOWvw2Ut1xlenA9mcuMKtzxmjrI9Vz8=;EntityPath=prueba4566";
        private static string hubname = "prueba4566";

        static void Main(string[] args)
        {
            GetEvents().Wait();
        }

        static private async Task GetEvents()
        {
            EventHubConsumerClient client = new EventHubConsumerClient("$Default", connstring, hubname);

            var cancellation = new CancellationToken();

            Console.WriteLine("Getting the events");
            await foreach (PartitionEvent Allevent in client.ReadEventsAsync(cancellation))
            {
                EventData event_data = Allevent.Data;
                Console.WriteLine(Encoding.UTF8.GetString(event_data.Body.ToArray()));

            }

        }
    }
}
