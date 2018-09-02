namespace DataEdit
{
    using ESRI.ArcGIS.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 编辑--获取属性窗体
    /// </summary>
    public class FormPropertyByXB2 : FormBase2
    {
        private IContainer components = null;
        private IHookHelper mHookHelper;
        private UserControlPropertyByXB2 userControlPropertyByXB2;

        /// <summary>
        /// 编辑--获取属性窗体:构造器
        /// </summary>
        /// <param name="hook"></param>
        /// <param name="sEditKind"></param>
        public FormPropertyByXB2(object hook, string sEditKind)
        {
            this.InitializeComponent();
            this.mHookHelper = new HookHelperClass();
            this.mHookHelper.Hook = hook;
            this.userControlPropertyByXB2.Dock = DockStyle.Fill;
            this.userControlPropertyByXB2.InitialValue(this.mHookHelper, sEditKind);
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
            this.userControlPropertyByXB2 = new DataEdit.UserControlPropertyByXB2();
            this.SuspendLayout();
            // 
            // userControlPropertyByXB2
            // 
            this.userControlPropertyByXB2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlPropertyByXB2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlPropertyByXB2.Appearance.Options.UseBackColor = true;
            this.userControlPropertyByXB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPropertyByXB2.Location = new System.Drawing.Point(0, 0);
            this.userControlPropertyByXB2.Name = "userControlPropertyByXB2";
            this.userControlPropertyByXB2.Padding = new System.Windows.Forms.Padding(6);
            this.userControlPropertyByXB2.Size = new System.Drawing.Size(371, 412);
            this.userControlPropertyByXB2.TabIndex = 1;
            // 
            // FormPropertyByXB2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(371, 412);
            this.Controls.Add(this.userControlPropertyByXB2);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPropertyByXB2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提取小班属性信息";
            this.Controls.SetChildIndex(this.userControlPropertyByXB2, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

