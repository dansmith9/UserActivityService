using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace ConsoleMQTTTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MqttClient client = new MqttClient("10.60.100.80");
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
                byte code = client.Connect(Guid.NewGuid().ToString());
                client.Publish("/Logins/221", Encoding.UTF8.GetBytes("Test client Startup"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
