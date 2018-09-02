namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FileGeoDataSelectFrm : XtraForm
    {
        private SimpleButton bnt_accept;
        private SimpleButton bnt_cancel;
        private IContainer components;
        private FolderBrowserDialog folderBrowserDialog1;
        private LabelControl labelControl1;
        private ButtonEdit txt_filegdbpath;

        public FileGeoDataSelectFrm()
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
            this.txt_filegdbpath = new ButtonEdit();
            this.labelControl1 = new LabelControl();
            this.bnt_accept = new SimpleButton();
            this.bnt_cancel = new SimpleButton();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            this.txt_filegdbpath.Properties.BeginInit();
            base.SuspendLayout();
            this.txt_filegdbpath.Location = new Point(0x7e, 0x1d);
            this.txt_filegdbpath.Name = "txt_filegdbpath";
            this.txt_filegdbpath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txt_filegdbpath.Size = new Size(0x157, 0x15);
            this.txt_filegdbpath.TabIndex = 0;
            this.txt_filegdbpath.ButtonClick += new ButtonPressedEventHandler(this.txt_filegdbpath_ButtonClick);
            this.labelControl1.Location = new Point(12, 0x20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x6c, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "选择文件数据库路径";
//            this.bnt_accept.DialogResult = DialogResult.OK;
            this.bnt_accept.Location = new Point(0x12b, 0x4c);
            this.bnt_accept.Name = "bnt_accept";
            this.bnt_accept.Size = new Size(0x4b, 0x17);
            this.bnt_accept.TabIndex = 2;
            this.bnt_accept.Text = "确定...";
//            this.bnt_cancel.DialogResult = DialogResult.Cancel;
            this.bnt_cancel.Location = new Point(0x18a, 0x4c);
            this.bnt_cancel.Name = "bnt_cancel";
            this.bnt_cancel.Size = new Size(0x4b, 0x17);
            this.bnt_cancel.TabIndex = 3;
            this.bnt_cancel.Text = "取消";
            this.folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.bnt_cancel;
            base.ClientSize = new Size(0x1f6, 0x6f);
            base.Controls.Add(this.bnt_cancel);
            base.Controls.Add(this.bnt_accept);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.txt_filegdbpath);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FileGeoDataSelectFrm";
            this.Text = "选择本地文件数据库路径";
            this.txt_filegdbpath.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void txt_filegdbpath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                this.txt_filegdbpath.Text = this.folderBrowserDialog1.SelectedPath;
            }
            else
            {
                this.txt_filegdbpath.Text = string.Empty;
            }
        }

        public string FileGDBPath
        {
            get
            {
                return this.txt_filegdbpath.Text;
            }
            set
            {
                this.txt_filegdbpath.Text = value;
            }
        }
    }
}

