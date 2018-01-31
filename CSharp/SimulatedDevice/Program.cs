using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace SimulatedDevice
{
    class Program
    {
        // String containing Hostname, Device Id & Device Key in one of the following formats:
        // "HostName=<iothub_host_name>;DeviceId=<device_id>;SharedAccessKey=<device_key>"
        // "HostName=<iothub_host_name>;CredentialType=SharedAccessSignature;DeviceId=<device_id>;SharedAccessSignature=SharedAccessSignature sr=<iot_host>/devices/<device_id>&sig=<token>&se=<expiry_time>";
        private const string DeviceConnectionString = "<replace>";

        private static int MESSAGE_COUNT = 10000;
        private const int TEMPERATURE_THRESHOLD = 30;
        private static float temperature;
        private static float humidity;
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            try
            {
                DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Mqtt);
                if (deviceClient == null)
                {
                    Console.WriteLine("Failed to create DeviceClient!");
                }
                else
                {
                    deviceClient.EnableE2EDiagnosticWithCloudSetting().Wait();
                    SendEvent(deviceClient).Wait();
                }

                Console.WriteLine("Exited!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sample: {0}", ex.Message);
            }
        }

        static async Task SendEvent(Microsoft.Azure.Devices.Client.DeviceClient deviceClient)
        {
            Console.WriteLine("Device sending {0} messages to IoTHub...\n", MESSAGE_COUNT);
            for (int count = 0; count < MESSAGE_COUNT; count++)
            {
                temperature = rnd.Next(20, 35);
                humidity = rnd.Next(60, 80);
                var dataBuffer = string.Format("{{\"messageId\":{0},\"temperature\":{1},\"humidity\":{2}}}", count, temperature, humidity);
                Message eventMessage = new Message(Encoding.UTF8.GetBytes(dataBuffer));
                eventMessage.Properties.Add("temperatureAlert", (temperature > TEMPERATURE_THRESHOLD) ? "true" : "false");
                Console.WriteLine("\t{0}> Sending message: {1}, Data: [{2}]", DateTime.Now.ToLocalTime(), count, dataBuffer);

                await deviceClient.SendEventAsync(eventMessage).ConfigureAwait(false);
                System.Threading.Thread.Sleep(1500);
            }
        }
    }
}
