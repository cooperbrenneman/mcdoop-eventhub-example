using System;
using System.Collections.Generic;
using System.Text;

namespace McDoop.DeviceApp.ConsoleApp
{
    public class MenuSelector
    {
        private readonly McDoopDeviceManager _deviceManager;
        public MenuSelector(McDoopDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }
        public void StartMenu()
        {
            Console.WriteLine("McDoop Ice Cream Device Application");

            int selection;
            do
            {
                selection = DisplayAndGetSelection();
                if (selection != 4)
                {
                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("Preparing a Sundae...");
                            _deviceManager.PrepareSundaeAsync();
                            break;
                        case 2:
                            Console.WriteLine("Preparing a Cone...");
                            _deviceManager.PrepareConeAsync();
                            break;
                        case 3:
                            Console.WriteLine("Sending Diagnostic Data...");
                            _deviceManager.SendDeviceDiagnostics();
                            break;
                    }
                }
            } while (selection != 4);
        }

        private int DisplayAndGetSelection()
        {
            Console.WriteLine("Make a Selection:");
            Console.WriteLine("\t1. Make a McDoop Sundae");
            Console.WriteLine("\t2. Make a McDoop Cone");
            Console.WriteLine("\t3. Send Device Diagnostic Data");
            Console.WriteLine("\t4. Exit");
            bool validResult = int.TryParse(Console.ReadLine(), out int selection);
            if (!validResult)
            {
                Console.WriteLine("Please enter a valid input");
            }
            return selection;
        }
    }
}
