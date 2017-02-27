using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SeatingPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string MQTTServer = "";

        public MainPage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MQTTServer = e.Parameter as string;
            try
            {
                MqttClient client = new MqttClient(MQTTServer);
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
                client.Connect(Guid.NewGuid().ToString());
                //client.Publish("/Logins/Test", Encoding.UTF8.GetBytes("UWP"));

                ushort msgId = client.Subscribe(new string[] { "/Logins/221" },
                    new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                client.MqttMsgSubscribed += client_MqttMsgSubscribed;
                //ByteCode.Text = msgId.ToString();
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            }
            catch (Exception)
            {
                DisplayErrorDialog();
            }
        }


        private async void DisplayErrorDialog()
        {
            var messageDialog = new MessageDialog(string.Format("Could not connect to MQTT server {0}", MQTTServer));
            messageDialog.Title = "Connection Error";
            await messageDialog.ShowAsync();
        }

        private async void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Debug.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);

            string Message = Encoding.UTF8.GetString(e.Message);
            string[] SplitMessage = Message.Split(',');
            string ComputerName = SplitMessage[0];
            string ComputerNumber = ComputerName.Split('-')[2];
            string SessionEvent = SplitMessage[1];
            string UserName = "";

            if (SessionEvent=="SessionLogon")
            {
                UserName = SplitMessage[2];
            }

            switch (ComputerNumber)
            {
                case "001":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC001.Text = messageAssembler(SessionEvent,ComputerNumber,UserName);
                    });
                    break;
                case "002":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC002.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "003":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC003.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "004":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC004.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "005":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC005.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "006":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC006.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "007":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC007.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "008":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC008.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "009":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC009.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "010":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC010.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "011":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC011.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "012":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC012.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "013":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC013.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "014":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC014.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "015":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC015.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "016":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC016.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "017":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC017.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "018":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC018.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "019":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC019.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "020":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC020.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "021":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC021.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "022":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC022.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "023":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC023.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "024":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC024.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "025":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC025.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "026":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC026.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "027":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC027.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "028":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC028.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "029":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC029.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "030":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC030.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "031":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC031.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                case "032":
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PC032.Text = messageAssembler(SessionEvent, ComputerNumber, UserName);
                    });
                    break;
                default:
                    break;
            }           
        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine("Subscribed for id = " + e.MessageId);
        }

        private string messageAssembler(string SessionEvent, string ComputerNumber,string UserName)
        {
            string ReturnText = "";
            if (SessionEvent== "SessionLogon")
            {
                ReturnText = UserName;
            }
            else if (SessionEvent=="Logoff") //Required for future events?
            {
                ReturnText = "No user";
            }
            else
            {
                ReturnText = "No user";
            }
            return ReturnText;
        }

    }
}
