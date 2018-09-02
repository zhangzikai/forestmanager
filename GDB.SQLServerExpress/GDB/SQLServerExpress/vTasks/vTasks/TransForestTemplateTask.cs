namespace GDB.SQLServerExpress.vTasks.vTasks
{
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.Geodatabase;
    using GDB.SQLServerExpress;
    using GDB.SQLServerExpress.vTasks;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class TransForestTemplateTask : ForestGDBTask
    {
        private IDataServerManagerAdmin _dsAdmin;
        private string _gdbInstance;
        private string uid = string.Empty;

        public TransForestTemplateTask(string gdbInstance)
        {
            this._gdbInstance = gdbInstance;
            this.uid = Guid.NewGuid().ToString();
        }

        private List<string> ExpTmplToNewGDB(IWorkspace srcWks, IWorkspace targetWks, esriDatasetType esriType, List<string> noNeedNames)
        {
            List<string> list = new List<string>();
            IEnumDataset dataset = srcWks.get_Datasets(esriType);
            if (dataset != null)
            {
                dataset.Reset();
                IDataset o = dataset.Next();
                int num = 70;
                while (o != null)
                {
                    string item = o.Name.ToUpper();
                    item = item.Substring(item.LastIndexOf('.') + 1);
                    esriDatasetType esriDataType = o.Type;
                    if ((noNeedNames == null) || !noNeedNames.Contains(item))
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        base.GDBToNewGDB(srcWks, targetWks, item, esriDataType, false);
                        stopwatch.Stop();
                        TaskResult result = new TaskResult {
                            Msg = item + "模板已导入!耗时:" + stopwatch.Elapsed.ToString(),
                            Success = true
                        };
                        base.FireProgressChangedEvent(num++, result);
                        Marshal.ReleaseComObject(o);
                        o = null;
                        o = dataset.Next();
                    }
                }
            }
            return list;
        }

        public override object Work(params object[] args)
        {
            base.Work(args);
            base.initDSAdmin(this._gdbInstance);
            ForestDataTransConfig config = args[0] as ForestDataTransConfig;
            if (config == null)
            {
                TaskResult result = new TaskResult {
                    Msg = "参数信息错误，需要指定第一个参数类型为ForestDataTransConfig",
                    Success = false
                };
                base.FireProgressChangedEvent(10, result);
                return null;
            }
            IWorkspace gdbTemplateWks = base.GetGdbTemplateWks(config.SrcType, config.SrcDBName);
            if (gdbTemplateWks == null)
            {
                TaskResult result2 = new TaskResult {
                    Msg = "建立源数据库工作空间失败!",
                    Success = false
                };
                base.FireProgressChangedEvent(100, result2);
                this.StopTask();
                return null;
            }
            IWorkspace targetWks = base.OpenWorkSpace(config.TargetDbName, string.Empty);
            if (targetWks == null)
            {
                TaskResult result3 = new TaskResult {
                    Msg = "建立目标数据库工作空间失败!",
                    Success = false
                };
                base.FireProgressChangedEvent(100, result3);
                this.StopTask();
                return null;
            }
            TaskResult result4 = new TaskResult {
                Msg = "处理完成，开始进行数据处理....",
                Success = false
            };
            base.FireProgressChangedEvent(50, result4);
            this.ExpTmplToNewGDB(gdbTemplateWks, targetWks, config.EsriType, null);
            base.FireStatusChangedEvent(TaskStatus.Stopped, this.uid);
            return null;
        }

        public string Uid
        {
            get
            {
                return this.uid;
            }
        }
    }
}

