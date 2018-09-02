namespace Cartography.Template
{
    using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using td.db.orm;
using td.forest.task.linker;
using Utilities;

    [ProgId("Cartography.Template.cmdSaveTemplate"), ClassInterface(ClassInterfaceType.None), Guid("fa7e5568-528d-4952-ab22-3e62c5b84352")]
    public sealed class cmdSaveTemplate : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public cmdSaveTemplate()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }
        public DB2LayerModelManager DMM { get { return DBServiceFactory<DB2LayerModelManager>.Service; } }
        public override void OnClick()
        {
            DirectoryInfo info;
            string path = UtilFactory.GetConfigOpt().RootPath + @"\Template\CustomTemplate";
            if (Directory.Exists(path))
            {
                info = new DirectoryInfo(path);
            }
            else
            {
                info = Directory.CreateDirectory(path);
            }
            FileInfo[] files = info.GetFiles();
            int num = 0;
            foreach (FileInfo info2 in files)
            {
                string name = info2.Name;
                int index = name.IndexOf(".");
                if (index >= 0)
                {
                    name = name.Substring(0, index);
                }
                int num3 = Convert.ToInt32(name);
                if (num3 > num)
                {
                    num = num3;
                }
            }
            string str3 = ((num + 1)).ToString() + ".mxt";
            try
            {
                IMapDocument document = new MapDocumentClass();
                document.New(path + @"\" + str3);
                document.ReplaceContents((IMxdContents) this.m_hookHelper.PageLayout);
                document.Save(false, true);
                MessageBox.Show("保存模板成功！", "保存模板");
            }
            catch
            {
                MessageBox.Show("保存模板失败！", "保存模板");
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                if (this.m_hookHelper == null)
                {
                    return false;
                }
                if (this.m_hookHelper.PageLayout == null)
                {
                    return false;
                }
                return base.Enabled;
            }
        }
    }
}

