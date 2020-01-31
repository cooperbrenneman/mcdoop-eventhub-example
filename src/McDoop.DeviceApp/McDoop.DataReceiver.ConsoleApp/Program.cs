using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Threading.Tasks;

namespace McDoop.DataReceiver.ConsoleApp
{
    class Program
    {
        private const string CONSUMER_GROUP_NAME = "";
        private const string EVENTHUB_CONNECTION_STRING = "";
        private const string EVENTHUB_PATH = "";
        private const string LEASE_CONTAINER_NAME = "";
        private const string STORAGE_CONNECTION_STRING = "";

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Starting the McDoop Data Receiver Console App!");
            Console.WriteLine("Attempting to register the event processor...");

            EventProcessorHost eventProcessorHost = new EventProcessorHost(EVENTHUB_PATH, CONSUMER_GROUP_NAME, EVENTHUB_CONNECTION_STRING, STORAGE_CONNECTION_STRING, LEASE_CONTAINER_NAME);

            await eventProcessorHost.RegisterEventProcessorAsync<McDoopEventProcessor>();

            Console.WriteLine("Setup and waiting for incoming events");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            Console.WriteLine("Starting to exit...");

            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
