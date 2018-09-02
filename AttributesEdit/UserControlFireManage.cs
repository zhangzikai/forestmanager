namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlFireManage : UserControlBase1
    {
        private SimpleButton buttonAdd;
        private SimpleButton buttonCancel;
        private SimpleButton buttonDelete;
        private SimpleButton buttonModify;
        private SimpleButton buttonSubmit;
        private SimpleButton buttonView;
        private IContainer components;
        private DateEdit dateEnd;
        private DateEdit dateStart;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelMessage;
        private ListBox listBox1;
        private bool m_bFirst = true;
        private const string m_ClassName = "FormFireList";
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IList m_RowList;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ITable m_Table;
        private int m_Type = 1;
        private Panel panel1;
        private Panel panel10;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private PanelControl panelControl3;
        private Panel panelInfo;
        private Panel panelList;
        private SimpleButton simpleButtonQuery;
        private UserControlFireInfo userControlFireInfo1;

        public UserControlFireManage()
        {
            this.InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.m_Type = 3;
            this.ShowFireInfo(null);
            this.panelList.Visible = false;
            this.panelInfo.Visible = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.panelInfo.Visible = false;
            this.panelList.Visible = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将删除选中火灾所对应的的所有班块，是否继续删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int selectedIndex = this.listBox1.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    IRow pRow = this.m_RowList[selectedIndex] as IRow;
                    this.DeleteFire(pRow);
                    this.Query();
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                this.m_Type = 2;
                this.ShowFireInfo(this.m_RowList[selectedIndex] as IObject);
                this.panelList.Visible = false;
                this.panelInfo.Visible = true;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string str = this.userControlFireInfo1.SubmitValues();
            if (str == "")
            {
                this.panelInfo.Visible = false;
                this.panelList.Visible = true;
                this.Query();
            }
            else
            {
                this.labelMessage.Text = "提交失败：" + str;
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;
            if (selectedIndex >= 0)
            {
                this.m_Type = 1;
                this.ShowFireInfo(this.m_RowList[selectedIndex] as IObject);
                this.panelList.Visible = false;
                this.panelInfo.Visible = true;
            }
        }

        private void DeleteFire(IRow pRow)
        {
            if (pRow != null)
            {
                try
                {
                    string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "IDField");
                    int index = pRow.Fields.FindField(name);
                    if (index >= 0)
                    {
                        string str2 = pRow.get_Value(index).ToString();
                        pRow.Delete();
                        string str3 = name + "='" + str2 + "'";
                        IFeatureLayer editLayer = EditTask.EditLayer;
                        if (editLayer != null)
                        {
                            IFeatureClass featureClass = editLayer.FeatureClass;
                            if (featureClass != null)
                            {
                                IQueryFilter filter = new QueryFilterClass {
                                    WhereClause = str3,
                                    SubFields = featureClass.OIDFieldName
                                };
                                IFeatureCursor o = featureClass.Search(filter, false);
                                if (o != null)
                                {
                                    IFeature feature = null;
                                    while ((feature = o.NextFeature()) != null)
                                    {
                                        feature.Delete();
                                    }
                                    Marshal.ReleaseComObject(o);
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "FormFireList", "DeleteFire", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
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

        private ITable GetFireTable()
        {
            string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "FireTable");
            IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
            if (editWorkspace == null)
            {
                return null;
            }
            ITable table = null;
            try
            {
                table = editWorkspace.OpenTable(name);
            }
            catch
            {
                return null;
            }
            return table;
        }

        public void Init()
        {
            if (this.m_bFirst)
            {
                this.panelList.Visible = true;
                this.panelInfo.Visible = false;
                this.buttonModify.Enabled = false;
                this.buttonView.Enabled = false;
                this.buttonDelete.Enabled = false;
                this.labelMessage.Text = "";
                DateTime now = DateTime.Now;
                this.dateStart.Text = now.AddMonths(-2).Date.ToString();
                this.dateEnd.Text = now.ToShortDateString() + " 23:59:59";
                if (this.m_Table == null)
                {
                    this.m_Table = this.GetFireTable();
                }
                if (this.m_Table == null)
                {
                    MessageBox.Show("未找到火灾信息表！", "提示");
                    this.buttonAdd.Enabled = false;
                }
                else
                {
                    this.buttonAdd.Enabled = true;
                    this.Query();
                }
            }
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelMessage = new DevExpress.XtraEditors.LabelControl();
            this.buttonSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.userControlFireInfo1 = new AttributesEdit.UserControlFireInfo();
            this.panelList = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonView = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonModify = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelInfo);
            this.panel1.Controls.Add(this.panelList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 700);
            this.panel1.TabIndex = 1;
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.panel7);
            this.panelInfo.Controls.Add(this.userControlFireInfo1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 252);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(6, 20, 6, 0);
            this.panelInfo.Size = new System.Drawing.Size(490, 442);
            this.panelInfo.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.labelMessage);
            this.panel7.Controls.Add(this.buttonSubmit);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.buttonCancel);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(6, 406);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.panel7.Size = new System.Drawing.Size(478, 36);
            this.panel7.TabIndex = 1;
            // 
            // labelMessage
            // 
            this.labelMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMessage.Location = new System.Drawing.Point(10, 4);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 14);
            this.labelMessage.TabIndex = 4;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSubmit.Location = new System.Drawing.Point(230, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(63, 28);
            this.buttonSubmit.TabIndex = 0;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(293, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(61, 28);
            this.panel8.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Location = new System.Drawing.Point(354, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(63, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(417, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(61, 28);
            this.panel9.TabIndex = 2;
            // 
            // userControlFireInfo1
            // 
            this.userControlFireInfo1.Appearance.BackColor = System.Drawing.Color.White;
            this.userControlFireInfo1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.userControlFireInfo1.Appearance.Options.UseBackColor = true;
            this.userControlFireInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFireInfo1.Location = new System.Drawing.Point(6, 20);
            this.userControlFireInfo1.Name = "userControlFireInfo1";
            this.userControlFireInfo1.Size = new System.Drawing.Size(478, 422);
            this.userControlFireInfo1.TabIndex = 0;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.panel2);
            this.panelList.Controls.Add(this.panel3);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(490, 252);
            this.panelList.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.panelControl3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 6);
            this.panel2.Size = new System.Drawing.Size(490, 192);
            this.panel2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(8, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(474, 147);
            this.listBox1.TabIndex = 42;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonQuery);
            this.panelControl3.Controls.Add(this.panel10);
            this.panelControl3.Controls.Add(this.dateEnd);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.dateStart);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(8, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(3, 8, 6, 8);
            this.panelControl3.Size = new System.Drawing.Size(474, 39);
            this.panelControl3.TabIndex = 5;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonQuery.ImageIndex = 2;
            this.simpleButtonQuery.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonQuery.Location = new System.Drawing.Point(391, 8);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(26, 23);
            this.simpleButtonQuery.TabIndex = 80;
            this.simpleButtonQuery.ToolTip = "查找";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(358, 8);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(33, 23);
            this.panel10.TabIndex = 92;
            // 
            // dateEnd
            // 
            this.dateEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(208, 8);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.EditFormat.FormatString = "G";
            this.dateEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "G";
            this.dateEnd.Size = new System.Drawing.Size(150, 20);
            this.dateEnd.TabIndex = 91;
            // 
            // labelControl2
            // 
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.Location = new System.Drawing.Point(189, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 14);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = " — ";
            // 
            // dateStart
            // 
            this.dateStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(39, 8);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.dateStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.EditFormat.FormatString = "G";
            this.dateStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateStart.Properties.Mask.EditMask = "G";
            this.dateStart.Size = new System.Drawing.Size(150, 20);
            this.dateStart.TabIndex = 90;
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 39;
            this.labelControl1.Text = "时间：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonView);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.buttonModify);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 192);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 10, 10, 20);
            this.panel3.Size = new System.Drawing.Size(490, 60);
            this.panel3.TabIndex = 1;
            // 
            // buttonView
            // 
            this.buttonView.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonView.Location = new System.Drawing.Point(264, 10);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(45, 30);
            this.buttonView.TabIndex = 2;
            this.buttonView.Text = "查看";
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(231, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(33, 30);
            this.panel6.TabIndex = 6;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonDelete.Location = new System.Drawing.Point(186, 10);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(45, 30);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(153, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(33, 30);
            this.panel5.TabIndex = 5;
            // 
            // buttonModify
            // 
            this.buttonModify.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonModify.Location = new System.Drawing.Point(108, 10);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(45, 30);
            this.buttonModify.TabIndex = 1;
            this.buttonModify.Text = "修改";
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(75, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(33, 30);
            this.panel4.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAdd.Location = new System.Drawing.Point(30, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(45, 30);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "新增";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // UserControlFireManage
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "UserControlFireManage";
            this.Size = new System.Drawing.Size(490, 700);
            this.panel1.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
            {
                this.buttonView.Enabled = true;
                this.buttonModify.Enabled = true;
                this.buttonDelete.Enabled = true;
            }
        }

        private void Query()
        {
            if (this.m_Table != null)
            {
                DateTime dateTime = this.dateStart.DateTime;
                DateTime time2 = this.dateEnd.DateTime;
                this.listBox1.Items.Clear();
                try
                {
                    string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "TimeField");
                    string str2 = "";                 
                    string str9 = str2;
                    str2 = str9 + name + ">= '" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and " + name + "< '" + time2.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    
                    IQueryFilter queryFilter = new QueryFilterClass {
                        WhereClause = str2
                    };
                    ICursor o = this.m_Table.Search(queryFilter, false);
                    if (o != null)
                    {
                        ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                        string str4 = configOpt.GetConfigValue2("Fire", "IDField");
                        string str5 = configOpt.GetConfigValue2("Fire", "PlaceField");
                        int index = this.m_Table.FindField(str4);
                        if (index >= 0)
                        {
                            int num2 = this.m_Table.FindField(str5);
                            int num3 = this.m_Table.FindField(name);
                            this.m_RowList = new ArrayList();
                            IRow row = null;
                            while ((row = o.NextRow()) != null)
                            {
                                this.m_RowList.Add(row);
                                row.get_Value(index).ToString();
                                string str6 = "";
                                if (num2 >= 0)
                                {
                                    str6 = row.get_Value(num2).ToString();
                                }
                                string str7 = "";
                                if (num3 >= 0)
                                {
                                    try
                                    {
                                        str7 = Convert.ToDateTime(row.get_Value(num3).ToString()).ToString("yyyy年MM月dd日HH时mm分ss秒");
                                    }
                                    catch
                                    {
                                        str7 = "";
                                    }
                                }
                                this.listBox1.Items.Add(str7 + "(" + str6 + ")");
                            }
                            Marshal.ReleaseComObject(o);
                            this.buttonDelete.Enabled = false;
                            this.buttonModify.Enabled = false;
                            this.buttonView.Enabled = false;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("查询出错！", "提示");
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "FormFireList", "Query", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        private void ShowFireInfo(IObject pObject)
        {
            if (this.m_Type == 3)
            {
                this.buttonSubmit.Visible = true;
                this.userControlFireInfo1.Init(true, this.m_Table, pObject, true);
            }
            else if (this.m_Type == 2)
            {
                this.buttonSubmit.Visible = true;
                this.userControlFireInfo1.Init(true, this.m_Table, pObject, false);
            }
            else
            {
                this.buttonSubmit.Visible = false;
                this.userControlFireInfo1.Init(false, this.m_Table, pObject, false);
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }
    }
}

