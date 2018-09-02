namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class ForestGDBTask : Task
    {
        protected List<string> _allDbs = new List<string>();
        protected IDataServerManagerAdmin _dsAdmin;

        protected void CloseAdmin()
        {
            if (this._dsAdmin != null)
            {
                Marshal.ReleaseComObject(this._dsAdmin);
                this._dsAdmin = null;
            }
        }

        protected static SqlConnection CreateConnection(string server, string uid, string pwd, string dbName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
                DataSource = server,
                InitialCatalog = dbName,
                UserID = uid,
                Password = pwd
            };
            string connectionString = builder.ConnectionString;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception)
            {
                return null;
            }
            return connection;
        }

        ~ForestGDBTask()
        {
            if (this._dsAdmin != null)
            {
                Marshal.ReleaseComObject(this._dsAdmin);
                this._dsAdmin = null;
            }
        }

        protected void GDBToNewGDB(IWorkspace sourceWorkspace, IWorkspace targetWorkspace, string objectName, esriDatasetType esriDataType, bool resolvConflicts)
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
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTFeatureClass:
                    {
                        IFeatureClassName name5 = new FeatureClassNameClass();
                        name3 = (IDatasetName) name5;
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTPlanarGraph:
                    case esriDatasetType.esriDTText:
                        return;

                    case esriDatasetType.esriDTGeometricNetwork:
                    {
                        IGeometricNetworkName name7 = new GeometricNetworkNameClass();
                        name3 = (IDatasetName) name7;
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTTopology:
                    {
                        ITopologyName name10 = new TopologyNameClass();
                        name3 = (IDatasetName) name10;
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTTable:
                    {
                        ITableName name6 = new TableNameClass();
                        name3 = (IDatasetName) name6;
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTRelationshipClass:
                    {
                        IRelationshipClassName name8 = new RelationshipClassNameClass();
                        name3 = (IDatasetName) name8;
                        goto Label_00EA;
                    }
                    case esriDatasetType.esriDTNetworkDataset:
                    {
                        INetworkDatasetName name9 = new NetworkDatasetNameClass();
                        name3 = (IDatasetName) name9;
                        goto Label_00EA;
                    }
                }
            }
            return;
        Label_00EA:
            name3.WorkspaceName = fullName;
            name3.Name = objectName;
            IEnumName from = new NamesEnumeratorClass();
            ((IEnumNameEdit) from).Add((IName) name3);
            IName toName = (IName) name2;
            IGeoDBDataTransfer o = new GeoDBDataTransferClass();
            o.GenerateNameMapping(from, toName, out mapping);
            o.Transfer(mapping, toName);
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
        }

        protected IWorkspace GetGdbTemplateWks(string type, string dbName)
        {
            if ("SQLGDB".CompareTo(type) == 0)
            {
                return this.OpenWorkSpace(dbName, "dbo.Default");
            }
            if ("FGDB".CompareTo(type) == 0)
            {
                return ForestGDBWorkSpaceUtil.GetWorkspace(dbName);
            }
            return null;
        }

        protected List<string> GetGeoClassNames(IWorkspace pWks, esriDatasetType esriType, string dsName)
        {
            if (pWks == null)
            {
                return null;
            }
            List<string> list = new List<string>();
            IFeatureWorkspace workspace = pWks as IFeatureWorkspace;
            if (string.IsNullOrEmpty(dsName))
            {
                return ForestGDBWorkSpaceUtil.GetItemNames(pWks, esriType);
            }
            IDataset dataset = null;
            try
            {
                dataset = workspace.OpenFeatureDataset(dsName);
            }
            catch (Exception)
            {
            }
            if (dataset != null)
            {
                IEnumDataset subsets = dataset.Subsets;
                subsets.Reset();
                for (IDataset dataset3 = subsets.Next(); dataset3 != null; dataset3 = subsets.Next())
                {
                    if (dataset3.Type == esriType)
                    {
                        string item = dataset3.Name.ToUpper();
                        item = item.Substring(item.LastIndexOf('.') + 1);
                        list.Add(item);
                    }
                }
                if (subsets != null)
                {
                    Marshal.ReleaseComObject(subsets);
                    subsets = null;
                }
            }
            return list;
        }

        protected void initDSAdmin(string gdbIntance)
        {
            if (!string.IsNullOrEmpty(gdbIntance))
            {
                try
                {
                    IDataServerManager manager = new DataServerManagerClass {
                        ServerName = gdbIntance
                    };
                    manager.Connect();
                    this._dsAdmin = (IDataServerManagerAdmin) manager;
                    TaskResult result = new TaskResult {
                        Msg = "空间数据管理连接成功!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(10, result);
                }
                catch (Exception)
                {
                    this._dsAdmin = null;
                }
            }
        }

        protected bool IsGDBExists(string gdbName)
        {
            if (this._dsAdmin == null)
            {
                return false;
            }
            this.queryAllDBNames();
            return this._allDbs.Contains(gdbName);
        }

        protected IWorkspace OpenWorkSpace(string dbName, string version)
        {
            if (!string.IsNullOrEmpty(dbName))
            {
                if (this._dsAdmin == null)
                {
                    return null;
                }
                try
                {
                    IName name2 = (IName) this._dsAdmin.CreateWorkspaceName(dbName, "VERSION", string.IsNullOrEmpty(version) ? "dbo.Default" : version);
                    return (IWorkspace) name2.Open();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        protected int queryAllDBNames()
        {
            if (this._dsAdmin == null)
            {
                return -1;
            }
            try
            {
                this._allDbs.Clear();
                this._allDbs = new List<string>();
                IEnumBSTR geodatabaseNames = this._dsAdmin.GetGeodatabaseNames();
                if (geodatabaseNames == null)
                {
                    return 0;
                }
                string str = geodatabaseNames.Next();
                if (this._allDbs == null)
                {
                    this._allDbs = new List<string>();
                }
                while (!string.IsNullOrEmpty(str))
                {
                    this._allDbs.Add(str);
                    str = geodatabaseNames.Next();
                }
                if (geodatabaseNames != null)
                {
                    Marshal.ReleaseComObject(geodatabaseNames);
                    geodatabaseNames = null;
                }
                return this._allDbs.Count;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}

