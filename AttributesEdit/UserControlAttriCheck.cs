namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;
    using td.logic.sys;
    using td.db.orm;
    using System.Data.SqlClient;


    public class UserControlAttriCheck : UserControlBase1
    {
        private SimpleButton btnAAdd;
        private SimpleButton btnAAnd;
        private SimpleButton btnABigger;
        private SimpleButton btnABigger1;
        private SimpleButton btnAddRule;
        private SimpleButton btnADivide;
        private SimpleButton btnAEqual;
        private SimpleButton btnAIs;
        private SimpleButton btnALike;
        private SimpleButton btnAll;
        private SimpleButton btnAMultiply;
        private SimpleButton btnANot;
        private SimpleButton btnAOr;
        private SimpleButton btnAParent;
        private SimpleButton btnASmaller;
        private SimpleButton btnASmaller1;
        private SimpleButton btnASub;
        private SimpleButton btnAUnequal;
        private SimpleButton btnAUnique;
        private SimpleButton btnCheck;
        private SimpleButton btnCheckRule;
        private SimpleButton btnClear;
        private SimpleButton btnClearText;
        private SimpleButton btnDeleteRule;
        private SimpleButton btnExport;
        private SimpleButton btnLD;
        private SimpleButton btnSimple;
        private Button buttonPopClose;
        private CheckedListBoxControl checkedListBoxDIY;
        private ComboBoxEdit comboBoxType;
        private IContainer components;
        private GridControl gridControl1;
        private GridControl gridControlResult2;
        private GridView gridView1;
        private GridView gridViewResult2;
        private GroupControl groupControl1;
        private GroupControl groupControl6;
        private GroupControl groupControlResult;
        private GroupControl groupControlResult2;
        private LabelControl labelControl1;
        private LabelControl labelErrorDes;
        internal Label labelExport;
        private Label labelID;
        internal Label LabelLoadInfo;
        private LabelControl labelMessage;
        internal Label LabelProgressBack;
        internal Label LabelProgressBar;
        private LabelControl labelSelectFeature;
        private RichTextBox labelSQL;
        private LabelControl labelSqlCopy;
        private ListBoxControl listBoxError;
        private ListBoxControl listBoxFields;
        private ListBoxControl listBoxRule;
 
        private bool m_bDown;
        private bool m_bInit;
        private IFeatureLayer m_CheckLayer;
        private const string m_ClassName = "AttributesEdit.UserControlAttriCheck";
        private bool m_Clear;
        private string m_DesignKind = "";
        private bool m_DIY;
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IFields m_Fields;
        private IHookHelper m_HookHelper;
        private ArrayList m_IDList;
        private LogicErrors2 m_LogicError;
        private int m_offX;
        private int m_offY;
        private ArrayList m_ReadList;
        private DataTable m_RuleTable;
        private bool m_SelectAll;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private string m_TableName = "T_Logic_Check";
        private RichTextBox memoEditSql;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PanelControl panelA1;
        private PanelControl panelA2;
        private PanelControl panelA3;
        private PanelControl panelBar;
        private Panel panelBottom;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl4;
        private PanelControl panelControl6;
        private PanelControl panelControl7;
        private PanelControl panelControl8;
        private PanelControl panelControl9;
        private PanelControl panelDIY;
        private PanelControl panelError;
        private PanelControl panelOK;
        private PanelControl panelProcess;
        private PanelControl panelResult;
        private PanelControl panelResult2;
        private Panel panelResultList;
        private Panel panelRule;
        private Panel panelSql;
        private PanelControl panelSubList;
        private Panel panelTop;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonSetValue;
        private SimpleButton simpleButtonSQL;
        private SimpleButton simpleButtonXBH;
        private SplitContainer splitContainer1;
        private TextBox textBoxResult;
        private ToolTip toolTip1;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlAttriCheck()
        {
            this.InitializeComponent();
            this.comboBoxType.SelectedIndexChanged += new EventHandler(this.comboBoxType_SelectedIndexChanged);
            this.btnDeleteRule.Click += new EventHandler(this.btnDeleteRule_Click);
            this.btnAll.Click += new EventHandler(this.btnAll_Click);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnSimple.Click += new EventHandler(this.btnSimple_Click);
            this.btnCheck.Click += new EventHandler(this.btnCheck_Click);
            this.checkedListBoxDIY.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxDIY_ItemCheck);
            this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
            this.btnLD.Click += new EventHandler(this.btnLD_Click);
            this.btnCheckRule.Click += new EventHandler(this.btnCheckRule_Click);
            this.labelSelectFeature.Click += new EventHandler(this.labelSelectFeature_Click);
            this.listBoxError.SelectedIndexChanged += new EventHandler(this.listBoxError_SelectedIndexChanged);
            this.listBoxError.MouseMove += new MouseEventHandler(this.listBoxError_MouseMove);
            this.gridControlResult2.DoubleClick += new EventHandler(this.gridControlResult2_DoubleClick);
            this.simpleButtonSetValue.Click += new EventHandler(this.simpleButtonSetValue_Click);
            this.simpleButtonSelect.Click += new EventHandler(this.simpleButtonSelect_Click);
        }

        private void btnAAdd_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " + " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnAAnd_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " AND " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 5;
        }

        private void btnABigger_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " > " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnABigger1_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " >= " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            string str = this.memoEditSql.Text.Replace("'", "''").Replace("\"", "\"\"");
            string sCmdText = "";
            if (str.Contains("UNIQUE"))
            {
                int index = str.IndexOf("UNIQUE(");
                if (index < 0)
                {
                    MessageBox.Show("规则设置不正确，无法添加！");
                    return;
                }
                int num2 = str.IndexOf(")");
                if (num2 < 0)
                {
                    MessageBox.Show("规则设置不正确，无法添加！");
                    return;
                }
                string str3 = str.Substring(index + 7, (num2 - index) - 7);
                sCmdText = "insert into " + this.m_TableName + " (DESIGN_KIND,CHECK_FIELD,CHECK_TYPE,FIELD_ALIAS,ERROR_DESCRIP,ENABLED,ISEDIT) values ('" + this.m_DesignKind + "','" + str3 + "','UNIQUE','" + str3 + "','不能重复',1,1)";
            }
            else
            {
                sCmdText = "insert into " + this.m_TableName + " (DESIGN_KIND,CHECK_RULE,ERROR_DESCRIP,ENABLED,ISEDIT) values ('" + this.m_DesignKind + "','" + str + "','" + str + "',1,1)";
            }
            try
            {
                this.ExecuteNonQuery(sCmdText);
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "btnAddRule_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            this.RefreshRule();
            this.checkedListBoxDIY.SelectedIndex = this.checkedListBoxDIY.Items.Count;
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
        private void btnADivide_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " / " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnAEqual_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " = " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnAIs_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " IS " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnALike_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " LIKE " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 6;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.m_SelectAll = true;
            for (int i = 0; i < this.checkedListBoxDIY.Items.Count; i++)
            {
                if (this.checkedListBoxDIY.Items[i].CheckState == CheckState.Unchecked)
                {
                    this.checkedListBoxDIY.SetItemCheckState(i, CheckState.Checked);
                }
            }
            try
            {
                string sCmdText = "";
                string str2 = "1";
                sCmdText = "update " + this.m_TableName + " set enabled=" + str2 + " where design_kind like '" + this.m_DesignKind + "%' and isedit=1";
                this.ExecuteNonQuery(sCmdText);
            }
            catch
            {
            }
            this.m_SelectAll = false;
        }

        private void btnAMultiply_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " * " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnANot_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " NOT " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 5;
        }

        private void btnAOr_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " OR " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnAParent_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " () " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnASmaller_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " < " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnASmaller1_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " <= " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnASub_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " - " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 3;
        }

        private void btnAUnequal_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = text.Substring(0, selectionStart) + " <> " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = selectionStart + 4;
        }

        private void btnAUnique_Click(object sender, EventArgs e)
        {
            string text = this.memoEditSql.Text;
            int selectionStart = this.memoEditSql.SelectionStart;
            text = "UNIQUE() " + text.Substring(selectionStart, text.Length - selectionStart);
            this.memoEditSql.Text = text;
            this.memoEditSql.Focus();
            this.memoEditSql.SelectionStart = 7;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Editor.UniqueInstance.IsBeingEdited)
            {
           //     if (!Editor.UniqueInstance.StopEdit2())
           //     {
            //        MessageBox.Show("提交数据到服务器时有冲突，请等待几秒后再次校验！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return;
            //    }
            //    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                Editor.UniqueInstance.StopEdit3();
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
            }
            else
            {
                MessageBox.Show("未打开编辑状态，无法进行逻辑校验！", "提示");
                goto Label_01F5;
            }
            this.panelResult2.Visible = false;
            this.panelSql.Visible = false;
            this.simpleButtonSQL.Visible = false;
            if ((this.m_RuleTable != null) && (this.m_RuleTable.Rows.Count >= 1))
            {
                this.btnExport.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                this.panelProcess.Visible = false;
                this.panelBar.Visible = true;
                string kindCode = EditTask.KindCode;
                LogicErrors2 errors = this.CheckAttr2(this.m_CheckLayer, this.m_RuleTable, "");
                this.m_LogicError = errors;
                this.panelBar.Visible = false;
                if (errors == null)
                {
                    this.panelResult2.Visible = false;
                    this.panelProcess.Visible = true;
                    this.labelMessage.Text = "校验过程出错！请检查校验规则是否正确。";
                }
                else if (errors.Count < 1)
                {
                    EditTask.LogicChkState = LogicCheckState.Success;
                    this.panelResult2.Visible = false;
                    this.panelProcess.Visible = true;
                    this.labelMessage.Text = "属性校验已通过。";
                }
                else
                {
                    this.listBoxError.Items.Clear();
                    for (int i = 0; i < errors.Count; i++)
                    {
                        this.listBoxError.Items.Add(errors.GetDescription(i));
                    }
                    this.labelErrorDes.Text = "共有" + errors.Count + "条规则未通过校验";
                    this.panelResult2.Visible = true;
                    this.panelError.Visible = true;
                    this.btnExport.Visible = true;
                }
            }
        Label_01F5:
            this.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void btnCheckRule_Click(object sender, EventArgs e)
        {
            string text = this.labelID.Text;
            try
            {
                IFeature pFeature = null;
                IFeatureClass featureClass = this.m_CheckLayer.FeatureClass;
                int iD = Convert.ToInt32(text);
                pFeature = featureClass.GetFeature(iD);
                if (pFeature != null)
                {
                    string str2 = CheckAttributes.CheckFeatureAttr(this.m_CheckLayer, pFeature);
                    this.textBoxResult.Text = str2;
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "buttonRecheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.m_Clear = true;
            for (int i = 0; i < this.checkedListBoxDIY.Items.Count; i++)
            {
                if (this.checkedListBoxDIY.Items[i].CheckState == CheckState.Checked)
                {
                    this.checkedListBoxDIY.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            try
            {
                string sCmdText = "";
                string str2 = "0";
                sCmdText = "update " + this.m_TableName + " set enabled=" + str2 + " where design_kind like '" + this.m_DesignKind + "%' and isedit=1";
                this.ExecuteNonQuery(sCmdText);
            }
            catch
            {
            }
            this.m_Clear = false;
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            this.memoEditSql.Text = "";
        }

        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.checkedListBoxDIY.SelectedIndex;
            if (selectedIndex >= 0)
            {
                if (this.m_ReadList[selectedIndex].ToString().ToLower() == "true")
                {
                    MessageBox.Show("此规则为系统设置规则，无法删除！");
                }
                else
                {
                    try
                    {
                        string sCmdText = "";
                        sCmdText = string.Concat(new object[] { "delete from ", this.m_TableName, " where ID=", this.m_IDList[selectedIndex] });
                        this.ExecuteNonQuery(sCmdText);
                    }
                    catch (Exception exception)
                    {
                        this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "btnDeleteRule_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    this.RefreshRule();
                    if (selectedIndex > 0)
                    {
                        this.checkedListBoxDIY.SelectedIndex = selectedIndex - 1;
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.labelExport.Visible = true;
            Application.DoEvents();
            this.ExportDbf2();
            this.labelExport.Visible = false;
        }

        private void btnLD_Click(object sender, EventArgs e)
        {
            try
            {
                string sCmdText = "";
                string str2 = "1";
                sCmdText = "update " + this.m_TableName + " set enabled=" + str2 + " where DESIGN_KIND like '" + this.m_DesignKind + "%' and isedit=1 and ISEXPORT=1";
                this.ExecuteNonQuery(sCmdText);
                sCmdText = "update " + this.m_TableName + " set enabled=0 where DESIGN_KIND like '" + this.m_DesignKind + "%' and isedit=1 and ISEXPORT=0";
                this.ExecuteNonQuery(sCmdText);
            }
            catch
            {
            }
            this.RefreshRule();
        }

        private void btnSimple_Click(object sender, EventArgs e)
        {
            try
            {
                string sCmdText = "";
                string str2 = "1";
                sCmdText = "update " + this.m_TableName + " set enabled=" + str2 + " where DESIGN_KIND like '" + this.m_DesignKind + "%' and isedit=1 and isFirst=1";
                this.ExecuteNonQuery(sCmdText);
                sCmdText = "update " + this.m_TableName + " set enabled=0 where DESIGN_KIND like '" + this.m_DesignKind + "%' and isedit=1 and isFirst=0";
                this.ExecuteNonQuery(sCmdText);
            }
            catch
            {
            }
            this.RefreshRule();
        }

        private void buttonPopClose_Click(object sender, EventArgs e)
        {
            this.panelResultList.Visible = false;
        }

        private DataTable Check(IFeatureLayer pFLayer)
        {
            if (pFLayer == null)
            {
                return null;
            }
            string sSubField = "";
            DataTable table = null;
            if (UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "MapDBkey").ToLower() != "sqlserver")
            {
                table = this.CheckAttr1(pFLayer, this.m_RuleTable, sSubField);
            }
            return table;
        }

        public DataTable CheckAttr1(IFeatureLayer pFLayer, DataTable pRuleTable, string sSubField)
        {
            if (pFLayer == null)
            {
                return null;
            }
            ITable featureClass = pFLayer.FeatureClass as ITable;
            if (featureClass == null)
            {
                return null;
            }
            try
            {
                int iValue = 5;
                this.SetLoadInfo("开始进行逻辑校验……", iValue);
                string definitionExpression = "";
                if (EditTask.KindCode.Length > 4)
                {
                    IFeatureLayerDefinition definition = pFLayer as IFeatureLayerDefinition;
                    definitionExpression = definition.DefinitionExpression;
                }
                LogicErrors errors = new LogicErrors();
                IQueryFilter queryFilter = new QueryFilterClass {
                    SubFields = featureClass.OIDFieldName
                };
                DataRow[] rowArray = pRuleTable.Select("CHECK_TYPE='UNIQUE'");
                if (rowArray.Length > 0)
                {
                    ICursor o = null;
                    if (definitionExpression != "")
                    {
                        queryFilter.WhereClause = definitionExpression;
                        o = featureClass.Search(queryFilter, false);
                    }
                    else
                    {
                        o = featureClass.Search(null, false);
                    }
                    IRow row = null;
                    ArrayList pList = new ArrayList();
                    while ((row = o.NextRow()) != null)
                    {
                        pList.Add(row);
                    }
                    Marshal.ReleaseComObject(o);
                    o = null;
                    ArrayList list2 = new ArrayList();
                    for (int k = 0; k < rowArray.Length; k++)
                    {
                        string[] sFieldNames = rowArray[k]["CHECK_FIELD"].ToString().Replace(" ", "").Split(new char[] { '+' });
                        string sDes = rowArray[k]["FIELD_ALIAS"] + rowArray[k]["ERROR_DESCRIP"].ToString();
                        this.SetLoadInfo("正在校验 [" + sDes + "]", iValue + ((k * 20) / rowArray.Length));
                        list2 = this.CheckUnique(pList, sFieldNames);
                        if ((list2 != null) & (list2.Count > 0))
                        {
                            for (int m = 0; m < list2.Count; m++)
                            {
                                errors.AddError(list2[m].ToString(), sDes);
                            }
                        }
                    }
                    iValue = 0x19;
                }
                GC.Collect();
                string str4 = "";
                queryFilter = new QueryFilterClass {
                    SubFields = featureClass.OIDFieldName
                };
                int count = pRuleTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataRow row2 = pRuleTable.Rows[i];
                    row2["CHECK_FIELD"].ToString();
                    str4 = row2["CHECK_TYPE"].ToString();
                    string str5 = row2["CHECK_RULE"].ToString();
                    string str6 = row2["FIELD_ALIAS"] + row2["ERROR_DESCRIP"].ToString();
                    if (str4.ToLower() != "unique")
                    {
                        this.SetLoadInfo("正在校验 [" + str6 + "]", iValue + ((i * 90) / count));
                        if (definitionExpression != "")
                        {
                            queryFilter.WhereClause = definitionExpression + " and " + str5;
                        }
                        else
                        {
                            queryFilter.WhereClause = str5;
                        }
                        ICursor cursor2 = featureClass.Search(queryFilter, false);
                        if (cursor2 != null)
                        {
                            IRow row3 = null;
                            while ((row3 = cursor2.NextRow()) != null)
                            {
                                errors.AddError(row3.OID.ToString(), str6);
                            }
                            Marshal.ReleaseComObject(cursor2);
                            cursor2 = null;
                            GC.Collect();
                        }
                    }
                }
                this.SetLoadInfo("校验完成", 100);
                DataTable table2 = new DataTable();
                DataColumn column = new DataColumn {
                    Caption = "编号",
                    ColumnName = "编号",
                    DataType = typeof(string),
                    MaxLength = 10
                };
                DataColumn column2 = new DataColumn {
                    Caption = "OID",
                    ColumnName = "OID",
                    DataType = typeof(string),
                    MaxLength = 20
                };
                DataColumn column3 = new DataColumn {
                    Caption = "校验结果",
                    ColumnName = "校验结果",
                    DataType = System.Type.GetType("System.String"),
                    MaxLength = 350
                };
                table2.Columns.AddRange(new DataColumn[] { column, column2, column3 });
                for (int j = 0; j < errors.Count; j++)
                {
                    DataRow row4 = table2.NewRow();
                    row4[0] = j + 1;
                    row4[1] = errors.GetKey(j);
                    row4[2] = errors.GetDescription(j);
                    table2.Rows.Add(row4);
                }
                return table2;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "CheckAttr1", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        public LogicErrors2 CheckAttr2(IFeatureLayer pFLayer, DataTable pRuleTable, string sSubField)
        {
            if (pFLayer == null)
            {
                return null;
            }
            IFeatureClass featureClass = pFLayer.FeatureClass;
            if (featureClass == null)
            {
                return null;
            }
            string oIDFieldName = featureClass.OIDFieldName;
            IDataset dataset = (IDataset) featureClass;
            string name = dataset.Name;
            //IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBkey"));
            //if (dBAccess == null)
            //{
            //    MessageBox.Show("数据库连接有错！", "提示");
            //    return null;
            //}
            try
            {
                int iValue = 5;
                this.SetLoadInfo("开始进行逻辑校验……", iValue);
                string definitionExpression = "";
                if (EditTask.KindCode.Length > 4)
                {
                    IFeatureLayerDefinition definition = pFLayer as IFeatureLayerDefinition;
                    definitionExpression = definition.DefinitionExpression;
                }
                LogicErrors2 errors = new LogicErrors2();
                string str5 = "";
                string sRuleType = "";
                int count = pRuleTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    GC.Collect();
                    DataRow row = pRuleTable.Rows[i];
                    str5 = row["CHECK_FIELD"].ToString().Replace(" ", "");
                    sRuleType = row["CHECK_TYPE"].ToString();
                    string str7 = row["CHECK_RULE"].ToString();
                    string str8 = row["FIELD_ALIAS"] + row["ERROR_DESCRIP"].ToString();
                    this.SetLoadInfo("正在校验 [" + str8 + "]", iValue + ((i * 90) / count));
                    string sql = "";
                    if (sRuleType.ToLower() == "unique")
                    {
                        string str10 = "select " + str5 + " from " + name + " group by " + str5 + " having count(*)>1";
                        DataTable table = null;// dBAccess.GetDataTable(dBAccess, str10);
                        if ((table == null) || (table.Rows.Count < 1))
                        {
                            continue;
                        }
                        sql = "select " + oIDFieldName + " from " + name + " where ";
                        string str11 = "";
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            object obj2 = table.Rows[j][0];
                            if ((obj2 == null) || (obj2 == DBNull.Value))
                            {
                                str11 = str11 + " or (" + str5 + " is null)";
                            }
                            else
                            {
                                int index = featureClass.FindField(str5);
                                if ((index < 0) && (str5.IndexOf('+') >= 0))
                                {
                                    string str12 = str5.Substring(0, str5.IndexOf('+'));
                                    index = featureClass.FindField(str12);
                                }
                                if (index < 0)
                                {
                                    break;
                                }
                                if (featureClass.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                                {
                                    string str15 = str11;
                                    str11 = str15 + " or (" + str5 + "='" + obj2.ToString() + "')";
                                }
                                else
                                {
                                    string str16 = str11;
                                    str11 = str16 + " or (" + str5 + "=" + obj2.ToString() + ")";
                                }
                            }
                        }
                        if (str11 == "")
                        {
                            continue;
                        }
                        str11 = str11.Substring(4);
                        sql = sql + str11;
                        if (definitionExpression != "")
                        {
                            sql = sql + " and (" + definitionExpression + ")";
                        }
                    }
                    else if (sRuleType.ToLower() == "incode")
                    {
                        string str13 = "T_SYS_META_CODE";
                        sql = "select " + oIDFieldName + " from " + name + " where (" + str5 + "<>'') and (" + str5 + " is not null) and (" + str5 + " not in (select CCODE from " + str13 + " where CTYPE='" + str7 + "'))";
                        if (definitionExpression != "")
                        {
                            sql = sql + " and (" + definitionExpression + ")";
                        }
                    }
                    else
                    {
                        sql = "select " + oIDFieldName + " from " + name + " where (" + str7 + ")";
                        if (definitionExpression != "")
                        {
                            sql = sql + " and (" + definitionExpression + ")";
                        }
                    }
                    DataTable dataTable = new DataTable();
                    // dBAccess.GetDataTable(dBAccess, sql);
                    SqlCommand tmp = new SqlCommand(sql, td.db.orm.mssql.TDMSSqlDBConnection.Single.MSSqlCon);

                    SqlDataAdapter tmp1 = new SqlDataAdapter(tmp);
                    tmp1.Fill(dataTable);
                    if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                    {
                        IList<int> pIDs = new List<int>();
                        for (int k = 0; k < dataTable.Rows.Count; k++)
                        {
                            pIDs.Add(int.Parse(dataTable.Rows[k][0].ToString()));
                        }
                        string sSql = sql.Substring(sql.IndexOf("where") + 5);
                        errors.AddError((i + 1) + "  " + str8, str5, sSql, sRuleType, pIDs);
                    }
                }
                this.SetLoadInfo("校验完成", 100);
                return errors;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "CheckAttr2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void checkedListBoxDIY_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if ((this.m_DIY && !this.m_Clear) && !this.m_SelectAll)
            {
                int selectedIndex = this.checkedListBoxDIY.SelectedIndex;
                this.SaveDIY(selectedIndex);
            }
        }

        private ArrayList CheckUnique(ArrayList pList, string[] sFieldNames)
        {
            if (pList == null)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();
            for (int i = 0; i < pList.Count; i++)
            {
                IObject pObj = pList[i] as IObject;
                string item = "";
                for (int j = 0; j < sFieldNames.Length; j++)
                {
                    item = item + DataFuncs.GetFieldValue(pObj, sFieldNames[j]).ToString();
                }
                if (list3.Contains(item))
                {
                    list2.Add(item);
                    string str2 = list4[i].ToString();
                    if (!list4.Contains(str2))
                    {
                        list.Add(str2);
                    }
                    list.Add(pObj.OID.ToString());
                }
                else
                {
                    list3.Add(item);
                }
            }
            return list;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxType.SelectedIndex == 1)
            {
                this.panelA1.Visible = false;
                this.panelA2.Visible = false;
                this.panelA3.Visible = false;
                this.panel5.Visible = false;
                this.panelControl7.Visible = false;
                this.RefreshFields();
            }
            else if (this.comboBoxType.SelectedIndex == 0)
            {
                this.panelA1.Visible = false;
                this.panelA2.Visible = false;
                this.panelA3.Visible = false;
                this.panel5.Visible = false;
                this.panelControl7.Visible = false;
                this.RefreshFields();
            }
            else if (this.comboBoxType.SelectedIndex == 2)
            {
                this.panelA1.Visible = true;
                this.panelA2.Visible = false;
                this.panelA3.Visible = false;
                this.panel5.Visible = true;
                this.panelControl7.Visible = true;
                this.listBoxFields.Items.Clear();
                for (int i = 0; i < this.m_Fields.FieldCount; i++)
                {
                    IField field = this.m_Fields.get_Field(i);
                    if (((field.Type != esriFieldType.esriFieldTypeGeometry) && (field.Type != esriFieldType.esriFieldTypeOID)) && (((field.Type == esriFieldType.esriFieldTypeDouble) || (field.Type == esriFieldType.esriFieldTypeInteger)) || (field.Type == esriFieldType.esriFieldTypeSmallInteger)))
                    {
                        this.listBoxFields.Items.Add(field.AliasName + "[" + field.Name + "]");
                    }
                }
            }
            else if (this.comboBoxType.SelectedIndex == 3)
            {
                this.panelA1.Visible = true;
                this.panelA2.Visible = false;
                this.panelA3.Visible = true;
                this.panel5.Visible = true;
                this.panelControl7.Visible = true;
                this.RefreshFields();
            }
            else if (this.comboBoxType.SelectedIndex == 4)
            {
                this.panelA1.Visible = true;
                this.panelA2.Visible = true;
                this.panelA3.Visible = true;
                this.panel5.Visible = true;
                this.panelControl7.Visible = true;
                this.RefreshFields();
            }
        }

        private bool CreateTable(OleDbConnection pConnection, string sSql)
        {
            try
            {
                if (pConnection.State == ConnectionState.Closed)
                {
                    pConnection.Open();
                }
                OleDbCommand command = new OleDbCommand {
                    Connection = pConnection
                };
                OleDbTransaction transaction = pConnection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = sSql;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    pConnection.Close();
                    return false;
                }
                transaction.Dispose();
                transaction = null;
                command = null;
                pConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
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

        private void ExportDbf(DataTable pSourceTable)
        {
            string sFullFilePath = "";
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "dbf",
                FileName = "属性校验结果",
                Filter = "DBF文件 (*.dbf)|*.dbf",
                OverwritePrompt = true,
                Title = "导出校验结果"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sFullFilePath = dialog.FileName.Trim();
                dialog = null;
                this.ExportDbf(pSourceTable, sFullFilePath);
            }
        }

        private void ExportDbf(DataTable pDataTable, string sFullFilePath)
        {
            try
            {
                if ((pDataTable == null) || (pDataTable.Rows.Count < 1))
                {
                    XtraMessageBox.Show(this, "导出数据为空！", "逻辑校验");
                }
                else if (sFullFilePath != string.Empty)
                {
                    if (File.Exists(sFullFilePath))
                    {
                        File.Delete(sFullFilePath);
                    }
                    string fullName = Directory.GetParent(sFullFilePath).FullName;
                    int num = sFullFilePath.LastIndexOf(@"\");
                    string sTableName = sFullFilePath.Substring(num + 1);
                    int index = sTableName.IndexOf(".");
                    string str3 = sTableName.Substring(0, index);
                    OleDbConnection pConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullName + ";Extended Properties=dBASE 5.0");
                    string sSql = "";
                    sSql = "create table " + str3 + "(";
                    string columnName = "";
                    for (int i = 0; i < pDataTable.Columns.Count; i++)
                    {
                        columnName = pDataTable.Columns[i].ColumnName;
                        int maxLength = pDataTable.Columns[i].MaxLength;
                        sSql = (sSql + columnName + " " + this.GetFieldDataType(pDataTable.Columns[i].DataType.Name, maxLength)) + ",";
                    }
                    sSql = sSql.Substring(0, sSql.Length - 1) + ")";
                    if (!this.CreateTable(pConnection, sSql))
                    {
                        XtraMessageBox.Show(this, "导出失败！", "逻辑校验");
                    }
                    else if (this.ImportData(pConnection, pDataTable, sTableName))
                    {
                        XtraMessageBox.Show(this, "导出成功！", "逻辑校验");
                    }
                    else
                    {
                        XtraMessageBox.Show(this, "导出失败！", "逻辑校验");
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "ExportDbf", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                XtraMessageBox.Show(this, "导出失败！", "逻辑校验");
            }
        }

        private void ExportDbf2()
        {
            string sFullFilePath = "";
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "dbf",
                FileName = "属性校验结果",
                Filter = "DBF文件 (*.dbf)|*.dbf",
                OverwritePrompt = true,
                Title = "导出校验结果"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sFullFilePath = dialog.FileName.Trim();
                    dialog = null;
                    DataTable pDataTable = new DataTable();
                    DataColumn column = new DataColumn {
                        Caption = "校验规则",
                        ColumnName = "校验规则",
                        DataType = typeof(string),
                        MaxLength = 100
                    };
                    pDataTable.Columns.Add(column);
                    column = new DataColumn {
                        Caption = "错误要素",
                        ColumnName = "错误要素",
                        DataType = typeof(string),
                        MaxLength = 20
                    };
                    pDataTable.Columns.Add(column);
                    for (int i = 0; i < this.listBoxError.ItemCount; i++)
                    {
                        IList<int> errorIDS = (IList<int>) this.m_LogicError.GetErrorIDS(i);
                        string description = this.m_LogicError.GetDescription(i);
                        for (int j = 0; j < errorIDS.Count; j++)
                        {
                            DataRow row = pDataTable.NewRow();
                            row[0] = description;
                            row[1] = errorIDS[j];
                            pDataTable.Rows.Add(row);
                        }
                    }
                    this.ExportDbf(pDataTable, sFullFilePath);
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "ExportDbf2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    XtraMessageBox.Show(this, "导出失败！", "逻辑校验");
                }
            }
        }

        private string GetFieldDataType(string sDataType, int iMaxLength)
        {
            string str = "";
            string str2 = sDataType.ToLower();
            if (str2 != null)
            {
                if (str2 == "string")
                {
                    sDataType = "varchar";
                }
                else if (str2 == "decimal")
                {
                    sDataType = "float";
                    iMaxLength = -1;
                }
                else if (str2 == "int")
                {
                    sDataType = "integer";
                    iMaxLength = -1;
                }
                else if (str2 == "datetime")
                {
                    sDataType = "date";
                    iMaxLength = -1;
                }
            }
            str = sDataType;
            if (iMaxLength <= 0)
            {
                return str;
            }
            if (iMaxLength > 0xfe)
            {
                iMaxLength = 0xfe;
            }
            object obj2 = str;
            return string.Concat(new object[] { obj2, "(", iMaxLength, ")" });
        }

        private void gridControlResult2_DoubleClick(object sender, EventArgs e)
        {
            DataRow focusedDataRow = this.gridViewResult2.GetFocusedDataRow();
            if (focusedDataRow != null)
            {
                string sOID = focusedDataRow[1].ToString();
                this.ZoomErrorFeature(sOID);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow focusedDataRow = this.gridView1.GetFocusedDataRow();
            if (focusedDataRow != null)
            {
                string sOID = focusedDataRow[1].ToString();
                this.ZoomErrorFeature(sOID);
                string[] strArray = focusedDataRow[2].ToString().Split(new char[] { '\\' });
                string str3 = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    str3 = str3 + "\r\n  " + strArray[i] + "。";
                }
                this.panelResultList.Visible = false;
                this.labelID.Text = sOID;
                this.textBoxResult.Text = str3.Substring(2);
                this.panelResultList.Visible = true;
            }
        }

        private bool ImportData(OleDbConnection pConnection, DataTable pDataTable, string sTableName)
        {
            try
            {
                if (pConnection == null)
                {
                    return false;
                }
                if (pConnection.State == ConnectionState.Closed)
                {
                    pConnection.Open();
                }
                string str = "";
                str = "Select  *  From  [" + sTableName + "]";
                OleDbCommand selectCommand = new OleDbCommand {
                    Connection = pConnection
                };
                OleDbTransaction transaction = pConnection.BeginTransaction();
                selectCommand.Transaction = transaction;
                try
                {
                    selectCommand.CommandText = str;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
                    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter) {
                        QuotePrefix = "[",
                        QuoteSuffix = "]"
                    };
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, sTableName);
                    DataTable table = dataSet.Tables[0];
                    foreach (DataRow row in pDataTable.Rows)
                    {
                        table.Rows.Add(row.ItemArray);
                    }
                    adapter.Update(dataSet, sTableName);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    pConnection.Close();
                    return false;
                }
                transaction.Dispose();
                transaction = null;
                selectCommand = null;
                pConnection.Close();
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "ImportData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public void Init(IFeatureLayer pLayer, object pHook)
        {
            this.panelBar.Visible = false;
            this.panelSql.Visible = false;
     
            if ((EditTask.KindCode.Substring(0, 2) == "08") && EditTask.LayerName.Contains("XIAOBAN"))
            {
                this.btnLD.Visible = true;
            }
            else
            {
                this.btnLD.Visible = false;
            }
            if (!this.m_bInit)
            {
                this.labelSelectFeature.Visible = false;
                this.RefreshCheckRule();
            }
            this.panelResultList.Visible = false;
            this.m_CheckLayer = pLayer;
            if (this.m_HookHelper == null)
            {
                this.m_HookHelper = new HookHelperClass();
            }
            this.m_HookHelper.Hook = pHook;
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelResult = new DevExpress.XtraEditors.PanelControl();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.labelSelectFeature = new DevExpress.XtraEditors.LabelControl();
            this.panelResultList = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCheckRule = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelID = new System.Windows.Forms.Label();
            this.buttonPopClose = new System.Windows.Forms.Button();
            this.listBoxRule = new DevExpress.XtraEditors.ListBoxControl();
            this.panelOK = new DevExpress.XtraEditors.PanelControl();
            this.labelExport = new System.Windows.Forms.Label();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.panelProcess = new DevExpress.XtraEditors.PanelControl();
            this.labelMessage = new DevExpress.XtraEditors.LabelControl();
            this.panelBar = new DevExpress.XtraEditors.PanelControl();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelRule = new System.Windows.Forms.Panel();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.btnClearText = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddRule = new DevExpress.XtraEditors.SimpleButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.memoEditSql = new System.Windows.Forms.RichTextBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.listBoxFields = new DevExpress.XtraEditors.ListBoxControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelA3 = new DevExpress.XtraEditors.PanelControl();
            this.btnAUnique = new DevExpress.XtraEditors.SimpleButton();
            this.btnAParent = new DevExpress.XtraEditors.SimpleButton();
            this.btnADivide = new DevExpress.XtraEditors.SimpleButton();
            this.btnAMultiply = new DevExpress.XtraEditors.SimpleButton();
            this.btnASub = new DevExpress.XtraEditors.SimpleButton();
            this.btnAAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelA2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAIs = new DevExpress.XtraEditors.SimpleButton();
            this.btnANot = new DevExpress.XtraEditors.SimpleButton();
            this.btnAOr = new DevExpress.XtraEditors.SimpleButton();
            this.btnAAnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnALike = new DevExpress.XtraEditors.SimpleButton();
            this.panelA1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnASmaller1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnASmaller = new DevExpress.XtraEditors.SimpleButton();
            this.btnAUnequal = new DevExpress.XtraEditors.SimpleButton();
            this.btnABigger1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnABigger = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelResult2 = new DevExpress.XtraEditors.PanelControl();
            this.panelError = new DevExpress.XtraEditors.PanelControl();
            this.listBoxError = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.labelErrorDes = new DevExpress.XtraEditors.LabelControl();
            this.panelSubList = new DevExpress.XtraEditors.PanelControl();
            this.panelSql = new System.Windows.Forms.Panel();
            this.labelSQL = new System.Windows.Forms.RichTextBox();
            this.labelSqlCopy = new DevExpress.XtraEditors.LabelControl();
            this.groupControlResult2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlResult2 = new DevExpress.XtraGrid.GridControl();
            this.gridViewResult2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonXBH = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSQL = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSetValue = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelDIY = new DevExpress.XtraEditors.PanelControl();
            this.checkedListBoxDIY = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnLD = new DevExpress.XtraEditors.SimpleButton();
            this.btnSimple = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteRule = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelResult)).BeginInit();
            this.panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            this.panelResultList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOK)).BeginInit();
            this.panelOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProcess)).BeginInit();
            this.panelProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).BeginInit();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panelRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFields)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelA3)).BeginInit();
            this.panelA3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelA2)).BeginInit();
            this.panelA2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelA1)).BeginInit();
            this.panelA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelResult2)).BeginInit();
            this.panelResult2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelError)).BeginInit();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            this.panelControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSubList)).BeginInit();
            this.panelSubList.SuspendLayout();
            this.panelSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult2)).BeginInit();
            this.groupControlResult2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResult2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDIY)).BeginInit();
            this.panelDIY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxDIY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(341, 96);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelResult
            // 
            this.panelResult.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelResult.Controls.Add(this.groupControlResult);
            this.panelResult.Location = new System.Drawing.Point(0, 346);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(345, 120);
            this.panelResult.TabIndex = 3;
            this.panelResult.Visible = false;
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.labelSelectFeature);
            this.groupControlResult.Controls.Add(this.panelResultList);
            this.groupControlResult.Controls.Add(this.gridControl1);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlResult.Location = new System.Drawing.Point(0, 0);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Size = new System.Drawing.Size(345, 120);
            this.groupControlResult.TabIndex = 7;
            this.groupControlResult.Text = "    校验结果";
            // 
            // labelSelectFeature
            // 
            this.labelSelectFeature.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectFeature.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelSelectFeature.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSelectFeature.Location = new System.Drawing.Point(8, 4);
            this.labelSelectFeature.Name = "labelSelectFeature";
            this.labelSelectFeature.Size = new System.Drawing.Size(16, 16);
            this.labelSelectFeature.TabIndex = 11;
            this.labelSelectFeature.ToolTip = "在地图上选中校验结果中的所有要素";
            // 
            // panelResultList
            // 
            this.panelResultList.Controls.Add(this.panel2);
            this.panelResultList.Location = new System.Drawing.Point(126, 12);
            this.panelResultList.Name = "panelResultList";
            this.panelResultList.Size = new System.Drawing.Size(180, 210);
            this.panelResultList.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panelBottom);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel2.Size = new System.Drawing.Size(180, 210);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textBoxResult);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 18);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel4.Size = new System.Drawing.Size(174, 165);
            this.panel4.TabIndex = 1;
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.Color.White;
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Location = new System.Drawing.Point(0, 0);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(174, 163);
            this.textBoxResult.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.btnCheckRule);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 183);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(0, 1, 20, 1);
            this.panelBottom.Size = new System.Drawing.Size(174, 24);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCheckRule
            // 
            this.btnCheckRule.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCheckRule.Location = new System.Drawing.Point(119, 1);
            this.btnCheckRule.Name = "btnCheckRule";
            this.btnCheckRule.Size = new System.Drawing.Size(35, 22);
            this.btnCheckRule.TabIndex = 2;
            this.btnCheckRule.Text = "验证";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelTop);
            this.panel3.Controls.Add(this.buttonPopClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.panel3.Size = new System.Drawing.Size(174, 18);
            this.panel3.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelID);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 1);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(154, 16);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(4, 1);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 14);
            this.labelID.TabIndex = 0;
            // 
            // buttonPopClose
            // 
            this.buttonPopClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonPopClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPopClose.Font = new System.Drawing.Font("Tahoma", 9F);
            this.buttonPopClose.Location = new System.Drawing.Point(154, 1);
            this.buttonPopClose.Name = "buttonPopClose";
            this.buttonPopClose.Size = new System.Drawing.Size(20, 16);
            this.buttonPopClose.TabIndex = 0;
            this.buttonPopClose.UseVisualStyleBackColor = false;
            this.buttonPopClose.Click += new System.EventHandler(this.buttonPopClose_Click);
            // 
            // listBoxRule
            // 
            this.listBoxRule.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.listBoxRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxRule.HorizontalScrollbar = true;
            this.listBoxRule.Location = new System.Drawing.Point(2, 22);
            this.listBoxRule.Name = "listBoxRule";
            this.listBoxRule.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxRule.Size = new System.Drawing.Size(340, 180);
            this.listBoxRule.TabIndex = 0;
            // 
            // panelOK
            // 
            this.panelOK.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelOK.Controls.Add(this.labelExport);
            this.panelOK.Controls.Add(this.btnExport);
            this.panelOK.Controls.Add(this.panelControl1);
            this.panelOK.Controls.Add(this.btnCheck);
            this.panelOK.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOK.Location = new System.Drawing.Point(0, 211);
            this.panelOK.Name = "panelOK";
            this.panelOK.Padding = new System.Windows.Forms.Padding(0, 3, 12, 3);
            this.panelOK.Size = new System.Drawing.Size(344, 33);
            this.panelOK.TabIndex = 1;
            // 
            // labelExport
            // 
            this.labelExport.BackColor = System.Drawing.Color.Transparent;
            this.labelExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelExport.Location = new System.Drawing.Point(17, 11);
            this.labelExport.Name = "labelExport";
            this.labelExport.Size = new System.Drawing.Size(165, 19);
            this.labelExport.TabIndex = 14;
            this.labelExport.Text = "正在导出，请稍候...";
            this.labelExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelExport.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(210, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(55, 27);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(265, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(12, 27);
            this.panelControl1.TabIndex = 2;
            // 
            // btnCheck
            // 
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCheck.Location = new System.Drawing.Point(277, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(55, 27);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "校验";
            // 
            // panelProcess
            // 
            this.panelProcess.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProcess.Controls.Add(this.labelMessage);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProcess.Location = new System.Drawing.Point(0, 295);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(344, 51);
            this.panelProcess.TabIndex = 5;
            this.panelProcess.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(104, 17);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(128, 14);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "正在校验，请等待……";
            // 
            // panelBar
            // 
            this.panelBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBar.Controls.Add(this.LabelProgressBack);
            this.panelBar.Controls.Add(this.LabelProgressBar);
            this.panelBar.Controls.Add(this.LabelLoadInfo);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 244);
            this.panelBar.Name = "panelBar";
            this.panelBar.Padding = new System.Windows.Forms.Padding(20, 30, 20, 17);
            this.panelBar.Size = new System.Drawing.Size(344, 51);
            this.panelBar.TabIndex = 11;
            this.panelBar.Visible = false;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(20, 30);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(305, 4);
            this.LabelProgressBack.TabIndex = 15;
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Orange;
            this.LabelProgressBar.ForeColor = System.Drawing.Color.Black;
            this.LabelProgressBar.Location = new System.Drawing.Point(20, 30);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(55, 4);
            this.LabelProgressBar.TabIndex = 14;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.LabelLoadInfo.Location = new System.Drawing.Point(30, 8);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(281, 19);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "正在进行校验，请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.listBoxRule);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(344, 211);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "校验规则";
            // 
            // panelRule
            // 
            this.panelRule.AutoScroll = true;
            this.panelRule.Controls.Add(this.panelControl7);
            this.panelRule.Controls.Add(this.panel5);
            this.panelRule.Controls.Add(this.panelControl4);
            this.panelRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRule.Location = new System.Drawing.Point(0, 55);
            this.panelRule.Name = "panelRule";
            this.panelRule.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelRule.Size = new System.Drawing.Size(344, 411);
            this.panelRule.TabIndex = 4;
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Controls.Add(this.btnClearText);
            this.panelControl7.Controls.Add(this.panel1);
            this.panelControl7.Controls.Add(this.btnAddRule);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(3, 306);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Padding = new System.Windows.Forms.Padding(0, 6, 12, 0);
            this.panelControl7.Size = new System.Drawing.Size(338, 33);
            this.panelControl7.TabIndex = 9;
            // 
            // btnClearText
            // 
            this.btnClearText.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearText.Location = new System.Drawing.Point(128, 6);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(75, 27);
            this.btnClearText.TabIndex = 9;
            this.btnClearText.Text = "清空";
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(203, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 27);
            this.panel1.TabIndex = 8;
            // 
            // btnAddRule
            // 
            this.btnAddRule.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddRule.Location = new System.Drawing.Point(251, 6);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(75, 27);
            this.btnAddRule.TabIndex = 7;
            this.btnAddRule.Text = "添加";
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.memoEditSql);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(338, 100);
            this.panel5.TabIndex = 10;
            // 
            // memoEditSql
            // 
            this.memoEditSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEditSql.Location = new System.Drawing.Point(0, 0);
            this.memoEditSql.Name = "memoEditSql";
            this.memoEditSql.Size = new System.Drawing.Size(338, 100);
            this.memoEditSql.TabIndex = 17;
            this.memoEditSql.Text = "";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.listBoxFields);
            this.panelControl4.Controls.Add(this.panel6);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(3, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panelControl4.Size = new System.Drawing.Size(338, 206);
            this.panelControl4.TabIndex = 4;
            // 
            // listBoxFields
            // 
            this.listBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFields.Location = new System.Drawing.Point(0, 6);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new System.Drawing.Size(187, 194);
            this.listBoxFields.TabIndex = 3;
            this.listBoxFields.DoubleClick += new System.EventHandler(this.listBoxFields_DoubleClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panelA3);
            this.panel6.Controls.Add(this.panelA2);
            this.panel6.Controls.Add(this.panelA1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(187, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(151, 194);
            this.panel6.TabIndex = 4;
            // 
            // panelA3
            // 
            this.panelA3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelA3.Controls.Add(this.btnAUnique);
            this.panelA3.Controls.Add(this.btnAParent);
            this.panelA3.Controls.Add(this.btnADivide);
            this.panelA3.Controls.Add(this.btnAMultiply);
            this.panelA3.Controls.Add(this.btnASub);
            this.panelA3.Controls.Add(this.btnAAdd);
            this.panelA3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelA3.Location = new System.Drawing.Point(0, 129);
            this.panelA3.Name = "panelA3";
            this.panelA3.Size = new System.Drawing.Size(151, 64);
            this.panelA3.TabIndex = 7;
            // 
            // btnAUnique
            // 
            this.btnAUnique.Location = new System.Drawing.Point(97, 34);
            this.btnAUnique.Name = "btnAUnique";
            this.btnAUnique.Size = new System.Drawing.Size(44, 27);
            this.btnAUnique.TabIndex = 14;
            this.btnAUnique.Text = "唯一值";
            this.btnAUnique.Click += new System.EventHandler(this.btnAUnique_Click);
            // 
            // btnAParent
            // 
            this.btnAParent.Location = new System.Drawing.Point(44, 34);
            this.btnAParent.Name = "btnAParent";
            this.btnAParent.Size = new System.Drawing.Size(43, 27);
            this.btnAParent.TabIndex = 13;
            this.btnAParent.Text = "小括号";
            this.btnAParent.Click += new System.EventHandler(this.btnAParent_Click);
            // 
            // btnADivide
            // 
            this.btnADivide.Location = new System.Drawing.Point(4, 34);
            this.btnADivide.Name = "btnADivide";
            this.btnADivide.Size = new System.Drawing.Size(35, 27);
            this.btnADivide.TabIndex = 12;
            this.btnADivide.Text = "除";
            this.btnADivide.Click += new System.EventHandler(this.btnADivide_Click);
            // 
            // btnAMultiply
            // 
            this.btnAMultiply.Location = new System.Drawing.Point(84, 3);
            this.btnAMultiply.Name = "btnAMultiply";
            this.btnAMultiply.Size = new System.Drawing.Size(35, 27);
            this.btnAMultiply.TabIndex = 11;
            this.btnAMultiply.Text = "乘";
            this.btnAMultiply.Click += new System.EventHandler(this.btnAMultiply_Click);
            // 
            // btnASub
            // 
            this.btnASub.Location = new System.Drawing.Point(44, 3);
            this.btnASub.Name = "btnASub";
            this.btnASub.Size = new System.Drawing.Size(35, 27);
            this.btnASub.TabIndex = 10;
            this.btnASub.Text = "减";
            this.btnASub.Click += new System.EventHandler(this.btnASub_Click);
            // 
            // btnAAdd
            // 
            this.btnAAdd.Location = new System.Drawing.Point(4, 3);
            this.btnAAdd.Name = "btnAAdd";
            this.btnAAdd.Size = new System.Drawing.Size(35, 27);
            this.btnAAdd.TabIndex = 9;
            this.btnAAdd.Text = "加";
            this.btnAAdd.Click += new System.EventHandler(this.btnAAdd_Click);
            // 
            // panelA2
            // 
            this.panelA2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelA2.Controls.Add(this.btnAIs);
            this.panelA2.Controls.Add(this.btnANot);
            this.panelA2.Controls.Add(this.btnAOr);
            this.panelA2.Controls.Add(this.btnAAnd);
            this.panelA2.Controls.Add(this.btnALike);
            this.panelA2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelA2.Location = new System.Drawing.Point(0, 65);
            this.panelA2.Name = "panelA2";
            this.panelA2.Size = new System.Drawing.Size(151, 64);
            this.panelA2.TabIndex = 6;
            // 
            // btnAIs
            // 
            this.btnAIs.Location = new System.Drawing.Point(45, 34);
            this.btnAIs.Name = "btnAIs";
            this.btnAIs.Size = new System.Drawing.Size(35, 27);
            this.btnAIs.TabIndex = 16;
            this.btnAIs.Text = "是";
            this.btnAIs.Click += new System.EventHandler(this.btnAIs_Click);
            // 
            // btnANot
            // 
            this.btnANot.Location = new System.Drawing.Point(4, 34);
            this.btnANot.Name = "btnANot";
            this.btnANot.Size = new System.Drawing.Size(35, 27);
            this.btnANot.TabIndex = 15;
            this.btnANot.Text = "不是";
            this.btnANot.Click += new System.EventHandler(this.btnANot_Click);
            // 
            // btnAOr
            // 
            this.btnAOr.Location = new System.Drawing.Point(86, 3);
            this.btnAOr.Name = "btnAOr";
            this.btnAOr.Size = new System.Drawing.Size(35, 27);
            this.btnAOr.TabIndex = 14;
            this.btnAOr.Text = "或";
            this.btnAOr.Click += new System.EventHandler(this.btnAOr_Click);
            // 
            // btnAAnd
            // 
            this.btnAAnd.Location = new System.Drawing.Point(45, 3);
            this.btnAAnd.Name = "btnAAnd";
            this.btnAAnd.Size = new System.Drawing.Size(35, 27);
            this.btnAAnd.TabIndex = 13;
            this.btnAAnd.Text = "和";
            this.btnAAnd.Click += new System.EventHandler(this.btnAAnd_Click);
            // 
            // btnALike
            // 
            this.btnALike.Location = new System.Drawing.Point(4, 3);
            this.btnALike.Name = "btnALike";
            this.btnALike.Size = new System.Drawing.Size(35, 27);
            this.btnALike.TabIndex = 12;
            this.btnALike.Text = "类似";
            this.btnALike.Click += new System.EventHandler(this.btnALike_Click);
            // 
            // panelA1
            // 
            this.panelA1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelA1.Controls.Add(this.btnAEqual);
            this.panelA1.Controls.Add(this.btnASmaller1);
            this.panelA1.Controls.Add(this.btnASmaller);
            this.panelA1.Controls.Add(this.btnAUnequal);
            this.panelA1.Controls.Add(this.btnABigger1);
            this.panelA1.Controls.Add(this.btnABigger);
            this.panelA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelA1.Location = new System.Drawing.Point(0, 0);
            this.panelA1.Name = "panelA1";
            this.panelA1.Size = new System.Drawing.Size(151, 65);
            this.panelA1.TabIndex = 5;
            // 
            // btnAEqual
            // 
            this.btnAEqual.Location = new System.Drawing.Point(103, 3);
            this.btnAEqual.Name = "btnAEqual";
            this.btnAEqual.Size = new System.Drawing.Size(35, 27);
            this.btnAEqual.TabIndex = 9;
            this.btnAEqual.Text = "等于";
            this.btnAEqual.Click += new System.EventHandler(this.btnAEqual_Click);
            // 
            // btnASmaller1
            // 
            this.btnASmaller1.Location = new System.Drawing.Point(44, 34);
            this.btnASmaller1.Name = "btnASmaller1";
            this.btnASmaller1.Size = new System.Drawing.Size(54, 27);
            this.btnASmaller1.TabIndex = 12;
            this.btnASmaller1.Text = "小于等于";
            this.btnASmaller1.Click += new System.EventHandler(this.btnASmaller1_Click);
            // 
            // btnASmaller
            // 
            this.btnASmaller.Location = new System.Drawing.Point(4, 34);
            this.btnASmaller.Name = "btnASmaller";
            this.btnASmaller.Size = new System.Drawing.Size(35, 27);
            this.btnASmaller.TabIndex = 11;
            this.btnASmaller.Text = "小于";
            this.btnASmaller.Click += new System.EventHandler(this.btnASmaller_Click);
            // 
            // btnAUnequal
            // 
            this.btnAUnequal.Location = new System.Drawing.Point(103, 34);
            this.btnAUnequal.Name = "btnAUnequal";
            this.btnAUnequal.Size = new System.Drawing.Size(42, 27);
            this.btnAUnequal.TabIndex = 10;
            this.btnAUnequal.Text = "不等于";
            this.btnAUnequal.Click += new System.EventHandler(this.btnAUnequal_Click);
            // 
            // btnABigger1
            // 
            this.btnABigger1.Location = new System.Drawing.Point(44, 3);
            this.btnABigger1.Name = "btnABigger1";
            this.btnABigger1.Size = new System.Drawing.Size(52, 27);
            this.btnABigger1.TabIndex = 9;
            this.btnABigger1.Text = "大于等于";
            this.btnABigger1.Click += new System.EventHandler(this.btnABigger1_Click);
            // 
            // btnABigger
            // 
            this.btnABigger.Location = new System.Drawing.Point(4, 3);
            this.btnABigger.Name = "btnABigger";
            this.btnABigger.Size = new System.Drawing.Size(35, 27);
            this.btnABigger.TabIndex = 8;
            this.btnABigger.Text = "大于";
            this.btnABigger.Click += new System.EventHandler(this.btnABigger_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(350, 678);
            this.xtraTabControl1.TabIndex = 8;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelResult2);
            this.xtraTabPage1.Controls.Add(this.panelResult);
            this.xtraTabPage1.Controls.Add(this.panelProcess);
            this.xtraTabPage1.Controls.Add(this.panelBar);
            this.xtraTabPage1.Controls.Add(this.panelOK);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(344, 649);
            this.xtraTabPage1.Text = "逻辑校验";
            // 
            // panelResult2
            // 
            this.panelResult2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelResult2.Controls.Add(this.panelError);
            this.panelResult2.Controls.Add(this.panelSubList);
            this.panelResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult2.Location = new System.Drawing.Point(0, 346);
            this.panelResult2.Name = "panelResult2";
            this.panelResult2.Size = new System.Drawing.Size(344, 303);
            this.panelResult2.TabIndex = 1;
            // 
            // panelError
            // 
            this.panelError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelError.Controls.Add(this.listBoxError);
            this.panelError.Controls.Add(this.panelControl9);
            this.panelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelError.Location = new System.Drawing.Point(0, 0);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(154, 303);
            this.panelError.TabIndex = 0;
            this.panelError.Visible = false;
            // 
            // listBoxError
            // 
            this.listBoxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxError.HorizontalScrollbar = true;
            this.listBoxError.ItemHeight = 20;
            this.listBoxError.Location = new System.Drawing.Point(0, 0);
            this.listBoxError.Name = "listBoxError";
            this.listBoxError.Size = new System.Drawing.Size(154, 266);
            this.listBoxError.TabIndex = 4;
            // 
            // panelControl9
            // 
            this.panelControl9.Controls.Add(this.labelErrorDes);
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl9.Location = new System.Drawing.Point(0, 266);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(154, 37);
            this.panelControl9.TabIndex = 3;
            // 
            // labelErrorDes
            // 
            this.labelErrorDes.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelErrorDes.Location = new System.Drawing.Point(5, 5);
            this.labelErrorDes.Name = "labelErrorDes";
            this.labelErrorDes.Size = new System.Drawing.Size(127, 14);
            this.labelErrorDes.TabIndex = 4;
            this.labelErrorDes.Text = "共有0条规则未通过校验";
            // 
            // panelSubList
            // 
            this.panelSubList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSubList.Controls.Add(this.panelSql);
            this.panelSubList.Controls.Add(this.groupControlResult2);
            this.panelSubList.Controls.Add(this.panelControl8);
            this.panelSubList.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSubList.Location = new System.Drawing.Point(154, 0);
            this.panelSubList.Name = "panelSubList";
            this.panelSubList.Size = new System.Drawing.Size(190, 303);
            this.panelSubList.TabIndex = 1;
            this.panelSubList.Visible = false;
            // 
            // panelSql
            // 
            this.panelSql.Controls.Add(this.labelSQL);
            this.panelSql.Controls.Add(this.labelSqlCopy);
            this.panelSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSql.Location = new System.Drawing.Point(0, 0);
            this.panelSql.Name = "panelSql";
            this.panelSql.Padding = new System.Windows.Forms.Padding(2);
            this.panelSql.Size = new System.Drawing.Size(190, 266);
            this.panelSql.TabIndex = 5;
            // 
            // labelSQL
            // 
            this.labelSQL.BackColor = System.Drawing.SystemColors.Info;
            this.labelSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQL.Location = new System.Drawing.Point(2, 2);
            this.labelSQL.Margin = new System.Windows.Forms.Padding(6);
            this.labelSQL.Name = "labelSQL";
            this.labelSQL.ReadOnly = true;
            this.labelSQL.Size = new System.Drawing.Size(186, 249);
            this.labelSQL.TabIndex = 0;
            this.labelSQL.Text = "";
            // 
            // labelSqlCopy
            // 
            this.labelSqlCopy.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSqlCopy.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelSqlCopy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelSqlCopy.Location = new System.Drawing.Point(2, 251);
            this.labelSqlCopy.Name = "labelSqlCopy";
            this.labelSqlCopy.Size = new System.Drawing.Size(0, 13);
            this.labelSqlCopy.TabIndex = 5;
            // 
            // groupControlResult2
            // 
            this.groupControlResult2.Controls.Add(this.gridControlResult2);
            this.groupControlResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlResult2.Location = new System.Drawing.Point(0, 0);
            this.groupControlResult2.Name = "groupControlResult2";
            this.groupControlResult2.Size = new System.Drawing.Size(190, 266);
            this.groupControlResult2.TabIndex = 8;
            this.groupControlResult2.Text = "错误要素列表";
            // 
            // gridControlResult2
            // 
            this.gridControlResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlResult2.Location = new System.Drawing.Point(2, 22);
            this.gridControlResult2.MainView = this.gridViewResult2;
            this.gridControlResult2.Name = "gridControlResult2";
            this.gridControlResult2.Size = new System.Drawing.Size(186, 242);
            this.gridControlResult2.TabIndex = 2;
            this.gridControlResult2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResult2});
            // 
            // gridViewResult2
            // 
            this.gridViewResult2.GridControl = this.gridControlResult2;
            this.gridViewResult2.Name = "gridViewResult2";
            this.gridViewResult2.OptionsBehavior.Editable = false;
            this.gridViewResult2.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewResult2.OptionsCustomization.AllowFilter = false;
            this.gridViewResult2.OptionsCustomization.AllowGroup = false;
            this.gridViewResult2.OptionsCustomization.AllowSort = false;
            this.gridViewResult2.OptionsMenu.EnableColumnMenu = false;
            this.gridViewResult2.OptionsMenu.EnableFooterMenu = false;
            this.gridViewResult2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewResult2.OptionsView.ColumnAutoWidth = false;
            this.gridViewResult2.OptionsView.ShowGroupPanel = false;
            this.gridViewResult2.OptionsView.ShowIndicator = false;
            // 
            // panelControl8
            // 
            this.panelControl8.Controls.Add(this.simpleButtonXBH);
            this.panelControl8.Controls.Add(this.simpleButtonSQL);
            this.panelControl8.Controls.Add(this.simpleButtonSetValue);
            this.panelControl8.Controls.Add(this.simpleButtonSelect);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl8.Location = new System.Drawing.Point(0, 266);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(190, 37);
            this.panelControl8.TabIndex = 2;
            // 
            // simpleButtonXBH
            // 
            this.simpleButtonXBH.Location = new System.Drawing.Point(140, 9);
            this.simpleButtonXBH.Name = "simpleButtonXBH";
            this.simpleButtonXBH.Size = new System.Drawing.Size(40, 23);
            this.simpleButtonXBH.TabIndex = 3;
            this.simpleButtonXBH.Text = "小班号";
            this.simpleButtonXBH.ToolTip = "对于重复的小班号重新进行编号";
            this.simpleButtonXBH.Visible = false;
            this.simpleButtonXBH.Click += new System.EventHandler(this.simpleButtonXBH_Click);
            // 
            // simpleButtonSQL
            // 
            this.simpleButtonSQL.Location = new System.Drawing.Point(6, 9);
            this.simpleButtonSQL.Name = "simpleButtonSQL";
            this.simpleButtonSQL.Size = new System.Drawing.Size(36, 23);
            this.simpleButtonSQL.TabIndex = 2;
            this.simpleButtonSQL.Text = "SQL";
            this.simpleButtonSQL.ToolTip = "显示错误过滤语句";
            this.simpleButtonSQL.Click += new System.EventHandler(this.simpleButtonSQL_Click);
            // 
            // simpleButtonSetValue
            // 
            this.simpleButtonSetValue.Location = new System.Drawing.Point(94, 9);
            this.simpleButtonSetValue.Name = "simpleButtonSetValue";
            this.simpleButtonSetValue.Size = new System.Drawing.Size(36, 23);
            this.simpleButtonSetValue.TabIndex = 1;
            this.simpleButtonSetValue.Text = "修改";
            this.simpleButtonSetValue.ToolTip = "批量赋值";
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Location = new System.Drawing.Point(50, 9);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(36, 23);
            this.simpleButtonSelect.TabIndex = 0;
            this.simpleButtonSelect.Text = "选择";
            this.simpleButtonSelect.ToolTip = "选中当前错误班块";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.splitContainer1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(344, 649);
            this.xtraTabPage2.Text = "自定义";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelDIY);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRule);
            this.splitContainer1.Panel2.Controls.Add(this.groupControl6);
            this.splitContainer1.Size = new System.Drawing.Size(344, 649);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 10;
            // 
            // panelDIY
            // 
            this.panelDIY.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelDIY.Controls.Add(this.checkedListBoxDIY);
            this.panelDIY.Controls.Add(this.panelControl2);
            this.panelDIY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDIY.Location = new System.Drawing.Point(0, 0);
            this.panelDIY.Name = "panelDIY";
            this.panelDIY.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelDIY.Size = new System.Drawing.Size(344, 180);
            this.panelDIY.TabIndex = 3;
            // 
            // checkedListBoxDIY
            // 
            this.checkedListBoxDIY.CheckOnClick = true;
            this.checkedListBoxDIY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxDIY.HorizontalScrollbar = true;
            this.checkedListBoxDIY.Location = new System.Drawing.Point(3, 0);
            this.checkedListBoxDIY.Name = "checkedListBoxDIY";
            this.checkedListBoxDIY.Size = new System.Drawing.Size(258, 180);
            this.checkedListBoxDIY.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnLD);
            this.panelControl2.Controls.Add(this.btnSimple);
            this.panelControl2.Controls.Add(this.btnDeleteRule);
            this.panelControl2.Controls.Add(this.btnClear);
            this.panelControl2.Controls.Add(this.btnAll);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(261, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(0, 3, 12, 3);
            this.panelControl2.Size = new System.Drawing.Size(80, 180);
            this.panelControl2.TabIndex = 8;
            // 
            // btnLD
            // 
            this.btnLD.Location = new System.Drawing.Point(15, 152);
            this.btnLD.Name = "btnLD";
            this.btnLD.Size = new System.Drawing.Size(55, 22);
            this.btnLD.TabIndex = 13;
            this.btnLD.Text = "林地规则";
            // 
            // btnSimple
            // 
            this.btnSimple.Location = new System.Drawing.Point(15, 117);
            this.btnSimple.Name = "btnSimple";
            this.btnSimple.Size = new System.Drawing.Size(55, 22);
            this.btnSimple.TabIndex = 12;
            this.btnSimple.Text = "初步规则";
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Location = new System.Drawing.Point(15, 12);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(50, 22);
            this.btnDeleteRule.TabIndex = 11;
            this.btnDeleteRule.Text = "删除";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 82);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 22);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "全不选";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(15, 48);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(50, 22);
            this.btnAll.TabIndex = 9;
            this.btnAll.Text = "全选";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.panelControl6);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(344, 55);
            this.groupControl6.TabIndex = 8;
            this.groupControl6.Text = "添加校验规则";
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.labelControl1);
            this.panelControl6.Controls.Add(this.comboBoxType);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(2, 22);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(340, 37);
            this.panelControl6.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "校验规则类型：";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Location = new System.Drawing.Point(96, 6);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxType.Properties.Items.AddRange(new object[] {
            "不能为空校验",
            "唯一值校验",
            "数值校验",
            "字段间相互校验",
            "其他校验"});
            this.comboBoxType.Size = new System.Drawing.Size(109, 20);
            this.comboBoxType.TabIndex = 2;
            // 
            // UserControlAttriCheck
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UserControlAttriCheck";
            this.Size = new System.Drawing.Size(350, 678);
            this.SizeChanged += new System.EventHandler(this.UserControlAttriCheck_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelResult)).EndInit();
            this.panelResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            this.panelResultList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOK)).EndInit();
            this.panelOK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProcess)).EndInit();
            this.panelProcess.ResumeLayout(false);
            this.panelProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar)).EndInit();
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panelRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFields)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelA3)).EndInit();
            this.panelA3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelA2)).EndInit();
            this.panelA2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelA1)).EndInit();
            this.panelA1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelResult2)).EndInit();
            this.panelResult2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelError)).EndInit();
            this.panelError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            this.panelControl9.ResumeLayout(false);
            this.panelControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSubList)).EndInit();
            this.panelSubList.ResumeLayout(false);
            this.panelSql.ResumeLayout(false);
            this.panelSql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult2)).EndInit();
            this.groupControlResult2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResult2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDIY)).EndInit();
            this.panelDIY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxDIY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void labelSelectFeature_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataSource = this.gridControl1.DataSource as DataTable;
                if ((dataSource != null) && (dataSource.Rows.Count >= 1))
                {
                    string str = "";
                    for (int i = 0; i < dataSource.Rows.Count; i++)
                    {
                        str = str + "," + dataSource.Rows[i][1].ToString();
                    }
                    str = str.Substring(1);
                    IFeatureClass featureClass = this.m_CheckLayer.FeatureClass;
                    IQueryFilter filter = new QueryFilterClass {
                        SubFields = featureClass.OIDFieldName,
                        WhereClause = featureClass.OIDFieldName + " in (" + str + ")"
                    };
                    IFeatureSelection checkLayer = this.m_CheckLayer as IFeatureSelection;
                    checkLayer.Clear();
                    checkLayer.SelectFeatures(filter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "buttonRecheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void listBoxError_MouseMove(object sender, MouseEventArgs e)
        {
            int num = (e.Y / this.listBoxError.ItemHeight) + this.listBoxError.TopIndex;
            string caption = "";
            if ((num >= 0) && (num < this.listBoxError.Items.Count))
            {
                caption = this.listBoxError.Items[num].ToString();
            }
            else
            {
                caption = "";
            }
            if (this.toolTip1.GetToolTip(this.listBoxError) != caption)
            {
                this.toolTip1.SetToolTip(this.listBoxError, caption);
            }
        }

        private void listBoxError_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxError.SelectedIndex < 0)
            {
                this.panelSubList.Visible = false;
            }
            else
            {
                this.panelSql.Visible = false;
                this.simpleButtonSQL.Visible = false;
                this.simpleButtonXBH.Visible = false;
                this.panelSubList.Visible = true;
                this.gridControlResult2.DataSource = null;
                try
                {
                    int selectedIndex = this.listBoxError.SelectedIndex;
                    if (this.m_LogicError != null)
                    {
                        if (this.m_LogicError.GetDescription(selectedIndex).Contains("村+林班+小班不能重复") && EditTask.EditLayer.Name.Contains("年度"))
                        {
                            this.simpleButtonXBH.Visible = true;
                        }
                        string errorType = this.m_LogicError.GetErrorType(selectedIndex);
                        if ((errorType.ToLower() == "unique") || (errorType.ToLower() == "incode"))
                        {
                            this.simpleButtonSQL.Visible = false;
                        }
                        else
                        {
                            this.simpleButtonSQL.Visible = true;
                        }
                        IList<int> errorIDS = (IList<int>) this.m_LogicError.GetErrorIDS(selectedIndex);
                        DataTable table = new DataTable();
                        DataColumn column = new DataColumn {
                            Caption = "编号",
                            ColumnName = "编号",
                            DataType = typeof(string),
                            MaxLength = 10
                        };
                        DataColumn column2 = new DataColumn {
                            Caption = "OID",
                            ColumnName = "OID",
                            DataType = typeof(string),
                            MaxLength = 20
                        };
                        table.Columns.AddRange(new DataColumn[] { column, column2 });
                        for (int i = 0; i < errorIDS.Count; i++)
                        {
                            DataRow row = table.NewRow();
                            row[0] = i + 1;
                            row[1] = errorIDS[i];
                            table.Rows.Add(row);
                        }
                        this.gridControlResult2.DataSource = table;
                        this.gridViewResult2.Columns[0].Width = 50;
                        this.gridViewResult2.Columns[1].Width = 70;
                        this.groupControlResult2.Text = "错误要素列表（" + errorIDS.Count + "）";
                    }
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "listBoxError_SelectedIndexChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxFields.SelectedIndex;
            string str = this.listBoxFields.Items[selectedIndex].ToString();
            int index = str.IndexOf("[");
            string name = str.Substring(index + 1, (str.Length - index) - 2);
            int num3 = this.m_Fields.FindField(name);
            IField field = this.m_Fields.get_Field(num3);
            if (this.comboBoxType.SelectedIndex == 1)
            {
                string str7 = "insert into " + this.m_TableName + " (DESIGN_KIND,CHECK_TYPE,CHECK_FIELD,FIELD_ALIAS,ERROR_DESCRIP,ENABLED,ISEDIT) values (";
                string sCmdText = str7 + "'" + this.m_DesignKind + "','UNIQUE','" + field.Name + "','" + field.AliasName + "','不能重复',1,1)";
                this.ExecuteNonQuery(sCmdText);
                this.RefreshRule();
                this.checkedListBoxDIY.SelectedIndex = this.checkedListBoxDIY.Items.Count;
            }
            else if (this.comboBoxType.SelectedIndex == 0)
            {
                string str4 = "";
                if (((field.Type == esriFieldType.esriFieldTypeDouble) || (field.Type == esriFieldType.esriFieldTypeInteger)) || (field.Type == esriFieldType.esriFieldTypeSmallInteger))
                {
                    str4 = field.Name + " is null";
                }
                else
                {
                    str4 = "(" + field.Name + " is null) or (LTRIM(RTRIM(" + field.Name + "))='''')";
                }
                string str8 = "insert into " + this.m_TableName + " (DESIGN_KIND,CHECK_TYPE,CHECK_FIELD,FIELD_ALIAS,CHECK_RULE,ERROR_DESCRIP,ENABLED,ISEDIT) values (";
                string str5 = str8 + "'" + this.m_DesignKind + "','NOTNULL','" + field.Name + "','" + field.AliasName + "','" + str4 + "','不能为空',1,1)";
                this.ExecuteNonQuery(str5);
                this.RefreshRule();
                this.checkedListBoxDIY.SelectedIndex = this.checkedListBoxDIY.Items.Count;
            }
            else
            {
                string text = this.memoEditSql.Text;
                int selectionStart = this.memoEditSql.SelectionStart;
                text = text.Substring(0, selectionStart) + field.Name + text.Substring(selectionStart, text.Length - selectionStart);
                this.memoEditSql.Text = text;
                this.memoEditSql.Focus();
                this.memoEditSql.SelectionStart = selectionStart + field.Name.Length;
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            this.m_bDown = true;
            this.m_offX = e.X - this.panelResultList.Location.X;
            this.m_offY = e.Y - this.panelResultList.Location.Y;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.m_bDown)
            {
                this.panelResultList.Location = new System.Drawing.Point(e.X - this.m_offX, e.Y - this.m_offY);
                this.Refresh();
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            this.m_bDown = false;
        }

        private void RefreshCheckRule()
        {
            this.listBoxRule.Items.Clear();
            string sql = "";
            this.m_DesignKind = EditTask.KindCode.Substring(0, 2);
            sql = "select * from " + this.m_TableName + " where design_kind like '" + this.m_DesignKind + "%' and enabled=1 order by CHECK_ID,ID";
            DataTable dataTable = new DataTable();
           using( SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString())){
               con.Open();
            SqlCommand tmp = new SqlCommand(sql, con);
            SqlDataAdapter tmp1 = new SqlDataAdapter(tmp);
            tmp1.Fill(dataTable);
            }
            //this.m_Accesser.GetDataTable(this.m_Accesser, sql);
            if ((dataTable == null) || (dataTable.Rows.Count < 1))
            {
                this.btnCheck.Enabled = false;
            }
            else
            {
                this.m_RuleTable = dataTable;
                string item = "";
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    item = string.Concat(new object[] { i + 1, "  ", row["FIELD_ALIAS"], row["ERROR_DESCRIP"], "\n" });
                    this.listBoxRule.Items.Add(item);
                }
                this.listBoxRule.SelectedIndex = -1;
                this.btnCheck.Enabled = true;
            }
        }

        private void RefreshFields()
        {
            this.listBoxFields.Items.Clear();
            for (int i = 0; i < this.m_Fields.FieldCount; i++)
            {
                IField field = this.m_Fields.get_Field(i);
                if ((field.Type != esriFieldType.esriFieldTypeGeometry) && (field.Type != esriFieldType.esriFieldTypeOID))
                {
                    this.listBoxFields.Items.Add(field.AliasName + "[" + field.Name + "]");
                }
            }
        }

        private void RefreshRule()
        {
            this.checkedListBoxDIY.Items.Clear();
            string sql = "select * from " + this.m_TableName + " where design_kind like '" + this.m_DesignKind + "%' and isedit=1 order by CHECK_ID,ID";
           // DataTable dataTable = null;// this.m_Accesser.GetDataTable(this.m_Accesser, sql);
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString()))
            {
                con.Open();
                SqlCommand tmp = new SqlCommand(sql, con);
                SqlDataAdapter tmp1 = new SqlDataAdapter(tmp);
                tmp1.Fill(dataTable);
            }
            if ((dataTable != null) && (dataTable.Rows.Count >= 1))
            {
                bool isChecked = false;
                string str3 = "";
                this.m_IDList = new ArrayList();
                this.m_ReadList = new ArrayList();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    isChecked = Convert.ToBoolean(row["ENABLED"].ToString());
                    str3 = row["FIELD_ALIAS"].ToString() + row["ERROR_DESCRIP"].ToString();
                    this.checkedListBoxDIY.Items.Add(str3, isChecked);
                    this.m_IDList.Add(row["ID"]);
                    this.m_ReadList.Add(row["ISNO_DELETE"]);
                }
            }
        }

        private void SaveDIY(int index)
        {
            if (index >= 0)
            {
                try
                {
                    string str2;
                    string sCmdText = "";
                    if (this.checkedListBoxDIY.Items[index].CheckState.ToString() == "Checked")
                    {
                        str2 = "1";
                    }
                    else
                    {
                        str2 = "0";
                    }
                    sCmdText = string.Concat(new object[] { "update ", this.m_TableName, " set enabled=", str2, " where ID=", this.m_IDList[index] });
                    this.ExecuteNonQuery(sCmdText);
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "SaveDIY", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            catch
            {
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = this.listBoxError.SelectedIndex;
                if ((selectedIndex >= 0) && (this.m_LogicError != null))
                {
                    IFeatureClass featureClass = this.m_CheckLayer.FeatureClass;
                    if (featureClass != null)
                    {
                        string sql = this.m_LogicError.GetSql(selectedIndex);
                        IQueryFilter queryFilter = new QueryFilterClass {
                            SubFields = featureClass.OIDFieldName + "," + featureClass.ShapeFieldName,
                            WhereClause = sql
                        };
                        IFeatureSelection checkLayer = this.m_CheckLayer as IFeatureSelection;
                        checkLayer.Clear();
                        ISelectionSet set = featureClass.Select(queryFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, ((IDataset) featureClass).Workspace);
                        checkLayer.SelectionSet = set;
                        this.m_HookHelper.ActiveView.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "simpleButton_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonSetValue_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxError.SelectedIndex;
            if ((selectedIndex >= 0) && (this.m_LogicError != null))
            {
                string field = this.m_LogicError.GetField(selectedIndex);
                if (field.Contains<char>(','))
                {
                    field = field.Split(new char[] { ',' })[0];
                }
                else if (field.Contains<char>('+'))
                {
                    field = field.Split(new char[] { '+' })[0];
                }
                FormSetUniqueValue value2 = new FormSetUniqueValue {
                    UpdateType = 2,
                    SelectedField = field,
                    UpdateFilter = this.m_LogicError.GetSql(selectedIndex)
                };
                value2.ShowDialog();
                value2.Dispose();
            }
        }

        private void simpleButtonSQL_Click(object sender, EventArgs e)
        {
            if (this.panelSql.Visible)
            {
                this.panelSql.Visible = false;
            }
            else
            {
                this.labelSqlCopy.Text = "";
                int selectedIndex = this.listBoxError.SelectedIndex;
                if ((selectedIndex >= 0) && (this.m_LogicError != null))
                {
                    this.labelSQL.Text = this.m_LogicError.GetSql(selectedIndex);
                }
                else
                {
                    this.labelSQL.Text = "";
                }
                this.panelSql.Visible = true;
                this.labelSQL.SelectAll();
                this.labelSQL.Copy();
                this.labelSqlCopy.Text = "已将SQL语句复制到【剪贴板】";
            }
        }

        private void simpleButtonXBH_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBoxError.SelectedIndex;
            if ((selectedIndex < 0) || (this.m_LogicError == null))
            {
                MessageBox.Show("当前无选中错误规则！", "提示");
            }
            else if (this.m_LogicError.GetDescription(selectedIndex).Contains("村+林班+小班不能重复") && (DialogResult.Cancel != MessageBox.Show("将对检查出的错误小班重新进行编号，是否继续？", "提示", MessageBoxButtons.OKCancel)))
            {
                IList<int> errorIDS = (IList<int>) this.m_LogicError.GetErrorIDS(selectedIndex);
                IFeatureClass featureClass = this.m_CheckLayer.FeatureClass;
                if (featureClass != null)
                {
                    string oIDFieldName = featureClass.OIDFieldName;
                    IDataset dataset = (IDataset) featureClass;
                    string name = dataset.Name;
                   // IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "MapDBkey"));
                    //if (dBAccess == null)
                    //{
                    //    MessageBox.Show("数据库连接有错！", "提示");
                    //}
                    //else
                    //{
                        try
                        {
                            IList<string> list2 = new List<string>();
                            for (int i = 0; i < errorIDS.Count; i++)
                            {
                                string sql = string.Concat(new object[] { "select ", oIDFieldName, ",cun,lin_ban,xiao_ban from ", name, " where ", oIDFieldName, "=", errorIDS[i] });
                                DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                                if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                                {
                                    DataRow row = dataTable.Rows[0];
                                    string item = row["cun"].ToString() + row["lin_ban"].ToString() + row["xiao_ban"].ToString();
                                    if (!list2.Contains(item))
                                    {
                                        list2.Add(item);
                                    }
                                    else
                                    {
                                        sql = string.Concat(new object[] { "select max(xiao_ban) from ", name, " where cun='", row["cun"], "' and lin_ban='", row["lin_ban"], "'" });
                                        object obj2 = null;//dBAccess.ExecuteScalar(sql).ToString();
                                        if (obj2 != null)
                                        {
                                            int num3 = 0;
                                            try
                                            {
                                                num3 = Convert.ToInt16(obj2.ToString());
                                            }
                                            catch
                                            {
                                                continue;
                                            }
                                            int num4 = num3 + 1;
                                            string str7 = num4.ToString().PadLeft(4, '0');
                                            sql = string.Concat(new object[] { "update ", name, " set xiao_ban='", str7, "' where ", oIDFieldName, "=", errorIDS[i] });
                                          //  dBAccess.ExecuteNonQuery(sql);
                                        }
                                    }
                                }
                            }
                            MessageBox.Show("编号完成！请再次进行逻辑校验，如还存在重复小班号，请手动修改！", "提示");
                        }
                        catch (Exception exception)
                        {
                            this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "simpleButtonXBH_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                            MessageBox.Show("编号失败！", "提示");
                        }
                    }
                //}
            }
        }

        private void UserControlAttriCheck_SizeChanged(object sender, EventArgs e)
        {
            this.panelResult.Height = (base.Height - this.groupControl1.Height) - this.panelOK.Height;
            this.LabelProgressBack.Width = this.panelBar.Width - 40;
            this.LabelLoadInfo.Width = this.panelBar.Width - 60;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage1)
            {
                this.RefreshCheckRule();
            }
            else if (!this.m_DIY)
            {
                try
                {
                    this.RefreshRule();
                    if (this.m_Fields == null)
                    {
                        IFields fields = null;
                        fields = this.m_CheckLayer.FeatureClass.Fields;
                        this.m_Fields = fields;
                    }
                    this.comboBoxType.SelectedIndex = 0;
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "xtraTabControl1_SelectedPageChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                this.m_DIY = true;
            }
        }

        private void ZoomErrorFeature(string sOID)
        {
            try
            {
                IFeature feature = null;
                string kindCode = EditTask.KindCode;
                UtilFactory.GetConfigOpt();
                IFeatureClass featureClass = this.m_CheckLayer.FeatureClass;
                IQueryFilter filter = new QueryFilterClass {
                    WhereClause = featureClass.OIDFieldName + "=" + sOID
                };
                feature = featureClass.Search(filter, false).NextFeature();
                if (feature != null)
                {
                    IActiveView activeView = this.m_HookHelper.ActiveView;
                    if (activeView != null)
                    {
                        IGeometry shapeCopy = feature.ShapeCopy;
                        if (shapeCopy.IsEmpty)
                        {
                            XtraMessageBox.Show(this, "要素图形为空，无法定位！", "逻辑校验");
                        }
                        else
                        {
                            shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_HookHelper.ActiveView.FocusMap.SpatialReference);
                            IEnvelope envelope = new EnvelopeClass();
                            envelope = shapeCopy.Envelope;
                            if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                            {
                                IEnvelope envelope2 = new EnvelopeClass {
                                    SpatialReference = activeView.FocusMap.SpatialReference
                                };
                                double num = 100.0;
                                envelope2.PutCoords(envelope.XMin - num, envelope.YMin - num, envelope.XMax + num, envelope.YMax + num);
                                envelope = envelope2;
                            }
                            else
                            {
                                envelope.Expand(1.5, 1.5, true);
                            }
                            IFeatureSelection checkLayer = this.m_CheckLayer as IFeatureSelection;
                            checkLayer.Clear();
                            checkLayer.Add(feature);
                            activeView.FullExtent = envelope;
                            activeView.Refresh();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "AttributesEdit.UserControlAttriCheck", "ZoomErrorFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

