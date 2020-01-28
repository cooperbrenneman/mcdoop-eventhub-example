using McDoop.EventHub.Sender.Model;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace McDoop.EventHub.Sender
{
    public interface IMcDoopDeviceDataSender
    {
        Task SendDataAsync(McDoopDeviceData data);
    }
    public class McDoopDeviceDataSender : IMcDoopDeviceDataSender
    {
        private EventHubClient _eventHubClient;

        public McDoopDeviceDataSender(string eventHubConnectionString)
        {
            _eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnectionString);
        }

        public async Task SendDataAsync(McDoopDeviceData data)
        {
            var dataAsJson = JsonConvert.SerializeObject(data);
            var eventData = new EventData(Encoding.UTF8.GetBytes(dataAsJson));
            await _eventHubClient.SendAsync(eventData);
        }
    }
}
