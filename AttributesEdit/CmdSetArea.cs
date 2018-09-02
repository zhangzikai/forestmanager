namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using ShapeEdit;
    using System;
    using System.Runtime.InteropServices;

    [ProgId("AttributesEdit.CmdSetArea"), ClassInterface(ClassInterfaceType.None), Guid("22673c9e-7f17-4bfd-9e56-8c95b55759c3")]
    public sealed class CmdSetArea : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public CmdSetArea()
        {
            base.m_category = "";
            base.m_caption = "面积平差";
            base.m_message = "面积平差";
            base.m_toolTip = "面积平差";
            base.m_name = "";
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            FormSetArea area = new FormSetArea();
            if (area.InitLayerArea(this.m_hookHelper.Hook))
            {
                area.ShowDialog();
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

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                return ((Editor.UniqueInstance.TargetLayer != null) && (Editor.UniqueInstance.TargetLayer.FeatureClass != null));
            }
        }
    }
}

