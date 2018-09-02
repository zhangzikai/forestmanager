using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.gis;
using td.db.orm;
using td.logic.sys;
namespace td.forest.zl.tj
{
    /// <summary>
    /// 造林的底层类
    /// </summary>
    public class ZaoLinTJBase
    {
        protected int m_digits = 2;
        protected MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        public virtual DataTable ComputeXianXiangCun(IEnumerable<Forst_ZL_Mid> lst)
        {
           

            DataTable resultTable = MakeTable();
            if (lst.Count() < 1) return resultTable;
            var xiangGrps = lst.GroupBy(p => p.XIAN);
            MakeRow(resultTable, lst.First().SHI, lst);
            foreach (var grp in xiangGrps)
            {
                var cunLst = grp.GroupBy(p => p.XIANG);
                MakeRow(resultTable, grp.Key, grp.AsEnumerable());
                foreach (var cunGrp in cunLst)
                {
                    MakeRow(resultTable, cunGrp.Key,cunGrp.AsEnumerable());
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }         
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return resultTable;
        }

        /// <summary>
        /// 计算乡村的底层类
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="xiang"></param>
        /// <returns></returns>
        public virtual DataTable ComputeXiangCun(IEnumerable<Forst_ZL_Mid> lst, string xiang)
        {
            var xiangGrps = lst.GroupBy(p => p.XIANG);
            DataTable resultTable = this.MakeTable();
            MakeRow(resultTable, xiang, lst);
            foreach (var grp in xiangGrps)
            {
                MakeRow(resultTable, grp.Key, grp.AsEnumerable());
                var grp1 =  grp.GroupBy(p => p.CUN);
                foreach (var grp2 in grp1) {
                    MakeRow(resultTable, grp2.Key, grp2.AsEnumerable());
                }
                
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }          
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return resultTable;
        }

        /// <summary>
        /// 计算县乡的底层类
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public virtual DataTable ComputeXianXiang(IEnumerable<Forst_ZL_Mid> lst)
        {
            DataTable resultTable = this.MakeTable();

            //因为没有造林类别为112，因此直接返回
            if (lst.Count() < 1) return resultTable;
            
            var xiangGrps= lst.GroupBy(p => p.XIAN);
            
            MakeRow(resultTable, lst.First().SHI, lst);
            foreach(var grp in xiangGrps)
            {                
                MakeRow(resultTable, grp.Key,grp.AsEnumerable());
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
           
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return resultTable;         
        }

        /// <summary>
        /// 基类制作数据表行的方法为null，需要子类重写
        /// </summary>
        /// <returns></returns>
        protected virtual DataTable  MakeTable()
        {
            return null;
        }
        protected virtual void MakeRow(DataTable resultTable, string key, IEnumerable<Forst_ZL_Mid> grp)
        {
           
        }
        protected void MakeFirstRow(DataTable table,string key)
        {
            DataRow row4 = table.NewRow();
            row4[0] = MDM.FindXQName(key); ;
            for (int i = 1; i < table.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(table.Compute("SUM(" + table.Columns[i] + ")", null)), m_digits);
            }
            table.Rows.InsertAt(row4, 0);
        }
        
        public object[,] Compute2ObjAry(DataTable table)
        {
            object[,] objArray = null;
            if ((table != null) && (table.Rows.Count > 0))
            {

                objArray = new object[table.Rows.Count, table.Columns.Count];
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        objArray[row, col] = table.Rows[row][col];
                    }
                }
                table = null;
            }
            return objArray;
        }


        protected DataTable ConvertTableFldValueZeroToNull(DataTable ResultTable, int startcolnum)
        {
            for (int i = 0; i < ResultTable.Rows.Count; i++)
            {
                for (int j = startcolnum; j < ResultTable.Columns.Count; j++)
                {
                    string str = ResultTable.Rows[i][j].ToString().Trim();
                    if ((str.Length > 0) && (Convert.ToDouble(str) == 0.0))
                    {
                        ResultTable.Rows[i][j] = DBNull.Value;
                    }
                }
            }
            return ResultTable;
        }
    }
}
