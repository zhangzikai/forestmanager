namespace VgsTiledMap.Ags
{
    using log4net;
    using log4net.Config;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;

    [RunInstaller(true)]
    public class VgsMapTilerInstaller : Installer
    {
        private IContainer components;
        private static readonly ILog logger = LogManager.GetLogger("VgsMapTileAgsSystemLogger");

        public VgsMapTilerInstaller()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private int GetArcGISVersion()
        {
            string str = (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ESRI\ArcGIS", "RealVersion", null);
            return int.Parse(str.Split(new char[] { '.' })[0]);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        public override void Install(IDictionary stateSaver)
        {
            XmlConfigurator.Configure(new FileInfo(base.GetType().Assembly.Location + ".config"));
            logger.Debug("Install VgsTiledMap.Ags");
            base.Install(stateSaver);
            new RegistrationServices().RegisterAssembly(base.GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase);
            int arcGISVersion = this.GetArcGISVersion();
            logger.Debug("Installed ArcGIS version: " + arcGISVersion);
            if (arcGISVersion == 10)
            {
                this.Install10();
            }
        }

        public void Install10()
        {
            string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), @"ArcGIS\bin\ESRIRegAsm.exe");
            Process process2 = new Process();
            process2.StartInfo.FileName = str;
            Process process = process2;
            string str2 = string.Format("\"{0}\" /p:Desktop", base.GetType().Assembly.Location);
            process.StartInfo.Arguments = str2;
            logger.Debug("Register for ArcGIS 10: " + str2);
            process.Start();
            logger.Debug("Register for ArcGIS 10 finished.");
        }

        public override void Uninstall(IDictionary savedState)
        {
            XmlConfigurator.Configure(new FileInfo(base.GetType().Assembly.Location + ".config"));
            logger.Debug("Uninstall VgsTiledMap.Ags");
            try
            {
                string cacheFolder = CacheSettings.GetCacheFolder();
                logger.Debug("Trying to delete tile folder: " + cacheFolder);
                Directory.Delete(cacheFolder, true);
                logger.Debug("Tile directory is deleted");
            }
            catch (Exception exception)
            {
                logger.Debug("Delete folder failed, error: " + exception.ToString());
            }
            int arcGISVersion = this.GetArcGISVersion();
            logger.Debug("Installed ArcGIS version: " + arcGISVersion);
            if (arcGISVersion == 10)
            {
                this.Uninstall10();
            }
            base.Uninstall(savedState);
            new RegistrationServices().UnregisterAssembly(base.GetType().Assembly);
            logger.Debug("Uninstall VgsTiledMap.Ags finished.");
        }

        public void Uninstall10()
        {
            string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), @"ArcGIS\bin\ESRIRegAsm.exe");
            Process process2 = new Process();
            process2.StartInfo.FileName = str;
            Process process = process2;
            string str2 = string.Format("\"{0}\" /p:Desktop /u", base.GetType().Assembly.Location);
            process.StartInfo.Arguments = str2;
            logger.Debug("Unregister for ArcGIS 10: " + str2);
            process.Start();
            logger.Debug("Unregister for ArcGIS 10 finished.");
        }
    }
}

