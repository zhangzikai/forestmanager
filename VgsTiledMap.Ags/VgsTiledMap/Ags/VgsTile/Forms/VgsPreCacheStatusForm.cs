namespace VgsTiledMap.Ags.VgsTile.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using VgsTiledMap.Ags;

    public class VgsPreCacheStatusForm : Form
    {
        private Precache _Precache;
        private IContainer components;
        private Label LabelStatus;

        public VgsPreCacheStatusForm(Precache precache)
        {
            this.InitializeComponent();
            this._Precache = precache;
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
            this.LabelStatus = new Label();
            base.SuspendLayout();
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new Point(12, 9);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new Size(0x41, 12);
            this.LabelStatus.TabIndex = 1;
            this.LabelStatus.Text = "下载状态：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x184, 0x27);
            base.Controls.Add(this.LabelStatus);
//            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "VgsPreCacheStatusForm";
            this.Text = "下载状态";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void SetStatusMessage(string message)
        {
            this.LabelStatus.Text = string.Format("下载状态: {0}", message);
        }
    }
}

