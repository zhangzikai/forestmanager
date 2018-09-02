namespace StatisChart
{
    using System;
    using System.Data;

    public static class ServiceData
    {
        public static DataTable GetWeekMoneyAndCost()
        {
            DataTable table = new DataTable();
            table.Columns.Add("month", typeof(string));
            table.Columns.Add("an", typeof(decimal));
            table.Columns.Add("song", typeof(decimal));
            table.Columns.Add("sha", typeof(decimal));
            table.Rows.Add(new object[] { "一月", 0x4b0, 400, 300 });
            table.Rows.Add(new object[] { "二月", 0x708, 750, 500 });
            table.Rows.Add(new object[] { "三月", 890, 320, 200 });
            table.Rows.Add(new object[] { "四月", 0x438, 290, 330 });
            table.Rows.Add(new object[] { "五月", 0xaf0, 0x3fc, 880 });
            table.Rows.Add(new object[] { "六月", 0xc80, 0x4ec, 0x514 });
            table.Rows.Add(new object[] { "七月", 0x1194, 0x910, 0x708 });
            return table;
        }
    }
}

