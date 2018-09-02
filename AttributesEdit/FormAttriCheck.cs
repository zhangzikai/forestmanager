namespace AttributesEdit
{
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormAttriCheck : FormBase2
    {
        private IContainer components;
        private UserControlAttriCheck userControlAttriCheck1;

        public FormAttriCheck()
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

        public void Init(IFeatureLayer pFLayer, object hook)
        {
            this.userControlAttriCheck1.Init(pFLayer, hook);
        }

        private void InitializeComponent()
        {
            this.userControlAttriCheck1 = new AttributesEdit.UserControlAttriCheck();
            this.SuspendLayout();
            // 
            // userControlAttriCheck1
            // 
            this.userControlAttriCheck1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlAttriCheck1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlAttriCheck1.Appearance.Options.UseBackColor = true;
            this.userControlAttriCheck1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAttriCheck1.Location = new System.Drawing.Point(0, 0);
            this.userControlAttriCheck1.Name = "userControlAttriCheck1";
            this.userControlAttriCheck1.Size = new System.Drawing.Size(341, 388);
            this.userControlAttriCheck1.TabIndex = 1;
            // 
            // FormAttriCheck
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(341, 388);
            this.Controls.Add(this.userControlAttriCheck1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormAttriCheck";
            this.Text = "逻辑检验";
            this.Controls.SetChildIndex(this.userControlAttriCheck1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

