namespace OperateLog
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraGrid.Views.Base;
    using td.logic.sys;
    using td.db.mid.sys;
    using System.Collections.Generic;

    public class UserControlLog : UserControlBase1
    {
        private SimpleButton btnDelete;
        private SimpleButton btnDeleteAll;
        private SimpleButton btnQuery;
        private ComboBoxEdit comboOperate;
        private IContainer components;
        private DateEdit dateEnd;
        private DateEdit dateStart;
        private GridControl gridControl1;
        private GridView gridView1;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private bool m_bFirst = true;
        private DateTime m_EndTime;
      //  private LogOperate m_LogOp;
        private string m_Operate;
        private DateTime m_StartTime;
        private PanelControl panelControl1;
        private PanelControl panelControl2;

        public UserControlLog()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow focusedDataRow = this.gridView1.GetFocusedDataRow();
                if (focusedDataRow != null)
                {
                    string sLogID = focusedDataRow[0].ToString();
                    if (sLogID != "")
                    {
                        UserManager.Single.DeleteSingleLog(sLogID);                       
                        this.QueryLog();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            UserManager.Single.DeleteLog(this.m_StartTime, this.m_EndTime, this.m_Operate, LogType.SystemType);
            this.QueryLog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.QueryLog();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Init()
        {
            if (this.m_bFirst)
            {
                DateTime date = DateTime.Now.Date;
                this.dateStart.DateTime = date;
                this.dateEnd.DateTime = date;
                //增加操作类型
                this.comboOperate.Properties.Items.Add("全部");
                this.comboOperate.Properties.Items.Add("登录系统");
                this.comboOperate.SelectedIndex = 0;              
                this.QueryLog();
            }
            this.m_bFirst = false;
        }

        private void InitializeComponent()
        {
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.comboOperate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDeleteAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOperate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(84, 31);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateStart.Size = new System.Drawing.Size(131, 20);
            this.dateStart.TabIndex = 0;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(267, 31);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(131, 20);
            this.dateEnd.TabIndex = 1;
            // 
            // comboOperate
            // 
            this.comboOperate.Location = new System.Drawing.Point(84, 73);
            this.comboOperate.Name = "comboOperate";
            this.comboOperate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboOperate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboOperate.Size = new System.Drawing.Size(131, 20);
            this.comboOperate.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(404, 335);
            this.gridControl1.TabIndex = 3;
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnQuery);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dateStart);
            this.groupControl1.Controls.Add(this.dateEnd);
            this.groupControl1.Controls.Add(this.comboOperate);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(408, 111);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "查询条件";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(332, 71);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 27);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "操作类型：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "至";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "起止时间：";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.btnDeleteAll);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(7, 477);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panelControl1.Size = new System.Drawing.Size(408, 41);
            this.panelControl1.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(179, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 34);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "删除当前记录";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(286, 7);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(15, 34);
            this.panelControl2.TabIndex = 2;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteAll.Location = new System.Drawing.Point(301, 7);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(107, 34);
            this.btnDeleteAll.TabIndex = 1;
            this.btnDeleteAll.Text = "删除查询结果";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(7, 118);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(408, 359);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "查询结果";
            // 
            // UserControlLog
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "UserControlLog";
            this.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Size = new System.Drawing.Size(422, 525);
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOperate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void QueryLog()
        {
         
                this.m_StartTime = this.dateStart.DateTime;
                this.m_EndTime = this.dateEnd.DateTime.AddDays(1.0);
                int selectedIndex = this.comboOperate.SelectedIndex;
                if (selectedIndex <= 0)
                {
                    this.m_Operate = "";
                }
                else
                {
                    this.m_Operate = this.comboOperate.Properties.Items[selectedIndex].ToString();
                }
                if (this.m_EndTime <= this.m_StartTime)
                {
                    MessageBox.Show("终止时间早于起始时间，请修改!", "提示", MessageBoxButtons.OK);
                }
                IList<T_LOG_Mid> logList = UserManager.Single.GetLogs(this.m_StartTime, this.m_EndTime, this.m_Operate, "");
                DataTable table2 = new DataTable();
                table2.Columns.Add("id");
                table2.Columns.Add("用户");
                table2.Columns.Add("操作");
                table2.Columns.Add("时间");
                table2.Columns.Add("备注");
                if ((logList != null) && (logList.Count > 0))
                {
                    foreach (T_LOG_Mid mid in logList)
                    {
                      
                        DataRow row2 = table2.NewRow();
                        row2[0] = mid.ID;
                        row2[1] = mid.USER_NAME;
                        row2[2] = mid.OPERATE;
                        row2[3] = mid.LOG_TIME;
                        row2[4] = mid.REMARK;
                        table2.Rows.Add(row2);
                    }
                }
                this.gridControl1.DataSource = table2;
                this.gridView1.Columns[0].Visible = false;
            
        }

        public  void Refresh()
        {
            this.QueryLog();
        }
    }
}

