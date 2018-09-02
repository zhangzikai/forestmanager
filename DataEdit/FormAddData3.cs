namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormAddData3 : FormBase2
    {
        public bool cancelflag = false;
        private IContainer components = null;
        public IFeatureWorkspace fWorkspace = null;
        private UserControlAddData3 userControlAddData31;

        public FormAddData3(IBasicMap map, IGroupLayer glayer, bool bAddFlag, IFeatureLayer player)
        {
            this.InitializeComponent();
            this.userControlAddData31.InitialValue(map, glayer, this, bAddFlag, player);
            this.userControlAddData31.TitleVisible = false;
            this.userControlAddData31.CancelVisible = true;
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
            this.userControlAddData31 = new UserControlAddData3();
            base.SuspendLayout();
            this.userControlAddData31.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlAddData31.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlAddData31.Appearance.Options.UseBackColor = true;
            this.userControlAddData31.CancelVisible = true;
            this.userControlAddData31.Dock = DockStyle.Fill;
            this.userControlAddData31.Horizontal = true;
            this.userControlAddData31.Location = new Point(0, 0);
            this.userControlAddData31.Name = "userControlAddData31";
            this.userControlAddData31.Padding = new Padding(0, 0, 0, 7);
            this.userControlAddData31.Size = new Size(0x1e4, 0x16a);
            this.userControlAddData31.TabIndex = 0;
            this.userControlAddData31.TitleVisible = false;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1e4, 0x16a);
            base.Controls.Add(this.userControlAddData31);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormAddData3";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "数据添加";
            base.Controls.SetChildIndex(this.userControlAddData31, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }
    }
}

