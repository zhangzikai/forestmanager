namespace TopologyCheck.UI
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 拓扑校验规则设置窗体
    /// </summary>
    public class RulerSet : FormBase3
    {
        private SimpleButton btCancel;
        private SimpleButton btReset;
        private SimpleButton btSave;
        private CheckEdit ceBoundaryBeyond;
        private CheckEdit ceLayersOverlap;
        private CheckEdit cePlolygonArea;
        private CheckEdit cePolygonAcuteangle;
        private CheckEdit cePolygonGap;
        private CheckEdit cePolygonOverlap;
        private CheckEdit cePolygonSelf;
        /// <summary>
        /// 重复点
        /// </summary>
        private CheckEdit ceRepeatPoint;
        private CheckedListBoxControl clbcYears;
        private IContainer components;
        private GroupBox gpRuler;
        private LabelControl lbSquare;
        private LabelControl lcDegree;
        private TextEdit teAngle;
        private TextEdit teArea;

        /// <summary>
        /// 拓扑校验规则设置窗体:构造器
        /// </summary>
        public RulerSet()
        {
            this.InitializeComponent();
            this.Init();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReset_Click(object sender, EventArgs e)
        {
            this.ceBoundaryBeyond.Checked = this.cePlolygonArea.Checked = this.cePolygonAcuteangle.Checked = this.cePolygonGap.Checked = this.cePolygonOverlap.Checked = this.cePolygonSelf.Checked = this.ceRepeatPoint.Checked = this.ceLayersOverlap.Checked = false;
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            if (this.cePlolygonArea.Enabled)
            {
                if (this.cePlolygonArea.Checked)
                {
                    configOpt.SetConfigValue("Area", "1");
                    configOpt.SetConfigValue("AreaValue", this.teArea.Text);
                }
                else
                {
                    configOpt.SetConfigValue("Area", "0");
                    configOpt.SetConfigValue("AreaValue", this.teArea.Text);
                }
            }
            if (this.cePolygonAcuteangle.Enabled)
            {
                if (this.cePolygonAcuteangle.Checked)
                {
                    configOpt.SetConfigValue("Angle", "1");
                    configOpt.SetConfigValue("AngleValue", this.teAngle.Text);
                }
                else
                {
                    configOpt.SetConfigValue("Angle", "0");
                    configOpt.SetConfigValue("AngleValue", this.teAngle.Text);
                }
            }
            if (this.ceRepeatPoint.Enabled)
            {
                if (this.ceRepeatPoint.Checked)
                {
                    configOpt.SetConfigValue("RepeatPoint", "1");
                }
                else
                {
                    configOpt.SetConfigValue("RepeatPoint", "0");
                }
            }
            if (this.cePolygonSelf.Enabled)
            {
                if (this.cePolygonSelf.Checked)
                {
                    configOpt.SetConfigValue("SelfIntersect", "1");
                }
                else
                {
                    configOpt.SetConfigValue("SelfIntersect", "0");
                }
            }
            if (this.cePolygonOverlap.Enabled)
            {
                if (this.cePolygonOverlap.Checked)
                {
                    configOpt.SetConfigValue("Overlap", "1");
                }
                else
                {
                    configOpt.SetConfigValue("Overlap", "0");
                }
            }
            if (this.ceBoundaryBeyond.Checked)
            {
                configOpt.SetConfigValue("BeyondBoundary", "1");
            }
            else
            {
                configOpt.SetConfigValue("BeyondBoundary", "0");
            }
            if (this.cePolygonGap.Enabled)
            {
                if (this.cePolygonGap.Checked)
                {
                    configOpt.SetConfigValue("Gaps", "1");
                }
                else
                {
                    configOpt.SetConfigValue("Gaps", "0");
                }
            }
            configOpt.SetConfigValue("Set", "1");
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void ceLayersOverlap_CheckedChanged(object sender, EventArgs e)
        {
            this.clbcYears.Enabled = this.ceLayersOverlap.Checked;
        }

        private void cePlolygonArea_CheckedChanged(object sender, EventArgs e)
        {
            this.teArea.Enabled = this.cePlolygonArea.Checked;
        }

        private void cePolygonAcuteangle_CheckedChanged(object sender, EventArgs e)
        {
            this.teAngle.Enabled = this.cePolygonAcuteangle.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 窗体加载数据初始化
        /// </summary>
        private void Init()
        {
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            string configValue = configOpt.GetConfigValue("AreaValue");
            if (string.IsNullOrEmpty(configValue))
            {
                this.teArea.Text = "667";
            }
            else
            {
                this.teArea.Text = configValue;
            }
            configValue = configOpt.GetConfigValue("AngleValue");
            if (string.IsNullOrEmpty(configValue))
            {
                this.teAngle.Text = "15";
            }
            else
            {
                this.teAngle.Text = configValue;
            }
            configValue = configOpt.GetConfigValue("Angle");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonAcuteangle.Checked = false;
                this.teAngle.Enabled = false;
            }
            configValue = configOpt.GetConfigValue("Area");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePlolygonArea.Checked = false;
                this.teArea.Enabled = false;
            }
            configValue = configOpt.GetConfigValue("RepeatPoint");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.ceRepeatPoint.Checked = false;
            }
            configValue = configOpt.GetConfigValue("SelfIntersect");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonSelf.Checked = false;
            }
            configValue = configOpt.GetConfigValue("Overlap");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonOverlap.Checked = false;
            }
            configValue = configOpt.GetConfigValue("BeyondBoundary");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.ceBoundaryBeyond.Checked = false;
            }
            configValue = configOpt.GetConfigValue("Gaps");
            if (string.IsNullOrEmpty(configValue) || (configValue == "0"))
            {
                this.cePolygonGap.Checked = false;
            }
            IFeatureLayer editLayer = EditTask.EditLayer;
            if ((editLayer != null) && (editLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon))
            {
                if (editLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    this.cePolygonSelf.Checked = false;
                    this.cePolygonSelf.Enabled = false;
                    this.cePlolygonArea.Checked = false;
                    this.cePlolygonArea.Enabled = false;
                    this.cePolygonGap.Checked = false;
                    this.cePolygonGap.Enabled = false;
                    this.cePolygonOverlap.Checked = false;
                    this.cePolygonOverlap.Enabled = false;
                }
                else
                {
                    this.ceRepeatPoint.Checked = false;
                    this.ceRepeatPoint.Enabled = false;
                    this.cePolygonSelf.Checked = false;
                    this.cePolygonSelf.Enabled = false;
                    this.cePlolygonArea.Checked = false;
                    this.cePlolygonArea.Enabled = false;
                    this.cePolygonAcuteangle.Checked = false;
                    this.cePolygonAcuteangle.Enabled = false;
                    this.cePolygonGap.Checked = false;
                    this.cePolygonGap.Enabled = false;
                    this.cePolygonOverlap.Checked = false;
                    this.cePolygonOverlap.Enabled = false;
                }
            }
        }

        private void InitializeComponent()
        {
            this.gpRuler = new System.Windows.Forms.GroupBox();
            this.clbcYears = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ceLayersOverlap = new DevExpress.XtraEditors.CheckEdit();
            this.ceBoundaryBeyond = new DevExpress.XtraEditors.CheckEdit();
            this.lcDegree = new DevExpress.XtraEditors.LabelControl();
            this.lbSquare = new DevExpress.XtraEditors.LabelControl();
            this.cePolygonGap = new DevExpress.XtraEditors.CheckEdit();
            this.teArea = new DevExpress.XtraEditors.TextEdit();
            this.cePlolygonArea = new DevExpress.XtraEditors.CheckEdit();
            this.teAngle = new DevExpress.XtraEditors.TextEdit();
            this.cePolygonAcuteangle = new DevExpress.XtraEditors.CheckEdit();
            this.cePolygonOverlap = new DevExpress.XtraEditors.CheckEdit();
            this.cePolygonSelf = new DevExpress.XtraEditors.CheckEdit();
            this.ceRepeatPoint = new DevExpress.XtraEditors.CheckEdit();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.btReset = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gpRuler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbcYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLayersOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBoundaryBeyond.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonGap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePlolygonArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAngle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonAcuteangle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonSelf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceRepeatPoint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gpRuler
            // 
            this.gpRuler.Controls.Add(this.clbcYears);
            this.gpRuler.Controls.Add(this.ceLayersOverlap);
            this.gpRuler.Controls.Add(this.ceBoundaryBeyond);
            this.gpRuler.Controls.Add(this.lcDegree);
            this.gpRuler.Controls.Add(this.lbSquare);
            this.gpRuler.Controls.Add(this.cePolygonGap);
            this.gpRuler.Controls.Add(this.teArea);
            this.gpRuler.Controls.Add(this.cePlolygonArea);
            this.gpRuler.Controls.Add(this.teAngle);
            this.gpRuler.Controls.Add(this.cePolygonAcuteangle);
            this.gpRuler.Controls.Add(this.cePolygonOverlap);
            this.gpRuler.Controls.Add(this.cePolygonSelf);
            this.gpRuler.Controls.Add(this.ceRepeatPoint);
            this.gpRuler.Location = new System.Drawing.Point(5, 5);
            this.gpRuler.Name = "gpRuler";
            this.gpRuler.Size = new System.Drawing.Size(304, 158);
            this.gpRuler.TabIndex = 1;
            this.gpRuler.TabStop = false;
            this.gpRuler.Text = "拓扑规则";
            // 
            // clbcYears
            // 
            this.clbcYears.Location = new System.Drawing.Point(169, 100);
            this.clbcYears.Name = "clbcYears";
            this.clbcYears.Size = new System.Drawing.Size(120, 46);
            this.clbcYears.TabIndex = 12;
            this.clbcYears.Visible = false;
            // 
            // ceLayersOverlap
            // 
            this.ceLayersOverlap.EditValue = true;
            this.ceLayersOverlap.Location = new System.Drawing.Point(167, 72);
            this.ceLayersOverlap.Name = "ceLayersOverlap";
            this.ceLayersOverlap.Properties.Caption = "图层间面重叠";
            this.ceLayersOverlap.Size = new System.Drawing.Size(93, 19);
            this.ceLayersOverlap.TabIndex = 11;
            this.ceLayersOverlap.Visible = false;
            this.ceLayersOverlap.CheckedChanged += new System.EventHandler(this.ceLayersOverlap_CheckedChanged);
            // 
            // ceBoundaryBeyond
            // 
            this.ceBoundaryBeyond.EditValue = true;
            this.ceBoundaryBeyond.Location = new System.Drawing.Point(7, 124);
            this.ceBoundaryBeyond.Name = "ceBoundaryBeyond";
            this.ceBoundaryBeyond.Properties.Caption = "超越行政边界";
            this.ceBoundaryBeyond.Size = new System.Drawing.Size(103, 19);
            this.ceBoundaryBeyond.TabIndex = 10;
            // 
            // lcDegree
            // 
            this.lcDegree.Location = new System.Drawing.Point(127, 101);
            this.lcDegree.Name = "lcDegree";
            this.lcDegree.Size = new System.Drawing.Size(12, 14);
            this.lcDegree.TabIndex = 9;
            this.lcDegree.Text = "度";
            // 
            // lbSquare
            // 
            this.lbSquare.Location = new System.Drawing.Point(127, 74);
            this.lbSquare.Name = "lbSquare";
            this.lbSquare.Size = new System.Drawing.Size(24, 14);
            this.lbSquare.TabIndex = 8;
            this.lbSquare.Text = "平米";
            // 
            // cePolygonGap
            // 
            this.cePolygonGap.EditValue = true;
            this.cePolygonGap.Location = new System.Drawing.Point(167, 22);
            this.cePolygonGap.Name = "cePolygonGap";
            this.cePolygonGap.Properties.Caption = "面之间有缝隙";
            this.cePolygonGap.Size = new System.Drawing.Size(93, 19);
            this.cePolygonGap.TabIndex = 7;
            // 
            // teArea
            // 
            this.teArea.EditValue = "";
            this.teArea.Location = new System.Drawing.Point(76, 71);
            this.teArea.Name = "teArea";
            this.teArea.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.teArea.Size = new System.Drawing.Size(43, 20);
            this.teArea.TabIndex = 6;
            this.teArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teArea_KeyDown);
            this.teArea.Leave += new System.EventHandler(this.teArea_Leave);
            // 
            // cePlolygonArea
            // 
            this.cePlolygonArea.EditValue = true;
            this.cePlolygonArea.Location = new System.Drawing.Point(7, 72);
            this.cePlolygonArea.Name = "cePlolygonArea";
            this.cePlolygonArea.Properties.Caption = "面积小于";
            this.cePlolygonArea.Size = new System.Drawing.Size(75, 19);
            this.cePlolygonArea.TabIndex = 5;
            this.cePlolygonArea.CheckedChanged += new System.EventHandler(this.cePlolygonArea_CheckedChanged);
            // 
            // teAngle
            // 
            this.teAngle.EditValue = "";
            this.teAngle.Location = new System.Drawing.Point(76, 97);
            this.teAngle.Name = "teAngle";
            this.teAngle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.teAngle.Size = new System.Drawing.Size(43, 20);
            this.teAngle.TabIndex = 4;
            this.teAngle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teAngle_KeyDown);
            this.teAngle.Leave += new System.EventHandler(this.teAngle_Leave);
            // 
            // cePolygonAcuteangle
            // 
            this.cePolygonAcuteangle.EditValue = true;
            this.cePolygonAcuteangle.Location = new System.Drawing.Point(7, 98);
            this.cePolygonAcuteangle.Name = "cePolygonAcuteangle";
            this.cePolygonAcuteangle.Properties.Caption = "角度小于";
            this.cePolygonAcuteangle.Size = new System.Drawing.Size(66, 19);
            this.cePolygonAcuteangle.TabIndex = 3;
            this.cePolygonAcuteangle.CheckedChanged += new System.EventHandler(this.cePolygonAcuteangle_CheckedChanged);
            // 
            // cePolygonOverlap
            // 
            this.cePolygonOverlap.EditValue = true;
            this.cePolygonOverlap.Location = new System.Drawing.Point(167, 45);
            this.cePolygonOverlap.Name = "cePolygonOverlap";
            this.cePolygonOverlap.Properties.Caption = "面之间重叠";
            this.cePolygonOverlap.Size = new System.Drawing.Size(103, 19);
            this.cePolygonOverlap.TabIndex = 2;
            // 
            // cePolygonSelf
            // 
            this.cePolygonSelf.EditValue = true;
            this.cePolygonSelf.Location = new System.Drawing.Point(7, 47);
            this.cePolygonSelf.Name = "cePolygonSelf";
            this.cePolygonSelf.Properties.Caption = "面自相交";
            this.cePolygonSelf.Size = new System.Drawing.Size(75, 19);
            this.cePolygonSelf.TabIndex = 1;
            // 
            // ceRepeatPoint
            // 
            this.ceRepeatPoint.EditValue = true;
            this.ceRepeatPoint.Location = new System.Drawing.Point(7, 22);
            this.ceRepeatPoint.Name = "ceRepeatPoint";
            this.ceRepeatPoint.Properties.Caption = "重复点";
            this.ceRepeatPoint.Size = new System.Drawing.Size(103, 19);
            this.ceRepeatPoint.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(23, 180);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "保存设置";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(124, 180);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(75, 23);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "清空";
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(228, 180);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // RulerSet
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(315, 215);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.gpRuler);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RulerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "拓扑校验规则设置";
            this.gpRuler.ResumeLayout(false);
            this.gpRuler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbcYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLayersOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBoundaryBeyond.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonGap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePlolygonArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAngle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonAcuteangle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePolygonSelf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceRepeatPoint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void teAngle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            else if ((((((e.KeyCode != Keys.D0) && (e.KeyCode != Keys.NumPad0)) && ((e.KeyCode != Keys.D1) && (e.KeyCode != Keys.NumPad1))) && (((e.KeyCode != Keys.D2) && (e.KeyCode != Keys.NumPad2)) && ((e.KeyCode != Keys.D3) && (e.KeyCode != Keys.NumPad3)))) && ((((e.KeyCode != Keys.D4) && (e.KeyCode != Keys.NumPad4)) && ((e.KeyCode != Keys.D5) && (e.KeyCode != Keys.NumPad5))) && (((e.KeyCode != Keys.D6) && (e.KeyCode != Keys.NumPad6)) && ((e.KeyCode != Keys.D7) && (e.KeyCode != Keys.NumPad7))))) && (((((e.KeyCode != Keys.D8) && (e.KeyCode != Keys.NumPad8)) && ((e.KeyCode != Keys.D9) && (e.KeyCode != Keys.NumPad9))) && (((e.KeyValue != 190) && (e.KeyValue != 110)) && ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete)))) && (e.KeyCode != Keys.Enter)))
            {
                e.SuppressKeyPress = true;
            }
            else if ((this.teAngle.Text.Length == 0) && ((e.KeyValue == 190) || (e.KeyValue == 110)))
            {
                e.SuppressKeyPress = true;
            }
            else if (((this.teAngle.Text == "9") || (this.teAngle.Text == "0")) && (((e.KeyValue != 190) && (e.KeyValue != 110)) && ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Enter))))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (this.teAngle.Text.Length == 2)
                {
                    if (this.teAngle.Text.EndsWith("."))
                    {
                        if ((e.KeyValue == 190) || (e.KeyValue == 110))
                        {
                            e.SuppressKeyPress = true;
                            return;
                        }
                    }
                    else if ((this.teAngle.SelectionLength == 1) && (this.teAngle.SelectionStart == 0))
                    {
                        if (((e.KeyValue == 190) || (e.KeyValue == 110)) || ((e.KeyCode == Keys.D0) || (e.KeyCode == Keys.NumPad0)))
                        {
                            e.SuppressKeyPress = true;
                            return;
                        }
                    }
                    else if (((this.teAngle.SelectionLength == 1) && (this.teAngle.SelectionStart == 1)) && this.teAngle.Text.StartsWith("0"))
                    {
                        if ((e.KeyCode == Keys.D0) || (e.KeyCode == Keys.NumPad0))
                        {
                            e.SuppressKeyPress = true;
                            return;
                        }
                    }
                    else if (this.teAngle.SelectionLength == 2)
                    {
                        if ((e.KeyValue == 190) || (e.KeyValue == 110))
                        {
                            e.SuppressKeyPress = true;
                            return;
                        }
                    }
                    else if (((e.KeyValue != 190) && (e.KeyValue != 110)) && ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Enter)))
                    {
                        e.SuppressKeyPress = true;
                        return;
                    }
                }
                if ((this.teAngle.Text.Length >= 3) && ((e.KeyValue == 190) || (e.KeyValue == 110)))
                {
                    e.SuppressKeyPress = true;
                }
                if (this.teAngle.Text == ".")
                {
                    this.teAngle.Text = "0.";
                }
            }
        }

        private void teAngle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.teAngle.Text) && this.cePolygonAcuteangle.Checked)
            {
                XtraMessageBox.Show("角度不可为空！");
                this.teAngle.Focus();
            }
            if (this.teAngle.Text.EndsWith("."))
            {
                this.teAngle.Text = this.teAngle.Text.TrimEnd(new char[] { '.' });
            }
        }

        private void teArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.SuppressKeyPress = true;
            }
            else if ((((((e.KeyCode != Keys.D0) && (e.KeyCode != Keys.NumPad0)) && ((e.KeyCode != Keys.D1) && (e.KeyCode != Keys.NumPad1))) && (((e.KeyCode != Keys.D2) && (e.KeyCode != Keys.NumPad2)) && ((e.KeyCode != Keys.D3) && (e.KeyCode != Keys.NumPad3)))) && ((((e.KeyCode != Keys.D4) && (e.KeyCode != Keys.NumPad4)) && ((e.KeyCode != Keys.D5) && (e.KeyCode != Keys.NumPad5))) && (((e.KeyCode != Keys.D6) && (e.KeyCode != Keys.NumPad6)) && ((e.KeyCode != Keys.D7) && (e.KeyCode != Keys.NumPad7))))) && (((((e.KeyCode != Keys.D8) && (e.KeyCode != Keys.NumPad8)) && ((e.KeyCode != Keys.D9) && (e.KeyCode != Keys.NumPad9))) && (((e.KeyValue != 190) && (e.KeyValue != 110)) && ((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete)))) && (e.KeyCode != Keys.Enter)))
            {
                e.SuppressKeyPress = true;
            }
            else if ((this.teArea.Text.Length == 0) && ((e.KeyValue == 190) || (e.KeyValue == 110)))
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (this.teArea.Text.EndsWith(".") && ((e.KeyValue == 190) || (e.KeyValue == 110)))
                {
                    e.SuppressKeyPress = true;
                }
                if ((((this.teArea.Text == "0") && (e.KeyValue != 190)) && ((e.KeyValue != 110) && (e.KeyCode != Keys.Back))) && (e.KeyCode != Keys.Enter))
                {
                    e.SuppressKeyPress = true;
                }
                else if (this.teArea.Text == ".")
                {
                    this.teArea.Text = "0.";
                }
            }
        }

        private void teArea_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.teArea.Text) && this.cePlolygonArea.Checked)
            {
                XtraMessageBox.Show("面积不可为空！");
                this.teArea.Focus();
            }
            if (this.teArea.Text.EndsWith("."))
            {
                this.teArea.Text = this.teArea.Text.TrimEnd(new char[] { '.' });
            }
        }
    }
}

