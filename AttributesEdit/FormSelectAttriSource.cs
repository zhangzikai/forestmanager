namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;

    public class FormSelectAttriSource : FormBase3
    {
        private SimpleButton btnCancel;
        private SimpleButton btnOK;
        private IContainer components;
        private LabelControl labelControl1;
        private IList<IFeature> m_CombineFeatures;
        private IHookHelper m_hookHelper;
        private int m_Index = -1;
        private IFeature m_NewFeature;
        private RadioGroup radioGroup1;

        public FormSelectAttriSource(IList<IFeature> pList, ref IFeature resultFeature, object pHook)
        {
            this.InitializeComponent();
            this.m_CombineFeatures = pList;
            this.m_NewFeature = resultFeature;
            this.m_hookHelper = new HookHelperClass();
            this.m_hookHelper.Hook = pHook;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.radioGroup1.SelectedIndex;
            this.m_Index = selectedIndex;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormSelectAttriSource_Load(object sender, EventArgs e)
        {
            this.InitRadioGroup();
        }

        private string GetXBID(IFeature pFeature, int index)
        {
            if (EditTask.KindCode.Substring(0, 2) == "05")
            {
                int num = index + 1;
                return (pFeature.OID + "_" + num.ToString());
            }
            object fieldValue = DataFuncs.GetFieldValue(pFeature, "HAR_SUB");
            if (fieldValue == null)
            {
                fieldValue = DataFuncs.GetFieldValue(pFeature, "AFF_SUB");
            }
            if (fieldValue == null)
            {
                fieldValue = DataFuncs.GetFieldValue(pFeature, "LQSQ_ID");
            }
            if (fieldValue == null)
            {
                int num2 = index + 1;
                return ("_" + num2.ToString());
            }
            return fieldValue.ToString();
        }

        private void InitializeComponent()
        {
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(14, 37);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(173, 112);
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(148, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "选择合并后的新要素的属性 ";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(208, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(208, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 27);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormSelectAttriSource
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(288, 168);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioGroup1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormSelectAttriSource";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "要素合并";
            this.Load += new System.EventHandler(this.FormSelectAttriSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitRadioGroup()
        {
            if ((this.m_CombineFeatures != null) && (this.m_NewFeature != null))
            {
                RadioGroupItem item;
                for (int i = 0; i < this.m_CombineFeatures.Count; i++)
                {
                    item = new RadioGroupItem();
                    IFeature pFeature = this.m_CombineFeatures[i];
                    string xBID = this.GetXBID(pFeature, i);
                    item.Description = xBID;
                    this.radioGroup1.Properties.Items.Add(item);
                }
                item = new RadioGroupItem {
                    Description = "重新填写"
                };
                this.radioGroup1.Properties.Items.Add(item);
                this.radioGroup1.SelectedIndex = 0;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.radioGroup1.SelectedIndex;
            if (selectedIndex != this.m_CombineFeatures.Count)
            {
                IFeature feature = this.m_CombineFeatures[selectedIndex];
                IGeometry shapeCopy = feature.ShapeCopy;
                shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_hookHelper.ActiveView.FocusMap.SpatialReference);
                (this.m_hookHelper.Hook as IMapControl2).FlashShape(shapeCopy, 3, 300, null);
            }
        }

        public IList<IFeature> FeatureList
        {
            get
            {
                return this.m_CombineFeatures;
            }
        }

        public int SelectIndex
        {
            get
            {
                return this.m_Index;
            }
        }
    }
}

