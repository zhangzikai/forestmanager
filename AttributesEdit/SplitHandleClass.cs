namespace AttributesEdit
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class SplitHandleClass : IAttributeSplit
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private UserControl m_UserControl;

        public SplitHandleClass(object hook, UserControl pUserControl)
        {
            this.m_hookHelper.Hook = hook;
            this.m_UserControl = pUserControl;
        }

        public DialogResult AttributeSplit(IFeature srcFeature, ref List<IFeature> pFeatureList)
        {
            pFeatureList.Add(srcFeature);
            UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
            if (userControl != null)
            {
                userControl.CutFeature(pFeatureList, this.m_hookHelper.Hook);
            }
            return DialogResult.OK;
        }
    }
}

