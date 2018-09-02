namespace Cartography.Render
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DevLabelRenderExtent : FormBase3
    {
        private SimpleButton btnAnd;
        private SimpleButton btnNewline;
        private SimpleButton btnUpE;
        private SimpleButton btnUpS;
        private CheckEdit checkEditFix;
        private ComboBoxEdit comboField11;
        private ComboBoxEdit comboField12;
        private ComboBoxEdit comboField13;
        private ComboBoxEdit comboField21;
        private ComboBoxEdit comboField22;
        private ComboBoxEdit comboField23;
        private IContainer components;
        private System.Windows.Forms.Label label35;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private ListBoxControl listBoxFields;
        private IList<string> m_FieldList;
        private string m_Label;
        private IGeoFeatureLayer m_Layer;
        private MemoEdit memoEditLabel;
        private PanelControl panelControl1;
        private PanelControl panelControl10;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PanelControl panelControl6;
        private PanelControl panelControl8;
        private PanelControl panelControl9;
        private PanelControl panelCustom;
        private PanelControl panelFix;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonOK;

        public DevLabelRenderExtent()
        {
            this.InitializeComponent();
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            string text = this.memoEditLabel.Text;
            int selectionStart = this.memoEditLabel.SelectionStart;
            text = text.Substring(0, selectionStart) + " & " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditLabel.Text = text;
            this.memoEditLabel.SelectionStart = selectionStart + 3;
            this.memoEditLabel.Select(this.memoEditLabel.SelectionStart, 0);
        }

        private void btnNewline_Click(object sender, EventArgs e)
        {
            string text = this.memoEditLabel.Text;
            int selectionStart = this.memoEditLabel.SelectionStart;
            text = text.Substring(0, selectionStart) + " vbnewline " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditLabel.Text = text;
            this.memoEditLabel.SelectionStart = selectionStart + 11;
            this.memoEditLabel.Select(this.memoEditLabel.SelectionStart, 0);
        }

        private void btnUpE_Click(object sender, EventArgs e)
        {
            string text = this.memoEditLabel.Text;
            int selectionStart = this.memoEditLabel.SelectionStart;
            text = text.Substring(0, selectionStart) + " \"</UND>\" " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditLabel.Text = text;
            this.memoEditLabel.SelectionStart = selectionStart + 8;
            this.memoEditLabel.Select(this.memoEditLabel.SelectionStart, 0);
        }

        private void btnUpS_Click(object sender, EventArgs e)
        {
            string text = this.memoEditLabel.Text;
            int selectionStart = this.memoEditLabel.SelectionStart;
            text = text.Substring(0, selectionStart) + " \"<UND>\" " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditLabel.Text = text;
            this.memoEditLabel.SelectionStart = selectionStart + 7;
            this.memoEditLabel.Select(this.memoEditLabel.SelectionStart, 0);
        }

        private void checkEditFix_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditFix.Checked)
            {
                this.panelFix.Enabled = true;
                this.panelCustom.Enabled = false;
            }
            else
            {
                this.panelFix.Enabled = false;
                this.panelCustom.Enabled = true;
                this.memoEditLabel.Text = this.m_Label;
            }
        }

        private void DevLabelRenderExtent_Load(object sender, EventArgs e)
        {
            this.checkEditFix.Checked = false;
            this.panelFix.Enabled = false;
            this.memoEditLabel.Text = this.m_Label;
            this.memoEditLabel.Select(this.memoEditLabel.Text.Length, 0);
            this.InitFields();
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

        private void InitFields()
        {
            this.m_FieldList = new List<string>();
            IField field = null;
            this.comboField12.Properties.Items.Add("<无>");
            this.comboField13.Properties.Items.Add("<无>");
            this.comboField22.Properties.Items.Add("<无>");
            this.comboField23.Properties.Items.Add("<无>");
            IFeatureClass featureClass = this.m_Layer.FeatureClass;
            for (int i = 0; i < featureClass.Fields.FieldCount; i++)
            {
                field = featureClass.Fields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    this.m_FieldList.Add(field.Name);
                    this.listBoxFields.Items.Add(field.AliasName + "[" + field.Name + "]");
                    this.comboField11.Properties.Items.Add(field.AliasName);
                    this.comboField12.Properties.Items.Add(field.AliasName);
                    this.comboField13.Properties.Items.Add(field.AliasName);
                    this.comboField21.Properties.Items.Add(field.AliasName);
                    this.comboField22.Properties.Items.Add(field.AliasName);
                    this.comboField23.Properties.Items.Add(field.AliasName);
                }
            }
            this.comboField11.SelectedIndex = 0;
            this.comboField12.SelectedIndex = 0;
            this.comboField13.SelectedIndex = 0;
            this.comboField21.SelectedIndex = 0;
            this.comboField22.SelectedIndex = 0;
            this.comboField23.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.panelCustom = new PanelControl();
            this.listBoxFields = new ListBoxControl();
            this.panelControl5 = new PanelControl();
            this.panelControl6 = new PanelControl();
            this.memoEditLabel = new MemoEdit();
            this.panelControl1 = new PanelControl();
            this.btnUpS = new SimpleButton();
            this.btnNewline = new SimpleButton();
            this.btnAnd = new SimpleButton();
            this.btnUpE = new SimpleButton();
            this.panelControl3 = new PanelControl();
            this.simpleButtonCancel = new SimpleButton();
            this.simpleButtonOK = new SimpleButton();
            this.panelControl4 = new PanelControl();
            this.checkEditFix = new CheckEdit();
            this.panelFix = new PanelControl();
            this.panelControl8 = new PanelControl();
            this.panelControl10 = new PanelControl();
            this.comboField23 = new ComboBoxEdit();
            this.labelControl6 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.comboField22 = new ComboBoxEdit();
            this.comboField21 = new ComboBoxEdit();
            this.label35 = new System.Windows.Forms.Label();
            this.panelControl9 = new PanelControl();
            this.comboField13 = new ComboBoxEdit();
            this.labelControl5 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.comboField12 = new ComboBoxEdit();
            this.comboField11 = new ComboBoxEdit();
            this.panelControl2 = new PanelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panelCustom.BeginInit();
            this.panelCustom.SuspendLayout();
            ((ISupportInitialize) this.listBoxFields).BeginInit();
            this.panelControl5.BeginInit();
            this.panelControl5.SuspendLayout();
            this.panelControl6.BeginInit();
            this.panelControl6.SuspendLayout();
            this.memoEditLabel.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            this.panelControl4.BeginInit();
            this.panelControl4.SuspendLayout();
            this.checkEditFix.Properties.BeginInit();
            this.panelFix.BeginInit();
            this.panelFix.SuspendLayout();
            this.panelControl8.BeginInit();
            this.panelControl8.SuspendLayout();
            this.panelControl10.BeginInit();
            this.panelControl10.SuspendLayout();
            this.comboField23.Properties.BeginInit();
            this.comboField22.Properties.BeginInit();
            this.comboField21.Properties.BeginInit();
            this.panelControl9.BeginInit();
            this.panelControl9.SuspendLayout();
            this.comboField13.Properties.BeginInit();
            this.comboField12.Properties.BeginInit();
            this.comboField11.Properties.BeginInit();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.panelCustom.BorderStyle = BorderStyles.NoBorder;
            this.panelCustom.Controls.Add(this.listBoxFields);
            this.panelCustom.Controls.Add(this.panelControl5);
            this.panelCustom.Dock = DockStyle.Top;
            this.panelCustom.Location = new Point(3, 0);
            this.panelCustom.Name = "panelCustom";
            this.panelCustom.Padding = new Padding(0, 6, 0, 6);
            this.panelCustom.Size = new Size(0x1be, 0xec);
            this.panelCustom.TabIndex = 1;
            this.listBoxFields.Dock = DockStyle.Fill;
            this.listBoxFields.Location = new Point(0, 6);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new Size(0xc1, 0xe0);
            this.listBoxFields.TabIndex = 4;
            this.listBoxFields.DoubleClick += new EventHandler(this.listBoxFields_DoubleClick);
            this.panelControl5.Controls.Add(this.panelControl6);
            this.panelControl5.Controls.Add(this.panelControl1);
            this.panelControl5.Dock = DockStyle.Right;
            this.panelControl5.Location = new Point(0xc1, 6);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(0xfd, 0xe0);
            this.panelControl5.TabIndex = 5;
            this.panelControl6.BorderStyle = BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.memoEditLabel);
            this.panelControl6.Dock = DockStyle.Fill;
            this.panelControl6.Location = new Point(2, 0x22);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new Size(0xf9, 0xbc);
            this.panelControl6.TabIndex = 6;
            this.memoEditLabel.Dock = DockStyle.Fill;
            this.memoEditLabel.Location = new Point(0, 0);
            this.memoEditLabel.Name = "memoEditLabel";
            this.memoEditLabel.Size = new Size(0xf9, 0xbc);
            this.memoEditLabel.TabIndex = 1;
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnUpS);
            this.panelControl1.Controls.Add(this.btnNewline);
            this.panelControl1.Controls.Add(this.btnAnd);
            this.panelControl1.Controls.Add(this.btnUpE);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0xf9, 0x20);
            this.panelControl1.TabIndex = 5;
            this.btnUpS.Location = new Point(4, 6);
            this.btnUpS.Name = "btnUpS";
            this.btnUpS.Size = new Size(60, 20);
            this.btnUpS.TabIndex = 2;
            this.btnUpS.Text = "分子开始";
            this.btnUpS.Click += new EventHandler(this.btnUpS_Click);
            this.btnNewline.Location = new Point(0xc4, 6);
            this.btnNewline.Name = "btnNewline";
            this.btnNewline.Size = new Size(0x24, 20);
            this.btnNewline.TabIndex = 1;
            this.btnNewline.Text = "换行";
            this.btnNewline.Click += new EventHandler(this.btnNewline_Click);
            this.btnAnd.Location = new Point(0x94, 6);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new Size(0x24, 20);
            this.btnAnd.TabIndex = 3;
            this.btnAnd.Text = "连接";
            this.btnAnd.Click += new EventHandler(this.btnAnd_Click);
            this.btnUpE.Location = new Point(0x4c, 6);
            this.btnUpE.Name = "btnUpE";
            this.btnUpE.Size = new Size(60, 20);
            this.btnUpE.TabIndex = 4;
            this.btnUpE.Text = "分子结束";
            this.btnUpE.Click += new EventHandler(this.btnUpE_Click);
            this.panelControl3.BorderStyle = BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonCancel);
            this.panelControl3.Controls.Add(this.simpleButtonOK);
            this.panelControl3.Dock = DockStyle.Bottom;
            this.panelControl3.Location = new Point(3, 0x151);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(0x1be, 0x2f);
            this.panelControl3.TabIndex = 2;
            this.simpleButtonCancel.Location = new Point(0xfb, 12);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(70, 0x1b);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.simpleButtonOK.Location = new Point(0x7b, 12);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(70, 0x1b);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panelControl4.BorderStyle = BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.checkEditFix);
            this.panelControl4.Dock = DockStyle.Top;
            this.panelControl4.Location = new Point(3, 0xec);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(0x1be, 0x1d);
            this.panelControl4.TabIndex = 3;
            this.checkEditFix.Location = new Point(5, 5);
            this.checkEditFix.Name = "checkEditFix";
            this.checkEditFix.Properties.Caption = "固定格式分子式注记";
            this.checkEditFix.Size = new Size(0x92, 0x13);
            this.checkEditFix.TabIndex = 0;
            this.checkEditFix.CheckedChanged += new EventHandler(this.checkEditFix_CheckedChanged);
            this.panelFix.BorderStyle = BorderStyles.NoBorder;
            this.panelFix.Controls.Add(this.panelControl8);
            this.panelFix.Controls.Add(this.panelControl2);
            this.panelFix.Dock = DockStyle.Top;
            this.panelFix.Location = new Point(3, 0x109);
            this.panelFix.Name = "panelFix";
            this.panelFix.Size = new Size(0x1be, 70);
            this.panelFix.TabIndex = 4;
            this.panelControl8.BorderStyle = BorderStyles.NoBorder;
            this.panelControl8.Controls.Add(this.panelControl10);
            this.panelControl8.Controls.Add(this.label35);
            this.panelControl8.Controls.Add(this.panelControl9);
            this.panelControl8.Dock = DockStyle.Left;
            this.panelControl8.Location = new Point(40, 0);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Padding = new Padding(4, 0, 10, 0);
            this.panelControl8.Size = new Size(0x193, 70);
            this.panelControl8.TabIndex = 0;
            this.panelControl10.BorderStyle = BorderStyles.NoBorder;
            this.panelControl10.Controls.Add(this.comboField23);
            this.panelControl10.Controls.Add(this.labelControl6);
            this.panelControl10.Controls.Add(this.labelControl4);
            this.panelControl10.Controls.Add(this.comboField22);
            this.panelControl10.Controls.Add(this.comboField21);
            this.panelControl10.Dock = DockStyle.Top;
            this.panelControl10.Location = new Point(4, 0x21);
            this.panelControl10.Name = "panelControl10";
            this.panelControl10.Size = new Size(0x185, 0x20);
            this.panelControl10.TabIndex = 2;
            this.comboField23.Location = new Point(0x10b, 6);
            this.comboField23.Name = "comboField23";
            this.comboField23.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField23.Size = new Size(0x6f, 0x15);
            this.comboField23.TabIndex = 6;
            this.labelControl6.Location = new Point(0x101, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(4, 14);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "-";
            this.labelControl4.Location = new Point(130, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(4, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "-";
            this.comboField22.Location = new Point(140, 6);
            this.comboField22.Name = "comboField22";
            this.comboField22.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField22.Size = new Size(0x6f, 0x15);
            this.comboField22.TabIndex = 3;
            this.comboField21.Location = new Point(13, 6);
            this.comboField21.Name = "comboField21";
            this.comboField21.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField21.Size = new Size(0x6f, 0x15);
            this.comboField21.TabIndex = 2;
            this.label35.BackColor = Color.Black;
            this.label35.Dock = DockStyle.Top;
            this.label35.Location = new Point(4, 0x20);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x185, 1);
            this.label35.TabIndex = 3;
            this.label35.Text = "label35";
            this.label35.TextAlign = ContentAlignment.MiddleLeft;
            this.panelControl9.BorderStyle = BorderStyles.NoBorder;
            this.panelControl9.Controls.Add(this.comboField13);
            this.panelControl9.Controls.Add(this.labelControl5);
            this.panelControl9.Controls.Add(this.labelControl3);
            this.panelControl9.Controls.Add(this.comboField12);
            this.panelControl9.Controls.Add(this.comboField11);
            this.panelControl9.Dock = DockStyle.Top;
            this.panelControl9.Location = new Point(4, 0);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new Size(0x185, 0x20);
            this.panelControl9.TabIndex = 1;
            this.comboField13.Location = new Point(0x10b, 6);
            this.comboField13.Name = "comboField13";
            this.comboField13.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField13.Size = new Size(0x6f, 0x15);
            this.comboField13.TabIndex = 6;
            this.labelControl5.Location = new Point(0x101, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(4, 14);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "-";
            this.labelControl3.Location = new Point(130, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(4, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "-";
            this.comboField12.Location = new Point(140, 6);
            this.comboField12.Name = "comboField12";
            this.comboField12.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField12.Size = new Size(0x6f, 0x15);
            this.comboField12.TabIndex = 3;
            this.comboField11.Location = new Point(13, 6);
            this.comboField11.Name = "comboField11";
            this.comboField11.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField11.Size = new Size(0x6f, 0x15);
            this.comboField11.TabIndex = 2;
            this.panelControl2.BorderStyle = BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = DockStyle.Left;
            this.panelControl2.Location = new Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(40, 70);
            this.panelControl2.TabIndex = 3;
            this.labelControl2.Location = new Point(6, 0x2a);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x24, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "分母：";
            this.labelControl1.Location = new Point(6, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x24, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "分子：";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c4, 0x180);
            base.Controls.Add(this.panelFix);
            base.Controls.Add(this.panelControl4);
            base.Controls.Add(this.panelControl3);
            base.Controls.Add(this.panelCustom);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DevLabelRenderExtent";
            base.Padding = new Padding(3, 0, 3, 0);
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "标注表达式";
            base.Load += new EventHandler(this.DevLabelRenderExtent_Load);
            this.panelCustom.EndInit();
            this.panelCustom.ResumeLayout(false);
            ((ISupportInitialize) this.listBoxFields).EndInit();
            this.panelControl5.EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl6.EndInit();
            this.panelControl6.ResumeLayout(false);
            this.memoEditLabel.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl4.EndInit();
            this.panelControl4.ResumeLayout(false);
            this.checkEditFix.Properties.EndInit();
            this.panelFix.EndInit();
            this.panelFix.ResumeLayout(false);
            this.panelControl8.EndInit();
            this.panelControl8.ResumeLayout(false);
            this.panelControl10.EndInit();
            this.panelControl10.ResumeLayout(false);
            this.panelControl10.PerformLayout();
            this.comboField23.Properties.EndInit();
            this.comboField22.Properties.EndInit();
            this.comboField21.Properties.EndInit();
            this.panelControl9.EndInit();
            this.panelControl9.ResumeLayout(false);
            this.panelControl9.PerformLayout();
            this.comboField13.Properties.EndInit();
            this.comboField12.Properties.EndInit();
            this.comboField11.Properties.EndInit();
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxFields.SelectedIndex;
            string str = this.listBoxFields.Items[selectedIndex].ToString();
            int index = str.IndexOf("[");
            string str2 = str.Substring(index, str.Length - index);
            string text = this.memoEditLabel.Text;
            int selectionStart = this.memoEditLabel.SelectionStart;
            text = text.Substring(0, selectionStart) + " " + str2 + " " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditLabel.Text = text;
            this.memoEditLabel.SelectionStart = (selectedIndex + 2) + str2.Length;
            this.memoEditLabel.Select(this.memoEditLabel.SelectionStart, 0);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (this.checkEditFix.Checked)
            {
                int selectedIndex = this.comboField11.SelectedIndex;
                int num2 = this.comboField12.SelectedIndex - 1;
                int num3 = this.comboField13.SelectedIndex - 1;
                int num4 = this.comboField21.SelectedIndex;
                int num5 = this.comboField22.SelectedIndex - 1;
                int num6 = this.comboField23.SelectedIndex - 1;
                this.m_Label = "\"<UND>\" & [" + this.m_FieldList[selectedIndex] + "] ";
                if (num2 > 0)
                {
                    this.m_Label = this.m_Label + "& \"-\" & [" + this.m_FieldList[num2] + "]";
                }
                if (num3 > 0)
                {
                    this.m_Label = this.m_Label + " & \"-\" & [" + this.m_FieldList[num3] + "]";
                }
                this.m_Label = this.m_Label + " & \"</UND>\" & vbnewline & [" + this.m_FieldList[num4] + "]";
                if (num5 > 0)
                {
                    this.m_Label = this.m_Label + " & \"-\" & [" + this.m_FieldList[num5] + "]";
                }
                if (num6 > 0)
                {
                    this.m_Label = this.m_Label + " & \"-\" & [" + this.m_FieldList[num6] + "]";
                }
            }
            else
            {
                this.m_Label = this.memoEditLabel.Text;
            }
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

