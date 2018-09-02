namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ForestProgressMessageBox : XtraMessageBoxForm
    {
        private IContainer components;
        private LabelControl lb_countProgress;
        private ProgressBarControl progress_info;
        private RichTextBox richEdit_progressInfo;

        public ForestProgressMessageBox()
        {
            this.InitializeComponent();
        }

        public ForestProgressMessageBox(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
        }

        public void AddProgressMessage(string msg)
        {
            this.richEdit_progressInfo.Text = this.richEdit_progressInfo.Text + msg + "\n";
            this.richEdit_progressInfo.Refresh();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ForestProgressMessageBox));
            this.progress_info = new ProgressBarControl();
            this.richEdit_progressInfo = new RichTextBox();
            this.lb_countProgress = new LabelControl();
            this.progress_info.Properties.BeginInit();
            base.SuspendLayout();
            this.progress_info.Location = new Point(0x15, 0x16);
            this.progress_info.Name = "progress_info";
            this.progress_info.Size = new Size(0x1b0, 0x15);
            this.progress_info.TabIndex = 0;
            this.richEdit_progressInfo.Location = new Point(0x15, 0x31);
            this.richEdit_progressInfo.Name = "richEdit_progressInfo";
            this.richEdit_progressInfo.Size = new Size(0x1b0, 0x9f);
            this.richEdit_progressInfo.TabIndex = 1;
            this.richEdit_progressInfo.Text = "";
            this.lb_countProgress.Location = new Point(0x15, 0xd7);
            this.lb_countProgress.Name = "lb_countProgress";
            this.lb_countProgress.Size = new Size(0, 14);
            this.lb_countProgress.TabIndex = 2;
            base.ClientSize = new Size(0x1d1, 0xec);
            base.ControlBox = false;
            base.Controls.Add(this.lb_countProgress);
            base.Controls.Add(this.richEdit_progressInfo);
            base.Controls.Add(this.progress_info);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ForestProgressMessageBox";
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.progress_info.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void initStatus()
        {
            this.progress_info.Position = 0;
            this.richEdit_progressInfo.Text = string.Empty;
        }

        public void OnProgressDataChanged(object sender, TaskEventArgs e)
        {
            if (base.InvokeRequired)
            {
                TaskEventHandler method = new TaskEventHandler(this.OnProgressDataChanged);
                base.BeginInvoke(method, new object[] { sender, e });
            }
            else
            {
                if (e.Result is TaskResult)
                {
                    TaskResult result = e.Result as TaskResult;
                    if (result != null)
                    {
                        if (e.Progress > 0)
                        {
                            this.progress_info.Position = e.Progress;
                        }
                        if (!string.IsNullOrEmpty(result.Msg))
                        {
                            this.richEdit_progressInfo.Text = result.Msg + "\n" + this.richEdit_progressInfo.Text;
                            this.richEdit_progressInfo.Refresh();
                        }
                        if (e.Progress >= 0x63)
                        {
                            base.Close();
                        }
                    }
                }
                if (e.Result is DataLoadInfo)
                {
                    DataLoadInfo info = e.Result as DataLoadInfo;
                    this.lb_countProgress.Text = string.Format("要素导入{0}/{1},导入时发生错误要素{2}", info.Current, info.Count, info.ErroCount);
                }
            }
        }
    }
}

