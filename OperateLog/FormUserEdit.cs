namespace OperateLog
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using td.db.orm;
    using td.db.mid.sys;
    using System.Collections.Generic;

    public class FormUserEdit : FormBase3
    {
        private SimpleButton btnAllselect;
        private SimpleButton btnAuthor;
        private SimpleButton btnBack;
        private SimpleButton btnCancel;
        private SimpleButton btnMore;
        private SimpleButton btnOK;
        private SimpleButton btnUnselect;
        private ComboBoxEdit comboBoxEditDept;
        private ComboBoxEdit comboBoxEditSex;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl10;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private CheckedListBoxControl listBoxAuthor;
        private IList m_AuthorList;
        private string m_AuthorTableName = "";
        private bool m_bCreate = true;
        private IList m_DeptList;
        private string m_DeptTableName = "";
        private string m_UserAuthorTableName = "";
        private string m_UserID = "";
        private string m_UserTableName = "";
  
        private PanelControl panelAuthor;
        private PanelControl panelBasic;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl7;
        private PanelControl panelControl8;
        private TextEdit textEditEmail;
        private TextEdit textEditNote;
        private TextEdit textEditPhone;
        private TextEdit textEditUsername;
        private TextEdit textEditUserpwd;

        public FormUserEdit()
        {
            this.InitializeComponent();
            base.MinimizeBox = false;
            base.MaximizeBox = false;
        }

        private void btnAllselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAuthor.Items.Count; i++)
            {
                this.listBoxAuthor.Items[i].CheckState = CheckState.Checked;
            }
        }
        public td.logic.sys.UserManager UM
        {
            get
            {
                return DBServiceFactory<td.logic.sys.UserManager>.Service;
            }
        }
        private void btnAuthor_Click(object sender, EventArgs e)
        {
            string sCmdText = "";
            try
            {
              //  sCmdText = "delete from " + this.m_UserAuthorTableName + " where USER_ID=" + this.m_UserID;
                int num = UM.UserAuthService.DeleteBySql("USER_ID=" + this.m_UserID);
               // int num = this.pAccesser.ExecuteNonQuery(sCmdText);
                if (this.listBoxAuthor.Items.Count > 0)
                {
                    for (int i = 0; i < this.listBoxAuthor.Items.Count; i++)
                    {
                        if (this.listBoxAuthor.Items[i].CheckState == CheckState.Checked)
                        {
                            //object obj2 = "insert into " + this.m_UserAuthorTableName + "(USER_ID,AUTHOR_ID) values(";
                            //sCmdText = string.Concat(new object[] { obj2, this.m_UserID, ",", this.m_AuthorList[i], ")" });
                            T_SYS_USER_AUTHOR_Mid mid = new T_SYS_USER_AUTHOR_Mid();
                            mid.USER_ID = Convert.ToInt32(m_UserID);
                            mid.AUTHOR_ID = Convert.ToInt32(this.m_AuthorList[i]);
                            num=UM.UserAuthService.Add(mid) ? 1 : -1;
                           // num = this.pAccesser.ExecuteNonQuery(sCmdText);
                        }
                    }
                }
                if (num >= 0)
                {
                    MessageBox.Show("权限设置成功！", "提示");
                }
            }
            catch
            {
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.panelBasic.Visible = true;
            this.panelAuthor.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            this.panelBasic.Visible = false;
            this.panelAuthor.Visible = true;
        }
        private T_SYS_FLOW_USER_Mid m_userMid;
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql = "";
            string text = this.textEditUsername.Text;
            if (text.Trim() == "")
            {
                MessageBox.Show("请填写用户名！", "提示");
            }
            else
            {
                string str3 = this.textEditUserpwd.Text;
                if (str3.Trim() == "")
                {
                    MessageBox.Show("请填写密码！", "提示");
                }
                else
                {
                    string str4 = this.textEditPhone.Text;
                    string str5 = this.textEditEmail.Text;
                    string str6 = this.textEditNote.Text;
                    int selectedIndex = this.comboBoxEditDept.SelectedIndex;
                    string str7 = "0";
                    if (selectedIndex >= 0)
                    {
                        str7 = this.m_DeptList[this.comboBoxEditDept.SelectedIndex].ToString();
                    }
                    string selectedText = this.comboBoxEditSex.SelectedText;
                    string str9 = "";
                    bool res = false;
                    if (this.m_bCreate)
                    {
                        //sql = "select USER_NAME from " + this.m_UserTableName + " where USER_NAME='" + text + "'";
                        //DataTable dataTable = this.pAccesser.GetDataTable(this.pAccesser, sql);
                        if (UM.IsUserNameExist(text))
                        {
                            MessageBox.Show("用户名与已有用户重复，请重新键入用户名！", "提示");
                            return;
                        }
                        str9 = "添加用户";
                        //sql = "select max(USER_ID) from " + this.m_UserTableName;
                        //int num2 = Convert.ToInt32(this.pAccesser.ExecuteScalar(sql).ToString()) + 1;
                        //this.m_UserID = num2.ToString();
                        DateTime now = DateTime.Now;
                        //sql = string.Concat(new object[] { 
                        //    "insert into ", this.m_UserTableName, "(USER_NAME,USER_PASSWORD,USER_NOTE,USER_SEX,USER_PHONE,USER_EMAIL,USER_DEPT,USER_ID,CREATE_TIME) values('", text, "','", str3, "','", str6, "','", selectedText, "','", str4, "','", str5, "',", str7,
                        //    ",", num2, ",'", now, "')"
                        //});
                        T_SYS_FLOW_USER_Mid uMid = new T_SYS_FLOW_USER_Mid();
                        uMid.USER_NAME = text;
                        uMid.USER_PASSWORD = str3;
                        uMid.USER_NOTE = str6;
                        uMid.USER_SEX = selectedText;
                        uMid.USER_PHONE = str4;
                        uMid.USER_EMAIL = str5;
                        uMid.USER_DEPT = comboBoxEditDept.SelectedIndex+1;
                        uMid.CREATE_TIME = DateTime.Now;
                        res=UM.UserService.Add(uMid);
                    }
                    else
                    {
                        str9 = "修改用户";
                       // sql = "update " + this.m_UserTableName + " set USER_NAME='" + text + "',USER_PASSWORD='" + str3 + "',USER_NOTE='" + str6 + "',USER_SEX='" + selectedText + "',USER_PHONE='" + str4 + "',USER_EMAIL='" + str5 + "',USER_DEPT=" + str7 + " where USER_ID=" + this.m_UserID;

                        m_userMid.USER_NAME = text;
                        m_userMid.USER_PASSWORD = str3;
                        m_userMid.USER_NOTE = str6;
                        m_userMid.USER_SEX = selectedText;
                        m_userMid.USER_PHONE = selectedText;
                        m_userMid.USER_EMAIL = str4;
                        m_userMid.USER_DEPT = Convert.ToInt32(str5);
                        m_userMid.CREATE_TIME = DateTime.Now;
                       res= UM.UserService.Edit(m_userMid);
                    }
                    if (res)
                    {
                        if (this.SetAuthor())
                        {
                            MessageBox.Show(str9 + "成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show(str9 + "失败！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show(str9 + "失败！", "提示");
                    }
                    base.Close();
                }
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listBoxAuthor.Items.Count; i++)
            {
                this.listBoxAuthor.Items[i].CheckState = CheckState.Unchecked;
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

        private void FormUserEdit_Load(object sender, EventArgs e)
        {
            if (this.m_UserID != "")
            {
                this.textEditUsername.Enabled = false;
            }
            this.m_UserTableName = "T_SYS_FLOW_USER";
            this.m_DeptTableName = "T_SYS_FLOW_DEPT";
            this.m_AuthorTableName = "T_SYS_FLOW_AUTHOR";
            this.m_UserAuthorTableName = "T_SYS_USER_AUTHOR";          
            this.InitControls();
        }

        private int GetDeptIndex(string sValue)
        {
            for (int i = 0; i < this.m_DeptList.Count; i++)
            {
                if (this.m_DeptList[i].ToString() == sValue)
                {
                    return i;
                }
            }
            return -1;
        }

        private void InitControls()
        {
            string sql = "";
            DataTable dataTable = null;
            this.panelBasic.Visible = true;
            this.panelAuthor.Visible = false;
            this.m_DeptList = new ArrayList();
            this.comboBoxEditDept.Properties.Items.Clear();
          //  sql = "select DEPT_ID,DEPT_NAME from " + this.m_DeptTableName;
           // dataTable = this.pAccesser.GetDataTable(this.pAccesser, sql);
            
            if (UM.AllDepts.Count > 0)
            {
                for (int i = 0; i < UM.AllDepts.Count; i++)
                {
                    string item = UM.AllDepts[i].DEPT_NAME;
                    this.m_DeptList.Add(UM.AllDepts[i].ID.ToString());
                    this.comboBoxEditDept.Properties.Items.Add(item);
                }
            }
            this.comboBoxEditSex.Properties.Items.Clear();
            this.comboBoxEditSex.Properties.Items.Add("男");
            this.comboBoxEditSex.Properties.Items.Add("女");
            if (this.m_UserID != "")
            {
                sql = "select * from " + this.m_UserTableName + " where USER_ID=" + this.m_UserID;
               this.m_userMid= UM.UserService.Find(Convert.ToInt32(m_UserID));
               // DataTable table2 = this.pAccesser.GetDataTable(this.pAccesser, sql);
               if (null != m_userMid)
                {
                   // DataRow row = table2.Rows[0];
                    this.textEditUsername.Text = m_userMid.USER_NAME;
                    this.textEditUserpwd.Text = m_userMid.USER_PASSWORD;
                    this.textEditEmail.Text = m_userMid.USER_EMAIL;
                    this.textEditNote.Text = m_userMid.USER_NOTE;
                    this.textEditPhone.Text = m_userMid.USER_PHONE;
                    this.comboBoxEditDept.SelectedIndex = m_userMid.USER_DEPT;
                    this.comboBoxEditSex.SelectedText = m_userMid.USER_SEX;
                }
            }
            if (this.m_UserID == "1")
            {
                this.btnMore.Enabled = false;
            }
            else
            {
                this.btnMore.Enabled = true;
                this.ShowAuthorList();
            }
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelAuthor = new DevExpress.XtraEditors.PanelControl();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.listBoxAuthor = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselect = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllselect = new DevExpress.XtraEditors.SimpleButton();
            this.btnAuthor = new DevExpress.XtraEditors.SimpleButton();
            this.panelBasic = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditSex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditDept = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditNote = new DevExpress.XtraEditors.TextEdit();
            this.textEditEmail = new DevExpress.XtraEditors.TextEdit();
            this.textEditPhone = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserpwd = new DevExpress.XtraEditors.TextEdit();
            this.textEditUsername = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnMore = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelAuthor)).BeginInit();
            this.panelAuthor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBasic)).BeginInit();
            this.panelBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelAuthor);
            this.panelControl1.Controls.Add(this.panelBasic);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(341, 362);
            this.panelControl1.TabIndex = 1;
            // 
            // panelAuthor
            // 
            this.panelAuthor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelAuthor.Controls.Add(this.panelControl8);
            this.panelAuthor.Controls.Add(this.panelControl7);
            this.panelAuthor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuthor.Location = new System.Drawing.Point(2, 364);
            this.panelAuthor.Name = "panelAuthor";
            this.panelAuthor.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.panelAuthor.Size = new System.Drawing.Size(337, 345);
            this.panelAuthor.TabIndex = 0;
            // 
            // panelControl8
            // 
            this.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl8.Controls.Add(this.listBoxAuthor);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl8.Location = new System.Drawing.Point(1, 0);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panelControl8.Size = new System.Drawing.Size(335, 265);
            this.panelControl8.TabIndex = 5;
            // 
            // listBoxAuthor
            // 
            this.listBoxAuthor.CheckOnClick = true;
            this.listBoxAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAuthor.Location = new System.Drawing.Point(10, 10);
            this.listBoxAuthor.Name = "listBoxAuthor";
            this.listBoxAuthor.Size = new System.Drawing.Size(315, 255);
            this.listBoxAuthor.TabIndex = 0;
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Controls.Add(this.btnBack);
            this.panelControl7.Controls.Add(this.btnUnselect);
            this.panelControl7.Controls.Add(this.btnAllselect);
            this.panelControl7.Controls.Add(this.btnAuthor);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl7.Location = new System.Drawing.Point(1, 265);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(335, 80);
            this.panelControl7.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(246, 42);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUnselect
            // 
            this.btnUnselect.Location = new System.Drawing.Point(26, 42);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(75, 23);
            this.btnUnselect.TabIndex = 2;
            this.btnUnselect.Text = "全不选";
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // btnAllselect
            // 
            this.btnAllselect.Location = new System.Drawing.Point(26, 10);
            this.btnAllselect.Name = "btnAllselect";
            this.btnAllselect.Size = new System.Drawing.Size(75, 23);
            this.btnAllselect.TabIndex = 1;
            this.btnAllselect.Text = "全选";
            this.btnAllselect.Click += new System.EventHandler(this.btnAllselect_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.Location = new System.Drawing.Point(145, 10);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnAuthor.TabIndex = 0;
            this.btnAuthor.Text = "设置";
            this.btnAuthor.Visible = false;
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            // 
            // panelBasic
            // 
            this.panelBasic.Controls.Add(this.panelControl3);
            this.panelBasic.Controls.Add(this.panelControl2);
            this.panelBasic.Controls.Add(this.panelControl4);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(2, 2);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(337, 362);
            this.panelBasic.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.comboBoxEditSex);
            this.panelControl3.Controls.Add(this.btnCancel);
            this.panelControl3.Controls.Add(this.comboBoxEditDept);
            this.panelControl3.Controls.Add(this.textEditNote);
            this.panelControl3.Controls.Add(this.textEditEmail);
            this.panelControl3.Controls.Add(this.textEditPhone);
            this.panelControl3.Controls.Add(this.textEditUserpwd);
            this.panelControl3.Controls.Add(this.textEditUsername);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(77, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(250, 302);
            this.panelControl3.TabIndex = 2;
            // 
            // comboBoxEditSex
            // 
            this.comboBoxEditSex.Location = new System.Drawing.Point(23, 129);
            this.comboBoxEditSex.Name = "comboBoxEditSex";
            this.comboBoxEditSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSex.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBoxEditSex.Size = new System.Drawing.Size(153, 20);
            this.comboBoxEditSex.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxEditDept
            // 
            this.comboBoxEditDept.Location = new System.Drawing.Point(23, 93);
            this.comboBoxEditDept.Name = "comboBoxEditDept";
            this.comboBoxEditDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditDept.Size = new System.Drawing.Size(153, 20);
            this.comboBoxEditDept.TabIndex = 5;
            // 
            // textEditNote
            // 
            this.textEditNote.Location = new System.Drawing.Point(23, 237);
            this.textEditNote.Name = "textEditNote";
            this.textEditNote.Size = new System.Drawing.Size(184, 20);
            this.textEditNote.TabIndex = 4;
            // 
            // textEditEmail
            // 
            this.textEditEmail.Location = new System.Drawing.Point(23, 200);
            this.textEditEmail.Name = "textEditEmail";
            this.textEditEmail.Size = new System.Drawing.Size(153, 20);
            this.textEditEmail.TabIndex = 3;
            // 
            // textEditPhone
            // 
            this.textEditPhone.Location = new System.Drawing.Point(23, 166);
            this.textEditPhone.Name = "textEditPhone";
            this.textEditPhone.Size = new System.Drawing.Size(153, 20);
            this.textEditPhone.TabIndex = 2;
            // 
            // textEditUserpwd
            // 
            this.textEditUserpwd.Location = new System.Drawing.Point(23, 56);
            this.textEditUserpwd.Name = "textEditUserpwd";
            this.textEditUserpwd.Properties.MaxLength = 8;
            this.textEditUserpwd.Properties.PasswordChar = '*';
            this.textEditUserpwd.Size = new System.Drawing.Size(153, 20);
            this.textEditUserpwd.TabIndex = 1;
            // 
            // textEditUsername
            // 
            this.textEditUsername.Location = new System.Drawing.Point(23, 21);
            this.textEditUsername.Name = "textEditUsername";
            this.textEditUsername.Properties.MaxLength = 20;
            this.textEditUsername.Size = new System.Drawing.Size(153, 20);
            this.textEditUsername.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl10);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(75, 302);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Location = new System.Drawing.Point(12, 25);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(7, 14);
            this.labelControl10.TabIndex = 9;
            this.labelControl10.Text = "*";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl9.Location = new System.Drawing.Point(12, 62);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(7, 14);
            this.labelControl9.TabIndex = 8;
            this.labelControl9.Text = "*";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 240);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "备注：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(25, 203);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "邮箱：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(25, 167);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "电话：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(25, 132);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "性别：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "部门：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密码：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnMore);
            this.panelControl4.Controls.Add(this.btnOK);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(2, 304);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(333, 56);
            this.panelControl4.TabIndex = 3;
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(25, 6);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(63, 33);
            this.btnMore.TabIndex = 2;
            this.btnMore.Text = "权限编辑";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(233, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "提交";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormUserEdit
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(341, 362);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户编辑";
            this.Load += new System.EventHandler(this.FormUserEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelAuthor)).EndInit();
            this.panelAuthor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBasic)).EndInit();
            this.panelBasic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private bool SetAuthor()
        {
            string sCmdText = "";
            try
            {
                sCmdText = "USER_ID=" + this.m_UserID;
              //  int num = this.pAccesser.ExecuteNonQuery(sCmdText);
                int num = UM.UserAuthService.DeleteBySql(sCmdText);
                if (this.listBoxAuthor.Items.Count > 0)
                {
                    for (int i = 0; i < this.listBoxAuthor.Items.Count; i++)
                    {
                        if (this.listBoxAuthor.Items[i].CheckState == CheckState.Checked)
                        {
                            T_SYS_USER_AUTHOR_Mid mid = new T_SYS_USER_AUTHOR_Mid();
                            //object obj2 = "insert into " + this.m_UserAuthorTableName + "(USER_ID,AUTHOR_ID) values(";
                            //sCmdText = string.Concat(new object[] { obj2, this.m_UserID, ",", this.m_AuthorList[i], ")" });
                            //num = this.pAccesser.ExecuteNonQuery(sCmdText);
                            mid.USER_ID = Convert.ToInt32(m_UserID);
                            mid.AUTHOR_ID = Convert.ToInt32(this.m_AuthorList[i]);
                            num= UM.UserAuthService.Add(mid)?1:-1;
                           
                        }
                    }
                }
                return (num >= 0);
            }
            catch
            {
                return false;
            }
        }

        private void ShowAuthorList()
        {
            this.listBoxAuthor.Items.Clear();
            string sql = "";

            IList<T_SYS_FLOW_AUTHOR_Mid> authList = new List<T_SYS_FLOW_AUTHOR_Mid>();
            if (this.m_UserID != "")
            {
               authList = UM.UserAuthService.FindAuthByUID(Convert.ToInt32(m_UserID));
                //sql = "select AUTHOR_ID from " + this.m_UserAuthorTableName + " where USER_ID=" + this.m_UserID;
                //DataTable table = this.pAccesser.GetDataTable(this.pAccesser, sql);
                //if ((table != null) && (table.Rows.Count > 0))
                //{
                //    for (int i = 0; i < table.Rows.Count; i++)
                //    {
                //        list.Add(table.Rows[i]["AUTHOR_ID"].ToString());
                //    }
                //}
            }
            this.m_AuthorList = new ArrayList();
            //sql = "select AUTHOR_ID,SYSTEM_ZT from " + this.m_AuthorTableName + " order by AUTHOR_ID";
            //DataTable dataTable = this.pAccesser.GetDataTable(this.pAccesser, sql);
            IList<T_SYS_FLOW_AUTHOR_Mid> alAuthList = UM.AuthService.FindAll();
            if (alAuthList.Count > 0)
            {
                for (int j = 0; j < alAuthList.Count; j++)
                {
                    T_SYS_FLOW_AUTHOR_Mid aMid=alAuthList[j];
                    string str2 = aMid.AUTHOR_ID.ToString();
                    string item = aMid.SYSTEM_ZT;
                    this.m_AuthorList.Add(str2);
                    this.listBoxAuthor.Items.Add(item);
                    foreach (T_SYS_FLOW_AUTHOR_Mid iMid in authList)
                    {
                        if (iMid.AUTHOR_ID == aMid.AUTHOR_ID)
                        {
                            this.listBoxAuthor.Items[j].CheckState = CheckState.Checked;
                        }
                    }
                }
            }
        }

        public string UserID
        {
            set
            {
                this.m_UserID = value;
                this.m_bCreate = false;
            }
        }
    }
}

