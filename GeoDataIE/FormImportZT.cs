namespace GeoDataIE
{
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class FormImportZT : FormBase3
    {
        private IContainer components;

        public FormImportZT()
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

        private void InitializeComponent()
        {
            this.components = new Container();
//            base.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "FormImportZT";
        }
    }
}

