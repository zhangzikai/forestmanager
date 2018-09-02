using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using jn.isos.log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.logic.forest;
using td.utility;

namespace td.db.etl
{
    public class FindMidFromTable_Base<T> : FindMidFromLayer<T> where T : new()
    {
        private static Logger m_log;
      //  public IFeatureLayer DataLayer { get; set; }
        public ITable DataTable { get; set; }
        public FindMidFromTable_Base()
        {
            m_log = LoggerManager.CreateLogger("UI", "FindMidFromTable_Base");
        }

        protected List<T> CreateQueryDef(string subField, string where, string orderby)
        {
            List<T> lst = new List<T>();
            if (null == DataTable) return lst;
            try
            {
                IDataset ds=DataTable as IDataset;
                IFeatureWorkspace pFWork = ds.Workspace as IFeatureWorkspace;
                IQueryDef2 pQDef = pFWork.CreateQueryDef() as IQueryDef2;               
                pQDef.Tables = ds.Name;
                pQDef.SubFields = subField;
                pQDef.WhereClause = where;

                ICursor cur = pQDef.Evaluate();
                IRow row = cur.NextRow();
                string[] sfs = subField.Split(','); 
                while (row != null)
                {
                    T mid = new T();

                    for (int i = 0; i < sfs.Length; i++)
                    {
                        object obj = row.get_Value(i);
                        if (null != obj)
                        {
                            ReflectUtility.SetPropertyValue(mid, sfs[i], obj);
                        }
                    }
                    lst.Add(mid);
                    row = cur.NextRow();
                }
                
            }
            catch(Exception ex)
            {
                m_log.Warn(ex.Message);

            }
            return lst;
        }
    }
}
