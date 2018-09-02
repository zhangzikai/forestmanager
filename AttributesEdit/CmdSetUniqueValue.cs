namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using ShapeEdit;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// 编辑--批量修改工具类
    /// </summary>
    [ProgId("AttributesEdit.CmdSetUniqueValue"), Guid("fc59f4f5-3f76-49c2-874b-5c44ca9537a3"), ClassInterface(ClassInterfaceType.None)]
    public sealed class CmdSetUniqueValue : BaseCommand
    {
        private IHookHelper m_hookHelper;

        /// <summary>
        /// 编辑--批量修改工具类：构造器
        /// </summary>
        public CmdSetUniqueValue()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "批量设置唯一值";
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
            new FormSetUniqueValue().ShowDialog();
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
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    return false;
                }
                return ((Editor.UniqueInstance.TargetLayer != null) && (Editor.UniqueInstance.TargetLayer.FeatureClass != null));
            }
        }
    }
}

