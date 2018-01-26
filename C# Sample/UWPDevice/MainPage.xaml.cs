using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Popups;
using UWPSample;

namespace Microsoft.Azure.Devices.Client.Samples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IoTClient client;

        struct ProtocolNameToIdLookupEntry
        {
            public string Name;
            public TransportType Id;
        }

        List<ProtocolNameToIdLookupEntry> protocolLookup = new List<ProtocolNameToIdLookupEntry>()
        {
            new ProtocolNameToIdLookupEntry { Name = "MQTT", Id = TransportType.Mqtt },
        };

        string GetProtocolNameFromId(TransportType protocolId)
        {
            return protocolLookup.Where(_ => _.Id == protocolId).First().Name;
        }

        TransportType GetProtocolIdFromName(string protocolName)
        {
            return protocolLookup.Where(_ => _.Name == protocolName).First().Id;
        }

        public MainPage()
        {
            this.InitializeComponent();

            var defaultProtocol = TransportType.Mqtt;

            this.client = new IoTClient(defaultProtocol);

            protocolLookup.ForEach(_ =>
            {
                this.protocolComboBox.Items.Add(_.Name);
            });

            this.protocolComboBox.SelectedIndex = protocolLookup.IndexOf(new ProtocolNameToIdLookupEntry { Id = defaultProtocol, Name = GetProtocolNameFromId(defaultProtocol) });

#pragma warning disable 4014
            client.Start();
#pragma warning restore 4014
        }

        private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = this.messageText.Text;
            await this.client.SendEvent(msg);
            var dialog = new MessageDialog("Message sent successfully!");
            await dialog.ShowAsync();
        }

        private async void OnProtocolSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransportType protocol = GetProtocolIdFromName(this.protocolComboBox.SelectedValue.ToString());

            if (protocol != client.Protocol)
            {
                if (this.client != null)
                {
                    try
                    {
                        await this.client.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        var err = string.Format("Error {0} while closing the client", ex.Message);
                        Debug.WriteLine(err);
                    }
                }
                this.client = new IoTClient(protocol);
                await this.client.Start();
            }
        }

        private async Task AddItemToListBox(ListBox list, string item)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    list.Items.Add(item);

                    var selectedIndex = list.Items.Count - 1;
                    if (selectedIndex < 0)
                        return;

                    list.SelectedIndex = selectedIndex;
                    list.UpdateLayout();

                    list.ScrollIntoView(list.SelectedItem);
                });
        }
    }
}
