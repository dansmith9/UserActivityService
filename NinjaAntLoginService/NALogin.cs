using System;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

namespace NinjaAntLoginService
{
    public partial class NALogin : ServiceBase
    {
        private MqttClient client = new MqttClient("10.60.100.80");
        private string _hostName = Environment.MachineName;
        private string topic = "";

        private string sSource = "NALogin";
        private string sLog = "Application";
        //private string sEvent;

        public NALogin()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Create eventlog
            if (!EventLog.SourceExists(sSource))
            {
                EventLog.CreateEventSource(sSource, sLog);
            }


            string[] HostSplit = _hostName.Split('-');
            EventLog.WriteEntry(sSource, string.Format("NALogin - Hostname: {0}", _hostName));
            topic = String.Format("/Logins/{0}",HostSplit[1]);
            EventLog.WriteEntry(sSource, string.Format("NALogin - Topic: {0}", topic));
            try
            {
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
                byte code = client.Connect(Guid.NewGuid().ToString());
                EventLog.WriteEntry(sSource, string.Format("NALogin - MQTT client code: {0}", code));
                client.Publish(topic, Encoding.UTF8.GetBytes(_hostName + "," + "Startup"));
            }
            catch (Exception e)
            {
                EventLog.WriteEntry(sSource, string.Format("NALogin - Exception: {0}", e));
                throw;
            }
        }

        protected override void OnStop()
        {
            client.Disconnect();
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
            
            
            if (changeDescription.Reason.ToString()=="SessionLogon")
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
                ManagementObjectCollection collection = searcher.Get();
                string DomainUsername = (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
                EventLog.WriteEntry(sSource, string.Format("NALogin - DomainUsername: {0}", DomainUsername));
                string[] username = DomainUsername.Split('\\');
                EventLog.WriteEntry(sSource, string.Format("NALogin - Stripped username: {0}", username[1]));
                client.Publish(topic, Encoding.UTF8.GetBytes(_hostName + "," + changeDescription.Reason + "," + username[1]));
            }
            else if (changeDescription.Reason.ToString() == "SessionLogoff")
            {
                client.Publish(topic, Encoding.UTF8.GetBytes(_hostName + "," + "Logoff"));
                EventLog.WriteEntry(sSource, "NALogin - Logoff event detected");
            }
            else
            {
                client.Publish(topic, Encoding.UTF8.GetBytes(_hostName + "," + changeDescription.Reason));
                EventLog.WriteEntry(sSource, string.Format("NALogin - Misc session event detected: {0}",changeDescription.Reason));
            }
        }
    }
}
