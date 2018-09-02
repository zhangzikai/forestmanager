namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using ShapeEdit;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class FormCalField : FormBase3
    {
        private SimpleButton btnAAdd;
        private SimpleButton btnADivide;
        private SimpleButton btnAEqual;
        private SimpleButton btnAMultiply;
        private SimpleButton btnASub;
        private SimpleButton buttonCancel;
        private SimpleButton buttonOK;
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        internal Label LabelLoadInfo;
        private Label labelTarget;
        private ListBoxControl listBoxField;
        private ListBoxControl listBoxU;
        private bool m_bReLoadU;
        private string m_CurrentFieldName;
        private string m_DBKey = "";
        private int m_UpdateType;
        private const string mClassName = "AttributesEdit.FormCalField";
        private RichTextBox memoEditText;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelBar2;
        private Panel panelSubmit;
        private RadioGroup radioGroup1;
        private SimpleButton simpleButtonClear;
        private Thread thread;

        public event UpdateValuehandler OnUpdateValue;

        public FormCalField()
        {
            this.InitializeComponent();
        }

        private void btnAAdd_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " + " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void btnAAnd_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " & " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void btnADivide_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " / " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void btnAEqual_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " = " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void btnAMultiply_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " * " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void btnASub_Click(object sender, EventArgs e)
        {
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + " - " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + 3;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.memoEditText.Text == "")
            {
                MessageBox.Show("请键入表达式！", "提示");
            }
            else if (DialogResult.No != MessageBox.Show("数据更新后将无法撤销，是否继续？", "提示", MessageBoxButtons.YesNo))
            {
                this.LabelLoadInfo.Visible = true;
                this.buttonOK.Enabled = false;
                this.CalField();
                this.LabelLoadInfo.Visible = false;
                this.buttonOK.Enabled = true;
                if (this.OnUpdateValue != null)
                {
                    this.OnUpdateValue();
                }
            }
        }
        public MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private int ExecuteNonQuery(string sSql)
        {
            try
            {
                return MDM.UpdateDB(sSql) ? 1 : -1;
            }
            catch
            {
                return -1;
            }
        }
        private void CalField()
        {
            IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
            string str = "";
            int num = 0;
            if (this.m_UpdateType == 1)
            {
                IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                ISelectionSet selectionSet = editLayer.SelectionSet;
                if (selectionSet.Count < 1)
                {
                    MessageBox.Show("当前编辑图层无选中要素，请选中要素后再操作！", "提示");
                    return;
                }
                string oIDFieldName = featureClass.OIDFieldName;
                IEnumIDs iDs = selectionSet.IDs;
                iDs.Reset();
                int num2 = -1;
                while ((num2 = iDs.Next()) != -1)
                {
                    num++;
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, " or ", oIDFieldName, "=", num2 });
                }
                if (str.Length > 4)
                {
                    str = str.Substring(4);
                }
            }
            else if (this.m_UpdateType != 2)
            {
                num = featureClass.FeatureCount(null);
            }
            if (this.m_CurrentFieldName != "")
            {
                try
                {
                    string name = ((IDataset) featureClass).Name;
                    string sCmdText = "update " + name + " set " + this.m_CurrentFieldName + "=" + this.memoEditText.Text;
                    if (str != "")
                    {
                        sCmdText = sCmdText + " where " + str;
                    }
                    if (this.ExecuteNonQuery(sCmdText) < 0)
                    {
                        MessageBox.Show("计算出错！表达式错误或与字段不匹配。", "提示");
                        return;
                    }
                    if ((this.m_UpdateType == 1) || (this.m_UpdateType == 2))
                    {
                        if (!Editor.UniqueInstance.StopEdit2())
                        {
                            Thread.Sleep(0x1388);
                            Editor.UniqueInstance.StopEdit2();
                        }
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    }
                    MessageBox.Show("共有" + num + "个要素被修改。", "提示");
                    EditTask.LogicChkState = LogicCheckState.Failure;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("修改失败！", "提示");
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormCalField", "CalField", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                GC.Collect();
            }
        }

        private void CalField0()
        {
            IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
            Editor.UniqueInstance.StartEditOperation();
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor {
                    OverwriteOutput = true
                };
                CalculateField process = new CalculateField {
                    in_table = featureClass,
                    field = this.m_CurrentFieldName,
                    expression_type = "PYTHON",
                    expression = this.memoEditText.Text
                };
                geoprocessor.Execute(process, null);
                Editor.UniqueInstance.StopEditOperation();
            }
            catch (Exception exception)
            {
                Editor.UniqueInstance.AbortEditOperation();
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormCalField", "CalField0", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("计算出错！表达式错误或与字段不匹配。", "提示");
            }
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                this.panelBar2.Visible = false;
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private void CalThread()
        {
            this.CalField();
            GC.Collect();
            this.CallBack();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormCalField_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.thread != null) && this.thread.IsAlive)
            {
                this.thread.Abort();
                this.thread.Join();
                this.thread = null;
            }
        }

        private void FormCalField_Load(object sender, EventArgs e)
        {
            this.m_DBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");
            this.labelTarget.Text = this.m_CurrentFieldName + "=";
            this.InitListField();
            this.radioGroup1.SelectedIndex = -1;
            this.radioGroup1.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.memoEditText = new System.Windows.Forms.RichTextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.labelTarget = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.listBoxField = new DevExpress.XtraEditors.ListBoxControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listBoxU = new DevExpress.XtraEditors.ListBoxControl();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnAEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnADivide = new DevExpress.XtraEditors.SimpleButton();
            this.btnAMultiply = new DevExpress.XtraEditors.SimpleButton();
            this.btnASub = new DevExpress.XtraEditors.SimpleButton();
            this.btnAAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButtonClear = new DevExpress.XtraEditors.SimpleButton();
            this.panelBar2 = new System.Windows.Forms.Panel();
            this.panelSubmit = new System.Windows.Forms.Panel();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxField)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxU)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            this.panelBar2.SuspendLayout();
            this.panelSubmit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panelBar2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 0);
            this.panel1.Size = new System.Drawing.Size(416, 432);
            this.panel1.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(5, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(406, 350);
            this.panel9.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel13);
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 203);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(406, 147);
            this.panel4.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.memoEditText);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 26);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(406, 121);
            this.panel13.TabIndex = 3;
            // 
            // memoEditText
            // 
            this.memoEditText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.memoEditText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEditText.Location = new System.Drawing.Point(0, 0);
            this.memoEditText.Margin = new System.Windows.Forms.Padding(0);
            this.memoEditText.Name = "memoEditText";
            this.memoEditText.Size = new System.Drawing.Size(404, 119);
            this.memoEditText.TabIndex = 2;
            this.memoEditText.Text = "";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.labelTarget);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(406, 26);
            this.panel12.TabIndex = 1;
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(4, 9);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(16, 14);
            this.labelTarget.TabIndex = 0;
            this.labelTarget.Text = "=";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 203);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.listBoxField);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(248, 203);
            this.panel6.TabIndex = 1;
            // 
            // listBoxField
            // 
            this.listBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxField.Location = new System.Drawing.Point(0, 26);
            this.listBoxField.Name = "listBoxField";
            this.listBoxField.Size = new System.Drawing.Size(248, 177);
            this.listBoxField.TabIndex = 1;
            this.listBoxField.DoubleClick += new System.EventHandler(this.listBoxField_DoubleClick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(248, 26);
            this.panel7.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "字段：";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listBoxU);
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(248, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel5.Size = new System.Drawing.Size(158, 203);
            this.panel5.TabIndex = 0;
            // 
            // listBoxU
            // 
            this.listBoxU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxU.Items.AddRange(new object[] {
            "Abs( )",
            "Atn( )",
            "Cos( )",
            "Exp( )",
            "Fix( )",
            "Int( )",
            "Log( )",
            "Sin( )",
            "Sqr( )",
            "Tan( )"});
            this.listBoxU.Location = new System.Drawing.Point(5, 26);
            this.listBoxU.Name = "listBoxU";
            this.listBoxU.Size = new System.Drawing.Size(153, 147);
            this.listBoxU.TabIndex = 3;
            this.listBoxU.SelectedIndexChanged += new System.EventHandler(this.listBoxU_SelectedIndexChanged);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnAEqual);
            this.panel11.Controls.Add(this.btnADivide);
            this.panel11.Controls.Add(this.btnAMultiply);
            this.panel11.Controls.Add(this.btnASub);
            this.panel11.Controls.Add(this.btnAAdd);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(5, 173);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(153, 30);
            this.panel11.TabIndex = 2;
            // 
            // btnAEqual
            // 
            this.btnAEqual.Location = new System.Drawing.Point(124, 6);
            this.btnAEqual.Name = "btnAEqual";
            this.btnAEqual.Size = new System.Drawing.Size(24, 24);
            this.btnAEqual.TabIndex = 14;
            this.btnAEqual.Text = "=";
            this.btnAEqual.Click += new System.EventHandler(this.btnAEqual_Click);
            // 
            // btnADivide
            // 
            this.btnADivide.Location = new System.Drawing.Point(93, 6);
            this.btnADivide.Name = "btnADivide";
            this.btnADivide.Size = new System.Drawing.Size(24, 24);
            this.btnADivide.TabIndex = 13;
            this.btnADivide.Text = "/";
            this.btnADivide.Click += new System.EventHandler(this.btnADivide_Click);
            // 
            // btnAMultiply
            // 
            this.btnAMultiply.Location = new System.Drawing.Point(62, 6);
            this.btnAMultiply.Name = "btnAMultiply";
            this.btnAMultiply.Size = new System.Drawing.Size(24, 24);
            this.btnAMultiply.TabIndex = 12;
            this.btnAMultiply.Text = "*";
            this.btnAMultiply.Click += new System.EventHandler(this.btnAMultiply_Click);
            // 
            // btnASub
            // 
            this.btnASub.Location = new System.Drawing.Point(31, 6);
            this.btnASub.Name = "btnASub";
            this.btnASub.Size = new System.Drawing.Size(24, 24);
            this.btnASub.TabIndex = 11;
            this.btnASub.Text = "-";
            this.btnASub.Click += new System.EventHandler(this.btnASub_Click);
            // 
            // btnAAdd
            // 
            this.btnAAdd.Location = new System.Drawing.Point(0, 6);
            this.btnAAdd.Name = "btnAAdd";
            this.btnAAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAAdd.TabIndex = 10;
            this.btnAAdd.Text = "+";
            this.btnAAdd.Click += new System.EventHandler(this.btnAAdd_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel2);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(5, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(153, 26);
            this.panel10.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioGroup1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(36, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panel2.Size = new System.Drawing.Size(117, 26);
            this.panel2.TabIndex = 4;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "数字"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "字符串")});
            this.radioGroup1.Size = new System.Drawing.Size(117, 25);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "函数：";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.simpleButtonClear);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(5, 353);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(406, 34);
            this.panel8.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 1);
            this.label3.TabIndex = 2;
            // 
            // simpleButtonClear
            // 
            this.simpleButtonClear.Location = new System.Drawing.Point(25, 6);
            this.simpleButtonClear.Name = "simpleButtonClear";
            this.simpleButtonClear.Size = new System.Drawing.Size(48, 23);
            this.simpleButtonClear.TabIndex = 1;
            this.simpleButtonClear.Text = "清空";
            this.simpleButtonClear.Click += new System.EventHandler(this.simpleButtonClear_Click);
            // 
            // panelBar2
            // 
            this.panelBar2.Controls.Add(this.panelSubmit);
            this.panelBar2.Controls.Add(this.LabelLoadInfo);
            this.panelBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBar2.Location = new System.Drawing.Point(5, 387);
            this.panelBar2.Name = "panelBar2";
            this.panelBar2.Size = new System.Drawing.Size(406, 45);
            this.panelBar2.TabIndex = 6;
            // 
            // panelSubmit
            // 
            this.panelSubmit.Controls.Add(this.buttonCancel);
            this.panelSubmit.Controls.Add(this.buttonOK);
            this.panelSubmit.Location = new System.Drawing.Point(194, 6);
            this.panelSubmit.Name = "panelSubmit";
            this.panelSubmit.Size = new System.Drawing.Size(185, 30);
            this.panelSubmit.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(98, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(60, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确定";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LabelLoadInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Location = new System.Drawing.Point(7, 9);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(194, 19);
            this.LabelLoadInfo.TabIndex = 14;
            this.LabelLoadInfo.Text = "      正在修改，请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Visible = false;
            // 
            // FormCalField
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(416, 432);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalField";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段计算器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalField_FormClosing);
            this.Load += new System.EventHandler(this.FormCalField_Load);
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxField)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxU)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panelBar2.ResumeLayout(false);
            this.panelSubmit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitListField()
        {
            this.listBoxField.Items.Clear();
            IFields fields = EditTask.EditLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    this.listBoxField.Items.Add(field.AliasName + "[" + field.Name + "]");
                }
            }
            this.listBoxField.SelectedIndex = -1;
        }

        private void listBoxField_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxField.SelectedIndex;
            string str = this.listBoxField.Items[selectedIndex].ToString();
            int index = str.IndexOf("[");
            string str2 = str.Substring(index + 1, (str.Length - index) - 2);
            string text = this.memoEditText.Text;
            int selectionStart = this.memoEditText.SelectionStart;
            text = text.Substring(0, selectionStart) + str2 + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditText.Text = text;
            this.memoEditText.Focus();
            this.memoEditText.SelectionStart = selectionStart + str2.Length;
        }

        private void listBoxU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_bReLoadU && (this.listBoxU.SelectedValue != null))
            {
                string str = this.listBoxU.SelectedValue.ToString();
                string text = this.memoEditText.Text;
                int selectionStart = this.memoEditText.SelectionStart;
                text = text.Substring(0, selectionStart) + str + text.Substring(selectionStart, text.Length - selectionStart);
                this.memoEditText.Text = text;
                this.memoEditText.Focus();
                this.memoEditText.SelectionStart = selectionStart + str.Length;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxU.Items.Clear();
            string str = "";
            if (this.m_DBKey == "SqlServer")
            {
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    str = "Abs( ),ATan( ),Cos( ),Exp( ),Ceiling( ),Floor( ),Log( ),Power( ),Round( ),Sin( ),Sqrt( ),Tan( )";
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    str = "AscII( ),Char( ),CharIndex( ),Left( ),Len( ),Lower( ),LTrim( ),PatIndex( ),Quotename( ),Replace( ),Replicate( ),Reverse( ),Right( ),RTrim( ),Space( ),Str( ),Substring( ),Upper( )";
                }
            }
            else
            {
                if (this.m_DBKey != "Access")
                {
                    return;
                }
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    str = "Abs( ),Atn( ),Cos( ),Exp( ),Fix( ),Int( ),Log( ),Round( ),Sin( ),Sqr( ),Tan( )";
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    str = "Asc( ),Chr( ),Format( ),Instr( ),LCase( ),Left( ),Len( ),LTrim( ),Mid( ),Right( ),RTrim( ),Space( ),StrConv( ),String( ),Trim( ),UCase( )";
                }
            }
            this.m_bReLoadU = true;
            string[] strArray = str.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                this.listBoxU.Items.Add(strArray[i]).ToString();
            }
            this.listBoxU.SelectedIndex = -1;
            this.m_bReLoadU = false;
        }

        private void SetLoadInfo(string sInfo)
        {
            if (base.InvokeRequired)
            {
                base.Invoke(new DeleSetLoadInfo(this.SetLoadInfo), new object[] { sInfo });
            }
            else
            {
                this.LabelLoadInfo.Text = "     " + sInfo;
                this.Refresh();
            }
        }

        private void simpleButtonClear_Click(object sender, EventArgs e)
        {
            this.memoEditText.Text = "";
        }

        public string UpdateField
        {
            set
            {
                this.m_CurrentFieldName = value;
            }
        }

        public int UpdateType
        {
            set
            {
                this.m_UpdateType = value;
            }
        }

        private delegate void DeleSetLoadInfo(string sInfo);

        public delegate void UpdateValuehandler();
    }
}

