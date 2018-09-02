namespace DataEdit
{
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSaveData : FormBase2
    {
        private IContainer components = null;
        public ArrayList LayerList = null;
        public ArrayList PathList = null;
        public UserControlSaveData userControlSaveData1;

        public FormSaveData(string datasetname, ArrayList pLayerList, ISpatialReference pSpatialReference, bool bSaveFlag)
        {
            this.InitializeComponent();
            this.userControlSaveData1.InitialValue(datasetname, pLayerList, pSpatialReference, this, bSaveFlag);
            this.userControlSaveData1.TitleVisible = false;
            this.userControlSaveData1.CancelVisible = true;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormSaveData));
            this.userControlSaveData1 = new UserControlSaveData();
            base.SuspendLayout();
            this.userControlSaveData1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlSaveData1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlSaveData1.Appearance.Options.UseBackColor = true;
            this.userControlSaveData1.CancelVisible = false;
            this.userControlSaveData1.Dock = DockStyle.Fill;
            this.userControlSaveData1.Horizontal = true;
            this.userControlSaveData1.Location = new System.Drawing.Point(0, 0);
            this.userControlSaveData1.Name = "userControlSaveData1";
            this.userControlSaveData1.Padding = new Padding(6);
            this.userControlSaveData1.Size = new Size(0x202, 0x16a);
            this.userControlSaveData1.TabIndex = 1;
            this.userControlSaveData1.TitleVisible = true;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x202, 0x16a);
            base.Controls.Add(this.userControlSaveData1);
//            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormSaveData";
            this.Text = "保存";
            base.Controls.SetChildIndex(this.userControlSaveData1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }
    }
}

