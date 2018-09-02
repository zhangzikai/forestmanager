namespace Tj
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    internal class Public_Class
    {
        private DataSet M_Dataset;
        private SqlCommand M_SqlCommand;
        private SqlConnection M_SqlConnection;
        private SqlDataAdapter M_SqlDataAdapter;
        private static string str_Bqnd;
        private static string str_Cncw;
        private static string str_ConnectionDataBaseName;
        private static string str_connectionpassword;
        private static string str_ConnectionServerName;
        private static string str_connectionstring;
        private static string str_connectionusername;
        private static string str_dwbh;
        private static string str_dwmc;
        private static string str_Qqnd;
        private static string str_QS;

        public void AppUpdate()
        {
            SqlConnection selectConnection = new SqlConnection(M_Str_ConnectionString);
            selectConnection.Open();
            try
            {
                string selectCommandText = "select name from sysobjects where  [name] ='T_updateversion' and xtype='U'";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, selectConnection);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                new SqlCommandBuilder(adapter);
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count == 0)
                {
                    selectCommandText = " CREATE TABLE [dbo].[T_updateversion](    [OBJECTID] [int] PRIMARY KEY identity(1,1),   [version] [nvarchar](8) NULL ) ON [PRIMARY]";
                    SqlCommand command = new SqlCommand(selectCommandText, selectConnection);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("创建程序更新表出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                }
                selectCommandText = "select objectid,version from T_updateversion order by version desc";
                adapter = new SqlDataAdapter(selectCommandText, selectConnection);
                new SqlCommandBuilder(adapter);
                System.Data.DataTable table2 = new System.Data.DataTable();
                adapter.Fill(table2);
                bool flag = true;
                if (table2.Rows.Count == 0)
                {
                    try
                    {
                        Public_Class class2 = new Public_Class();
                        string str3 = "select name from sysobjects where  [name] like 'T_xb_45%' and xtype='U'";
                        SqlDataAdapter adapter2 = new SqlDataAdapter(str3, selectConnection);
                        System.Data.DataTable table3 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter2);
                        adapter2.Fill(table3);
                        for (int j = 0; j < table3.Rows.Count; j++)
                        {
                            SqlDataAdapter adapter3 = new SqlDataAdapter((((" alter table " + table3.Rows[j]["name"].ToString().Trim() + " alter column tdjyq nvarchar(2)") + " alter table " + table3.Rows[j]["name"].ToString().Trim() + " alter column lmsyq nvarchar(2)") + " alter table " + table3.Rows[j]["name"].ToString().Trim() + " alter column lmjyq nvarchar(2)") + " alter table " + table3.Rows[j]["name"].ToString().Trim() + " alter column xbid nvarchar(17)", selectConnection);
                            System.Data.DataTable table4 = new System.Data.DataTable();
                            adapter3.Fill(table4);
                            if (table4 == null)
                            {
                                MessageBox.Show("扩充" + table3.Rows[j]["name"].ToString().Trim() + "的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                System.Windows.Forms.Application.Exit();
                            }
                        }
                        str3 = "select name from sysobjects where  [name] like 'T_lastxb_45%' and xtype='U'";
                        adapter2 = new SqlDataAdapter(str3, selectConnection);
                        table3 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter2);
                        adapter2.Fill(table3);
                        for (int k = 0; k < table3.Rows.Count; k++)
                        {
                            SqlDataAdapter adapter4 = new SqlDataAdapter((((" alter table " + table3.Rows[k]["name"].ToString().Trim() + " alter column tdjyq nvarchar(2)") + " alter table " + table3.Rows[k]["name"].ToString().Trim() + " alter column lmsyq nvarchar(2)") + " alter table " + table3.Rows[k]["name"].ToString().Trim() + " alter column lmjyq nvarchar(2)") + " alter table " + table3.Rows[k]["name"].ToString().Trim() + " alter column xbid nvarchar(17)", selectConnection);
                            System.Data.DataTable table5 = new System.Data.DataTable();
                            adapter4.Fill(table5);
                            if (table5 == null)
                            {
                                MessageBox.Show("扩充" + table3.Rows[k]["name"].ToString().Trim() + "的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                System.Windows.Forms.Application.Exit();
                            }
                        }
                        str3 = "alter table T_TEMPLATES_XB alter column tdjyq nvarchar(2) ";
                        str3 = (str3 + " alter table T_TEMPLATES_XB alter column lmsyq nvarchar(2) ") + " alter table T_TEMPLATES_XB alter column lmjyq nvarchar(2) " + " alter table T_TEMPLATES_XB alter column xbid nvarchar(17) ";
                        if (!class2.GetExecute(str3))
                        {
                            MessageBox.Show("扩充小班模板表的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                        str3 = "alter table T_TEMPLATES_LASTXB alter column tdjyq nvarchar(2) ";
                        str3 = (str3 + " alter table T_TEMPLATES_LASTXB alter column lmsyq nvarchar(2) ") + " alter table T_TEMPLATES_LASTXB alter column lmjyq nvarchar(2) " + " alter table T_TEMPLATES_LASTXB alter column xbid nvarchar(17) ";
                        if (!class2.GetExecute(str3))
                        {
                            MessageBox.Show("扩充小班模板表的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                        string str6 = "select name from sysobjects where  [name] like 'T_META_CODE%' and xtype='U'";
                        SqlDataAdapter adapter5 = new SqlDataAdapter(str6, selectConnection);
                        System.Data.DataTable table6 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter5);
                        adapter5.Fill(table6);
                        for (int m = 0; m < table6.Rows.Count; m++)
                        {
                            SqlDataAdapter adapter6 = new SqlDataAdapter((((((((((((((((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set cname = '龙眼*' where cname = '龙眼' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set ccode = '256' where ccode = '342' and cname = '椴树' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '大桉' where ccode = '283' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '巨桉' where ccode = '292' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '赤桉' where ccode = '294' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '蓝桉' where ccode = '295' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '柳桉' where ccode = '299' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '大相思' where ccode = '318' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '大径竹' where ccode = '421' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '吊丝球' where ccode = '423' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '玉桂' where ccode = '681' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '栲胶' where ccode = '686' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set cname = '榜胶原料' where ccode = '686' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '其它化' where ccode = '689' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '银杏' where ccode = '691' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '其它药' where ccode = '699' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '其它果' where ccode = '646' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '其它食' where ccode = '674' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '小杂竹' where ccode = '813' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '锈竹' where ccode = '905' and ctype = '树种'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = '其它红' where ccode = '511' and ctype = '树种'", selectConnection);
                            System.Data.DataTable table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname =cname where csname = '' or csname is null", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname =cname where ctype = '经营措施类型'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='严格保护' where ctype = '经营管理类型' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='重点保护' where ctype = '经营管理类型' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='保护经营' where ctype = '经营管理类型' and ccode = '3'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='集约经营' where ctype = '经营管理类型' and ccode = '4'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非乔林' where ctype = '地类' and ccode = '961'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非灌经' where ctype = '地类' and ccode = '962'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非竹林' where ctype = '地类' and ccode = '963'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set ccode ='603' where ctype = '地类' and ccode = '6031'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='生物' where ctype = '高保护价值森林' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='景观' where ctype = '高保护价值森林' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='珍稀' where ctype = '高保护价值森林' and ccode = '3'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='生态' where ctype = '高保护价值森林' and ccode = '4'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='基本' where ctype = '高保护价值森林' and ccode = '5'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='文化' where ctype = '高保护价值森林' and ccode = '6'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname = cname where ctype = '地貌'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='中岩' where ctype = '地貌' and ccode = '11'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='低岩' where ctype = '地貌' and ccode = '21'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='丘岩' where ctype = '地貌' and ccode = '31'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='平岩' where ctype = '地貌' and ccode = '41'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='无' where ctype = '坡向' and ccode = '9'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set ctype ='公益林保护等级' where ctype = '国家公益林保护等级'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='重点公' where ctype = '森林类别' and ccode = '11'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='一般公' where ctype = '森林类别' and ccode = '12'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='重点商' where ctype = '森林类别' and ccode = '21'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='一般商' where ctype = '森林类别' and ccode = '22'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='国家' where ctype = '事权等级' and ccode = '10'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='区级' where ctype = '事权等级' and ccode = '21'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='一般' where ctype = '事权等级' and ccode = '22'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='大林道' where ctype = '线状物类型' and ccode = '12'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='公路' where ctype = '线状物类型' and ccode = '13'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='铁路' where ctype = '线状物类型' and ccode = '14'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname =cname where ctype = '坡向' and ccode <> '9'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='造林' where ctype = '经营措施类型' and ccode = '14'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='生态伐' where ctype = '经营措施类型' and ccode = '6'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='景观伐' where ctype = '经营措施类型' and ccode = '7'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='幼抚' where ctype = '经营措施类型' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='定抚' where ctype = '经营措施类型' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='水肥' where ctype = '经营措施类型' and ccode = '13'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='封育' where ctype = '经营措施类型' and ccode = '15'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='滨盐土' where ctype = '土壤类型' and ccode = '107'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='硅白土' where ctype = '土壤类型' and ccode = '108'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='沼泽土' where ctype = '土壤类型' and ccode = '116'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '土地权属' and ccode = '10'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '土地权属' and ccode = '20'") + "update " + table6.Rows[m]["name"].ToString().Trim() + " set cname ='国有' where ctype = '土地权属' and ccode = '10'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set cname ='集体' where ctype = '土地权属' and ccode = '20'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '土地使用权' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '土地使用权' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '土地使用权' and ccode = '3'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '土地使用权' and ccode = '4'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '土地使用权' and ccode = '5'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '土地使用权' and ccode = '6'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='被  占' where ctype = '土地使用权' and ccode = '7'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '土地使用权' and ccode = '8'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set cname ='其它' where ctype = '土地使用权' and ccode = '8'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '林木所有权' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '林木所有权' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '林木所有权' and ccode = '3'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '林木所有权' and ccode = '4'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '林木所有权' and ccode = '5'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '林木所有权' and ccode = '6'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '林木所有权' and ccode = '7'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set cname ='其它' where ctype = '林木所有权' and ccode = '7'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '林木使用权' and ccode = '1'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '林木使用权' and ccode = '2'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '林木使用权' and ccode = '3'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '林木使用权' and ccode = '4'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '林木使用权' and ccode = '5'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '林木使用权' and ccode = '6'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '林木使用权' and ccode = '7'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set cname ='其它' where ctype = '林木使用权' and ccode = '7'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter((((((("update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='天然' where ctype = '起源' and ccode = '11'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='人促' where ctype = '起源' and ccode = '12'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='萌芽' where ctype = '起源' and ccode = '13'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='人1' where ctype = '起源' and ccode = '31'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='人2' where ctype = '起源' and ccode = '32'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='人3' where ctype = '起源' and ccode = '33'") + " update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='人4' where ctype = '起源' and ccode = '34'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(" update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='重点公益林' where ctype = '工程类别' and ccode = '80'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(" update " + table6.Rows[m]["name"].ToString().Trim() + " set csname ='小径竹' where ctype = '树种' and ccode = '428'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((("delete " + table6.Rows[m]["name"].ToString().Trim() + " where (ccode = '380' or ccode = '412') and ctype = '树种'") + "delete " + table6.Rows[m]["name"].ToString().Trim() + " where (ccode = '11' or ccode = '51' or ccode = '52' or ccode = '53' or ccode = '71' or ccode = '72') and ctype = '土地使用权'") + "delete " + table6.Rows[m]["name"].ToString().Trim() + " where (ccode = '51') and ctype = '林木所有权'") + "delete " + table6.Rows[m]["name"].ToString().Trim() + " where (ccode = '51') and ctype = '林木使用权'", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','380','绿化树','绿化树','树种','','shu_zhong','','219','','3')", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter("insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','412','其它散生竹类','其散竹','树种','','shu_zhong','','219','','3')", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                            adapter6 = new SqlDataAdapter(((((((("insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','移交斯道','移交斯道','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','52','提前移交','提前移交','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','53','越界经营','越界经营','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','11','计划移交','计划移交','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','71','斯道被占','斯道被占','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','72','被占','被  占','土地使用权','','tdjyq','','208','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木所有权','','lmsyq','','209','','2')") + " insert into " + table6.Rows[m]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木使用权','','lmjyq','','209','','2')", selectConnection);
                            table7 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter6);
                            adapter6.Fill(table7);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("更新代码表出错" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                    try
                    {
                        string str8 = "update T_SYS_META_CODE set cname = '龙眼*' where cname = '龙眼' and ctype = '树种'";
                        SqlDataAdapter adapter7 = new SqlDataAdapter((((((((((str8 + " update T_SYS_META_CODE set ccode = '256' where ccode = '342' and cname = '椴树' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '大桉' where ccode = '283' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '巨桉' where ccode = '292' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '赤桉' where ccode = '294' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '蓝桉' where ccode = '295' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '柳桉' where ccode = '299' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '大相思' where ccode = '318' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '大径竹' where ccode = '421' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '吊丝球' where ccode = '423' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '玉桂' where ccode = '681' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '栲胶' where ccode = '686' and ctype = '树种'" + " update T_SYS_META_CODE set cname = '榜胶原料' where ccode = '686' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它化' where ccode = '689' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '银杏' where ccode = '691' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它药' where ccode = '699' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '其它果' where ccode = '646' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它食' where ccode = '674' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '小杂竹' where ccode = '813' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '锈竹' where ccode = '905' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '其它红' where ccode = '511' and ctype = '树种'", selectConnection);
                        System.Data.DataTable table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname =cname where csname = '' or csname is null";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname =cname where ctype = '经营措施类型'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='严格保护' where ctype = '经营管理类型' and ccode = '1'";
                        adapter7 = new SqlDataAdapter((str8 + " update T_SYS_META_CODE set csname ='重点保护' where ctype = '经营管理类型' and ccode = '2'") + " update T_SYS_META_CODE set csname ='保护经营' where ctype = '经营管理类型' and ccode = '3'" + " update T_SYS_META_CODE set csname ='集约经营' where ctype = '经营管理类型' and ccode = '4'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='非乔林' where ctype = '地类' and ccode = '961'";
                        adapter7 = new SqlDataAdapter(str8 + " update T_SYS_META_CODE set csname ='非灌经' where ctype = '地类' and ccode = '962'" + " update T_SYS_META_CODE set csname ='非竹林' where ctype = '地类' and ccode = '963'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set ccode ='603' where ctype = '地类' and ccode = '6031'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='生物' where ctype = '高保护价值森林' and ccode = '1'";
                        adapter7 = new SqlDataAdapter(((str8 + " update T_SYS_META_CODE set csname ='景观' where ctype = '高保护价值森林' and ccode = '2'") + " update T_SYS_META_CODE set csname ='珍稀' where ctype = '高保护价值森林' and ccode = '3'" + " update T_SYS_META_CODE set csname ='生态' where ctype = '高保护价值森林' and ccode = '4'") + " update T_SYS_META_CODE set csname ='基本' where ctype = '高保护价值森林' and ccode = '5'" + " update T_SYS_META_CODE set csname ='文化' where ctype = '高保护价值森林' and ccode = '6'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname = cname where ctype = '地貌'";
                        adapter7 = new SqlDataAdapter((str8 + " update T_SYS_META_CODE set csname ='中岩' where ctype = '地貌' and ccode = '11'" + " update T_SYS_META_CODE set csname ='低岩' where ctype = '地貌' and ccode = '21'") + " update T_SYS_META_CODE set csname ='丘岩' where ctype = '地貌' and ccode = '31'" + " update T_SYS_META_CODE set csname ='平岩' where ctype = '地貌' and ccode = '41'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='无' where ctype = '坡向' and ccode = '9'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set ctype ='公益林保护等级' where ctype = '国家公益林保护等级'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='重点公' where ctype = '森林类别' and ccode = '11'";
                        adapter7 = new SqlDataAdapter((str8 + " update T_SYS_META_CODE set csname ='一般公' where ctype = '森林类别' and ccode = '12'") + " update T_SYS_META_CODE set csname ='重点商' where ctype = '森林类别' and ccode = '21'" + " update T_SYS_META_CODE set csname ='一般商' where ctype = '森林类别' and ccode = '22'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='国家' where ctype = '事权等级' and ccode = '10'";
                        adapter7 = new SqlDataAdapter(str8 + " update T_SYS_META_CODE set csname ='区级' where ctype = '事权等级' and ccode = '21'" + " update T_SYS_META_CODE set csname ='一般' where ctype = '事权等级' and ccode = '22'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='大林道' where ctype = '线状物类型' and ccode = '12'";
                        adapter7 = new SqlDataAdapter(str8 + " update T_SYS_META_CODE set csname ='公路' where ctype = '线状物类型' and ccode = '13'" + " update T_SYS_META_CODE set csname ='铁路' where ctype = '线状物类型' and ccode = '14'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname =cname where ctype = '坡向' and ccode <> '9'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='造林' where ctype = '经营措施类型' and ccode = '14'";
                        adapter7 = new SqlDataAdapter(((str8 + " update T_SYS_META_CODE set csname ='生态伐' where ctype = '经营措施类型' and ccode = '6'" + " update T_SYS_META_CODE set csname ='景观伐' where ctype = '经营措施类型' and ccode = '7'") + " update T_SYS_META_CODE set csname ='幼抚' where ctype = '经营措施类型' and ccode = '1'" + " update T_SYS_META_CODE set csname ='定抚' where ctype = '经营措施类型' and ccode = '2'") + " update T_SYS_META_CODE set csname ='水肥' where ctype = '经营措施类型' and ccode = '13'" + " update T_SYS_META_CODE set csname ='封育' where ctype = '经营措施类型' and ccode = '15'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='滨盐土' where ctype = '土壤类型' and ccode = '107'";
                        adapter7 = new SqlDataAdapter(str8 + " update T_SYS_META_CODE set csname ='硅白土' where ctype = '土壤类型' and ccode = '108'" + " update T_SYS_META_CODE set csname ='沼泽土' where ctype = '土壤类型' and ccode = '116'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '土地权属' and ccode = '10'";
                        adapter7 = new SqlDataAdapter((str8 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '土地权属' and ccode = '20'") + "update T_SYS_META_CODE set cname ='国有' where ctype = '土地权属' and ccode = '10'" + " update T_SYS_META_CODE set cname ='集体' where ctype = '土地权属' and ccode = '20'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '土地使用权' and ccode = '1'";
                        adapter7 = new SqlDataAdapter((((str8 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '土地使用权' and ccode = '2'" + " update T_SYS_META_CODE set csname ='其他国' where ctype = '土地使用权' and ccode = '3'") + " update T_SYS_META_CODE set csname ='联  营' where ctype = '土地使用权' and ccode = '4'" + " update T_SYS_META_CODE set csname ='非公有' where ctype = '土地使用权' and ccode = '5'") + " update T_SYS_META_CODE set csname ='个  人' where ctype = '土地使用权' and ccode = '6'" + " update T_SYS_META_CODE set csname ='被  占' where ctype = '土地使用权' and ccode = '7'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '土地使用权' and ccode = '8'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '土地使用权' and ccode = '8'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '林木所有权' and ccode = '1'";
                        adapter7 = new SqlDataAdapter((((str8 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '林木所有权' and ccode = '2'") + " update T_SYS_META_CODE set csname ='其他国' where ctype = '林木所有权' and ccode = '3'" + " update T_SYS_META_CODE set csname ='联  营' where ctype = '林木所有权' and ccode = '4'") + " update T_SYS_META_CODE set csname ='非公有' where ctype = '林木所有权' and ccode = '5'" + " update T_SYS_META_CODE set csname ='个  人' where ctype = '林木所有权' and ccode = '6'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '林木所有权' and ccode = '7'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '林木所有权' and ccode = '7'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '林木使用权' and ccode = '1'";
                        adapter7 = new SqlDataAdapter((((str8 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '林木使用权' and ccode = '2'") + " update T_SYS_META_CODE set csname ='其他国' where ctype = '林木使用权' and ccode = '3'" + " update T_SYS_META_CODE set csname ='联  营' where ctype = '林木使用权' and ccode = '4'") + " update T_SYS_META_CODE set csname ='非公有' where ctype = '林木使用权' and ccode = '5'" + " update T_SYS_META_CODE set csname ='个  人' where ctype = '林木使用权' and ccode = '6'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '林木使用权' and ccode = '7'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '林木使用权' and ccode = '7'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "update T_SYS_META_CODE set csname ='天然' where ctype = '起源' and ccode = '11'";
                        adapter7 = new SqlDataAdapter(((str8 + " update T_SYS_META_CODE set csname ='人促' where ctype = '起源' and ccode = '12'" + " update T_SYS_META_CODE set csname ='萌芽' where ctype = '起源' and ccode = '13'") + " update T_SYS_META_CODE set csname ='人1' where ctype = '起源' and ccode = '31'" + " update T_SYS_META_CODE set csname ='人2' where ctype = '起源' and ccode = '32'") + " update T_SYS_META_CODE set csname ='人3' where ctype = '起源' and ccode = '33'" + " update T_SYS_META_CODE set csname ='人4' where ctype = '起源' and ccode = '34'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = " update T_SYS_META_CODE set csname ='重点公益林' where ctype = '工程类别' and ccode = '80'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = " update T_SYS_META_CODE set csname ='小径竹' where ctype = '树种' and ccode = '428'";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "delete T_SYS_META_CODE where (ccode = '380' or ccode = '412') and ctype = '树种'";
                        adapter7 = new SqlDataAdapter((str8 + "delete T_SYS_META_CODE where (ccode = '11' or ccode = '51' or ccode = '52' or ccode = '53' or ccode = '71' or ccode = '72') and ctype = '土地使用权'") + "delete T_SYS_META_CODE where (ccode = '51') and ctype = '林木所有权'" + "delete T_SYS_META_CODE where (ccode = '51') and ctype = '林木使用权'", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','380','绿化树','绿化树','树种','','shu_zhong','','219','','3')";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','412','其它散生竹类','其散竹','树种','','shu_zhong','','219','','3')";
                        adapter7 = new SqlDataAdapter(str8, selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                        str8 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','移交斯道','移交斯道','土地使用权','','tdjyq','','208','','2')";
                        adapter7 = new SqlDataAdapter((((str8 + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','52','提前移交','提前移交','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','53','越界经营','越界经营','土地使用权','','tdjyq','','208','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','11','计划移交','计划移交','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','71','斯道被占','斯道被占','土地使用权','','tdjyq','','208','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','72','被占','被  占','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木所有权','','lmsyq','','209','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木使用权','','lmjyq','','209','','2')", selectConnection);
                        table8 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter7);
                        adapter7.Fill(table8);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("更新代码模板表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf"))
                        {
                            string str9 = "TRUNCATE TABLE [T_SYS_META_LJLZ]";
                            if (this.GetExecute(str9))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_LJLZ");
                            }
                            else
                            {
                                MessageBox.Show("更新龄组龄级划分表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新龄组龄级划分表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf"))
                        {
                            string str10 = "DROP Table [T_SYS_META_LOGICCHECKRULE] CREATE TABLE [dbo].[T_SYS_META_LOGICCHECKRULE](    [OBJECTID] [int] identity(1,1),   [CODE] [numeric](10, 0) NULL,   [COLUMNNAME] [nvarchar](50) NULL,   [LOGICRULE] [nvarchar](254) NULL,   [TIPS] [nvarchar](254) NULL,   [JCDJ] [nvarchar](20) NULL ) ON [PRIMARY]";
                            if (this.GetExecute(str10))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_LOGICCHECKRULE");
                            }
                            else
                            {
                                MessageBox.Show("更新逻辑出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新逻辑表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf"))
                        {
                            string str11 = "TRUNCATE TABLE [T_SYS_META_DWBH]";
                            if (this.GetExecute(str11))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_DWBH");
                            }
                            else
                            {
                                MessageBox.Show("更新单位代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新单位代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf");
                        GC.Collect();
                    }
                    string cmdtxt = "select name from sysobjects where ([name] like 'T_SLSZHB%' or [name] like 'T_QMLSZHB%'or [name] like 'T_YCLSZHB%' or [name] like 'T_JJLSZHB%') and xtype='U'";
                    System.Data.DataTable table = new System.Data.DataTable();
                    table = this.GetTable(cmdtxt, "DelSYSTable");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string str13 = "drop table " + table.Rows[i]["name"].ToString().Trim();
                        if (!this.GetExecute(str13))
                        {
                            MessageBox.Show("升级出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf"))
                        {
                            string str14 = "TRUNCATE TABLE [T_Templates_SLSZHB]";
                            if (this.GetExecute(str14))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_SLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_YCLSZHB.dbf"))
                        {
                            string str15 = "TRUNCATE TABLE [T_Templates_YCLSZHB]";
                            if (this.GetExecute(str15))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_YCLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_YCLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新用材林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新用材林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf"))
                        {
                            string str16 = "TRUNCATE TABLE [T_Templates_QMLSZHB]";
                            if (this.GetExecute(str16))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_QMLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf"))
                        {
                            string str17 = "TRUNCATE TABLE [T_Templates_JJLSZHB]";
                            if (this.GetExecute(str17))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_JJLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新经济林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新经济林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf");
                        GC.Collect();
                    }
                    if (flag)
                    {
                        try
                        {
                            try
                            {
                                DataRow row = table2.NewRow();
                                row["version"] = "20140323";
                                table2.Rows.Add(row);
                                adapter.Update(table2);
                            }
                            catch (Exception exception2)
                            {
                                MessageBox.Show("更新版本表出错" + exception2.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                flag = false;
                            }
                            return;
                        }
                        finally
                        {
                            GC.Collect();
                        }
                    }
                    MessageBox.Show("更新失败，请联系开发人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (double.Parse(table2.Rows[0]["version"].ToString().Trim()) <= 20140322.0)
                {
                    try
                    {
                        Public_Class class3 = new Public_Class();
                        string str18 = "select name from sysobjects where  [name] like 'T_xb_45%' and xtype='U'";
                        SqlDataAdapter adapter8 = new SqlDataAdapter(str18, selectConnection);
                        System.Data.DataTable table10 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter8);
                        adapter8.Fill(table10);
                        for (int num5 = 0; num5 < table10.Rows.Count; num5++)
                        {
                            SqlDataAdapter adapter9 = new SqlDataAdapter((((" alter table " + table10.Rows[num5]["name"].ToString().Trim() + " alter column tdjyq nvarchar(2)") + " alter table " + table10.Rows[num5]["name"].ToString().Trim() + " alter column lmsyq nvarchar(2)") + " alter table " + table10.Rows[num5]["name"].ToString().Trim() + " alter column lmjyq nvarchar(2)") + " alter table " + table10.Rows[num5]["name"].ToString().Trim() + " alter column xbid nvarchar(17)", selectConnection);
                            System.Data.DataTable table11 = new System.Data.DataTable();
                            adapter9.Fill(table11);
                            if (table11 == null)
                            {
                                MessageBox.Show("扩充" + table10.Rows[num5]["name"].ToString().Trim() + "的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                System.Windows.Forms.Application.Exit();
                            }
                        }
                        str18 = "select name from sysobjects where  [name] like 'T_lastxb_45%' and xtype='U'";
                        adapter8 = new SqlDataAdapter(str18, selectConnection);
                        table10 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter8);
                        adapter8.Fill(table10);
                        for (int num6 = 0; num6 < table10.Rows.Count; num6++)
                        {
                            SqlDataAdapter adapter10 = new SqlDataAdapter((((" alter table " + table10.Rows[num6]["name"].ToString().Trim() + " alter column tdjyq nvarchar(2)") + " alter table " + table10.Rows[num6]["name"].ToString().Trim() + " alter column lmsyq nvarchar(2)") + " alter table " + table10.Rows[num6]["name"].ToString().Trim() + " alter column lmjyq nvarchar(2)") + " alter table " + table10.Rows[num6]["name"].ToString().Trim() + " alter column xbid nvarchar(17)", selectConnection);
                            System.Data.DataTable table12 = new System.Data.DataTable();
                            adapter10.Fill(table12);
                            if (table12 == null)
                            {
                                MessageBox.Show("扩充" + table10.Rows[num6]["name"].ToString().Trim() + "的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                System.Windows.Forms.Application.Exit();
                            }
                        }
                        str18 = "alter table T_TEMPLATES_XB alter column tdjyq nvarchar(2) ";
                        str18 = (str18 + " alter table T_TEMPLATES_XB alter column lmsyq nvarchar(2) ") + " alter table T_TEMPLATES_XB alter column lmjyq nvarchar(2) " + " alter table T_TEMPLATES_XB alter column xbid nvarchar(17) ";
                        if (!class3.GetExecute(str18))
                        {
                            MessageBox.Show("扩充小班模板表的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                        str18 = "alter table T_TEMPLATES_LASTXB alter column tdjyq nvarchar(2) ";
                        str18 = (str18 + " alter table T_TEMPLATES_LASTXB alter column lmsyq nvarchar(2) ") + " alter table T_TEMPLATES_LASTXB alter column lmjyq nvarchar(2) " + " alter table T_TEMPLATES_LASTXB alter column xbid nvarchar(17) ";
                        if (!class3.GetExecute(str18))
                        {
                            MessageBox.Show("扩充小班模板表的林地使用权、林木所有权、林木使用权三个字段的长度失败。请联系开发人员。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                        string str21 = "select name from sysobjects where  [name] like 'T_META_CODE%' and xtype='U'";
                        SqlDataAdapter adapter11 = new SqlDataAdapter(str21, selectConnection);
                        System.Data.DataTable table13 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter11);
                        adapter11.Fill(table13);
                        for (int num7 = 0; num7 < table13.Rows.Count; num7++)
                        {
                            SqlDataAdapter adapter12 = new SqlDataAdapter((((((((((((((((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname = '龙眼*' where cname = '龙眼' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set ccode = '256' where ccode = '342' and cname = '椴树' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '大桉' where ccode = '283' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '巨桉' where ccode = '292' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '赤桉' where ccode = '294' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '蓝桉' where ccode = '295' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '柳桉' where ccode = '299' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '大相思' where ccode = '318' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '大径竹' where ccode = '421' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '吊丝球' where ccode = '423' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '玉桂' where ccode = '681' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '栲胶' where ccode = '686' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname = '榜胶原料' where ccode = '686' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '其它化' where ccode = '689' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '银杏' where ccode = '691' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '其它药' where ccode = '699' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '其它果' where ccode = '646' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '其它食' where ccode = '674' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '小杂竹' where ccode = '813' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '锈竹' where ccode = '905' and ctype = '树种'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = '其它红' where ccode = '511' and ctype = '树种'", selectConnection);
                            System.Data.DataTable table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname =cname where csname = '' or csname is null", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname =cname where ctype = '经营措施类型'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='严格保护' where ctype = '经营管理类型' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='重点保护' where ctype = '经营管理类型' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='保护经营' where ctype = '经营管理类型' and ccode = '3'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='集约经营' where ctype = '经营管理类型' and ccode = '4'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非乔林' where ctype = '地类' and ccode = '961'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非灌经' where ctype = '地类' and ccode = '962'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非竹林' where ctype = '地类' and ccode = '963'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set ccode ='603' where ctype = '地类' and ccode = '6031'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='生物' where ctype = '高保护价值森林' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='景观' where ctype = '高保护价值森林' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='珍稀' where ctype = '高保护价值森林' and ccode = '3'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='生态' where ctype = '高保护价值森林' and ccode = '4'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='基本' where ctype = '高保护价值森林' and ccode = '5'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='文化' where ctype = '高保护价值森林' and ccode = '6'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname = cname where ctype = '地貌'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='中岩' where ctype = '地貌' and ccode = '11'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='低岩' where ctype = '地貌' and ccode = '21'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='丘岩' where ctype = '地貌' and ccode = '31'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='平岩' where ctype = '地貌' and ccode = '41'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='无' where ctype = '坡向' and ccode = '9'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set ctype ='公益林保护等级' where ctype = '国家公益林保护等级'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='重点公' where ctype = '森林类别' and ccode = '11'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='一般公' where ctype = '森林类别' and ccode = '12'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='重点商' where ctype = '森林类别' and ccode = '21'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='一般商' where ctype = '森林类别' and ccode = '22'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='国家' where ctype = '事权等级' and ccode = '10'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='区级' where ctype = '事权等级' and ccode = '21'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='一般' where ctype = '事权等级' and ccode = '22'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='大林道' where ctype = '线状物类型' and ccode = '12'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='公路' where ctype = '线状物类型' and ccode = '13'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='铁路' where ctype = '线状物类型' and ccode = '14'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname =cname where ctype = '坡向' and ccode <> '9'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='造林' where ctype = '经营措施类型' and ccode = '14'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='生态伐' where ctype = '经营措施类型' and ccode = '6'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='景观伐' where ctype = '经营措施类型' and ccode = '7'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='幼抚' where ctype = '经营措施类型' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='定抚' where ctype = '经营措施类型' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='水肥' where ctype = '经营措施类型' and ccode = '13'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='封育' where ctype = '经营措施类型' and ccode = '15'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='滨盐土' where ctype = '土壤类型' and ccode = '107'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='硅白土' where ctype = '土壤类型' and ccode = '108'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='沼泽土' where ctype = '土壤类型' and ccode = '116'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '土地权属' and ccode = '10'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '土地权属' and ccode = '20'") + "update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname ='国有' where ctype = '土地权属' and ccode = '10'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname ='集体' where ctype = '土地权属' and ccode = '20'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '土地使用权' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '土地使用权' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '土地使用权' and ccode = '3'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '土地使用权' and ccode = '4'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '土地使用权' and ccode = '5'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '土地使用权' and ccode = '6'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='被  占' where ctype = '土地使用权' and ccode = '7'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '土地使用权' and ccode = '8'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname ='其它' where ctype = '土地使用权' and ccode = '8'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '林木所有权' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '林木所有权' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '林木所有权' and ccode = '3'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '林木所有权' and ccode = '4'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '林木所有权' and ccode = '5'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '林木所有权' and ccode = '6'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '林木所有权' and ccode = '7'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname ='其它' where ctype = '林木所有权' and ccode = '7'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='国  有' where ctype = '林木使用权' and ccode = '1'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='集  体' where ctype = '林木使用权' and ccode = '2'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其他国' where ctype = '林木使用权' and ccode = '3'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='联  营' where ctype = '林木使用权' and ccode = '4'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='非公有' where ctype = '林木使用权' and ccode = '5'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='个  人' where ctype = '林木使用权' and ccode = '6'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='其  它' where ctype = '林木使用权' and ccode = '7'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set cname ='其它' where ctype = '林木使用权' and ccode = '7'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter((((((("update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='天然' where ctype = '起源' and ccode = '11'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='人促' where ctype = '起源' and ccode = '12'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='萌芽' where ctype = '起源' and ccode = '13'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='人1' where ctype = '起源' and ccode = '31'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='人2' where ctype = '起源' and ccode = '32'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='人3' where ctype = '起源' and ccode = '33'") + " update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='人4' where ctype = '起源' and ccode = '34'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(" update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='重点公益林' where ctype = '工程类别' and ccode = '80'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(" update " + table13.Rows[num7]["name"].ToString().Trim() + " set csname ='小径竹' where ctype = '树种' and ccode = '428'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((("delete " + table13.Rows[num7]["name"].ToString().Trim() + " where (ccode = '380' or ccode = '412') and ctype = '树种'") + "delete " + table13.Rows[num7]["name"].ToString().Trim() + " where (ccode = '11' or ccode = '51' or ccode = '52' or ccode = '53' or ccode = '71' or ccode = '72') and ctype = '土地使用权'") + "delete " + table13.Rows[num7]["name"].ToString().Trim() + " where (ccode = '51') and ctype = '林木所有权'") + "delete " + table13.Rows[num7]["name"].ToString().Trim() + " where (ccode = '51') and ctype = '林木使用权'", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','380','绿化树','绿化树','树种','','shu_zhong','','219','','3')", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter("insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','412','其它散生竹类','其散竹','树种','','shu_zhong','','219','','3')", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                            adapter12 = new SqlDataAdapter(((((((("insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','移交斯道','移交斯道','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','52','提前移交','提前移交','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','53','越界经营','越界经营','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','11','计划移交','计划移交','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','71','斯道被占','斯道被占','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','72','被占','被  占','土地使用权','','tdjyq','','208','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木所有权','','lmsyq','','209','','2')") + " insert into " + table13.Rows[num7]["name"].ToString().Trim() + " (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木使用权','','lmjyq','','209','','2')", selectConnection);
                            table14 = new System.Data.DataTable();
                            new SqlCommandBuilder(adapter12);
                            adapter12.Fill(table14);
                        }
                    }
                    catch (Exception exception3)
                    {
                        MessageBox.Show("更新代码表出错" + exception3.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                    try
                    {
                        string str23 = "update T_SYS_META_CODE set cname = '龙眼*' where cname = '龙眼' and ctype = '树种'";
                        SqlDataAdapter adapter13 = new SqlDataAdapter((((((((((str23 + " update T_SYS_META_CODE set ccode = '256' where ccode = '342' and cname = '椴树' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '大桉' where ccode = '283' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '巨桉' where ccode = '292' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '赤桉' where ccode = '294' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '蓝桉' where ccode = '295' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '柳桉' where ccode = '299' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '大相思' where ccode = '318' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '大径竹' where ccode = '421' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '吊丝球' where ccode = '423' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '玉桂' where ccode = '681' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '栲胶' where ccode = '686' and ctype = '树种'" + " update T_SYS_META_CODE set cname = '榜胶原料' where ccode = '686' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它化' where ccode = '689' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '银杏' where ccode = '691' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它药' where ccode = '699' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '其它果' where ccode = '646' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '其它食' where ccode = '674' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '小杂竹' where ccode = '813' and ctype = '树种'") + " update T_SYS_META_CODE set csname = '锈竹' where ccode = '905' and ctype = '树种'" + " update T_SYS_META_CODE set csname = '其它红' where ccode = '511' and ctype = '树种'", selectConnection);
                        System.Data.DataTable table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname =cname where csname = '' or csname is null";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname =cname where ctype = '经营措施类型'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='严格保护' where ctype = '经营管理类型' and ccode = '1'";
                        adapter13 = new SqlDataAdapter((str23 + " update T_SYS_META_CODE set csname ='重点保护' where ctype = '经营管理类型' and ccode = '2'") + " update T_SYS_META_CODE set csname ='保护经营' where ctype = '经营管理类型' and ccode = '3'" + " update T_SYS_META_CODE set csname ='集约经营' where ctype = '经营管理类型' and ccode = '4'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='非乔林' where ctype = '地类' and ccode = '961'";
                        adapter13 = new SqlDataAdapter(str23 + " update T_SYS_META_CODE set csname ='非灌经' where ctype = '地类' and ccode = '962'" + " update T_SYS_META_CODE set csname ='非竹林' where ctype = '地类' and ccode = '963'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set ccode ='603' where ctype = '地类' and ccode = '6031'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='生物' where ctype = '高保护价值森林' and ccode = '1'";
                        adapter13 = new SqlDataAdapter(((str23 + " update T_SYS_META_CODE set csname ='景观' where ctype = '高保护价值森林' and ccode = '2'") + " update T_SYS_META_CODE set csname ='珍稀' where ctype = '高保护价值森林' and ccode = '3'" + " update T_SYS_META_CODE set csname ='生态' where ctype = '高保护价值森林' and ccode = '4'") + " update T_SYS_META_CODE set csname ='基本' where ctype = '高保护价值森林' and ccode = '5'" + " update T_SYS_META_CODE set csname ='文化' where ctype = '高保护价值森林' and ccode = '6'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname = cname where ctype = '地貌'";
                        adapter13 = new SqlDataAdapter((str23 + " update T_SYS_META_CODE set csname ='中岩' where ctype = '地貌' and ccode = '11'" + " update T_SYS_META_CODE set csname ='低岩' where ctype = '地貌' and ccode = '21'") + " update T_SYS_META_CODE set csname ='丘岩' where ctype = '地貌' and ccode = '31'" + " update T_SYS_META_CODE set csname ='平岩' where ctype = '地貌' and ccode = '41'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='无' where ctype = '坡向' and ccode = '9'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set ctype ='公益林保护等级' where ctype = '国家公益林保护等级'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='重点公' where ctype = '森林类别' and ccode = '11'";
                        adapter13 = new SqlDataAdapter((str23 + " update T_SYS_META_CODE set csname ='一般公' where ctype = '森林类别' and ccode = '12'") + " update T_SYS_META_CODE set csname ='重点商' where ctype = '森林类别' and ccode = '21'" + " update T_SYS_META_CODE set csname ='一般商' where ctype = '森林类别' and ccode = '22'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='国家' where ctype = '事权等级' and ccode = '10'";
                        adapter13 = new SqlDataAdapter(str23 + " update T_SYS_META_CODE set csname ='区级' where ctype = '事权等级' and ccode = '21'" + " update T_SYS_META_CODE set csname ='一般' where ctype = '事权等级' and ccode = '22'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='大林道' where ctype = '线状物类型' and ccode = '12'";
                        adapter13 = new SqlDataAdapter(str23 + " update T_SYS_META_CODE set csname ='公路' where ctype = '线状物类型' and ccode = '13'" + " update T_SYS_META_CODE set csname ='铁路' where ctype = '线状物类型' and ccode = '14'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname =cname where ctype = '坡向' and ccode <> '9'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='造林' where ctype = '经营措施类型' and ccode = '14'";
                        adapter13 = new SqlDataAdapter(((str23 + " update T_SYS_META_CODE set csname ='生态伐' where ctype = '经营措施类型' and ccode = '6'" + " update T_SYS_META_CODE set csname ='景观伐' where ctype = '经营措施类型' and ccode = '7'") + " update T_SYS_META_CODE set csname ='幼抚' where ctype = '经营措施类型' and ccode = '1'" + " update T_SYS_META_CODE set csname ='定抚' where ctype = '经营措施类型' and ccode = '2'") + " update T_SYS_META_CODE set csname ='水肥' where ctype = '经营措施类型' and ccode = '13'" + " update T_SYS_META_CODE set csname ='封育' where ctype = '经营措施类型' and ccode = '15'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='滨盐土' where ctype = '土壤类型' and ccode = '107'";
                        adapter13 = new SqlDataAdapter(str23 + " update T_SYS_META_CODE set csname ='硅白土' where ctype = '土壤类型' and ccode = '108'" + " update T_SYS_META_CODE set csname ='沼泽土' where ctype = '土壤类型' and ccode = '116'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '土地权属' and ccode = '10'";
                        adapter13 = new SqlDataAdapter((str23 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '土地权属' and ccode = '20'") + "update T_SYS_META_CODE set cname ='国有' where ctype = '土地权属' and ccode = '10'" + " update T_SYS_META_CODE set cname ='集体' where ctype = '土地权属' and ccode = '20'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '土地使用权' and ccode = '1'";
                        adapter13 = new SqlDataAdapter((((str23 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '土地使用权' and ccode = '2'" + " update T_SYS_META_CODE set csname ='其他国' where ctype = '土地使用权' and ccode = '3'") + " update T_SYS_META_CODE set csname ='联  营' where ctype = '土地使用权' and ccode = '4'" + " update T_SYS_META_CODE set csname ='非公有' where ctype = '土地使用权' and ccode = '5'") + " update T_SYS_META_CODE set csname ='个  人' where ctype = '土地使用权' and ccode = '6'" + " update T_SYS_META_CODE set csname ='被  占' where ctype = '土地使用权' and ccode = '7'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '土地使用权' and ccode = '8'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '土地使用权' and ccode = '8'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '林木所有权' and ccode = '1'";
                        adapter13 = new SqlDataAdapter((((str23 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '林木所有权' and ccode = '2'") + " update T_SYS_META_CODE set csname ='其他国' where ctype = '林木所有权' and ccode = '3'" + " update T_SYS_META_CODE set csname ='联  营' where ctype = '林木所有权' and ccode = '4'") + " update T_SYS_META_CODE set csname ='非公有' where ctype = '林木所有权' and ccode = '5'" + " update T_SYS_META_CODE set csname ='个  人' where ctype = '林木所有权' and ccode = '6'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '林木所有权' and ccode = '7'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '林木所有权' and ccode = '7'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='国  有' where ctype = '林木使用权' and ccode = '1'";
                        adapter13 = new SqlDataAdapter((((str23 + " update T_SYS_META_CODE set csname ='集  体' where ctype = '林木使用权' and ccode = '2'") + " update T_SYS_META_CODE set csname ='其他国' where ctype = '林木使用权' and ccode = '3'" + " update T_SYS_META_CODE set csname ='联  营' where ctype = '林木使用权' and ccode = '4'") + " update T_SYS_META_CODE set csname ='非公有' where ctype = '林木使用权' and ccode = '5'" + " update T_SYS_META_CODE set csname ='个  人' where ctype = '林木使用权' and ccode = '6'") + " update T_SYS_META_CODE set csname ='其  它' where ctype = '林木使用权' and ccode = '7'" + " update T_SYS_META_CODE set cname ='其它' where ctype = '林木使用权' and ccode = '7'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "update T_SYS_META_CODE set csname ='天然' where ctype = '起源' and ccode = '11'";
                        adapter13 = new SqlDataAdapter(((str23 + " update T_SYS_META_CODE set csname ='人促' where ctype = '起源' and ccode = '12'" + " update T_SYS_META_CODE set csname ='萌芽' where ctype = '起源' and ccode = '13'") + " update T_SYS_META_CODE set csname ='人1' where ctype = '起源' and ccode = '31'" + " update T_SYS_META_CODE set csname ='人2' where ctype = '起源' and ccode = '32'") + " update T_SYS_META_CODE set csname ='人3' where ctype = '起源' and ccode = '33'" + " update T_SYS_META_CODE set csname ='人4' where ctype = '起源' and ccode = '34'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = " update T_SYS_META_CODE set csname ='重点公益林' where ctype = '工程类别' and ccode = '80'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = " update T_SYS_META_CODE set csname ='小径竹' where ctype = '树种' and ccode = '428'";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "delete T_SYS_META_CODE where (ccode = '380' or ccode = '412') and ctype = '树种'";
                        adapter13 = new SqlDataAdapter((str23 + "delete T_SYS_META_CODE where (ccode = '11' or ccode = '51' or ccode = '52' or ccode = '53' or ccode = '71' or ccode = '72') and ctype = '土地使用权'") + "delete T_SYS_META_CODE where (ccode = '51') and ctype = '林木所有权'" + "delete T_SYS_META_CODE where (ccode = '51') and ctype = '林木使用权'", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','380','绿化树','绿化树','树种','','shu_zhong','','219','','3')";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','412','其它散生竹类','其散竹','树种','','shu_zhong','','219','','3')";
                        adapter13 = new SqlDataAdapter(str23, selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                        str23 = "insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','移交斯道','移交斯道','土地使用权','','tdjyq','','208','','2')";
                        adapter13 = new SqlDataAdapter((((str23 + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','52','提前移交','提前移交','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','53','越界经营','越界经营','土地使用权','','tdjyq','','208','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','11','计划移交','计划移交','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','71','斯道被占','斯道被占','土地使用权','','tdjyq','','208','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','72','被占','被  占','土地使用权','','tdjyq','','208','','2')") + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木所有权','','lmsyq','','209','','2')" + " insert into T_SYS_META_CODE (pcode,CCODE ,CNAME,CSNAME ,CTYPE ,ccatog,CDOMAIN ,cextinf,CINDEX ,cyear ,CLEN ) values('','51','斯道','斯  道','林木使用权','','lmjyq','','209','','2')", selectConnection);
                        table15 = new System.Data.DataTable();
                        new SqlCommandBuilder(adapter13);
                        adapter13.Fill(table15);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("更新代码模板表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf"))
                        {
                            string str24 = "TRUNCATE TABLE [T_SYS_META_LJLZ]";
                            if (this.GetExecute(str24))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_LJLZ");
                            }
                            else
                            {
                                MessageBox.Show("更新龄组龄级划分表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新龄组龄级划分表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LJLZ.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf"))
                        {
                            string str25 = "DROP Table [T_SYS_META_LOGICCHECKRULE] CREATE TABLE [dbo].[T_SYS_META_LOGICCHECKRULE](    [OBJECTID] [int] identity(1,1),   [CODE] [numeric](10, 0) NULL,   [COLUMNNAME] [nvarchar](50) NULL,   [LOGICRULE] [nvarchar](254) NULL,   [TIPS] [nvarchar](254) NULL,   [JCDJ] [nvarchar](20) NULL ) ON [PRIMARY]";
                            if (this.GetExecute(str25))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_LOGICCHECKRULE");
                            }
                            else
                            {
                                MessageBox.Show("更新逻辑出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新逻辑表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_LogicCheckRule.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf"))
                        {
                            string str26 = "TRUNCATE TABLE [T_SYS_META_DWBH]";
                            if (this.GetExecute(str26))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_SYS_META_DWBH");
                            }
                            else
                            {
                                MessageBox.Show("更新单位代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新单位代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_SYS_META_DWBH.dbf");
                        GC.Collect();
                    }
                    string str27 = "select name from sysobjects where ([name] like 'T_SLSZHB%' or [name] like 'T_QMLSZHB%'or [name] like 'T_YCLSZHB%' or [name] like 'T_JJLSZHB%') and xtype='U'";
                    System.Data.DataTable table16 = new System.Data.DataTable();
                    table16 = this.GetTable(str27, "DelSYSTable");
                    for (int n = 0; n < table16.Rows.Count; n++)
                    {
                        string str28 = "drop table " + table16.Rows[n]["name"].ToString().Trim();
                        if (!this.GetExecute(str28))
                        {
                            MessageBox.Show("升级出错", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf"))
                        {
                            string str29 = "TRUNCATE TABLE [T_Templates_SLSZHB]";
                            if (this.GetExecute(str29))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_SLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_YCLSZHB.dbf"))
                        {
                            string str30 = "TRUNCATE TABLE [T_Templates_YCLSZHB]";
                            if (this.GetExecute(str30))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_YCLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_YCLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新用材林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新用材林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_SLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf"))
                        {
                            string str31 = "TRUNCATE TABLE [T_Templates_QMLSZHB]";
                            if (this.GetExecute(str31))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_QMLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新森林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_QMLSZHB.dbf");
                        GC.Collect();
                    }
                    try
                    {
                        if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf"))
                        {
                            string str32 = "TRUNCATE TABLE [T_Templates_JJLSZHB]";
                            if (this.GetExecute(str32))
                            {
                                this.UpdateSYSTable(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf", "*", M_Str_ConnectionDataBaseName + ".dbo.T_Templates_JJLSZHB");
                            }
                            else
                            {
                                MessageBox.Show("更新经济林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("更新经济林树种代码表出错。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    }
                    finally
                    {
                        File.Delete(System.Windows.Forms.Application.StartupPath + @"\\T_Templates_JJLSZHB.dbf");
                        GC.Collect();
                    }
                    if (flag)
                    {
                        try
                        {
                            try
                            {
                                table2.Rows[0]["version"] = "20140323";
                                adapter.Update(table2);
                            }
                            catch (Exception exception4)
                            {
                                MessageBox.Show("更新版本表出错" + exception4.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                flag = false;
                            }
                            return;
                        }
                        finally
                        {
                            GC.Collect();
                        }
                    }
                    MessageBox.Show("更新失败，请联系开发人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception exception5)
            {
                MessageBox.Show(exception5.Message.ToString(), "更新出错，请联系开发人员。", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                System.Windows.Forms.Application.Exit();
            }
            finally
            {
                selectConnection.Close();
                GC.Collect();
            }
        }

        public string CheckImportData(string pPath)
        {
            string str = "";
            DataSet dataSet = new DataSet();
            string str2 = pPath;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str2 + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string selectCommandText = "SELECT * FROM [" + str2 + "]";
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = selectConnectionString;
            int num = 1;
            OdbcConnection connection2 = new OdbcConnection();
            connection2.ConnectionString = selectConnectionString;
            connection2.Open();
            OdbcDataReader reader = new OdbcCommand("select * from " + str2, connection2).ExecuteReader(CommandBehavior.KeyInfo);
            System.Data.DataTable schemaTable = new System.Data.DataTable();
            schemaTable = reader.GetSchemaTable();
            try
            {
                connection.Open();
                new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SourceData");
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    num++;
                    string str5 = "";
                    if (dataSet.Tables[0].Columns[i].DataType == typeof(string))
                    {
                        str5 = " select distinct ISDIGIT(" + dataSet.Tables[0].Columns[i].ColumnName + "), " + dataSet.Tables[0].Columns[i].ColumnName + " from " + str2;
                    }
                    else
                    {
                        str5 = " select distinct ISDIGIT(alltrim(str(" + dataSet.Tables[0].Columns[i].ColumnName + "))), " + dataSet.Tables[0].Columns[i].ColumnName + " from " + str2;
                    }
                    OdbcDataAdapter adapter2 = new OdbcDataAdapter(str5, selectConnectionString);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter2.Fill(dataTable);
                    if (dataTable.Rows.Count > 1)
                    {
                        for (int j = 0; j < dataTable.Rows.Count; j++)
                        {
                            int num4;
                            if ((dataTable.Rows[j][0].ToString().Trim() == "False") && (dataTable.Rows[j][1].ToString().Trim() != ""))
                            {
                                string str7 = str;
                                str = str7 + dataSet.Tables[0].Columns[i].ColumnName + "字段里含有：“" + dataTable.Rows[j][1].ToString().Trim() + "”,为非数字字符，请检查修改好再导入。\r\n";
                            }
                            if (dataTable.Columns[1].DataType == typeof(string))
                            {
                                num4 = 0;
                                while (num4 < schemaTable.Rows.Count)
                                {
                                    if (schemaTable.Rows[num4]["columnname"].ToString().Trim() == dataTable.Columns[1].ColumnName.ToString().Trim())
                                    {
                                        goto Label_0349;
                                    }
                                    num4++;
                                }
                            }
                            continue;
                        Label_0349:
                            if (int.Parse(schemaTable.Rows[num4]["columnsize"].ToString().Trim()) < dataTable.Rows[j][1].ToString().Length)
                            {
                                str = str + dataSet.Tables[0].Columns[i].ColumnName.ToString().Trim() + "该字段有超过长度的值，请检查修改好再导入。\r\n";
                            }
                        }
                    }
                }
                if (str != "")
                {
                    return ("已完成检查，\r\n" + str);
                }
                return "已完成检查，数据没发现异常。";
            }
            catch (Exception exception)
            {
                return (exception.Message + num.ToString());
            }
        }

        public bool DelRecord(string mytablename, string pSQLCommand)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(M_Str_ConnectionString);
            try
            {
                connection.Open();
                new SqlCommand(pSQLCommand, connection).ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("清空数据库记录表错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public void ExportDataFromDataTable(System.Data.DataTable pDataTable, string pTitle)
        {
            try
            {
                string path = "";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "请为输出的Excel表选择一个存储位置";
                dialog.Filter = "Excel表(*.xls)|*.xls";
                dialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(dialog.FileName);
                    string cmdText = "第一个字段 char(20)";
                    cmdText = "Create Table " + fileNameWithoutExtension + " (" + cmdText + ")";
                    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=;Extended properties=Excel 5.0;Data Source=" + path);
                    connection.Open();
                    new OleDbCommand(cmdText, connection).ExecuteNonQuery();
                    connection.Close();
                    int count = pDataTable.Rows.Count;
                    int num2 = pDataTable.Columns.Count;
                    object[,] objArray = new object[count, num2];
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < num2; j++)
                        {
                            objArray[i, j] = pDataTable.Rows[i][j].ToString();
                        }
                    }
                    Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                    if (application == null)
                    {
                        MessageBox.Show("不能建立Microsoft.Office.Interop.Excel对象，请在机器上安装Excel", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        application.Visible = false;
                        Workbook workbook = application.Workbooks.Open(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                        Worksheet worksheet = application.Sheets[1] as Worksheet;
                        worksheet.Cells[1, 1] = pTitle;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).MergeCells = true;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).VerticalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).Font.Size = 12;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).Font.Bold = true;
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, pDataTable.Columns.Count]).RowHeight = 0x12;
                        for (int k = 0; k < pDataTable.Columns.Count; k++)
                        {
                            worksheet.Cells[2, k + 1] = pDataTable.Columns[k].ColumnName;
                        }
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).VerticalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).Font.Bold = true;
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).RowHeight = 0x12;
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).Borders.LineStyle = 1;
                        worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, pDataTable.Columns.Count]).NumberFormatLocal = "@";
                        int num1 = worksheet.UsedRange.Rows.Count;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).VerticalAlignment = XlHAlign.xlHAlignCenter;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).Borders.LineStyle = 1;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).EntireRow.Delete(Missing.Value);
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).RowHeight = 0x12;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).NumberFormatLocal = "@";
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[2, pDataTable.Columns.Count]).EntireColumn.AutoFit();
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).Value2 = objArray;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).Borders.LineStyle = 1;
                        worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[count + 2, num2]).EntireColumn.AutoFit();
                        worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 1]).ColumnWidth = 12;
                        worksheet.PageSetup.CenterHorizontally = true;
                        workbook.Save();
                        worksheet = null;
                        workbook = null;
                        application.Workbooks.Close();
                        application.Quit();
                        application = null;
                        MessageBox.Show("数据导出Excel完成!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                GC.Collect();
            }
        }

        public SqlConnection GetCon()
        {
            if (M_Str_ConnectionString == null)
            {
                return null;
            }
            this.M_SqlConnection = new SqlConnection(M_Str_ConnectionString);
            try
            {
                this.M_SqlConnection.Open();
                return this.M_SqlConnection;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "连接数据库错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        public System.Data.DataTable GetDataTableFromDBF(string pDBFPath, string pSQLCommand)
        {
            System.Data.DataTable table2;
            string str = pDBFPath;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = selectConnectionString;
            try
            {
                connection.Open();
                OdbcDataAdapter adapter = new OdbcDataAdapter(pSQLCommand, selectConnectionString);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("打开dbf表错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return table2;
        }

        public DataSet GetDs(string cmdtxt)
        {
            DataSet set;
            if (M_Str_ConnectionString == null)
            {
                MessageBox.Show("请先进行数据库连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
            try
            {
                this.M_SqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(cmdtxt, this.GetCon());
                command.CommandTimeout = 0;
                this.M_SqlDataAdapter.SelectCommand = command;
                this.M_Dataset = new DataSet();
                this.M_SqlDataAdapter.Fill(this.M_Dataset);
                set = this.M_Dataset;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                set = null;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return set;
        }

        public bool GetExecute(string cmdtxt)
        {
            bool flag;
            if (M_Str_ConnectionString == null)
            {
                return false;
            }
            this.M_SqlCommand = new SqlCommand(cmdtxt, this.GetCon());
            this.M_SqlCommand.CommandTimeout = 0;
            try
            {
                this.M_SqlCommand.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return flag;
        }

        public SqlDataReader GetReader(string cmdtxt)
        {
            SqlDataReader reader2;
            this.M_SqlCommand = new SqlCommand(cmdtxt, this.GetCon());
            try
            {
                reader2 = this.M_SqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                reader2 = null;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return reader2;
        }

        public System.Data.DataTable GetTable(string cmdtxt, string tablename)
        {
            System.Data.DataTable table2;
            try
            {
                this.M_SqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(cmdtxt, this.GetCon());
                command.CommandTimeout = 0;
                this.M_SqlDataAdapter.SelectCommand = command;
                System.Data.DataTable dataTable = new System.Data.DataTable(tablename);
                this.M_SqlDataAdapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return table2;
        }

        public bool GetXcdm(string xcdmfilename)
        {
            bool flag;
            string str = xcdmfilename.Substring(xcdmfilename.Length - 3, 3);
            DataSet dataSet = new DataSet();
            if ((str != "xls") && (str != "XLS"))
            {
                if ((str != "dbf") && (str != "DBF"))
                {
                    return false;
                }
                string str6 = xcdmfilename;
                string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str6 + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
                string selectCommandText = "SELECT dm,hy FROM " + str6;
                OdbcConnection connection2 = new OdbcConnection();
                connection2.ConnectionString = selectConnectionString;
                try
                {
                    connection2.Open();
                    new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "xcdmdbf");
                    this.LoadDsXcdmToDB(dataSet);
                    return true;
                }
                catch (Exception exception2)
                {
                    MessageBox.Show("导入乡村代码dbf表错误：" + exception2.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                    return false;
                }
                finally
                {
                    connection2.Close();
                }
            }
            string str2 = xcdmfilename;
            OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str2 + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'");
            try
            {
                selectConnection.Open();
                string str4 = selectConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0][2].ToString().Trim();
                string[] strArray = str4.Split(new char[] { '\'' });
                if (strArray.Length > 1)
                {
                    str4 = strArray[1];
                }
                new OleDbDataAdapter("SELECT dm,hy FROM [" + str4 + "]", selectConnection).Fill(dataSet, "xcdmxls");
                this.LoadDsXcdmToDB(dataSet);
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("导入乡村代码xls表错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                selectConnection.Close();
            }
            return flag;
        }

        public bool ImportData(string pImportFilename, string pColumnNames, string pTargetTableName)
        {
            bool flag;
            string str = pImportFilename.Substring(pImportFilename.Length - 3, 3);
            DataSet dataSet = new DataSet();
            if (str.ToUpper() == "XLS")
            {
                string str2 = pImportFilename;
                OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str2 + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'");
                try
                {
                    selectConnection.Open();
                    string str4 = selectConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0][2].ToString().Trim();
                    string[] strArray = str4.Split(new char[] { '\'' });
                    if (strArray.Length > 1)
                    {
                        str4 = strArray[1];
                    }
                    new OleDbDataAdapter("SELECT " + pColumnNames + " FROM [" + str4 + "]", selectConnection).Fill(dataSet, "SourceData");
                    SqlBulkCopy copy = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                    copy.DestinationTableName = pTargetTableName;
                    System.Data.DataTable table = new System.Data.DataTable();
                    table = this.GetTable("select top 1 * from " + pTargetTableName, pTargetTableName);
                    for (int i = 0; i < dataSet.Tables["SourceData"].Columns.Count; i++)
                    {
                        copy.ColumnMappings.Add(dataSet.Tables["SourceData"].Columns[i].ColumnName, table.Columns[i + 1].ColumnName);
                    }
                    copy.WriteToServer(dataSet.Tables["SourceData"]);
                    string str6 = this.GetTable("select count(objectid) from " + pTargetTableName, pTargetTableName).Rows[0][0].ToString();
                    MessageBox.Show("共导入" + dataSet.Tables["SourceData"].Rows.Count.ToString() + "条记录，当前" + M_str_dwmc + "的数据表里共有" + str6 + "条记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("导入数据错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                finally
                {
                    selectConnection.Close();
                }
            }
            if (str.ToUpper() != "DBF")
            {
                return false;
            }
            string str7 = pImportFilename;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str7 + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string selectCommandText = "SELECT " + pColumnNames + " FROM [" + str7 + "]";
            OdbcConnection connection2 = new OdbcConnection();
            connection2.ConnectionString = selectConnectionString;
            try
            {
                connection2.Open();
                new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SourceData");
                SqlBulkCopy copy2 = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                copy2.DestinationTableName = pTargetTableName;
                System.Data.DataTable table3 = new System.Data.DataTable();
                table3 = this.GetTable("select top 1 * from " + pTargetTableName, pTargetTableName);
                for (int j = 0; j < dataSet.Tables["SourceData"].Columns.Count; j++)
                {
                    int num3 = 0;
                    while (num3 < table3.Columns.Count)
                    {
                        if (table3.Columns[num3].ColumnName.ToLower() == dataSet.Tables["SourceData"].Columns[j].ColumnName.ToLower())
                        {
                            goto Label_03B0;
                        }
                        num3++;
                    }
                    continue;
                Label_03B0:
                    copy2.ColumnMappings.Add(dataSet.Tables["SourceData"].Columns[j].ColumnName, table3.Columns[num3].ColumnName);
                }
                copy2.WriteToServer(dataSet.Tables["SourceData"]);
                string str10 = this.GetTable("select count(objectid) from " + pTargetTableName, pTargetTableName).Rows[0][0].ToString();
                MessageBox.Show("共导入" + dataSet.Tables["SourceData"].Rows.Count.ToString() + "条记录，当前" + M_str_dwmc + "的数据表里共有" + str10 + "条记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag = true;
            }
            catch (Exception exception2)
            {
                MessageBox.Show("导入数据错误：" + exception2.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection2.Close();
                GC.Collect();
            }
            return flag;
        }

        public bool ImportLastXBData(string pImportFilename, string pTargetTableName)
        {
            bool flag;
            DataSet dataSet = new DataSet();
            string str = pImportFilename;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string selectCommandText = "SELECT * FROM [" + str + "]";
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = selectConnectionString;
            try
            {
                connection.Open();
                new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SourceData");
                selectCommandText = "SELECT * FROM " + System.Windows.Forms.Application.StartupPath + @"\lastxb_template.dbf";
                connection = new OdbcConnection();
                connection.ConnectionString = selectConnectionString;
                connection.Open();
                OdbcDataAdapter adapter = new OdbcDataAdapter(selectCommandText, selectConnectionString);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dataTable.Merge(dataSet.Tables["SourceData"], false);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((dataTable.Rows[i]["tdzl"].ToString().Trim() == "113") || (dataTable.Rows[i]["tdzl"].ToString().Trim() == "114"))
                    {
                        dataTable.Rows[i]["tdzl"] = "961";
                    }
                    if (dataTable.Rows[i]["tdzl"].ToString().Trim() == "303")
                    {
                        dataTable.Rows[i]["tdzl"] = "962";
                    }
                    if (dataTable.Rows[i]["tdzl"].ToString().Trim() == "131")
                    {
                        dataTable.Rows[i]["tdzl"] = "963";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "11")
                    {
                        dataTable.Rows[i]["lz"] = "111";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "12")
                    {
                        dataTable.Rows[i]["lz"] = "112";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "13")
                    {
                        dataTable.Rows[i]["lz"] = "113";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "14")
                    {
                        dataTable.Rows[i]["lz"] = "114";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "15")
                    {
                        dataTable.Rows[i]["lz"] = "115";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "16")
                    {
                        dataTable.Rows[i]["lz"] = "116";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "17")
                    {
                        dataTable.Rows[i]["lz"] = "117";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "21")
                    {
                        dataTable.Rows[i]["lz"] = "121";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "22")
                    {
                        dataTable.Rows[i]["lz"] = "122";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "23")
                    {
                        dataTable.Rows[i]["lz"] = "123";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "24")
                    {
                        dataTable.Rows[i]["lz"] = "124";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "25")
                    {
                        dataTable.Rows[i]["lz"] = "125";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "26")
                    {
                        dataTable.Rows[i]["lz"] = "126";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "27")
                    {
                        dataTable.Rows[i]["lz"] = "127";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "31")
                    {
                        dataTable.Rows[i]["lz"] = "231";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "32")
                    {
                        dataTable.Rows[i]["lz"] = "232";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "33")
                    {
                        dataTable.Rows[i]["lz"] = "233";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "40")
                    {
                        dataTable.Rows[i]["lz"] = "240";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "51")
                    {
                        dataTable.Rows[i]["lz"] = "251";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "52")
                    {
                        dataTable.Rows[i]["lz"] = "252";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "53")
                    {
                        dataTable.Rows[i]["lz"] = "253";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "54")
                    {
                        dataTable.Rows[i]["lz"] = "254";
                    }
                    if (dataTable.Rows[i]["lz"].ToString().Trim() == "55")
                    {
                        dataTable.Rows[i]["lz"] = "255";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "11")
                    {
                        dataTable.Rows[i]["qy1"] = "11";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "12")
                    {
                        dataTable.Rows[i]["qy1"] = "13";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "21")
                    {
                        dataTable.Rows[i]["qy1"] = "22";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "22")
                    {
                        dataTable.Rows[i]["qy1"] = "21";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "23")
                    {
                        dataTable.Rows[i]["qy1"] = "25";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "24")
                    {
                        dataTable.Rows[i]["qy1"] = "26";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "25")
                    {
                        dataTable.Rows[i]["qy1"] = "12";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "26")
                    {
                        dataTable.Rows[i]["qy1"] = "31";
                    }
                    if (dataTable.Rows[i]["qy1"].ToString().Trim() == "30")
                    {
                        dataTable.Rows[i]["qy1"] = "23";
                    }
                    if (dataTable.Rows[i]["tdjyq"].ToString().Trim() == "7")
                    {
                        dataTable.Rows[i]["tdjyq"] = "8";
                    }
                }
                connection.Close();
                SqlBulkCopy copy = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                copy.DestinationTableName = pTargetTableName;
                selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + System.Windows.Forms.Application.StartupPath + @"\ColumnConvert.dbf;Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
                selectCommandText = "SELECT * FROM " + System.Windows.Forms.Application.StartupPath + @"\ColumnConvert.dbf";
                connection = new OdbcConnection();
                connection.ConnectionString = selectConnectionString;
                connection.Open();
                adapter = new OdbcDataAdapter(selectCommandText, selectConnectionString);
                System.Data.DataTable table2 = new System.Data.DataTable();
                adapter.Fill(table2);
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    if (table2.Rows[j]["oldname"].ToString().Trim() != "")
                    {
                        copy.ColumnMappings.Add(table2.Rows[j]["oldname"].ToString().Trim(), table2.Rows[j]["newname"].ToString().Trim());
                    }
                }
                try
                {
                    copy.WriteToServer(dataTable);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("请检查导入的前期小班数据表的结构是否标准" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    GC.Collect();
                }
                string str4 = this.GetTable("select count(objectid) from " + pTargetTableName, pTargetTableName).Rows[0][0].ToString();
                MessageBox.Show("共导入" + dataSet.Tables["SourceData"].Rows.Count.ToString() + "条记录，当前" + M_str_dwmc + "的数据表里共有" + str4 + "条记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                flag = true;
            }
            catch (Exception exception2)
            {
                MessageBox.Show("导入数据错误：" + exception2.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection.Close();
                GC.Collect();
            }
            return flag;
        }

        public bool ImportXCDM(string pImportFilename, string pColumnNames, string pTargetTableName)
        {
            bool flag;
            string str = pImportFilename.Substring(pImportFilename.Length - 3, 3);
            DataSet dataSet = new DataSet();
            if (str.ToUpper() == "XLS")
            {
                string str2 = pImportFilename;
                OleDbConnection selectConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str2 + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'");
                try
                {
                    selectConnection.Open();
                    string str4 = selectConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0][2].ToString().Trim();
                    string[] strArray = str4.Split(new char[] { '\'' });
                    if (strArray.Length > 1)
                    {
                        str4 = strArray[1];
                    }
                    new OleDbDataAdapter("SELECT " + pColumnNames + " FROM [" + str4 + "]", selectConnection).Fill(dataSet, "SourceData");
                    if ((dataSet.Tables["SourceData"].Columns.IndexOf("ccode") != -1) && (dataSet.Tables["SourceData"].Columns.IndexOf("cname") != -1))
                    {
                        string str6 = dataSet.Tables["SourceData"].Rows.Count.ToString();
                        DataColumn column = new DataColumn();
                        column.ColumnName = "ctype";
                        column.DataType = typeof(string);
                        column.MaxLength = 2;
                        dataSet.Tables["SourceData"].Columns.Add(column);
                        for (int i = 0; i < dataSet.Tables["SourceData"].Rows.Count; i++)
                        {
                            if (((dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Length == 6) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(4, 2) == "00")) && ((dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(0, 2) != "00") && (this.IsNumeric(dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim()) != -1.0)))
                            {
                                if (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(2, 2) == "00")
                                {
                                    dataSet.Tables["SourceData"].Rows[i]["ctype"] = "乡";
                                }
                                else
                                {
                                    dataSet.Tables["SourceData"].Rows[i]["ctype"] = "村";
                                }
                            }
                            else if ((dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Length == 6) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                            {
                                dataSet.Tables["SourceData"].Rows[i]["ctype"] = "县";
                            }
                            else if (((dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Length == 10) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(8, 2) == "00")) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                            {
                                dataSet.Tables["SourceData"].Rows[i]["ctype"] = "乡";
                            }
                            else if (((dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Length == 10) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(8, 2) != "00")) && (dataSet.Tables["SourceData"].Rows[i]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                            {
                                dataSet.Tables["SourceData"].Rows[i]["ctype"] = "村";
                            }
                            else
                            {
                                dataSet.Tables["SourceData"].Rows.RemoveAt(i);
                            }
                        }
                        dataSet.AcceptChanges();
                        SqlBulkCopy copy = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                        copy.DestinationTableName = pTargetTableName;
                        System.Data.DataTable table = new System.Data.DataTable();
                        table = this.GetTable("select top 1 * from " + pTargetTableName, pTargetTableName);
                        for (int j = 0; j < dataSet.Tables["SourceData"].Columns.Count; j++)
                        {
                            copy.ColumnMappings.Add(dataSet.Tables["SourceData"].Columns[j].ColumnName, table.Columns[j + 1].ColumnName);
                        }
                        copy.WriteToServer(dataSet.Tables["SourceData"]);
                        string str7 = this.GetTable("select count(objectid) from " + pTargetTableName + " where ctype = '乡' or ctype = '村' or ctype = '县'", pTargetTableName).Rows[0][0].ToString();
                        MessageBox.Show("原表一共有" + str6 + "条记录，共导入符合标准的" + dataSet.Tables["SourceData"].Rows.Count.ToString() + "条记录，当前" + M_str_dwmc + "的代码表里共有" + str7 + "条乡村代码记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return true;
                    }
                    MessageBox.Show("导入的乡村代码表里必须含有“ccode,cname”这两列，请返回检查。");
                    return false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("导入数据错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                finally
                {
                    selectConnection.Close();
                }
            }
            if (str.ToUpper() != "DBF")
            {
                return false;
            }
            string str8 = pImportFilename;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str8 + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string selectCommandText = "SELECT " + pColumnNames + " FROM [" + str8 + "]";
            OdbcConnection connection2 = new OdbcConnection();
            connection2.ConnectionString = selectConnectionString;
            try
            {
                connection2.Open();
                new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SourceData");
                if ((dataSet.Tables["SourceData"].Columns.IndexOf("ccode") != -1) && (dataSet.Tables["SourceData"].Columns.IndexOf("cname") != -1))
                {
                    string str11 = dataSet.Tables["SourceData"].Rows.Count.ToString();
                    DataColumn column2 = new DataColumn();
                    column2.ColumnName = "ctype";
                    column2.DataType = typeof(string);
                    column2.MaxLength = 2;
                    dataSet.Tables["SourceData"].Columns.Add(column2);
                    for (int k = 0; k < dataSet.Tables["SourceData"].Rows.Count; k++)
                    {
                        if (((dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Length == 6) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(4, 2) == "00")) && ((dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(0, 2) != "00") && (this.IsNumeric(dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim()) != -1.0)))
                        {
                            if (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(2, 2) == "00")
                            {
                                dataSet.Tables["SourceData"].Rows[k]["ctype"] = "乡";
                            }
                            else
                            {
                                dataSet.Tables["SourceData"].Rows[k]["ctype"] = "村";
                            }
                        }
                        else if ((dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Length == 6) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                        {
                            dataSet.Tables["SourceData"].Rows[k]["ctype"] = "县";
                        }
                        else if (((dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Length == 10) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(8, 2) == "00")) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                        {
                            dataSet.Tables["SourceData"].Rows[k]["ctype"] = "乡";
                        }
                        else if (((dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Length == 10) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(8, 2) != "00")) && (dataSet.Tables["SourceData"].Rows[k]["ccode"].ToString().Trim().Substring(0, 2) == "45"))
                        {
                            dataSet.Tables["SourceData"].Rows[k]["ctype"] = "村";
                        }
                        else
                        {
                            dataSet.Tables["SourceData"].Rows.RemoveAt(k);
                        }
                    }
                    dataSet.AcceptChanges();
                    SqlBulkCopy copy2 = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                    copy2.DestinationTableName = pTargetTableName;
                    System.Data.DataTable table3 = new System.Data.DataTable();
                    table3 = this.GetTable("select top 1 * from " + pTargetTableName, pTargetTableName);
                    for (int m = 0; m < dataSet.Tables["SourceData"].Columns.Count; m++)
                    {
                        int num5 = 0;
                        while (num5 < table3.Columns.Count)
                        {
                            if (table3.Columns[num5].ColumnName.ToLower() == dataSet.Tables["SourceData"].Columns[m].ColumnName.ToLower())
                            {
                                goto Label_0E60;
                            }
                            num5++;
                        }
                        continue;
                    Label_0E60:
                        copy2.ColumnMappings.Add(dataSet.Tables["SourceData"].Columns[m].ColumnName, table3.Columns[num5].ColumnName);
                    }
                    copy2.WriteToServer(dataSet.Tables["SourceData"]);
                    string str12 = this.GetTable("select count(objectid) from " + pTargetTableName + " where ctype = '乡' or ctype = '村' or ctype = '县'", pTargetTableName).Rows[0][0].ToString();
                    MessageBox.Show("原表一共有" + str11 + "条记录，共导入符合标准的" + dataSet.Tables["SourceData"].Rows.Count.ToString() + "条记录，当前" + M_str_dwmc + "的代码表里共有" + str12 + "条乡村代码记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
                MessageBox.Show("导入的乡村代码表里必须含有“ccode,cname”这两列，其中“ccode”代表代码，“cname”代表中文名称，请返回检查。");
                flag = false;
            }
            catch (Exception exception2)
            {
                MessageBox.Show("导入数据错误：" + exception2.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection2.Close();
                GC.Collect();
            }
            return flag;
        }

        public int intRecordsInTable(string Sql)
        {
            int count;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Sql, this.GetCon());
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                count = dataTable.Rows.Count;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                count = 0;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return count;
        }

        public double IsNumeric(string str)
        {
            double num;
            double num2;
            try
            {
                if (double.TryParse(str, out num))
                {
                    return num;
                }
                num = -1.0;
                num2 = num;
            }
            catch
            {
                num = -1.0;
                num2 = num;
            }
            finally
            {
                GC.Collect();
            }
            return num2;
        }

        public void LoadDsXcdmToDB(DataSet myds)
        {
            SqlConnection selectConnection = new SqlConnection(M_Str_ConnectionString);
            selectConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT CODE,NAME FROM DM_XCUN", selectConnection);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            new SqlCommandBuilder(adapter);
            adapter.Fill(dataTable);
            DataRow row = null;
            foreach (DataRow row2 in myds.Tables[0].Rows)
            {
                row = dataTable.NewRow();
                row[0] = row2[0].ToString().Trim();
                row[1] = row2[1].ToString().Trim();
                dataTable.Rows.Add(row);
            }
            adapter.Update(dataTable);
            string cmdtxt = "UPDATE DM_XCUN SET MYBH = 0 WHERE (LEN(LTRIM(RTRIM(CODE))) = 6)";
            this.GetExecute(cmdtxt);
            MessageBox.Show("乡村代码表导入成功!\r总共导入 " + myds.Tables[0].Rows.Count.ToString() + " 条记录。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public bool TruncateTable(string mytablename)
        {
            bool flag;
            string connectionString = M_Str_ConnectionString;
            string cmdText = "TRUNCATE TABLE " + mytablename;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                new SqlCommand(cmdText, connection).ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("清空数据库记录表错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        private bool UpdateSYSTable(string pImportFilename, string pColumnNames, string pTargetTableName)
        {
            bool flag;
            DataSet dataSet = new DataSet();
            string str = pImportFilename;
            string selectConnectionString = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + str + ";Exclusive=No;NULL=NO;Collate=Machine;BACKGROUNDFETCH=NO;DELETED=NO";
            string selectCommandText = "SELECT " + pColumnNames + " FROM [" + str + "]";
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = selectConnectionString;
            try
            {
                connection.Open();
                new OdbcDataAdapter(selectCommandText, selectConnectionString).Fill(dataSet, "SourceData");
                SqlBulkCopy copy = new SqlBulkCopy(M_Str_ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
                copy.DestinationTableName = pTargetTableName;
                System.Data.DataTable table = new System.Data.DataTable();
                table = this.GetTable("select top 1 * from " + pTargetTableName, pTargetTableName);
                for (int i = 0; i < dataSet.Tables["SourceData"].Columns.Count; i++)
                {
                    int num2 = 0;
                    while (num2 < table.Columns.Count)
                    {
                        if (table.Columns[num2].ColumnName.ToLower() == dataSet.Tables["SourceData"].Columns[i].ColumnName.ToLower())
                        {
                            goto Label_0116;
                        }
                        num2++;
                    }
                    continue;
                Label_0116:
                    copy.ColumnMappings.Add(dataSet.Tables["SourceData"].Columns[i].ColumnName, table.Columns[num2].ColumnName);
                }
                copy.WriteToServer(dataSet.Tables["SourceData"]);
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("更新系统表错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                connection.Close();
                GC.Collect();
            }
            return flag;
        }

        public bool ValidateSQL(string sql)
        {
            bool flag;
            SqlCommand command = this.GetCon().CreateCommand();
            command.CommandText = "SET PARSEONLY ON";
            command.ExecuteNonQuery();
            try
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                flag = false;
                MessageBox.Show("输入的SQL语句不正确，请返回检查。\r\n" + exception.Message);
                return false;
            }
            finally
            {
                command.CommandText = "SET PARSEONLY OFF";
                command.ExecuteNonQuery();
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return flag;
        }

        public static string M_Str_Bqnd
        {
            get
            {
                return str_Bqnd;
            }
            set
            {
                str_Bqnd = value;
            }
        }

        public static string M_Str_Cncw
        {
            get
            {
                return str_Cncw;
            }
            set
            {
                str_Cncw = value;
            }
        }

        public static string M_Str_ConnectionDataBaseName
        {
            get
            {
                return str_ConnectionDataBaseName;
            }
            set
            {
                str_ConnectionDataBaseName = value;
            }
        }

        public static string M_Str_ConnectionPassWord
        {
            get
            {
                return str_connectionpassword;
            }
            set
            {
                str_connectionpassword = value;
            }
        }

        public static string M_Str_ConnectionServerName
        {
            get
            {
                return str_ConnectionServerName;
            }
            set
            {
                str_ConnectionServerName = value;
            }
        }

        public static string M_Str_ConnectionString
        {
            get
            {
                return str_connectionstring;
            }
            set
            {
                str_connectionstring = value;
            }
        }

        public static string M_Str_ConnectionUserName
        {
            get
            {
                return str_connectionusername;
            }
            set
            {
                str_connectionusername = value;
            }
        }

        public static string M_str_dwbh
        {
            get
            {
                return str_dwbh;
            }
            set
            {
                str_dwbh = value;
            }
        }

        public static string M_str_dwmc
        {
            get
            {
                return str_dwmc;
            }
            set
            {
                str_dwmc = value;
            }
        }

        public static string M_Str_Qqnd
        {
            get
            {
                return str_Qqnd;
            }
            set
            {
                str_Qqnd = value;
            }
        }

        public static string M_Str_QS
        {
            get
            {
                return str_QS;
            }
            set
            {
                str_QS = value;
            }
        }
    }
}

