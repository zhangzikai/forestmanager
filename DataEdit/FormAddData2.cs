namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormAddData2 : FormBase2
    {
        private IContainer components = null;
        public ArrayList LayerList = null;
        public ArrayList PathList = null;
        private UserControlAddData2 userControlAddData21;

        public FormAddData2(IBasicMap map, IGroupLayer glayer, bool bAddFlag, IFeatureLayer player)
        {
            this.InitializeComponent();
            this.userControlAddData21.InitialValue(map, glayer, this, bAddFlag, player);
            this.userControlAddData21.TitleVisible = false;
            this.userControlAddData21.CancelVisible = true;
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
            this.userControlAddData21 = new DataEdit.UserControlAddData2();
            this.SuspendLayout();
            // 
            // userControlAddData21
            // 
            this.userControlAddData21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlAddData21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlAddData21.Appearance.Options.UseBackColor = true;
            this.userControlAddData21.CancelVisible = false;
            this.userControlAddData21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAddData21.Horizontal = true;
            this.userControlAddData21.Location = new System.Drawing.Point(0, 0);
            this.userControlAddData21.Name = "userControlAddData21";
            this.userControlAddData21.Size = new System.Drawing.Size(681, 425);
            this.userControlAddData21.TabIndex = 0;
            this.userControlAddData21.TitleVisible = false;
            // 
            // FormAddData2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(681, 425);
            this.Controls.Add(this.userControlAddData21);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormAddData2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加";
            this.Controls.SetChildIndex(this.userControlAddData21, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

