using System;

namespace McDoop.DeviceApp.ConsoleApp
{
    public class McDoopDevice
    {
        private Random random;
        public string City { get; private set; }
        public string Id { get; private set; }
        public int TotalSundaesMade { get; private set; }
        public int TotalConesMade { get; private set; }
        public double Level { get; private set; }
        public double Temperature { get; private set; }

        public McDoopDevice()
        {
            random = new Random();
            City = Cities[random.Next(0, Cities.Length)];
            Id = Guid.NewGuid().ToString();
            TotalSundaesMade = 0;
            TotalConesMade = 0;
            Temperature = GenerateTemperature();
            Level = GenerateLevel();
        }

        public void MakeSundae()
        {
            TotalSundaesMade++;
        }

        public void MakeCone()
        {
            TotalConesMade++;
        }

        public string GetDiagnostics()
        {
            return $"Temperature: {string.Format("{0:0.0}", GenerateTemperature())}°F, Level: {string.Format("{0:0}", GenerateLevel())}%";
        }

        private double GenerateLevel()
        {
            Level = 100 * random.NextDouble();
            return Level;
        }

        private double GenerateTemperature()
        {
            Temperature = 32 - (4 * random.NextDouble());
            return Temperature;
        }

        readonly string[] Cities = new string[]{
            "Seattle",
            "Portland",
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Phoenix",
            "Philadelphia"
        };

    }
}
