namespace AttributesEdit
{
    using ESRI.ArcGIS.Geodatabase;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class DeleteHandleClass : IAttributeDelete
    {
        private UserControl m_UserControl;

        public DeleteHandleClass(UserControl pUserControl)
        {
            this.m_UserControl = pUserControl;
        }

        public DialogResult AttributeDelete(IFeature pFeature)
        {
            if (pFeature == null)
            {
                return DialogResult.Cancel;
            }
            IList pList = new ArrayList {
                pFeature
            };
            UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
            if (userControl != null)
            {
                userControl.DeleteFeatures(pList);
            }
            return DialogResult.OK;
        }
    }
}

