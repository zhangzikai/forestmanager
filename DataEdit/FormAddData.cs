namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormAddData : FormBase2
    {
        private IContainer components = null;
        public ArrayList LayerList = null;
        public ArrayList PathList = null;
        private UserControlAddData userControlAddData1;

        public FormAddData(IBasicMap map, IGroupLayer glayer, bool bAddFlag, IFeatureLayer player)
        {
            this.InitializeComponent();
            this.userControlAddData1.InitialValue(map, glayer, this, bAddFlag, player);
            this.userControlAddData1.TitleVisible = false;
            this.userControlAddData1.CancelVisible = true;
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
            this.userControlAddData1 = new UserControlAddData();
            base.SuspendLayout();
            this.userControlAddData1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlAddData1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlAddData1.Appearance.Options.UseBackColor = true;
            this.userControlAddData1.CancelVisible = true;
            this.userControlAddData1.Dock = DockStyle.Fill;
            this.userControlAddData1.Horizontal = true;
            this.userControlAddData1.Location = new Point(0, 0);
            this.userControlAddData1.Name = "userControlAddData1";
            this.userControlAddData1.Size = new Size(0x26a, 0x180);
            this.userControlAddData1.TabIndex = 1;
            this.userControlAddData1.TitleVisible = false;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x26a, 0x180);
            base.Controls.Add(this.userControlAddData1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormAddData";
            this.Text = "添加地图数据";
            base.Controls.SetChildIndex(this.userControlAddData1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }
    }
}

