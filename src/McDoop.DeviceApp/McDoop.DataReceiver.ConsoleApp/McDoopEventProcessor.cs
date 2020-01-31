using McDoop.EventHub.Sender.Model;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McDoop.DataReceiver.ConsoleApp
{
    public class McDoopEventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Closing processor for partition {context.PartitionId} for path {context.EventHubPath}.");
            Console.WriteLine($"Reason for closing partition {context.PartitionId}: {reason}");
            return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"Opening processor for partition {context.PartitionId} for path {context.EventHubPath}.");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Process error for partition {context.PartitionId} for path {context.EventHubPath}.");
            Console.WriteLine($"{error.Message}");
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            if (messages != null)
            {
                foreach (var message in messages)
                {
                    var dataAsJson = Encoding.UTF8.GetString(message.Body.Array);
                    var mcDoopDeviceData = JsonConvert.DeserializeObject<McDoopDeviceData>(dataAsJson);
                    Console.WriteLine($"{mcDoopDeviceData}, Partition Id: {context.PartitionId}, Offset: {message.SystemProperties.Offset}");
                }
            }
            return context.CheckpointAsync();
        }
    }
}
