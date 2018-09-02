namespace TopologyCheck.UI
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;

    /// <summary>
    /// 狭长多边形检查工具类
    /// </summary>
    [ProgId("TopologyCheck.UI.CmdXCCheck"), ClassInterface(ClassInterfaceType.None), Guid("aef7f43c-52aa-47dd-b7d9-f2ccf2b8eea9")]
    public sealed class CmdXCPolygonCheck : BaseCommand
    {
        private IHookHelper m_hookHelper;

        /// <summary>
        /// 狭长多边形检查工具类
        /// </summary>
        public CmdXCPolygonCheck()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "狭长多边形检查";
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

        public override void OnClick()
        {
            FormXCPolygonCheck check = new FormXCPolygonCheck();
            check.Hook = this.m_hookHelper.Hook;
            check.StartPosition = FormStartPosition.CenterParent;
            check.Show();
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

        [ComRegisterFunction, ComVisible(false)]
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
                IFeatureLayer editLayer = EditTask.EditLayer;
                if (editLayer.FeatureClass == null)
                {
                    return false;
                }
                if (editLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
                {
                    return false;
                }
                return base.Enabled;
            }
        }
    }
}

