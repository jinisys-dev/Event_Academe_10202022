using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Folio_Plus_Call_Logger_Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}