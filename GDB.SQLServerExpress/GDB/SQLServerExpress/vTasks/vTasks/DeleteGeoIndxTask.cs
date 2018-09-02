namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class DeleteGeoIndxTask : ForestGDBTask
    {
        private const string GeoAdminName = "BASE_P_XIAN_10K";
        private const string GeoIndxName = "INDEX_A_10K";

        private void DeleteIndxes(IWorkspace pWks, int progress)
        {
            if (pWks != null)
            {
                IFeatureWorkspace pWs = pWks as IFeatureWorkspace;
                if (pWs != null)
                {
                    IFeatureClass o = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, "INDEX_A_10K");
                    if (o == null)
                    {
                        TaskResult result = new TaskResult {
                            Msg = "数据库中索引图层：INDEX_A_10K打开失败！",
                            Success = false
                        };
                        base.FireProgressChangedEvent(progress, result);
                    }
                    else
                    {
                        IFeatureClass class3 = ForestGDBWorkSpaceUtil.OpenFeatureClass(pWs, "BASE_P_XIAN_10K");
                        if (class3 == null)
                        {
                            TaskResult result2 = new TaskResult {
                                Msg = "数据库中行政区域图层：BASE_P_XIAN_10K打开失败！",
                                Success = false
                            };
                            base.FireProgressChangedEvent(progress, result2);
                        }
                        else
                        {
                            IGeometryCollection geometrys = new GeometryBagClass();
                            IFeatureCursor cursor = class3.Search(null, false);
                            if (cursor == null)
                            {
                                TaskResult result3 = new TaskResult {
                                    Msg = "行政区域图层：BASE_P_XIAN_10K中未查询到多边形数据！",
                                    Success = false
                                };
                                base.FireProgressChangedEvent(progress, result3);
                            }
                            else
                            {
                                IFeature feature = cursor.NextFeature();
                                object missing = Type.Missing;
                                while (feature != null)
                                {
                                    geometrys.AddGeometry(feature.ShapeCopy, ref missing, ref missing);
                                    feature = cursor.NextFeature();
                                }
                                ISpatialFilter queryFilter = new SpatialFilterClass {
                                    Geometry = geometrys as IGeometry,
                                    GeometryField = o.ShapeFieldName,
                                    SpatialRel = esriSpatialRelEnum.esriSpatialRelRelation,
                                    SpatialRelDescription = "FF*FF****"
                                };
                                ((ITable) o).DeleteSearchedRows(queryFilter);
                                if (geometrys != null)
                                {
                                    Marshal.ReleaseComObject(geometrys);
                                    geometrys = null;
                                }
                                if (cursor != null)
                                {
                                    Marshal.ReleaseComObject(cursor);
                                    cursor = null;
                                }
                                if (queryFilter != null)
                                {
                                    Marshal.ReleaseComObject(queryFilter);
                                    queryFilter = null;
                                }
                                if (class3 != null)
                                {
                                    Marshal.ReleaseComObject(class3);
                                    class3 = null;
                                }
                                if (o != null)
                                {
                                    Marshal.ReleaseComObject(o);
                                    o = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        private string GetGbCode(string dbName)
        {
            if (!dbName.Contains("MODULE"))
            {
                string[] strArray = dbName.Split(new char[] { '_' });
                if (strArray.Length < 2)
                {
                    return string.Empty;
                }
                string s = strArray[1];
                int result = 0;
                if (int.TryParse(s, out result))
                {
                    return s;
                }
            }
            return string.Empty;
        }

        public override object Work(params object[] args)
        {
            base.Work(args);
            if ((args == null) || (args.Length <= 0))
            {
                this.StopTask();
                return null;
            }
            string str = args[0] as string;
            List<string> list = args[1] as List<string>;
            if ((!string.IsNullOrEmpty(str) && (list != null)) && (list.Count > 0))
            {
                TaskResult result6 = new TaskResult {
                    Msg = "连接地理空间数据库！",
                    Success = true
                };
                base.FireProgressChangedEvent(10, result6);
                base.initDSAdmin(str);
                if (base._dsAdmin == null)
                {
                    TaskResult result = new TaskResult {
                        Msg = "空间数据库连接失败！",
                        Success = false
                    };
                    base.FireProgressChangedEvent(100, result);
                    return null;
                }
                int progress = 20;
                int num2 = 80 / list.Count;
                foreach (string str2 in list)
                {
                    if (string.IsNullOrEmpty(this.GetGbCode(str2)))
                    {
                        TaskResult result2 = new TaskResult {
                            Msg = "数据库名称" + str2 + "中不包含所需国标代码部分,不进行处理。",
                            Success = false
                        };
                        base.FireProgressChangedEvent(progress, result2);
                    }
                    else
                    {
                        IWorkspace pWks = base.OpenWorkSpace(str2, string.Empty);
                        if (pWks == null)
                        {
                            TaskResult result3 = new TaskResult {
                                Msg = "数据库：" + str2 + "地理空间打开失败！",
                                Success = false
                            };
                            base.FireProgressChangedEvent(progress, result3);
                        }
                        else
                        {
                            TaskResult result4 = new TaskResult {
                                Msg = "开始删除行政区域外的图框数据!",
                                Success = false
                            };
                            base.FireProgressChangedEvent(progress, result4);
                            this.DeleteIndxes(pWks, progress);
                            TaskResult result5 = new TaskResult {
                                Msg = "删除完成!",
                                Success = false
                            };
                            base.FireProgressChangedEvent(progress, result5);
                            if (pWks != null)
                            {
                                Marshal.ReleaseComObject(pWks);
                                pWks = null;
                            }
                            progress += num2;
                        }
                    }
                }
                TaskResult result7 = new TaskResult {
                    Msg = "数据整理完成！",
                    Success = true
                };
                base.FireProgressChangedEvent(100, result7);
            }
            return null;
        }
    }
}

