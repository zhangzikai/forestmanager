namespace AttributesEdit
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ShapeEdit;
    using System;
    using System.Windows.Forms;

    public class AddHandleClass : IAttributeAdd
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private UserControl m_UserControl;

        public AddHandleClass(object hook, UserControl pUserControl)
        {
            this.m_hookHelper.Hook = hook;
            this.m_UserControl = pUserControl;
        }

        public DialogResult AttributeAdd(ref IFeature pFeature)
        {
            if (pFeature == null)
            {
                return DialogResult.OK;
            }
            DialogResult oK = DialogResult.OK;
            UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
            if (userControl != null)
            {
                userControl.AddAttributes(pFeature, this.m_hookHelper.Hook);
            }
            return oK;
        }
    }
}

