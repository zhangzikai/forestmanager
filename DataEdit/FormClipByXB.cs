namespace DataEdit
{
    using ESRI.ArcGIS.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 批量数据裁剪窗体
    /// </summary>
    public class FormClipByXB : FormBase2
    {
        private IContainer components = null;
        private IHookHelper mHookHelper;
        private UserControlClipByXB userControlClipByXB1;

        /// <summary>
        /// 批量数据裁剪窗体:构造器
        /// </summary>
        /// <param name="hook"></param>
        /// <param name="sEditKind"></param>
        public FormClipByXB(object hook, string sEditKind)
        {
            this.InitializeComponent();
            this.mHookHelper = new HookHelperClass();
            this.mHookHelper.Hook = hook;
            this.userControlClipByXB1.InitialValue(this.mHookHelper, sEditKind);
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
            this.userControlClipByXB1 = new DataEdit.UserControlClipByXB();
            this.SuspendLayout();
            // 
            // userControlClipByXB1
            // 
            this.userControlClipByXB1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlClipByXB1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlClipByXB1.Appearance.Options.UseBackColor = true;
            this.userControlClipByXB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlClipByXB1.Location = new System.Drawing.Point(0, 0);
            this.userControlClipByXB1.Name = "userControlClipByXB1";
            this.userControlClipByXB1.Padding = new System.Windows.Forms.Padding(6);
            this.userControlClipByXB1.Size = new System.Drawing.Size(386, 407);
            this.userControlClipByXB1.TabIndex = 1;
            // 
            // FormClipByXB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(386, 407);
            this.Controls.Add(this.userControlClipByXB1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClipByXB";
            this.Text = "批量数据裁切";
            this.Controls.SetChildIndex(this.userControlClipByXB1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

