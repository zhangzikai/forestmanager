namespace Cartography.Render
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class NewHeading : FormBase3
    {
        private string _heading;
        private SimpleButton btCancel;
        private SimpleButton btOk;
        private IContainer components;
        private LabelControl g;
        private TextEdit teNewHeading;

        public NewHeading()
        {
            this.InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
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
            this.teNewHeading = new DevExpress.XtraEditors.TextEdit();
            this.g = new DevExpress.XtraEditors.LabelControl();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.teNewHeading.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // teNewHeading
            // 
            this.teNewHeading.Location = new System.Drawing.Point(14, 30);
            this.teNewHeading.Name = "teNewHeading";
            this.teNewHeading.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.teNewHeading.Properties.Mask.IgnoreMaskBlank = false;
            this.teNewHeading.Properties.Mask.ShowPlaceHolders = false;
            this.teNewHeading.Size = new System.Drawing.Size(198, 20);
            this.teNewHeading.TabIndex = 0;
            this.teNewHeading.TextChanged += new System.EventHandler(this.teNewHeading_TextChanged);
            // 
            // g
            // 
            this.g.Location = new System.Drawing.Point(15, 7);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(64, 14);
            this.g.TabIndex = 1;
            this.g.Text = "请输入标题:";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(222, 28);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(222, 58);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // NewHeading
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(311, 89);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.g);
            this.Controls.Add(this.teNewHeading);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewHeading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新标题";
            ((System.ComponentModel.ISupportInitialize)(this.teNewHeading.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void teNewHeading_TextChanged(object sender, EventArgs e)
        {
            this._heading = this.teNewHeading.Text;
        }

        public string Heading
        {
            get
            {
                return this._heading;
            }
            set
            {
                this.teNewHeading.Text = value;
            }
        }
    }
}

