namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using FormBase;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks.Properties;
    using GDB.SQLServerExpress.vTasks.vForms;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Types;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class CreateNewGDB : UserControlBase1
    {
        private ForestGDBInfo _forestGDBInfo;
        private string _path;
        private Microsoft.SqlServer.Management.Common.ServerConnection _serverConnection;
        private ButtonEdit bntEdit_dataDir;
        private IContainer components;
        private DefaultLookAndFeel defaultLookAndFeel1;
        private LabelControl labelControl1;
        private LabelControl lb_code;
        private LabelControl lb_Year;
        private LabelControl lc_createuser;
        private LabelControl lcEmpty;
        public Form ParentForm;
        private RadioGroup radioGroup1;
        private SimpleButton sb_Skip;
        private TextBox tb_CreateUser;
        private TextBox tbEmpty;
        private TextEdit textEdit1;
        private TextEdit txt_Code;
        private TextEdit txt_Year;

        public event Skip SkipEvent;

        public CreateNewGDB()
        {
            this.InitializeComponent();
            txt_Code.Text = "142326";
            txt_Year.Text = "2016";
            tb_CreateUser.Text = "sde";
            bntEdit_dataDir.Text = @"E:\DBFiles\";
        }

        private void bntEdit_dataDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ServerDirectory directory = new ServerDirectory();
            directory.Init(this._serverConnection, false, false);
            if (directory.ShowDialog() == DialogResult.OK)
            {
                this.bntEdit_dataDir.Text = directory.Path;
                this.bntEdit_dataDir.ForeColor = Color.Black;
            }
        }

        private void CompressDatabase(Server pServer, string pDbName, string pPath)
        {
            this._serverConnection.Connect();
            string path = this.bntEdit_dataDir.Text + pDbName + ".ldf";
            string str2 = this.bntEdit_dataDir.Text + pDbName + ".mdf";
            pServer.KillAllProcesses(pDbName);
            pServer.DetachDatabase(pDbName, false);
            System.IO.File.Delete(path);
            StringCollection files = new StringCollection {
                str2
            };
            pServer.AttachDatabase(pDbName, files);
            this._serverConnection.Disconnect();
        }

        private bool CreateDatabase()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = baseDirectory.Remove(baseDirectory.LastIndexOf("bin"));
            string newValue = null;
            string sqlCommand = null;
            string str4 = null;
            string text = this.txt_Code.Text;
            string s = this.txt_Year.Text;
            Server pServer = new Server(this._serverConnection);
            if (this.radioGroup1.SelectedIndex == 0)
            {
                int num = int.Parse(s) - 1;
                str4 = text + "_" + s;
                newValue = "FORDATA_" + str4;
                baseDirectory = baseDirectory + @"Template\FORDATA\";
                using (StreamReader reader = new StreamReader(baseDirectory + "Database.db", Encoding.Default))
                {
                    sqlCommand = reader.ReadToEnd();
                }
                sqlCommand = sqlCommand.Replace("{1}", str4).Replace("{0}", this.bntEdit_dataDir.Text).Replace("{2}", s).Replace("{3}", num.ToString());
            }
            else if (this.radioGroup1.SelectedIndex == 1)
            {
                baseDirectory = baseDirectory + @"Template\FQSJ\";
                newValue = "FQSJ";
                using (StreamReader reader2 = new StreamReader(baseDirectory + "Database.db"))
                {
                    sqlCommand = reader2.ReadToEnd();
                }
                sqlCommand = sqlCommand.Replace("{1}", s).Replace("{0}", this.bntEdit_dataDir.Text);
            }
            else if (this.radioGroup1.SelectedIndex == 2)
            {
                int num2 = int.Parse(s) - 1;
                baseDirectory = baseDirectory + @"Template\ZZYXM\";
                newValue = "ZZYXM";
                using (StreamReader reader3 = new StreamReader(baseDirectory + "Database.db"))
                {
                    sqlCommand = reader3.ReadToEnd();
                }
                sqlCommand = sqlCommand.Replace("{1}", s).Replace("{0}", this.bntEdit_dataDir.Text).Replace("{2}", num2.ToString());
            }
            else
            {
                baseDirectory = baseDirectory + @"Template\EMPTY\";
                newValue = this.tbEmpty.Text;
                using (StreamReader reader4 = new StreamReader(baseDirectory + "Database.db"))
                {
                    sqlCommand = reader4.ReadToEnd();
                }
                sqlCommand = sqlCommand.Replace("{1}", this.bntEdit_dataDir.Text).Replace("{0}", newValue);
            }
            WaitDialog dialog = null;
            try
            {
                string str7 = "select count(*) from dbo.sysdatabases where name='" + newValue + "'";
                if (!this._serverConnection.IsOpen)
                {
                    this._serverConnection.Connect();
                }
                object obj2 = pServer.ConnectionContext.ExecuteScalar(str7);
                dialog = new WaitDialog {
                    Owner = this.ParentForm
                };
                dialog.Show();
                Application.DoEvents();
                if (obj2.ToString() == "0")
                {
                    dialog.SetProgress("正在创建数据库...");
                    pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
                }
                else
                {
                    XtraMessageBox.Show("数据库已存在！");
                    dialog.Close();
                    return true;
                }
                bool flag = Dns.GetHostName().ToUpper() != pServer.NetName.ToUpper();
                pServer.ConnectionContext.BeginTransaction();
                dialog.SetProgress("正在加载元数据...");
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    if (!flag)
                    {
                        this.LoadFORDATAMetaData(pServer, baseDirectory + "Local", str4, newValue);
                    }
                    else
                    {
                        this.LoadFORDATAMetaData(baseDirectory + "Server", str4, newValue);
                    }
                    dialog.SetProgress("正在删除域...");
                    this.DeleteDomain(pServer, newValue, text);
                    dialog.SetProgress("正在删除冗余数据...");
                    this.DeleteOverData(pServer, text, new string[] { "T_SYS_LD_ADMIN_CODES", "T_SYS_META_CODE" });
                    this.UpdateUser(pServer, this.tb_CreateUser.Text);
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    if (!flag)
                    {
                        this.LoadFQSJMetaData(pServer, baseDirectory + "Local", s);
                    }
                    else
                    {
                        this.LoadFQSJMetaData(baseDirectory + "Server", newValue, s);
                    }
                }
                else if (this.radioGroup1.SelectedIndex == 2)
                {
                    if (!flag)
                    {
                        this.LoadZZYMetaData(pServer, baseDirectory + "Local", s);
                    }
                    else
                    {
                        this.LoadZZYMetaData(baseDirectory + "Server", newValue, s);
                    }
                }
                else if (!flag)
                {
                    this.LoadEmptyMetaData(pServer, baseDirectory, newValue);
                }
                else
                {
                    this.LoadEmptyMetaData(baseDirectory, newValue);
                }
                pServer.ConnectionContext.CommitTransaction();
                this._serverConnection.Disconnect();
                if (!flag)
                {
                    dialog.SetProgress("压缩数据库");
                    this.CompressDatabase(pServer, newValue, baseDirectory);
                }
                dialog.SetProgress("完成");
                dialog.Close();
                XtraMessageBox.Show("数据库创建成功！");
            }
            catch (Exception exception)
            {
                if (dialog != null)
                {
                    dialog.SetProgress("正在回退数据...");
                }
                pServer.ConnectionContext.RollBackTransaction();
                if (this._serverConnection.IsOpen)
                {
                    this._serverConnection.Disconnect();
                }
                if (dialog != null)
                {
                    dialog.Close();
                    dialog.Dispose();
                }
                XtraMessageBox.Show("数据库创建失败：" + exception.Message);
                return false;
            }
            return true;
        }

        private void CreateView(Server pServer, string pYear)
        {
            string sqlCommand = string.Format(Resources.CREATE_VIEW, pYear);
            pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
        }

        private void DeleteDomain(Server pServer, string pDbName, string pCode)
        {
            Database database = pServer.Databases[pDbName];
            string str = pCode.Substring(0, 4);
            string str2 = pCode + "001";
            string str3 = str2 + "001";
            string str4 = ((int.Parse(pCode) + 1)).ToString() + "001";
            string str5 = str4 + "001";
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code!=" + str + "])') where Name='SHI'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code!=" + pCode + "])') where Name='XIAN'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code<" + str2 + " or Code>=" + str4 + "])') where Name='XIANG'");
            database.ExecuteNonQuery("update GDB_ITEMS set [Definition].modify('delete (//CodedValue[Code<" + str3 + " or Code>=" + str5 + "])') where Name='CUN'");
        }

        private void DeleteObjectID(Server pServer, string pDbName, string[] pTables)
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
                        Microsoft.SqlServer.Management.Smo.Index index = null;
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

        private void DeleteOverData(Server pServer, string pCode, string[] pTables)
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

        public string GetDataBaseName()
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                return ("fordata_" + this.txt_Code.Text + "_" + this.txt_Year.Text);
            }
            return "fqsj";
        }

        private void InitializeComponent()
        {
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.bntEdit_dataDir = new DevExpress.XtraEditors.ButtonEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lb_code = new DevExpress.XtraEditors.LabelControl();
            this.txt_Code = new DevExpress.XtraEditors.TextEdit();
            this.lb_Year = new DevExpress.XtraEditors.LabelControl();
            this.txt_Year = new DevExpress.XtraEditors.TextEdit();
            this.sb_Skip = new DevExpress.XtraEditors.SimpleButton();
            this.lcEmpty = new DevExpress.XtraEditors.LabelControl();
            this.tbEmpty = new System.Windows.Forms.TextBox();
            this.tb_CreateUser = new System.Windows.Forms.TextBox();
            this.lc_createuser = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Year.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(0, 0);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // bntEdit_dataDir
            // 
            this.bntEdit_dataDir.EditValue = "";
            this.bntEdit_dataDir.Location = new System.Drawing.Point(15, 144);
            this.bntEdit_dataDir.Name = "bntEdit_dataDir";
            this.bntEdit_dataDir.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bntEdit_dataDir.Properties.Appearance.Options.UseForeColor = true;
            this.bntEdit_dataDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bntEdit_dataDir.Size = new System.Drawing.Size(399, 20);
            this.bntEdit_dataDir.TabIndex = 4;
            this.bntEdit_dataDir.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bntEdit_dataDir_ButtonClick);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(15, 10);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Columns = 4;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "资源管理"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "伐区设计"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "征占用"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "空数据库")});
            this.radioGroup1.Size = new System.Drawing.Size(399, 53);
            this.radioGroup1.TabIndex = 1;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 119);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "数据库存放路径：";
            // 
            // lb_code
            // 
            this.lb_code.Location = new System.Drawing.Point(15, 89);
            this.lb_code.Name = "lb_code";
            this.lb_code.Size = new System.Drawing.Size(36, 14);
            this.lb_code.TabIndex = 14;
            this.lb_code.Text = "代码：";
            // 
            // txt_Code
            // 
            this.txt_Code.EditValue = "";
            this.txt_Code.Location = new System.Drawing.Point(54, 86);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Properties.Mask.BeepOnError = true;
            this.txt_Code.Properties.Mask.EditMask = "\\d{6}";
            this.txt_Code.Properties.Mask.IgnoreMaskBlank = false;
            this.txt_Code.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Code.Properties.Mask.ShowPlaceHolders = false;
            this.txt_Code.Properties.MaxLength = 6;
            this.txt_Code.Size = new System.Drawing.Size(130, 20);
            this.txt_Code.TabIndex = 2;
            // 
            // lb_Year
            // 
            this.lb_Year.Location = new System.Drawing.Point(203, 89);
            this.lb_Year.Name = "lb_Year";
            this.lb_Year.Size = new System.Drawing.Size(36, 14);
            this.lb_Year.TabIndex = 32;
            this.lb_Year.Text = "年份：";
            // 
            // txt_Year
            // 
            this.txt_Year.EditValue = "";
            this.txt_Year.Location = new System.Drawing.Point(245, 86);
            this.txt_Year.Name = "txt_Year";
            this.txt_Year.Properties.Mask.BeepOnError = true;
            this.txt_Year.Properties.Mask.EditMask = "[0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3}";
            this.txt_Year.Properties.Mask.IgnoreMaskBlank = false;
            this.txt_Year.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Year.Properties.Mask.ShowPlaceHolders = false;
            this.txt_Year.Size = new System.Drawing.Size(130, 20);
            this.txt_Year.TabIndex = 3;
            // 
            // sb_Skip
            // 
            this.sb_Skip.Location = new System.Drawing.Point(444, 200);
            this.sb_Skip.Name = "sb_Skip";
            this.sb_Skip.Size = new System.Drawing.Size(75, 23);
            this.sb_Skip.TabIndex = 5;
            this.sb_Skip.Text = "跳过";
            this.sb_Skip.Click += new System.EventHandler(this.sb_Skip_Click);
            // 
            // lcEmpty
            // 
            this.lcEmpty.Location = new System.Drawing.Point(15, 89);
            this.lcEmpty.Name = "lcEmpty";
            this.lcEmpty.Size = new System.Drawing.Size(36, 14);
            this.lcEmpty.TabIndex = 33;
            this.lcEmpty.Text = "名字：";
            this.lcEmpty.Visible = false;
            // 
            // tbEmpty
            // 
            this.tbEmpty.Location = new System.Drawing.Point(54, 86);
            this.tbEmpty.Name = "tbEmpty";
            this.tbEmpty.Size = new System.Drawing.Size(360, 22);
            this.tbEmpty.TabIndex = 34;
            this.tbEmpty.Visible = false;
            // 
            // tb_CreateUser
            // 
            this.tb_CreateUser.Location = new System.Drawing.Point(15, 201);
            this.tb_CreateUser.Name = "tb_CreateUser";
            this.tb_CreateUser.Size = new System.Drawing.Size(399, 22);
            this.tb_CreateUser.TabIndex = 38;
            // 
            // lc_createuser
            // 
            this.lc_createuser.Location = new System.Drawing.Point(15, 173);
            this.lc_createuser.Name = "lc_createuser";
            this.lc_createuser.Size = new System.Drawing.Size(72, 14);
            this.lc_createuser.TabIndex = 37;
            this.lc_createuser.Text = "创建用户名：";
            // 
            // CreateNewGDB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Controls.Add(this.tb_CreateUser);
            this.Controls.Add(this.lc_createuser);
            this.Controls.Add(this.tbEmpty);
            this.Controls.Add(this.lcEmpty);
            this.Controls.Add(this.sb_Skip);
            this.Controls.Add(this.txt_Year);
            this.Controls.Add(this.lb_Year);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.bntEdit_dataDir);
            this.Controls.Add(this.txt_Code);
            this.Controls.Add(this.lb_code);
            this.Name = "CreateNewGDB";
            this.Size = new System.Drawing.Size(533, 239);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntEdit_dataDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Year.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadEmptyMetaData(string pPath, string pDataBaseName)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers";
            SqlConnection pConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[] { this._serverConnection.ServerInstance, pDataBaseName, this._serverConnection.TrueLogin, this._serverConnection.Password }));
            SqlTransaction pTransaction = null;
            try
            {
                pConnection.Open();
                pTransaction = pConnection.BeginTransaction();
                foreach (FileInfo info2 in files)
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                    if (str.Contains(fileNameWithoutExtension))
                    {
                        string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + ".txt";
                        using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                        {
                            string contents = reader.ReadToEnd().Replace("{0}", pDataBaseName);
                            System.IO.File.WriteAllText(path, contents, Encoding.Default);
                        }
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", path, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                    else
                    {
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", info2.FullName, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                }
                pTransaction.Commit();
                pConnection.Close();
            }
            catch
            {
                if (pConnection.State != ConnectionState.Closed)
                {
                    pConnection.Close();
                }
                throw;
            }
        }

        private void LoadEmptyMetaData(Server pServer, string pPath, string pDbName)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers";
            string sqlCommand = null;
            foreach (FileInfo info2 in files)
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                if (str.Contains(fileNameWithoutExtension))
                {
                    string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + ".txt";
                    using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                    {
                        string contents = reader.ReadToEnd().Replace("{0}", pDbName);
                        System.IO.File.WriteAllText(path, contents, Encoding.Default);
                    }
                    sqlCommand = "Bulk insert [" + pDbName + "].[dbo].[" + fileNameWithoutExtension + "] from '" + path + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                else
                {
                    sqlCommand = "Bulk insert [" + pDbName + "].[dbo].[" + fileNameWithoutExtension + "] from '" + info2.FullName + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        private void LoadFORDATAMetaData(string pPath, string pExtendInfo, string pDataBaseName)
        {
            string s = pExtendInfo.Substring(pExtendInfo.Length - 4, 4);
            string newValue = (int.Parse(s) - 1).ToString();
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str3 = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,SDE_raster_columns,T_SYS_META_TABLE,SDE_process_information";
            SqlConnection pConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[] { this._serverConnection.ServerInstance, pDataBaseName, this._serverConnection.TrueLogin, this._serverConnection.Password }));
            SqlTransaction pTransaction = null;
            try
            {
                pConnection.Open();
                pTransaction = pConnection.BeginTransaction();
                foreach (FileInfo info2 in files)
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                    if (str3.Contains(fileNameWithoutExtension))
                    {
                        string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pExtendInfo + ".txt";
                        using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                        {
                            string contents = reader.ReadToEnd().Replace("{1}", pExtendInfo).Replace("{2}", s).Replace("{3}", newValue);
                            System.IO.File.WriteAllText(path, contents, Encoding.Default);
                        }
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", path, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                    else
                    {
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", info2.FullName, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                }
                pTransaction.Commit();
                pConnection.Close();
            }
            catch
            {
                if (pConnection.State != ConnectionState.Closed)
                {
                    pConnection.Close();
                }
                throw;
            }
        }

        private void LoadFORDATAMetaData(Server pServer, string pPath, string pExtendInfo, string pDataBaseName)
        {
            string s = pExtendInfo.Substring(pExtendInfo.Length - 4, 4);
            string newValue = (int.Parse(s) - 1).ToString();
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str3 = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,SDE_raster_columns,T_SYS_META_TABLE,SDE_process_information";
            string sqlCommand = null;
            foreach (FileInfo info2 in files)
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                if (str3.Contains(fileNameWithoutExtension))
                {
                    string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pExtendInfo + ".txt";
                    using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                    {
                        string contents = reader.ReadToEnd().Replace("{1}", pExtendInfo).Replace("{2}", s).Replace("{3}", newValue);
                        System.IO.File.WriteAllText(path, contents, Encoding.Default);
                    }
                    sqlCommand = string.Format("Bulk insert {0}.[dbo].[" + fileNameWithoutExtension + "] from '" + path + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml') ", pDataBaseName);
                }
                else
                {
                    sqlCommand = string.Format("Bulk insert {0}.[dbo].[" + fileNameWithoutExtension + "] from '" + info2.FullName + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')", pDataBaseName);
                }
                System.IO.File.AppendAllText(@"d:\ERROR.TXT", sqlCommand + Environment.NewLine);
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        private void LoadFQSJMetaData(Server pServer, string pPath, string pYear)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,T_SYS_META_TABLE";
            string sqlCommand = null;
            foreach (FileInfo info2 in files)
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                if (str.Contains(fileNameWithoutExtension))
                {
                    string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pYear + ".txt";
                    using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                    {
                        string contents = reader.ReadToEnd().Replace("{2}", pYear);
                        System.IO.File.WriteAllText(path, contents, Encoding.Default);
                    }
                    sqlCommand = "Bulk insert [FQSJ].[dbo].[" + fileNameWithoutExtension + "] from '" + path + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                else
                {
                    sqlCommand = "Bulk insert [FQSJ].[dbo].[" + fileNameWithoutExtension + "] from '" + info2.FullName + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        private void LoadFQSJMetaData(string pPath, string pDataBaseName, string pYear)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers,T_SYS_META_TABLE";
            SqlConnection pConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[] { this._serverConnection.ServerInstance, pDataBaseName, this._serverConnection.TrueLogin, this._serverConnection.Password }));
            SqlTransaction pTransaction = null;
            try
            {
                pConnection.Open();
                pTransaction = pConnection.BeginTransaction();
                foreach (FileInfo info2 in files)
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                    if (str.Contains(fileNameWithoutExtension))
                    {
                        string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pYear + ".txt";
                        using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                        {
                            string contents = reader.ReadToEnd().Replace("{2}", pYear);
                            System.IO.File.WriteAllText(path, contents, Encoding.Default);
                        }
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", path, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                    else
                    {
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", info2.FullName, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                }
                pTransaction.Commit();
                pConnection.Close();
            }
            catch
            {
                if (pConnection.State != ConnectionState.Closed)
                {
                    pConnection.Close();
                }
                throw;
            }
        }

        private void LoadZZYMetaData(Server pServer, string pPath, string pYear)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers";
            string sqlCommand = null;
            foreach (FileInfo info2 in files)
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                if (str.Contains(fileNameWithoutExtension))
                {
                    string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pYear + ".txt";
                    using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                    {
                        int num2 = int.Parse(pYear) - 1;
                        string contents = reader.ReadToEnd().Replace("{1}", pYear).Replace("{2}", num2.ToString());
                        System.IO.File.WriteAllText(path, contents, Encoding.Default);
                    }
                    sqlCommand = "Bulk insert [ZZYXM].[dbo].[" + fileNameWithoutExtension + "] from '" + path + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                else
                {
                    sqlCommand = "Bulk insert [ZZYXM].[dbo].[" + fileNameWithoutExtension + "] from '" + info2.FullName + "' with(formatfile = '" + System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml')";
                }
                pServer.ConnectionContext.ExecuteNonQuery(sqlCommand);
            }
        }

        private void LoadZZYMetaData(string pPath, string pDataBaseName, string pYear)
        {
            DirectoryInfo info = new DirectoryInfo(pPath);
            FileInfo[] files = info.GetFiles("*.txt");
            string str = "GDB_ITEMS,SDE_column_registry,SDE_geometry_columns,SDE_table_registry,SDE_layers";
            SqlConnection pConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", new object[] { this._serverConnection.ServerInstance, pDataBaseName, this._serverConnection.TrueLogin, this._serverConnection.Password }));
            SqlTransaction pTransaction = null;
            try
            {
                pConnection.Open();
                pTransaction = pConnection.BeginTransaction();
                foreach (FileInfo info2 in files)
                {
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(info2.Name);
                    if (str.Contains(fileNameWithoutExtension))
                    {
                        string path = info.FullName + @"\Temp\" + fileNameWithoutExtension + "_" + pYear + ".txt";
                        using (StreamReader reader = new StreamReader(info2.FullName, Encoding.Default))
                        {
                            int num2 = int.Parse(pYear) - 1;
                            string contents = reader.ReadToEnd().Replace("{1}", pYear).Replace("{2}", num2.ToString());
                            System.IO.File.WriteAllText(path, contents, Encoding.Default);
                        }
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", path, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                    else
                    {
                        this.WriteToServer(System.IO.Path.GetDirectoryName(info2.FullName) + @"\" + fileNameWithoutExtension + ".xml", info2.FullName, fileNameWithoutExtension, pConnection, pTransaction);
                    }
                }
                pTransaction.Commit();
                pConnection.Close();
            }
            catch
            {
                if (pConnection.State != ConnectionState.Closed)
                {
                    pConnection.Close();
                }
                throw;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.txt_Code.Visible = true;
                this.txt_Year.Visible = true;
                this.lb_code.Visible = true;
                this.lb_Year.Visible = true;
                this.txt_Code.Enabled = true;
                this.txt_Code.Text = "";
                this.lcEmpty.Visible = false;
                this.tbEmpty.Visible = false;
            }
            else if ((this.radioGroup1.SelectedIndex == 1) || (this.radioGroup1.SelectedIndex == 2))
            {
                this.txt_Code.Visible = true;
                this.txt_Year.Visible = true;
                this.lb_code.Visible = true;
                this.lb_Year.Visible = true;
                this.txt_Code.Enabled = false;
                this.txt_Code.Text = "";
                this.lcEmpty.Visible = false;
                this.tbEmpty.Visible = false;
            }
            else
            {
                this.txt_Code.Visible = false;
                this.txt_Year.Visible = false;
                this.lb_code.Visible = false;
                this.lb_Year.Visible = false;
                this.lcEmpty.Visible = true;
                this.tbEmpty.Visible = true;
            }
        }

        public bool Run()
        {
            if (this.radioGroup1.SelectedIndex != 3)
            {
                if (this.txt_Code.Enabled && string.IsNullOrEmpty(this.txt_Code.Text))
                {
                    XtraMessageBox.Show("请填写行政代码！");
                    return false;
                }
                if (string.IsNullOrEmpty(this.txt_Year.Text))
                {
                    XtraMessageBox.Show("请填写年份！");
                    return false;
                }
            }
            else if (string.IsNullOrEmpty(this.tbEmpty.Text))
            {
                XtraMessageBox.Show("请填写数据库名字！");
                return false;
            }
            if (string.IsNullOrEmpty(this.bntEdit_dataDir.Text))
            {
                XtraMessageBox.Show("请填写数据库存放路径！");
                return false;
            }
            if (string.IsNullOrEmpty(this.tb_CreateUser.Text))
            {
                XtraMessageBox.Show("请填写数据库存创建用户名！");
                return false;
            }
            return this.CreateDatabase();
        }

        private void sb_Skip_Click(object sender, EventArgs e)
        {
            if (this.SkipEvent != null)
            {
                this.SkipEvent();
            }
        }

        private void UpdateUser(Server pServer, string pCreateUser)
        {
            pServer.ConnectionContext.ExecuteNonQuery("UPDATE T_SYS_DB_INFO SET V_VALUE='" + pCreateUser + "' WHERE V_ITEM='PRODUCER'");
            pServer.ConnectionContext.ExecuteNonQuery("UPDATE T_SYS_DB_INFO SET V_VALUE='" + DateTime.Now.ToString("yyyyMMdd") + "' WHERE V_ITEM='PRDATE'");
        }

        private void WriteToServer(string pFormatFile, string pDataFile, string pTablename, SqlConnection pConnection, SqlTransaction pTransaction)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pFormatFile);
            string str = document.GetElementsByTagName("FIELD").Item(0).Attributes["TERMINATOR"].Value;
            DataTable table = new DataTable();
            IEnumerator enumerator = document.GetElementsByTagName("COLUMN").GetEnumerator();
            enumerator.Reset();
            int num = -1;
            int num2 = -1;
            while (enumerator.MoveNext())
            {
                XmlNode current = enumerator.Current as XmlNode;
                string columnName = current.Attributes["NAME"].Value;
                string str3 = current.Attributes["xsi:type"].Value;
                DataColumn column = new DataColumn(columnName);
                num++;
                switch (str3)
                {
                    case "SQLINT":
                        column.DataType = typeof(int);
                        break;

                    case "SQLSMALLINT":
                        column.DataType = typeof(short);
                        break;

                    case "SQLUNIQUEID":
                        column.DataType = typeof(Guid);
                        break;

                    case "SQLUDT":
                        column.DataType = typeof(SqlGeometry);
                        num2 = num;
                        break;

                    default:
                        column.DataType = typeof(string);
                        break;
                }
                table.Columns.Add(column);
            }
            using (StreamReader reader = new StreamReader(pDataFile, Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    string str4 = reader.ReadLine();
                    if (!string.IsNullOrEmpty(str4))
                    {
                        string[] strArray = str4.Split(str.ToCharArray());
                        DataRow row = table.NewRow();
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i] == "")
                            {
                                if ((table.Columns[i].DataType == typeof(short)) || (table.Columns[i].DataType == typeof(int)))
                                {
                                    row[i] = DBNull.Value;
                                }
                                else
                                {
                                    row[i] = null;
                                }
                            }
                            else if (i == num2)
                            {
                                SqlChars geometryTaggedText = new SqlChars(strArray[i].ToString());
                                row[i] = SqlGeometry.STGeomFromText(geometryTaggedText, 0x1202);
                            }
                            else
                            {
                                row[i] = strArray[i];
                            }
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            using (SqlBulkCopy copy = new SqlBulkCopy(pConnection, SqlBulkCopyOptions.KeepIdentity, pTransaction))
            {
                copy.BatchSize = table.Rows.Count;
                copy.BulkCopyTimeout = 60;
                copy.DestinationTableName = pTablename;
                copy.WriteToServer(table);
            }
        }

        public ForestGDBInfo ForestGdbInfo
        {
            set
            {
                this._forestGDBInfo = value;
            }
        }

        public string Path
        {
            set
            {
                this._path = value;
            }
        }

        public Microsoft.SqlServer.Management.Common.ServerConnection ServerConnection
        {
            get
            {
                return this._serverConnection;
            }
            set
            {
                this._serverConnection = value;
            }
        }

        public delegate void Skip();
    }
}

