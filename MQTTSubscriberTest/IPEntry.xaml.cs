using SeatingPlanner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SeatingPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IPEntry : Page
    {
        public IPEntry()
        {
            this.InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IPAddressEntry.Text!="")
            {
                this.Frame.Navigate(typeof(MainPage),IPAddressEntry.Text);
            }
            else
            {
                DisplayErrorDialog();
            }
        }

        private async void DisplayErrorDialog()
        {
            var messageDialog = new MessageDialog("Please enter an IP address");
            messageDialog.Title = "Error";
            await messageDialog.ShowAsync();
        }
    }
}
