namespace GDB.SQLServerExpress.vTasks
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.Forest;
    using GDB.SQLServerExpress.vTasks.Properties;
    using GDB.SQLServerExpress.vTasks.vControls;
    using GDB.SQLServerExpress.vTasks.vTasks;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class CreateForestGDBTask : ForestGDBTask
    {
        private ForGeoDataMatchFrm _dataMatchFrm;
        private string _loadDataSets = "BASE,FOREST";
        private IWorkspace _pTargetWorkspace;
        private ForestGDBInfo _wkGdbInfo;
        public GetDataFieldNamesHandler OnGetFieldNames;
        private IWorkspace pSrcWks;
        private string srcGdbPath = string.Empty;

        private void ChangeNameHandler(object sender, string name)
        {
            IFeatureWorkspace pSrcWks = this.pSrcWks as IFeatureWorkspace;
            if (pSrcWks != null)
            {
                IFeatureClass pFeatureClass = ForestGDBWorkSpaceUtil.OpenFeatureClass(pSrcWks, name);
                if (pFeatureClass != null)
                {
                    Dictionary<string, esriFieldType> fields = this.getFields(pFeatureClass);
                    if (this.OnGetFieldNames == null)
                    {
                        this.OnGetFieldNames(this, fields);
                    }
                }
            }
        }

        public static void CopyGeoObject(IObject pSrcObj, IObject pTargObj)
        {
            if ((pSrcObj != null) && (pTargObj != null))
            {
                string sFieldName = "";
                IFields fields = pTargObj.Fields;
                try
                {
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                        {
                            sFieldName = field.Name;
                            object fieldValue = GetFieldValue(pSrcObj, sFieldName);
                            if (fieldValue != null)
                            {
                                pTargObj.set_Value(i, fieldValue);
                            }
                        }
                    }
                    pTargObj.Store();
                }
                catch
                {
                }
            }
        }

        public static void CopyGeoObject(IObject pSrcObj, IObject pTargObj, Dictionary<string, string> mapFields)
        {
            if ((pSrcObj != null) && (pTargObj != null))
            {
                string key = string.Empty;
                IFields fields = pTargObj.Fields;
                try
                {
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                        {
                            key = field.Name;
                            if (((mapFields != null) && mapFields.ContainsKey(key)) && !string.IsNullOrEmpty(mapFields[key]))
                            {
                                key = mapFields[key];
                            }
                            if (string.IsNullOrEmpty(key))
                            {
                                object fieldValue = GetFieldValue(pSrcObj, key);
                                if (fieldValue != null)
                                {
                                    pTargObj.set_Value(i, fieldValue);
                                }
                            }
                        }
                    }
                    pTargObj.Store();
                }
                catch
                {
                }
            }
        }

        protected bool CreateNewGDB(string keyText)
        {
            if (base._dsAdmin == null)
            {
                return false;
            }
            try
            {
                base.queryAllDBNames();
                if (base.IsGDBExists(this._wkGdbInfo.DBName))
                {
                    TaskResult result = new TaskResult {
                        Msg = "数据库已经存在不需要建立!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(100, result);
                    return true;
                }
                if (base._dsAdmin.IsConnectedUserAdministrator)
                {
                    base._dsAdmin.CreateGeodatabase(this._wkGdbInfo.DBName, this._wkGdbInfo.GdbFileName, (this._wkGdbInfo.GDBSize < 0) ? 0 : this._wkGdbInfo.GDBSize, this._wkGdbInfo.GdbLogFileName, (this._wkGdbInfo.LogSize < 0) ? 0 : this._wkGdbInfo.LogSize);
                    TaskResult result2 = new TaskResult {
                        Msg = "新库建立成功，更新数据库信息...",
                        Success = true
                    };
                    base.FireProgressChangedEvent(20, result2);
                    return this.UpdateGDBToForest(keyText);
                }
                return false;
            }
            catch (Exception exception)
            {
                TaskResult result3 = new TaskResult {
                    Msg = "新库建立失败：" + exception.Message,
                    Success = true
                };
                base.FireProgressChangedEvent(100, result3);
                return false;
            }
        }

        private void CreateSysTable()
        {
            if (((this._wkGdbInfo != null) && (this._wkGdbInfo.UpdateMetaInfos != null)) && (this._wkGdbInfo.UpdateMetaInfos.Count > 0))
            {
                using (SqlConnection connection = ForestGDBTask.CreateConnection(this._wkGdbInfo.ServerName, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
                {
                    connection.Open();
                    string sql = "CREATE TABLE SYS_MAX_ID(MAX_TYPE nvarchar(20),MAX_ID int,TYPE_NAME nvarchar(20))";
                    this.ExcuteSql(connection, sql);
                    sql = "CREATE TABLE T_LOG(USER_NAME nvarchar(50) ,OPERATE nvarchar(50) ,LOG_TIME datetime2(7) ,REMARK nvarchar(255) ,SYSTEM nvarchar(50) ,ID int NOT NULL)";
                    this.ExcuteSql(connection, sql);
                    string str2 = string.Format("DELETE FROM T_SYS_META_CODE WHERE LEN(PCODE)>0 AND LEFT(CCODE,6) <> '{0}'", this._wkGdbInfo.GBCode);
                    this.ExcuteSql(connection, str2);
                    str2 = string.Format("DELETE FROM T_SYS_LD_ADMIN_CODES WHERE LEFT(CCODE,6) <> '{0}'", this._wkGdbInfo.GBCode);
                    this.ExcuteSql(connection, str2);
                    string str3 = string.Format(Resources.CREATE_VIEW, this._wkGdbInfo.DataYear);
                    this.ExcuteSql(connection, str3);
                    try
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                    TaskResult result = new TaskResult {
                        Msg = "数据库元数据更新完成!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(0x5f, result);
                }
                this.DropObjectIdField(new string[] { "T_DesignKind", "T_EditTask_ZT", "SYS_MAX_ID", "T_LOG", "T_SYS_USER_AUTHOR", "T_MapLayer", "T_EditTask", "T_SYS_FLOW_AUTHOR", "T_SYS_FLOW_DEPT", "T_SYS_FLOW_USER", "T_Logic_Check", "T_AutoUpdate_Feature", "T_ZT_Overlap" });
            }
        }

        private void DeleteIndx()
        {
            if (((this._wkGdbInfo != null) && (this._wkGdbInfo.UpdateMetaInfos != null)) && (this._wkGdbInfo.UpdateMetaInfos.Count > 0))
            {
                using (SqlConnection connection = ForestGDBTask.CreateConnection(this._wkGdbInfo.ServerName, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
                {
                    connection.Open();
                    this.ExcuteSql(connection, Resources.DELE_INDX);
                    try
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void DropObjectIdField(string[] tables)
        {
            ServerConnection serverConnection = new ServerConnection(this._wkGdbInfo.GDBServer, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass);
            Server server = new Server(serverConnection);
            Database database = server.Databases[this._wkGdbInfo.DBName];
            foreach (string str in tables)
            {
                Microsoft.SqlServer.Management.Smo.Table table = database.Tables[str];
                if (table != null)
                {
                    try
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
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        Column column = table.Columns["OBJECTID"];
                        if (column != null)
                        {
                            column.Drop();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            serverConnection.Disconnect();
            serverConnection = null;
        }

        private void ExcuteSql(SqlConnection conn, string sql)
        {
            try
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
            }
            catch (Exception)
            {
            }
        }

        private List<string> ExpTmplToNewGDB(IWorkspace srcWks, IWorkspace targetWks, esriDatasetType esriType, List<string> noNeedNames)
        {
            List<string> list = new List<string>();
            IEnumDataset dataset = srcWks.get_Datasets(esriType);
            if (dataset != null)
            {
                dataset.Reset();
                IDataset o = dataset.Next();
                int num = 0x19;
                while (o != null)
                {
                    string item = o.Name.ToUpper();
                    item = item.Substring(item.LastIndexOf('.') + 1);
                    esriDatasetType esriDataType = o.Type;
                    if ((noNeedNames == null) || !noNeedNames.Contains(item))
                    {
                        TaskResult result = new TaskResult {
                            Msg = "导入模板要素:" + item,
                            Success = true
                        };
                        base.FireProgressChangedEvent(num++, result);
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        this.GDBToNewGDB2(srcWks, targetWks, item, esriDataType, false);
                        stopwatch.Stop();
                        TaskResult result2 = new TaskResult {
                            Msg = item + "模板已导入!耗时:" + stopwatch.Elapsed.ToString(),
                            Success = true
                        };
                        base.FireProgressChangedEvent(num++, result2);
                        Marshal.ReleaseComObject(o);
                        o = null;
                        o = dataset.Next();
                    }
                }
            }
            return list;
        }

        ~CreateForestGDBTask()
        {
            try
            {
                if (base._dsAdmin != null)
                {
                    Marshal.ReleaseComObject(base._dsAdmin);
                    base._dsAdmin = null;
                }
                if (this._pTargetWorkspace != null)
                {
                    Marshal.ReleaseComObject(this._pTargetWorkspace);
                    this._pTargetWorkspace = null;
                }
                if (this.pSrcWks != null)
                {
                    Marshal.ReleaseComObject(this.pSrcWks);
                    this.pSrcWks = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void GDBToNewGDB2(IWorkspace sourceWorkspace, IWorkspace targetWorkspace, string objectName, esriDatasetType esriDataType, bool resolvConflicts)
        {
            IWorkspaceName fullName;
            IWorkspaceName name2;
            IDatasetName name3;
            IEnumNameMapping mapping;
            if ((sourceWorkspace.Type != esriWorkspaceType.esriFileSystemWorkspace) && (targetWorkspace.Type != esriWorkspaceType.esriFileSystemWorkspace))
            {
                IDataset dataset = (IDataset) sourceWorkspace;
                fullName = (IWorkspaceName) dataset.FullName;
                IDataset dataset2 = (IDataset) targetWorkspace;
                name2 = (IWorkspaceName) dataset2.FullName;
                switch (esriDataType)
                {
                    case esriDatasetType.esriDTFeatureDataset:
                    {
                        IFeatureDatasetName name4 = new FeatureDatasetNameClass();
                        name3 = (IDatasetName) name4;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTFeatureClass:
                    {
                        IFeatureClassName name5 = new FeatureClassNameClass();
                        name3 = (IDatasetName) name5;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTPlanarGraph:
                    case esriDatasetType.esriDTText:
                    case esriDatasetType.esriDTRasterDataset:
                    case esriDatasetType.esriDTRasterBand:
                    case esriDatasetType.esriDTTin:
                    case esriDatasetType.esriDTCadDrawing:
                        return;

                    case esriDatasetType.esriDTGeometricNetwork:
                    {
                        IGeometricNetworkName name7 = new GeometricNetworkNameClass();
                        name3 = (IDatasetName) name7;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTTopology:
                    {
                        ITopologyName name10 = new TopologyNameClass();
                        name3 = (IDatasetName) name10;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTTable:
                    {
                        ITableName name6 = new TableNameClass();
                        name3 = (IDatasetName) name6;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTRelationshipClass:
                    {
                        IRelationshipClassName name8 = new RelationshipClassNameClass();
                        name3 = (IDatasetName) name8;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTRasterCatalog:
                    {
                        IRasterCatalogName name11 = new RasterCatalogNameClass();
                        name3 = (IDatasetName) name11;
                        goto Label_0110;
                    }
                    case esriDatasetType.esriDTNetworkDataset:
                    {
                        INetworkDatasetName name9 = new NetworkDatasetNameClass();
                        name3 = (IDatasetName) name9;
                        goto Label_0110;
                    }
                }
            }
            return;
        Label_0110:
            name3.WorkspaceName = fullName;
            name3.Name = objectName;
            IEnumName from = new NamesEnumeratorClass();
            ((IEnumNameEdit) from).Add((IName) name3);
            IName toName = (IName) name2;
            IGeoDBDataTransfer o = new GeoDBDataTransferClass();
            TaskResult result = new TaskResult {
                Msg = "检测名称冲突...",
                Success = true
            };
            base.FireProgressChangedEvent(-1, result);
            o.GenerateNameMapping(from, toName, out mapping);
            TaskResult result2 = new TaskResult {
                Msg = "解决名称冲突...",
                Success = true
            };
            base.FireProgressChangedEvent(-1, result2);
            if ((mapping != null) && this._wkGdbInfo.IsDataSetNeedReName(objectName))
            {
                mapping.Reset();
                INameMapping mapping2 = null;
                while ((mapping2 = mapping.Next()) != null)
                {
                    if (esriDataType != esriDatasetType.esriDTFeatureDataset)
                    {
                        mapping2.TargetName = mapping2.TargetName + "_" + this._wkGdbInfo.DataYear.ToString();
                    }
                    IEnumNameMapping children = mapping2.Children;
                    if (children != null)
                    {
                        children.Reset();
                        INameMapping mapping4 = null;
                        while ((mapping4 = children.Next()) != null)
                        {
                            mapping4.TargetName = mapping4.TargetName + "_" + this._wkGdbInfo.DataYear.ToString();
                        }
                    }
                }
            }
            TaskResult result3 = new TaskResult {
                Msg = "向目标库中导入数据...",
                Success = true
            };
            base.FireProgressChangedEvent(-1, result3);
            int num = o.NumberObjectsToTransfer(mapping);
            TaskResult result4 = new TaskResult {
                Msg = "共有:" + num + "个要素类需要导入!",
                Success = true
            };
            base.FireProgressChangedEvent(-1, result4);
            o.Transfer(mapping, toName);
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
        }

        private Dictionary<string, esriFieldType> getFields(IFeatureClass pFeatureClass)
        {
            if (pFeatureClass == null)
            {
                return null;
            }
            IFields fields = pFeatureClass.Fields;
            if (fields == null)
            {
                return null;
            }
            int fieldCount = fields.FieldCount;
            if (fieldCount <= 0)
            {
                return null;
            }
            Dictionary<string, esriFieldType> dictionary = new Dictionary<string, esriFieldType>();
            for (int i = 0; i < fieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field != null)
                {
                    string source = field.Name.ToUpper();
                    if (!source.Contains<char>('.') && !source.Contains("SHAPE"))
                    {
                        esriFieldType type = field.Type;
                        dictionary.Add(source, type);
                    }
                }
            }
            return dictionary;
        }

        public static object GetFieldValue(IObject pObj, string sFieldName)
        {
            try
            {
                if (pObj == null)
                {
                    return null;
                }
                int index = pObj.Fields.FindField(sFieldName);
                if (index < 0)
                {
                    return null;
                }
                return pObj.get_Value(index);
            }
            catch
            {
                return null;
            }
        }

        private int loadData(IWorkspace pTargetWks, IWorkspace pSrcWKs, string fcName)
        {
            try
            {
                IDataset dataset = (IDataset) pSrcWKs;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureDatasetName inputFDatasetName = new FeatureDatasetNameClass();
                IDatasetName name3 = (IDatasetName) inputFDatasetName;
                name3.WorkspaceName = fullName;
                name3.Name = fcName;
                IDataset dataset2 = (IDataset) pTargetWks;
                IWorkspaceName name4 = (IWorkspaceName) dataset2.FullName;
                IFeatureDatasetName outputFDatasetName = new FeatureDatasetNameClass();
                IDatasetName name6 = (IDatasetName) outputFDatasetName;
                name6.WorkspaceName = name4;
                name6.Name = fcName;
                IFeatureDataConverter o = new FeatureDataConverterClass();
                o.ConvertFeatureDataset(inputFDatasetName, outputFDatasetName, null, "", 0x3e8, 0);
                Marshal.ReleaseComObject(o);
                o = null;
                if (outputFDatasetName != null)
                {
                    Marshal.ReleaseComObject(outputFDatasetName);
                    outputFDatasetName = null;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int LoadDataToTarget(IWorkspace pTargetWks, IWorkspace pSrcWKs, string fcName)
        {
            if (string.IsNullOrEmpty(fcName))
            {
                return this.LoadForestData(pTargetWks, pSrcWKs);
            }
            return this.loadData(pTargetWks, pSrcWKs, fcName);
        }

        private int LoadFeatureData(IWorkspace pTargetWks, IWorkspace pSrcWks, string fcName, int progress, string dsName, string fcName2)
        {
            Dictionary<string, string> mappedFields;
            if (string.IsNullOrEmpty(fcName2))
            {
                return this.LoadToFeatureClass(pTargetWks, pSrcWks, fcName, progress, dsName);
            }
            IFeatureWorkspace pWs = pTargetWks as IFeatureWorkspace;
            IFeatureClass pFeatureClass = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, fcName);
            if (pFeatureClass == null)
            {
                return -1;
            }
            IFeatureWorkspace workspace2 = pSrcWks as IFeatureWorkspace;
            if (workspace2 == null)
            {
                return -1;
            }
            Dictionary<string, esriFieldType> targetFields = this.getFields(pFeatureClass);
            IFeatureClass class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, fcName2);
            Dictionary<string, esriFieldType> srcFields = null;
            List<string> srcNames = base.GetGeoClassNames(pSrcWks, esriDatasetType.esriDTFeatureClass, dsName);
        Label_0058:
            mappedFields = null;
            if (class3 != null)
            {
                goto Label_0153;
            }
        Label_0062:
            if (this._dataMatchFrm == null)
            {
                this._dataMatchFrm = new ForGeoDataMatchFrm();
                this._dataMatchFrm.WorkSpace = this.pSrcWks;
            }
            this._dataMatchFrm.TryToMatch(fcName, srcNames, srcFields, targetFields);
            if (DialogResult.OK == this._dataMatchFrm.ShowDialog())
            {
                GeoDataMatchResult matchResult = this._dataMatchFrm.MatchResult;
                if (matchResult == null)
                {
                    TaskResult result = new TaskResult {
                        Msg = "未设置数据字段匹配关系，取消数据" + fcName + "中数据的导入!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(progress, result);
                    return -1;
                }
                fcName = matchResult.TargetName;
                mappedFields = matchResult.MappedFields;
            }
            else
            {
                TaskResult result3 = new TaskResult {
                    Msg = "用户取消匹配字段和数据，取消数据" + fcName + "中数据的导入!",
                    Success = true
                };
                base.FireProgressChangedEvent(progress, result3);
                return -1;
            }
            class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(workspace2, fcName);
            if (class3 == null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("未设置数据源，是否退出该图层导入？", "提示", MessageBoxButtons.YesNo))
                {
                    return -1;
                }
                goto Label_0058;
            }
        Label_0153:
            srcFields = this.getFields(class3);
            if (!this.tryMatchFields(targetFields, srcFields))
            {
                goto Label_0062;
            }
            return this.LoadFeatureObjects(class3, pFeatureClass, mappedFields);
        }

        private int LoadFeatureObjects(IFeatureClass pSrcFeatureClass, IFeatureClass pTargetFeatureClass, Dictionary<string, string> mappedFields)
        {
            if ((pSrcFeatureClass != null) && (pTargetFeatureClass != null))
            {
                IFeatureCursor cursor = pSrcFeatureClass.Search(null, false);
                int num = pSrcFeatureClass.FeatureCount(null);
                if (num > 0)
                {
                    int num2 = pTargetFeatureClass.FeatureCount(null);
                    if (num2 == num)
                    {
                        return num2;
                    }
                    if ((num2 > 0) && (num2 != num))
                    {
                        string text1 = string.Concat(new object[] { "目标图层中已经存在了", num2, "个要素，但不等于源数据中：", num, "个要素，请手工处理!" });
                        return num2;
                    }
                    if (cursor == null)
                    {
                        return 0;
                    }
                    try
                    {
                        IFeatureBuffer buffer = pTargetFeatureClass.CreateFeatureBuffer();
                        IFeatureCursor o = pTargetFeatureClass.Insert(true);
                        IFeature pSrcObj = null;
                        int num3 = 0;
                        while ((pSrcObj = cursor.NextFeature()) != null)
                        {
                            buffer.Shape = pSrcObj.ShapeCopy;
                            CopyGeoObject(pSrcObj, (IObject) buffer, mappedFields);
                            o.InsertFeature(buffer);
                            DataLoadInfo result = new DataLoadInfo {
                                Current = num3++,
                                Count = num
                            };
                            base.FireProgressChangedEvent(0, result);
                        }
                        o.Flush();
                        if (buffer != null)
                        {
                            Marshal.ReleaseComObject(buffer);
                            o = null;
                        }
                        if (o != null)
                        {
                            Marshal.ReleaseComObject(o);
                            o = null;
                        }
                        return num3;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return 0;
        }

        private int LoadForestData(IWorkspace pTargetWks, IWorkspace pSrcWKs)
        {
            IEnumDataset dataset = pTargetWks.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            if (dataset == null)
            {
                TaskResult result = new TaskResult {
                    Msg = "目标库中列出名称时未找到需要导入的森林资源数据集!",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result);
                return -1;
            }
            dataset.Reset();
            IDataset dataset2 = dataset.Next();
            int progress = 0x19;
            TaskResult result4 = new TaskResult {
                Msg = "开始数据导入....!",
                Success = true
            };
            base.FireProgressChangedEvent(progress, result4);
            while (dataset2 != null)
            {
                IEnumDataset subsets = dataset2.Subsets;
                if (subsets != null)
                {
                    subsets.Reset();
                    string[] strArray = dataset2.Name.Split(new char[] { '.' });
                    string dsName = strArray[strArray.Length - 1];
                    TaskResult result3 = new TaskResult {
                        Msg = "开始导入数据集：" + dsName + "：中要素类数据",
                        Success = true
                    };
                    base.FireProgressChangedEvent(progress++, result3);
                    for (IDataset dataset4 = subsets.Next(); dataset4 != null; dataset4 = subsets.Next())
                    {
                        if (dataset4.Type == esriDatasetType.esriDTFeatureClass)
                        {
                            strArray = dataset4.Name.ToUpper().Split(new char[] { '.' });
                            string fcName = strArray[strArray.Length - 1];
                            int num2 = this.LoadToFeatureClass(pTargetWks, pSrcWKs, fcName, progress++, dsName);
                            TaskResult result2 = new TaskResult {
                                Msg = string.Concat(new object[] { 
                                    "要素图层:",
                                    fcName,
                                    "导入完成，共导入:",
                                    num2,
                                    "个要素"
                                }),
                                Success = true
                            };
                            base.FireProgressChangedEvent(progress++, result2);
                        }
                    }
                    dataset2 = dataset.Next();
                }
            }
            return -1;
        }

        private void LoadSrcData()
        {
            this.pSrcWks = base.GetGdbTemplateWks("FGDB", this.srcGdbPath);
            if (this._pTargetWorkspace == null)
            {
                TaskResult result = new TaskResult {
                    Msg = "目标地理存储空间不能打开....",
                    Success = false
                };
                base.FireProgressChangedEvent(90, result);
            }
            else if (this.pSrcWks == null)
            {
                TaskResult result2 = new TaskResult {
                    Msg = "源数据地理存储空间不能打开....",
                    Success = false
                };
                base.FireProgressChangedEvent(90, result2);
            }
            else
            {
                this.LoadForestData(this._pTargetWorkspace, this.pSrcWks);
                TaskResult result3 = new TaskResult {
                    Msg = "源数据导入完成，更新系统表....",
                    Success = false
                };
                base.FireProgressChangedEvent(90, result3);
            }
        }

        private int LoadToFeatureClass(IWorkspace pTargetWks, IWorkspace pSrcWks, string fcName, int progress, string dsName)
        {
            Dictionary<string, string> mappedFields;
            IFeatureWorkspace pWs = pTargetWks as IFeatureWorkspace;
            string str = fcName;
            IFeatureClass pFeatureClass = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, fcName);
            if (pFeatureClass == null)
            {
                return -1;
            }
            if (!(pSrcWks is IFeatureWorkspace))
            {
                return -1;
            }
            Dictionary<string, esriFieldType> targetFields = this.getFields(pFeatureClass);
            IFeatureClass class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, fcName);
            Dictionary<string, esriFieldType> srcFields = null;
            List<string> srcNames = base.GetGeoClassNames(pSrcWks, esriDatasetType.esriDTFeatureClass, dsName);
        Label_0043:
            mappedFields = null;
            if (class3 != null)
            {
                goto Label_0146;
            }
        Label_004D:
            if (this._dataMatchFrm == null)
            {
                this._dataMatchFrm = new ForGeoDataMatchFrm();
                this._dataMatchFrm.WorkSpace = this.pSrcWks;
            }
            this._dataMatchFrm.TryToMatch(fcName, srcNames, srcFields, targetFields);
            this._dataMatchFrm.ShowDialog();
            GeoDataMatchResult matchResult = this._dataMatchFrm.MatchResult;
            if (matchResult == null)
            {
                TaskResult result = new TaskResult {
                    Msg = "未设置数据字段匹配关系，取消数据导入!",
                    Success = true
                };
                base.FireProgressChangedEvent(progress, result);
                return 0;
            }
            fcName = matchResult.TargetName;
            mappedFields = matchResult.MappedFields;
            if ((string.IsNullOrEmpty(fcName) || (mappedFields == null)) || (mappedFields.Count <= 0))
            {
                TaskResult result3 = new TaskResult {
                    Msg = "未设置目标图层，取消向：" + str + "中导入数据!",
                    Success = true
                };
                base.FireProgressChangedEvent(progress, result3);
                return 0;
            }
            class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, fcName);
            if (class3 == null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("未设置数据源，是否退出该图层导入？", "提示", MessageBoxButtons.YesNo))
                {
                    return -1;
                }
                goto Label_0043;
            }
        Label_0146:
            srcFields = this.getFields(class3);
            if ((mappedFields == null) && !this.tryMatchFields(targetFields, srcFields))
            {
                goto Label_004D;
            }
            return this.LoadFeatureObjects(class3, pFeatureClass, mappedFields);
        }

        public override bool StopTask()
        {
            try
            {
                if (base._dsAdmin != null)
                {
                    Marshal.ReleaseComObject(base._dsAdmin);
                    base._dsAdmin = null;
                }
                if (this._pTargetWorkspace != null)
                {
                    Marshal.ReleaseComObject(this._pTargetWorkspace);
                    this._pTargetWorkspace = null;
                }
                if (this.pSrcWks != null)
                {
                    Marshal.ReleaseComObject(this.pSrcWks);
                    this.pSrcWks = null;
                }
            }
            catch (Exception)
            {
            }
            return base.StopTask();
        }

        private void tryImport(string dbType, string dbName)
        {
            if (string.IsNullOrEmpty(dbType) || string.IsNullOrEmpty(dbName))
            {
                TaskResult result = new TaskResult {
                    Msg = "由于给定参数不够，只生成了空数据库未导入模板数据",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result);
                this.StopTask();
            }
            else
            {
                IWorkspace gdbTemplateWks = base.GetGdbTemplateWks(dbType, dbName);
                if (gdbTemplateWks == null)
                {
                    TaskResult result2 = new TaskResult {
                        Msg = "模板数据库地理空间打开失败，只生成了空数据库未导入模板数据",
                        Success = true
                    };
                    base.FireProgressChangedEvent(100, result2);
                    this.StopTask();
                }
                else if (this._pTargetWorkspace == null)
                {
                    TaskResult result3 = new TaskResult {
                        Msg = "目标数据库地理空间打开失败，只生成了空数据库未导入模板数据",
                        Success = true
                    };
                    base.FireProgressChangedEvent(100, result3);
                    this.StopTask();
                }
                else
                {
                    List<string> noNeedNames = this.ExpTmplToNewGDB(gdbTemplateWks, this._pTargetWorkspace, esriDatasetType.esriDTFeatureDataset, null);
                    TaskResult result12 = new TaskResult {
                        Msg = "要素集模板导入完成！",
                        Success = true
                    };
                    base.FireProgressChangedEvent(50, result12);
                    try
                    {
                        this.ExpTmplToNewGDB(gdbTemplateWks, this._pTargetWorkspace, esriDatasetType.esriDTFeatureClass, noNeedNames);
                        TaskResult result4 = new TaskResult {
                            Msg = "要素模板导入完成！",
                            Success = true
                        };
                        base.FireProgressChangedEvent(60, result4);
                    }
                    catch (Exception)
                    {
                        TaskResult result5 = new TaskResult {
                            Msg = "要素模板导入失败！",
                            Success = false
                        };
                        base.FireProgressChangedEvent(60, result5);
                    }
                    try
                    {
                        this.ExpTmplToNewGDB(gdbTemplateWks, this._pTargetWorkspace, esriDatasetType.esriDTTable, noNeedNames);
                        TaskResult result6 = new TaskResult {
                            Msg = "表格模板导入完成！",
                            Success = true
                        };
                        base.FireProgressChangedEvent(80, result6);
                    }
                    catch (Exception)
                    {
                        TaskResult result7 = new TaskResult {
                            Msg = "表格模板导入失败！",
                            Success = false
                        };
                        base.FireProgressChangedEvent(60, result7);
                    }
                    try
                    {
                        this.ExpTmplToNewGDB(gdbTemplateWks, this._pTargetWorkspace, esriDatasetType.esriDTRasterCatalog, null);
                        TaskResult result8 = new TaskResult {
                            Msg = "栅格要素集模板导入完成！",
                            Success = true
                        };
                        base.FireProgressChangedEvent(60, result8);
                    }
                    catch (Exception)
                    {
                        TaskResult result9 = new TaskResult {
                            Msg = "栅格要素集模板导入失败！",
                            Success = false
                        };
                        base.FireProgressChangedEvent(60, result9);
                    }
                    if (!string.IsNullOrEmpty(this.srcGdbPath))
                    {
                        try
                        {
                            this.pSrcWks = base.GetGdbTemplateWks("FGDB", this.srcGdbPath);
                            if (this._pTargetWorkspace == null)
                            {
                                TaskResult result10 = new TaskResult {
                                    Msg = "目标地理存储空间不能打开....",
                                    Success = false
                                };
                                base.FireProgressChangedEvent(90, result10);
                                return;
                            }
                            if (this.pSrcWks == null)
                            {
                                TaskResult result11 = new TaskResult {
                                    Msg = "源数据地理存储空间不能打开....",
                                    Success = false
                                };
                                base.FireProgressChangedEvent(90, result11);
                                return;
                            }
                            this.LoadForestData(this._pTargetWorkspace, this.pSrcWks);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (gdbTemplateWks == null)
                    {
                        Marshal.ReleaseComObject(gdbTemplateWks);
                        gdbTemplateWks = null;
                    }
                }
            }
        }

        private bool tryMatchFields(Dictionary<string, esriFieldType> srcFields, Dictionary<string, esriFieldType> targetFields)
        {
            if ((srcFields == null) || (targetFields == null))
            {
                return false;
            }
            if (targetFields.Count != srcFields.Count)
            {
                return false;
            }
            foreach (string str in srcFields.Keys)
            {
                if (!str.Contains<char>('.') && (srcFields[str] != targetFields[str]))
                {
                    return false;
                }
            }
            return true;
        }

        protected bool UpdateGDBToForest(string keyText)
        {
            string str = this._wkGdbInfo.GDBServer.Split(new char[] { '\\' })[0];
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            using (SqlConnection connection = ForestGDBTask.CreateConnection(str, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
            {
                connection.Open();
                TaskResult result = new TaskResult {
                    Msg = "更新空间数据存储类型....",
                    Success = true
                };
                base.FireProgressChangedEvent(40, result);
                string str2 = string.Format("UPDATE [{0}].[dbo].[SDE_dbtune] SET config_string='GEOMETRY' WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", this._wkGdbInfo.DBName);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = str2;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
                TaskResult result2 = new TaskResult {
                    Msg = "更新空间数据存储类型更新完成!",
                    Success = true
                };
                base.FireProgressChangedEvent(50, result2);
                TaskResult result3 = new TaskResult {
                    Msg = "更新空间数据库授权方式.....",
                    Success = true
                };
                base.FireProgressChangedEvent(50, result3);
                if (string.IsNullOrEmpty(keyText))
                {
                    keyText = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";
                }
                string str3 = string.Format("UPDATE [{0}].[dbo].[SDE_server_config] set char_prop_value='{1}' WHERE prop_name='AUTH_KEY'", this._wkGdbInfo.DBName, keyText);
                SqlCommand command2 = connection.CreateCommand();
                command2.CommandText = str3;
                command2.ExecuteNonQuery();
                command2.Dispose();
                command2 = null;
                TaskResult result4 = new TaskResult {
                    Msg = "更新空间数据库授权方式.....完成！",
                    Success = true
                };
                base.FireProgressChangedEvent(0x37, result4);
                try
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception)
                {
                }
                TaskResult result5 = new TaskResult {
                    Msg = "空间数据库注册和配置信息更新完成!",
                    Success = true
                };
                base.FireProgressChangedEvent(60, result5);
                return true;
            }
        }

        private void UpdateSysTableInfo()
        {
            if (((this._wkGdbInfo != null) && (this._wkGdbInfo.UpdateMetaInfos != null)) && (this._wkGdbInfo.UpdateMetaInfos.Count > 0))
            {
                using (SqlConnection connection = ForestGDBTask.CreateConnection(this._wkGdbInfo.ServerName, this._wkGdbInfo.UserName, this._wkGdbInfo.UserPass, this._wkGdbInfo.DBName))
                {
                    try
                    {
                        connection.Open();
                        foreach (string str in this._wkGdbInfo.UpdateMetaInfos)
                        {
                            string str2 = string.Format("UPDATE T_SYS_META_TABLE SET TAB_NAME='{0}_{1}' WHERE TAB_NAME LIKE '{0}%'", str, this._wkGdbInfo.DataYear.ToString());
                            SqlCommand command = connection.CreateCommand();
                            command.CommandText = str2;
                            command.ExecuteNonQuery();
                            command.Dispose();
                            command = null;
                        }
                        string str3 = string.Format("UPDATE T_SYS_META_TABLE SET TAB_NAME=TAB_NAME+'_{0}' WHERE TAB_ID = 'T00200100001'", this._wkGdbInfo.DataYear - 1);
                        SqlCommand command2 = connection.CreateCommand();
                        command2.CommandText = str3;
                        command2.ExecuteNonQuery();
                        command2.Dispose();
                        command2 = null;
                        str3 = string.Format("UPDATE T_SYS_META_TABLE SET TAB_NAME=TAB_NAME+'_{0}' WHERE TAB_ID = 'T00200100002'", this._wkGdbInfo.DataYear);
                        command2 = connection.CreateCommand();
                        command2.CommandText = str3;
                        command2.ExecuteNonQuery();
                        command2.Dispose();
                        command2 = null;
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                    TaskResult result = new TaskResult {
                        Msg = "数据库元数据更新完成!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(0x5f, result);
                }
            }
        }

        public override object Work(params object[] args)
        {
            base.Work(args);
            if ((args == null) || (args.Length <= 0))
            {
                this.StopTask();
                return null;
            }
            this._wkGdbInfo = args[0] as ForestGDBInfo;
            if (this._wkGdbInfo != null)
            {
                string keyText = string.Empty;
                string dbType = string.Empty;
                string dbName = string.Empty;
                if (args.Length >= 2)
                {
                    keyText = args[1] as string;
                }
                if (args.Length >= 4)
                {
                    dbType = args[2] as string;
                    dbName = args[3] as string;
                }
                this.srcGdbPath = (args.Length >= 5) ? (args[4] as string) : string.Empty;
                base.initDSAdmin(this._wkGdbInfo.GDBServer);
                if (base.IsGDBExists(this._wkGdbInfo.DBName))
                {
                    this._pTargetWorkspace = base.OpenWorkSpace(this._wkGdbInfo.DBName, string.Empty);
                    this.LoadSrcData();
                }
                else
                {
                    this.CreateNewGDB(keyText);
                    string str4 = (args.Length >= 6) ? (args[5] as string) : "false";
                    bool flag = str4.CompareTo("true") == 0;
                    this._pTargetWorkspace = base.OpenWorkSpace(this._wkGdbInfo.DBName, string.Empty);
                    if (flag)
                    {
                        this.tryImport(dbType, dbName);
                    }
                }
                this.UpdateSysTableInfo();
                this.CreateSysTable();
                TaskResult result = new TaskResult {
                    Msg = "数据导入完成,任务处理结束!",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result);
                this.StopTask();
            }
            return null;
        }

        public delegate void GetDataFieldNamesHandler(object sender, Dictionary<string, esriFieldType> fields);
    }
}

