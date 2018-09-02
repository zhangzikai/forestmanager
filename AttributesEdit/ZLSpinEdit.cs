namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class ZLSpinEdit : SpinEdit
    {
        private IContainer components;
        private RepositoryItemSpinEdit fProperties;
        private int m_Scale;

        public ZLSpinEdit()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DllImport("user32.dll ")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        private void InitializeComponent()
        {
            this.fProperties = new RepositoryItemSpinEdit();
            this.fProperties.BeginInit();
            base.SuspendLayout();
            this.fProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.fProperties.Name = "fProperties";
            base.Size = new Size(0x84, 0x15);
            this.fProperties.EndInit();
            base.ResumeLayout(false);
        }

        [DllImport("user32.dll ")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        private void ZLSpinEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((base.Properties.IsFloatValue && (this.m_Scale != 0)) && (e.NewValue != null))
            {
                string str = e.NewValue.ToString();
                int index = str.IndexOf(".");
                if ((index > 0) && (((str.Length - index) - 1) > this.m_Scale))
                {
                    e.Cancel = true;
                }
            }
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
                base.EditValueChanging += new ChangingEventHandler(this.ZLSpinEdit_EditValueChanging);
            }
        }
    }
}

