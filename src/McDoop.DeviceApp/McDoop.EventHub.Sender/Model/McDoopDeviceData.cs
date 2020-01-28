using System;

namespace McDoop.EventHub.Sender.Model
{
    public class McDoopDeviceData
    {
        public string City { get; set; }
        public string Id { get; set; }
        public string SensorType { get; set; }
        public string SensorValue { get; set; }
        public DateTime EventTime { get; set; }

        public override string ToString()
        {
            return $"Time: {EventTime:HH:mm:ss}, {SensorType}: {SensorValue}, City: {City}, Id: {Id}";
        }
    }
}
