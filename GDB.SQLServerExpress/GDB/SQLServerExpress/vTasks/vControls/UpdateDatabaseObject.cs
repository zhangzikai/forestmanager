namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.Properties;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UpdateDatabaseObject : UserControlBase1
    {
        private Server _server;
        private Microsoft.SqlServer.Management.Common.ServerConnection _serverConnection;
        private CheckEdit checkEdit_deleteCode;
        private CheckEdit checkEdit_deleteIndex;
        private CheckEdit checkEdit_id;
        private CheckEdit checkEdit_xk;
        private List<string> codes = new List<string>();
        private ComboBoxEdit comboBoxEdit_database;
        private IContainer components;
        private List<string> ids = new List<string>();
        private LabelControl labelControl_databases;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private SimpleButton sb_Skip;
        private TextEdit textEdit_code;
        private TextEdit textEdit_xk;

        public event Skip SkipEvent;

        public UpdateDatabaseObject()
        {
            this.InitializeComponent();
        }

        private void checkEdit_deleteCode_CheckedChanged(object sender, EventArgs e)
        {
            this.textEdit_code.Enabled = this.checkEdit_deleteCode.Checked;
        }

        private void checkEdit_xk_CheckedChanged(object sender, EventArgs e)
        {
            this.textEdit_xk.Enabled = this.checkEdit_xk.Checked;
        }

        private void comboBoxEdit_database_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.codes.Clear();
            this.ids.Clear();
            string str = this.comboBoxEdit_database.SelectedText.ToUpper();
            if (str.Contains("FORDATA"))
            {
                this.checkEdit_deleteIndex.Enabled = true;
                this.codes.AddRange(new string[] { "T_SYS_LD_ADMIN_CODES", "T_SYS_META_CODE" });
                this.ids.AddRange(new string[] { 
                    "SYS_MAX_ID", "T_DESIGNKIND", "T_EDITTASK_ZT", "T_EDITTASK_ZT", "T_LOG", "T_STAT_REPORT", "T_SYS_FLOW_AUTHOR", "T_SYS_FLOW_DEPT", "T_SYS_FLOW_USER", "T_SYS_LD_ADMIN_CODES", "T_SYS_META_CODE", "T_SYS_META_CODEINDEX", "T_SYS_META_FIELDS", "T_SYS_META_GMLSZHB", "T_SYS_META_GROWTHMODEL", "T_SYS_META_GYLQW",
                    "T_SYS_META_HSLSZHB", "T_SYS_META_JJLCQ", "T_SYS_META_JJLSZHB", "T_SYS_META_LDZZBCBZB", "T_SYS_META_LJLZ", "T_SYS_META_QMLSZHB", "T_SYS_META_SLSZHB", "T_SYS_META_TABLE", "T_SYS_META_XJLJSSZHB", "T_SYS_META_YCLSZHB", "T_SYS_USER_AUTHOR"
                });
            }
            else if (str.Contains("FQSJ"))
            {
                this.checkEdit_deleteIndex.Checked = false;
                this.checkEdit_deleteIndex.Enabled = false;
                this.codes.Add("T_SYS_META_CODE");
                this.ids.AddRange(new string[] { "SYS_MAX_ID", "T_DESIGNKIND", "T_EDITTASK_ZT", "T_EDITTASK_ZT", "T_LOG", "T_STAT_REPORT", "T_SYS_FLOW_AUTHOR", "T_SYS_FLOW_DEPT", "T_SYS_FLOW_USER", "T_SYS_META_CODE", "T_SYS_USER_AUTHOR" });
            }
            else if (str.Contains("ZZYXM"))
            {
                this.checkEdit_deleteIndex.Checked = false;
                this.checkEdit_deleteIndex.Enabled = false;
                this.codes.Add("T_SYS_META_CODE");
                this.ids.AddRange(new string[] { "SYS_MAX_ID", "T_DESIGNKIND", "T_EDITTASK_ZT", "T_EDITTASK_ZT", "T_LOG", "T_SYS_FLOW_AUTHOR", "T_SYS_FLOW_DEPT", "T_SYS_FLOW_USER", "T_SYS_META_CODE", "T_SYS_USER_AUTHOR" });
            }
        }

        private void DeleteMapIndex(Server pServer)
        {
            pServer.Databases[this.comboBoxEdit_database.Text].ExecuteNonQuery(Resources.DELE_INDX);
        }

        private void DeleteObjectID(Server pServer, string pDbName, List<string> pTables)
        {
            Database database = pServer.Databases[pDbName];
            foreach (string str in pTables)
            {
                Table table = database.Tables[str];
                if (table != null)
                {
                    IndexCollection indexes = table.Indexes;
                    int count = indexes.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Index index = null;
                        index = indexes[i];
                        if ((index != null) && index.Name.Contains("SDE_ROWID"))
                        {
                            index.Drop();
                        }
                    }
                    Column column = table.Columns["OBJECTID"];
                    if (column != null)
                    {
                        column.Drop();
                    }
                }
            }
        }

        private void DeleteOverData(Server pServer, string pCode, List<string> pTables)
        {
            string str = pCode.Substring(0, 4);
            foreach (string str2 in pTables)
            {
                string sqlCommand = "delete from " + str2 + " where (ccode!='" + str + "' and len(ccode)=4 and ctype='市') or (ccode not like '%" + pCode + "%' and len(ccode)>=6 and CTYPE IN('县','乡','村'))";
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
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

        private void InitializeComponent()
        {
            this.checkEdit_deleteCode = new CheckEdit();
            this.checkEdit_deleteIndex = new CheckEdit();
            this.checkEdit_id = new CheckEdit();
            this.textEdit_xk = new TextEdit();
            this.labelControl_databases = new LabelControl();
            this.comboBoxEdit_database = new ComboBoxEdit();
            this.checkEdit_xk = new CheckEdit();
            this.textEdit_code = new TextEdit();
            this.sb_Skip = new SimpleButton();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.checkEdit_deleteCode.Properties.BeginInit();
            this.checkEdit_deleteIndex.Properties.BeginInit();
            this.checkEdit_id.Properties.BeginInit();
            this.textEdit_xk.Properties.BeginInit();
            this.comboBoxEdit_database.Properties.BeginInit();
            this.checkEdit_xk.Properties.BeginInit();
            this.textEdit_code.Properties.BeginInit();
            base.SuspendLayout();
            this.checkEdit_deleteCode.Location = new Point(0x12, 0x33);
            this.checkEdit_deleteCode.Name = "checkEdit_deleteCode";
            this.checkEdit_deleteCode.Properties.Caption = "删除冗余代码";
            this.checkEdit_deleteCode.Size = new Size(0x60, 0x13);
            this.checkEdit_deleteCode.TabIndex = 2;
            this.checkEdit_deleteCode.CheckedChanged += new EventHandler(this.checkEdit_deleteCode_CheckedChanged);
            this.checkEdit_deleteIndex.Location = new Point(0x12, 0x7c);
            this.checkEdit_deleteIndex.Name = "checkEdit_deleteIndex";
            this.checkEdit_deleteIndex.Properties.Caption = "删除冗余图幅索引";
            this.checkEdit_deleteIndex.Size = new Size(0x76, 0x13);
            this.checkEdit_deleteIndex.TabIndex = 4;
            this.checkEdit_id.Location = new Point(0x9b, 0x7c);
            this.checkEdit_id.Name = "checkEdit_id";
            this.checkEdit_id.Properties.Caption = "删除objectid";
            this.checkEdit_id.Size = new Size(0x68, 0x13);
            this.checkEdit_id.TabIndex = 5;
            this.textEdit_xk.EditValue = "";
            this.textEdit_xk.Enabled = false;
            this.textEdit_xk.Location = new Point(80, 0xc0);
            this.textEdit_xk.Name = "textEdit_xk";
            this.textEdit_xk.Size = new Size(400, 0x15);
            this.textEdit_xk.TabIndex = 7;
            this.labelControl_databases.Location = new Point(0x13, 0x11);
            this.labelControl_databases.Name = "labelControl_databases";
            this.labelControl_databases.Size = new Size(0x30, 14);
            this.labelControl_databases.TabIndex = 0x25;
            this.labelControl_databases.Text = "数据库：";
            this.comboBoxEdit_database.Location = new Point(80, 14);
            this.comboBoxEdit_database.Name = "comboBoxEdit_database";
            this.comboBoxEdit_database.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit_database.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_database.Size = new Size(0xc5, 0x15);
            this.comboBoxEdit_database.TabIndex = 1;
            this.comboBoxEdit_database.SelectedIndexChanged += new EventHandler(this.comboBoxEdit_database_SelectedIndexChanged);
            this.checkEdit_xk.Location = new Point(0x12, 0x9e);
            this.checkEdit_xk.Name = "checkEdit_xk";
            this.checkEdit_xk.Properties.Caption = "更新许可";
            this.checkEdit_xk.Size = new Size(0x60, 0x13);
            this.checkEdit_xk.TabIndex = 6;
            this.checkEdit_xk.CheckedChanged += new EventHandler(this.checkEdit_xk_CheckedChanged);
            this.textEdit_code.EditValue = "";
            this.textEdit_code.Enabled = false;
            this.textEdit_code.Location = new Point(80, 0x55);
            this.textEdit_code.Name = "textEdit_code";
            this.textEdit_code.Properties.Mask.BeepOnError = true;
            this.textEdit_code.Properties.Mask.EditMask = @"\d{6}";
            this.textEdit_code.Properties.Mask.IgnoreMaskBlank = false;
            this.textEdit_code.Properties.Mask.MaskType = MaskType.RegEx;
            this.textEdit_code.Properties.Mask.ShowPlaceHolders = false;
            this.textEdit_code.Properties.MaxLength = 6;
            this.textEdit_code.Size = new Size(0x18f, 0x15);
            this.textEdit_code.TabIndex = 3;
            this.textEdit_code.ToolTip = "输入6位县级代码，将删除与该县无关代码";
            this.sb_Skip.Location = new Point(0x198, 0xdb);
            this.sb_Skip.Name = "sb_Skip";
            this.sb_Skip.Size = new Size(0x4b, 0x17);
            this.sb_Skip.TabIndex = 8;
            this.sb_Skip.Text = "跳过";
            this.sb_Skip.Click += new EventHandler(this.simpleButton_run_Click);
            this.labelControl1.Location = new Point(0x13, 0x58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x30, 14);
            this.labelControl1.TabIndex = 0x2d;
            this.labelControl1.Text = "县代码：";
            this.labelControl2.Location = new Point(20, 0xc3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 0x2e;
            this.labelControl2.Text = "许可代码：";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            base.Appearance.GradientMode = LinearGradientMode.Vertical;
            base.Appearance.Options.UseBackColor = true;
            base.Appearance.Options.UseBorderColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.sb_Skip);
            base.Controls.Add(this.textEdit_code);
            base.Controls.Add(this.checkEdit_xk);
            base.Controls.Add(this.labelControl_databases);
            base.Controls.Add(this.comboBoxEdit_database);
            base.Controls.Add(this.textEdit_xk);
            base.Controls.Add(this.checkEdit_id);
            base.Controls.Add(this.checkEdit_deleteIndex);
            base.Controls.Add(this.checkEdit_deleteCode);
            this.LookAndFeel.SkinName = "Money Twins";
            base.Name = "UpdateDatabaseObject";
            base.Size = new Size(0x1ef, 0x107);
            this.checkEdit_deleteCode.Properties.EndInit();
            this.checkEdit_deleteIndex.Properties.EndInit();
            this.checkEdit_id.Properties.EndInit();
            this.textEdit_xk.Properties.EndInit();
            this.comboBoxEdit_database.Properties.EndInit();
            this.checkEdit_xk.Properties.EndInit();
            this.textEdit_code.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void LoadDatabases()
        {
            this.comboBoxEdit_database.Properties.Items.Clear();
            this._server = new Server(this._serverConnection);
            if (!this._serverConnection.IsOpen)
            {
                this._serverConnection.Connect();
            }
            foreach (Database database in this._server.Databases)
            {
                this.comboBoxEdit_database.Properties.Items.Add(database.Name);
            }
            this.comboBoxEdit_database.Text = "";
        }

        public bool Run()
        {
            try
            {
                if (string.IsNullOrEmpty(this.comboBoxEdit_database.Text))
                {
                    XtraMessageBox.Show("请选择数据库！");
                    return false;
                }
                if (this.checkEdit_deleteCode.Checked)
                {
                    if (string.IsNullOrEmpty(this.textEdit_code.Text))
                    {
                        XtraMessageBox.Show("请填写代码！");
                        return false;
                    }
                    this.DeleteOverData(this._server, this.textEdit_code.Text, this.codes);
                }
                if (this.checkEdit_deleteIndex.Checked)
                {
                    this.DeleteMapIndex(this._server);
                }
                if (this.checkEdit_xk.Checked)
                {
                    if (string.IsNullOrEmpty(this.textEdit_xk.Text))
                    {
                        XtraMessageBox.Show("请填写许可信息！");
                        return false;
                    }
                    this._server.ConnectionContext.ExecuteNonQuery("update SDE_server_config set char_prop_value='" + this.textEdit_xk.Text + "' where prop_name='AUTH_KEY'");
                }
                if (this.checkEdit_id.Checked)
                {
                    this.DeleteObjectID(this._server, this.comboBoxEdit_database.Text, this.ids);
                }
                this._serverConnection.Disconnect();
                XtraMessageBox.Show("更新成功！");
            }
            catch
            {
                if (this._serverConnection.IsOpen)
                {
                    this._serverConnection.Disconnect();
                }
                XtraMessageBox.Show("更新失败！");
                return false;
            }
            return true;
        }

        private void simpleButton_run_Click(object sender, EventArgs e)
        {
            if (this.SkipEvent != null)
            {
                this.SkipEvent();
            }
        }

        public Microsoft.SqlServer.Management.Common.ServerConnection ServerConnection
        {
            set
            {
                this._serverConnection = value;
            }
        }

        public delegate void Skip();
    }
}

