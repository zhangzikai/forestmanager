namespace GX_DB_INFO
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using GX_DB_INFO.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlUpdateAS2 : UserControlBase1
    {
        private CheckedListBoxControl checkedListBox1;
        private IContainer components;
        private Label labelInfo;
        private Label labelMessage;
        private Label labelQuery;
        private Label labelQuery2;
     
        private int m_SZ;
        private string m_TableName = "";
        private IList<string> m_TownList;
        private IHookHelper mHookHelper;
        private Panel panel1;
        private Panel panel2;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panelButton;
        private Panel panelLabel;
        private Panel panelResult;
        private Panel panelTown;
        private RadioGroup radioGroup1;
        private RepositoryItemImageEdit repositoryItemImageEdit8;
        private SimpleButton simpleButtonAuto;
        private SimpleButton simpleButtonQuery;
        private SimpleButton simpleButtonSelect;
        private SimpleButton simpleButtonUnselect;
        private TreeList tList2;
        private TreeListColumn treeListColumn11;
        private TreeListColumn treeListColumn12;
        private TreeListColumn treeListColumn13;

        public UserControlUpdateAS2()
        {
            this.InitializeComponent();
        }

        private void checkedListBox1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            GC.Collect();
            if (e.Index >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.tList2.Nodes.Clear();
                    string str = "";
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        if (this.checkedListBox1.Items[i].CheckState == CheckState.Checked)
                        {
                            str = str + ",'" + this.m_TownList[i] + "'";
                        }
                    }
                    if (str.Length < 1)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    str = str.Substring(1);
                    this.tList2.Visible = true;
                    this.panelButton.Visible = true;
                    string cmdText = "";
                    string str3 = "";
                    if (this.m_SZ == 0)
                    {
                        this.m_SZ = 0;
                        str3 = "(BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320') AND (PINGJUN_NL>5) AND XIANG in (" + str + ")";
                        cmdText = "select objectid,PINGJUN_NL,YOU_SHI_SZ from " + this.m_TableName + " where " + str3;
                        cmdText = "select objectid,CNAME,PINGJUN_NL from (" + cmdText + ") t1 left join T_SYS_META_CODE on t1.YOU_SHI_SZ=T_SYS_META_CODE.CCODE where CDOMAIN='SHU_ZHONG' order by objectid ";
                    }
                    else if (this.m_SZ == 1)
                    {
                        this.m_SZ = 1;
                        str3 = "(BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (BSSZ>='290' AND BSSZ<='320') AND (BSSZNL>5) AND XIANG in (" + str + ")";
                        cmdText = "select objectid,BSSZNL,BSSZ from " + this.m_TableName + " where " + str3;
                        cmdText = "select objectid,CNAME,BSSZNL from (" + cmdText + ") t1 left join T_SYS_META_CODE on t1.BSSZ=T_SYS_META_CODE.CCODE where CDOMAIN='SHU_ZHONG' order by objectid ";
                    }
                    DataTable table = null;// this.ExecuteCommandWithResults(cmdText, (SqlConnection)this.m_DBAccess.Connection);
                    TreeListNode parentNode = null;
                    TreeListNode node2 = null;
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        this.tList2.Refresh();
                        string nodeData = table.Rows[j][0].ToString();
                        string val = table.Rows[j][1].ToString();
                        string str6 = table.Rows[j][2].ToString();
                        node2 = this.tList2.AppendNode(nodeData, parentNode);
                        node2.Tag = nodeData;
                        node2.SetValue(0, nodeData);
                        node2.SetValue(1, val);
                        node2.SetValue(2, str6);
                    }
                    this.tList2.Refresh();
                    this.labelQuery2.Text = "共" + this.tList2.Nodes.Count + "个";
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "提示");
                }
                this.Cursor = Cursors.Default;
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

        public string ExcuteCommandText(string cmdText, SqlConnection sqlDbConnection)
        {
            try
            {
                SqlCommand command = sqlDbConnection.CreateCommand();
                command.CommandText = cmdText;
                command.CommandTimeout = 0;
                command.ExecuteNonQuery();
                command.Dispose();
                return string.Empty;
            }
            catch (SqlException exception)
            {
                return string.Format("错误消息：{0}", exception.Message);
            }
        }

        public DataTable ExecuteCommandWithResults(string cmdText, SqlConnection sqlDbConnection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmdText, sqlDbConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private string GetTableName()
        {
            IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
            if (featureClass == null)
            {
                return "";
            }
            return (featureClass as IDataset).Name;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelQuery = new System.Windows.Forms.Label();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelTown = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.panelResult = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.labelQuery2 = new System.Windows.Forms.Label();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.simpleButtonUnselect = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.simpleButtonAuto = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.panelLabel.SuspendLayout();
            this.panelTown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit8)).BeginInit();
            this.panelResult.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(256, 85);
            this.panel1.TabIndex = 8;
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Location = new System.Drawing.Point(0, 10);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(256, 75);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "    对于速生桉与速生相思的平均年龄超过5的小班，请用户根据查询结果进行核实。核实完成后，选择需要处理的小班，系统将会对其进行批量处理：将平均年龄减去5，并更新" +
    "对应的测树因子。";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.radioGroup1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 85);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel2.Size = new System.Drawing.Size(256, 77);
            this.panel2.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelQuery);
            this.panel6.Controls.Add(this.simpleButtonQuery);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 45);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.panel6.Size = new System.Drawing.Size(256, 24);
            this.panel6.TabIndex = 19;
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelQuery.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelQuery.Location = new System.Drawing.Point(0, 10);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(0, 14);
            this.labelQuery.TabIndex = 18;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonQuery.ImageIndex = 6;
            this.simpleButtonQuery.Location = new System.Drawing.Point(201, 0);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(52, 24);
            this.simpleButtonQuery.TabIndex = 17;
            this.simpleButtonQuery.Text = "查询";
            this.simpleButtonQuery.ToolTip = "查询树种年龄大于5的小班";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "优势树种"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "伴生树种")});
            this.radioGroup1.Size = new System.Drawing.Size(256, 32);
            this.radioGroup1.TabIndex = 18;
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.labelMessage);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLabel.Location = new System.Drawing.Point(10, 449);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelLabel.Size = new System.Drawing.Size(256, 38);
            this.panelLabel.TabIndex = 10;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(13, 12);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 14);
            this.labelMessage.TabIndex = 16;
            // 
            // panelTown
            // 
            this.panelTown.Controls.Add(this.checkedListBox1);
            this.panelTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTown.Location = new System.Drawing.Point(10, 162);
            this.panelTown.Name = "panelTown";
            this.panelTown.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panelTown.Size = new System.Drawing.Size(256, 98);
            this.panelTown.TabIndex = 11;
            this.panelTown.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(256, 96);
            this.checkedListBox1.TabIndex = 9;
            this.checkedListBox1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // tList2
            // 
            this.tList2.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.tList2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList2.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.tList2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tList2.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tList2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn13});
            this.tList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tList2.Location = new System.Drawing.Point(0, 2);
            this.tList2.Name = "tList2";
            this.tList2.OptionsBehavior.Editable = false;
            this.tList2.OptionsView.AutoWidth = false;
            this.tList2.OptionsView.ShowCheckBoxes = true;
            this.tList2.OptionsView.ShowHorzLines = false;
            this.tList2.OptionsView.ShowIndicator = false;
            this.tList2.OptionsView.ShowRoot = false;
            this.tList2.OptionsView.ShowVertLines = false;
            this.tList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit8});
            this.tList2.Size = new System.Drawing.Size(256, 159);
            this.tList2.TabIndex = 8;
            this.tList2.TreeLevelWidth = 12;
            this.tList2.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tList2.Visible = false;
            this.tList2.DoubleClick += new System.EventHandler(this.tList2_DoubleClick);
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "OBJECTID";
            this.treeListColumn11.FieldName = "OBJECTID";
            this.treeListColumn11.MinWidth = 80;
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            this.treeListColumn11.Width = 90;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "树种";
            this.treeListColumn12.FieldName = "树种";
            this.treeListColumn12.MinWidth = 90;
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 90;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.Caption = "年龄";
            this.treeListColumn13.FieldName = "年龄";
            this.treeListColumn13.MinWidth = 40;
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 2;
            this.treeListColumn13.Width = 50;
            // 
            // repositoryItemImageEdit8
            // 
            this.repositoryItemImageEdit8.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit8.AutoHeight = false;
            this.repositoryItemImageEdit8.Name = "repositoryItemImageEdit8";
            this.repositoryItemImageEdit8.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.tList2);
            this.panelResult.Controls.Add(this.panelButton);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(10, 260);
            this.panelResult.Name = "panelResult";
            this.panelResult.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelResult.Size = new System.Drawing.Size(256, 189);
            this.panelResult.TabIndex = 12;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.labelQuery2);
            this.panelButton.Controls.Add(this.simpleButtonSelect);
            this.panelButton.Controls.Add(this.panel8);
            this.panelButton.Controls.Add(this.simpleButtonUnselect);
            this.panelButton.Controls.Add(this.panel7);
            this.panelButton.Controls.Add(this.simpleButtonAuto);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 161);
            this.panelButton.Name = "panelButton";
            this.panelButton.Padding = new System.Windows.Forms.Padding(0, 4, 3, 0);
            this.panelButton.Size = new System.Drawing.Size(256, 28);
            this.panelButton.TabIndex = 18;
            this.panelButton.Visible = false;
            // 
            // labelQuery2
            // 
            this.labelQuery2.AutoSize = true;
            this.labelQuery2.Location = new System.Drawing.Point(0, 10);
            this.labelQuery2.Name = "labelQuery2";
            this.labelQuery2.Size = new System.Drawing.Size(0, 14);
            this.labelQuery2.TabIndex = 18;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageIndex = 6;
            this.simpleButtonSelect.Location = new System.Drawing.Point(69, 4);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(40, 24);
            this.simpleButtonSelect.TabIndex = 17;
            this.simpleButtonSelect.Text = "全选";
            this.simpleButtonSelect.ToolTip = "选中全部小班";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(109, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(15, 24);
            this.panel8.TabIndex = 18;
            // 
            // simpleButtonUnselect
            // 
            this.simpleButtonUnselect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonUnselect.ImageIndex = 6;
            this.simpleButtonUnselect.Location = new System.Drawing.Point(124, 4);
            this.simpleButtonUnselect.Name = "simpleButtonUnselect";
            this.simpleButtonUnselect.Size = new System.Drawing.Size(46, 24);
            this.simpleButtonUnselect.TabIndex = 19;
            this.simpleButtonUnselect.Text = "全不选";
            this.simpleButtonUnselect.ToolTip = "取消选中全部小班";
            this.simpleButtonUnselect.Click += new System.EventHandler(this.simpleButtonUnselect_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(170, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(15, 24);
            this.panel7.TabIndex = 16;
            // 
            // simpleButtonAuto
            // 
            this.simpleButtonAuto.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonAuto.ImageIndex = 6;
            this.simpleButtonAuto.Location = new System.Drawing.Point(185, 4);
            this.simpleButtonAuto.Name = "simpleButtonAuto";
            this.simpleButtonAuto.Size = new System.Drawing.Size(68, 24);
            this.simpleButtonAuto.TabIndex = 15;
            this.simpleButtonAuto.Text = "批量处理";
            this.simpleButtonAuto.ToolTip = "批量处理";
            this.simpleButtonAuto.Click += new System.EventHandler(this.simpleButtonAuto_Click);
            // 
            // UserControlUpdateAS2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelTown);
            this.Controls.Add(this.panelLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlUpdateAS2";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Size = new System.Drawing.Size(276, 487);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panelTown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit8)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Query()
        {
            GC.Collect();
         //   if (this.m_DBAccess != null)
            {
                try
                {
                    this.m_TownList = null;
                    this.simpleButtonQuery.Enabled = false;
                    this.tList2.Visible = false;
                    this.panelButton.Visible = false;
                    this.labelQuery.Text = "正在查询……";
                    this.checkedListBox1.Items.Clear();
                    this.tList2.Nodes.Clear();
                    this.Cursor = Cursors.WaitCursor;
                    Application.DoEvents();
                    if (this.m_TableName == "")
                    {
                        this.m_TableName = this.GetTableName();
                    }
                    string cmdText = "";
                    string str2 = "";
                    if (this.radioGroup1.SelectedIndex == 0)
                    {
                        this.m_SZ = 0;
                        str2 = "(BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320') AND (PINGJUN_NL>5)";
                    }
                    else if (this.radioGroup1.SelectedIndex == 1)
                    {
                        this.m_SZ = 1;
                        str2 = "(BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (BSSZ>='290' AND BSSZ<='320') AND (BSSZNL>5)";
                    }
                    else
                    {
                        this.labelQuery.Text = "";
                        this.Cursor = Cursors.Default;
                        this.simpleButtonQuery.Enabled = true;
                        this.panelTown.Visible = false;
                        return;
                    }
                    cmdText = "select XIANG,count(*) as XBCOUNT from FOR_XIAOBAN_2014 where " + str2 + "  group by XIANG";
                    cmdText = "select XIANG,CNAME,XBCOUNT from (" + cmdText + ") t1 left join T_SYS_META_CODE on t1.XIANG=T_SYS_META_CODE.CCODE where CDOMAIN='XIANG' order by XIANG";
                    DataTable table = null;// this.ExecuteCommandWithResults(cmdText, (SqlConnection)this.m_DBAccess.Connection);
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        this.labelQuery.Text = "没有需要处理的小班";
                        this.Cursor = Cursors.Default;
                        this.simpleButtonQuery.Enabled = true;
                        this.panelTown.Visible = false;
                        return;
                    }
                    this.panelTown.Visible = true;
                    int num = 0;
                    this.m_TownList = new List<string>();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int num3 = int.Parse(table.Rows[i][2].ToString());
                        this.checkedListBox1.Items.Add(string.Concat(new object[] { table.Rows[i][1].ToString(), "（", num3, "个）" }));
                        this.m_TownList.Add(table.Rows[i][0].ToString());
                        num += num3;
                    }
                    if (this.m_SZ == 0)
                    {
                        this.labelQuery.Text = "优势树种：共" + num + "个";
                    }
                    else if (this.m_SZ == 1)
                    {
                        this.labelQuery.Text = "伴生树种：共" + num + "个";
                    }
                }
                catch (Exception exception)
                {
                    this.labelQuery.Text = "";
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(exception.Message, "提示");
                }
                this.simpleButtonQuery.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButtonAuto_Click(object sender, EventArgs e)
        {
            GC.Collect();
            string message = string.Empty;
            try
            {
                this.panel2.Enabled = false;
                this.panelTown.Enabled = false;
                this.panelButton.Enabled = false;
                this.labelMessage.Text = "正在处理，请稍候……";
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                string sFilter = "";
                for (int i = 0; i < this.tList2.Nodes.Count; i++)
                {
                    if (this.tList2.Nodes[i].Checked)
                    {
                        string str3 = this.tList2.Nodes[i].Tag.ToString();
                        sFilter = sFilter + "," + str3;
                    }
                }
                if (sFilter.Length < 1)
                {
                    MessageBox.Show("请选择要处理的小班！", "提示");
                    this.panel2.Enabled = true;
                    this.panelTown.Enabled = true;
                    this.panelButton.Enabled = true;
                    this.labelMessage.Text = "";
                    this.Cursor = Cursors.Default;
                    return;
                }
                sFilter = EditTask.EditLayer.FeatureClass.OIDFieldName + " in (" + sFilter.Substring(1) + ")";
                string cmdText = "";
                if (this.m_SZ == 0)
                {
                    cmdText = "update " + this.m_TableName + " set PINGJUN_NL=PINGJUN_NL-5 where PINGJUN_NL>5 and " + sFilter;
                }
                else
                {
                    cmdText = "update " + this.m_TableName + " set BSSZNL=BSSZNL-5 where BSSZNL>5 and " + sFilter;
                }
           //     message = this.ExcuteCommandText(cmdText, this.m_DBAccess.Connection as SqlConnection);
                if (message == string.Empty)
                {
                    if (this.m_SZ == 0)
                    {
                   //     message = this.UpdateAsXJ_YS(this.m_DBAccess.Connection as SqlConnection, this.m_TableName, sFilter);
                    }
                    else
                    {
                     //   message = this.UpdateAsXJ_BS(this.m_DBAccess.Connection as SqlConnection, this.m_TableName, sFilter);
                    }
                    if (message == string.Empty)
                    {
                        this.labelMessage.Text = "处理完成";
                    }
                    else
                    {
                        this.labelMessage.Text = "处理失败：" + message;
                    }
                }
                else
                {
                    this.labelMessage.Text = "处理失败：" + message;
                }
            }
            catch (Exception exception)
            {
                message = exception.Message;
                this.labelMessage.Text = "处理失败：" + exception.Message;
            }
            Application.DoEvents();
            this.Cursor = Cursors.Default;
            this.panel2.Enabled = true;
            this.panelTown.Enabled = true;
            this.panelButton.Enabled = true;
            if (message == string.Empty)
            {
                this.Query();
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            this.labelMessage.Text = "";
            this.Query();
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < this.tList2.Nodes.Count; i++)
            {
                this.tList2.Nodes[i].CheckState = CheckState.Checked;
            }
            this.Cursor = Cursors.Default;
        }

        private void simpleButtonUnselect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < this.tList2.Nodes.Count; i++)
            {
                this.tList2.Nodes[i].CheckState = CheckState.Unchecked;
            }
            this.Cursor = Cursors.Default;
        }

        private void tList2_DoubleClick(object sender, EventArgs e)
        {
            int iD = int.Parse(this.tList2.FocusedNode.Tag.ToString());
            IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
            this.ZoomToFeature(this.mHookHelper.ActiveView, featureClass.GetFeature(iD));
        }

        public string UpdateAsXJ_BS(SqlConnection pDb, string sTableName, string sFilter)
        {
            try
            {
                string cmdText = "IF OBJECT_ID('FOR_BSANXJ_PROC2')IS NOT NULL DROP PROC FOR_BSANXJ_PROC2";
                string str2 = this.ExcuteCommandText(cmdText, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                str2 = this.ExcuteCommandText(Resources.UPBSANXJ2, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                string str3 = string.Format("FOR_BSANXJ_PROC2 '{0}'", sTableName);
                str2 = this.ExcuteCommandText(str3, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                cmdText = string.Format("SELECT DISTINCT CUN+LIN_BAN as linban,BSSZNL FROM {0} WHERE " + sFilter + " ORDER BY CUN+LIN_BAN,BSSZNL", sTableName);
                DataTable table = this.ExecuteCommandWithResults(cmdText, pDb);
                string str5 = "FOR_ANBS_VIEW2";
                if ((table != null) && (table.Rows.Count >= 1))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string str6 = row["linban"] as string;
                        int num = Convert.ToInt32(row["BSSZNL"]);
                        cmdText = string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM " + str5 + " WHERE linban='{0}' AND Q_BSSZNL={1} AND XIAN<>'合计' AND XIANG<>'合计' AND CUN<>'合计'", str6, num);
                        DataTable table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                        double num2 = -1.0;
                        double num3 = -1.0;
                        double num4 = -1.0;
                        if ((table2 == null) || (table2.Rows.Count <= 0))
                        {
                            cmdText = string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM " + str5 + " WHERE CUN='{0}' AND Q_BSSZNL={1} AND XIAN<>'合计' and XIANG<>'合计' and linban='合计'", str6.Substring(0, 12), num);
                            table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                            if ((table2 == null) || (table2.Rows.Count <= 0))
                            {
                                cmdText = string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM " + str5 + " WHERE XIANG='{0}' AND Q_BSSZNL={1} AND linban='合计' AND CUN='合计' AND XIAN<>'合计'", str6.Substring(0, 9), num);
                                table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                                if ((table2 == null) || (table2.Rows.Count <= 0))
                                {
                                    cmdText = string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM " + str5 + " WHERE XIAN='{0}' AND Q_BSSZNL={1} AND linban='合计' AND CUN='合计' AND XIANG='合计'", str6.Substring(0, 6), num);
                                    table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                                    if ((table2 != null) && (table2.Rows.Count >= 1))
                                    {
                                        DataRow row2 = table2.Rows[0];
                                        num2 = Convert.ToDouble(row2["Q_BSSZPJXJ"]);
                                        num3 = Convert.ToDouble(row2["Q_BSSZSG"]);
                                        num4 = Convert.ToDouble(row2["Q_BSSZGQDM"]);
                                    }
                                }
                                else
                                {
                                    DataRow row3 = table2.Rows[0];
                                    num2 = Convert.ToDouble(row3["Q_BSSZPJXJ"]);
                                    num3 = Convert.ToDouble(row3["Q_BSSZSG"]);
                                    num4 = Convert.ToDouble(row3["Q_BSSZGQDM"]);
                                }
                            }
                            else
                            {
                                DataRow row4 = table2.Rows[0];
                                num2 = Convert.ToDouble(row4["Q_BSSZPJXJ"]);
                                num3 = Convert.ToDouble(row4["Q_BSSZSG"]);
                                num4 = Convert.ToDouble(row4["Q_BSSZGQDM"]);
                            }
                        }
                        else
                        {
                            DataRow row5 = table2.Rows[0];
                            num2 = Convert.ToDouble(row5["Q_BSSZPJXJ"]);
                            num3 = Convert.ToDouble(row5["Q_BSSZSG"]);
                            num4 = Convert.ToDouble(row5["Q_BSSZGQDM"]);
                        }
                        if (((num2 > 0.0) && (num3 > 0.0)) && (num4 > 0.0))
                        {
                            cmdText = string.Format("UPDATE {0} SET BSSZPJXJ={1},BSSZSG={2},BSSZGQDM={3} WHERE CUN+LIN_BAN={4} AND BSSZNL={5} AND " + sFilter, new object[] { sTableName, num2, num3, num4, str6, num });
                            this.ExcuteCommandText(cmdText, pDb);
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string UpdateAsXJ_YS(SqlConnection pDb, string sTableName, string sFilter)
        {
            try
            {
                string cmdText = "IF OBJECT_ID('FOR_ANXJ_PROC2')IS NOT NULL DROP PROC FOR_ANXJ_PROC2 ";
                string str2 = this.ExcuteCommandText(cmdText, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                str2 = this.ExcuteCommandText(Resources.UPANSXJ2, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                string str3 = string.Format("FOR_ANXJ_PROC2 '{0}'", sTableName);
                str2 = this.ExcuteCommandText(str3, pDb);
                if (str2 != string.Empty)
                {
                    return str2;
                }
                cmdText = string.Format("SELECT DISTINCT CUN+LIN_BAN as linban,PINGJUN_NL FROM {0} WHERE " + sFilter + " ORDER BY CUN+LIN_BAN,PINGJUN_NL", sTableName);
                DataTable table = this.ExecuteCommandWithResults(cmdText, pDb);
                string str5 = "FOR_ANXJ_VIEW2";
                if ((table != null) && (table.Rows.Count >= 1))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        string str6 = row["linban"] as string;
                        int num = Convert.ToInt32(row["PINGJUN_NL"]);
                        cmdText = string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM " + str5 + " WHERE linban='{0}' AND Q_PJNL={1} AND XIAN<>'合计' AND XIANG<>'合计' AND CUN<>'合计'", str6, num);
                        DataTable table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                        double num2 = -1.0;
                        double num3 = -1.0;
                        double num4 = -1.0;
                        if ((table2 == null) || (table2.Rows.Count <= 0))
                        {
                            cmdText = string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM " + str5 + " WHERE CUN='{0}' AND Q_PJNL={1} AND XIAN<>'合计' and XIANG<>'合计' and linban='合计'", str6.Substring(0, 12), num);
                            table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                            if ((table2 == null) || (table2.Rows.Count <= 0))
                            {
                                cmdText = string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM " + str5 + " WHERE XIANG='{0}' AND Q_PJNL={1} AND linban='合计' AND CUN='合计' AND XIAN<>'合计'", str6.Substring(0, 9), num);
                                table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                                if ((table2 == null) || (table2.Rows.Count <= 0))
                                {
                                    cmdText = string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM " + str5 + " WHERE XIAN='{0}' AND Q_PJNL={1} AND linban='合计' AND CUN='合计' AND XIANG='合计'", str6.Substring(0, 6), num);
                                    table2 = this.ExecuteCommandWithResults(cmdText, pDb);
                                    if ((table2 != null) && (table2.Rows.Count >= 1))
                                    {
                                        DataRow row2 = table2.Rows[0];
                                        num2 = Convert.ToDouble(row2["Q_PJXJ"]);
                                        num3 = Convert.ToDouble(row2["Q_PJSG"]);
                                        num4 = Convert.ToDouble(row2["Q_PJDM"]);
                                    }
                                }
                                else
                                {
                                    DataRow row3 = table2.Rows[0];
                                    num2 = Convert.ToDouble(row3["Q_PJXJ"]);
                                    num3 = Convert.ToDouble(row3["Q_PJSG"]);
                                    num4 = Convert.ToDouble(row3["Q_PJDM"]);
                                }
                            }
                            else
                            {
                                DataRow row4 = table2.Rows[0];
                                num2 = Convert.ToDouble(row4["Q_PJXJ"]);
                                num3 = Convert.ToDouble(row4["Q_PJSG"]);
                                num4 = Convert.ToDouble(row4["Q_PJDM"]);
                            }
                        }
                        else
                        {
                            DataRow row5 = table2.Rows[0];
                            num2 = Convert.ToDouble(row5["Q_PJXJ"]);
                            num3 = Convert.ToDouble(row5["Q_PJSG"]);
                            num4 = Convert.ToDouble(row5["Q_PJDM"]);
                        }
                        if (((num2 > 0.0) && (num3 > 0.0)) && (num4 > 0.0))
                        {
                            cmdText = string.Format("UPDATE {0} SET PINGJUN_XJ={1},PINGJUN_SG={2},PINGJUN_DM={3} WHERE CUN+LIN_BAN={4} AND PINGJUN_NL={5} AND " + sFilter, new object[] { sTableName, num2, num3, num4, str6, num });
                            str2 = this.ExcuteCommandText(cmdText, pDb);
                            if (str2 != string.Empty)
                            {
                                return str2;
                            }
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        private void ZoomToFeature(IActiveView pActiveView, IFeature pFeature)
        {
            try
            {
                if ((pActiveView != null) && (pFeature != null))
                {
                    IGeometry shapeCopy = null;
                    IEnvelope envelope = null;
                    shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                    {
                        shapeCopy.Project(this.mHookHelper.FocusMap.SpatialReference);
                        shapeCopy.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shapeCopy.Envelope;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = pActiveView.FullExtent.Width / 38.0;
                        num2 = pActiveView.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shapeCopy as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((pActiveView.Extent.Width != envelope.Width) && (pActiveView.Extent.Height != envelope.Height))
                    {
                        pActiveView.FullExtent = envelope;
                        pActiveView.Refresh();
                    }
                    IFeatureLayer editLayer = EditTask.EditLayer;
                    (editLayer as IFeatureSelection).Clear();
                    if ((editLayer != null) && (pFeature != null))
                    {
                        this.mHookHelper.FocusMap.SelectFeature(editLayer, pFeature);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public object Hook
        {
            set
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = value;
            }
        }
    }
}

