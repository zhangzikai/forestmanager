namespace GeoDataIE
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class UserControlImportHarvest : UserControlBase1
    {
        private SimpleButton btnSaveBrowse;
        private IContainer components;
        private GroupControl groupControl1;
        private Label labelMess;
        private LabelControl labelTop;
        private ListBox listBox1;
        private bool m_bUpzip;
        private const string m_ClassName = "GeoDataIE.UserControlImportHarvest";
        private string m_DataType = "";
      
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IHookHelper m_hookHelper;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private string m_TDistField = "";
        private string m_TIDField = "";
        private string m_TKindField = "";
        private string m_TNameField = "";
        private IWorkspace m_Workspace;
        private Panel panel1;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PanelControl panelTask;
        private SimpleButton simpleButtonImport;
        private SimpleButton simpleButtonPreview;
        private SimpleButton simpleButtonRemove;
        private TextEdit txtOutData;

        public UserControlImportHarvest()
        {
            this.InitializeComponent();
            this.panelTask.Visible = false;
        }

        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (this.txtOutData.Text != "")
            {
                try
                {
                    dialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.txtOutData.Text);
                }
                catch
                {
                }
            }
            if (this.m_DataType == "02")
            {
                dialog.Filter = "采伐数据库 (*.cf)|*.cf";
                dialog.Title = "采伐数据";
            }
            else
            {
                dialog.Filter = "征占用数据库 (*.zz)|*.zz";
                dialog.Title = "征占用数据";
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.txtOutData.Text = fileName;
            }
            dialog = null;
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
                    ConvertData.LoadTableData(pSrcTable, pTargTable, filter);
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(filter);
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "ConvertTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                message = exception.Message;
            }
            return message;
        }
        public MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private bool ConvertTaskTable(ITable pSrcTable, string sTableName, string sTaskID)
        {
            if (pSrcTable == null)
            {
                return false;
            }
            try
            {
                IQueryFilter queryFilter = null;
                if (sTaskID != "")
                {
                    queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = this.m_TIDField + "=" + sTaskID;
                }
                ICursor o = pSrcTable.Search(queryFilter, false);
                IRow row = o.NextRow();
                if (row == null)
                {
                    return false;
                }
                bool flag = true;
                IFields fields = pSrcTable.Fields;
                string str = "";
                string str2 = "";
                string sCmdText = "";
                while (row != null)
                {
                    str = "";
                    str2 = "";
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        if (fields.get_Field(i).Editable)
                        {
                            object obj2 = row.get_Value(i);
                            if (obj2 != null)
                            {
                                str = str + "," + fields.get_Field(i).Name;
                                if (fields.get_Field(i).Type == esriFieldType.esriFieldTypeString)
                                {
                                    str2 = str2 + ",'" + obj2.ToString() + "'";
                                }
                                else
                                {
                                    str2 = str2 + "," + obj2.ToString();
                                }
                            }
                        }
                    }
                    str = str.Substring(1);
                    str2 = str2.Substring(1);
                    sCmdText = "insert into " + sTableName + "(" + str + ") values(" + str2 + ")";
                    if (MDM.UpdateDB(sCmdText))
                    {
                        flag = false;
                        break;
                    }
                    row = o.NextRow();
                }
                Marshal.ReleaseComObject(o);
                return flag;
            }
            catch
            {
                return false;
            }
        }

        private bool DeleteData(IFeatureClass pFClass, string sWhere)
        {
            if (sWhere == "")
            {
                return true;
            }
            try
            {
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = sWhere;
                IFeatureCursor o = pFClass.Search(filter, false);
                IFeature feature = o.NextFeature();
                if (feature != null)
                {
                    goto Label_0041;
                }
                return true;
            Label_0034:
                feature.Delete();
                feature = o.NextFeature();
            Label_0041:
                if (feature != null)
                {
                    goto Label_0034;
                }
                Marshal.ReleaseComObject(filter);
                Marshal.ReleaseComObject(o);
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "DeleteData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool DeleteData(IFeatureClass pTargFClass, ITable pTargTable, string sWhere)
        {
            if (sWhere == "")
            {
                return true;
            }
            try
            {
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = sWhere;
                IFeatureCursor o = pTargFClass.Search(filter, false);
                IFeature pObj = o.NextFeature();
                if (pObj != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaConnectFieldName");
                    int index = configValue.IndexOf(";");
                    string str2 = configValue.Substring(0, index);
                    string str3 = configValue.Substring(index + 1);
                    string[] strArray = str2.Split(new char[] { ',' });
                    string[] strArray2 = str3.Split(new char[] { ',' });
                    IQueryFilter queryFilter = new QueryFilterClass();
                    while (pObj != null)
                    {
                        string str4 = "";
                        string str5 = "";
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            str5 = ConvertData.GetFieldValue(pObj, strArray[i]).ToString();
                            string str6 = str4;
                            str4 = str6 + " and " + strArray2[i] + "='" + str5 + "'";
                        }
                        str4 = str4.Substring(5);
                        queryFilter.WhereClause = str4;
                        ICursor cursor2 = pTargTable.Search(queryFilter, false);
                        for (IRow row = cursor2.NextRow(); row != null; row = cursor2.NextRow())
                        {
                            row.Delete();
                        }
                        Marshal.ReleaseComObject(cursor2);
                        pObj.Delete();
                        pObj = o.NextFeature();
                    }
                    Marshal.ReleaseComObject(filter);
                    Marshal.ReleaseComObject(queryFilter);
                    Marshal.ReleaseComObject(o);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "DeleteData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }
        private ProjectManager PM
        {
            get
            {
               return DBServiceFactory<ProjectManager>.Service;
            }
        }
     
        
        private bool DeleteTaskTable(string sTaskTable, string sTaskID, string sDist, string sKind)
        {
           // PM.Delete()
            string str;
            string str2 = str = "delete from " + sTaskTable + " where " + this.m_TIDField + "=" + sTaskID;
            str = str2 + " and " + this.m_TDistField + "='" + sDist + "' and " + this.m_TKindField + " like '" + sKind.Substring(0, 2) + "%'";
            return MDM.UpdateDB(str);
          ;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExistTask(string sDist, string sID, string sKind)
        {
            string sql = "";
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
            sql = "select id from " + str2 + " where " + this.m_TDistField + "='" + sDist + "' and " + this.m_TIDField + "=" + sID + " and " + this.m_TKindField + " like '" + sKind.Substring(0, 2) + "%'";
        //    DataTable dataTable = this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
           // return ((dataTable != null) && (dataTable.Rows.Count >= 1));
            return false;
        }

        private IWorkspace GetWorkspace()
        {
            string text = this.txtOutData.Text;
            if ((text == "") || !File.Exists(text))
            {
                return null;
            }
            string dir = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
            FileZip.DeleteFolderFile(dir);
            string destFileName = dir + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".gdb.zip";
            File.Copy(text, destFileName);
            string sSourceFile = FileZip.UnzipFile(destFileName);
            if (sSourceFile == "")
            {
                return null;
            }
            return ConvertData.OpenWorkspace(sSourceFile);
        }

        private void ImportData()
        {
            IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
            if (editWorkspace == null)
            {
                MessageBox.Show("获取数据库出错，无法导入！", "提示");
            }
            else
            {
                try
                {
                    ITable pSrcTable = null;
                    ITable pTaskTable = null;
                    IEnumDataset dataset = this.m_Workspace.get_Datasets(esriDatasetType.esriDTTable);
                    for (IDataset dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
                    {
                        if (dataset2.Name.ToLower().Contains("task"))
                        {
                            pTaskTable = (ITable) dataset2;
                        }
                        else
                        {
                            pSrcTable = (ITable) dataset2;
                        }
                    }
                    if ((pTaskTable == null) || (pTaskTable.RowCount(null) < 1))
                    {
                        MessageBox.Show("作业设计信息不全，无法导入！", "提示");
                    }
                    else
                    {
                        IEnumDataset dataset3 = this.m_Workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                        IFeatureClass pSrcFClass = (IFeatureClass) dataset3.Next();
                        if (pSrcFClass == null)
                        {
                            MessageBox.Show("无矢量数据，无法导入！", "提示");
                        }
                        else
                        {
                            bool flag = true;
                            string sTaskTable = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskTable");
                            ICursor o = pTaskTable.Search(null, false);
                            IRow row = o.NextRow();
                            while (row != null)
                            {
                                string sDist = ConvertData.GetFieldValue((IObject) row, this.m_TDistField).ToString();
                                string sID = ConvertData.GetFieldValue((IObject) row, this.m_TIDField).ToString();
                                string str4 = ConvertData.GetFieldValue((IObject) row, this.m_TNameField).ToString();
                                string sKind = ConvertData.GetFieldValue((IObject) row, this.m_TKindField).ToString();
                                if (EditTask.TaskYear != "")
                                {
                                    string str6 = ConvertData.GetFieldValue((IObject) row, "taskyear").ToString();
                                    if (EditTask.TaskYear != str6)
                                    {
                                        MessageBox.Show("    导入作业设计【" + str4 + "】失败！导入的作业设计与当前编辑年度不一致。", "提示");
                                        flag = false;
                                        row = o.NextRow();
                                        continue;
                                    }
                                }
                                if (this.m_DataType == "02")
                                {
                                    if (this.ExistTask(sDist, sID, sKind))
                                    {
                                        if (MessageBox.Show("    作业设计【" + str4 + "】已存在，是否替换？", "数据导入", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            this.DeleteTaskTable(sTaskTable, sID, sDist, sKind);
                                            if (!this.LoadDataHarvest(pSrcFClass, pSrcTable, pTaskTable, sTaskTable, sID, editWorkspace, true))
                                            {
                                                MessageBox.Show("    导入作业设计【" + str4 + "】失败！", "提示");
                                                flag = false;
                                            }
                                        }
                                        else
                                        {
                                            flag = false;
                                        }
                                    }
                                    else if (!this.LoadDataHarvest(pSrcFClass, pSrcTable, pTaskTable, sTaskTable, sID, editWorkspace, false))
                                    {
                                        MessageBox.Show("    导入作业设计【" + str4 + "】失败！", "提示");
                                        flag = false;
                                    }
                                }
                                else
                                {
                                    IList<IFeatureClass> pFList = new List<IFeatureClass>();
                                    pFList.Add(pSrcFClass);
                                    IDataset dataset5 = null;
                                    while ((dataset5 = dataset3.Next()) != null)
                                    {
                                        IFeatureClass item = (IFeatureClass) dataset5;
                                        if (pSrcFClass != null)
                                        {
                                            pFList.Add(item);
                                        }
                                    }
                                    if (this.ExistTask(sDist, sID, sKind))
                                    {
                                        if (MessageBox.Show("    征占用项目【" + str4 + "】的编号已存在，是否替换？", "数据导入", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            this.DeleteTaskTable(sTaskTable, sID, sDist, sKind);
                                            if (!this.LoadDataZZ(pFList, pSrcTable, pTaskTable, sTaskTable, sID, editWorkspace, true))
                                            {
                                                MessageBox.Show("    导入征占用项目【" + str4 + "】失败！", "提示");
                                                flag = false;
                                            }
                                        }
                                        else
                                        {
                                            flag = false;
                                        }
                                    }
                                    else if (!this.LoadDataZZ(pFList, pSrcTable, pTaskTable, sTaskTable, sID, editWorkspace, false))
                                    {
                                        MessageBox.Show("    导入征占用项目【" + str4 + "】失败！", "提示");
                                        flag = false;
                                    }
                                }
                                row = o.NextRow();
                            }
                            Marshal.ReleaseComObject(o);
                            if (flag)
                            {
                                MessageBox.Show("导入数据完成！", "提示");
                                ((Form) base.Parent).Close();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "ImportData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        public void Init()
        {
            this.labelMess.Visible = false;
            this.m_TIDField = "id";
            this.m_TNameField = "taskname";
            this.m_TDistField = "distcode";
            this.m_TKindField = "taskkind";
            this.m_DataType = EditTask.KindCode.Substring(0, 2);
            if (this.m_DataType == "02")
            {
                this.groupControl1.Text = "采伐作业设计列表";
            }
            else
            {
                this.groupControl1.Text = "征占用项目列表";
            }         
        }

        private void InitializeComponent()
        {
            this.txtOutData = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonPreview = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelTop = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelTask = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTask)).BeginInit();
            this.panelTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutData
            // 
            this.txtOutData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutData.Location = new System.Drawing.Point(14, 7);
            this.txtOutData.Name = "txtOutData";
            this.txtOutData.Size = new System.Drawing.Size(286, 20);
            this.txtOutData.TabIndex = 7;
            this.txtOutData.EditValueChanged += new System.EventHandler(this.txtOutData_EditValueChanged);
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveBrowse.Location = new System.Drawing.Point(310, 7);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(33, 21);
            this.btnSaveBrowse.TabIndex = 8;
            this.btnSaveBrowse.Text = "…";
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButtonRemove);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.simpleButtonPreview);
            this.panelControl2.Controls.Add(this.simpleButtonImport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 74);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 10, 15, 10);
            this.panelControl2.Size = new System.Drawing.Size(352, 44);
            this.panelControl2.TabIndex = 9;
            // 
            // simpleButtonRemove
            // 
            this.simpleButtonRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonRemove.Location = new System.Drawing.Point(106, 10);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(55, 24);
            this.simpleButtonRemove.TabIndex = 2;
            this.simpleButtonRemove.Text = "移除查看";
            this.simpleButtonRemove.Click += new System.EventHandler(this.simpleButtonRemove_Click);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(65, 10);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(41, 24);
            this.panelControl4.TabIndex = 3;
            // 
            // simpleButtonPreview
            // 
            this.simpleButtonPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonPreview.Location = new System.Drawing.Point(10, 10);
            this.simpleButtonPreview.Name = "simpleButtonPreview";
            this.simpleButtonPreview.Size = new System.Drawing.Size(55, 24);
            this.simpleButtonPreview.TabIndex = 1;
            this.simpleButtonPreview.Text = "查看";
            this.simpleButtonPreview.Click += new System.EventHandler(this.simpleButtonPreview_Click);
            // 
            // simpleButtonImport
            // 
            this.simpleButtonImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonImport.Location = new System.Drawing.Point(282, 10);
            this.simpleButtonImport.Name = "simpleButtonImport";
            this.simpleButtonImport.Size = new System.Drawing.Size(55, 24);
            this.simpleButtonImport.TabIndex = 0;
            this.simpleButtonImport.Text = "导入";
            this.simpleButtonImport.Click += new System.EventHandler(this.simpleButtonImport_Click);
            // 
            // labelTop
            // 
            this.labelTop.Location = new System.Drawing.Point(14, 17);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(60, 14);
            this.labelTop.TabIndex = 10;
            this.labelTop.Text = "导入数据：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.labelTop);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(352, 74);
            this.panelControl1.TabIndex = 11;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.txtOutData);
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Controls.Add(this.btnSaveBrowse);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 37);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(14, 7, 5, 7);
            this.panelControl3.Size = new System.Drawing.Size(348, 35);
            this.panelControl3.TabIndex = 12;
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl5.Location = new System.Drawing.Point(300, 7);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(10, 21);
            this.panelControl5.TabIndex = 9;
            // 
            // panelTask
            // 
            this.panelTask.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTask.Controls.Add(this.groupControl1);
            this.panelTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTask.Location = new System.Drawing.Point(0, 118);
            this.panelTask.Name = "panelTask";
            this.panelTask.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelTask.Size = new System.Drawing.Size(352, 157);
            this.panelTask.TabIndex = 12;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.listBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(10, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(332, 145);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "作业设计列表";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(2, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(328, 121);
            this.listBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMess);
            this.panel1.Controls.Add(this.panelTask);
            this.panel1.Controls.Add(this.panelControl2);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 319);
            this.panel1.TabIndex = 13;
            // 
            // labelMess
            // 
            this.labelMess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMess.Location = new System.Drawing.Point(19, 288);
            this.labelMess.Name = "labelMess";
            this.labelMess.Size = new System.Drawing.Size(111, 18);
            this.labelMess.TabIndex = 13;
            this.labelMess.Text = "      正在导入……";
            // 
            // UserControlImportHarvest
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panel1);
            this.Name = "UserControlImportHarvest";
            this.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
            this.Size = new System.Drawing.Size(360, 321);
            ((System.ComponentModel.ISupportInitialize)(this.txtOutData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTask)).EndInit();
            this.panelTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private bool LoadDataHarvest(IFeatureClass pSrcFClass, ITable pSrcTable, ITable pTaskTable, string sTaskTable, string sTaskID, IFeatureWorkspace pTargFws, bool bReplace)
        {
            bool flag = true;
            try
            {
                IFeatureClass pTargFClass = null;
                string sName = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "DatasetName");
                IFeatureClassContainer container = (IFeatureClassContainer) ConvertData.OpenFeatureDataset(pTargFws, sName);
                IEnumFeatureClass classes = container.Classes;
                for (IFeatureClass class4 = classes.Next(); class4 != null; class4 = classes.Next())
                {
                    if (((IDataset) class4).Name.ToLower().Contains("cf"))
                    {
                        pTargFClass = class4;
                        break;
                    }
                }
                if (pTargFClass == null)
                {
                    return false;
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaTableName");
                ITable pTargTable = ConvertData.OpenTable(pTargFws, configValue);
                bool flag2 = true;
                Editor.UniqueInstance.SetArea = false;
                Editor.UniqueInstance.CheckOverlap = false;
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    flag2 = false;
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                Editor.UniqueInstance.StartEditOperation();
                string sWhere = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskField") + "='" + sTaskID + "'";
                if (bReplace && !this.DeleteData(pTargFClass, pTargTable, sWhere))
                {
                    flag = false;
                }
                else
                {
                    IQueryFilter pQFilter = new QueryFilterClass();
                    pQFilter.WhereClause = sWhere;
                    if (!ConvertData.LoadFeatureClass(pSrcFClass, pTargFClass, pQFilter))
                    {
                        flag = false;
                    }
                    else if ((pSrcTable != null) && (this.ConvertTable(pSrcFClass, pQFilter, pSrcTable, pTargTable) != ""))
                    {
                        flag = false;
                    }
                    else
                    {
                        Marshal.ReleaseComObject(pQFilter);
                        if (!this.ConvertTaskTable(pTaskTable, sTaskTable, sTaskID))
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    Editor.UniqueInstance.StopEditOperation();
                }
                else
                {
                    Editor.UniqueInstance.AbortEditOperation();
                }
                Editor.UniqueInstance.StopEdit();
                if (flag2)
                {
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                return flag;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "LoadDataHarvest", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool LoadDataZZ(IList<IFeatureClass> pFList, ITable pSrcTable, ITable pTaskTable, string sTaskTable, string sTaskID, IFeatureWorkspace pTargFws, bool bReplace)
        {
            bool flag = true;
            bool flag2 = true;
            try
            {
                IFeatureClass class2 = null;
                IFeatureClass class3 = null;
                IFeatureClass class4 = null;
                string sName = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "DatasetName");
                IFeatureClassContainer container = (IFeatureClassContainer) ConvertData.OpenFeatureDataset(pTargFws, sName);
                IEnumFeatureClass classes = container.Classes;
                for (IFeatureClass class6 = classes.Next(); class6 != null; class6 = classes.Next())
                {
                    if (((IDataset) class6).Name.ToLower().Contains("zt_ldzz"))
                    {
                        class2 = class6;
                    }
                    else if (((IDataset) class6).Name.ToLower().Contains("zt_d_ldzz"))
                    {
                        class3 = class6;
                    }
                    else if (((IDataset) class6).Name.ToLower().Contains("zt_l_ldzz"))
                    {
                        class4 = class6;
                    }
                }
                if (class2 == null)
                {
                    return false;
                }
                Editor.UniqueInstance.SetArea = false;
                Editor.UniqueInstance.CheckOverlap = false;
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    flag2 = false;
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                Editor.UniqueInstance.StartEditOperation();
                string sWhere = UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "XMField") + "='" + sTaskID + "'";
                IQueryFilter pQFilter = new QueryFilterClass();
                pQFilter.WhereClause = sWhere;
                for (int i = 0; i < pFList.Count; i++)
                {
                    IFeatureClass pFClass = pFList[i];
                    IFeatureClass pTargFClass = null;
                    if (pFClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        pTargFClass = class2;
                    }
                    else if (pFClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {
                        pTargFClass = class4;
                    }
                    else
                    {
                        pTargFClass = class3;
                    }
                    if (bReplace && !this.DeleteData(pFClass, sWhere))
                    {
                        flag = false;
                        goto Label_01D1;
                    }
                    if (!ConvertData.LoadFeatureClass(pFClass, pTargFClass, pQFilter))
                    {
                        flag = false;
                        goto Label_01D1;
                    }
                }
                Marshal.ReleaseComObject(pQFilter);
                if (!this.ConvertTaskTable(pTaskTable, sTaskTable, sTaskID))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            Label_01D1:
                Editor.UniqueInstance.SetArea = true;
                if (flag)
                {
                    Editor.UniqueInstance.StopEditOperation();
                }
                else
                {
                    Editor.UniqueInstance.AbortEditOperation();
                }
                Editor.UniqueInstance.StopEdit();
                if (flag2)
                {
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                return flag;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "LoadDataZZ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                if (!flag2)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                return false;
            }
        }

        private void PreviewData()
        {
            try
            {
                if (!this.m_bUpzip)
                {
                    IWorkspace workspace = this.GetWorkspace();
                    if (workspace == null)
                    {
                        MessageBox.Show("打开数据出错，请确认已选择正确文件！", "提示");
                        return;
                    }
                    this.m_Workspace = workspace;
                    this.m_bUpzip = true;
                }
                this.listBox1.Items.Clear();
                ITable table = null;
                IEnumDataset dataset = this.m_Workspace.get_Datasets(esriDatasetType.esriDTTable);
                for (IDataset dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
                {
                    if (dataset2.Name.ToLower().Contains("task"))
                    {
                        table = (ITable) dataset2;
                        break;
                    }
                }
                if (table == null)
                {
                    MessageBox.Show("提交数据无作业设计信息表！", "提示");
                }
                else
                {
                    ICursor o = table.Search(null, false);
                    IRow row = o.NextRow();
                    if (row == null)
                    {
                        MessageBox.Show("提交数据无作业设计信息！", "提示");
                    }
                    else
                    {
                        string name = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "TaskNameField");
                        int index = table.Fields.FindField(name);
                        while (row != null)
                        {
                            string item = row.get_Value(index).ToString();
                            this.listBox1.Items.Add(item);
                            row = o.NextRow();
                        }
                        Marshal.ReleaseComObject(o);
                        this.panelTask.Visible = true;
                        IEnumDataset dataset3 = this.m_Workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                        IDataset dataset4 = dataset3.Next();
                        if (dataset4 == null)
                        {
                            MessageBox.Show("提交数据无数据！", "提示");
                        }
                        else
                        {
                            IFeatureClass class2 = null;
                            while (dataset4 != null)
                            {
                                class2 = (IFeatureClass) dataset4;
                                if (class2.ShapeType == esriGeometryType.esriGeometryPolygon)
                                {
                                    break;
                                }
                                dataset4 = dataset3.Next();
                            }
                            string sDocument = "";
                            if (this.m_DataType == "02")
                            {
                                sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\导入采伐作业设计.lyr";
                            }
                            else
                            {
                                sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\导入征占用项目.lyr";
                            }
                            IMapDocument document = new MapDocumentClass();
                            document.Open(sDocument, "");
                            ILayer layer = document.get_Map(0).get_Layer(0);
                            IFeatureLayer layer2 = (IFeatureLayer) layer;
                            layer2.FeatureClass = class2;
                            if (this.m_hookHelper != null)
                            {
                                this.m_hookHelper.FocusMap.AddLayer(layer);
                                IGeoDataset dataset5 = (IGeoDataset) class2;
                                IEnvelope extent = dataset5.Extent;
                                extent.Expand(1.2, 1.2, true);
                                this.m_hookHelper.ActiveView.Extent = extent;
                                this.m_hookHelper.ActiveView.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "GeoDataIE.UserControlImportHarvest", "simpleButtonPreview_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            
                if (!this.m_bUpzip)
                {
                    IWorkspace workspace = this.GetWorkspace();
                    if (workspace == null)
                    {
                        MessageBox.Show("打开数据出错，请确认已选择正确文件！", "提示");
                        return;
                    }
                    this.m_Workspace = workspace;
                    this.m_bUpzip = true;
                }
                this.panelControl2.Enabled = false;
                this.labelMess.Visible = true;
                this.ImportData();
                this.panelControl2.Enabled = true;
                this.labelMess.Visible = false;
            
        }

        private void simpleButtonPreview_Click(object sender, EventArgs e)
        {
            this.PreviewData();
        }

        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            string sLayerName = "";
            if (this.m_DataType == "02")
            {
                sLayerName = "导入采伐作业设计";
            }
            else
            {
                sLayerName = "导入征占用项目";
            }
            if (this.m_hookHelper != null)
            {
                IMap focusMap = this.m_hookHelper.FocusMap;
                ILayer layer = GISFunFactory.LayerFun.FindLayer((IBasicMap) focusMap, sLayerName, true);
                if (layer != null)
                {
                    focusMap.DeleteLayer(layer);
                }
            }
        }

        private void txtOutData_EditValueChanged(object sender, EventArgs e)
        {
            this.m_bUpzip = false;
            this.panelTask.Visible = false;
        }

        public object Hook
        {
            set
            {
                if (value != null)
                {
                    try
                    {
                        this.m_hookHelper = new HookHelperClass();
                        this.m_hookHelper.Hook = value;
                        if (this.m_hookHelper.ActiveView == null)
                        {
                            this.m_hookHelper = null;
                        }
                    }
                    catch
                    {
                        this.m_hookHelper = null;
                    }
                }
            }
        }
    }
}

