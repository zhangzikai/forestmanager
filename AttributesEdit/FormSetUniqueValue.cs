namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    /// <summary>
    /// 编辑--批量修改工具窗体
    /// </summary>
    public class FormSetUniqueValue : FormBase3
    {
        private SimpleButton buttonCancel;
        private SimpleButton buttonOK;
        private CheckEdit checkEditSelected;
        private ComboBoxEdit comboField;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        internal Label LabelLoadInfo;
        private LabelControl labelMessage;
        private Label labelText;
        private bool m_bInit;
        private string m_CurrentFieldName = "";
        private string[] m_DayFields = AttriEdit.DateFields;
        private IFeatureClass m_FClass;
        private IList<string> m_FieldNames;
        private string m_Filter = "";
        private IList<string> m_Names;
        private int m_UpdateType;
        private IList<string> m_Values;
        private string[] m_YbdFields = AttriEdit.YBDFields;
        private const string mClassName = "AttributesEdit.FormSetUniqueValue";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panelField;
        private Panel panellabel;
        private Panel panelValue;

        public event UpdateValuehandler OnUpdateValue;

        /// <summary>
        /// 编辑--批量修改工具窗体：构造器
        /// </summary>
        public FormSetUniqueValue()
        {
            this.InitializeComponent();
            this.panellabel.Visible = false;
            this.comboField.SelectedIndexChanged += new EventHandler(this.comboField_SelectedIndexChanged);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.m_CurrentFieldName == "")
            {
                MessageBox.Show("请选择要修改的字段！", "提示");
            }
            else
            {
                string text = "";
                if (this.m_UpdateType == 1)
                {
                    text = "编辑图层中的选中要素属性将被修改，并且无法撤销。是否继续执行？";
                }
                else if (this.m_UpdateType == 2)
                {
                    text = "当前规则下的所有错误要素都将被修改，并且无法撤销。是否继续执行？";
                }
                else
                {
                    text = "编辑图层所有数据都将被修改，并且无法撤销。是否继续执行？";
                }
                if (DialogResult.Yes == MessageBox.Show(text, "提示", MessageBoxButtons.YesNo))
                {
                    this.LabelLoadInfo.Visible = true;
                    this.Refresh();
                    this.SaveValue();
                    this.LabelLoadInfo.Visible = false;
                    this.Refresh();
                    if (this.OnUpdateValue != null)
                    {
                        this.OnUpdateValue();
                    }
                }
            }
        }

        private void checkEditSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditSelected.Checked)
            {
                this.m_UpdateType = 1;
            }
            else
            {
                this.m_UpdateType = 0;
            }
        }

        private void ClearControl()
        {
            this.panelValue.Controls.Clear();
            this.m_Names = new List<string>();
            this.m_Values = new List<string>();
            this.labelMessage.Text = "";
        }

        private void comboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboField.SelectedIndex;
            if (selectedIndex >= 0)
            {
                string str = this.m_FieldNames[selectedIndex];
                this.m_CurrentFieldName = str;
                this.SetEditControl();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormSetUniqueValue_Load(object sender, EventArgs e)
        {
            if (!this.m_bInit)
            {
                this.Init();
                this.comboField.Properties.Items.Clear();
                IFields fields = this.m_FClass.Fields;
                this.m_FieldNames = new List<string>();
                int num = 0;
                int num2 = 0;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                    {
                        this.m_FieldNames.Add(field.Name);
                        this.comboField.Properties.Items.Add(field.Name + "(" + field.AliasName + ")");
                        if (this.m_CurrentFieldName.ToUpper() == field.Name.ToUpper())
                        {
                            this.m_CurrentFieldName = field.Name;
                            num = num2;
                        }
                        num2++;
                    }
                }
                this.comboField.SelectedIndex = num;
            }
            if (this.m_UpdateType == 2)
            {
                this.checkEditSelected.Visible = false;
            }
        }

        private object GetControlValue()
        {
            object selectedValue = DBNull.Value;
            try
            {
                Control control = this.panelValue.Controls[0];
                if (this.m_DayFields.Contains<string>(this.m_CurrentFieldName))
                {
                    DateEdit edit = control as DateEdit;
                    string text = edit.Text;
                    if (text != "")
                    {
                        selectedValue = Convert.ToDateTime(text).ToString("yyyyMMdd");
                    }
                    return selectedValue;
                }
                if (control is Panel)
                {
                    control = control.Controls[0];
                    if (control is ZLComboBox)
                    {
                        selectedValue = ((ZLComboBox) control).GetSelectedValue();
                    }
                    return selectedValue;
                }
                if (control is SpinEdit)
                {
                    return ((SpinEdit) control).Value;
                }
                if (control is DateEdit)
                {
                    DateEdit edit2 = control as DateEdit;
                    return edit2.DateTime;
                }
                if (control is TextEdit)
                {
                    string str2 = ((TextEdit) control).Text;
                    if (str2.Replace(" ", "").Length < 1)
                    {
                        selectedValue = DBNull.Value;
                    }
                    return str2.Trim();
                }
                if (!(control is CheckedListBoxControl))
                {
                    return selectedValue;
                }
                string str3 = "";
                CheckedListBoxControl control2 = (CheckedListBoxControl) control;
                for (int i = 0; i < control2.Items.Count; i++)
                {
                    if (control2.Items[i].CheckState == CheckState.Checked)
                    {
                        str3 = str3 + "," + control2.Items[i].Value;
                    }
                }
                if (str3.Length > 0)
                {
                    selectedValue = str3.Substring(1);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetUniqueValue", "SaveValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return selectedValue;
        }

        private void Init()
        {
            IFeatureLayer editLayer = EditTask.EditLayer;
            if (editLayer == null)
            {
                this.buttonOK.Enabled = false;
            }
            IFeatureClass featureClass = editLayer.FeatureClass;
            if (featureClass == null)
            {
                this.buttonOK.Enabled = false;
            }
            this.m_FClass = featureClass;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSetUniqueValue));
            this.panel1 = new Panel();
            this.panel6 = new Panel();
            this.LabelLoadInfo = new Label();
            this.labelMessage = new LabelControl();
            this.panel5 = new Panel();
            this.buttonOK = new SimpleButton();
            this.buttonCancel = new SimpleButton();
            this.panel3 = new Panel();
            this.panelValue = new Panel();
            this.panel4 = new Panel();
            this.labelControl2 = new LabelControl();
            this.panel2 = new Panel();
            this.panellabel = new Panel();
            this.labelText = new Label();
            this.panelField = new Panel();
            this.checkEditSelected = new CheckEdit();
            this.labelControl1 = new LabelControl();
            this.comboField = new ComboBoxEdit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panellabel.SuspendLayout();
            this.panelField.SuspendLayout();
            this.checkEditSelected.Properties.BeginInit();
            this.comboField.Properties.BeginInit();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x155, 0x14e);
            this.panel1.TabIndex = 0;
            this.panel6.Controls.Add(this.LabelLoadInfo);
            this.panel6.Controls.Add(this.labelMessage);
            this.panel6.Dock = DockStyle.Bottom;
            this.panel6.Location = new Point(0, 0x130);
            this.panel6.Name = "panel6";
            this.panel6.Size = new Size(0x155, 30);
            this.panel6.TabIndex = 5;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            //this.LabelLoadInfo.Image = (Image)resources.GetObject("LabelLoadInfo.Image");
            this.LabelLoadInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Location = new Point(0x23, 3);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0xea, 0x13);
            this.LabelLoadInfo.TabIndex = 14;
            this.LabelLoadInfo.Text = "      正在修改，请稍候...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelLoadInfo.Visible = false;
            this.labelMessage.Location = new Point(0x23, 4);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new Size(0, 14);
            this.labelMessage.TabIndex = 2;
            this.panel5.Controls.Add(this.buttonOK);
            this.panel5.Controls.Add(this.buttonCancel);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new Point(0, 0xf6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x155, 0x2f);
            this.panel5.TabIndex = 4;
            this.buttonOK.Location = new Point(0xee, 0x11);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(60, 0x17);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "修改";
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Location = new Point(0x4f, 0x11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(60, 0x17);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            this.panel3.Controls.Add(this.panelValue);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x155, 0x9c);
            this.panel3.TabIndex = 3;
            this.panelValue.Dock = DockStyle.Left;
            this.panelValue.Location = new Point(0x34, 0);
            this.panelValue.Name = "panelValue";
            this.panelValue.Padding = new Padding(7, 10, 20, 0);
            this.panelValue.Size = new Size(0xf6, 0x9c);
            this.panelValue.TabIndex = 1;
            this.panel4.Controls.Add(this.labelControl2);
            this.panel4.Dock = DockStyle.Left;
            this.panel4.Location = new Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x34, 0x9c);
            this.panel4.TabIndex = 0;
            this.labelControl2.Location = new Point(0x16, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x18, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "值：";
            this.panel2.Controls.Add(this.panellabel);
            this.panel2.Controls.Add(this.panelField);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x155, 90);
            this.panel2.TabIndex = 2;
            this.panellabel.Controls.Add(this.labelText);
            this.panellabel.Dock = DockStyle.Top;
            this.panellabel.Location = new Point(0, 0x3d);
            this.panellabel.Name = "panellabel";
            this.panellabel.Size = new Size(0x155, 30);
            this.panellabel.TabIndex = 4;
            this.labelText.Dock = DockStyle.Fill;
            this.labelText.Location = new Point(0, 0);
            this.labelText.Name = "labelText";
            this.labelText.Padding = new Padding(8, 0, 0, 0);
            this.labelText.Size = new Size(0x155, 30);
            this.labelText.TabIndex = 0;
            this.labelText.TextAlign = ContentAlignment.MiddleLeft;
            this.panelField.Controls.Add(this.checkEditSelected);
            this.panelField.Controls.Add(this.labelControl1);
            this.panelField.Controls.Add(this.comboField);
            this.panelField.Dock = DockStyle.Top;
            this.panelField.Location = new Point(0, 0);
            this.panelField.Name = "panelField";
            this.panelField.Size = new Size(0x155, 0x3d);
            this.panelField.TabIndex = 3;
            this.checkEditSelected.Location = new Point(0x21, 10);
            this.checkEditSelected.Name = "checkEditSelected";
            this.checkEditSelected.Properties.Caption = "只修改选中要素";
            this.checkEditSelected.Size = new Size(0x7b, 0x13);
            this.checkEditSelected.TabIndex = 2;
            this.checkEditSelected.CheckedChanged += new EventHandler(this.checkEditSelected_CheckedChanged);
            this.labelControl1.Location = new Point(0x10, 0x26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "字段：";
            this.comboField.Location = new Point(0x3a, 0x22);
            this.comboField.Name = "comboField";
            this.comboField.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboField.Size = new Size(220, 0x15);
            this.comboField.TabIndex = 1;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
      //      base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 0x14e);
            base.Controls.Add(this.panel1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormSetUniqueValue";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "批量修改字段值";
            base.Load += new EventHandler(this.FormSetUniqueValue_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panellabel.ResumeLayout(false);
            this.panelField.ResumeLayout(false);
            this.panelField.PerformLayout();
            this.checkEditSelected.Properties.EndInit();
            this.comboField.Properties.EndInit();
            base.ResumeLayout(false);
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
        
        /// <summary>
        /// 保存值
        /// </summary>
        private void SaveValue()
        {
            this.labelMessage.Text = "";
            if (this.m_FClass != null)
            {
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
                    string oIDFieldName = this.m_FClass.OIDFieldName;
                    IEnumIDs iDs = selectionSet.IDs;
                    iDs.Reset();
                    int num2 = -1;
                    while ((num2 = iDs.Next()) != -1)
                    {
                        num++;
                        object obj3 = str;
                        str = string.Concat(new object[] { obj3, " or ", oIDFieldName, "=", num2 });
                    }
                    if (str.Length > 4)
                    {
                        str = str.Substring(4);
                    }
                }
                else if (this.m_UpdateType == 2)
                {
                    str = this.m_Filter;
                    IQueryFilter queryFilter = new QueryFilterClass {
                        SubFields = this.m_FClass.OIDFieldName + "," + this.m_FClass.ShapeFieldName,
                        WhereClause = str
                    };
                    num = this.m_FClass.FeatureCount(queryFilter);
                }
                else
                {
                    num = this.m_FClass.FeatureCount(null);
                }
                if (this.m_CurrentFieldName == "")
                {
                    int selectedIndex = this.comboField.SelectedIndex;
                    if (selectedIndex < 0)
                    {
                        return;
                    }
                    this.m_CurrentFieldName = this.m_FieldNames[selectedIndex];
                }
                int index = this.m_FClass.Fields.FindField(this.m_CurrentFieldName);
                object controlValue = this.GetControlValue();
                try
                {
                    string name = ((IDataset) this.m_FClass).Name;
                    string sCmdText = "update " + name + " set " + this.m_CurrentFieldName + "=";
                    if (this.m_FClass.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                    {
                        sCmdText = sCmdText + "'" + controlValue.ToString() + "'";
                    }
                    else
                    {
                        sCmdText = sCmdText + controlValue.ToString();
                    }
                    if (str != "")
                    {
                        sCmdText = sCmdText + " where " + str;
                    }
                   ExecuteNonQuery(sCmdText);
                    if ((this.m_UpdateType == 1) || (this.m_UpdateType == 2))
                    {
                        if (!Editor.UniqueInstance.StopEdit2())
                        {
                            Thread.Sleep(0x1388);
                            Editor.UniqueInstance.StopEdit2();
                        }
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    }
                    this.labelMessage.Text = "共有" + num + "个要素被修改。";
                    EditTask.LogicChkState = LogicCheckState.Failure;
                }
                catch (Exception exception)
                {
                    this.labelMessage.Text = "修改失败";
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetUniqueValue", "SaveValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                GC.Collect();
            }
        }

        /// <summary>
        /// 设置村控件
        /// </summary>
        /// <param name="pField"></param>
        private void SetCunControl(IField pField)
        {
            try
            {
                ZLComboBox box = new ZLComboBox {
                    DrawMode = DrawMode.OwnerDrawFixed
                };
                box.ClearItems();
                if (pField.IsNullable)
                {
                    box.AddItem("<空>", "", true);
                }
                string sql = "select CCODE,CNAME from T_SYS_META_CODE where CDOMAIN='CUN'";
             //   IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                {
                    int num = 0;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string sValue = dataTable.Rows[i]["CCODE"].ToString();
                        box.AddItem(dataTable.Rows[i]["CNAME"].ToString(), sValue);
                    }
                    box.SelectedIndex = num;
                    Panel panel = new Panel {
                        Size = new Size(220, 0x16),
                        Location = new Point(7, 11),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    box.Dock = DockStyle.Fill;
                    panel.Controls.Add(box);
                    this.panelValue.Controls.Add(panel);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetUniqueValue", "SetCunControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 设置编辑控件
        /// </summary>
        private void SetEditControl()
        {
            this.ClearControl();
            if (this.m_FClass != null)
            {
                int index = this.m_FClass.Fields.FindField(this.m_CurrentFieldName);
                IField pField = this.m_FClass.Fields.get_Field(index);
                if ((this.m_UpdateType == 1) || (this.m_UpdateType == 0))
                {
                    this.labelText.Text = "当前修改字段为：" + pField.Name + "（" + pField.AliasName + "）";
                    if (!pField.Editable)
                    {
                        this.labelText.Text = "\n字段不可编辑。";
                        return;
                    }
                }
                bool flag = false;
                try
                {
                    if (this.m_DayFields.Contains<string>(pField.Name))
                    {
                        DateEdit edit = new DateEdit {
                            Text = "",
                            Dock = DockStyle.Left,
                            Width = 220
                        };
                        this.panelValue.Controls.Add(edit);
                    }
                    else
                    {
                        IDomain domain = pField.Domain;
                        if (domain != null)
                        {
                            if (domain is ICodedValueDomain)
                            {
                                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                                for (int i = 0; i < domain2.CodeCount; i++)
                                {
                                    this.m_Values.Add(domain2.get_Value(i).ToString());
                                    this.m_Names.Add(domain2.get_Name(i));
                                }
                                if (pField.Name == "ZJLY")
                                {
                                    CheckedListBoxControl control = new CheckedListBoxControl();
                                    for (int j = 0; j < this.m_Names.Count; j++)
                                    {
                                        control.Items.Add(this.m_Names[j]);
                                    }
                                    control.Dock = DockStyle.Fill;
                                    this.panelValue.Controls.Add(control);
                                }
                                else
                                {
                                    ZLComboBox box = new ZLComboBox {
                                        DrawMode = DrawMode.OwnerDrawFixed
                                    };
                                    box.ClearItems();
                                    if (pField.IsNullable)
                                    {
                                        box.AddItem("<空>", "", true);
                                    }
                                    string[] readonlyItems = AttriEdit.GetReadonlyItems(pField);
                                    for (int k = 0; k < this.m_Values.Count; k++)
                                    {
                                        if ((readonlyItems != null) && readonlyItems.Contains<string>(this.m_Names[k]))
                                        {
                                            box.AddItem(this.m_Names[k], this.m_Values[k], false);
                                        }
                                        else
                                        {
                                            box.AddItem(this.m_Names[k], this.m_Values[k], true);
                                        }
                                    }
                                    box.SelectedIndex = 0;
                                    Panel panel = new Panel {
                                        Size = new Size(220, 0x16),
                                        Location = new Point(7, 11),
                                        BorderStyle = BorderStyle.FixedSingle
                                    };
                                    box.Dock = DockStyle.Fill;
                                    panel.Controls.Add(box);
                                    this.panelValue.Controls.Add(panel);
                                }
                            }
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                        {
                            SpinEdit edit2 = new SpinEdit {
                                Enabled = !flag,
                                Properties = { 
                                    Appearance = { TextOptions = { HAlignment = HorzAlignment.Near } },
                                    IsFloatValue = false
                                },
                                Dock = DockStyle.Left,
                                Width = 220
                            };
                            this.panelValue.Controls.Add(edit2);
                        }
                        else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                        {
                            ZLSpinEdit edit3 = new ZLSpinEdit {
                                Enabled = !flag,
                                Properties = { 
                                    Appearance = { TextOptions = { HAlignment = HorzAlignment.Near } },
                                    IsFloatValue = true
                                },
                                EditScale = pField.Scale,
                                Dock = DockStyle.Left,
                                Width = 220
                            };
                            if (this.m_YbdFields.Contains<string>(pField.Name))
                            {
                                edit3.Properties.MinValue = 0M;
                                edit3.Properties.MaxValue = 1M;
                            }
                            this.panelValue.Controls.Add(edit3);
                        }
                        else if (pField.Type == esriFieldType.esriFieldTypeDate)
                        {
                            DateEdit edit4 = new DateEdit {
                                Enabled = !flag,
                                Properties = { 
                                    DisplayFormat = { 
                                        FormatString = "yyyy/MM/dd HH:mm:ss",
                                        FormatType = FormatType.DateTime
                                    },
                                    EditFormat = { 
                                        FormatString = "G",
                                        FormatType = FormatType.DateTime
                                    },
                                    Mask = { 
                                        EditMask = "G",
                                        MaskType = MaskType.DateTimeAdvancingCaret
                                    }
                                },
                                Text = "",
                                Dock = DockStyle.Left,
                                Width = 220
                            };
                            this.panelValue.Controls.Add(edit4);
                        }
                        else
                        {
                            TextEdit edit5 = new TextEdit {
                                Enabled = !flag,
                                Properties = { MaxLength = pField.Length },
                                Text = "",
                                Dock = DockStyle.Left,
                                Width = 220
                            };
                            this.panelValue.Controls.Add(edit5);
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetUniqueValue", "SetEditControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        public string SelectedField
        {
            set
            {
                if (value != "")
                {
                    this.m_CurrentFieldName = value;
                }
            }
        }

        public string UpdateField
        {
            set
            {
                this.m_CurrentFieldName = value;
                this.Init();
                this.m_bInit = true;
                this.SetEditControl();
                this.panellabel.Visible = true;
                this.panelField.Visible = false;
            }
        }

        public string UpdateFilter
        {
            set
            {
                this.m_Filter = value;
            }
        }

        public int UpdateType
        {
            set
            {
                this.m_UpdateType = value;
            }
        }

        public delegate void UpdateValuehandler();
    }
}

