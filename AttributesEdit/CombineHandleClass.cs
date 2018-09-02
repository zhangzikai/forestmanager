namespace AttributesEdit
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class CombineHandleClass : IAttributeCombine
    {
        private IHookHelper m_hookHelper = new HookHelperClass();
        private UserControl m_UserControl;

        public CombineHandleClass(object hook, UserControl pUserControl)
        {
            this.m_hookHelper.Hook = hook;
            this.m_UserControl = pUserControl;
        }

        public DialogResult AttributeCombine(List<IFeature> pList, ref IFeature resultFeature)
        {
            FormSelectAttriSource source = new FormSelectAttriSource(pList, ref resultFeature, this.m_hookHelper.Hook);
            if (source.ShowDialog() != DialogResult.OK)
            {
                return DialogResult.Cancel;
            }
            UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
            if (userControl != null)
            {
                userControl.CombineFeatures(pList, resultFeature, source.SelectIndex, this.m_hookHelper.Hook);
            }
            return DialogResult.OK;
        }
    }
}

