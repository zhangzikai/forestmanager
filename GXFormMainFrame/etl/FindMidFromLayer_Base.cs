using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using jn.isos.log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using td.db.gis;
using td.logic.forest;
using td.utility;

namespace td.db.etl
{
    public class FindMidFromLayer_Base<T> : FindMidFromLayer<T>  where T : new()
    {
         private static Logger m_log;
         private IFeatureLayer m_dataLayer;
         public IFeatureLayer DataLayer
         {
             get { return m_dataLayer; }
             set
             {
                 m_dataLayer = value;
                 DataClass = value.FeatureClass;
             }
         }
        public IFeatureClass DataClass { get; set; }
        public FindMidFromLayer_Base() {
            m_log = LoggerManager.CreateLogger("UI", "FindMidFromLayer_Base");
        }

        /// <summary>
        /// 创建默认的查询，将查询的数据封装在List中
        /// </summary>
        /// <param name="subField"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        protected List<T> CreateQueryDef(string subField, string where, string orderby)
        {
            List<T> lst = new List<T>();
            try
            {

                IFeatureWorkspace pFWork = DataClass.FeatureDataset.Workspace as IFeatureWorkspace;
                IQueryDef2 pQDef = pFWork.CreateQueryDef() as IQueryDef2;
                IDataset ds = DataClass as IDataset;
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
