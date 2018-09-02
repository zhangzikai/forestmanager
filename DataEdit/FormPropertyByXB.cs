namespace DataEdit
{
    using ESRI.ArcGIS.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormPropertyByXB : FormBase2
    {
        private IContainer components = null;
        private IHookHelper mHookHelper;
        private UserControlPropertyByXB userControlPropertyByXB1;

        public FormPropertyByXB(object hook, string sEditKind)
        {
            this.InitializeComponent();
            this.mHookHelper = new HookHelperClass();
            this.mHookHelper.Hook = hook;
            this.userControlPropertyByXB1.Dock = DockStyle.Fill;
            this.userControlPropertyByXB1.InitialValue(this.mHookHelper, sEditKind);
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
            this.userControlPropertyByXB1 = new UserControlPropertyByXB();
            base.SuspendLayout();
            this.userControlPropertyByXB1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlPropertyByXB1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlPropertyByXB1.Appearance.Options.UseBackColor = true;
            this.userControlPropertyByXB1.Dock = DockStyle.Fill;
            this.userControlPropertyByXB1.Location = new Point(0, 0);
            this.userControlPropertyByXB1.Name = "userControlPropertyByXB1";
            this.userControlPropertyByXB1.Padding = new Padding(6);
            this.userControlPropertyByXB1.Size = new Size(0x174, 0x1a3);
            this.userControlPropertyByXB1.TabIndex = 1;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x173, 0x19c);
            base.Controls.Add(this.userControlPropertyByXB1);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormPropertyByXB";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "提取小班属性信息";
            base.Controls.SetChildIndex(this.userControlPropertyByXB1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }
    }
}

