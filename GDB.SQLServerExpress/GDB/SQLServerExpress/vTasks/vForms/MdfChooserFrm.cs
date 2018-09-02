namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class MdfChooserFrm : Form
    {
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private OpenFileDialog openFileDialog1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private ButtonEdit txt_logpath;
        private ButtonEdit txt_mdfpath;

        public MdfChooserFrm()
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
            this.openFileDialog1 = new OpenFileDialog();
            this.txt_mdfpath = new ButtonEdit();
            this.txt_logpath = new ButtonEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.txt_mdfpath.Properties.BeginInit();
            this.txt_logpath.Properties.BeginInit();
            base.SuspendLayout();
            this.openFileDialog1.FileName = "openFileDialog1";
            this.txt_mdfpath.Location = new Point(0x8f, 13);
            this.txt_mdfpath.Name = "txt_mdfpath";
            this.txt_mdfpath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txt_mdfpath.Size = new Size(0x13a, 0x15);
            this.txt_mdfpath.TabIndex = 0;
            this.txt_mdfpath.ButtonClick += new ButtonPressedEventHandler(this.txt_mdfpath_ButtonClick);
            this.txt_logpath.Location = new Point(0x8f, 50);
            this.txt_logpath.Name = "txt_logpath";
            this.txt_logpath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txt_logpath.Size = new Size(0x13a, 0x15);
            this.txt_logpath.TabIndex = 1;
            this.txt_logpath.ButtonClick += new ButtonPressedEventHandler(this.txt_logpath_ButtonClick);
            this.simpleButton1.Location = new Point(0xff, 0x4d);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x58, 0x21);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0x170, 0x4d);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x58, 0x21);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl1.Location = new Point(0x12, 0x12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x63, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "选择MDF文件路径:";
            this.labelControl2.Location = new Point(0x12, 0x35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "选择LDF文件路径:";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1da, 120);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.txt_logpath);
            base.Controls.Add(this.txt_mdfpath);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "MdfChooserFrm";
            this.Text = "选择MDF数据文件路径";
            this.txt_mdfpath.Properties.EndInit();
            this.txt_logpath.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void txt_logpath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.openFileDialog1.Filter = "GeoLDF日志文件(*.LDF)|*.LDF";
            this.openFileDialog1.Title = "打开SQLServer数据库文件";
            if (DialogResult.OK == this.openFileDialog1.ShowDialog())
            {
                this.txt_logpath.Text = this.openFileDialog1.FileName;
                this.LDFPath = this.openFileDialog1.FileName;
            }
        }

        private void txt_mdfpath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.openFileDialog1.Filter = "GeoMDF数据文件(*.MDF)|*.mdf";
            this.openFileDialog1.Title = "打开SQLServer数据库文件";
            if (DialogResult.OK == this.openFileDialog1.ShowDialog())
            {
                this.txt_mdfpath.Text = this.openFileDialog1.FileName;
                this.MDFPath = this.openFileDialog1.FileName;
            }
        }

        public string LDFPath { get; set; }

        public string MDFPath { get; set; }
    }
}

