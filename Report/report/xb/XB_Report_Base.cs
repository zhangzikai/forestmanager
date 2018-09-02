using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Report;
using td.db.mid.forest;
using td.logic.forest;
using td.logic.sys;
using td.db.orm;
using DevExpress.XtraEditors;

namespace td.forest.report.xb
{
    /// <summary>
    /// 小班报表的底层类
    /// </summary>
    public class XB_Report_Base 
    {
        protected List<FOR_XIAOBAN_Mid> m_xb_dataList;
        protected DataTable m_table;
        protected int m_digits = 2;
        protected FindMidFromLayer<FOR_XIAOBAN_Mid> m_midLayer;
        protected int m_firstRow;
        protected int m_firstColumn;
        public string TJYear { get; set; }
        public string SheetName { get; set; }
        protected MetaDataManager MDM
        { get { return DBServiceFactory<MetaDataManager>.Service; } }

        public XB_Report_Base()
        {
        }

        public virtual List<FOR_XIAOBAN_Mid> InitialReport(FindMidFromLayer<FOR_XIAOBAN_Mid> midLayer)
        {               
            //需要获取的字段
            m_midLayer = midLayer;
            //字段名：“县|乡|村|地名||”
            string subFields = "SHI,XIAN,XIANG,CUN,DIMING,QHSJ,PHSJ,TOTAL_MJ,YSL_MJ,RGL_MJ,LINFEN,SS_CL,SS_YL,SS_ZLMJ,SHANG_Q,SHANG_Z,SHANG_S,SS_MONEY,PU_RG,PU_CL,PU_QC,PU_FJ,PU_JF,SF_CL,CL_RS,CL_XSRS,HZYY,FIRE_NO,HZDJ,NL";
            m_xb_dataList = m_midLayer.Find(subFields, "", "Order by CUN");
            return m_xb_dataList;
        }

        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="xb_dataList"></param>
        public virtual void InitialReport(List<FOR_XIAOBAN_Mid> xb_dataList)
        {
            m_xb_dataList = xb_dataList;           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual DataTable FromMid2Table()
        {
            return null;
        }
        protected int m_index = 1;
        protected virtual void MakeRow(DataTable table, IEnumerable<T_ZT_HZ_INFO_Mid> data, string xiangName)
        {
           
        }
        protected virtual DataTable MakeTable()
        {
            return null;
        }

        /// <summary>
        /// 将封装在DataTable中的数据写入Excel表格中
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="worksheet"></param>
        public virtual void WriteExcel(System.Data.DataTable pDt, Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            if ((pDt != null) && (pDt.Rows.Count != 0))
            {
                object[,] objArray = new object[pDt.Rows.Count, pDt.Columns.Count];

                for (int j = 0; j < pDt.Rows.Count; j++)
                {
                    
                    for (int k = 0; k < pDt.Columns.Count; k++)
                    {
                        objArray[j, k] = pDt.Rows[j][k];                       
                    }                  
                }
                int maxRow = pDt.Rows.Count + m_firstRow-1;
                int maxcol = pDt.Columns.Count + m_firstColumn-1;
                Microsoft.Office.Interop.Excel.Range range3 = worksheet.get_Range(worksheet.Cells[m_firstRow, m_firstColumn], worksheet.Cells[maxRow, maxcol]);
                range3.Value2 = objArray;
                range3.Borders.LineStyle = 1;
                range3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                range3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            }
        }
    }
}
