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
using td.logic.sys;
    using td.db.orm;
    using td.db.mid.sys;
    using System.Collections.Generic;

    public class FormUserManage : FormBase2
    {
        private SimpleButton btnCancel;
        private SimpleButton btnCreate;
        private SimpleButton btnDelete;
        private IContainer components;
        private string m_DeptTableName = "";
        private string m_UserAuthorTableName = "";
        private string m_UserTableName = "";       
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private TreeView treeView1;

        public FormUserManage()
        {
            this.InitializeComponent();
            base.MinimizeBox = false;
            base.MaximizeBox = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new FormUserEdit().ShowDialog();
            this.InitTreeList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (((selectedNode == null) || (selectedNode.Tag == null)) || (selectedNode.Tag.ToString() == ""))
            {
                MessageBox.Show("请选中用户再删除！", "提示");
            }
            else if (UserInfo.UserID == selectedNode.Tag.ToString())
            {
                MessageBox.Show("无法删除当前用户！", "提示");
            }
            else
            {
                string str = selectedNode.Tag.ToString();
                if (str == "1")
                {
                    MessageBox.Show("系统管理员用户，无法删除！", "提示");
                }
                else
                {
                    UM.DeleteUser(Convert.ToInt32(str));
                    //string sCmdText = "delete from " + this.m_UserTableName + " where USER_ID=" + str;
                    //if (this.pAccesser.ExecuteNonQuery(sCmdText) > 0)
                    //{
                    //    sCmdText = "delete from " + this.m_UserAuthorTableName + " where USER_ID=" + str;
                    //    int num = this.pAccesser.ExecuteNonQuery(sCmdText);
                    //}
                    this.InitTreeList();
                }
            }
        }
        private UserManager UM
        {
            get { return UserManager.Single; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditUser(string sID)
        {
            FormUserEdit edit = new FormUserEdit();
            edit.UserID = sID;
            edit.ShowDialog();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            this.m_UserTableName = "T_SYS_FLOW_USER";
            this.m_DeptTableName = "T_SYS_FLOW_DEPT";
            this.m_UserAuthorTableName = "T_SYS_USER_AUTHOR";
          
            this.InitTreeList();
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(341, 310);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.treeView1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 0);
            this.panelControl3.Size = new System.Drawing.Size(337, 247);
            this.panelControl3.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(6, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(325, 242);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnCreate);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 249);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(337, 59);
            this.panelControl2.TabIndex = 4;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(10, 18);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "创建用户";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(118, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除用户";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormUserManage
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(341, 310);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormUserManage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FormUser_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitTreeList()
        {
            
                IList list = new ArrayList();
                IList list2 = new ArrayList();
              //  string sql = "select DEPT_ID,DEPT_NAME from " + this.m_DeptTableName + " order by DEPT_ID";
              
              //  DataTable dataTable = this.pAccesser.GetDataTable(this.pAccesser, sql);
        
                if (UM.AllDepts.Count > 0)
                {
                    for (int j = 0; j < UM.AllDepts.Count; j++)
                    {
                        list.Add(UM.AllDepts[j].ID.ToString());
                        list2.Add(UM.AllDepts[j].DEPT_NAME);
                    }
                }
                list.Add("0");
                list2.Add("其他部门");
                this.treeView1.Nodes.Clear();
                TreeNode node = null;
                for (int i = 0; i < list.Count; i++)
                {
                    string str2 = list[i].ToString();
                    string text = list2[i].ToString();
                    node = this.treeView1.Nodes.Add(text);
                    node.Tag = "";
                    node.ForeColor = Color.Blue;
                    node.Expand();
                    //if (str2 == "")
                    //{
                    //    sql = "select USER_ID,USER_NAME from " + this.m_UserTableName + " where USER_DEPT is null";
                    //}
                    //else
                    //{
                    //    sql = "select USER_ID,USER_NAME from " + this.m_UserTableName + " where USER_DEPT=" + str2;
                    //}
                  IList<T_SYS_FLOW_USER_Mid> ulst=  UM.FindUserByDept(int.Parse(str2));
                  //  DataTable table2 = this.pAccesser.GetDataTable(this.pAccesser, sql);
                  if ((ulst != null) && (ulst.Count > 0))
                    {
                        for (int k = 0; k < ulst.Count; k++)
                        {
                            string str4 = ulst[k].ID.ToString();
                            node.Nodes.Add(ulst[k].USER_NAME).Tag = str4;
                        }
                    }
                }
            
        }

        public void SetCloseVisible(bool bVisible)
        {
            this.btnCancel.Visible = bVisible;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode nodeAt = this.treeView1.GetNodeAt(e.Location);
            if (((nodeAt != null) && (nodeAt.Tag != null)) && (nodeAt.Tag.ToString() != ""))
            {
                string sID = nodeAt.Tag.ToString();
                this.EditUser(sID);
                this.InitTreeList();
            }
        }
    }
}

