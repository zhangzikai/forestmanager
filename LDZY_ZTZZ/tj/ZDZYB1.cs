using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.mid.forest;

namespace td.forest.ldzy.tj
{
    public class ZDZYB1 : ZDZYTJBase
    {
        private DataTable m_table;

        public override System.Data.DataTable GetTableByXianXiangCun(List<ZT_LDZZ_2016_Mid> xbLst)
        {
            DataTable table = MakeTable();
            if (xbLst.Count == 0) return table;
            return base.GetTableByXianXiangCun(xbLst);
        }
        protected override System.Data.DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDGJMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDCFMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDGJMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDCFMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }
    }
}
