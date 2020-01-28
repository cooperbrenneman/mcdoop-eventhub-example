using McDoop.EventHub.Sender;
using McDoop.EventHub.Sender.Model;
using System;
using System.Threading.Tasks;

namespace McDoop.DeviceApp.ConsoleApp
{
    public class McDoopDeviceManager
    {

        private static McDoopDeviceDataSender _dataSender;
        private static McDoopDevice _device;

        public McDoopDeviceManager(string connectionString)
        {
            _device = new McDoopDevice();
            _dataSender = new McDoopDeviceDataSender(connectionString);
        }

        public void PrintDeviceData()
        {
            Console.WriteLine("Device Information: ");
            Console.WriteLine($"Device Id: {_device.Id}");
            Console.WriteLine($"Device City: {_device.City}");
            Console.WriteLine($"Temperature: {string.Format("{0:0.0}", _device.Temperature)}°F");
            Console.WriteLine($"Level: {string.Format("{0:0}", _device.Level)}%");
            Console.WriteLine();
        }

        public async void PrepareConeAsync()
        {
            _device.MakeCone();
            await CreateMcDoopDeviceData("ConeCounter", _device.TotalConesMade.ToString());
        }

        public async void PrepareSundaeAsync()
        {
            _device.MakeSundae();
            await CreateMcDoopDeviceData("SundaeCounter", _device.TotalSundaesMade.ToString());
        }

        public async void SendDeviceDiagnostics()
        {
            string diagnostics = _device.GetDiagnostics();
            WriteLog($"New Device Diagnostics: {diagnostics}");
            await CreateMcDoopDeviceData("Temperature", $"{string.Format("{0:0.0}", _device.Temperature)}");
            await CreateMcDoopDeviceData("Level", $"{string.Format("{0:0}", _device.Level)}");
        }

        private async Task CreateMcDoopDeviceData(string sensorType, string sensorValue)
        {
            var mcDoopDeviceData = new McDoopDeviceData
            {
                City = _device.City,
                Id = _device.Id,
                SensorType = sensorType,
                SensorValue = sensorValue,
                EventTime = DateTime.Now
            };
            await SendDataAsync(mcDoopDeviceData);
        }

        private async Task SendDataAsync(McDoopDeviceData mcDoopDeviceData)
        {
            try
            {
                await _dataSender.SendDataAsync(mcDoopDeviceData);
                WriteLog($"Data Sent: {mcDoopDeviceData}");
            }
            catch (Exception ex)
            {
                WriteLog($"Exception: {ex.Message}");
            }
        }

        private void WriteLog(string message)
        {
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("Action Finished!");
            Console.WriteLine(message);
            Console.WriteLine("==========================================================================================");
            Console.WriteLine();
        }
    }
}
