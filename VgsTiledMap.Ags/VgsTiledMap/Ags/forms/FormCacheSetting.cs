namespace VgsTiledMap.Ags.forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormCacheSetting : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtCurDir;

        public FormCacheSetting()
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
            this.groupBox1 = new GroupBox();
            this.txtCurDir = new TextBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtCurDir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x17e, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前设置";
            this.txtCurDir.Location = new Point(0x59, 20);
            this.txtCurDir.Name = "txtCurDir";
            this.txtCurDir.ReadOnly = true;
            this.txtCurDir.Size = new Size(0x11f, 0x15);
            this.txtCurDir.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("SimSun", 9f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.label3.ForeColor = Color.Red;
            this.label3.Location = new Point(0x57, 0x44);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xb9, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "已占用20M，C盘剩余空间3500M";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 0x44);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "磁盘开销：";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 0x17);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4d, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "缓存文件夹：";
            this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox2.Location = new Point(12, 0x76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x17e, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前设置";
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
//            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x13f, 0xe8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
//            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0xee, 0xe8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            base.AcceptButton = this.btnOK;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(0x196, 0x10b);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormCacheSetting";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "缓存设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

