namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.ADF;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.Properties;
    using GDB.SQLServerExpress.vTasks.vForms;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class InsertData : UserControlBase1
    {
        private Microsoft.SqlServer.Management.Common.ServerConnection _serverConnection;
        private string _sourceInstance;
        private CheckEdit checkEdit_PP;
        private ComboBoxEdit comboBoxEdit_database;
        private ComboBoxEdit comboBoxEdit_tDatabase;
        private IContainer components;
        private FileGeodatabase fileGeodatabase1;
        private GroupBox groupBox_source;
        private LabelControl labelControl_databases;
        private LabelControl labelControl1;
        private RadioGroup radioGroup_source;
        private SimpleButton simpleButton_run;
        private SqlServerDatabases sqlServerDatabases1;
        private WaitDialog wd;

        public event Skip SkipEvent;

        public InsertData()
        {
            this.InitializeComponent();
        }

        private void comboBoxEdit_database_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.sqlServerDatabases1.CheckConnection())
            {
                Microsoft.SqlServer.Management.Common.ServerConnection sqlServerConnection = this.sqlServerDatabases1.GeoMDFManager.SqlServerConnection;
                if (sqlServerConnection.ServerInstance.ToUpper() != this._sourceInstance)
                {
                    this._sourceInstance = sqlServerConnection.ServerInstance.ToUpper();
                    this.comboBoxEdit_database.Properties.Items.Clear();
                    Server server = new Server(sqlServerConnection);
                    foreach (Database database in server.Databases)
                    {
                        this.comboBoxEdit_database.Properties.Items.Add(database.Name);
                    }
                    this.comboBoxEdit_database.ShowPopup();
                }
            }
        }

        private void DeleteMapIndex()
        {
            this._serverConnection.Connect();
            Server server = new Server(this._serverConnection);
            server.Databases[this.comboBoxEdit_tDatabase.Text].ExecuteNonQuery(Resources.DELE_INDX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private IWorkspace GetTargetWorkspace(out string pPath)
        {
            IPropertySet connectionProperties = new PropertySetClass();
            string serverInstance = this._serverConnection.ServerInstance;
            connectionProperties.SetProperty("SERVER", serverInstance);
            connectionProperties.SetProperty("INSTANCE", "sde:sqlserver:" + serverInstance);
            connectionProperties.SetProperty("DATABASE", this.comboBoxEdit_tDatabase.Text);
            connectionProperties.SetProperty("USER", this._serverConnection.TrueLogin);
            connectionProperties.SetProperty("PASSWORD", this._serverConnection.Password);
            connectionProperties.SetProperty("VERSION", "dbo.DEFAULT");
            IWorkspaceFactory factory = new SdeWorkspaceFactoryClass();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            pPath = baseDirectory + "Target.sde";
            if (File.Exists(pPath))
            {
                File.Delete(pPath);
            }
            factory.Create(baseDirectory, "Target.sde", connectionProperties, 0);
            return factory.Open(connectionProperties, 0);
        }

        private void InitializeComponent()
        {
            this.groupBox_source = new GroupBox();
            this.radioGroup_source = new RadioGroup();
            this.simpleButton_run = new SimpleButton();
            this.labelControl_databases = new LabelControl();
            this.comboBoxEdit_database = new ComboBoxEdit();
            this.labelControl1 = new LabelControl();
            this.comboBoxEdit_tDatabase = new ComboBoxEdit();
            this.checkEdit_PP = new CheckEdit();
            this.fileGeodatabase1 = new FileGeodatabase();
            this.sqlServerDatabases1 = new SqlServerDatabases();
            this.groupBox_source.SuspendLayout();
            this.radioGroup_source.Properties.BeginInit();
            this.comboBoxEdit_database.Properties.BeginInit();
            this.comboBoxEdit_tDatabase.Properties.BeginInit();
            this.checkEdit_PP.Properties.BeginInit();
            base.SuspendLayout();
            this.groupBox_source.Controls.Add(this.radioGroup_source);
            this.groupBox_source.Location = new Point(13, -2);
            this.groupBox_source.Name = "groupBox_source";
            this.groupBox_source.Size = new Size(0x1bb, 0x41);
            this.groupBox_source.TabIndex = 0;
            this.groupBox_source.TabStop = false;
            this.groupBox_source.Text = "数据来源";
            this.radioGroup_source.Dock = DockStyle.Fill;
            this.radioGroup_source.Location = new Point(3, 0x12);
            this.radioGroup_source.Name = "radioGroup_source";
            this.radioGroup_source.Properties.Appearance.BackColor = Color.Transparent;
            this.radioGroup_source.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup_source.Properties.Columns = 2;
            this.radioGroup_source.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "Sqlserver"), new RadioGroupItem(null, "文件地理数据库") });
            this.radioGroup_source.Size = new Size(0x1b5, 0x2c);
            this.radioGroup_source.TabIndex = 1;
            this.radioGroup_source.ToolTip = "如果是文件地理数据库,该库只能位于本机上";
            this.radioGroup_source.SelectedIndexChanged += new EventHandler(this.radioGroup_source_SelectedIndexChanged);
            this.simpleButton_run.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.simpleButton_run.Location = new Point(0x17f, 0x129);
            this.simpleButton_run.Name = "simpleButton_run";
            this.simpleButton_run.Size = new Size(0x4f, 0x17);
            this.simpleButton_run.TabIndex = 6;
            this.simpleButton_run.Text = "跳过";
            this.simpleButton_run.Click += new EventHandler(this.simpleButton_run_Click);
            this.labelControl_databases.Location = new Point(0x4e, 0xde);
            this.labelControl_databases.Name = "labelControl_databases";
            this.labelControl_databases.Size = new Size(60, 14);
            this.labelControl_databases.TabIndex = 0x2b;
            this.labelControl_databases.Text = "源数据库：";
            this.comboBoxEdit_database.Location = new Point(0x90, 0xdf);
            this.comboBoxEdit_database.Name = "comboBoxEdit_database";
            this.comboBoxEdit_database.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit_database.Properties.ButtonClick += new ButtonPressedEventHandler(this.comboBoxEdit_database_Properties_ButtonClick);
            this.comboBoxEdit_database.Size = new Size(0xc5, 0x15);
            this.comboBoxEdit_database.TabIndex = 4;
            this.labelControl1.Location = new Point(0x42, 0x106);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x48, 14);
            this.labelControl1.TabIndex = 0x31;
            this.labelControl1.Text = "目标数据库：";
            this.comboBoxEdit_tDatabase.Location = new Point(0x90, 0x103);
            this.comboBoxEdit_tDatabase.Name = "comboBoxEdit_tDatabase";
            this.comboBoxEdit_tDatabase.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit_tDatabase.Size = new Size(0xc5, 0x15);
            this.comboBoxEdit_tDatabase.TabIndex = 5;
            this.checkEdit_PP.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.checkEdit_PP.Location = new Point(330, 0x12b);
            this.checkEdit_PP.Name = "checkEdit_PP";
            this.checkEdit_PP.Properties.Caption = "匹配";
            this.checkEdit_PP.Size = new Size(0x2f, 0x13);
            this.checkEdit_PP.TabIndex = 50;
            this.fileGeodatabase1.Appearance.BackColor = Color.FromArgb(0xb0, 0xcf, 0xf7);
            this.fileGeodatabase1.Appearance.BackColor2 = Color.White;
            this.fileGeodatabase1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.fileGeodatabase1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.fileGeodatabase1.Appearance.Options.UseBackColor = true;
            this.fileGeodatabase1.Appearance.Options.UseBorderColor = true;
            this.fileGeodatabase1.Location = new Point(0x10, 70);
            this.fileGeodatabase1.LookAndFeel.SkinName = "Money Twins";
            this.fileGeodatabase1.Name = "fileGeodatabase1";
            this.fileGeodatabase1.Size = new Size(0x1b5, 0xae);
            this.fileGeodatabase1.TabIndex = 2;
            this.fileGeodatabase1.Visible = false;
            this.sqlServerDatabases1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.sqlServerDatabases1.Appearance.BackColor2 = Color.White;
            this.sqlServerDatabases1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.sqlServerDatabases1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.sqlServerDatabases1.Appearance.Options.UseBackColor = true;
            this.sqlServerDatabases1.Appearance.Options.UseBorderColor = true;
            this.sqlServerDatabases1.Location = new Point(13, 70);
            this.sqlServerDatabases1.LookAndFeel.SkinName = "Money Twins";
            this.sqlServerDatabases1.Name = "sqlServerDatabases1";
            this.sqlServerDatabases1.Size = new Size(0x1ad, 0x98);
            this.sqlServerDatabases1.TabIndex = 3;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            base.Appearance.GradientMode = LinearGradientMode.Vertical;
            base.Appearance.Options.UseBackColor = true;
            base.Appearance.Options.UseBorderColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.checkEdit_PP);
            base.Controls.Add(this.fileGeodatabase1);
            base.Controls.Add(this.sqlServerDatabases1);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.comboBoxEdit_tDatabase);
            base.Controls.Add(this.labelControl_databases);
            base.Controls.Add(this.comboBoxEdit_database);
            base.Controls.Add(this.simpleButton_run);
            base.Controls.Add(this.groupBox_source);
            base.Name = "InsertData";
            base.Size = new Size(0x1d4, 0x144);
            this.groupBox_source.ResumeLayout(false);
            this.radioGroup_source.Properties.EndInit();
            this.comboBoxEdit_database.Properties.EndInit();
            this.comboBoxEdit_tDatabase.Properties.EndInit();
            this.checkEdit_PP.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private bool LoadData(IWorkspace pSourceWorkspace, IWorkspace pTargetWorkspace, string pSourcePath, string pTarPath)
        {
            IDataset dataset2;
            IWorkspace2 workspace = pTargetWorkspace as IWorkspace2;
            ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            Append process = new Append {
                schema_type = "NO_TEST"
            };
            IEnumDataset dataset = pSourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                IEnumDataset subsets = dataset2.Subsets;
                subsets.Reset();
                IDataset dataset4 = subsets.Next();
                while (dataset4 != null)
                {
                    if (dataset4.Name.ToUpper().Contains("INDEX_A_10K"))
                    {
                        dataset4 = subsets.Next();
                        continue;
                    }
                    if (!workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, dataset4.Name))
                    {
                        continue;
                    }
                    string str = dataset2.Name + @"\" + dataset4.Name;
                    process.inputs = pSourcePath + @"\" + str;
                    process.target = pTarPath + @"\" + str;
                    this.wd.SetProgress("正在导入" + dataset4.Name);
                    try
                    {
                        geoprocessor.Execute(process, null);
                    }
                    catch
                    {
                        for (int i = 0; i < geoprocessor.MessageCount; i++)
                        {
                            string message = geoprocessor.GetMessage(i);
                            if (message.Contains("ERROR"))
                            {
                                if (XtraMessageBox.Show("发生错误：" + message + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                                {
                                    goto Label_0151;
                                }
                                return false;
                            }
                        }
                    }
                Label_0151:
                    dataset4 = subsets.Next();
                }
            }
            Copy copy = new Copy();
            dataset = pSourceWorkspace.get_Datasets(esriDatasetType.esriDTRasterCatalog);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                string name = dataset2.Name;
                string str4 = name.Substring(name.LastIndexOf('\\') + 1);
                if (workspace.get_NameExists(esriDatasetType.esriDTRasterCatalog, str4))
                {
                    IFeatureWorkspace workspace2 = pTargetWorkspace as IFeatureWorkspace;
                    (workspace2.OpenTable(str4) as IDataset).Delete();
                    Marshal.ReleaseComObject(dataset2);
                }
                copy.in_data = pSourcePath + @"\" + name;
                copy.out_data = pTarPath + @"\" + name;
                this.wd.SetProgress("正在导入" + name);
                try
                {
                    geoprocessor.Execute(copy, null);
                }
                catch
                {
                    for (int j = 0; j < geoprocessor.MessageCount; j++)
                    {
                        string str5 = geoprocessor.GetMessage(j);
                        if (str5.Contains("ERROR"))
                        {
                            if (XtraMessageBox.Show("发生错误：" + str5 + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                            {
                                continue;
                            }
                            return false;
                        }
                    }
                }
            }
            Marshal.ReleaseComObject(pSourceWorkspace);
            Marshal.ReleaseComObject(pTargetWorkspace);
            XtraMessageBox.Show("数据导入完成！");
            if (this.comboBoxEdit_tDatabase.Text.ToUpper().Contains("FORDATA"))
            {
                this.DeleteMapIndex();
            }
            return true;
        }

        public void LoadDatabases()
        {
            this.comboBoxEdit_tDatabase.Properties.Items.Clear();
            if (!this._serverConnection.IsOpen)
            {
                this._serverConnection.Connect();
            }
            Server server = new Server(this._serverConnection);
            foreach (Database database in server.Databases)
            {
                this.comboBoxEdit_tDatabase.Properties.Items.Add(database.Name);
            }
            this._serverConnection.Disconnect();
            this.comboBoxEdit_tDatabase.Text = "";
            server = null;
        }

        private bool LoadDataCommon(IFeatureWorkspace pSF, IFeatureWorkspace pTF)
        {
            IDataset dataset = pTF as IDataset;
            IWorkspace2 workspace = pTF as IWorkspace2;
            IDatabaseConnectionInfo info = pTF as IDatabaseConnectionInfo;
            string text1 = info.ConnectedDatabase + "." + info.ConnectedUser + ".";
            IEnumDataset subsets = dataset.Subsets;
            subsets.Reset();
            for (IDataset dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
            {
                if (dataset3 is IRasterCatalog)
                {
                    IRasterCatalog catalog = dataset3 as IRasterCatalog;
                    if (!workspace.get_NameExists(esriDatasetType.esriDTRasterCatalog, dataset3.Name))
                    {
                        dataset3 = subsets.Next();
                        return false;
                    }
                    IFeatureClass pSfc = catalog as IFeatureClass;
                    IRasterWorkspaceEx ex = pTF as IRasterWorkspaceEx;
                    IFeatureClass pTfc = ex.OpenRasterCatalog(dataset3.Name) as IFeatureClass;
                    if (!this.LoadRasterDatasetCommon(pSfc, pTfc))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool LoadDataEx(IWorkspace pSourceWorkspace, IWorkspace pTargetWorkspace, string pSourcePath, string pTarPath, string pDatabaseName)
        {
            IDataset dataset2;
            IWorkspace2 workspace = pTargetWorkspace as IWorkspace2;
            ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            Append process = new Append();
            IEnumDataset dataset = pSourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                IEnumDataset subsets = dataset2.Subsets;
                subsets.Reset();
                IDataset dataset4 = subsets.Next();
                while (dataset4 != null)
                {
                    if (dataset4.Name.ToUpper().Contains("INDEX_A_10K"))
                    {
                        dataset4 = subsets.Next();
                        continue;
                    }
                    if (!workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, dataset4.Name))
                    {
                        continue;
                    }
                    string str = dataset2.Name + @"\" + dataset4.Name;
                    process.inputs = pSourcePath + @"\" + str;
                    string str2 = pDatabaseName + ".DBO.";
                    process.target = pTarPath + @"\" + str2 + dataset2.Name + @"\" + str2 + dataset4.Name;
                    process.schema_type = "NO_TEST";
                    this.wd.SetProgress("正在导入：" + dataset4.Name);
                    try
                    {
                        geoprocessor.Execute(process, null);
                    }
                    catch
                    {
                        for (int i = 0; i < geoprocessor.MessageCount; i++)
                        {
                            string message = geoprocessor.GetMessage(i);
                            if (message.Contains("ERROR"))
                            {
                                if (XtraMessageBox.Show("发生错误：" + message + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                                {
                                    goto Label_019A;
                                }
                                return false;
                            }
                        }
                    }
                Label_019A:
                    dataset4 = subsets.Next();
                }
            }
            Copy copy = new Copy();
            dataset = pSourceWorkspace.get_Datasets(esriDatasetType.esriDTRasterCatalog);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                string name = dataset2.Name;
                if (workspace.get_NameExists(esriDatasetType.esriDTRasterCatalog, name))
                {
                    IFeatureWorkspace workspace2 = pTargetWorkspace as IFeatureWorkspace;
                    (workspace2.OpenTable(name) as IDataset).Delete();
                    Marshal.ReleaseComObject(dataset2);
                }
                copy.in_data = pSourcePath + @"\" + name;
                copy.out_data = pTarPath + @"\" + name;
                this.wd.SetProgress("正在导入：" + name);
                try
                {
                    geoprocessor.Execute(copy, null);
                }
                catch
                {
                    for (int j = 0; j < geoprocessor.MessageCount; j++)
                    {
                        string str5 = geoprocessor.GetMessage(j);
                        if (str5.Contains("ERROR"))
                        {
                            if (XtraMessageBox.Show("发生错误：" + str5 + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                            {
                                continue;
                            }
                            return false;
                        }
                    }
                }
            }
            Marshal.ReleaseComObject(pSourceWorkspace);
            Marshal.ReleaseComObject(pTargetWorkspace);
            XtraMessageBox.Show("数据导入完成！");
            if (this.comboBoxEdit_tDatabase.Text.ToUpper().Contains("FORDATA"))
            {
                this.DeleteMapIndex();
            }
            return true;
        }

        private bool LoadDataPP(Dictionary<DataSetInfo, DataSetInfo> pPP)
        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            Append process = new Append();
            CopyRaster raster = new CopyRaster();
            foreach (KeyValuePair<DataSetInfo, DataSetInfo> pair in pPP)
            {
                int num = pair.Key.Path.LastIndexOf('\\');
                this.wd.SetProgress("正在导入：" + pair.Key.Path.Substring(num + 1));
                if (pair.Value.Type == esriDatasetType.esriDTFeatureClass)
                {
                    process.inputs = pair.Key.Path;
                    process.target = pair.Value.Path;
                    process.schema_type = "NO_TEST";
                    try
                    {
                        geoprocessor.Execute(process, null);
                    }
                    catch
                    {
                        for (int i = 0; i < geoprocessor.MessageCount; i++)
                        {
                            string message = geoprocessor.GetMessage(i);
                            if (message.Contains("ERROR"))
                            {
                                if (XtraMessageBox.Show("发生错误：" + message + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                                {
                                    continue;
                                }
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    raster.in_raster = pair.Key.Path;
                    raster.out_rasterdataset = pair.Value.Path;
                    raster.colormap_to_RGB = "ColormapToRGB";
                    try
                    {
                        geoprocessor.Execute(raster, null);
                    }
                    catch
                    {
                        for (int j = 0; j < geoprocessor.MessageCount; j++)
                        {
                            string str3 = geoprocessor.GetMessage(j);
                            if (str3.Contains("ERROR"))
                            {
                                if (XtraMessageBox.Show("发生错误：" + str3 + "，是否继续导入其他数据", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
                                {
                                    continue;
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            XtraMessageBox.Show("数据导入完成！");
            if (this.comboBoxEdit_tDatabase.Text.ToUpper().Contains("FORDATA"))
            {
                this.DeleteMapIndex();
            }
            return true;
        }

        private bool LoadFeatureClassCommon(IFeatureClass pSfc, IFeatureClass pTfc)
        {
            Dictionary<int, string> dictionary = this.MatchFields(pSfc, pTfc);
            try
            {
                using (ComReleaser releaser = new ComReleaser())
                {
                    IFeatureCursor o = pTfc.Insert(true);
                    releaser.ManageLifetime(o);
                    IFeatureBuffer buffer = pTfc.CreateFeatureBuffer();
                    releaser.ManageLifetime(buffer);
                    IFeatureCursor cursor2 = pSfc.Search(null, false);
                    for (IFeature feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                    {
                        foreach (KeyValuePair<int, string> pair in dictionary)
                        {
                            object obj2 = feature.get_Value(pair.Key);
                            int index = buffer.Fields.FindField(pair.Value);
                            buffer.set_Value(index, obj2);
                        }
                        o.InsertFeature(buffer);
                    }
                    o.Flush();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("数据导入遇到问题：" + exception.Message + "，请删除数据库重新生成！");
                return false;
            }
            return true;
        }

        private bool LoadRasterDatasetCommon(IFeatureClass pSfc, IFeatureClass pTfc)
        {
            try
            {
                using (ComReleaser releaser = new ComReleaser())
                {
                    IFeatureCursor o = pTfc.Insert(true);
                    releaser.ManageLifetime(o);
                    IFeatureBuffer buffer = pTfc.CreateFeatureBuffer();
                    releaser.ManageLifetime(buffer);
                    IFeatureCursor cursor2 = pSfc.Search(null, false);
                    for (IFeature feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                    {
                        for (int i = 0; i < buffer.Fields.FieldCount; i++)
                        {
                            object obj2 = feature.get_Value(i);
                            buffer.set_Value(i, obj2);
                        }
                        o.InsertFeature(buffer);
                    }
                    o.Flush();
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("数据导入遇到问题：" + exception.Message + "，请删除数据库重新生成！");
                return false;
            }
            return true;
        }

        private Dictionary<int, string> MatchFields(IFeatureClass pSfc, IFeatureClass pTfc)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            IFields fields = pSfc.Fields;
            IFields fields2 = pTfc.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                string name = field.Name;
                if (name != pSfc.OIDFieldName)
                {
                    int index = fields2.FindField(name);
                    if (index != -1)
                    {
                        IField field2 = fields2.get_Field(index);
                        if (field.Type == field2.Type)
                        {
                            dictionary.Add(i, name);
                        }
                    }
                }
            }
            return dictionary;
        }

        private void radioGroup_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup_source.SelectedIndex == 0)
            {
                this.fileGeodatabase1.Visible = false;
                this.sqlServerDatabases1.Visible = true;
            }
            else
            {
                this.fileGeodatabase1.Visible = true;
                this.sqlServerDatabases1.Visible = false;
                this.fileGeodatabase1.LoadDriver();
            }
        }

        public bool Run()
        {
            if (this.radioGroup_source.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(this.comboBoxEdit_database.Text))
                {
                    XtraMessageBox.Show("请选择源数据库！");
                    return false;
                }
            }
            else if (!this.fileGeodatabase1.HasSelected)
            {
                XtraMessageBox.Show("请选择源数据库！");
                return false;
            }
            if (string.IsNullOrEmpty(this.comboBoxEdit_tDatabase.Text))
            {
                XtraMessageBox.Show("请选择目标数据库！");
                return false;
            }
            try
            {
                this.wd = new WaitDialog();
                this.wd.Owner = base.ParentForm;
                this.wd.Show();
                this.wd.SetProgress("正在获取数据源...");
                if (!this._serverConnection.IsOpen)
                {
                    this._serverConnection.Connect();
                }
                Server server = new Server(this._serverConnection);
                if (!this.checkEdit_PP.Checked)
                {
                    if (this.radioGroup_source.SelectedIndex == 0)
                    {
                        string str = null;
                        IWorkspace pSourceWorkspace = this.sqlServerDatabases1.GetFeatureWorkspace(this.comboBoxEdit_database.Text, out str);
                        if (pSourceWorkspace == null)
                        {
                            XtraMessageBox.Show("源数据工作空间获取失败");
                            this.wd.Close();
                            return false;
                        }
                        string str2 = null;
                        IWorkspace pTargetWorkspace = this.GetTargetWorkspace(out str2);
                        if (pTargetWorkspace == null)
                        {
                            XtraMessageBox.Show("目标工作空间获取失败");
                            this.wd.Close();
                            return false;
                        }
                        this.wd.SetProgress("正在加载数据...");
                        server.KillAllProcesses(this.comboBoxEdit_tDatabase.Text);
                        this._serverConnection.Disconnect();
                        bool flag = this.LoadData(pSourceWorkspace, pTargetWorkspace, str, str2);
                        this.wd.Close();
                        return flag;
                    }
                    IWorkspace featureWorkspace = this.fileGeodatabase1.GetFeatureWorkspace();
                    if (featureWorkspace == null)
                    {
                        XtraMessageBox.Show("源数据工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    string pPath = null;
                    IWorkspace targetWorkspace = this.GetTargetWorkspace(out pPath);
                    if (targetWorkspace == null)
                    {
                        XtraMessageBox.Show("目标工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    this.wd.SetProgress("正在加载数据...");
                    server.KillAllProcesses(this.comboBoxEdit_tDatabase.Text);
                    this._serverConnection.Disconnect();
                    bool flag2 = this.LoadDataCommon(featureWorkspace as IFeatureWorkspace, targetWorkspace as IFeatureWorkspace);
                    this.wd.Close();
                    return flag2;
                }
                IWorkspace pSourceWs = null;
                Database pDb = server.Databases[this.comboBoxEdit_tDatabase.Text];
                DataMatchForm form = null;
                if (this.radioGroup_source.SelectedIndex == 0)
                {
                    string str4 = null;
                    pSourceWs = this.sqlServerDatabases1.GetFeatureWorkspace(this.comboBoxEdit_database.Text, out str4);
                    if (pSourceWs == null)
                    {
                        XtraMessageBox.Show("源数据工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    string str5 = null;
                    if (this.GetTargetWorkspace(out str5) == null)
                    {
                        XtraMessageBox.Show("目标工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    form = new DataMatchForm(pSourceWs, str4, str5, pDb);
                }
                else
                {
                    pSourceWs = this.fileGeodatabase1.GetFeatureWorkspace();
                    if (pSourceWs == null)
                    {
                        XtraMessageBox.Show("源数据工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    string str6 = null;
                    if (this.GetTargetWorkspace(out str6) == null)
                    {
                        XtraMessageBox.Show("目标工作空间获取失败");
                        this.wd.Close();
                        return false;
                    }
                    form = new DataMatchForm(pSourceWs, pSourceWs.PathName, str6, pDb);
                }
                this.wd.Hide();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.wd.SetProgress("正在加载数据...");
                    Dictionary<DataSetInfo, DataSetInfo> match = form.GetMatch();
                    server.KillAllProcesses(this.comboBoxEdit_tDatabase.Text);
                    this._serverConnection.Disconnect();
                    bool flag3 = this.LoadDataPP(match);
                    this.wd.Close();
                    return flag3;
                }
                this.wd.Close();
                return false;
            }
            catch
            {
                if (this.wd != null)
                {
                    this.wd.Close();
                }
                if (this._serverConnection.IsOpen)
                {
                    this._serverConnection.Disconnect();
                }
                XtraMessageBox.Show("数据导入失败！");
                return false;
            }
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

