namespace AttributesEdit
{
    using ShapeEdit;
    using System;
    using System.Windows.Forms;

    public class UndoHandleClass : IAttributeUndo
    {
        private UserControl m_UserControl;

        public UndoHandleClass(UserControl pUserControl)
        {
            this.m_UserControl = pUserControl;
        }

        public DialogResult AttributeUndo()
        {
            UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
            if (userControl != null)
            {
                userControl.Undo();
            }
            return DialogResult.OK;
        }
    }
}

