namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.ComponentModel;

    public class ZLRepositoryItemSpinEdit : RepositoryItemSpinEdit
    {
        private IContainer components;
        private RepositoryItemSpinEdit fProperties;
        private int m_Scale;

        public ZLRepositoryItemSpinEdit()
        {
            this.InitializeComponent();
        }

        private void baseEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            SpinEdit edit = (SpinEdit) sender;
            if ((edit.Properties.IsFloatValue && (this.m_Scale != 0)) && (e.NewValue != null))
            {
                string str = e.NewValue.ToString();
                int index = str.IndexOf(".");
                if ((index > 0) && (((str.Length - index) - 1) > this.m_Scale))
                {
                    e.Cancel = true;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.fProperties = new RepositoryItemSpinEdit();
            this.fProperties.BeginInit();
            this.fProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.fProperties.Name = "fProperties";
            this.fProperties.EndInit();
        }

        public int EditScale
        {
            get
            {
                return this.m_Scale;
            }
            set
            {
                this.m_Scale = value;
                RepositoryItemBaseSpinEdit edit = this;
                edit.EditValueChanging += new ChangingEventHandler(this.baseEdit_EditValueChanging);
            }
        }
    }
}

