namespace GDB.SQLServerExpress
{
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Runtime.InteropServices;

    public sealed class ForestGDBWorkSpaceUtil
    {
        public static string ConvertFeatureClass(IWorkspace pSourceWs, IWorkspace pTargetWs, string sSourceName, string sTargetName, IQueryFilter pQueryFilter)
        {
            string message = "";
            try
            {
                if (pSourceWs == null)
                {
                    return message;
                }
                if (pTargetWs == null)
                {
                    return message;
                }
                if (sSourceName == "")
                {
                    return message;
                }
                if (sTargetName == "")
                {
                    sTargetName = sSourceName;
                }
                IDataset dataset = (IDataset) pSourceWs;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureClassName inputDatasetName = new FeatureClassNameClass();
                IDatasetName name3 = (IDatasetName) inputDatasetName;
                name3.Name = sSourceName;
                name3.WorkspaceName = fullName;
                IDataset dataset2 = (IDataset) pTargetWs;
                IWorkspaceName name4 = (IWorkspaceName) dataset2.FullName;
                IFeatureClassName outputFClassName = new FeatureClassNameClass();
                IDatasetName name6 = (IDatasetName) outputFClassName;
                name6.Name = sTargetName;
                name6.WorkspaceName = name4;
                IName name7 = (IName) inputDatasetName;
                IFeatureClass class2 = (IFeatureClass) name7.Open();
                IFieldChecker checker = new FieldCheckerClass();
                IFields fixedFields = null;
                IFields fields = class2.Fields;
                IEnumFieldError error = null;
                checker.InputWorkspace = pSourceWs;
                checker.ValidateWorkspace = pTargetWs;
                checker.Validate(fields, out error, out fixedFields);
                int index = class2.FindField(class2.ShapeFieldName);
                IGeometryDef geometryDef = class2.Fields.get_Field(index).GeometryDef;
                for (int i = 0; i < fixedFields.FieldCount; i++)
                {
                    if (fixedFields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        IField field = fixedFields.get_Field(i);
                        IGeometryDef outputGeometryDef = field.GeometryDef;
                        IGeometryDefEdit edit = (IGeometryDefEdit) outputGeometryDef;
                      //  edit.GridCount = geometryDef.GridCount;
                        for (int j = 0; j < geometryDef.GridCount; j++)
                        {
                            edit.set_GridSize(j, geometryDef.get_GridSize(j));
                        }
                      //  edit.SpatialReference = field.GeometryDef.SpatialReference;
                        IFeatureDataConverter converter = new FeatureDataConverterClass();
                        IEnumInvalidObject obj2 = converter.ConvertFeatureClass(inputDatasetName, pQueryFilter, null, outputFClassName, outputGeometryDef, fixedFields, "", 0x3e8, 0);
                        converter = null;
                        obj2.Reset();
                        IInvalidObjectInfo info = obj2.Next();
                        if (info != null)
                        {
                            message = "导出以下要素时出错: ";
                        }
                        while (info != null)
                        {
                            message = message + info.InvalidObjectID + "\n";
                            info = obj2.Next();
                        }
                        return message;
                    }
                }
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
        }

        public static bool ConvertFeatureDataset(IWorkspace pSourceWS, IWorkspace pTargetWS, string sSourceName, string sTargetName)
        {
            if ((pSourceWS == null) || (pTargetWS == null))
            {
                return false;
            }
            if (sSourceName == "")
            {
                return false;
            }
            if (sTargetName == "")
            {
                sTargetName = sSourceName;
            }
            try
            {
                IDataset dataset = (IDataset) pSourceWS;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureDatasetName inputFDatasetName = new FeatureDatasetNameClass();
                IDatasetName name3 = (IDatasetName) inputFDatasetName;
                name3.WorkspaceName = fullName;
                name3.Name = sSourceName;
                IDataset dataset2 = (IDataset) pTargetWS;
                IWorkspaceName name4 = (IWorkspaceName) dataset2.FullName;
                IFeatureDatasetName outputFDatasetName = new FeatureDatasetNameClass();
                IDatasetName name6 = (IDatasetName) outputFDatasetName;
                name6.WorkspaceName = name4;
                name6.Name = sTargetName;
                IFeatureDataConverter o = new FeatureDataConverterClass();
                o.ConvertFeatureDataset(inputFDatasetName, outputFDatasetName, null, "", 0x3e8, 0);
                Marshal.ReleaseComObject(o);
                o = null;
                if (outputFDatasetName != null)
                {
                    Marshal.ReleaseComObject(outputFDatasetName);
                    outputFDatasetName = null;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ConvertTable(IWorkspace pSourceWs, IWorkspace pTargetWs, string sSourceName, string sTargetName, IQueryFilter pQueryFilter)
        {
            string message = string.Empty;
            try
            {
                if (pSourceWs == null)
                {
                    return message;
                }
                if (pTargetWs == null)
                {
                    return message;
                }
                if (sSourceName == "")
                {
                    return message;
                }
                if (sTargetName == "")
                {
                    int index = sSourceName.IndexOf(".");
                    if (index >= 0)
                    {
                        sTargetName = sSourceName.Substring(index + 1);
                    }
                    else
                    {
                        sTargetName = sSourceName;
                    }
                }
                IDataset dataset = (IDataset) pSourceWs;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                ITableName name2 = new TableNameClass();
                IDatasetName inputDatasetName = (IDatasetName) name2;
                inputDatasetName.Name = sSourceName;
                inputDatasetName.WorkspaceName = fullName;
                IDataset dataset2 = (IDataset) pTargetWs;
                IWorkspaceName name4 = (IWorkspaceName) dataset2.FullName;
                ITableName name5 = new TableNameClass();
                IDatasetName outputDatasetName = (IDatasetName) name5;
                outputDatasetName.Name = sTargetName;
                outputDatasetName.WorkspaceName = name4;
                IName name7 = name2 as IName;
                ITable table = name7.Open() as ITable;
                IFieldChecker checker = new FieldCheckerClass();
                IFields fixedFields = null;
                IFields fields = table.Fields;
                IEnumFieldError error = null;
                checker.InputWorkspace = pSourceWs;
                checker.ValidateWorkspace = pTargetWs;
                checker.Validate(fields, out error, out fixedFields);
                IFeatureDataConverter converter = new FeatureDataConverterClass();
                IEnumInvalidObject obj2 = converter.ConvertTable(inputDatasetName, pQueryFilter, outputDatasetName, fixedFields, "", 0x3e8, 0);
                converter = null;
                obj2.Reset();
                IInvalidObjectInfo info = obj2.Next();
                if (info != null)
                {
                    message = "导出以下要素时出错: ";
                }
                while (info != null)
                {
                    message = message + info.InvalidObjectID + "\n";
                    info = obj2.Next();
                }
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
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
                            pTargObj.set_Value(i, fieldValue);
                        }
                    }
                    pTargObj.Store();
                }
                catch
                {
                }
            }
        }

        public static IWorkspace CreateDBFile(string sFullPath)
        {
            try
            {
                string str2;
                string str3;
                IWorkspaceFactory factory;
                IWorkspaceName name;
                int num = sFullPath.LastIndexOf('.');
                if (num >= 0)
                {
                    string str = sFullPath.Substring(num + 1);
                    int num2 = sFullPath.LastIndexOf('\\');
                    str2 = sFullPath.Substring(0, num2 + 1);
                    str3 = sFullPath.Substring(num2 + 1);
                    factory = null;
                    name = null;
                    if (str.ToLower() == "mdb")
                    {
                        factory = new AccessWorkspaceFactoryClass();
                        goto Label_007F;
                    }
                    if (str.ToLower() == "gdb")
                    {
                        factory = new FileGDBWorkspaceFactoryClass();
                        goto Label_007F;
                    }
                }
                return null;
            Label_007F:
                name = factory.Create(str2, str3, null, 0);
                IName o = (IName) name;
                IWorkspace workspace = (IWorkspace) o.Open();
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(name);
                Marshal.ReleaseComObject(factory);
                return workspace;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IFeatureClass CreateFeatureClass(IFeatureDataset pFDataset, IFeatureClass pTemlFClass, string sFCName)
        {
            if (pFDataset == null)
            {
                return null;
            }
            if (pTemlFClass == null)
            {
                return null;
            }
            try
            {
                IFeatureClassDescription description = new FeatureClassDescriptionClass();
                IObjectClassDescription description2 = (IObjectClassDescription) description;
                return pFDataset.CreateFeatureClass(sFCName, pTemlFClass.Fields, description2.InstanceCLSID, description2.ClassExtensionCLSID, esriFeatureType.esriFTSimple, "Shape", "");
            }
            catch
            {
                return null;
            }
        }

        public static ITable CreateTable(IFeatureWorkspace pFWorkspace, ITable pTemlTable, string sTName)
        {
            if (pFWorkspace == null)
            {
                return null;
            }
            if (pTemlTable == null)
            {
                return null;
            }
            try
            {
                UID cLSID = new UIDClass {
                    Value = "esriGeoDatabase.Object"
                };
                return pFWorkspace.CreateTable(sTName, pTemlTable.Fields, cLSID, null, "");
            }
            catch
            {
                return null;
            }
        }

        public static void GDBToNewGDB2(IWorkspace sourceWorkspace, IWorkspace targetWorkspace, string objectName, esriDatasetType esriDataType, bool resolvConflicts)
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
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTFeatureClass:
                    {
                        IFeatureClassName name5 = new FeatureClassNameClass();
                        name3 = (IDatasetName) name5;
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTPlanarGraph:
                    case esriDatasetType.esriDTText:
                        return;

                    case esriDatasetType.esriDTGeometricNetwork:
                    {
                        IGeometricNetworkName name7 = new GeometricNetworkNameClass();
                        name3 = (IDatasetName) name7;
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTTopology:
                    {
                        ITopologyName name10 = new TopologyNameClass();
                        name3 = (IDatasetName) name10;
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTTable:
                    {
                        ITableName name6 = new TableNameClass();
                        name3 = (IDatasetName) name6;
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTRelationshipClass:
                    {
                        IRelationshipClassName name8 = new RelationshipClassNameClass();
                        name3 = (IDatasetName) name8;
                        goto Label_00E9;
                    }
                    case esriDatasetType.esriDTNetworkDataset:
                    {
                        INetworkDatasetName name9 = new NetworkDatasetNameClass();
                        name3 = (IDatasetName) name9;
                        goto Label_00E9;
                    }
                }
            }
            return;
        Label_00E9:
            name3.WorkspaceName = fullName;
            name3.Name = objectName;
            IEnumName from = new NamesEnumeratorClass();
            ((IEnumNameEdit) from).Add((IName) name3);
            IName toName = (IName) name2;
            IGeoDBDataTransfer2 o = new GeoDBDataTransferClass();
            bool flag = o.GenerateNameMapping(from, toName, out mapping);
            if (resolvConflicts && flag)
            {
                INameMapping mapping2 = null;
                while ((mapping2 = mapping.Next()) != null)
                {
                    if (mapping2.NameConflicts)
                    {
                        mapping2.TargetName = mapping2.GetSuggestedName(toName);
                    }
                    IEnumNameMapping children = mapping2.Children;
                    if (children != null)
                    {
                        children.Reset();
                        INameMapping mapping4 = null;
                        while ((mapping4 = children.Next()) != null)
                        {
                            if (mapping4.NameConflicts)
                            {
                                mapping4.TargetName = mapping4.GetSuggestedName(toName);
                            }
                        }
                    }
                }
            }
            o.Transfer(mapping, toName);
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
        }

        public static List<string> GetAllDataBase(string ip, string username, string password)
        {
            List<string> list = new List<string>();
            SqlConnection selectConnection = new SqlConnection(string.Format("Data Source={0};Initial Catalog = master;User ID = {1};PWD = {2}", ip, username, password));
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select name from master..sysdatabases", selectConnection);
            lock (adapter)
            {
                adapter.Fill(dataTable);
            }
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(row["name"] as string);
            }
            return list;
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
                    return false;
                }
                return pObj.get_Value(index);
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetItemNames(IWorkspace pWks, esriDatasetType esriType)
        {
            List<string> list = new List<string>();
            IEnumDataset o = pWks.get_Datasets(esriType);
            if (o != null)
            {
                o.Reset();
                for (IDataset dataset2 = o.Next(); dataset2 != null; dataset2 = o.Next())
                {
                    if ((dataset2.Type == esriDatasetType.esriDTFeatureClass) || (dataset2.Type == esriDatasetType.esriDTFeatureDataset))
                    {
                        if (dataset2.Subsets == null)
                        {
                            string item = dataset2.Name.ToUpper();
                            item = item.Substring(item.LastIndexOf('.') + 1);
                            list.Add(item);
                        }
                        else
                        {
                            IEnumDataset subsets = dataset2.Subsets;
                            subsets.Reset();
                            for (IDataset dataset4 = subsets.Next(); dataset4 != null; dataset4 = subsets.Next())
                            {
                                if (dataset4.Type == esriDatasetType.esriDTFeatureClass)
                                {
                                    string str2 = dataset4.Name.ToUpper();
                                    str2 = str2.Substring(str2.LastIndexOf('.') + 1);
                                    list.Add(str2);
                                }
                            }
                            if (subsets != null)
                            {
                                Marshal.ReleaseComObject(subsets);
                                subsets = null;
                            }
                        }
                    }
                    else
                    {
                        string str3 = dataset2.Name.ToUpper();
                        str3 = str3.Substring(str3.LastIndexOf('.') + 1);
                        list.Add(str3);
                    }
                    Marshal.ReleaseComObject(dataset2);
                    dataset2 = null;
                }
                if (o != null)
                {
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            return list;
        }

        public static Dictionary<string, esriDatasetType> GetItemNames(IWorkspace pWorkspace, bool isListDataSet)
        {
            Dictionary<string, esriDatasetType> dictionary = new Dictionary<string, esriDatasetType>();
            IEnumDataset o = pWorkspace.get_Datasets(esriDatasetType.esriDTAny);
            if (o != null)
            {
                o.Reset();
                for (IDataset dataset2 = o.Next(); dataset2 != null; dataset2 = o.Next())
                {
                    if ((dataset2.Type == esriDatasetType.esriDTFeatureClass) || (dataset2.Type == esriDatasetType.esriDTFeatureDataset))
                    {
                        if (dataset2.Subsets == null)
                        {
                            string key = dataset2.Name.ToUpper();
                            key = key.Substring(key.LastIndexOf('.') + 1);
                            dictionary.Add(key, dataset2.Type);
                        }
                        else if (isListDataSet)
                        {
                            IEnumDataset subsets = dataset2.Subsets;
                            subsets.Reset();
                            for (IDataset dataset4 = subsets.Next(); dataset4 != null; dataset4 = subsets.Next())
                            {
                                if (dataset4.Type == esriDatasetType.esriDTFeatureClass)
                                {
                                    string str2 = dataset4.Name.ToUpper();
                                    str2 = str2.Substring(str2.LastIndexOf('.') + 1);
                                    dictionary.Add(str2, dataset4.Type);
                                }
                            }
                            if (subsets != null)
                            {
                                Marshal.ReleaseComObject(subsets);
                                subsets = null;
                            }
                        }
                        else
                        {
                            string str3 = dataset2.Name.ToUpper();
                            str3 = str3.Substring(str3.LastIndexOf('.') + 1);
                            dictionary.Add(str3, dataset2.Type);
                        }
                    }
                    else
                    {
                        string str4 = dataset2.Name.ToUpper();
                        str4 = str4.Substring(str4.LastIndexOf('.') + 1);
                        dictionary.Add(str4, dataset2.Type);
                    }
                    Marshal.ReleaseComObject(dataset2);
                    dataset2 = null;
                }
                if (o != null)
                {
                    Marshal.ReleaseComObject(o);
                    o = null;
                }
            }
            return dictionary;
        }

        public static IWorkspace GetWorkspace(string sSourceFile)
        {
            try
            {
                if ((string.IsNullOrEmpty(sSourceFile) | !File.Exists(sSourceFile)) & (string.IsNullOrEmpty(sSourceFile) | !Directory.Exists(sSourceFile)))
                {
                    return null;
                }
                int num = sSourceFile.LastIndexOf('\\');
                int num2 = sSourceFile.LastIndexOf('.');
                string str = "";
                if ((num2 < 0) || (num > num2))
                {
                    str = "shp";
                }
                else
                {
                    str = sSourceFile.Substring(num2 + 1);
                }
                IWorkspaceFactory o = null;
                if (str.ToLower() == "mdb")
                {
                    o = new AccessWorkspaceFactoryClass();
                }
                else if (str.ToLower() == "gdb")
                {
                    o = new FileGDBWorkspaceFactoryClass();
                }
                else if (str.ToLower() == "shp")
                {
                    o = new ShapefileWorkspaceFactoryClass();
                }
                else
                {
                    return null;
                }
                if (!o.IsWorkspace(sSourceFile))
                {
                    return null;
                }
                IWorkspace workspace = o.OpenFromFile(sSourceFile, 0);
                Marshal.ReleaseComObject(o);
                o = null;
                return workspace;
            }
            catch
            {
                return null;
            }
        }

        public static bool IsGDBOnline(IWorkspace pWks)
        {
            IWorkspaceFactoryStatus o = new SdeWorkspaceFactoryClass();
            bool flag = o.PingWorkspaceStatus(pWks).ConnectionStatus == esriWorkspaceConnectionStatus.esriWCSUp;
            Marshal.ReleaseComObject(o);
            o = null;
            return flag;
        }

        public static bool LoadFeatureClass(IFeatureClass pSrcFClass, IFeatureClass pTargFClass)
        {
            if (pSrcFClass == null)
            {
                return true;
            }
            if (pTargFClass == null)
            {
                return false;
            }
            try
            {
                IFeatureCursor o = pSrcFClass.Search(null, false);
                if (o != null)
                {
                    try
                    {
                        IFeatureBuffer buffer = pTargFClass.CreateFeatureBuffer();
                        IFeatureCursor cursor2 = pTargFClass.Insert(true);
                        IFeature pSrcObj = null;
                        IDataset dataset = (IDataset) pTargFClass;
                        IWorkspace workspace = dataset.Workspace;
                        string name = dataset.Name;
                        int index = name.IndexOf(".");
                        if (index > 0)
                        {
                            name = name.Substring(index + 1);
                        }
                        string str2 = Guid.NewGuid().ToString().Replace("-", "");
                        DateTime now = DateTime.Now;
                        while ((pSrcObj = o.NextFeature()) != null)
                        {
                            buffer.Shape = pSrcObj.ShapeCopy;
                            CopyGeoObject(pSrcObj, (IObject) buffer);
                            cursor2.InsertFeature(buffer);
                        }
                        cursor2.Flush();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    Marshal.ReleaseComObject(o);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool LoadFeatureClass(IFeatureClass pSrcFClass, IFeatureClass pTargFClass, string fieldName, string value)
        {
            if (pSrcFClass == null)
            {
                return true;
            }
            if (pTargFClass == null)
            {
                return false;
            }
            try
            {
                IFeatureCursor o = pSrcFClass.Search(null, false);
                if (o != null)
                {
                    try
                    {
                        IFeatureBuffer buffer = pTargFClass.CreateFeatureBuffer();
                        IFeatureCursor cursor2 = pTargFClass.Insert(true);
                        IFeature pSrcObj = null;
                        IDataset dataset = (IDataset) pTargFClass;
                        IWorkspace workspace = dataset.Workspace;
                        string name = dataset.Name;
                        int index = name.IndexOf(".");
                        if (index > 0)
                        {
                            name = name.Substring(index + 1);
                        }
                        string str2 = Guid.NewGuid().ToString().Replace("-", "");
                        DateTime now = DateTime.Now;
                        while ((pSrcObj = o.NextFeature()) != null)
                        {
                            buffer.Shape = pSrcObj.ShapeCopy;
                            CopyGeoObject(pSrcObj, (IObject) buffer);
                            UpdateFieldValue((IObject) buffer, fieldName, value);
                            cursor2.InsertFeature(buffer);
                        }
                        cursor2.Flush();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    Marshal.ReleaseComObject(o);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IFeatureClass OpenFeatureClass(IFeatureWorkspace pWs, string sName)
        {
            if (pWs == null)
            {
                return null;
            }
            try
            {
                return pWs.OpenFeatureClass(sName);
            }
            catch
            {
                return null;
            }
        }

        public static ITable OpenTable(IFeatureWorkspace pWs, string sName)
        {
            if (pWs == null)
            {
                return null;
            }
            try
            {
                return pWs.OpenTable(sName);
            }
            catch
            {
                return null;
            }
        }

        public static void UpdateFieldValue(IObject pObj, string sFieldName, object pValue)
        {
            if (pObj != null)
            {
                try
                {
                    int index = pObj.Fields.FindField(sFieldName);
                    if ((index >= 0) && pObj.Fields.get_Field(index).Editable)
                    {
                        pObj.set_Value(index, pValue);
                    }
                }
                catch
                {
                }
            }
        }

        public static void WriteLog(string user, string status, string featureClassName, IWorkspace pWorkspace, IFeature feature, string glid, DateTime time)
        {
            if ((glid == null) || glid.Equals(""))
            {
                glid = Guid.NewGuid().ToString();
                glid = glid.Replace("-", "");
            }
            try
            {
                string sName = featureClassName + "_LOG";
                IFeatureWorkspace pWs = (IFeatureWorkspace) pWorkspace;
                IFeatureClass class2 = OpenFeatureClass(pWs, sName);
                if (class2 != null)
                {
                    try
                    {
                        IFeatureBuffer buffer = class2.CreateFeatureBuffer();
                        IFeatureCursor o = class2.Insert(true);
                        buffer.Shape = feature.ShapeCopy;
                        CopyGeoObject(feature, (IObject) buffer);
                        UpdateFieldValue((IObject) buffer, "GLID", glid);
                        UpdateFieldValue((IObject) buffer, "CZY", user);
                        UpdateFieldValue((IObject) buffer, "CZTIME", time);
                        UpdateFieldValue((IObject) buffer, "CZ_STATUS", status);
                        o.InsertFeature(buffer);
                        o.Flush();
                        Marshal.ReleaseComObject(o);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

