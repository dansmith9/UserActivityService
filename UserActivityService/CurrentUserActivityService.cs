using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace UAS
{
    public partial class CurrentUserActivityService : ServiceBase
    {
        private MqttClient client = new MqttClient("192.168.1.10");

        public CurrentUserActivityService()
        {
            CanPauseAndContinue = true;
            CanHandleSessionChangeEvent = true;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //MqttClient client = new MqttClient("192.168.1.10");
            byte code = client.Connect(Guid.NewGuid().ToString());
            client.Publish("/Logins/Test", Encoding.UTF8.GetBytes("Service Connected"));
        }

        protected override void OnStop()
        {
            client.Disconnect();
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
            WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            client.Publish("/Logins/Test", Encoding.UTF8.GetBytes(wp.Identity.Name));
        }
    }
}
