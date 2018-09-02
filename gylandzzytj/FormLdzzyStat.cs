namespace gylandzzytj
{
    using DevExpress.Utils;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraTab;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraGrid.Views.Base;
    using td.db.orm;
    using td.logic.sys;
    using td.logic.forest;
    using td.db.mid.forest;
    using td.db.orm.sqlite;
    using Utilities;
    using System.IO;
    using System.Xml;
    using System.Data.SQLite;
    using ConSQLServerInfo;

    /// <summary>
    ///  统计--国家统计报表：窗体
    /// </summary>
    public class FormLdzzyStat : Form
    {
        string sqlitepath = UtilFactory.GetConfigOpt().RootPath + "Data\\forest_142326_2016.db";
        public SQLiteConnection cnn;
        private string _ConnectionString = ConnectionSQLServerString.Get_M_Str_ConnectionString();
        /// <summary>
        /// 表1 占用征收林地按月份统计表
        /// </summary>
        private DataTable _Dtb1;
        /// <summary>
        /// 表2 占用征收林地按主导功能统计表（总表）
        /// </summary>
        private DataTable _Dtb2;
        /// <summary>
        /// 表3 占用征收林地按主导功能统计表（长期占用）
        /// </summary>
        private DataTable _Dtb3;
        /// <summary>
        /// 表4 占用征收林地按主导功能统计表（临时占用）
        /// </summary>
        private DataTable _Dtb4;
        /// <summary>
        /// 表5 占用征收林地按主导功能统计表（林业占用）
        /// </summary>
        private DataTable _Dtb5;
        private string _TableName = "";
        private const string _xmlx_cxggjsyd = "城乡公共建设用地";
        private const string _xmlx_cxjyxjsyd = "城乡经营性建设用地";
        private const string _xmlx_dlxzjyxyd = "独立选址经营性用地";
        private const string _xmlx_jcssjs = "基础设施建设";
        private const string _xmlx_kcck = "勘查采矿";
        private const string _xmlx_qt = "其它";
        private const string _zylx_hj = "合计";
        private const string _zylx_lszyld = "二、临时占用林地";
        private const string _zylx_lyzyld = "三、林业生产服务设施";
        private const string _zylx_zyzsld = "一、占用征收林地";
        /// <summary>
        /// 表示以表格形式显示数据的视图，允许分组列进入频带并支持复杂的数据信元安排。
        /// </summary>
        private AdvBandedGridView advBandedGridView1;
        private AdvBandedGridView advBandedGridView2;
        private AdvBandedGridView advBandedGridView3;
        private AdvBandedGridView advBandedGridView4;
        private AdvBandedGridView advBandedGridView5;
        private BandedGridColumn bandedGridColumn1;
        private BandedGridColumn bandedGridColumn10;
        private BandedGridColumn bandedGridColumn100;
        private BandedGridColumn bandedGridColumn101;
        private BandedGridColumn bandedGridColumn102;
        private BandedGridColumn bandedGridColumn103;
        private BandedGridColumn bandedGridColumn104;
        private BandedGridColumn bandedGridColumn105;
        private BandedGridColumn bandedGridColumn106;
        private BandedGridColumn bandedGridColumn107;
        private BandedGridColumn bandedGridColumn108;
        private BandedGridColumn bandedGridColumn109;
        private BandedGridColumn bandedGridColumn11;
        private BandedGridColumn bandedGridColumn110;
        private BandedGridColumn bandedGridColumn111;
        private BandedGridColumn bandedGridColumn112;
        private BandedGridColumn bandedGridColumn113;
        private BandedGridColumn bandedGridColumn114;
        private BandedGridColumn bandedGridColumn115;
        private BandedGridColumn bandedGridColumn116;
        private BandedGridColumn bandedGridColumn117;
        private BandedGridColumn bandedGridColumn118;
        private BandedGridColumn bandedGridColumn119;
        private BandedGridColumn bandedGridColumn12;
        private BandedGridColumn bandedGridColumn120;
        private BandedGridColumn bandedGridColumn121;
        private BandedGridColumn bandedGridColumn122;
        private BandedGridColumn bandedGridColumn123;
        private BandedGridColumn bandedGridColumn124;
        private BandedGridColumn bandedGridColumn125;
        private BandedGridColumn bandedGridColumn126;
        private BandedGridColumn bandedGridColumn127;
        private BandedGridColumn bandedGridColumn128;
        private BandedGridColumn bandedGridColumn129;
        private BandedGridColumn bandedGridColumn13;
        private BandedGridColumn bandedGridColumn130;
        private BandedGridColumn bandedGridColumn131;
        private BandedGridColumn bandedGridColumn132;
        private BandedGridColumn bandedGridColumn133;
        private BandedGridColumn bandedGridColumn134;
        private BandedGridColumn bandedGridColumn135;
        private BandedGridColumn bandedGridColumn136;
        private BandedGridColumn bandedGridColumn137;
        private BandedGridColumn bandedGridColumn138;
        private BandedGridColumn bandedGridColumn14;
        private BandedGridColumn bandedGridColumn15;
        private BandedGridColumn bandedGridColumn16;
        private BandedGridColumn bandedGridColumn17;
        private BandedGridColumn bandedGridColumn18;
        private BandedGridColumn bandedGridColumn19;
        private BandedGridColumn bandedGridColumn2;
        private BandedGridColumn bandedGridColumn20;
        private BandedGridColumn bandedGridColumn21;
        private BandedGridColumn bandedGridColumn22;
        private BandedGridColumn bandedGridColumn23;
        private BandedGridColumn bandedGridColumn24;
        private BandedGridColumn bandedGridColumn25;
        private BandedGridColumn bandedGridColumn26;
        private BandedGridColumn bandedGridColumn27;
        private BandedGridColumn bandedGridColumn28;
        private BandedGridColumn bandedGridColumn29;
        private BandedGridColumn bandedGridColumn3;
        private BandedGridColumn bandedGridColumn30;
        private BandedGridColumn bandedGridColumn31;
        private BandedGridColumn bandedGridColumn32;
        private BandedGridColumn bandedGridColumn33;
        private BandedGridColumn bandedGridColumn34;
        private BandedGridColumn bandedGridColumn35;
        private BandedGridColumn bandedGridColumn36;
        private BandedGridColumn bandedGridColumn37;
        private BandedGridColumn bandedGridColumn38;
        private BandedGridColumn bandedGridColumn39;
        private BandedGridColumn bandedGridColumn4;
        private BandedGridColumn bandedGridColumn40;
        private BandedGridColumn bandedGridColumn41;
        private BandedGridColumn bandedGridColumn42;
        private BandedGridColumn bandedGridColumn43;
        private BandedGridColumn bandedGridColumn44;
        private BandedGridColumn bandedGridColumn45;
        private BandedGridColumn bandedGridColumn46;
        private BandedGridColumn bandedGridColumn47;
        private BandedGridColumn bandedGridColumn48;
        private BandedGridColumn bandedGridColumn49;
        private BandedGridColumn bandedGridColumn5;
        private BandedGridColumn bandedGridColumn50;
        private BandedGridColumn bandedGridColumn51;
        private BandedGridColumn bandedGridColumn52;
        private BandedGridColumn bandedGridColumn53;
        private BandedGridColumn bandedGridColumn54;
        private BandedGridColumn bandedGridColumn55;
        private BandedGridColumn bandedGridColumn56;
        private BandedGridColumn bandedGridColumn57;
        private BandedGridColumn bandedGridColumn58;
        private BandedGridColumn bandedGridColumn59;
        private BandedGridColumn bandedGridColumn6;
        private BandedGridColumn bandedGridColumn60;
        private BandedGridColumn bandedGridColumn61;
        private BandedGridColumn bandedGridColumn62;
        private BandedGridColumn bandedGridColumn63;
        private BandedGridColumn bandedGridColumn64;
        private BandedGridColumn bandedGridColumn65;
        private BandedGridColumn bandedGridColumn66;
        private BandedGridColumn bandedGridColumn67;
        private BandedGridColumn bandedGridColumn68;
        private BandedGridColumn bandedGridColumn69;
        private BandedGridColumn bandedGridColumn7;
        private BandedGridColumn bandedGridColumn70;
        private BandedGridColumn bandedGridColumn71;
        private BandedGridColumn bandedGridColumn72;
        private BandedGridColumn bandedGridColumn73;
        private BandedGridColumn bandedGridColumn74;
        private BandedGridColumn bandedGridColumn75;
        private BandedGridColumn bandedGridColumn76;
        private BandedGridColumn bandedGridColumn77;
        private BandedGridColumn bandedGridColumn78;
        private BandedGridColumn bandedGridColumn79;
        private BandedGridColumn bandedGridColumn8;
        private BandedGridColumn bandedGridColumn80;
        private BandedGridColumn bandedGridColumn81;
        private BandedGridColumn bandedGridColumn82;
        private BandedGridColumn bandedGridColumn83;
        private BandedGridColumn bandedGridColumn84;
        private BandedGridColumn bandedGridColumn85;
        private BandedGridColumn bandedGridColumn86;
        private BandedGridColumn bandedGridColumn87;
        private BandedGridColumn bandedGridColumn88;
        private BandedGridColumn bandedGridColumn89;
        private BandedGridColumn bandedGridColumn9;
        private BandedGridColumn bandedGridColumn90;
        private BandedGridColumn bandedGridColumn91;
        private BandedGridColumn bandedGridColumn92;
        private BandedGridColumn bandedGridColumn93;
        private BandedGridColumn bandedGridColumn94;
        private BandedGridColumn bandedGridColumn95;
        private BandedGridColumn bandedGridColumn96;
        private BandedGridColumn bandedGridColumn97;
        private BandedGridColumn bandedGridColumn98;
        private BandedGridColumn bandedGridColumn99;
        private IContainer components;
        private GridControl gridControl1;
        private GridControl gridControl2;
        private GridControl gridControl3;
        private GridControl gridControl4;
        private GridControl gridControl5;
        private ToolStripButton tBtn_ExportToExcel;
        private ToolStrip toolStrip1;
        private XtraTabControl xtcb_gyltj;
        private XtraTabPage xtp_b1;
        private XtraTabPage xtp_b2;
        private XtraTabPage xtp_b3;
        private XtraTabPage xtp_b4;
        private XtraTabPage xtp_b5;

        public System.Data.SQLite.SQLiteConnection m_dbConnection;

        /// <summary>
        /// 查询征占用专题图层的底层类
        /// </summary>
        public FindMidFromLayer<ZT_LDZZ_2016_Mid> FindFromLayer { get; set; }

        /// <summary>
        ///  统计--国家统计报表:窗体：构造器
        /// </summary>
        /// <param name="tname"></param>
        public FormLdzzyStat(string tname)
        {
            this.InitializeComponent();

            this._TableName = tname;
        }

        /// <summary>
        /// 构建：表2 占用征收林地按主导功能统计表（总表）：将数据填充进DataTable中
        /// </summary>
        /// <returns></returns>
        private DataTable Calc_zd_hj(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {///没有连接到SQLServer数据库，故注销一下代码
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                this._ConnectionString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            }
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                return null;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < 20; i++)
            {
                dt.Columns.Add();
            }
            try
            {
                ///SQLServer连接
                SqlConnection con = new SqlConnection(this._ConnectionString);
                con.Open();

                ///SQLite连接
                ////cnn = new System.Data.SQLite.SQLiteConnection();
                ////cnn.ConnectionString = @"Data Source=forest_142326_2016.db;Pooling=true;FailIfMissing=false";
                ////cnn.ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                ////cnn.ConnectionString = @"Data Source= D:\ForestManager\GXFormMainFrame\bin\Data\forest_142326_2016;Initial Catalog=forest_142326_2016;User ID=sa;Password=sa123456;Persist Security Info=false;";
                ////cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
                ////cnn.Open();

                string[] strArray = new string[] { "合计", "一、占用征收林地", "二、临时占用林地", "三、林业生产服务设施" };
                string[] strArray2 = new string[] { "基础设施建设", "城乡公共建设用地", "城乡经营性建设用地", "勘查采矿", "独立选址经营性用地", "其它" };
                foreach (string str in strArray)
                {
                    string str4 = str;
                    if (str4 != null)
                    {
                        if (str4 != "合计")
                        {
                            if (str4 == "一、占用征收林地")
                            {
                                goto Label_013A;
                            }
                            if (str4 == "二、临时占用林地")
                            {
                                goto Label_0177;
                            }
                            if (str4 == "三、林业生产服务设施")
                            {
                                goto Label_01B4;
                            }
                        }
                        else
                        {
                            this.Calc_zd_hj_row(con, ref dt, str, "");
                        }
                    }
                    continue;
                Label_013A:
                    this.Calc_zd_hj_row(con, ref dt, str, "");
                    foreach (string str2 in strArray2)
                    {
                        this.Calc_zd_hj_row(con, ref dt, str, str2);
                    }
                    continue;
                Label_0177:
                    this.Calc_zd_hj_row(con, ref dt, str, "");
                    foreach (string str3 in strArray2)
                    {
                        this.Calc_zd_hj_row(con, ref dt, str, str3);
                    }
                    continue;
                Label_01B4:
                    this.Calc_zd_hj_row(con, ref dt, str, "");
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zd_ly", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dt;
        }

        /// <summary>
        ///  构建：表2 占用征收林地按主导功能统计表（总表）：将查询的数据填充进DataTable的每行中
        /// </summary>
        /// <param name="con"></param>
        /// <param name="dt"></param>
        /// <param name="zylx"></param>
        /// <param name="xmlx"></param>
        private void Calc_zd_hj_row(SqlConnection con, ref DataTable dt, string zylx, string xmlx)
        {
            try
            {
                string str12;
                string str13;
                string str = "";
                string str2 = "select (count(distinct XMMC)) as 项目个数 from ";
                str2 = str2 + this._TableName;
                string str3 = "";
                if (((str12 = zylx) != null) && (str12 != "合计"))
                {
                    if (str12 != "一、占用征收林地")
                    {
                        if (str12 == "二、临时占用林地")
                        {
                            goto Label_0067;
                        }
                        if (str12 == "三、林业生产服务设施")
                        {
                            goto Label_006F;
                        }
                    }
                    else
                    {
                        str = "YDZL = '2'";
                    }
                }
                goto Label_0075;
            Label_0067:
                str = "XMLX = '2'";
                goto Label_0075;
            Label_006F:
                str = "XMLX = '4'";
            Label_0075:
                if (!string.IsNullOrEmpty(str))
                {
                    str3 = " where ";
                    str3 = str3 + str;
                }
                if (!string.IsNullOrEmpty(xmlx) && ((str13 = xmlx) != null))
                {
                    if (str13 == "基础设施建设")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        ////str3 = str3 + " LDYT like '1%'";///SQLite
                        str3 = str3 + " left(LDYT, 1) = '1'";///SQLServer
                    }
                    else if (str13 == "城乡公共建设用地")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        str3 = str3 + " left(LDYT, 1) = '2'";
                    }
                    else if (str13 == "城乡经营性建设用地")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        str3 = str3 + " left(LDYT, 1) = '3'";
                    }
                    else if (str13 == "勘查采矿")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        str3 = str3 + " left(LDYT, 1) = '4'";
                    }
                    else if (str13 == "独立选址经营性用地")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        str3 = str3 + " left(LDYT, 1) = '5'";
                    }
                    else if (str13 == "其它")
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            str3 = str3 + " and ";
                        }
                        else
                        {
                            str3 = " where ";
                        }
                        str3 = str3 + " left(LDYT, 1) = '7'";
                    }
                }
                int num = 0;
                DataRow row = dt.NewRow();
                if (!string.IsNullOrEmpty(xmlx))
                {
                    row[num++] = "  " + xmlx;
                }
                else if (!string.IsNullOrEmpty(zylx))
                {
                    row[num++] = zylx;
                }

                ///SQLite连接
                ////System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(str2 + str3, con);
                ////System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader();

                ///SQLServer连接
                SqlCommand command = new SqlCommand(str2 + str3, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {              
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                str2 = "select sum(MIAN_JI) from ";
                str2 = str2 + this._TableName;
                command.CommandText = str2 + str3;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                string str4 = " left(LD_QS, 1) = '1' ";
                string str5 = " left(LD_QS, 1) = '2' ";
                if (string.IsNullOrEmpty(str3))
                {
                    str3 = " where ";
                }
                else
                {
                    str3 = str3 + " and ";
                }
                command.CommandText = str2 + str3 + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                string str6 = " (left(SEN_LIN_LB, 1) = '1') ";
                string str7 = " (left(SEN_LIN_LB, 1) = '2') ";
                string str8 = " left(SHI_QUAN_D, 1) = '1' ";
                string str9 = " left(SHI_QUAN_D, 1) = '2' ";
                string str10 = " (left(DI_LEI, 1) = '1') ";
                string str11 = " (left(DI_LEI, 1) <> '1') ";
                command.CommandText = str2 + str3 + str6 + " and " + str8;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str8 + "and " + str10 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str8 + "and " + str10 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str8 + "and " + str11 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str8 + "and " + str11 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str9;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str9 + " and " + str10 + "and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str9 + " and " + str10 + "and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str9 + " and " + str11 + "and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str6 + " and " + str9 + " and " + str11 + "and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str7;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str7 + " and " + str10 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str7 + " and " + str10 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str7 + " and " + str11 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = str2 + str3 + str7 + " and " + str11 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                this.DealWithZero(ref row, 1, 20);
                dt.Rows.Add(row);
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zd_zq_ls", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 构建表5 占用征收林地按主导功能统计表（林业占用）：将查询的数据显示在DataTable中
        /// </summary>
        /// <returns></returns>
        private DataTable Calc_zd_ly(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {///没有连接到SQLServer数据库，故注销一下代码
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                this._ConnectionString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            }
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                return null;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < 0x1a; i++)
            {
                dt.Columns.Add();
            }
            try
            {
                ///SQLServer
                SqlConnection con = new SqlConnection(this._ConnectionString);
                con.Open();

                ///SQLite
                ////SqlConnection con = new SqlConnection(this._ConnectionString);
                ////cnn = new System.Data.SQLite.SQLiteConnection();
                ////////cnn.ConnectionString = @"Data Source=forest_142326_2016.db;Pooling=true;FailIfMissing=false";
                ///////cnn.ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                //////cnn.ConnectionString = @"Data Source= D:\ForestManager\GXFormMainFrame\bin\Data\forest_142326_2016;Initial Catalog=forest_142326_2016;User ID=sa;Password=sa123456;Persist Security Info=false;";
                ////cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
                ////cnn.Open();

                string zylx = "林业占用";
                string[] strArray = new string[] { "合计", "一、培育、生产、种子、苗木的设施", "二、贮存种子、苗木、木材的设施", "三、集材道、运材道", "四、林业科研、试验、示范基地", "五、野生动植物保护、护林、森林病虫害防治、森林防火、木材检疫的设施", "六、供水、供电、供热、供气、通讯基础设施" };
                foreach (string str2 in strArray)
                {
                    this.Calc_zd_zq_ls_row(con, ref dt, str2, zylx);
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zd_ly", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dt;
        }
        /// <summary>
        /// 构建：表3 占用征收林地按主导功能统计表（长期占用）：将查询的数据显示在DataTable中
        /// </summary>
        /// <param name="cq"></param>
        /// <returns></returns>
        private DataTable Calc_zd_zq_ls(IEnumerable<ZT_LDZZ_2016_Mid> lst, bool cq)
        {///没有连接到SQLServer数据库，故注销一下代码
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                this._ConnectionString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            }
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                return null;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < 0x1a; i++)
            {
                dt.Columns.Add();
            }
            try
            {
                ///SQLServer连接
                SqlConnection con = new SqlConnection(this._ConnectionString);
                con.Open();

                ///SQLite连接
                ////cnn = new System.Data.SQLite.SQLiteConnection();
                ////////cnn.ConnectionString = @"Data Source=forest_142326_2016.db;Pooling=true;FailIfMissing=false";
                ///////cnn.ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                //////cnn.ConnectionString = @"Data Source= D:\ForestManager\GXFormMainFrame\bin\Data\forest_142326_2016;Initial Catalog=forest_142326_2016;User ID=sa;Password=sa123456;Persist Security Info=false;";
                ////cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
                ////cnn.Open();
                string zylx = "长期占用";
                if (!cq)
                {
                    zylx = "临时占用";
                }
                string[] strArray = new string[] { "合计", "一、基础设施", "  公路", "  铁路", "  机场", "  水利电力", "  电力通讯", "  油气管道", "二、城乡公共建设用地", "三、城乡经营性建设用地", "四、勘查采矿", "五、独立选址经营性用地", "  旅游设施", "  商业性开发", "六、其它" };
                foreach (string str2 in strArray)
                {
                    this.Calc_zd_zq_ls_row(con, ref dt, str2, zylx);
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zd_zq_ls", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dt;
        }

        /// <summary>
        /// 构建：表3 占用征收林地按主导功能统计表（长期占用）：将数据查询填充进DataTable的每行中
        /// </summary>
        /// <param name="con"></param>
        /// <param name="dt"></param>
        /// <param name="xmlx"></param>
        /// <param name="zylx"></param>
        private void Calc_zd_zq_ls_row(SqlConnection con, ref DataTable dt, string xmlx, string zylx)
        {
            try
            {
                string str = "";
                string str2 = "";
                string cmdText = "select (count(distinct XMMC)) as 项目个数 from ";
                cmdText = cmdText + this._TableName + " where ";
                string str14 = zylx;
                if (str14 != null)
                {
                    if (str14 != "长期占用")
                    {
                        if (str14 == "临时占用")
                        {
                            goto Label_0066;
                        }
                        if (str14 == "林业占用")
                        {
                            goto Label_006E;
                        }
                    }
                    else
                    {
                        str = "ydzl = '2'";
                    }
                }
                goto Label_0074;
            Label_0066:
                str = "xmlx = '2'";
                goto Label_0074;
            Label_006E:
                str = "xmlx = '4'";
            Label_0074:
                cmdText = cmdText + str;
                switch (xmlx)
                {
                    case "一、基础设施":
                        str2 = " left(ldyt, 1) = '1'";
                        break;

                    case "  公路":
                        str2 = " ldyt = '11'";
                        break;

                    case "  铁路":
                        str2 = " ldyt = '12'";
                        break;

                    case "  机场":
                        str2 = " ldyt = '13'";
                        break;

                    case "  水利电力":
                        str2 = " ldyt = '14'";
                        break;

                    case "  电力通讯":
                        str2 = " ldyt = '15'";
                        break;

                    case "  油气管道":
                        str2 = " ldyt = '16'";
                        break;

                    case "二、城乡公共建设用地":
                        str2 = " left(ldyt, 1) = '2'";
                        break;

                    case "三、城乡经营性建设用地":
                        ////str2 = " substr(ldyt,0) = '3'";///SQLite
                        str2 = " left(ldyt, 1) = '3'";
                        break;

                    case "四、勘查采矿":
                        str2 = " left(ldyt, 1) = '4'";
                        break;

                    case "五、独立选址经营性用地":
                        str2 = " left(ldyt, 1) = '5'";
                        break;

                    case "  旅游设施":
                        str2 = " ldyt = '51'";
                        break;

                    case "  商业性开发":
                        str2 = " ldyt = '52'";
                        break;

                    case "六、其它":
                        ////str2 = " (substr(ldyt, 0) = '6' and (substr(ldyt, 0) = '7')) ";///SQLite
                        str2 = " (left(ldyt, 1) = '6' and (left(ldyt, 1) = '7')) ";
                        break;

                    case "一、培育、生产、种子、苗木的设施":
                        str2 = " ldyt = '61'";
                        break;

                    case "二、贮存种子、苗木、木材的设施":
                        str2 = " ldyt = '62'";
                        break;

                    case "三、集材道、运材道":
                        str2 = " ldyt = '63'";
                        break;

                    case "四、林业科研、试验、示范基地":
                        str2 = " ldyt = '64'";
                        break;

                    case "五、野生动植物保护、护林、森林病虫害防治、森林防火、木材检疫的设施":
                        str2 = " ldyt = '65'";
                        break;

                    case "六、供水、供电、供热、供气、通讯基础设施":
                        str2 = " ldyt = '66'";
                        break;
                }
                int num = 0;
                DataRow row = dt.NewRow();
                row[num++] = xmlx;
                if (!string.IsNullOrEmpty(str2))
                {
                    cmdText = cmdText + " and " + str2;
                }

                ///SQLite查询
                ////////SqlCommand command = new SqlCommand(cmdText, con);
                ////SQLiteCommand command = new SQLiteCommand(cmdText, con);
                ////////SqlDataReader reader = command.ExecuteReader();
                ////System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader();

                ///SQLServer
                SqlCommand command = new SqlCommand(cmdText, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                cmdText = "select sum(MIAN_JI) from ";
                cmdText = (cmdText + this._TableName) + " where " + str;
                if (!string.IsNullOrEmpty(str2))
                {
                    cmdText = cmdText + " and " + str2;
                }
                command.CommandText = cmdText;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                ///SQLite
                ////string str4 = " substr(LD_QS, 0) = '1' ";
                ////string str5 = " substr(LD_QS, 0) = '2' ";
                ///SQLServer
                string str4 = " left(LD_QS, 1) = '1' ";
                string str5 = " left(LD_QS, 1) = '2' ";
                command.CommandText = cmdText + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                ///SQLServer
                string str6 = " (left(SEN_LIN_LB, 1) = '1') ";
                string str7 = " (left(SEN_LIN_LB, 1) = '2') ";
                string str8 = " left(SHI_QUAN_D, 1) = '1' ";
                string str9 = " left(SHI_QUAN_D, 1) = '2' ";
                string str10 = " SHI_QUAN_D = '21' ";
                string str11 = " (SHI_QUAN_D = '22' or SHI_QUAN_D = '23') ";
                string str12 = " (left(DI_LEI, 1) = '1') ";
                string str13 = " (left(DI_LEI, 1) <> '1') ";

                ///SQlite
                ////string str6 = " (substr(SEN_LIN_LB,0) = '1') ";
                ////string str7 = " (substr(SEN_LIN_LB,0) = '2') ";
                ////string str8 = " substr(SHI_QUAN_D, 0) = '1' ";
                ////string str9 = " substr(SHI_QUAN_D, 0) = '2' ";
                ////string str10 = " SHI_QUAN_D = '21' ";
                ////string str11 = " (SHI_QUAN_D = '22' or SHI_QUAN_D = '23') ";
                ////string str12 = " (substr(DI_LEI, 0) = '1') ";
                ////string str13 = " (substr(DI_LEI, 0) <> '1') ";
                command.CommandText = cmdText + " and " + str6 + " and " + str8;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str8 + "and " + str12 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str8 + "and " + str12 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str8 + "and " + str13 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str8 + "and " + str13 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str9;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str10;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str10 + " and " + str12 + "and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str10 + " and " + str12 + "and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str10 + " and " + str13 + "and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str10 + " and " + str13 + "and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str11;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str11 + " and " + str12 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str11 + " and " + str12 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str11 + " and " + str13 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str6 + " and " + str11 + " and " + str13 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str7;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str7 + " and " + str12 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str7 + " and " + str12 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str7 + " and " + str13 + " and " + str4;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                command.CommandText = cmdText + " and " + str7 + " and " + str13 + " and " + str5;
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    row[num++] = reader.GetValue(0);
                }
                reader.Close();
                this.DealWithZero(ref row, 1, 0x1a);
                dt.Rows.Add(row);
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zd_zq_ls", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 构建：表1 占用征收林地按月份统计表：这里把将要显示的值填充进DataTable表中
        /// </summary>
        /// <returns></returns>
        private DataTable Calc_zzyyftj(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {///没有连接到SQLServer数据库，故注销一下代码

            ///SQLite连接
            ////从gdb属性表中获取数据
            //DataTable dt = new DataTable();
            //for (int i = 0; i < 40; i++)
            //{//获取属于该表列的集合
            //    dt.Columns.Add();
            //}
            //cnn = new System.Data.SQLite.SQLiteConnection();
            //////cnn.ConnectionString = @"Data Source=forest_142326_2016.db;Pooling=true;FailIfMissing=false";
            /////cnn.ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
            ////cnn.ConnectionString = @"Data Source= D:\ForestManager\GXFormMainFrame\bin\Data\forest_142326_2016;Initial Catalog=forest_142326_2016;User ID=sa;Password=sa123456;Persist Security Info=false;";
            //cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
            //cnn.Open();

            ///SQLServer连接
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                this._ConnectionString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            }
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                return null;
            }
            DataTable dt = new DataTable();
            for (int i = 0; i < 40; i++)
            {
                dt.Columns.Add();
            }
            try
            {
                SqlConnection con = new SqlConnection(this._ConnectionString);
                con.Open();

                string[] strArray = new string[] { "合计", "一、占用征收林地", "二、临时占用林地", "三、林业生产服务设施" };
                string[] strArray2 = new string[] { "基础设施建设", "城乡公共建设用地", "城乡经营性建设用地", "勘查采矿", "独立选址经营性用地", "其它" };
                foreach (string str in strArray)
                {
                    string str4 = str;
                    if (str4 != null)
                    {
                        if (str4 != "合计")
                        {
                            if (str4 == "一、占用征收林地")
                            {
                                goto Label_013A;//当字符串为“一、占用征收林地”获取数据填充进行的方式
                            }
                            if (str4 == "二、临时占用林地")
                            {
                                goto Label_0177;//当字符串为“二、临时占用林地”获取数据填充进行的方式
                            }
                            if (str4 == "三、林业生产服务设施")
                            {
                                goto Label_01B4;//当字符串为“三、林业生产服务设施”获取数据填充进行的方式
                            }
                        }
                        else
                        {
                            this.Calc_zzyyftj_Row(con, ref dt, str, "");//当字符串为“合计”获取数据填充进行的方式
                        }
                    }
                    continue;
                Label_013A:
                    this.Calc_zzyyftj_Row(con, ref dt, str, "");
                    foreach (string str2 in strArray2)
                    {
                        this.Calc_zzyyftj_Row(con, ref dt, str, str2);
                    }
                    continue;
                Label_0177:
                    this.Calc_zzyyftj_Row(con, ref dt, str, "");
                    foreach (string str3 in strArray2)
                    {
                        this.Calc_zzyyftj_Row(con, ref dt, str, str3);
                    }
                    continue;
                Label_01B4:
                    this.Calc_zzyyftj_Row(con, ref dt, str, "");
                }
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zzyyftj", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dt;
            
        }

        /// <summary>
        /// 构建：表1 占用征收林地按月份统计表：这里获取每行将要显示的数据
        /// </summary>
        /// <param name="con"></param>
        /// <param name="dt"></param>
        /// <param name="zylx"></param>
        /// <param name="xmlx"></param>
        private void Calc_zzyyftj_Row(SqlConnection con, ref DataTable dt, string zylx, string xmlx)
        {
            try
            {
                string str5;
                string str6;
                string str = "select (count(distinct XMMC)) as 项目个数, sum(MIAN_JI) as 面积, sum(ZBHFF) as 植被恢复费 from ";
                str = str + this._TableName;
                string str2 = "";
                if (((str5 = zylx) != null) && (str5 != "合计"))
                {
                    if (str5 != "一、占用征收林地")
                    {
                        if (str5 == "二、临时占用林地")
                        {
                            goto Label_0061;
                        }
                        if (str5 == "三、林业生产服务设施")
                        {
                            goto Label_0069;
                        }
                    }
                    else
                    {
                        str2 = " where YDZL = '2' ";
                    }
                }
                goto Label_006F;//当字符串为“合计”时
            Label_0061:
                str2 = " where XMLX = '2' ";//项目类型为“建设项目临时占用”
                goto Label_006F;
            Label_0069:
                str2 = " where XMLX = '4' ";
            Label_006F:
                if (!string.IsNullOrEmpty(xmlx) && ((str6 = xmlx) != null))
                {

                    //应该在以下地方执行实际的查询，并将查询数据填充进DataTable中
                    switch (str6)
                    {
                        case "基础设施建设":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '1'";

                            break;

                        case "城乡公共建设用地":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '2'";
                            break;

                        case "城乡经营性建设用地":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '3'";
                            break;

                        case "勘查采矿":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '4'";
                            break;

                        case "独立选址经营性用地":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '5'";
                            break;

                        case "其它":
                            if (!string.IsNullOrEmpty(str2))
                            {
                                str2 = str2 + " and ";
                            }
                            else
                            {
                                str2 = " where ";
                            }
                            str2 = str2 + " left(LDYT,1) = '7'";
                            break;
                    }
                }
                
                DataRow row = null;
                ///SQLite连接
                ////System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand();

                ///SQLServer连接
                SqlCommand command = new SqlCommand("", con);

                string str3 = DateTime.Now.Year.ToString();
                string str4 = "";
                //按月份作为查询条件进行统计
               
                for (int i = 0; i < 13; i++)
                {
                    str4 = "";
                    if (i > 0)
                    {
                        DateTime now = DateTime.Now;
                        DateTime.TryParse(str3 + "-" + i.ToString() + "-1", out now);
                        now = now.AddDays(-1.0);
                        string now_gs= now.ToString("yyyy-MM-dd");

                        DateTime result = DateTime.Now;
                        result.ToString("yyyy-MM-dd");
                        DateTime.TryParse(str3 + "-" + i.ToString() + "-1", out result);
                        result = result.AddMonths(1);
                        string result_gs = result.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str4 = " and ";
                        }
                        else
                        {
                            str4 = " where ";
                        }
                        //以下是时间格式的标准化格式（yyyy-MM--dd）,如果没有此过程，语句有误
                        ///str4 = ((str4 + " Convert(datetime, SHSJ) > Convert(datetime, '") + now_gs + "') and  date(SHSJ) <date( '") + result_gs + "')";
                        ////str4 = ((str4 + " datetime(SHSJ) > '") + now.ToShortDateString().Replace("/", "-") + "' and  datetime(SHSJ) < '") + result.ToShortDateString().Replace("/", "-") + "'";
                        //where  SHSJ > '2017-1-31' and  SHSJ < '2017-3-1'

                        str4 = ((str4 + " Convert(datetime, SHSJ) > Convert(datetime, '") + now_gs + "') and  Convert(datetime, SHSJ) < Convert(datetime, '") + result_gs + "')";               
                    }


                    command.CommandText = str + str2 + str4;

                    ///SQLite查询
                    ////command = new System.Data.SQLite.SQLiteCommand(command.CommandText, cnn);
                    ////select (count(distinct XMMC)) as 项目个数, sum(MIAN_JI) as 面积, sum(ZBHFF) as 植被恢复费 from ZT_LDZZ_2016
                    ////System.Data.SQLite.SQLiteDataReader reader = command.ExecuteReader();

                    ///SQLServer查询
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (row == null)
                        {
                            row = dt.NewRow();
                            if (!string.IsNullOrEmpty(xmlx))
                            {
                                row[0] = "  " + xmlx;
                            }
                            else if (!string.IsNullOrEmpty(zylx))
                            {
                                row[0] = zylx;
                            }
                        }

                        row[(i * 3) + 1] = reader.GetValue(0);
                        row[(i * 3) + 2] = reader.GetValue(1);
                        row[(i * 3) + 3] = reader.GetValue(2);
                    }
                    reader.Close();
                }
                if (row != null)
                {
                    this.DealWithZero(ref row, 1, 40);
                    dt.Rows.Add(row);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zzyyftj_Row", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public ProjectManager PM
        {
            get { return DBServiceFactory<ProjectManager>.Service; }
        }

        /// <summary>
        /// 构建：表1 占用征收林地按月份统计表：这里获取每行将要显示的数据
        /// </summary>
        /// <param name="con"></param>
        /// <param name="dt"></param>
        /// <param name="zylx"></param>
        /// <param name="xmlx"></param>
        ////private void Calc_zzyyftj_Row(SQLCommand con,ref DataTable dt, string zylx, string xmlx)
        ////{
        ////    try
        ////    {
        ////        string str5;
        ////        string str6;
        ////        string str = "select (count(distinct XMMC)) as 项目个数, sum(MIAN_JI) as 面积, sum(ZBHFF) as 植被恢复费 from ";
        ////        str = str + this._TableName;
        ////        string str2 = "";
        ////        if (((str5 = zylx) != null) && (str5 != "合计"))
        ////        {
        ////            if (str5 != "一、占用征收林地")
        ////            {
        ////                if (str5 == "二、临时占用林地")
        ////                {
        ////                    goto Label_0061;
        ////                }
        ////                if (str5 == "三、林业生产服务设施")
        ////                {
        ////                    goto Label_0069;
        ////                }
        ////            }
        ////            else
        ////            {
        ////                str2 = " where xmlx = '1' ";
        ////            }
        ////        }
        ////        goto Label_006F;
        ////    Label_0061:
        ////        str2 = " where xmlx = '2' ";
        ////        goto Label_006F;
        ////    Label_0069:
        ////        str2 = " where xmlx = '4' ";
        ////    Label_006F:
        ////        if (!string.IsNullOrEmpty(xmlx) && ((str6 = xmlx) != null))
        ////        {
        ////            switch (str6)
        ////            {
        ////                case "基础设施建设":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '1'";
        ////                    break;

        ////                case "城乡公共建设用地":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '2'";
        ////                    break;

        ////                case "城乡经营性建设用地":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '3'";
        ////                    break;

        ////                case "勘查采矿":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '4'";
        ////                    break;

        ////                case "独立选址经营性用地":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '5'";
        ////                    break;

        ////                case "其它":
        ////                    if (!string.IsNullOrEmpty(str2))
        ////                    {
        ////                        str2 = str2 + " and ";
        ////                    }
        ////                    else
        ////                    {
        ////                        str2 = " where ";
        ////                    }
        ////                    str2 = str2 + " left(ldyt, 1) = '7'";
        ////                    break;
        ////            }
        ////        }
        ////        DataRow row = null;
        ////        SqlCommand command = new SqlCommand("", con);
        ////        string str3 = DateTime.Now.Year.ToString();
        ////        string str4 = "";
        ////        for (int i = 0; i < 13; i++)
        ////        {
        ////            str4 = "";
        ////            if (i > 0)
        ////            {
        ////                DateTime now = DateTime.Now;
        ////                DateTime.TryParse(str3 + "-" + i.ToString() + "-1", out now);
        ////                now = now.AddDays(-1.0);
        ////                DateTime result = DateTime.Now;
        ////                DateTime.TryParse(str3 + "-" + i.ToString() + "-1", out result);
        ////                result = result.AddMonths(1);
        ////                if (!string.IsNullOrEmpty(str2))
        ////                {
        ////                    str4 = " and ";
        ////                }
        ////                else
        ////                {
        ////                    str4 = " where ";
        ////                }
        ////                str4 = ((str4 + " Convert(datetime, SHSJ) > Convert(datetime, '") + now.ToShortDateString().Replace("/", "-") + "') and  Convert(datetime, SHSJ) < Convert(datetime, '") + result.ToShortDateString().Replace("/", "-") + "')";
        ////            }
        ////            command.CommandText = str + str2 + str4;
        ////            SqlDataReader reader = command.ExecuteReader();
        ////            if (reader.Read())
        ////            {
        ////                if (row == null)
        ////                {
        ////                    row = dt.NewRow();
        ////                    if (!string.IsNullOrEmpty(xmlx))
        ////                    {
        ////                        row[0] = "  " + xmlx;
        ////                    }
        ////                    else if (!string.IsNullOrEmpty(zylx))
        ////                    {
        ////                        row[0] = zylx;
        ////                    }
        ////                }
        ////                row[(i * 3) + 1] = reader.GetValue(0);
        ////                row[(i * 3) + 2] = reader.GetValue(1);
        ////                row[(i * 3) + 3] = reader.GetValue(2);
        ////            }
        ////            reader.Close();
        ////        }
        ////        if (row != null)
        ////        {
        ////            this.DealWithZero(ref row, 1, 40);
        ////            dt.Rows.Add(row);
        ////        }
        ////    }
        ////    catch (Exception exception)
        ////    {
        ////        MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Calc_zzyyftj_Row", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ////    }
        ////}

        /// <summary>
        /// 将查询的数据逐个填充进DataRow数据行的每个单元格中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="off"></param>
        /// <param name="cnt"></param>
        private void DealWithZero(ref DataRow row, int off, int cnt)
        {
            double result = 0.0;
            for (int i = off; i < cnt; i++)
            {
                object obj2 = row[i];
                if (!Convert.IsDBNull(obj2))
                {
                    result = 0.0;
                    double.TryParse(obj2.ToString(), out result);
                    if (result == 0.0)
                    {
                        row[i] = Convert.DBNull;
                    }
                    else
                    {
                        string str = result.ToString("#0.00").Replace(".00", "");
                        if (str[str.Length - 1] == '0')
                        {
                            str = str.Substring(0, str.Length - 1);
                        }
                        row[i] = str;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormLdzzyStat_Load(object sender, EventArgs e)
        {
            ////cnn = new System.Data.SQLite.SQLiteConnection();
            ////////cnn.ConnectionString = @"Data Source=forest_142326_2016.db;Pooling=true;FailIfMissing=false";
            ///////cnn.ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
            //////cnn.ConnectionString = @"Data Source= D:\ForestManager\GXFormMainFrame\bin\Data\forest_142326_2016;Initial Catalog=forest_142326_2016;User ID=sa;Password=sa123456;Persist Security Info=false;";
            ////cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
            ////cnn.Open();
            this.InitB1();
            this.InitB2();
            this.InitB3();
            this.InitB4();
            this.InitB5();
            string subField = "SHI,XIAN,XIANG,CUN,Q_LD_QS,Q_DI_LEI,LDLX,SHI_QUAN_D,MIAN_JI,SLXJ,XMBH,YDZL,XIAO_BAN,LD_QS,DI_LEI,LING_ZU,QI_YUAN,LIN_ZHONG,YOU_SHI_SZ,BZ,LMSYQ,JJLCQ,ZFYHJ,YDFW,ZBHFDJ,ZBHFF,QYKZ,LYFQ,BH_DJ,ZL_DJ,LIN_BAN,XI_BAN,SEN_LIN_LB,SHI_QUAN_D";
            List<ZT_LDZZ_2016_Mid> data = FindFromLayer.Find(subField, "", "Order By CUN");

            this.Stat(data);
        }

        private DirectoryInfo GetParentDirectory(DirectoryInfo directoryInfo_0, string name)
        {
            try
            {
                if (directoryInfo_0.Parent.GetDirectories(name).Length > 0)
                {
                    return directoryInfo_0.Parent;
                }
                return this.GetParentDirectory(directoryInfo_0.Parent, name);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "获取Config目录错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        /// <summary>
        /// 初始化报表1：占用征收林地按月份统计表
        /// </summary>
        private void InitB1()
        {
            BandedGridView view = this.advBandedGridView1;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("占用征收林地按月份统计表");
            GridBand band2 = band.Children.AddBand("类型");
            this.bandedGridColumn1.OwnerBand = band2;
            GridBand band3 = band.Children.AddBand("项目数");
            this.bandedGridColumn2.OwnerBand = band3;
            GridBand band4 = band.Children.AddBand("面积");
            this.bandedGridColumn3.OwnerBand = band4;
            GridBand band5 = band.Children.AddBand("恢复费");
            this.bandedGridColumn4.OwnerBand = band5;
            GridBand band6 = band.Children.AddBand("一月");
            GridBand band7 = band6.Children.AddBand("项目数");
            this.bandedGridColumn5.OwnerBand = band7;
            GridBand band8 = band6.Children.AddBand("面积");
            this.bandedGridColumn6.OwnerBand = band8;
            GridBand band9 = band6.Children.AddBand("恢复费");
            this.bandedGridColumn7.OwnerBand = band9;
            GridBand band10 = band.Children.AddBand("二月");
            GridBand band11 = band10.Children.AddBand("项目数");
            this.bandedGridColumn8.OwnerBand = band11;
            GridBand band12 = band10.Children.AddBand("面积");
            this.bandedGridColumn9.OwnerBand = band12;
            GridBand band13 = band10.Children.AddBand("恢复费");
            this.bandedGridColumn10.OwnerBand = band13;
            GridBand band14 = band.Children.AddBand("三月");
            GridBand band15 = band14.Children.AddBand("项目数");
            this.bandedGridColumn11.OwnerBand = band15;
            GridBand band16 = band14.Children.AddBand("面积");
            this.bandedGridColumn12.OwnerBand = band16;
            GridBand band17 = band14.Children.AddBand("恢复费");
            this.bandedGridColumn13.OwnerBand = band17;
            GridBand band18 = band.Children.AddBand("四月");
            GridBand band19 = band18.Children.AddBand("项目数");
            this.bandedGridColumn14.OwnerBand = band19;
            GridBand band20 = band18.Children.AddBand("面积");
            this.bandedGridColumn15.OwnerBand = band20;
            GridBand band21 = band18.Children.AddBand("恢复费");
            this.bandedGridColumn16.OwnerBand = band21;
            GridBand band22 = band.Children.AddBand("五月");
            GridBand band23 = band22.Children.AddBand("项目数");
            this.bandedGridColumn17.OwnerBand = band23;
            GridBand band24 = band22.Children.AddBand("面积");
            this.bandedGridColumn18.OwnerBand = band24;
            GridBand band25 = band22.Children.AddBand("恢复费");
            this.bandedGridColumn19.OwnerBand = band25;
            GridBand band26 = band.Children.AddBand("六月");
            GridBand band27 = band26.Children.AddBand("项目数");
            this.bandedGridColumn20.OwnerBand = band27;
            GridBand band28 = band26.Children.AddBand("面积");
            this.bandedGridColumn21.OwnerBand = band28;
            GridBand band29 = band26.Children.AddBand("恢复费");
            this.bandedGridColumn22.OwnerBand = band29;
            GridBand band30 = band.Children.AddBand("七月");
            GridBand band31 = band30.Children.AddBand("项目数");
            this.bandedGridColumn23.OwnerBand = band31;
            GridBand band32 = band30.Children.AddBand("面积");
            this.bandedGridColumn24.OwnerBand = band32;
            GridBand band33 = band30.Children.AddBand("恢复费");
            this.bandedGridColumn25.OwnerBand = band33;
            GridBand band34 = band.Children.AddBand("八月");
            GridBand band35 = band34.Children.AddBand("项目数");
            this.bandedGridColumn26.OwnerBand = band35;
            GridBand band36 = band34.Children.AddBand("面积");
            this.bandedGridColumn27.OwnerBand = band36;
            GridBand band37 = band34.Children.AddBand("恢复费");
            this.bandedGridColumn28.OwnerBand = band37;
            GridBand band38 = band.Children.AddBand("九月");
            GridBand band39 = band38.Children.AddBand("项目数");
            this.bandedGridColumn29.OwnerBand = band39;
            GridBand band40 = band38.Children.AddBand("面积");
            this.bandedGridColumn30.OwnerBand = band40;
            GridBand band41 = band38.Children.AddBand("恢复费");
            this.bandedGridColumn31.OwnerBand = band41;
            GridBand band42 = band.Children.AddBand("十月");
            GridBand band43 = band42.Children.AddBand("项目数");
            this.bandedGridColumn32.OwnerBand = band43;
            GridBand band44 = band42.Children.AddBand("面积");
            this.bandedGridColumn33.OwnerBand = band44;
            GridBand band45 = band42.Children.AddBand("恢复费");
            this.bandedGridColumn34.OwnerBand = band45;
            GridBand band46 = band.Children.AddBand("十一月");
            GridBand band47 = band46.Children.AddBand("项目数");
            this.bandedGridColumn35.OwnerBand = band47;
            GridBand band48 = band46.Children.AddBand("面积");
            this.bandedGridColumn36.OwnerBand = band48;
            GridBand band49 = band46.Children.AddBand("恢复费");
            this.bandedGridColumn37.OwnerBand = band49;
            GridBand band50 = band.Children.AddBand("十二月");
            GridBand band51 = band50.Children.AddBand("项目数");
            this.bandedGridColumn38.OwnerBand = band51;
            GridBand band52 = band50.Children.AddBand("面积");
            this.bandedGridColumn39.OwnerBand = band52;
            GridBand band53 = band50.Children.AddBand("恢复费");
            this.bandedGridColumn40.OwnerBand = band53;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band27.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band28.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band29.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band30.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band31.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band32.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band33.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band34.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band35.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band36.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band37.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band38.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band39.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band40.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band41.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band42.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band43.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band44.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band45.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band46.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band47.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band48.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band49.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band50.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band51.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band52.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band53.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        /// <summary>
        /// 初始化 表2 占用征收林地按主导功能统计表（总表）
        /// </summary>
        private void InitB2()
        {
            BandedGridView view = this.advBandedGridView2;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("占用征收林地按主导功能统计表");
            GridBand band2 = band.Children.AddBand("类型");
            this.bandedGridColumn41.OwnerBand = band2;
            GridBand band3 = band.Children.AddBand("项目数");
            this.bandedGridColumn42.OwnerBand = band3;
            GridBand band4 = band.Children.AddBand("合计");
            GridBand band5 = band4.Children.AddBand("小计");
            this.bandedGridColumn43.OwnerBand = band5;
            GridBand band6 = band4.Children.AddBand("国有");
            this.bandedGridColumn44.OwnerBand = band6;
            GridBand band7 = band4.Children.AddBand("集体");
            this.bandedGridColumn45.OwnerBand = band7;
            GridBand band8 = band.Children.AddBand("主导功能");
            GridBand band9 = band8.Children.AddBand("国家公益林");
            GridBand band10 = band9.Children.AddBand("小计");
            this.bandedGridColumn46.OwnerBand = band10;
            GridBand band11 = band9.Children.AddBand("有林地");
            GridBand band12 = band11.Children.AddBand("国有");
            this.bandedGridColumn47.OwnerBand = band12;
            GridBand band13 = band11.Children.AddBand("集体");
            this.bandedGridColumn48.OwnerBand = band13;
            GridBand band14 = band9.Children.AddBand("其它");
            GridBand band15 = band14.Children.AddBand("国有");
            this.bandedGridColumn49.OwnerBand = band15;
            GridBand band16 = band14.Children.AddBand("集体");
            this.bandedGridColumn50.OwnerBand = band16;
            GridBand band17 = band8.Children.AddBand("地方公益林");
            GridBand band18 = band17.Children.AddBand("小计");
            this.bandedGridColumn51.OwnerBand = band18;
            GridBand band19 = band17.Children.AddBand("有林地");
            GridBand band20 = band19.Children.AddBand("国有");
            this.bandedGridColumn52.OwnerBand = band20;
            GridBand band21 = band19.Children.AddBand("集体");
            this.bandedGridColumn53.OwnerBand = band21;
            GridBand band22 = band17.Children.AddBand("其它");
            GridBand band23 = band22.Children.AddBand("国有");
            this.bandedGridColumn54.OwnerBand = band23;
            GridBand band24 = band22.Children.AddBand("集体");
            this.bandedGridColumn55.OwnerBand = band24;
            GridBand band25 = band8.Children.AddBand("商品林");
            GridBand band26 = band25.Children.AddBand("小计");
            this.bandedGridColumn56.OwnerBand = band26;
            GridBand band27 = band25.Children.AddBand("有林地");
            GridBand band28 = band27.Children.AddBand("国有");
            this.bandedGridColumn57.OwnerBand = band28;
            GridBand band29 = band27.Children.AddBand("集体");
            this.bandedGridColumn58.OwnerBand = band29;
            GridBand band30 = band25.Children.AddBand("其它");
            GridBand band31 = band30.Children.AddBand("国有");
            this.bandedGridColumn59.OwnerBand = band31;
            GridBand band32 = band30.Children.AddBand("集体");
            this.bandedGridColumn60.OwnerBand = band32;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band27.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band28.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band29.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band30.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band31.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band32.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        /// <summary>
        /// 初始化：表3 占用征收林地按主导功能统计表（长期占用）
        /// </summary>
        private void InitB3()
        {
            BandedGridView view = this.advBandedGridView3;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("占用征收林地按主导功能统计表");
            GridBand band2 = band.Children.AddBand("占地类型：长期占用");
            GridBand band3 = band2.Children.AddBand("类型");
            this.bandedGridColumn61.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("项目数");
            this.bandedGridColumn62.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("合计");
            GridBand band6 = band5.Children.AddBand("小计");
            this.bandedGridColumn63.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("国有");
            this.bandedGridColumn64.OwnerBand = band7;
            GridBand band8 = band5.Children.AddBand("集体");
            this.bandedGridColumn65.OwnerBand = band8;
            GridBand band9 = band2.Children.AddBand("主导功能");
            GridBand band10 = band9.Children.AddBand("国家公益林");
            GridBand band11 = band10.Children.AddBand("小计");
            this.bandedGridColumn66.OwnerBand = band11;
            GridBand band12 = band10.Children.AddBand("有林地");
            GridBand band13 = band12.Children.AddBand("国有");
            this.bandedGridColumn67.OwnerBand = band13;
            GridBand band14 = band12.Children.AddBand("集体");
            this.bandedGridColumn68.OwnerBand = band14;
            GridBand band15 = band10.Children.AddBand("其它");
            GridBand band16 = band15.Children.AddBand("国有");
            this.bandedGridColumn69.OwnerBand = band16;
            GridBand band17 = band15.Children.AddBand("集体");
            this.bandedGridColumn70.OwnerBand = band17;
            GridBand band18 = band9.Children.AddBand("地方公益林");
            GridBand band19 = band18.Children.AddBand("小计");
            this.bandedGridColumn71.OwnerBand = band19;
            GridBand band20 = band18.Children.AddBand("省级");
            GridBand band21 = band20.Children.AddBand("小计");
            this.bandedGridColumn72.OwnerBand = band21;
            GridBand band22 = band20.Children.AddBand("有林地");
            GridBand band23 = band22.Children.AddBand("国有");
            this.bandedGridColumn73.OwnerBand = band23;
            GridBand band24 = band22.Children.AddBand("集体");
            this.bandedGridColumn74.OwnerBand = band23;
            GridBand band25 = band20.Children.AddBand("其它");
            GridBand band26 = band25.Children.AddBand("国有");
            this.bandedGridColumn75.OwnerBand = band26;
            GridBand band27 = band25.Children.AddBand("集体");
            this.bandedGridColumn76.OwnerBand = band27;
            GridBand band28 = band18.Children.AddBand("其它");
            GridBand band29 = band28.Children.AddBand("小计");
            this.bandedGridColumn77.OwnerBand = band29;
            GridBand band30 = band28.Children.AddBand("有林地");
            GridBand band31 = band30.Children.AddBand("国有");
            this.bandedGridColumn78.OwnerBand = band31;
            GridBand band32 = band30.Children.AddBand("集体");
            this.bandedGridColumn79.OwnerBand = band32;
            GridBand band33 = band28.Children.AddBand("其它");
            GridBand band34 = band33.Children.AddBand("国有");
            this.bandedGridColumn80.OwnerBand = band34;
            GridBand band35 = band33.Children.AddBand("集体");
            this.bandedGridColumn81.OwnerBand = band35;
            GridBand band36 = band9.Children.AddBand("商品林");
            GridBand band37 = band36.Children.AddBand("小计");
            this.bandedGridColumn82.OwnerBand = band37;
            GridBand band38 = band36.Children.AddBand("有林地");
            GridBand band39 = band38.Children.AddBand("国有");
            this.bandedGridColumn83.OwnerBand = band39;
            GridBand band40 = band38.Children.AddBand("集体");
            this.bandedGridColumn84.OwnerBand = band40;
            GridBand band41 = band36.Children.AddBand("其它");
            GridBand band42 = band41.Children.AddBand("国有");
            this.bandedGridColumn85.OwnerBand = band42;
            GridBand band43 = band41.Children.AddBand("集体");
            this.bandedGridColumn86.OwnerBand = band43;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band27.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band28.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band29.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band30.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band31.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band32.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band33.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band34.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band35.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band36.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band37.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band38.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band39.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band40.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band41.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band42.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band43.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        /// <summary>
        /// 初始化 表4 占用征收林地按主导功能统计表（临时占用）
        /// </summary>
        private void InitB4()
        {
            BandedGridView view = this.advBandedGridView5;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("占用征收林地按主导功能统计表");
            GridBand band2 = band.Children.AddBand("占地类型：临时占用");
            GridBand band3 = band2.Children.AddBand("类型");
            this.bandedGridColumn87.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("项目数");
            this.bandedGridColumn88.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("合计");
            GridBand band6 = band5.Children.AddBand("小计");
            this.bandedGridColumn89.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("国有");
            this.bandedGridColumn90.OwnerBand = band7;
            GridBand band8 = band5.Children.AddBand("集体");
            this.bandedGridColumn91.OwnerBand = band8;
            GridBand band9 = band2.Children.AddBand("主导功能");
            GridBand band10 = band9.Children.AddBand("国家公益林");
            GridBand band11 = band10.Children.AddBand("小计");
            this.bandedGridColumn92.OwnerBand = band11;
            GridBand band12 = band10.Children.AddBand("有林地");
            GridBand band13 = band12.Children.AddBand("国有");
            this.bandedGridColumn93.OwnerBand = band13;
            GridBand band14 = band12.Children.AddBand("集体");
            this.bandedGridColumn94.OwnerBand = band14;
            GridBand band15 = band10.Children.AddBand("其它");
            GridBand band16 = band15.Children.AddBand("国有");
            this.bandedGridColumn95.OwnerBand = band16;
            GridBand band17 = band15.Children.AddBand("集体");
            this.bandedGridColumn96.OwnerBand = band17;
            GridBand band18 = band9.Children.AddBand("地方公益林");
            GridBand band19 = band18.Children.AddBand("小计");
            this.bandedGridColumn97.OwnerBand = band19;
            GridBand band20 = band18.Children.AddBand("省级");
            GridBand band21 = band20.Children.AddBand("小计");
            this.bandedGridColumn98.OwnerBand = band21;
            GridBand band22 = band20.Children.AddBand("有林地");
            GridBand band23 = band22.Children.AddBand("国有");
            this.bandedGridColumn99.OwnerBand = band23;
            GridBand band24 = band22.Children.AddBand("集体");
            this.bandedGridColumn100.OwnerBand = band23;
            GridBand band25 = band20.Children.AddBand("其它");
            GridBand band26 = band25.Children.AddBand("国有");
            this.bandedGridColumn101.OwnerBand = band26;
            GridBand band27 = band25.Children.AddBand("集体");
            this.bandedGridColumn102.OwnerBand = band27;
            GridBand band28 = band18.Children.AddBand("其它");
            GridBand band29 = band28.Children.AddBand("小计");
            this.bandedGridColumn103.OwnerBand = band29;
            GridBand band30 = band28.Children.AddBand("有林地");
            GridBand band31 = band30.Children.AddBand("国有");
            this.bandedGridColumn104.OwnerBand = band31;
            GridBand band32 = band30.Children.AddBand("集体");
            this.bandedGridColumn105.OwnerBand = band32;
            GridBand band33 = band28.Children.AddBand("其它");
            GridBand band34 = band33.Children.AddBand("国有");
            this.bandedGridColumn106.OwnerBand = band34;
            GridBand band35 = band33.Children.AddBand("集体");
            this.bandedGridColumn107.OwnerBand = band35;
            GridBand band36 = band9.Children.AddBand("商品林");
            GridBand band37 = band36.Children.AddBand("小计");
            this.bandedGridColumn108.OwnerBand = band37;
            GridBand band38 = band36.Children.AddBand("有林地");
            GridBand band39 = band38.Children.AddBand("国有");
            this.bandedGridColumn109.OwnerBand = band39;
            GridBand band40 = band38.Children.AddBand("集体");
            this.bandedGridColumn110.OwnerBand = band40;
            GridBand band41 = band36.Children.AddBand("其它");
            GridBand band42 = band41.Children.AddBand("国有");
            this.bandedGridColumn111.OwnerBand = band42;
            GridBand band43 = band41.Children.AddBand("集体");
            this.bandedGridColumn112.OwnerBand = band43;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band27.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band28.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band29.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band30.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band31.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band32.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band33.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band34.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band35.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band36.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band37.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band38.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band39.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band40.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band41.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band42.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band43.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        /// <summary>
        /// 初始化 表5 占用征收林地按主导功能统计表（林业占用）
        /// </summary>
        private void InitB5()
        {
            BandedGridView view = this.advBandedGridView4;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("占用征收林地按主导功能统计表");
            GridBand band2 = band.Children.AddBand("占地类型：林业占用");
            GridBand band3 = band2.Children.AddBand("类型");
            this.bandedGridColumn113.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("项目数");
            this.bandedGridColumn114.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("合计");
            GridBand band6 = band5.Children.AddBand("小计");
            this.bandedGridColumn115.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("国有");
            this.bandedGridColumn116.OwnerBand = band7;
            GridBand band8 = band5.Children.AddBand("集体");
            this.bandedGridColumn117.OwnerBand = band8;
            GridBand band9 = band2.Children.AddBand("主导功能");
            GridBand band10 = band9.Children.AddBand("国家公益林");
            GridBand band11 = band10.Children.AddBand("小计");
            this.bandedGridColumn118.OwnerBand = band11;
            GridBand band12 = band10.Children.AddBand("有林地");
            GridBand band13 = band12.Children.AddBand("国有");
            this.bandedGridColumn119.OwnerBand = band13;
            GridBand band14 = band12.Children.AddBand("集体");
            this.bandedGridColumn120.OwnerBand = band14;
            GridBand band15 = band10.Children.AddBand("其它");
            GridBand band16 = band15.Children.AddBand("国有");
            this.bandedGridColumn121.OwnerBand = band16;
            GridBand band17 = band15.Children.AddBand("集体");
            this.bandedGridColumn122.OwnerBand = band17;
            GridBand band18 = band9.Children.AddBand("地方公益林");
            GridBand band19 = band18.Children.AddBand("小计");
            this.bandedGridColumn123.OwnerBand = band19;
            GridBand band20 = band18.Children.AddBand("省级");
            GridBand band21 = band20.Children.AddBand("小计");
            this.bandedGridColumn124.OwnerBand = band21;
            GridBand band22 = band20.Children.AddBand("有林地");
            GridBand band23 = band22.Children.AddBand("国有");
            this.bandedGridColumn125.OwnerBand = band23;
            GridBand band24 = band22.Children.AddBand("集体");
            this.bandedGridColumn126.OwnerBand = band23;
            GridBand band25 = band20.Children.AddBand("其它");
            GridBand band26 = band25.Children.AddBand("国有");
            this.bandedGridColumn127.OwnerBand = band26;
            GridBand band27 = band25.Children.AddBand("集体");
            this.bandedGridColumn128.OwnerBand = band27;
            GridBand band28 = band18.Children.AddBand("其它");
            GridBand band29 = band28.Children.AddBand("小计");
            this.bandedGridColumn129.OwnerBand = band29;
            GridBand band30 = band28.Children.AddBand("有林地");
            GridBand band31 = band30.Children.AddBand("国有");
            this.bandedGridColumn130.OwnerBand = band31;
            GridBand band32 = band30.Children.AddBand("集体");
            this.bandedGridColumn131.OwnerBand = band32;
            GridBand band33 = band28.Children.AddBand("其它");
            GridBand band34 = band33.Children.AddBand("国有");
            this.bandedGridColumn132.OwnerBand = band34;
            GridBand band35 = band33.Children.AddBand("集体");
            this.bandedGridColumn133.OwnerBand = band35;
            GridBand band36 = band9.Children.AddBand("商品林");
            GridBand band37 = band36.Children.AddBand("小计");
            this.bandedGridColumn134.OwnerBand = band37;
            GridBand band38 = band36.Children.AddBand("有林地");
            GridBand band39 = band38.Children.AddBand("国有");
            this.bandedGridColumn135.OwnerBand = band39;
            GridBand band40 = band38.Children.AddBand("集体");
            this.bandedGridColumn136.OwnerBand = band40;
            GridBand band41 = band36.Children.AddBand("其它");
            GridBand band42 = band41.Children.AddBand("国有");
            this.bandedGridColumn137.OwnerBand = band42;
            GridBand band43 = band41.Children.AddBand("集体");
            this.bandedGridColumn138.OwnerBand = band43;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band27.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band28.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band29.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band30.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band31.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band32.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band33.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band34.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band35.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band36.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band37.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band38.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band39.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band40.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band41.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band42.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band43.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLdzzyStat));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tBtn_ExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.xtcb_gyltj = new DevExpress.XtraTab.XtraTabControl();
            this.xtp_b1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn25 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn28 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn29 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn30 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn31 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn32 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn33 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn35 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn37 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn39 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtp_b2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn41 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn43 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn45 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn47 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn49 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn51 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn53 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn54 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn55 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn56 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn57 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn58 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn59 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtp_b3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView3 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn61 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn62 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn63 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn64 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn65 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn66 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn67 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn68 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn69 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn70 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn71 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn72 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn73 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn74 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn75 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn76 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn77 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn78 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn79 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn80 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn81 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn82 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn83 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn84 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn85 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn86 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtp_b4 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView5 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn87 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn88 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn89 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn90 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn91 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn92 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn93 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn94 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn95 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn96 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn97 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn98 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn99 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn100 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn101 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn102 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn103 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn104 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn105 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn106 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn107 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn108 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn109 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn110 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn111 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn112 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtp_b5 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView4 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn113 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn114 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn115 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn116 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn117 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn118 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn119 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn120 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn121 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn122 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn123 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn124 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn125 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn126 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn127 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn128 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn129 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn130 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn131 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn132 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn133 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn134 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn135 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn136 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn137 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn138 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcb_gyltj)).BeginInit();
            this.xtcb_gyltj.SuspendLayout();
            this.xtp_b1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            this.xtp_b2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).BeginInit();
            this.xtp_b3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).BeginInit();
            this.xtp_b4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView5)).BeginInit();
            this.xtp_b5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBtn_ExportToExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tBtn_ExportToExcel
            // 
            this.tBtn_ExportToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtn_ExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("tBtn_ExportToExcel.Image")));
            this.tBtn_ExportToExcel.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tBtn_ExportToExcel.Name = "tBtn_ExportToExcel";
            this.tBtn_ExportToExcel.Size = new System.Drawing.Size(23, 22);
            this.tBtn_ExportToExcel.Text = "导出到Excel文件";
            this.tBtn_ExportToExcel.Click += new System.EventHandler(this.tBtn_ExportToExcel_Click);
            // 
            // xtcb_gyltj
            // 
            this.xtcb_gyltj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcb_gyltj.Location = new System.Drawing.Point(0, 25);
            this.xtcb_gyltj.Name = "xtcb_gyltj";
            this.xtcb_gyltj.SelectedTabPage = this.xtp_b1;
            this.xtcb_gyltj.Size = new System.Drawing.Size(831, 590);
            this.xtcb_gyltj.TabIndex = 14;
            this.xtcb_gyltj.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtp_b1,
            this.xtp_b2,
            this.xtp_b3,
            this.xtp_b4,
            this.xtp_b5});
            // 
            // xtp_b1
            // 
            this.xtp_b1.Controls.Add(this.gridControl1);
            this.xtp_b1.Name = "xtp_b1";
            this.xtp_b1.Size = new System.Drawing.Size(825, 561);
            this.xtp_b1.Text = "表1 占用征收林地按月份统计表";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(825, 561);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn9,
            this.bandedGridColumn10,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14,
            this.bandedGridColumn15,
            this.bandedGridColumn16,
            this.bandedGridColumn17,
            this.bandedGridColumn18,
            this.bandedGridColumn19,
            this.bandedGridColumn20,
            this.bandedGridColumn21,
            this.bandedGridColumn22,
            this.bandedGridColumn23,
            this.bandedGridColumn24,
            this.bandedGridColumn25,
            this.bandedGridColumn26,
            this.bandedGridColumn27,
            this.bandedGridColumn28,
            this.bandedGridColumn29,
            this.bandedGridColumn30,
            this.bandedGridColumn31,
            this.bandedGridColumn32,
            this.bandedGridColumn33,
            this.bandedGridColumn34,
            this.bandedGridColumn35,
            this.bandedGridColumn36,
            this.bandedGridColumn37,
            this.bandedGridColumn38,
            this.bandedGridColumn39,
            this.bandedGridColumn40});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "bandedGridColumn1";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "bandedGridColumn2";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "bandedGridColumn3";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "bandedGridColumn4";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "bandedGridColumn5";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "bandedGridColumn6";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "bandedGridColumn7";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "bandedGridColumn8";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "bandedGridColumn9";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            // 
            // bandedGridColumn10
            // 
            this.bandedGridColumn10.Caption = "bandedGridColumn10";
            this.bandedGridColumn10.Name = "bandedGridColumn10";
            this.bandedGridColumn10.Visible = true;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "bandedGridColumn11";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Visible = true;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.Caption = "bandedGridColumn12";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Visible = true;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.Caption = "bandedGridColumn13";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.Visible = true;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.Caption = "bandedGridColumn14";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.Visible = true;
            // 
            // bandedGridColumn15
            // 
            this.bandedGridColumn15.Caption = "bandedGridColumn15";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.Visible = true;
            // 
            // bandedGridColumn16
            // 
            this.bandedGridColumn16.Caption = "bandedGridColumn16";
            this.bandedGridColumn16.Name = "bandedGridColumn16";
            this.bandedGridColumn16.Visible = true;
            // 
            // bandedGridColumn17
            // 
            this.bandedGridColumn17.Caption = "bandedGridColumn17";
            this.bandedGridColumn17.Name = "bandedGridColumn17";
            this.bandedGridColumn17.Visible = true;
            // 
            // bandedGridColumn18
            // 
            this.bandedGridColumn18.Caption = "bandedGridColumn18";
            this.bandedGridColumn18.Name = "bandedGridColumn18";
            this.bandedGridColumn18.Visible = true;
            // 
            // bandedGridColumn19
            // 
            this.bandedGridColumn19.Caption = "bandedGridColumn19";
            this.bandedGridColumn19.Name = "bandedGridColumn19";
            this.bandedGridColumn19.Visible = true;
            // 
            // bandedGridColumn20
            // 
            this.bandedGridColumn20.Caption = "bandedGridColumn20";
            this.bandedGridColumn20.Name = "bandedGridColumn20";
            this.bandedGridColumn20.Visible = true;
            // 
            // bandedGridColumn21
            // 
            this.bandedGridColumn21.Caption = "bandedGridColumn21";
            this.bandedGridColumn21.Name = "bandedGridColumn21";
            this.bandedGridColumn21.Visible = true;
            // 
            // bandedGridColumn22
            // 
            this.bandedGridColumn22.Caption = "bandedGridColumn22";
            this.bandedGridColumn22.Name = "bandedGridColumn22";
            this.bandedGridColumn22.Visible = true;
            // 
            // bandedGridColumn23
            // 
            this.bandedGridColumn23.Caption = "bandedGridColumn23";
            this.bandedGridColumn23.Name = "bandedGridColumn23";
            this.bandedGridColumn23.Visible = true;
            // 
            // bandedGridColumn24
            // 
            this.bandedGridColumn24.Caption = "bandedGridColumn24";
            this.bandedGridColumn24.Name = "bandedGridColumn24";
            this.bandedGridColumn24.Visible = true;
            // 
            // bandedGridColumn25
            // 
            this.bandedGridColumn25.Caption = "bandedGridColumn25";
            this.bandedGridColumn25.Name = "bandedGridColumn25";
            this.bandedGridColumn25.Visible = true;
            // 
            // bandedGridColumn26
            // 
            this.bandedGridColumn26.Caption = "bandedGridColumn26";
            this.bandedGridColumn26.Name = "bandedGridColumn26";
            this.bandedGridColumn26.Visible = true;
            // 
            // bandedGridColumn27
            // 
            this.bandedGridColumn27.Caption = "bandedGridColumn27";
            this.bandedGridColumn27.Name = "bandedGridColumn27";
            this.bandedGridColumn27.Visible = true;
            // 
            // bandedGridColumn28
            // 
            this.bandedGridColumn28.Caption = "bandedGridColumn28";
            this.bandedGridColumn28.Name = "bandedGridColumn28";
            this.bandedGridColumn28.Visible = true;
            // 
            // bandedGridColumn29
            // 
            this.bandedGridColumn29.Caption = "bandedGridColumn29";
            this.bandedGridColumn29.Name = "bandedGridColumn29";
            this.bandedGridColumn29.Visible = true;
            // 
            // bandedGridColumn30
            // 
            this.bandedGridColumn30.Caption = "bandedGridColumn30";
            this.bandedGridColumn30.Name = "bandedGridColumn30";
            this.bandedGridColumn30.Visible = true;
            // 
            // bandedGridColumn31
            // 
            this.bandedGridColumn31.Caption = "bandedGridColumn31";
            this.bandedGridColumn31.Name = "bandedGridColumn31";
            this.bandedGridColumn31.Visible = true;
            // 
            // bandedGridColumn32
            // 
            this.bandedGridColumn32.Caption = "bandedGridColumn32";
            this.bandedGridColumn32.Name = "bandedGridColumn32";
            this.bandedGridColumn32.Visible = true;
            // 
            // bandedGridColumn33
            // 
            this.bandedGridColumn33.Caption = "bandedGridColumn33";
            this.bandedGridColumn33.Name = "bandedGridColumn33";
            this.bandedGridColumn33.Visible = true;
            // 
            // bandedGridColumn34
            // 
            this.bandedGridColumn34.Caption = "bandedGridColumn34";
            this.bandedGridColumn34.Name = "bandedGridColumn34";
            this.bandedGridColumn34.Visible = true;
            // 
            // bandedGridColumn35
            // 
            this.bandedGridColumn35.Caption = "bandedGridColumn35";
            this.bandedGridColumn35.Name = "bandedGridColumn35";
            this.bandedGridColumn35.Visible = true;
            // 
            // bandedGridColumn36
            // 
            this.bandedGridColumn36.Caption = "bandedGridColumn36";
            this.bandedGridColumn36.Name = "bandedGridColumn36";
            this.bandedGridColumn36.Visible = true;
            // 
            // bandedGridColumn37
            // 
            this.bandedGridColumn37.Caption = "bandedGridColumn37";
            this.bandedGridColumn37.Name = "bandedGridColumn37";
            this.bandedGridColumn37.Visible = true;
            // 
            // bandedGridColumn38
            // 
            this.bandedGridColumn38.Caption = "bandedGridColumn38";
            this.bandedGridColumn38.Name = "bandedGridColumn38";
            this.bandedGridColumn38.Visible = true;
            // 
            // bandedGridColumn39
            // 
            this.bandedGridColumn39.Caption = "bandedGridColumn39";
            this.bandedGridColumn39.Name = "bandedGridColumn39";
            this.bandedGridColumn39.Visible = true;
            // 
            // bandedGridColumn40
            // 
            this.bandedGridColumn40.Caption = "bandedGridColumn40";
            this.bandedGridColumn40.Name = "bandedGridColumn40";
            this.bandedGridColumn40.Visible = true;
            // 
            // xtp_b2
            // 
            this.xtp_b2.Controls.Add(this.gridControl2);
            this.xtp_b2.Name = "xtp_b2";
            this.xtp_b2.Size = new System.Drawing.Size(825, 561);
            this.xtp_b2.Text = "表2 占用征收林地按主导功能统计表（总表）";
            // 
            // gridControl2
            // 
            this.gridControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.advBandedGridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(825, 561);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView2});
            // 
            // advBandedGridView2
            // 
            this.advBandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn41,
            this.bandedGridColumn42,
            this.bandedGridColumn43,
            this.bandedGridColumn44,
            this.bandedGridColumn45,
            this.bandedGridColumn46,
            this.bandedGridColumn47,
            this.bandedGridColumn48,
            this.bandedGridColumn49,
            this.bandedGridColumn50,
            this.bandedGridColumn51,
            this.bandedGridColumn52,
            this.bandedGridColumn53,
            this.bandedGridColumn54,
            this.bandedGridColumn55,
            this.bandedGridColumn56,
            this.bandedGridColumn57,
            this.bandedGridColumn58,
            this.bandedGridColumn59,
            this.bandedGridColumn60});
            this.advBandedGridView2.GridControl = this.gridControl2;
            this.advBandedGridView2.Name = "advBandedGridView2";
            this.advBandedGridView2.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn41
            // 
            this.bandedGridColumn41.Caption = "bandedGridColumn41";
            this.bandedGridColumn41.Name = "bandedGridColumn41";
            this.bandedGridColumn41.Visible = true;
            // 
            // bandedGridColumn42
            // 
            this.bandedGridColumn42.Caption = "bandedGridColumn42";
            this.bandedGridColumn42.Name = "bandedGridColumn42";
            this.bandedGridColumn42.Visible = true;
            // 
            // bandedGridColumn43
            // 
            this.bandedGridColumn43.Caption = "bandedGridColumn43";
            this.bandedGridColumn43.Name = "bandedGridColumn43";
            this.bandedGridColumn43.Visible = true;
            // 
            // bandedGridColumn44
            // 
            this.bandedGridColumn44.Caption = "bandedGridColumn44";
            this.bandedGridColumn44.Name = "bandedGridColumn44";
            this.bandedGridColumn44.Visible = true;
            // 
            // bandedGridColumn45
            // 
            this.bandedGridColumn45.Caption = "bandedGridColumn45";
            this.bandedGridColumn45.Name = "bandedGridColumn45";
            this.bandedGridColumn45.Visible = true;
            // 
            // bandedGridColumn46
            // 
            this.bandedGridColumn46.Caption = "bandedGridColumn46";
            this.bandedGridColumn46.Name = "bandedGridColumn46";
            this.bandedGridColumn46.Visible = true;
            // 
            // bandedGridColumn47
            // 
            this.bandedGridColumn47.Caption = "bandedGridColumn47";
            this.bandedGridColumn47.Name = "bandedGridColumn47";
            this.bandedGridColumn47.Visible = true;
            // 
            // bandedGridColumn48
            // 
            this.bandedGridColumn48.Caption = "bandedGridColumn48";
            this.bandedGridColumn48.Name = "bandedGridColumn48";
            this.bandedGridColumn48.Visible = true;
            // 
            // bandedGridColumn49
            // 
            this.bandedGridColumn49.Caption = "bandedGridColumn49";
            this.bandedGridColumn49.Name = "bandedGridColumn49";
            this.bandedGridColumn49.Visible = true;
            // 
            // bandedGridColumn50
            // 
            this.bandedGridColumn50.Caption = "bandedGridColumn50";
            this.bandedGridColumn50.Name = "bandedGridColumn50";
            this.bandedGridColumn50.Visible = true;
            // 
            // bandedGridColumn51
            // 
            this.bandedGridColumn51.Caption = "bandedGridColumn51";
            this.bandedGridColumn51.Name = "bandedGridColumn51";
            this.bandedGridColumn51.Visible = true;
            // 
            // bandedGridColumn52
            // 
            this.bandedGridColumn52.Caption = "bandedGridColumn52";
            this.bandedGridColumn52.Name = "bandedGridColumn52";
            this.bandedGridColumn52.Visible = true;
            // 
            // bandedGridColumn53
            // 
            this.bandedGridColumn53.Caption = "bandedGridColumn53";
            this.bandedGridColumn53.Name = "bandedGridColumn53";
            this.bandedGridColumn53.Visible = true;
            // 
            // bandedGridColumn54
            // 
            this.bandedGridColumn54.Caption = "bandedGridColumn54";
            this.bandedGridColumn54.Name = "bandedGridColumn54";
            this.bandedGridColumn54.Visible = true;
            // 
            // bandedGridColumn55
            // 
            this.bandedGridColumn55.Caption = "bandedGridColumn55";
            this.bandedGridColumn55.Name = "bandedGridColumn55";
            this.bandedGridColumn55.Visible = true;
            // 
            // bandedGridColumn56
            // 
            this.bandedGridColumn56.Caption = "bandedGridColumn56";
            this.bandedGridColumn56.Name = "bandedGridColumn56";
            this.bandedGridColumn56.Visible = true;
            // 
            // bandedGridColumn57
            // 
            this.bandedGridColumn57.Caption = "bandedGridColumn57";
            this.bandedGridColumn57.Name = "bandedGridColumn57";
            this.bandedGridColumn57.Visible = true;
            // 
            // bandedGridColumn58
            // 
            this.bandedGridColumn58.Caption = "bandedGridColumn58";
            this.bandedGridColumn58.Name = "bandedGridColumn58";
            this.bandedGridColumn58.Visible = true;
            // 
            // bandedGridColumn59
            // 
            this.bandedGridColumn59.Caption = "bandedGridColumn59";
            this.bandedGridColumn59.Name = "bandedGridColumn59";
            this.bandedGridColumn59.Visible = true;
            // 
            // bandedGridColumn60
            // 
            this.bandedGridColumn60.Caption = "bandedGridColumn60";
            this.bandedGridColumn60.Name = "bandedGridColumn60";
            this.bandedGridColumn60.Visible = true;
            // 
            // xtp_b3
            // 
            this.xtp_b3.Controls.Add(this.gridControl3);
            this.xtp_b3.Name = "xtp_b3";
            this.xtp_b3.Size = new System.Drawing.Size(825, 561);
            this.xtp_b3.Text = "表3 占用征收林地按主导功能统计表（长期占用）";
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.advBandedGridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(825, 561);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView3});
            // 
            // advBandedGridView3
            // 
            this.advBandedGridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn61,
            this.bandedGridColumn62,
            this.bandedGridColumn63,
            this.bandedGridColumn64,
            this.bandedGridColumn65,
            this.bandedGridColumn66,
            this.bandedGridColumn67,
            this.bandedGridColumn68,
            this.bandedGridColumn69,
            this.bandedGridColumn70,
            this.bandedGridColumn71,
            this.bandedGridColumn72,
            this.bandedGridColumn73,
            this.bandedGridColumn74,
            this.bandedGridColumn75,
            this.bandedGridColumn76,
            this.bandedGridColumn77,
            this.bandedGridColumn78,
            this.bandedGridColumn79,
            this.bandedGridColumn80,
            this.bandedGridColumn81,
            this.bandedGridColumn82,
            this.bandedGridColumn83,
            this.bandedGridColumn84,
            this.bandedGridColumn85,
            this.bandedGridColumn86});
            this.advBandedGridView3.GridControl = this.gridControl3;
            this.advBandedGridView3.Name = "advBandedGridView3";
            this.advBandedGridView3.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn61
            // 
            this.bandedGridColumn61.Caption = "bandedGridColumn61";
            this.bandedGridColumn61.Name = "bandedGridColumn61";
            this.bandedGridColumn61.Visible = true;
            // 
            // bandedGridColumn62
            // 
            this.bandedGridColumn62.Caption = "bandedGridColumn62";
            this.bandedGridColumn62.Name = "bandedGridColumn62";
            this.bandedGridColumn62.Visible = true;
            // 
            // bandedGridColumn63
            // 
            this.bandedGridColumn63.Caption = "bandedGridColumn63";
            this.bandedGridColumn63.Name = "bandedGridColumn63";
            this.bandedGridColumn63.Visible = true;
            // 
            // bandedGridColumn64
            // 
            this.bandedGridColumn64.Caption = "bandedGridColumn64";
            this.bandedGridColumn64.Name = "bandedGridColumn64";
            this.bandedGridColumn64.Visible = true;
            // 
            // bandedGridColumn65
            // 
            this.bandedGridColumn65.Caption = "bandedGridColumn65";
            this.bandedGridColumn65.Name = "bandedGridColumn65";
            this.bandedGridColumn65.Visible = true;
            // 
            // bandedGridColumn66
            // 
            this.bandedGridColumn66.Caption = "bandedGridColumn66";
            this.bandedGridColumn66.Name = "bandedGridColumn66";
            this.bandedGridColumn66.Visible = true;
            // 
            // bandedGridColumn67
            // 
            this.bandedGridColumn67.Caption = "bandedGridColumn67";
            this.bandedGridColumn67.Name = "bandedGridColumn67";
            this.bandedGridColumn67.Visible = true;
            // 
            // bandedGridColumn68
            // 
            this.bandedGridColumn68.Caption = "bandedGridColumn68";
            this.bandedGridColumn68.Name = "bandedGridColumn68";
            this.bandedGridColumn68.Visible = true;
            // 
            // bandedGridColumn69
            // 
            this.bandedGridColumn69.Caption = "bandedGridColumn69";
            this.bandedGridColumn69.Name = "bandedGridColumn69";
            this.bandedGridColumn69.Visible = true;
            // 
            // bandedGridColumn70
            // 
            this.bandedGridColumn70.Caption = "bandedGridColumn70";
            this.bandedGridColumn70.Name = "bandedGridColumn70";
            this.bandedGridColumn70.Visible = true;
            // 
            // bandedGridColumn71
            // 
            this.bandedGridColumn71.Caption = "bandedGridColumn71";
            this.bandedGridColumn71.Name = "bandedGridColumn71";
            this.bandedGridColumn71.Visible = true;
            // 
            // bandedGridColumn72
            // 
            this.bandedGridColumn72.Caption = "bandedGridColumn72";
            this.bandedGridColumn72.Name = "bandedGridColumn72";
            this.bandedGridColumn72.Visible = true;
            // 
            // bandedGridColumn73
            // 
            this.bandedGridColumn73.Caption = "bandedGridColumn73";
            this.bandedGridColumn73.Name = "bandedGridColumn73";
            this.bandedGridColumn73.Visible = true;
            // 
            // bandedGridColumn74
            // 
            this.bandedGridColumn74.Caption = "bandedGridColumn74";
            this.bandedGridColumn74.Name = "bandedGridColumn74";
            this.bandedGridColumn74.Visible = true;
            // 
            // bandedGridColumn75
            // 
            this.bandedGridColumn75.Caption = "bandedGridColumn75";
            this.bandedGridColumn75.Name = "bandedGridColumn75";
            this.bandedGridColumn75.Visible = true;
            // 
            // bandedGridColumn76
            // 
            this.bandedGridColumn76.Caption = "bandedGridColumn76";
            this.bandedGridColumn76.Name = "bandedGridColumn76";
            this.bandedGridColumn76.Visible = true;
            // 
            // bandedGridColumn77
            // 
            this.bandedGridColumn77.Caption = "bandedGridColumn77";
            this.bandedGridColumn77.Name = "bandedGridColumn77";
            this.bandedGridColumn77.Visible = true;
            // 
            // bandedGridColumn78
            // 
            this.bandedGridColumn78.Caption = "bandedGridColumn78";
            this.bandedGridColumn78.Name = "bandedGridColumn78";
            this.bandedGridColumn78.Visible = true;
            // 
            // bandedGridColumn79
            // 
            this.bandedGridColumn79.Caption = "bandedGridColumn79";
            this.bandedGridColumn79.Name = "bandedGridColumn79";
            this.bandedGridColumn79.Visible = true;
            // 
            // bandedGridColumn80
            // 
            this.bandedGridColumn80.Caption = "bandedGridColumn80";
            this.bandedGridColumn80.Name = "bandedGridColumn80";
            this.bandedGridColumn80.Visible = true;
            // 
            // bandedGridColumn81
            // 
            this.bandedGridColumn81.Caption = "bandedGridColumn81";
            this.bandedGridColumn81.Name = "bandedGridColumn81";
            this.bandedGridColumn81.Visible = true;
            // 
            // bandedGridColumn82
            // 
            this.bandedGridColumn82.Caption = "bandedGridColumn82";
            this.bandedGridColumn82.Name = "bandedGridColumn82";
            this.bandedGridColumn82.Visible = true;
            // 
            // bandedGridColumn83
            // 
            this.bandedGridColumn83.Caption = "bandedGridColumn83";
            this.bandedGridColumn83.Name = "bandedGridColumn83";
            this.bandedGridColumn83.Visible = true;
            // 
            // bandedGridColumn84
            // 
            this.bandedGridColumn84.Caption = "bandedGridColumn84";
            this.bandedGridColumn84.Name = "bandedGridColumn84";
            this.bandedGridColumn84.Visible = true;
            // 
            // bandedGridColumn85
            // 
            this.bandedGridColumn85.Caption = "bandedGridColumn85";
            this.bandedGridColumn85.Name = "bandedGridColumn85";
            this.bandedGridColumn85.Visible = true;
            // 
            // bandedGridColumn86
            // 
            this.bandedGridColumn86.Caption = "bandedGridColumn86";
            this.bandedGridColumn86.Name = "bandedGridColumn86";
            this.bandedGridColumn86.Visible = true;
            // 
            // xtp_b4
            // 
            this.xtp_b4.Controls.Add(this.gridControl5);
            this.xtp_b4.Name = "xtp_b4";
            this.xtp_b4.Size = new System.Drawing.Size(825, 561);
            this.xtp_b4.Text = "表4 占用征收林地按主导功能统计表（临时占用）";
            // 
            // gridControl5
            // 
            this.gridControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl5.Location = new System.Drawing.Point(0, 0);
            this.gridControl5.MainView = this.advBandedGridView5;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.Size = new System.Drawing.Size(825, 561);
            this.gridControl5.TabIndex = 0;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView5});
            // 
            // advBandedGridView5
            // 
            this.advBandedGridView5.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn87,
            this.bandedGridColumn88,
            this.bandedGridColumn89,
            this.bandedGridColumn90,
            this.bandedGridColumn91,
            this.bandedGridColumn92,
            this.bandedGridColumn93,
            this.bandedGridColumn94,
            this.bandedGridColumn95,
            this.bandedGridColumn96,
            this.bandedGridColumn97,
            this.bandedGridColumn98,
            this.bandedGridColumn99,
            this.bandedGridColumn100,
            this.bandedGridColumn101,
            this.bandedGridColumn102,
            this.bandedGridColumn103,
            this.bandedGridColumn104,
            this.bandedGridColumn105,
            this.bandedGridColumn106,
            this.bandedGridColumn107,
            this.bandedGridColumn108,
            this.bandedGridColumn109,
            this.bandedGridColumn110,
            this.bandedGridColumn111,
            this.bandedGridColumn112});
            this.advBandedGridView5.GridControl = this.gridControl5;
            this.advBandedGridView5.Name = "advBandedGridView5";
            this.advBandedGridView5.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn87
            // 
            this.bandedGridColumn87.Caption = "bandedGridColumn87";
            this.bandedGridColumn87.Name = "bandedGridColumn87";
            this.bandedGridColumn87.Visible = true;
            // 
            // bandedGridColumn88
            // 
            this.bandedGridColumn88.Caption = "bandedGridColumn88";
            this.bandedGridColumn88.Name = "bandedGridColumn88";
            this.bandedGridColumn88.Visible = true;
            // 
            // bandedGridColumn89
            // 
            this.bandedGridColumn89.Caption = "bandedGridColumn89";
            this.bandedGridColumn89.Name = "bandedGridColumn89";
            this.bandedGridColumn89.Visible = true;
            // 
            // bandedGridColumn90
            // 
            this.bandedGridColumn90.Caption = "bandedGridColumn90";
            this.bandedGridColumn90.Name = "bandedGridColumn90";
            this.bandedGridColumn90.Visible = true;
            // 
            // bandedGridColumn91
            // 
            this.bandedGridColumn91.Caption = "bandedGridColumn91";
            this.bandedGridColumn91.Name = "bandedGridColumn91";
            this.bandedGridColumn91.Visible = true;
            // 
            // bandedGridColumn92
            // 
            this.bandedGridColumn92.Caption = "bandedGridColumn92";
            this.bandedGridColumn92.Name = "bandedGridColumn92";
            this.bandedGridColumn92.Visible = true;
            // 
            // bandedGridColumn93
            // 
            this.bandedGridColumn93.Caption = "bandedGridColumn93";
            this.bandedGridColumn93.Name = "bandedGridColumn93";
            this.bandedGridColumn93.Visible = true;
            // 
            // bandedGridColumn94
            // 
            this.bandedGridColumn94.Caption = "bandedGridColumn94";
            this.bandedGridColumn94.Name = "bandedGridColumn94";
            this.bandedGridColumn94.Visible = true;
            // 
            // bandedGridColumn95
            // 
            this.bandedGridColumn95.Caption = "bandedGridColumn95";
            this.bandedGridColumn95.Name = "bandedGridColumn95";
            this.bandedGridColumn95.Visible = true;
            // 
            // bandedGridColumn96
            // 
            this.bandedGridColumn96.Caption = "bandedGridColumn96";
            this.bandedGridColumn96.Name = "bandedGridColumn96";
            this.bandedGridColumn96.Visible = true;
            // 
            // bandedGridColumn97
            // 
            this.bandedGridColumn97.Caption = "bandedGridColumn97";
            this.bandedGridColumn97.Name = "bandedGridColumn97";
            this.bandedGridColumn97.Visible = true;
            // 
            // bandedGridColumn98
            // 
            this.bandedGridColumn98.Caption = "bandedGridColumn98";
            this.bandedGridColumn98.Name = "bandedGridColumn98";
            this.bandedGridColumn98.Visible = true;
            // 
            // bandedGridColumn99
            // 
            this.bandedGridColumn99.Caption = "bandedGridColumn99";
            this.bandedGridColumn99.Name = "bandedGridColumn99";
            this.bandedGridColumn99.Visible = true;
            // 
            // bandedGridColumn100
            // 
            this.bandedGridColumn100.Caption = "bandedGridColumn100";
            this.bandedGridColumn100.Name = "bandedGridColumn100";
            this.bandedGridColumn100.Visible = true;
            // 
            // bandedGridColumn101
            // 
            this.bandedGridColumn101.Caption = "bandedGridColumn101";
            this.bandedGridColumn101.Name = "bandedGridColumn101";
            this.bandedGridColumn101.Visible = true;
            // 
            // bandedGridColumn102
            // 
            this.bandedGridColumn102.Caption = "bandedGridColumn102";
            this.bandedGridColumn102.Name = "bandedGridColumn102";
            this.bandedGridColumn102.Visible = true;
            // 
            // bandedGridColumn103
            // 
            this.bandedGridColumn103.Caption = "bandedGridColumn103";
            this.bandedGridColumn103.Name = "bandedGridColumn103";
            this.bandedGridColumn103.Visible = true;
            // 
            // bandedGridColumn104
            // 
            this.bandedGridColumn104.Caption = "bandedGridColumn104";
            this.bandedGridColumn104.Name = "bandedGridColumn104";
            this.bandedGridColumn104.Visible = true;
            // 
            // bandedGridColumn105
            // 
            this.bandedGridColumn105.Caption = "bandedGridColumn105";
            this.bandedGridColumn105.Name = "bandedGridColumn105";
            this.bandedGridColumn105.Visible = true;
            // 
            // bandedGridColumn106
            // 
            this.bandedGridColumn106.Caption = "bandedGridColumn106";
            this.bandedGridColumn106.Name = "bandedGridColumn106";
            this.bandedGridColumn106.Visible = true;
            // 
            // bandedGridColumn107
            // 
            this.bandedGridColumn107.Caption = "bandedGridColumn107";
            this.bandedGridColumn107.Name = "bandedGridColumn107";
            this.bandedGridColumn107.Visible = true;
            // 
            // bandedGridColumn108
            // 
            this.bandedGridColumn108.Caption = "bandedGridColumn108";
            this.bandedGridColumn108.Name = "bandedGridColumn108";
            this.bandedGridColumn108.Visible = true;
            // 
            // bandedGridColumn109
            // 
            this.bandedGridColumn109.Caption = "bandedGridColumn109";
            this.bandedGridColumn109.Name = "bandedGridColumn109";
            this.bandedGridColumn109.Visible = true;
            // 
            // bandedGridColumn110
            // 
            this.bandedGridColumn110.Caption = "bandedGridColumn110";
            this.bandedGridColumn110.Name = "bandedGridColumn110";
            this.bandedGridColumn110.Visible = true;
            // 
            // bandedGridColumn111
            // 
            this.bandedGridColumn111.Caption = "bandedGridColumn111";
            this.bandedGridColumn111.Name = "bandedGridColumn111";
            this.bandedGridColumn111.Visible = true;
            // 
            // bandedGridColumn112
            // 
            this.bandedGridColumn112.Caption = "bandedGridColumn112";
            this.bandedGridColumn112.Name = "bandedGridColumn112";
            this.bandedGridColumn112.Visible = true;
            // 
            // xtp_b5
            // 
            this.xtp_b5.Controls.Add(this.gridControl4);
            this.xtp_b5.Name = "xtp_b5";
            this.xtp_b5.Size = new System.Drawing.Size(825, 561);
            this.xtp_b5.Text = "表5 占用征收林地按主导功能统计表（林业占用）";
            // 
            // gridControl4
            // 
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.Location = new System.Drawing.Point(0, 0);
            this.gridControl4.MainView = this.advBandedGridView4;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.Size = new System.Drawing.Size(825, 561);
            this.gridControl4.TabIndex = 0;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView4});
            // 
            // advBandedGridView4
            // 
            this.advBandedGridView4.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn113,
            this.bandedGridColumn114,
            this.bandedGridColumn115,
            this.bandedGridColumn116,
            this.bandedGridColumn117,
            this.bandedGridColumn118,
            this.bandedGridColumn119,
            this.bandedGridColumn120,
            this.bandedGridColumn121,
            this.bandedGridColumn122,
            this.bandedGridColumn123,
            this.bandedGridColumn124,
            this.bandedGridColumn125,
            this.bandedGridColumn126,
            this.bandedGridColumn127,
            this.bandedGridColumn128,
            this.bandedGridColumn129,
            this.bandedGridColumn130,
            this.bandedGridColumn131,
            this.bandedGridColumn132,
            this.bandedGridColumn133,
            this.bandedGridColumn134,
            this.bandedGridColumn135,
            this.bandedGridColumn136,
            this.bandedGridColumn137,
            this.bandedGridColumn138});
            this.advBandedGridView4.GridControl = this.gridControl4;
            this.advBandedGridView4.Name = "advBandedGridView4";
            this.advBandedGridView4.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn113
            // 
            this.bandedGridColumn113.Caption = "bandedGridColumn113";
            this.bandedGridColumn113.Name = "bandedGridColumn113";
            this.bandedGridColumn113.Visible = true;
            // 
            // bandedGridColumn114
            // 
            this.bandedGridColumn114.Caption = "bandedGridColumn114";
            this.bandedGridColumn114.Name = "bandedGridColumn114";
            this.bandedGridColumn114.Visible = true;
            // 
            // bandedGridColumn115
            // 
            this.bandedGridColumn115.Caption = "bandedGridColumn115";
            this.bandedGridColumn115.Name = "bandedGridColumn115";
            this.bandedGridColumn115.Visible = true;
            // 
            // bandedGridColumn116
            // 
            this.bandedGridColumn116.Caption = "bandedGridColumn116";
            this.bandedGridColumn116.Name = "bandedGridColumn116";
            this.bandedGridColumn116.Visible = true;
            // 
            // bandedGridColumn117
            // 
            this.bandedGridColumn117.Caption = "bandedGridColumn117";
            this.bandedGridColumn117.Name = "bandedGridColumn117";
            this.bandedGridColumn117.Visible = true;
            // 
            // bandedGridColumn118
            // 
            this.bandedGridColumn118.Caption = "bandedGridColumn118";
            this.bandedGridColumn118.Name = "bandedGridColumn118";
            this.bandedGridColumn118.Visible = true;
            // 
            // bandedGridColumn119
            // 
            this.bandedGridColumn119.Caption = "bandedGridColumn119";
            this.bandedGridColumn119.Name = "bandedGridColumn119";
            this.bandedGridColumn119.Visible = true;
            // 
            // bandedGridColumn120
            // 
            this.bandedGridColumn120.Caption = "bandedGridColumn120";
            this.bandedGridColumn120.Name = "bandedGridColumn120";
            this.bandedGridColumn120.Visible = true;
            // 
            // bandedGridColumn121
            // 
            this.bandedGridColumn121.Caption = "bandedGridColumn121";
            this.bandedGridColumn121.Name = "bandedGridColumn121";
            this.bandedGridColumn121.Visible = true;
            // 
            // bandedGridColumn122
            // 
            this.bandedGridColumn122.Caption = "bandedGridColumn122";
            this.bandedGridColumn122.Name = "bandedGridColumn122";
            this.bandedGridColumn122.Visible = true;
            // 
            // bandedGridColumn123
            // 
            this.bandedGridColumn123.Caption = "bandedGridColumn123";
            this.bandedGridColumn123.Name = "bandedGridColumn123";
            this.bandedGridColumn123.Visible = true;
            // 
            // bandedGridColumn124
            // 
            this.bandedGridColumn124.Caption = "bandedGridColumn124";
            this.bandedGridColumn124.Name = "bandedGridColumn124";
            this.bandedGridColumn124.Visible = true;
            // 
            // bandedGridColumn125
            // 
            this.bandedGridColumn125.Caption = "bandedGridColumn125";
            this.bandedGridColumn125.Name = "bandedGridColumn125";
            this.bandedGridColumn125.Visible = true;
            // 
            // bandedGridColumn126
            // 
            this.bandedGridColumn126.Caption = "bandedGridColumn126";
            this.bandedGridColumn126.Name = "bandedGridColumn126";
            this.bandedGridColumn126.Visible = true;
            // 
            // bandedGridColumn127
            // 
            this.bandedGridColumn127.Caption = "bandedGridColumn127";
            this.bandedGridColumn127.Name = "bandedGridColumn127";
            this.bandedGridColumn127.Visible = true;
            // 
            // bandedGridColumn128
            // 
            this.bandedGridColumn128.Caption = "bandedGridColumn128";
            this.bandedGridColumn128.Name = "bandedGridColumn128";
            this.bandedGridColumn128.Visible = true;
            // 
            // bandedGridColumn129
            // 
            this.bandedGridColumn129.Caption = "bandedGridColumn129";
            this.bandedGridColumn129.Name = "bandedGridColumn129";
            this.bandedGridColumn129.Visible = true;
            // 
            // bandedGridColumn130
            // 
            this.bandedGridColumn130.Caption = "bandedGridColumn130";
            this.bandedGridColumn130.Name = "bandedGridColumn130";
            this.bandedGridColumn130.Visible = true;
            // 
            // bandedGridColumn131
            // 
            this.bandedGridColumn131.Caption = "bandedGridColumn131";
            this.bandedGridColumn131.Name = "bandedGridColumn131";
            this.bandedGridColumn131.Visible = true;
            // 
            // bandedGridColumn132
            // 
            this.bandedGridColumn132.Caption = "bandedGridColumn132";
            this.bandedGridColumn132.Name = "bandedGridColumn132";
            this.bandedGridColumn132.Visible = true;
            // 
            // bandedGridColumn133
            // 
            this.bandedGridColumn133.Caption = "bandedGridColumn133";
            this.bandedGridColumn133.Name = "bandedGridColumn133";
            this.bandedGridColumn133.Visible = true;
            // 
            // bandedGridColumn134
            // 
            this.bandedGridColumn134.Caption = "bandedGridColumn134";
            this.bandedGridColumn134.Name = "bandedGridColumn134";
            this.bandedGridColumn134.Visible = true;
            // 
            // bandedGridColumn135
            // 
            this.bandedGridColumn135.Caption = "bandedGridColumn135";
            this.bandedGridColumn135.Name = "bandedGridColumn135";
            this.bandedGridColumn135.Visible = true;
            // 
            // bandedGridColumn136
            // 
            this.bandedGridColumn136.Caption = "bandedGridColumn136";
            this.bandedGridColumn136.Name = "bandedGridColumn136";
            this.bandedGridColumn136.Visible = true;
            // 
            // bandedGridColumn137
            // 
            this.bandedGridColumn137.Caption = "bandedGridColumn137";
            this.bandedGridColumn137.Name = "bandedGridColumn137";
            this.bandedGridColumn137.Visible = true;
            // 
            // bandedGridColumn138
            // 
            this.bandedGridColumn138.Caption = "bandedGridColumn138";
            this.bandedGridColumn138.Name = "bandedGridColumn138";
            this.bandedGridColumn138.Visible = true;
            // 
            // FormLdzzyStat
            // 
            this.ClientSize = new System.Drawing.Size(831, 615);
            this.Controls.Add(this.xtcb_gyltj);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormLdzzyStat";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "占用征收林地统计表";
            this.Load += new System.EventHandler(this.FormLdzzyStat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcb_gyltj)).EndInit();
            this.xtcb_gyltj.ResumeLayout(false);
            this.xtp_b1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            this.xtp_b2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView2)).EndInit();
            this.xtp_b3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).EndInit();
            this.xtp_b4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView5)).EndInit();
            this.xtp_b5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Stat(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {
            try
            {
                this._Dtb1 = this.Calc_zzyyftj(lst);
                this._Dtb2 = this.Calc_zd_hj(lst);
                this._Dtb3 = this.Calc_zd_zq_ls(lst, true);
                this._Dtb4 = this.Calc_zd_zq_ls(lst,false);
                this._Dtb5 = this.Calc_zd_ly(lst);
                this.gridControl1.DataSource = this._Dtb1;
                for (int i = 0; i < this._Dtb1.Columns.Count; i++)
                {
                    this.advBandedGridView1.Columns[i].FieldName = this._Dtb1.Columns[i].ColumnName;
                }
                this.advBandedGridView1.OptionsBehavior.Editable = false;
                this.gridControl2.DataSource = this._Dtb2;
                for (int j = 0; j < this._Dtb2.Columns.Count; j++)
                {
                    this.advBandedGridView2.Columns[j].FieldName = this._Dtb2.Columns[j].ColumnName;
                }
                this.advBandedGridView2.OptionsBehavior.Editable = false;
                this.gridControl3.DataSource = this._Dtb3;
                for (int k = 0; k < this._Dtb3.Columns.Count; k++)
                {
                    this.advBandedGridView3.Columns[k].FieldName = this._Dtb3.Columns[k].ColumnName;
                }
                this.advBandedGridView3.OptionsBehavior.Editable = false;
                this.gridControl5.DataSource = this._Dtb4;
                for (int m = 0; m < this._Dtb4.Columns.Count; m++)
                {
                    this.advBandedGridView5.Columns[m].FieldName = this._Dtb4.Columns[m].ColumnName;
                }
                this.advBandedGridView5.OptionsBehavior.Editable = false;
                this.gridControl4.DataSource = this._Dtb5;
                for (int n = 0; n < this._Dtb5.Columns.Count; n++)
                {
                    this.advBandedGridView4.Columns[n].FieldName = this._Dtb5.Columns[n].ColumnName;
                }
                this.advBandedGridView4.OptionsBehavior.Editable = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormLdzzyStat::Stat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 将报表导出Excel表格的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBtn_ExportToExcel_Click(object sender, EventArgs e)
        {
            string srcPath = Application.StartupPath + @"\林地征占用国家统计表模板.xls";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel文件|*.xls";
            dialog.FileName = "林地征占用国家统计表模板.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string> sheets = new List<string>();
                sheets.Add("占用征用林地按月份统计表");
                sheets.Add("占用征用林地按主导功能统计表");
                sheets.Add("长期占用征用林地按主导功能统计表");
                sheets.Add("临时占用征用林地按主导功能统计表");
                sheets.Add("林业占用征用林地统计表");
                List<DataTable> tables = new List<DataTable>();
                tables.Add(this._Dtb1);
                tables.Add(this._Dtb2);
                tables.Add(this._Dtb3);
                tables.Add(this._Dtb4);
                tables.Add(this._Dtb5);
                List<int> starts = new List<int>();
                starts.Add(4);
                starts.Add(7);
                starts.Add(8);
                starts.Add(8);
                starts.Add(7);
                List<int> cols = new List<int>();
                cols.Add(40);
                cols.Add(20);
                cols.Add(0x1a);
                cols.Add(0x1a);
                cols.Add(0x1a);
                CommonFunctions.ExportDataToExcelFile(srcPath, dialog.FileName, sheets, tables, starts, cols);
            }
        }
    }
}

