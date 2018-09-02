namespace GeoDataIE
{
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class ConvertData
    {
        public static string ConvertFeatureClass(IWorkspace pSourceWS, IFeatureClass pSourceFC, IWorkspace pTargetWS, string sTargetName, IQueryFilter pQueryFilter)
        {
            string message = string.Empty;
            try
            {
                if (pSourceWS == null)
                {
                    return message;
                }
                if (pSourceFC == null)
                {
                    return message;
                }
                if (pTargetWS == null)
                {
                    return message;
                }
                string name = ((IDataset) pSourceFC).Name;
                if (sTargetName == "")
                {
                    sTargetName = name + "_Export";
                }
                IDataset dataset = (IDataset) pSourceWS;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureClassName inputDatasetName = new FeatureClassNameClass();
                IDatasetName name4 = (IDatasetName) inputDatasetName;
                name4.Name = name;
                name4.WorkspaceName = fullName;
                IDataset dataset2 = (IDataset) pTargetWS;
                IWorkspaceName name6 = (IWorkspaceName) dataset2.FullName;
                IFeatureClassName outputFClassName = new FeatureClassNameClass();
                IDatasetName name8 = (IDatasetName) outputFClassName;
                name8.Name = sTargetName;
                name8.WorkspaceName = name6;
                IFieldChecker checker = new FieldCheckerClass();
                IFields inputField = pSourceFC.Fields;
                IFields fixedFields = null;
                IEnumFieldError error = null;
                checker.InputWorkspace = pSourceWS;
                checker.ValidateWorkspace = pTargetWS;
                checker.Validate(inputField, out error, out fixedFields);
                string shapeFieldName = pSourceFC.ShapeFieldName;
                int index = pSourceFC.FindField(shapeFieldName);
                IClone geometryDef = (IClone) inputField.get_Field(index).GeometryDef;
                IGeometryDef outputGeometryDef = (IGeometryDef) geometryDef.Clone();
                IFeatureDataConverter converter = new FeatureDataConverterClass();
                IEnumInvalidObject obj2 = converter.ConvertFeatureClass(inputDatasetName, pQueryFilter, null, outputFClassName, outputGeometryDef, fixedFields, "", 0x3e8, 0);
                IInvalidObjectInfo info = null;
                obj2.Reset();
                info = obj2.Next();
                if (info != null)
                {
                    message = "Errors occurred for the following feature: ";
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
                    sTargetName = sSourceName;
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

        public static bool CopyPasteGeodatabaseData(IWorkspace sourceWorkspace, IDataset pDataset, string objectName, esriDatasetType esriDataType)
        {
            if (sourceWorkspace.Type == esriWorkspaceType.esriFileSystemWorkspace)
            {
                return false;
            }
            try
            {
                IDatasetName name3;
                IEnumNameMapping mapping;
                IDataset dataset = (IDataset) sourceWorkspace;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureDatasetName name2 = (IFeatureDatasetName) pDataset.FullName;
                switch (esriDataType)
                {
                    case esriDatasetType.esriDTFeatureDataset:
                    {
                        IFeatureDatasetName name4 = new FeatureDatasetNameClass();
                        name3 = (IDatasetName) name4;
                        break;
                    }
                    case esriDatasetType.esriDTFeatureClass:
                    {
                        IFeatureClassName name5 = new FeatureClassNameClass();
                        name3 = (IDatasetName) name5;
                        break;
                    }
                    case esriDatasetType.esriDTGeometricNetwork:
                    {
                        IGeometricNetworkName name7 = new GeometricNetworkNameClass();
                        name3 = (IDatasetName) name7;
                        break;
                    }
                    case esriDatasetType.esriDTTopology:
                    {
                        ITopologyName name10 = new TopologyNameClass();
                        name3 = (IDatasetName) name10;
                        break;
                    }
                    case esriDatasetType.esriDTTable:
                    {
                        ITableName name6 = new TableNameClass();
                        name3 = (IDatasetName) name6;
                        break;
                    }
                    case esriDatasetType.esriDTRelationshipClass:
                    {
                        IRelationshipClassName name8 = new RelationshipClassNameClass();
                        name3 = (IDatasetName) name8;
                        break;
                    }
                    case esriDatasetType.esriDTNetworkDataset:
                    {
                        INetworkDatasetName name9 = new NetworkDatasetNameClass();
                        name3 = (IDatasetName) name9;
                        break;
                    }
                    default:
                        return false;
                }
                name3.WorkspaceName = fullName;
                name3.Name = objectName;
                IEnumName from = new NamesEnumeratorClass();
                ((IEnumNameEdit) from).Add((IName) name3);
                IName toName = (IName) name2;
                IGeoDBDataTransfer2 transfer = new GeoDBDataTransferClass();
                if (transfer.GenerateNameMapping(from, toName, out mapping))
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
                transfer.Transfer(mapping, toName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CopyPasteGeodatabaseData(IWorkspace sourceWorkspace, IWorkspace targetWorkspace, string objectName, esriDatasetType esriDataType)
        {
            if (sourceWorkspace.Type == esriWorkspaceType.esriFileSystemWorkspace)
            {
                return false;
            }
            try
            {
                IDatasetName name3;
                IEnumNameMapping mapping;
                IDataset dataset = (IDataset) sourceWorkspace;
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IDataset dataset2 = (IDataset) targetWorkspace;
                IWorkspaceName name2 = (IWorkspaceName) dataset2.FullName;
                switch (esriDataType)
                {
                    case esriDatasetType.esriDTFeatureDataset:
                    {
                        IFeatureDatasetName name4 = new FeatureDatasetNameClass();
                        name3 = (IDatasetName) name4;
                        break;
                    }
                    case esriDatasetType.esriDTFeatureClass:
                    {
                        IFeatureClassName name5 = new FeatureClassNameClass();
                        name3 = (IDatasetName) name5;
                        break;
                    }
                    case esriDatasetType.esriDTGeometricNetwork:
                    {
                        IGeometricNetworkName name7 = new GeometricNetworkNameClass();
                        name3 = (IDatasetName) name7;
                        break;
                    }
                    case esriDatasetType.esriDTTopology:
                    {
                        ITopologyName name10 = new TopologyNameClass();
                        name3 = (IDatasetName) name10;
                        break;
                    }
                    case esriDatasetType.esriDTTable:
                    {
                        ITableName name6 = new TableNameClass();
                        name3 = (IDatasetName) name6;
                        break;
                    }
                    case esriDatasetType.esriDTRelationshipClass:
                    {
                        IRelationshipClassName name8 = new RelationshipClassNameClass();
                        name3 = (IDatasetName) name8;
                        break;
                    }
                    case esriDatasetType.esriDTNetworkDataset:
                    {
                        INetworkDatasetName name9 = new NetworkDatasetNameClass();
                        name3 = (IDatasetName) name9;
                        break;
                    }
                    default:
                        return false;
                }
                name3.WorkspaceName = fullName;
                name3.Name = objectName;
                IEnumName from = new NamesEnumeratorClass();
                ((IEnumNameEdit) from).Add((IName) name3);
                IName toName = (IName) name2;
                IGeoDBDataTransfer2 transfer = new GeoDBDataTransferClass();
                if (transfer.GenerateNameMapping(from, toName, out mapping))
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
                transfer.Transfer(mapping, toName);
                return true;
            }
            catch
            {
                return false;
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
                        factory = (IWorkspaceFactory) Activator.CreateInstance(Type.GetTypeFromProgID("esriDataSourcesGDB.AccessWorkspaceFactory"));
                        goto Label_00A5;
                    }
                    if (str.ToLower() == "gdb")
                    {
                        factory = (IWorkspaceFactory) Activator.CreateInstance(Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory"));
                        goto Label_00A5;
                    }
                }
                return null;
            Label_00A5:
                name = factory.Create(str2, str3, null, 0);
                IName o = (IName) name;
                IWorkspace workspace = (IWorkspace) o.Open();
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(name);
                Marshal.ReleaseComObject(factory);
                return workspace;
            }
            catch
            {
                return null;
            }
        }

        public static IWorkspace CreateDBFile1(string sFullPath)
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
            catch
            {
                return null;
            }
        }

        public static IFeatureDataset CreateFeatureDataset(IFeatureWorkspace pFWorkspace, ISpatialReference pSr, string sTName)
        {
            if (pFWorkspace == null)
            {
                return null;
            }
            try
            {
                return pFWorkspace.CreateFeatureDataset(sTName, pSr);
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
                UID cLSID = new UIDClass();
                cLSID.Value = "esriGeoDatabase.Object";
                return pFWorkspace.CreateTable(sTName, pTemlTable.Fields, cLSID, null, "");
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteDBFile(string sFile)
        {
            try
            {
                if (sFile == "")
                {
                    return false;
                }
                (OpenWorkspace(sFile) as IDataset).Delete();
                return true;
            }
            catch
            {
                return false;
            }
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

        public static bool LoadFeatureClass(IFeatureClass pSrcFClass, IFeatureClass pTargFClass, IQueryFilter pQFilter)
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
                IFeatureCursor o = pSrcFClass.Search(pQFilter, false);
                if (o != null)
                {
                    try
                    {
                        IFeature pSrcObj = null;
                        IFeature pTargObj = null;
                        while ((pSrcObj = o.NextFeature()) != null)
                        {
                            pTargObj = pTargFClass.CreateFeature();
                            CopyGeoObject(pSrcObj, pTargObj);
                            pTargObj.Shape = pSrcObj.ShapeCopy;
                            pTargObj.Store();
                        }
                        if (pTargObj != null)
                        {
                            Marshal.ReleaseComObject(pTargObj);
                        }
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

        public static bool LoadTableData(ITable pSourceTable, ITable pTargetTable, IQueryFilter pQueryFilter)
        {
            if (pSourceTable == null)
            {
                return false;
            }
            if (pTargetTable == null)
            {
                return false;
            }
            try
            {
                ICursor o = pSourceTable.Search(pQueryFilter, false);
                if (o == null)
                {
                    return false;
                }
                IRow row = null;
                IRow row2 = null;
                while ((row = o.NextRow()) != null)
                {
                    row2 = pTargetTable.CreateRow();
                    CopyGeoObject((IObject) row, (IObject) row2);
                    row2.Store();
                }
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(row2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadTableData2(ITable pSourceTable, ITable pTargetTable, IQueryFilter pQueryFilter)
        {
            if (pSourceTable == null)
            {
                return false;
            }
            if (pTargetTable == null)
            {
                return false;
            }
            try
            {
                ICursor o = pSourceTable.Search(pQueryFilter, false);
                if (o == null)
                {
                    return false;
                }
                IRowBuffer buffer = pTargetTable.CreateRowBuffer();
                ICursor cursor2 = pTargetTable.Insert(true);
                IRow row = null;
                while ((row = o.NextRow()) != null)
                {
                    CopyGeoObject((IObject) row, (IObject) buffer);
                    cursor2.InsertRow(buffer);
                }
                cursor2.Flush();
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(buffer);
                Marshal.ReleaseComObject(cursor2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static IFeatureClass OpenFeatureClass(IFeatureWorkspace pWs, string sName)
        {
            try
            {
                if (pWs == null)
                {
                    return null;
                }
                return pWs.OpenFeatureClass(sName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IFeatureDataset OpenFeatureDataset(IFeatureWorkspace pWs, string sName)
        {
            try
            {
                if (pWs == null)
                {
                    return null;
                }
                return pWs.OpenFeatureDataset(sName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ITable OpenTable(IFeatureWorkspace pWs, string sName)
        {
            try
            {
                if (pWs == null)
                {
                    return null;
                }
                return pWs.OpenTable(sName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IWorkspace OpenWorkspace(string sSourceFile)
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
                IWorkspace workspace = o.OpenFromFile(sSourceFile, 0);
                Marshal.ReleaseComObject(o);
                return workspace;
            }
            catch
            {
                return null;
            }
        }

        public static string ProjectFeatureClass(IFeatureClass pInFClass, string sOutPath, string sOutSpatialReference)
        {
            try
            {
                IGeoProcessorResult o = null;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                Project process = new Project();
                process.in_dataset = pInFClass;
                process.in_coor_system = ((IGeoDataset) pInFClass).SpatialReference;
                process.out_dataset = sOutPath;
                process.out_coor_system = sOutSpatialReference;
                o = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (o == null)
                {
                    string str = "";
                    for (int i = 0; i < geoprocessor.MessageCount; i++)
                    {
                        str = str + geoprocessor.GetMessage(i);
                    }
                    return str;
                }
                Marshal.ReleaseComObject(o);
                o = null;
                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public static bool UpdateFieldValue(IObject pObj, string sFieldName, object pValue)
        {
            try
            {
                if (pObj == null)
                {
                    return false;
                }
                int index = pObj.Fields.FindField(sFieldName);
                if (index < 0)
                {
                    return false;
                }
                if (pObj.Fields.get_Field(index).Editable)
                {
                    pObj.set_Value(index, pValue);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

