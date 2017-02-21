﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace UAS
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();
            // Instantiate installers for process and services.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // The services run under the system account.
            processInstaller.Account = ServiceAccount.LocalSystem;

            // The services are started manually.
            serviceInstaller.StartType = ServiceStartMode.Manual;

            // ServiceName must equal those on ServiceBase derived classes.
            serviceInstaller.ServiceName = "CurrentUserActivityService";

            // Add installers to collection. Order is not important.
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
