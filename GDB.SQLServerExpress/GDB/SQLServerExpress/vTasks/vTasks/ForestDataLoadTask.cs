namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using GDB.SQLServerExpress.vTasks.vControls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ForestDataLoadTask : ForestGDBTask
    {
        private ForGeoDataMatchFrm _dataMatchFrm;
        private string _gdbInstance = string.Empty;

        public ForestDataLoadTask(string gdbInstance)
        {
            this._gdbInstance = gdbInstance;
            if (!string.IsNullOrEmpty(this._gdbInstance))
            {
                base.initDSAdmin(gdbInstance);
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
            IFeatureWorkspace workspace2 = pSrcWks as IFeatureWorkspace;
            if (workspace2 == null)
            {
                return -1;
            }
            Dictionary<string, esriFieldType> targetFields = this.getFields(pFeatureClass);
            IFeatureClass class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(workspace2, fcName);
            Dictionary<string, esriFieldType> srcFields = null;
            List<string> srcNames = base.GetGeoClassNames(pSrcWks, esriDatasetType.esriDTFeatureClass, dsName);
        Label_0043:
            mappedFields = null;
            if (class3 != null)
            {
                goto Label_0141;
            }
        Label_004D:
            if (this._dataMatchFrm == null)
            {
                this._dataMatchFrm = new ForGeoDataMatchFrm();
                this._dataMatchFrm.WorkSpace = pSrcWks;
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
            class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(workspace2, fcName);
            if (class3 == null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("未设置数据源，是否退出该图层导入？", "提示", MessageBoxButtons.YesNo))
                {
                    return 0;
                }
                goto Label_0043;
            }
        Label_0141:
            srcFields = this.getFields(class3);
            if ((mappedFields == null) && !this.tryMatchFields(targetFields, srcFields))
            {
                goto Label_004D;
            }
            return this.LoadFeatureObjects(class3, pFeatureClass, mappedFields);
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

        public override object Work(params object[] args)
        {
            base.Work(args);
            if ((args == null) || (args.Length < 2))
            {
                TaskResult result = new TaskResult {
                    Msg = "给定参数不满足需求，需要至少两个参数!"
                };
                base.FireProgressChangedEvent(100, result);
                this.StopTask();
                return null;
            }
            string str = args[0] as string;
            string str2 = args[1] as string;
            if (args.Length >= 3)
            {
                this._gdbInstance = args[2] as string;
                base.CloseAdmin();
            }
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str2))
            {
                TaskResult result2 = new TaskResult {
                    Msg = "给定参数不满足需求，源数据库路径或数据库名称必须指定!"
                };
                base.FireProgressChangedEvent(100, result2);
                this.StopTask();
                return null;
            }
            if (base._dsAdmin == null)
            {
                base.initDSAdmin(this._gdbInstance);
            }
            if (base.IsGDBExists(str2))
            {
                IWorkspace pTargetWks = base.OpenWorkSpace(str2, string.Empty);
                IWorkspace gdbTemplateWks = base.GetGdbTemplateWks("FGDB", str);
                if ((pTargetWks == null) || (pTargetWks == null))
                {
                    TaskResult result3 = new TaskResult {
                        Msg = "空间数据库打开失败!",
                        Success = true
                    };
                    base.FireProgressChangedEvent(100, result3);
                }
                else
                {
                    this.LoadForestData(pTargetWks, gdbTemplateWks);
                }
                if (pTargetWks != null)
                {
                    Marshal.ReleaseComObject(pTargetWks);
                    pTargetWks = null;
                }
                if (gdbTemplateWks != null)
                {
                    Marshal.ReleaseComObject(gdbTemplateWks);
                    gdbTemplateWks = null;
                }
            }
            return null;
        }
    }
}

