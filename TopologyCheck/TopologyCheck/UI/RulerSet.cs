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
        private CheckEdit ceRepeatPoint;
        private CheckedListBoxControl clbcYears;
        private IContainer components;
        private GroupBox gpRuler;
        private LabelControl lbSquare;
        private LabelControl lcDegree;
        private TextEdit teAngle;
        private TextEdit teArea;

        public RulerSet()
        {
            this.InitializeComponent();
            this.Init();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            this.ceBoundaryBeyond.Checked = this.cePlolygonArea.Checked = this.cePolygonAcuteangle.Checked = this.cePolygonGap.Checked = this.cePolygonOverlap.Checked = this.cePolygonSelf.Checked = this.ceRepeatPoint.Checked = this.ceLayersOverlap.Checked = false;
        }

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
            this.gpRuler = new GroupBox();
            this.clbcYears = new CheckedListBoxControl();
            this.ceLayersOverlap = new CheckEdit();
            this.ceBoundaryBeyond = new CheckEdit();
            this.lcDegree = new LabelControl();
            this.lbSquare = new LabelControl();
            this.cePolygonGap = new CheckEdit();
            this.teArea = new TextEdit();
            this.cePlolygonArea = new CheckEdit();
            this.teAngle = new TextEdit();
            this.cePolygonAcuteangle = new CheckEdit();
            this.cePolygonOverlap = new CheckEdit();
            this.cePolygonSelf = new CheckEdit();
            this.ceRepeatPoint = new CheckEdit();
            this.btSave = new SimpleButton();
            this.btReset = new SimpleButton();
            this.btCancel = new SimpleButton();
            this.gpRuler.SuspendLayout();
            ((ISupportInitialize) this.clbcYears).BeginInit();
            this.ceLayersOverlap.Properties.BeginInit();
            this.ceBoundaryBeyond.Properties.BeginInit();
            this.cePolygonGap.Properties.BeginInit();
            this.teArea.Properties.BeginInit();
            this.cePlolygonArea.Properties.BeginInit();
            this.teAngle.Properties.BeginInit();
            this.cePolygonAcuteangle.Properties.BeginInit();
            this.cePolygonOverlap.Properties.BeginInit();
            this.cePolygonSelf.Properties.BeginInit();
            this.ceRepeatPoint.Properties.BeginInit();
            base.SuspendLayout();
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
            this.gpRuler.Size = new Size(0x130, 0x9e);
            this.gpRuler.TabIndex = 1;
            this.gpRuler.TabStop = false;
            this.gpRuler.Text = "拓扑规则";
            this.clbcYears.Location = new System.Drawing.Point(0xa9, 100);
            this.clbcYears.Name = "clbcYears";
            this.clbcYears.Size = new Size(120, 0x2e);
            this.clbcYears.TabIndex = 12;
            this.clbcYears.Visible = false;
            this.ceLayersOverlap.EditValue = true;
            this.ceLayersOverlap.Location = new System.Drawing.Point(0xa7, 0x48);
            this.ceLayersOverlap.Name = "ceLayersOverlap";
            this.ceLayersOverlap.Properties.Caption = "图层间面重叠";
            this.ceLayersOverlap.Size = new Size(0x5d, 0x13);
            this.ceLayersOverlap.TabIndex = 11;
            this.ceLayersOverlap.Visible = false;
            this.ceLayersOverlap.CheckedChanged += new EventHandler(this.ceLayersOverlap_CheckedChanged);
            this.ceBoundaryBeyond.EditValue = true;
            this.ceBoundaryBeyond.Location = new System.Drawing.Point(7, 0x7c);
            this.ceBoundaryBeyond.Name = "ceBoundaryBeyond";
            this.ceBoundaryBeyond.Properties.Caption = "超越行政边界";
            this.ceBoundaryBeyond.Size = new Size(0x67, 0x13);
            this.ceBoundaryBeyond.TabIndex = 10;
            this.lcDegree.Location = new System.Drawing.Point(0x7f, 0x65);
            this.lcDegree.Name = "lcDegree";
            this.lcDegree.Size = new Size(12, 14);
            this.lcDegree.TabIndex = 9;
            this.lcDegree.Text = "度";
            this.lbSquare.Location = new System.Drawing.Point(0x7f, 0x4a);
            this.lbSquare.Name = "lbSquare";
            this.lbSquare.Size = new Size(0x18, 14);
            this.lbSquare.TabIndex = 8;
            this.lbSquare.Text = "平米";
            this.cePolygonGap.EditValue = true;
            this.cePolygonGap.Location = new System.Drawing.Point(0xa7, 0x16);
            this.cePolygonGap.Name = "cePolygonGap";
            this.cePolygonGap.Properties.Caption = "面之间有缝隙";
            this.cePolygonGap.Size = new Size(0x5d, 0x13);
            this.cePolygonGap.TabIndex = 7;
            this.teArea.EditValue = "";
            this.teArea.Location = new System.Drawing.Point(0x4c, 0x47);
            this.teArea.Name = "teArea";
            this.teArea.Properties.AllowNullInput = DefaultBoolean.False;
            this.teArea.Size = new Size(0x2b, 0x15);
            this.teArea.TabIndex = 6;
            this.teArea.Leave += new EventHandler(this.teArea_Leave);
            this.teArea.KeyDown += new KeyEventHandler(this.teArea_KeyDown);
            this.cePlolygonArea.EditValue = true;
            this.cePlolygonArea.Location = new System.Drawing.Point(7, 0x48);
            this.cePlolygonArea.Name = "cePlolygonArea";
            this.cePlolygonArea.Properties.Caption = "面积小于";
            this.cePlolygonArea.Size = new Size(0x4b, 0x13);
            this.cePlolygonArea.TabIndex = 5;
            this.cePlolygonArea.CheckedChanged += new EventHandler(this.cePlolygonArea_CheckedChanged);
            this.teAngle.EditValue = "";
            this.teAngle.Location = new System.Drawing.Point(0x4c, 0x61);
            this.teAngle.Name = "teAngle";
            this.teAngle.Properties.AllowNullInput = DefaultBoolean.False;
            this.teAngle.Size = new Size(0x2b, 0x15);
            this.teAngle.TabIndex = 4;
            this.teAngle.Leave += new EventHandler(this.teAngle_Leave);
            this.teAngle.KeyDown += new KeyEventHandler(this.teAngle_KeyDown);
            this.cePolygonAcuteangle.EditValue = true;
            this.cePolygonAcuteangle.Location = new System.Drawing.Point(7, 0x62);
            this.cePolygonAcuteangle.Name = "cePolygonAcuteangle";
            this.cePolygonAcuteangle.Properties.Caption = "角度小于";
            this.cePolygonAcuteangle.Size = new Size(0x42, 0x13);
            this.cePolygonAcuteangle.TabIndex = 3;
            this.cePolygonAcuteangle.CheckedChanged += new EventHandler(this.cePolygonAcuteangle_CheckedChanged);
            this.cePolygonOverlap.EditValue = true;
            this.cePolygonOverlap.Location = new System.Drawing.Point(0xa7, 0x2d);
            this.cePolygonOverlap.Name = "cePolygonOverlap";
            this.cePolygonOverlap.Properties.Caption = "面之间重叠";
            this.cePolygonOverlap.Size = new Size(0x67, 0x13);
            this.cePolygonOverlap.TabIndex = 2;
            this.cePolygonSelf.EditValue = true;
            this.cePolygonSelf.Location = new System.Drawing.Point(7, 0x2f);
            this.cePolygonSelf.Name = "cePolygonSelf";
            this.cePolygonSelf.Properties.Caption = "面自相交";
            this.cePolygonSelf.Size = new Size(0x4b, 0x13);
            this.cePolygonSelf.TabIndex = 1;
            this.ceRepeatPoint.EditValue = true;
            this.ceRepeatPoint.Location = new System.Drawing.Point(7, 0x16);
            this.ceRepeatPoint.Name = "ceRepeatPoint";
            this.ceRepeatPoint.Properties.Caption = "重复点";
            this.ceRepeatPoint.Size = new Size(0x67, 0x13);
            this.ceRepeatPoint.TabIndex = 0;
            this.btSave.Location = new System.Drawing.Point(0x17, 180);
            this.btSave.Name = "btSave";
            this.btSave.Size = new Size(0x4b, 0x17);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "保存设置";
            this.btSave.Click += new EventHandler(this.btSave_Click);
            this.btReset.Location = new System.Drawing.Point(0x7c, 180);
            this.btReset.Name = "btReset";
            this.btReset.Size = new Size(0x4b, 0x17);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "清空";
            this.btReset.Click += new EventHandler(this.btReset_Click);
            this.btCancel.Location = new System.Drawing.Point(0xe4, 180);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new Size(0x4b, 0x17);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new EventHandler(this.btCancel_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x13b, 0xd7);
            base.Controls.Add(this.btCancel);
            base.Controls.Add(this.btReset);
            base.Controls.Add(this.btSave);
            base.Controls.Add(this.gpRuler);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "RulerSet";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "拓扑校验规则设置";
            this.gpRuler.ResumeLayout(false);
            this.gpRuler.PerformLayout();
            ((ISupportInitialize) this.clbcYears).EndInit();
            this.ceLayersOverlap.Properties.EndInit();
            this.ceBoundaryBeyond.Properties.EndInit();
            this.cePolygonGap.Properties.EndInit();
            this.teArea.Properties.EndInit();
            this.cePlolygonArea.Properties.EndInit();
            this.teAngle.Properties.EndInit();
            this.cePolygonAcuteangle.Properties.EndInit();
            this.cePolygonOverlap.Properties.EndInit();
            this.cePolygonSelf.Properties.EndInit();
            this.ceRepeatPoint.Properties.EndInit();
            base.ResumeLayout(false);
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

