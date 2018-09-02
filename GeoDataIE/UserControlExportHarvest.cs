namespace GeoDataIE
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlExportHarvest : UserControlBase1
    {
        private SimpleButton btnSaveBrowse;
        private ComboBoxEdit comboBoxCity;
        private ComboBoxEdit comboBoxCnty;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVill;
        private IContainer components;
        private DateEdit dateEnd;
        private DateEdit dateStart;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private Label labelMess;
        private LabelControl labelTop;
        private ListBox listBox1;
        private bool m_bCurrentTask;
        private const string m_ClassName = "UserControlExportHarvest";
        private string m_Code = "";
        private string m_DataType = "";
   
        private string m_DBKey = "";
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IList m_TaskList;
        private DataTable m_TaskTable;
        private Panel panel1;
        private Panel panel2;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl5;
        private PanelControl panelCurrent;
        private PanelControl panelFilter;
        private PanelControl panelList;
        private SimpleButton simpleButtonExport;
        private SimpleButton simpleButtonQuery;
        private TextEdit txtOutData;

        public UserControlExportHarvest()
        {
            this.InitializeComponent();
            this.simpleButtonQuery.Click += new EventHandler(this.simpleButtonQuery_Click);
        }

        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (this.txtOutData.Text != "")
            {
                try
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(this.txtOutData.Text);
                }
                catch
                {
                }
            }
            string str = "";
            if (this.m_DataType == "02")
            {
                dialog.Filter = "采伐数据库 (*.cf)|*.cf";
                str = "采伐作业设计";
            }
            else
            {
                dialog.Filter = "征占用数据库 (*.zz)|*.zz";
                str = "征占用项目";
            }
            if (this.m_bCurrentTask)
            {
                dialog.FileName = EditTask.TaskName;
            }
            else
            {
                dialog.FileName = str;
            }
            dialog.OverwritePrompt = true;
            dialog.Title = "导出数据";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.txtOutData.Text = fileName;
            }
            dialog = null;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxCnty.Properties.Items.Clear();
            this.comboBoxTown.Properties.Items.Clear();
            this.comboBoxVill.Properties.Items.Clear();
            if (this.comboBoxCity.SelectedIndex == 0)
            {
                this.m_Code = "";
            }
            else
            {
                IList<string> tag = (IList<string>) this.comboBoxCity.Tag;
                string str = tag[this.comboBoxCity.SelectedIndex];
                this.m_Code = str;
              //  if (this.m_DBAccess != null)
                {
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                    string sql = "select CCODE,CNAME from T_SYS_META_CODE where CCODE in (select distinct substring(distcode,1,6) from " + str2 + " where distcode like '" + str + "%' and distcode<>'" + str + "' and taskkind like'" + this.m_DataType + "%')";
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                    {
                        IList<string> list2 = new List<string>();
                        list2.Add("");
                        this.comboBoxCnty.Properties.Items.Add("--");
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            list2.Add(dataTable.Rows[i]["CCODE"].ToString());
                            this.comboBoxCnty.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                        }
                        this.comboBoxCnty.Tag = list2;
                        if (list2.Count == 2)
                        {
                            this.comboBoxCnty.SelectedIndex = 1;
                        }
                        else
                        {
                            this.comboBoxCnty.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void comboBoxCnty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxTown.Properties.Items.Clear();
            this.comboBoxVill.Properties.Items.Clear();
            if (this.comboBoxCnty.SelectedIndex == 0)
            {
                IList<string> tag = (IList<string>) this.comboBoxCity.Tag;
                this.m_Code = tag[this.comboBoxCity.SelectedIndex];
            }
            else
            {
                IList<string> list2 = (IList<string>) this.comboBoxCnty.Tag;
                string str = list2[this.comboBoxCnty.SelectedIndex];
                this.m_Code = str;
               // if (this.m_DBAccess != null)
                {
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                    string sql = "select CCODE,CNAME from T_SYS_META_CODE where CCODE in (select distinct substring(distcode,1,9) from " + str2 + " where distcode like '" + str + "%' and distcode<>'" + str + "' and taskkind like'" + this.m_DataType + "%')";
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                    {
                        IList<string> list3 = new List<string>();
                        list3.Add("");
                        this.comboBoxTown.Properties.Items.Add("--");
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            list3.Add(dataTable.Rows[i]["CCODE"].ToString());
                            this.comboBoxTown.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                        }
                        this.comboBoxTown.Tag = list3;
                        if (list3.Count == 2)
                        {
                            this.comboBoxTown.SelectedIndex = 1;
                        }
                        else
                        {
                            this.comboBoxTown.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void comboBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxVill.Properties.Items.Clear();
            if (this.comboBoxTown.SelectedIndex == 0)
            {
                IList<string> tag = (IList<string>) this.comboBoxCnty.Tag;
                this.m_Code = tag[this.comboBoxCnty.SelectedIndex];
            }
            else
            {
                IList<string> list2 = (IList<string>) this.comboBoxTown.Tag;
                string str = list2[this.comboBoxTown.SelectedIndex];
                this.m_Code = str;
             //   if (this.m_DBAccess != null)
                {
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                    string sql = "select CCODE,CNAME from T_SYS_META_CODE where CCODE in (select distinct substring(distcode,1,12) from " + str2 + " where distcode like '" + str + "%' and distcode<>'" + str + "' and taskkind like'" + this.m_DataType + "%')";
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                    {
                        IList<string> list3 = new List<string>();
                        list3.Add("");
                        this.comboBoxVill.Properties.Items.Add("--");
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            list3.Add(dataTable.Rows[i]["CCODE"].ToString());
                            this.comboBoxVill.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                        }
                        this.comboBoxVill.Tag = list3;
                        if (list3.Count == 2)
                        {
                            this.comboBoxVill.SelectedIndex = 1;
                        }
                        else
                        {
                            this.comboBoxVill.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void comboBoxVill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxVill.SelectedIndex == 0)
            {
                IList<string> tag = (IList<string>) this.comboBoxTown.Tag;
                this.m_Code = tag[this.comboBoxTown.SelectedIndex];
            }
            else
            {
                IList<string> list2 = (IList<string>) this.comboBoxVill.Tag;
                string str = list2[this.comboBoxVill.SelectedIndex];
                this.m_Code = str;
            }
        }

        private string ConvertTable(IFeatureClass pFClass, IQueryFilter pQueryFilter, ITable pSrcTable, ITable pTargTable)
        {
            string message = string.Empty;
            try
            {
                if (pSrcTable == null)
                {
                    return message;
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaConnectFieldName");
                int index = configValue.IndexOf(";");
                string str3 = configValue.Substring(0, index);
                string str4 = configValue.Substring(index + 1);
                string[] strArray = str3.Split(new char[] { ',' });
                string[] strArray2 = str4.Split(new char[] { ',' });
                IQueryFilter filter = new QueryFilterClass();
                IFeatureCursor o = pFClass.Search(pQueryFilter, false);
                for (IFeature feature = o.NextFeature(); feature != null; feature = o.NextFeature())
                {
                    string str5 = "";
                    string str6 = "";
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        str6 = ConvertData.GetFieldValue(feature, strArray[i]).ToString();
                        string str8 = str5;
                        str5 = str8 + " and " + strArray2[i] + "='" + str6 + "'";
                    }
                    str5 = str5.Substring(5);
                    filter.WhereClause = str5;
                    if (!ConvertData.LoadTableData2(pSrcTable, pTargTable, filter))
                    {
                        message = "LoadTable Failed";
                        break;
                    }
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(filter);
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "ConvertTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                message = exception.Message;
            }
            return message;
        }

        private bool CreateTaskTable(IWorkspace pTargWs)
        {
            if (pTargWs == null)
            {
                return false;
            }
            if (this.m_TaskTable == null)
            {
                return false;
            }
            try
            {
                IFeatureWorkspace workspace = (IFeatureWorkspace) pTargWs;
                DataTable taskTable = this.m_TaskTable;
                string name = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                UID cLSID = new UIDClass();
                cLSID.Value = "esriGeoDatabase.Object";
                IFields fields = new FieldsClass();
                IFieldsEdit edit = (IFieldsEdit) fields;
                for (int i = 0; i < taskTable.Columns.Count; i++)
                {
                    if (taskTable.Columns[i].ColumnName.ToLower() != "objectid")
                    {
                        IField field = new FieldClass();
                        IFieldEdit edit2 = (IFieldEdit) field;
                        edit2.Name_2 = taskTable.Columns[i].ColumnName;
                        edit2.Type_2 = this.GetDataType(taskTable.Columns[i].DataType.Name);
                        edit.AddField(field);
                    }
                }
                ITable o = workspace.CreateTable(name, fields, cLSID, null, "");
                if (o == null)
                {
                    return false;
                }
                for (int j = 0; j < taskTable.Rows.Count; j++)
                {
                    IRow row = o.CreateRow();
                    for (int k = 0; k < taskTable.Columns.Count; k++)
                    {
                        ConvertData.UpdateFieldValue((IObject) row, taskTable.Columns[k].ColumnName, taskTable.Rows[j][k]);
                    }
                    row.Store();
                    Marshal.ReleaseComObject(row);
                }
                Marshal.ReleaseComObject(o);
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "CreateTaskTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private bool ExportData(string sZipFullPath)
        {
            try
            {
                int num = sZipFullPath.LastIndexOf('\\');
                int num2 = sZipFullPath.LastIndexOf('.');
                sZipFullPath.Substring(0, num + 1);
                sZipFullPath.Substring(num + 1, (num2 - num) - 1);
                string str = "gdb";
                string dir = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                FileZip.DeleteFolderFile(dir);
                string sFullPath = dir + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + str;
                IWorkspace editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                IList<IFeatureClass> pFList = new List<IFeatureClass>();
                if (this.m_DataType == "02")
                {
                    IFeatureLayer editLayer = EditTask.EditLayer;
                    pFList.Add(editLayer.FeatureClass);
                }
                else
                {
                    IFeatureLayer layer2 = EditTask.EditLayer;
                    pFList.Add(layer2.FeatureClass);
                }
                IWorkspace pTargWs = null;
                pTargWs = ConvertData.CreateDBFile(sFullPath);
                if (pTargWs != null)
                {
                    string str4 = "";
                    if (this.m_DataType == "02")
                    {
                        str4 = this.ImportDataHarvest(editWorkspace, pTargWs, pFList[0]);
                    }
                    else
                    {
                        str4 = this.ImportDataZZ(editWorkspace, pTargWs, pFList);
                    }
                    Marshal.ReleaseComObject(editWorkspace);
                    Marshal.ReleaseComObject(pTargWs);
                    IWorkspaceName o = new WorkspaceNameClass();
                    o.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";
                    o.PathName = sFullPath;
                    IWorkspaceFactory workspaceFactory = o.WorkspaceFactory;
                    IWorkspaceFactoryLockControl control = (IWorkspaceFactoryLockControl) workspaceFactory;
                    if (control.SchemaLockingEnabled)
                    {
                        control.DisableSchemaLocking();
                    }
                    Marshal.ReleaseComObject(control);
                    Marshal.ReleaseComObject(workspaceFactory);
                    Marshal.ReleaseComObject(o);
                    if (str4 == string.Empty)
                    {
                        string sourceFileName = FileZip.ZipFile(sFullPath);
                        if (!sourceFileName.Equals(""))
                        {
                            if (File.Exists(sZipFullPath))
                            {
                                File.Delete(sZipFullPath);
                            }
                            File.Copy(sourceFileName, sZipFullPath);
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "ExportData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private esriFieldType GetDataType(string sType)
        {
            if (sType == "Int16")
            {
                return esriFieldType.esriFieldTypeSmallInteger;
            }
            if (sType == "Int32")
            {
                return esriFieldType.esriFieldTypeInteger;
            }
            if (sType == "DateTime")
            {
                return esriFieldType.esriFieldTypeDate;
            }
            if ((sType != "String") && (sType == "Double"))
            {
                return esriFieldType.esriFieldTypeDouble;
            }
            return esriFieldType.esriFieldTypeString;
        }

        private string ImportDataHarvest(IWorkspace pSrcWs, IWorkspace pTargWs, IFeatureClass pSourceFClass)
        {
            string message = "";
            try
            {
                string str2 = "";
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskField");
                if (this.m_bCurrentTask)
                {
                    str2 = string.Concat(new object[] { str3, "='", EditTask.TaskID, "'" });
                    string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                    string sql = string.Concat(new object[] { "select * from ", str4, " where ID=", EditTask.TaskID });
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable == null) || (dataTable.Rows.Count < 1))
                    {
                        this.m_TaskTable = null;
                    }
                    else
                    {
                        this.m_TaskTable = dataTable;
                    }
                }
                else
                {
                    for (int i = 0; i < this.m_TaskList.Count; i++)
                    {
                        object obj2 = str2;
                        str2 = string.Concat(new object[] { obj2, " or ", str3, "='", this.m_TaskList[i], "'" });
                    }
                    str2 = str2.Substring(4);
                }
                if (!this.CreateTaskTable(pTargWs))
                {
                    return "生成作业设计表出错";
                }
                IQueryFilter pQueryFilter = new QueryFilterClass();
                string name = ((IDataset) pSourceFClass).Name;
                name = name.Substring(name.LastIndexOf(".") + 1);
                pQueryFilter.WhereClause = str2;
                message = ConvertData.ConvertFeatureClass(pSrcWs, pSourceFClass, pTargWs, name, pQueryFilter);
                if (!message.Equals(""))
                {
                    return message;
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaTableName");
                ITable pTemlTable = ConvertData.OpenTable((IFeatureWorkspace) pSrcWs, configValue);
                if (pTemlTable == null)
                {
                    return "生成每木检尺表出错";
                }
                ITable pTargTable = ConvertData.CreateTable((IFeatureWorkspace) pTargWs, pTemlTable, configValue);
                if (pTargTable == null)
                {
                    return "生成每木检尺表出错";
                }
                message = message + this.ConvertTable(pSourceFClass, pQueryFilter, pTemlTable, pTargTable);
                Marshal.ReleaseComObject(pTemlTable);
                Marshal.ReleaseComObject(pTargTable);
                Marshal.ReleaseComObject(pQueryFilter);
                if (!message.Equals(""))
                {
                    return message;
                }
            }
            catch (Exception exception)
            {
                message = exception.Message;
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "ImportDataHarvest", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return message;
        }

        private string ImportDataZZ(IWorkspace pSrcWs, IWorkspace pTargWs, IList<IFeatureClass> pFList)
        {
            string message = "";
            try
            {
                string str2 = "";
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "XMField");
                if (this.m_bCurrentTask)
                {
                    str2 = string.Concat(new object[] { str3, "='", EditTask.TaskID, "'" });
                    string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "ExproTable");
                    string sql = string.Concat(new object[] { "select * from ", str4, " where ID=", EditTask.TaskID });
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable == null) || (dataTable.Rows.Count < 1))
                    {
                        this.m_TaskTable = null;
                    }
                    else
                    {
                        this.m_TaskTable = dataTable;
                    }
                }
                else
                {
                    for (int j = 0; j < this.m_TaskList.Count; j++)
                    {
                        object obj2 = str2;
                        str2 = string.Concat(new object[] { obj2, " or ", str3, "='", this.m_TaskList[j], "'" });
                    }
                    str2 = str2.Substring(4);
                }
                if (!this.CreateTaskTable(pTargWs))
                {
                    return "生成征占用项目表出错";
                }
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = str2;
                for (int i = 0; i < pFList.Count; i++)
                {
                    IFeatureClass pSourceFC = pFList[i];
                    string name = ((IDataset) pSourceFC).Name;
                    name = name.Substring(name.LastIndexOf(".") + 1);
                    message = ConvertData.ConvertFeatureClass(pSrcWs, pSourceFC, pTargWs, name, pQueryFilter);
                    if (!message.Equals(""))
                    {
                        break;
                    }
                }
                Marshal.ReleaseComObject(pQueryFilter);
            }
            catch (Exception exception)
            {
                message = exception.Message;
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "ImportDataZZ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return message;
        }

        public void Init(bool bCurrentTask)
        {
            this.m_bCurrentTask = bCurrentTask;
            this.m_DataType = EditTask.KindCode.Substring(0, 2);
            if (this.m_DataType == "02")
            {
                this.labelTop.Text = "导出当前作业设计数据";
            }
            else
            {
                this.labelTop.Text = "导出当前征占用项目数据";
            }
            this.m_DBKey = UtilFactory.GetConfigOpt().GetConfigValue("DBKey");
          //  this.m_DBAccess = UtilFactory.GetDBAccess(this.m_DBKey);
            this.labelMess.Visible = false;
            if (this.m_bCurrentTask)
            {
                this.panelList.Visible = false;
                this.panelFilter.Visible = false;
                this.panelCurrent.Visible = true;
            }
            else
            {
                this.panelCurrent.Visible = false;
                this.panelList.Visible = true;
                this.panelFilter.Visible = true;
                this.InitDist();
                DateTime now = DateTime.Now;
                this.dateStart.Text = now.AddMonths(-1).Date.ToString();
                this.dateEnd.Text = now.ToShortDateString() + " 23:59:59";
                this.QueryTask();
            }
        }

        private void InitDist()
        {
            this.comboBoxCity.Properties.Items.Clear();
            this.comboBoxCnty.Properties.Items.Clear();
            this.comboBoxTown.Properties.Items.Clear();
            this.comboBoxVill.Properties.Items.Clear();
         //   if (this.m_DBAccess != null)
            {
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                string sql = "select CCODE,CNAME from T_SYS_META_CODE where CCODE in (select distinct substring(distcode,1,4) from " + str + " where taskkind like'" + this.m_DataType + "%')";
                DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                {
                    IList<string> list = new List<string>();
                    list.Add("");
                    this.comboBoxCity.Properties.Items.Add("--");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        list.Add(dataTable.Rows[i]["CCODE"].ToString());
                        this.comboBoxCity.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                    }
                    this.comboBoxCity.Tag = list;
                    if (list.Count == 2)
                    {
                        this.comboBoxCity.SelectedIndex = 1;
                    }
                    else
                    {
                        this.comboBoxCity.SelectedIndex = 0;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtOutData = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelMess = new System.Windows.Forms.Label();
            this.simpleButtonExport = new DevExpress.XtraEditors.SimpleButton();
            this.panelCurrent = new DevExpress.XtraEditors.PanelControl();
            this.labelTop = new DevExpress.XtraEditors.LabelControl();
            this.panelList = new DevExpress.XtraEditors.PanelControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFilter = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxVill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxCnty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxCity = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCurrent)).BeginInit();
            this.panelCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelList)).BeginInit();
            this.panelList.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).BeginInit();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCnty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.txtOutData);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.btnSaveBrowse);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 269);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10, 10, 14, 9);
            this.panelControl1.Size = new System.Drawing.Size(402, 40);
            this.panelControl1.TabIndex = 0;
            // 
            // txtOutData
            // 
            this.txtOutData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutData.Location = new System.Drawing.Point(70, 10);
            this.txtOutData.Name = "txtOutData";
            this.txtOutData.Size = new System.Drawing.Size(268, 20);
            this.txtOutData.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(338, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 21);
            this.panel2.TabIndex = 9;
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveBrowse.Location = new System.Drawing.Point(358, 10);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(30, 21);
            this.btnSaveBrowse.TabIndex = 7;
            this.btnSaveBrowse.Text = "…";
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.Location = new System.Drawing.Point(10, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "导出位置：";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelMess);
            this.panelControl2.Controls.Add(this.simpleButtonExport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 309);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(0, 10, 20, 10);
            this.panelControl2.Size = new System.Drawing.Size(402, 46);
            this.panelControl2.TabIndex = 1;
            // 
            // labelMess
            // 
            this.labelMess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMess.Location = new System.Drawing.Point(19, 18);
            this.labelMess.Name = "labelMess";
            this.labelMess.Size = new System.Drawing.Size(111, 18);
            this.labelMess.TabIndex = 1;
            this.labelMess.Text = "      正在导出……";
            this.labelMess.Visible = false;
            // 
            // simpleButtonExport
            // 
            this.simpleButtonExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExport.Location = new System.Drawing.Point(327, 10);
            this.simpleButtonExport.Name = "simpleButtonExport";
            this.simpleButtonExport.Size = new System.Drawing.Size(55, 26);
            this.simpleButtonExport.TabIndex = 0;
            this.simpleButtonExport.Text = "导出";
            this.simpleButtonExport.Click += new System.EventHandler(this.simpleButtonExport_Click);
            // 
            // panelCurrent
            // 
            this.panelCurrent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelCurrent.Appearance.Options.UseBackColor = true;
            this.panelCurrent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCurrent.Controls.Add(this.labelTop);
            this.panelCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCurrent.Location = new System.Drawing.Point(0, 0);
            this.panelCurrent.Name = "panelCurrent";
            this.panelCurrent.Size = new System.Drawing.Size(402, 39);
            this.panelCurrent.TabIndex = 2;
            // 
            // labelTop
            // 
            this.labelTop.Location = new System.Drawing.Point(10, 10);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(120, 14);
            this.labelTop.TabIndex = 10;
            this.labelTop.Text = "导出当前作业设计数据";
            // 
            // panelList
            // 
            this.panelList.Appearance.BackColor = System.Drawing.Color.White;
            this.panelList.Appearance.Options.UseBackColor = true;
            this.panelList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelList.Controls.Add(this.listBox1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelList.Location = new System.Drawing.Point(0, 145);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panelList.Size = new System.Drawing.Size(402, 124);
            this.panelList.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(4, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(394, 120);
            this.listBox1.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelControl2);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Controls.Add(this.panelList);
            this.panel1.Controls.Add(this.panelFilter);
            this.panel1.Controls.Add(this.panelCurrent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 358);
            this.panel1.TabIndex = 4;
            // 
            // panelFilter
            // 
            this.panelFilter.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelFilter.Appearance.Options.UseBackColor = true;
            this.panelFilter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFilter.Controls.Add(this.panelControl3);
            this.panelFilter.Controls.Add(this.panelControl5);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 39);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(402, 106);
            this.panelFilter.TabIndex = 11;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.dateEnd);
            this.panelControl3.Controls.Add(this.dateStart);
            this.panelControl3.Controls.Add(this.simpleButtonQuery);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 68);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(5, 9, 14, 8);
            this.panelControl3.Size = new System.Drawing.Size(402, 38);
            this.panelControl3.TabIndex = 5;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(204, 9);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(140, 20);
            this.dateEnd.TabIndex = 91;
            // 
            // dateStart
            // 
            this.dateStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(41, 9);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Size = new System.Drawing.Size(140, 20);
            this.dateStart.TabIndex = 90;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonQuery.ImageIndex = 2;
            this.simpleButtonQuery.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonQuery.Location = new System.Drawing.Point(362, 9);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(26, 21);
            this.simpleButtonQuery.TabIndex = 80;
            this.simpleButtonQuery.ToolTip = "查找";
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(5, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 39;
            this.labelControl1.Text = "时间：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(187, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "—";
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.labelControl7);
            this.panelControl5.Controls.Add(this.labelControl6);
            this.panelControl5.Controls.Add(this.labelControl5);
            this.panelControl5.Controls.Add(this.labelControl4);
            this.panelControl5.Controls.Add(this.comboBoxVill);
            this.panelControl5.Controls.Add(this.comboBoxTown);
            this.panelControl5.Controls.Add(this.comboBoxCnty);
            this.panelControl5.Controls.Add(this.comboBoxCity);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(402, 68);
            this.panelControl5.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(187, 42);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "村：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 14);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "乡：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(187, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "县：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "市：";
            // 
            // comboBoxVill
            // 
            this.comboBoxVill.Location = new System.Drawing.Point(214, 41);
            this.comboBoxVill.Name = "comboBoxVill";
            this.comboBoxVill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVill.Size = new System.Drawing.Size(130, 20);
            this.comboBoxVill.TabIndex = 3;
            this.comboBoxVill.SelectedIndexChanged += new System.EventHandler(this.comboBoxVill_SelectedIndexChanged);
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Location = new System.Drawing.Point(39, 41);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(130, 20);
            this.comboBoxTown.TabIndex = 2;
            this.comboBoxTown.SelectedIndexChanged += new System.EventHandler(this.comboBoxTown_SelectedIndexChanged);
            // 
            // comboBoxCnty
            // 
            this.comboBoxCnty.Location = new System.Drawing.Point(214, 8);
            this.comboBoxCnty.Name = "comboBoxCnty";
            this.comboBoxCnty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCnty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCnty.Size = new System.Drawing.Size(130, 20);
            this.comboBoxCnty.TabIndex = 1;
            this.comboBoxCnty.SelectedIndexChanged += new System.EventHandler(this.comboBoxCnty_SelectedIndexChanged);
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.Location = new System.Drawing.Point(39, 8);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCity.Size = new System.Drawing.Size(130, 20);
            this.comboBoxCity.TabIndex = 0;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBoxCity_SelectedIndexChanged);
            // 
            // UserControlExportHarvest
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlExportHarvest";
            this.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
            this.Size = new System.Drawing.Size(410, 360);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCurrent)).EndInit();
            this.panelCurrent.ResumeLayout(false);
            this.panelCurrent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelList)).EndInit();
            this.panelList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFilter)).EndInit();
            this.panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCnty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCity.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void QueryTask()
        {
           // if (this.m_DBAccess != null)
            {
                DateTime dateTime = this.dateStart.DateTime;
                DateTime time2 = this.dateEnd.DateTime;
                this.listBox1.Items.Clear();
                this.m_TaskList = new ArrayList();
                try
                {
                    string str = "createtime";
                    string str2 = "";
                    if (this.m_DBKey.ToLower() == "sqlserver")
                    {
                        string str6 = str2;
                        str2 = str6 + str + ">=cast('" + dateTime.ToString() + "' as datetime) and " + str + "<cast('" + time2.ToString() + "' as datetime)";
                    }
                    else
                    {
                        object obj2 = str2;
                        str2 = string.Concat(new object[] { obj2, "cdate(", str, ")>=#", dateTime, "# and cdate(", str, ")<#", time2, "#" });
                    }
                    if (this.m_DataType == "02")
                    {
                        str2 = "taskkind like '02%' and " + str2;
                    }
                    else
                    {
                        str2 = "taskkind like '04%' and " + str2;
                    }
                    if (this.m_Code != "")
                    {
                        str2 = "distcode like '" + this.m_Code + "%' and " + str2;
                    }
                    string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                    string sql = "select * from " + str3 + " where " + str2 + " order by " + str + " desc";
                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if ((dataTable == null) || (dataTable.Rows.Count < 1))
                    {
                        this.m_TaskTable = null;
                    }
                    else
                    {
                        this.m_TaskTable = dataTable;
                        string item = "";
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            item = dataTable.Rows[i]["taskname"].ToString();
                            this.m_TaskList.Add(dataTable.Rows[i]["ID"]);
                            this.listBox1.Items.Add(item);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("查询出错！", "提示");
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportHarvest", "QueryTask", "", "", exception.Message, "", "", "");
                }
            }
        }

        private void simpleButtonExport_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string text = this.txtOutData.Text;
            if (text == "")
            {
                MessageBox.Show("请选择数据保存位置！", "提示", MessageBoxButtons.OK);
            }
            else if (!this.m_bCurrentTask && ((this.m_TaskList == null) || (this.m_TaskList.Count < 1)))
            {
                MessageBox.Show("导出列表为空，无法导出！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                this.simpleButtonExport.Enabled = false;
                this.labelMess.Visible = true;
                if (this.ExportData(text))
                {
                    flag = true;
                }
                this.simpleButtonExport.Enabled = true;
                this.labelMess.Visible = false;
                if (flag)
                {
                    MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK);
                    (base.Parent as Form).Close();
                }
                else
                {
                    MessageBox.Show("导出失败！", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            //if (this.m_DBAccess == null)
            //{
            //    MessageBox.Show("数据库连接出错，无法导出！", "提示");
            //}
            //else
            //{
            //    DateTime dateTime = this.dateStart.DateTime;
            //    DateTime time2 = this.dateEnd.DateTime;
            //    if (dateTime > time2)
            //    {
            //        MessageBox.Show("录入开始时间比结束时间晚，请修改！", "提示");
            //    }
            //    else
            //    {
            //        this.QueryTask();
            //    }
            //}
        }
    }
}

