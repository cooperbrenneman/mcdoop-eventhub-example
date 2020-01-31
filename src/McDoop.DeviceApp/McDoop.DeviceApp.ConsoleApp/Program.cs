using System;

namespace McDoop.DeviceApp.ConsoleApp
{
    public class Program
    {
        private const string EVENTHUB_CONNECTION_STRING = "";

        static void Main(string[] args)
        {
            McDoopDeviceManager deviceManager = new McDoopDeviceManager(EVENTHUB_CONNECTION_STRING);

            deviceManager.PrintDeviceData();

            MenuSelector menu = new MenuSelector(deviceManager);
            menu.StartMenu();
        }

    }
}
