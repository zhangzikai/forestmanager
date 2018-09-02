namespace Cartography.Render
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DevLabelRenderExtent2 : FormBase3
    {
        private IContainer components;
        private string m_Label;
        private IGeoFeatureLayer m_Layer;
        private PanelControl panelControl3;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonOK;
        private vForestAnnoControl2 vForestAnnoControl21;

        public DevLabelRenderExtent2()
        {
            this.InitializeComponent();
        }

        private void DevLabelRenderExtent2_Load(object sender, EventArgs e)
        {
            this.vForestAnnoControl21.TargetLayer = this.m_Layer;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Init(ILayer pLayer, string sLabel)
        {
            this.m_Layer = (IGeoFeatureLayer) pLayer;
            this.m_Label = sLabel;
        }

        private void InitializeComponent()
        {
            this.vForestAnnoControl21 = new Cartography.Render.vForestAnnoControl2();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // vForestAnnoControl21
            // 
            this.vForestAnnoControl21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vForestAnnoControl21.Location = new System.Drawing.Point(0, 0);
            this.vForestAnnoControl21.Name = "vForestAnnoControl21";
            this.vForestAnnoControl21.Size = new System.Drawing.Size(494, 305);
            this.vForestAnnoControl21.TabIndex = 0;
            this.vForestAnnoControl21.TargetLayer = null;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonCancel);
            this.panelControl3.Controls.Add(this.simpleButtonOK);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 305);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(494, 56);
            this.panelControl3.TabIndex = 3;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(275, 12);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(149, 12);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // DevLabelRenderExtent2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(494, 361);
            this.Controls.Add(this.vForestAnnoControl21);
            this.Controls.Add(this.panelControl3);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevLabelRenderExtent2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分子式标注";
            this.Load += new System.EventHandler(this.DevLabelRenderExtent2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.m_Label = this.vForestAnnoControl21.LabelExpression;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        public string Label
        {
            get
            {
                return this.m_Label;
            }
        }
    }
}

