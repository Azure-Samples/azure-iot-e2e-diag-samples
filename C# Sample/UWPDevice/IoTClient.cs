// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace UWPSample
{
    class DeviceData
    {
        public DeviceData(string myName)
        {
            this.Name = myName;
        }

        public string Name
        {
            get; set;
        }
    }

    class IoTClient
    {
        private readonly string DeviceConnectionString = ConnectionStringProvider.Value;

        DeviceClient deviceClient;
        public TransportType Protocol { get; private set; }

        Action<object> errorHandler;

        public IoTClient(TransportType protocol)
        {
            this.Protocol = protocol;
        }

        public async Task Start()
        {
            try
            {
                this.deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString, this.Protocol);

                await this.deviceClient.OpenAsync();

                Debug.WriteLine("Exited!\n");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in sample: {0}", ex.Message);
            }
        }

        public Task CloseAsync()
        {
            return this.deviceClient.CloseAsync();
        }

        public Task SendEvent(string message)
        {
            var dataBuffer = string.Format("Msg from UWP: '{0}'. Sent at: {1}. Protocol used: {2}.", message, DateTime.Now.ToLocalTime(), Protocol);
            Message eventMessage = new Message(Encoding.UTF8.GetBytes(dataBuffer));
            Debug.WriteLine(string.Format("Sending message: '{0}'", dataBuffer));
            return deviceClient.SendEventAsync(eventMessage);
        }
    }
}