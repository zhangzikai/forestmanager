namespace Cartography.Business
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class OperatorSelect : FormBase3
    {
        private CheckButton btCancel;
        private SimpleButton btDelete;
        private SimpleButton btEdit;
        private IContainer components;
        private LabelControl lbTip;

        public OperatorSelect()
        {
            this.InitializeComponent();
        }

        private void btCancel_CheckedChanged(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.No;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Yes;
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
            this.lbTip = new DevExpress.XtraEditors.LabelControl();
            this.btEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.CheckButton();
            this.SuspendLayout();
            // 
            // lbTip
            // 
            this.lbTip.Location = new System.Drawing.Point(22, 26);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(0, 14);
            this.lbTip.TabIndex = 0;
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(19, 65);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(87, 27);
            this.btEdit.TabIndex = 1;
            this.btEdit.Text = "编辑";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(127, 65);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(87, 27);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "删除";
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(236, 65);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.CheckedChanged += new System.EventHandler(this.btCancel_CheckedChanged);
            // 
            // OperatorSelect
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(341, 103);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.lbTip);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择操作";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string Tip
        {
            set
            {
                this.lbTip.Text = value;
            }
        }
    }
}

