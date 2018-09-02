namespace gylandzzytj
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraTab;
    using LDZY_GYLTJ;
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
    using Utilities;
    using ConSQLServerInfo;

    /// <summary>
    /// 统计--公益林统计表：窗体
    /// </summary>
    public class FormGylStat : Form
    {
        string sqlitepath = UtilFactory.GetConfigOpt().RootPath + "Data\\forest_142326_2016.db";
        public System.Data.SQLite.SQLiteConnection cnn;
        private string _ConnectionString = ConnectionSQLServerString.Get_M_Str_ConnectionString();
        private DataTable _Dtb1;
        private DataTable _Dtb2;
        private DataTable _Dtb3;
        private DataTable _Dtb4;
        private DataTable _Dtb5;
        private DataTable _gylDatas;
        private string _TableName = "";
        private AdvBandedGridView advBandedGridView1;
        private AdvBandedGridView advBandedGridView2;
        private AdvBandedGridView advBandedGridView3;
        private AdvBandedGridView advBandedGridView4;
        private AdvBandedGridView advBandedGridView5;
        private BandedGridColumn bandedGridColumn1;
        private BandedGridColumn bandedGridColumn10;
        private BandedGridColumn bandedGridColumn100;
        private BandedGridColumn bandedGridColumn11;
        private BandedGridColumn bandedGridColumn12;
        private BandedGridColumn bandedGridColumn13;
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
        private BarButtonItem barButtonItem1;
        private BarDockControl barDockControl1;
        private BarDockControl barDockControl2;
        private BarDockControl barDockControl3;
        private BarDockControl barDockControl4;
        private BarDockControl barDockControl5;
        private BarDockControl barDockControl6;
        private BarDockControl barDockControl7;
        private BarDockControl barDockControl8;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private BarManager barManager2;
        private BarManager barManager3;
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

        /// <summary>
        /// 统计--公益林统计表：窗体构造器
        /// </summary>
        /// <param name="tname"></param>
        public FormGylStat(string tname)
        {
            this.InitializeComponent();
            this._TableName = tname;
        }

        /// <summary>
        /// 将查询到的数据填充进数据表
        /// </summary>
        private void b1_stat()
        {
            //因为没有连接到SQLServer数据库，因此注销以下代码
            if (string.IsNullOrEmpty(this._ConnectionString))
            {
                this._ConnectionString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            }
            if (!string.IsNullOrEmpty(this._ConnectionString))
            {
                try
                {
                    GYLTJ.M_Str_ConnectionString = this._ConnectionString;
                    GYLTJ.TABLE_XBTableName = this._TableName;
                    GYLTJ gyltj = new GYLTJ();
                    this._Dtb1 = gyltj.B1TJByXianXiangCun(true);
                    this.gridControl1.DataSource = this._Dtb1;
                    for (int i = 0; i < this._Dtb1.Columns.Count; i++)
                    {
                        this.advBandedGridView1.Columns[i].FieldName = this._Dtb1.Columns[i].ColumnName;
                    }
                    this.advBandedGridView1.OptionsBehavior.Editable = false;
                    this._Dtb2 = gyltj.B2TJByXianXiangCun(true);
                    this.gridControl2.DataSource = this._Dtb2;
                    for (int j = 0; j < this._Dtb2.Columns.Count; j++)
                    {
                        this.advBandedGridView2.Columns[j].FieldName = this._Dtb2.Columns[j].ColumnName;
                    }
                    this.advBandedGridView2.OptionsBehavior.Editable = false;
                    this._Dtb3 = gyltj.B3TJByXianXiangCun(true);
                    this.gridControl3.DataSource = this._Dtb3;
                    for (int k = 0; k < this._Dtb3.Columns.Count; k++)
                    {
                        this.advBandedGridView3.Columns[k].FieldName = this._Dtb3.Columns[k].ColumnName;
                    }
                    this.advBandedGridView3.OptionsBehavior.Editable = false;
                    this._Dtb4 = gyltj.B4TJByXianXiangCun();
                    this.gridControl4.DataSource = this._Dtb4;
                    for (int m = 0; m < this._Dtb4.Columns.Count; m++)
                    {
                        this.advBandedGridView4.Columns[m].FieldName = this._Dtb4.Columns[m].ColumnName;
                    }
                    this.advBandedGridView4.OptionsBehavior.Editable = false;
                    this._Dtb5 = gyltj.B5TJByXianXiangCun(true);
                    this.gridControl5.DataSource = this._Dtb5;
                    for (int n = 0; n < this._Dtb5.Columns.Count; n++)
                    {
                        this.advBandedGridView5.Columns[n].FieldName = this._Dtb5.Columns[n].ColumnName;
                    }
                    this.advBandedGridView5.OptionsBehavior.Editable = false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("统计过程中发生错误：" + exception.Message, "FormGylStat::b1_stat", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void b1_statByCode(SqlConnection con, ref DataTable dt, string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                if (dt == null)
                {
                    dt = new DataTable();
                }
                this.b1_statByCodeInDiLei(con, ref dt, code);
            }
        }

        private void b1_statByCodeInDiLei(SqlConnection con, ref DataTable dt, string code)
        {
            string[] strArray = new string[] { "合计", "有林地", "疏林地", "灌木林地", "未成林地", "苗圃地", "无立木林地", "宜林地", "林业辅助生产林地" };
            foreach (string str in strArray)
            {
                this.b1_statByCodeInDiLei(con, ref dt, code, str);
            }
            int length = code.Length;
            if (length != 6)
            {
                if (length != 9)
                {
                    return;
                }
            }
            else
            {
                foreach (string str2 in CommonFunctions.GetXiangList(con, this._TableName, code, ForestConditions.GetCondition("公益林").Condition))
                {
                    this.b1_statByCodeInDiLei(con, ref dt, str2);
                }
                return;
            }
            foreach (string str3 in CommonFunctions.GetCunList(con, this._TableName, code, ForestConditions.GetCondition("公益林").Condition))
            {
                this.b1_statByCodeInDiLei(con, ref dt, str3);
            }
        }

        private void b1_statByCodeInDiLei(SqlConnection con, ref DataTable dt, string code, string dl)
        {
            string[] strArray = new string[] { "防护林", "水源涵养林", "水土保持林", "防风固沙林", "农田牧场防护林", "护岸林", "护路林", "其它防护林", "特用林", "国防林", "实验林", "母树林", "环境保护林", "风景林", "名胜古迹和纪念林", "自然保护林" };
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("单位");
                dt.Columns.Add("地类");
                for (int i = 0; i < strArray.Length; i++)
                {
                    dt.Columns.Add(strArray[i]);
                }
            }
            DataRow row = this.FindRow(dt, code, "地类", dl);
            if (row == null)
            {
                row = dt.NewRow();
                row[0] = code;
                row[1] = dl;
                for (int j = 0; j < strArray.Length; j++)
                {
                    row[strArray[j]] = 0;
                }
                dt.Rows.Add(row);
            }
            foreach (string str in strArray)
            {
                this.SumDatas(code, dl, str, ref row);
            }
        }

        private void b1_statByCodeInDiLei(SqlConnection con, ref DataRow row, int col, string code, ForestCondition dl, string lz)
        {
            string cmdText = "select sum(mian_ji) from ";
            cmdText = (((cmdText + this._TableName + " where ") + "left(CUN, " + code.Length) + ") = '" + code) + "' and " + ForestConditions.GetCondition("公益林").Condition;
            if (dl != null)
            {
                cmdText = cmdText + " and " + dl.Condition;
            }
            if (!string.IsNullOrEmpty(lz))
            {
                cmdText = cmdText + " and " + lz;
            }
            SqlDataReader reader = new SqlCommand(cmdText, con).ExecuteReader();
            if (reader.Read())
            {
                row[col] = reader.GetValue(0);
            }
            reader.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private DataRow FindRow(DataTable dt, string code, string filed, string text)
        {
            foreach (DataRow row2 in dt.Rows)
            {
                if ((row2[0].ToString() == code) && (row2[filed].ToString() == text))
                {
                    return row2;
                }
            }
            return null;
        }

        /// <summary>
        /// 公益林加载窗体响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitB1();
            this.InitB2();
            this.InitB3();
            this.InitB4();
            this.InitB5();
            this.b1_stat();
        }

        private void GetGylDatas()
        {
            try
            {
                string selectCommandText = "select CUN as 村, DI_LEI as 地类, LD_QS as 权属, LIN_ZHONG as 林种, SHI_QUAN_D as 事权级, MIAN_JI as 面积 from ";
                selectCommandText = (selectCommandText + this._TableName) + " where " + ForestConditions.GetCondition("公益林").Condition;
                this._gylDatas = new DataTable();
                SqlConnection selectConnection = new SqlConnection(this._ConnectionString);
                new SqlDataAdapter(selectCommandText, selectConnection).Fill(this._gylDatas);
            }
            catch (Exception exception)
            {
                MessageBox.Show("检索数据过程中发生错误：" + exception.Message, "FormGylStat::GetGylDatas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string GetLocationName(SqlConnection con, string code)
        {
            string str = "";
            string str2 = "select CNAME from T_SYS_META_CODE where ";
            switch (code.Length)
            {
                case 6:
                    str2 = str2 + "CTYPE = '县' and CCODE = '";
                    break;

                case 9:
                    str2 = str2 + "CTYPE = '乡' and CCODE = '";
                    break;

                case 12:
                    str2 = str2 + "CTYPE = '村' and CCODE = '";
                    break;
            }
            SqlDataReader reader = new SqlCommand(str2 + code + "'", con).ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetValue(0).ToString();
            }
            reader.Close();
            return str;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void InitB1()
        {
            BandedGridView view = this.advBandedGridView1;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("吕梁市公益林按地类统计表");
            GridBand band2 = band.Children.AddBand("单位：公顷");
            GridBand band3 = band2.Children.AddBand("单位");
            this.bandedGridColumn1.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("地类");
            this.bandedGridColumn2.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("公益林");
            GridBand band6 = band5.Children.AddBand("合计");
            this.bandedGridColumn3.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("防护林");
            GridBand band8 = band7.Children.AddBand("小计");
            this.bandedGridColumn4.OwnerBand = band8;
            GridBand band9 = band7.Children.AddBand("水源涵养林");
            this.bandedGridColumn5.OwnerBand = band9;
            GridBand band10 = band7.Children.AddBand("水土保持林");
            this.bandedGridColumn6.OwnerBand = band10;
            GridBand band11 = band7.Children.AddBand("防风固沙林");
            this.bandedGridColumn7.OwnerBand = band11;
            GridBand band12 = band7.Children.AddBand("农田牧场\r\n防护林");
            this.bandedGridColumn8.OwnerBand = band12;
            GridBand band13 = band7.Children.AddBand("护岸林");
            this.bandedGridColumn9.OwnerBand = band13;
            GridBand band14 = band7.Children.AddBand("护路林");
            this.bandedGridColumn10.OwnerBand = band14;
            GridBand band15 = band7.Children.AddBand("其他防护林");
            this.bandedGridColumn11.OwnerBand = band15;
            GridBand band16 = band5.Children.AddBand("特种用途林");
            GridBand band17 = band16.Children.AddBand("小计");
            this.bandedGridColumn12.OwnerBand = band17;
            GridBand band18 = band16.Children.AddBand("国防林");
            this.bandedGridColumn13.OwnerBand = band18;
            GridBand band19 = band16.Children.AddBand("实验林");
            this.bandedGridColumn14.OwnerBand = band19;
            GridBand band20 = band16.Children.AddBand("母树林");
            this.bandedGridColumn15.OwnerBand = band20;
            GridBand band21 = band16.Children.AddBand("环境保护林");
            this.bandedGridColumn16.OwnerBand = band21;
            GridBand band22 = band16.Children.AddBand("风景林");
            this.bandedGridColumn17.OwnerBand = band22;
            GridBand band23 = band16.Children.AddBand("名胜古迹革\r\n命纪念林");
            this.bandedGridColumn18.OwnerBand = band23;
            GridBand band24 = band16.Children.AddBand("自然\r\n保护区林");
            this.bandedGridColumn19.OwnerBand = band24;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.RowCount = 2;
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
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitB2()
        {
            BandedGridView view = this.advBandedGridView2;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("吕梁市公益林按权属统计表");
            GridBand band2 = band.Children.AddBand("单位：公顷");
            GridBand band3 = band2.Children.AddBand("单位");
            this.bandedGridColumn20.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("权属");
            this.bandedGridColumn21.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("公益林");
            GridBand band6 = band5.Children.AddBand("合计");
            this.bandedGridColumn22.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("按林种划分");
            GridBand band8 = band7.Children.AddBand("小计");
            this.bandedGridColumn23.OwnerBand = band8;
            GridBand band9 = band7.Children.AddBand("水源涵养林");
            this.bandedGridColumn24.OwnerBand = band9;
            GridBand band10 = band7.Children.AddBand("水土保持林");
            this.bandedGridColumn25.OwnerBand = band10;
            GridBand band11 = band7.Children.AddBand("防风固沙林");
            this.bandedGridColumn26.OwnerBand = band11;
            GridBand band12 = band7.Children.AddBand("护岸林");
            this.bandedGridColumn27.OwnerBand = band12;
            GridBand band13 = band7.Children.AddBand("自然\r\n保护区林");
            this.bandedGridColumn28.OwnerBand = band13;
            GridBand band14 = band7.Children.AddBand("国防林");
            this.bandedGridColumn29.OwnerBand = band14;
            GridBand band15 = band7.Children.AddBand("其他防护林");
            this.bandedGridColumn30.OwnerBand = band15;
            GridBand band16 = band5.Children.AddBand("按地类分");
            GridBand band17 = band16.Children.AddBand("小计");
            this.bandedGridColumn31.OwnerBand = band17;
            GridBand band18 = band16.Children.AddBand("有林地");
            this.bandedGridColumn32.OwnerBand = band18;
            GridBand band19 = band16.Children.AddBand("疏林地");
            this.bandedGridColumn33.OwnerBand = band19;
            GridBand band20 = band16.Children.AddBand("灌木林地");
            this.bandedGridColumn34.OwnerBand = band20;
            GridBand band21 = band16.Children.AddBand("未成林地");
            this.bandedGridColumn35.OwnerBand = band21;
            GridBand band22 = band16.Children.AddBand("苗圃地");
            this.bandedGridColumn36.OwnerBand = band22;
            GridBand band23 = band16.Children.AddBand("无立木林地");
            this.bandedGridColumn37.OwnerBand = band23;
            GridBand band24 = band16.Children.AddBand("宜林地");
            this.bandedGridColumn38.OwnerBand = band24;
            GridBand band25 = band16.Children.AddBand("辅助\r\n生产用地");
            this.bandedGridColumn39.OwnerBand = band25;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.RowCount = 2;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitB3()
        {
            BandedGridView view = this.advBandedGridView3;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("吕梁市公益林按事权级统计表");
            GridBand band2 = band.Children.AddBand("单位：公顷");
            GridBand band3 = band2.Children.AddBand("单位");
            this.bandedGridColumn40.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("事权级");
            this.bandedGridColumn41.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("公益林");
            GridBand band6 = band5.Children.AddBand("合计");
            this.bandedGridColumn42.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("按林种划分");
            GridBand band8 = band7.Children.AddBand("小计");
            this.bandedGridColumn43.OwnerBand = band8;
            GridBand band9 = band7.Children.AddBand("水源涵养林");
            this.bandedGridColumn44.OwnerBand = band9;
            GridBand band10 = band7.Children.AddBand("水土保持林");
            this.bandedGridColumn45.OwnerBand = band10;
            GridBand band11 = band7.Children.AddBand("防风固沙林");
            this.bandedGridColumn46.OwnerBand = band11;
            GridBand band12 = band7.Children.AddBand("护岸林");
            this.bandedGridColumn47.OwnerBand = band12;
            GridBand band13 = band7.Children.AddBand("自然\r\n保护区林");
            this.bandedGridColumn48.OwnerBand = band13;
            GridBand band14 = band7.Children.AddBand("国防林");
            this.bandedGridColumn49.OwnerBand = band14;
            GridBand band15 = band7.Children.AddBand("其他防护林");
            this.bandedGridColumn50.OwnerBand = band15;
            GridBand band16 = band5.Children.AddBand("按地类分");
            GridBand band17 = band16.Children.AddBand("小计");
            this.bandedGridColumn51.OwnerBand = band17;
            GridBand band18 = band16.Children.AddBand("有林地");
            this.bandedGridColumn52.OwnerBand = band18;
            GridBand band19 = band16.Children.AddBand("疏林地");
            this.bandedGridColumn53.OwnerBand = band19;
            GridBand band20 = band16.Children.AddBand("灌木林地");
            this.bandedGridColumn54.OwnerBand = band20;
            GridBand band21 = band16.Children.AddBand("未成林地");
            this.bandedGridColumn55.OwnerBand = band21;
            GridBand band22 = band16.Children.AddBand("苗圃地");
            this.bandedGridColumn56.OwnerBand = band22;
            GridBand band23 = band16.Children.AddBand("无立木林地");
            this.bandedGridColumn57.OwnerBand = band23;
            GridBand band24 = band16.Children.AddBand("宜林地");
            this.bandedGridColumn58.OwnerBand = band24;
            GridBand band25 = band16.Children.AddBand("辅助\r\n生产用地");
            this.bandedGridColumn59.OwnerBand = band25;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.RowCount = 2;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitB4()
        {
            BandedGridView view = this.advBandedGridView4;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("吕梁市公益林按生态区位统计表");
            GridBand band2 = band.Children.AddBand("单位：公顷");
            GridBand band3 = band2.Children.AddBand("单位");
            this.bandedGridColumn80.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("生态区位");
            this.bandedGridColumn81.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("区位名称");
            this.bandedGridColumn82.OwnerBand = band5;
            GridBand band6 = band2.Children.AddBand("公益林");
            GridBand band7 = band6.Children.AddBand("合计");
            this.bandedGridColumn83.OwnerBand = band7;
            GridBand band8 = band6.Children.AddBand("按林种划分");
            GridBand band9 = band8.Children.AddBand("小计");
            this.bandedGridColumn84.OwnerBand = band9;
            GridBand band10 = band8.Children.AddBand("水源涵养林");
            this.bandedGridColumn85.OwnerBand = band10;
            GridBand band11 = band8.Children.AddBand("水土保持林");
            this.bandedGridColumn86.OwnerBand = band11;
            GridBand band12 = band8.Children.AddBand("防风固沙林");
            this.bandedGridColumn87.OwnerBand = band12;
            GridBand band13 = band8.Children.AddBand("护岸林");
            this.bandedGridColumn88.OwnerBand = band13;
            GridBand band14 = band8.Children.AddBand("自然\r\n保护区林");
            this.bandedGridColumn89.OwnerBand = band14;
            GridBand band15 = band8.Children.AddBand("国防林");
            this.bandedGridColumn90.OwnerBand = band15;
            GridBand band16 = band8.Children.AddBand("其他防护林");
            this.bandedGridColumn91.OwnerBand = band16;
            GridBand band17 = band6.Children.AddBand("按地类分");
            GridBand band18 = band17.Children.AddBand("小计");
            this.bandedGridColumn92.OwnerBand = band18;
            GridBand band19 = band17.Children.AddBand("有林地");
            this.bandedGridColumn93.OwnerBand = band19;
            GridBand band20 = band17.Children.AddBand("疏林地");
            this.bandedGridColumn94.OwnerBand = band20;
            GridBand band21 = band17.Children.AddBand("灌木林地");
            this.bandedGridColumn95.OwnerBand = band21;
            GridBand band22 = band17.Children.AddBand("未成林地");
            this.bandedGridColumn96.OwnerBand = band22;
            GridBand band23 = band17.Children.AddBand("苗圃地");
            this.bandedGridColumn97.OwnerBand = band23;
            GridBand band24 = band17.Children.AddBand("无立木林地");
            this.bandedGridColumn98.OwnerBand = band24;
            GridBand band25 = band17.Children.AddBand("宜林地");
            this.bandedGridColumn99.OwnerBand = band25;
            GridBand band26 = band17.Children.AddBand("辅助\r\n生产用地");
            this.bandedGridColumn100.OwnerBand = band26;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band9.RowCount = 2;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band26.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitB5()
        {
            BandedGridView view = this.advBandedGridView5;
            view.BeginUpdate();
            view.BeginDataUpdate();
            view.Bands.Clear();
            view.OptionsView.ShowColumnHeaders = false;
            GridBand band = view.Bands.AddBand("吕梁市公益林按保护等级统计表");
            GridBand band2 = band.Children.AddBand("单位：公顷");
            GridBand band3 = band2.Children.AddBand("单位");
            this.bandedGridColumn60.OwnerBand = band3;
            GridBand band4 = band2.Children.AddBand("保护等级");
            this.bandedGridColumn61.OwnerBand = band4;
            GridBand band5 = band2.Children.AddBand("公益林");
            GridBand band6 = band5.Children.AddBand("合计");
            this.bandedGridColumn62.OwnerBand = band6;
            GridBand band7 = band5.Children.AddBand("按林种划分");
            GridBand band8 = band7.Children.AddBand("小计");
            this.bandedGridColumn63.OwnerBand = band8;
            GridBand band9 = band7.Children.AddBand("水源涵养林");
            this.bandedGridColumn64.OwnerBand = band9;
            GridBand band10 = band7.Children.AddBand("水土保持林");
            this.bandedGridColumn65.OwnerBand = band10;
            GridBand band11 = band7.Children.AddBand("防风固沙林");
            this.bandedGridColumn66.OwnerBand = band11;
            GridBand band12 = band7.Children.AddBand("护岸林");
            this.bandedGridColumn67.OwnerBand = band12;
            GridBand band13 = band7.Children.AddBand("自然\r\n保护区林");
            this.bandedGridColumn68.OwnerBand = band13;
            GridBand band14 = band7.Children.AddBand("国防林");
            this.bandedGridColumn69.OwnerBand = band14;
            GridBand band15 = band7.Children.AddBand("其他防护林");
            this.bandedGridColumn70.OwnerBand = band15;
            GridBand band16 = band5.Children.AddBand("按地类分");
            GridBand band17 = band16.Children.AddBand("小计");
            this.bandedGridColumn71.OwnerBand = band17;
            GridBand band18 = band16.Children.AddBand("有林地");
            this.bandedGridColumn72.OwnerBand = band18;
            GridBand band19 = band16.Children.AddBand("疏林地");
            this.bandedGridColumn73.OwnerBand = band19;
            GridBand band20 = band16.Children.AddBand("灌木林地");
            this.bandedGridColumn74.OwnerBand = band20;
            GridBand band21 = band16.Children.AddBand("未成林地");
            this.bandedGridColumn75.OwnerBand = band21;
            GridBand band22 = band16.Children.AddBand("苗圃地");
            this.bandedGridColumn76.OwnerBand = band22;
            GridBand band23 = band16.Children.AddBand("无立木林地");
            this.bandedGridColumn77.OwnerBand = band23;
            GridBand band24 = band16.Children.AddBand("宜林地");
            this.bandedGridColumn78.OwnerBand = band24;
            GridBand band25 = band16.Children.AddBand("辅助\r\n生产用地");
            this.bandedGridColumn79.OwnerBand = band25;
            band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band.AppearanceHeader.Font = new Font("宋体", 18f);
            band.RowCount = 2;
            band2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
            band3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band8.RowCount = 2;
            band9.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band10.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band11.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band12.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band15.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band16.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band17.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band14.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band18.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band19.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band20.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band21.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band22.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band13.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band23.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band24.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            band25.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            view.EndDataUpdate();
            view.EndUpdate();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGylStat));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager2 = new DevExpress.XtraBars.BarManager();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barManager3 = new DevExpress.XtraBars.BarManager();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
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
            this.xtp_b2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView2 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
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
            this.xtp_b3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView3 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.xtp_b4 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView4 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn80 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn81 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn82 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn83 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn84 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn85 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn86 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.xtp_b5 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView5 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.bandedGridColumn60 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager3)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).BeginInit();
            this.xtp_b5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 562);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 562);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "jjjh";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.MaxItemId = 0;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 562);
            this.barDockControl2.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 562);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(884, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 562);
            // 
            // barManager3
            // 
            this.barManager3.DockControls.Add(this.barDockControl5);
            this.barManager3.DockControls.Add(this.barDockControl6);
            this.barManager3.DockControls.Add(this.barDockControl7);
            this.barManager3.DockControls.Add(this.barDockControl8);
            this.barManager3.Form = this;
            this.barManager3.MaxItemId = 1;
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl5.Location = new System.Drawing.Point(0, 0);
            this.barDockControl5.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl6.Location = new System.Drawing.Point(0, 562);
            this.barDockControl6.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl7.Location = new System.Drawing.Point(0, 0);
            this.barDockControl7.Size = new System.Drawing.Size(0, 562);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl8.Location = new System.Drawing.Point(884, 0);
            this.barDockControl8.Size = new System.Drawing.Size(0, 562);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBtn_ExportToExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 12;
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
            this.xtcb_gyltj.Size = new System.Drawing.Size(884, 537);
            this.xtcb_gyltj.TabIndex = 13;
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
            this.xtp_b1.Size = new System.Drawing.Size(878, 508);
            this.xtp_b1.Text = "表1 吕梁市公益林按地类统计表";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(878, 508);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
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
            this.bandedGridColumn19});
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
            // xtp_b2
            // 
            this.xtp_b2.Controls.Add(this.gridControl2);
            this.xtp_b2.Name = "xtp_b2";
            this.xtp_b2.Size = new System.Drawing.Size(878, 508);
            this.xtp_b2.Text = "表2 吕梁市公益林按权属统计表";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.advBandedGridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(878, 508);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView2});
            // 
            // advBandedGridView2
            // 
            this.advBandedGridView2.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
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
            this.bandedGridColumn39});
            this.advBandedGridView2.GridControl = this.gridControl2;
            this.advBandedGridView2.Name = "advBandedGridView2";
            this.advBandedGridView2.OptionsView.ShowGroupPanel = false;
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
            // xtp_b3
            // 
            this.xtp_b3.Controls.Add(this.gridControl3);
            this.xtp_b3.Name = "xtp_b3";
            this.xtp_b3.Size = new System.Drawing.Size(878, 508);
            this.xtp_b3.Text = "表3 吕梁市公益林按事权级统计表";
            // 
            // gridControl3
            // 
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 0);
            this.gridControl3.MainView = this.advBandedGridView3;
            this.gridControl3.MenuManager = this.barManager1;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.Size = new System.Drawing.Size(878, 508);
            this.gridControl3.TabIndex = 0;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView3});
            // 
            // advBandedGridView3
            // 
            this.advBandedGridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn40,
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
            this.bandedGridColumn59});
            this.advBandedGridView3.GridControl = this.gridControl3;
            this.advBandedGridView3.Name = "advBandedGridView3";
            this.advBandedGridView3.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn40
            // 
            this.bandedGridColumn40.Caption = "bandedGridColumn40";
            this.bandedGridColumn40.Name = "bandedGridColumn40";
            this.bandedGridColumn40.Visible = true;
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
            // xtp_b4
            // 
            this.xtp_b4.Controls.Add(this.gridControl4);
            this.xtp_b4.Name = "xtp_b4";
            this.xtp_b4.Size = new System.Drawing.Size(878, 508);
            this.xtp_b4.Text = "表4 吕梁市公益林按生态区位统计表";
            // 
            // gridControl4
            // 
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.Location = new System.Drawing.Point(0, 0);
            this.gridControl4.MainView = this.advBandedGridView4;
            this.gridControl4.MenuManager = this.barManager1;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.Size = new System.Drawing.Size(878, 508);
            this.gridControl4.TabIndex = 1;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView4});
            // 
            // advBandedGridView4
            // 
            this.advBandedGridView4.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn80,
            this.bandedGridColumn81,
            this.bandedGridColumn82,
            this.bandedGridColumn83,
            this.bandedGridColumn84,
            this.bandedGridColumn85,
            this.bandedGridColumn86,
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
            this.bandedGridColumn100});
            this.advBandedGridView4.GridControl = this.gridControl4;
            this.advBandedGridView4.Name = "advBandedGridView4";
            this.advBandedGridView4.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn80
            // 
            this.bandedGridColumn80.Caption = "bandedGridColumn60";
            this.bandedGridColumn80.Name = "bandedGridColumn80";
            this.bandedGridColumn80.Visible = true;
            // 
            // bandedGridColumn81
            // 
            this.bandedGridColumn81.Caption = "bandedGridColumn61";
            this.bandedGridColumn81.Name = "bandedGridColumn81";
            this.bandedGridColumn81.Visible = true;
            // 
            // bandedGridColumn82
            // 
            this.bandedGridColumn82.Caption = "bandedGridColumn62";
            this.bandedGridColumn82.Name = "bandedGridColumn82";
            this.bandedGridColumn82.Visible = true;
            // 
            // bandedGridColumn83
            // 
            this.bandedGridColumn83.Caption = "bandedGridColumn63";
            this.bandedGridColumn83.Name = "bandedGridColumn83";
            this.bandedGridColumn83.Visible = true;
            // 
            // bandedGridColumn84
            // 
            this.bandedGridColumn84.Caption = "bandedGridColumn64";
            this.bandedGridColumn84.Name = "bandedGridColumn84";
            this.bandedGridColumn84.Visible = true;
            // 
            // bandedGridColumn85
            // 
            this.bandedGridColumn85.Caption = "bandedGridColumn65";
            this.bandedGridColumn85.Name = "bandedGridColumn85";
            this.bandedGridColumn85.Visible = true;
            // 
            // bandedGridColumn86
            // 
            this.bandedGridColumn86.Caption = "bandedGridColumn66";
            this.bandedGridColumn86.Name = "bandedGridColumn86";
            this.bandedGridColumn86.Visible = true;
            // 
            // bandedGridColumn87
            // 
            this.bandedGridColumn87.Caption = "bandedGridColumn67";
            this.bandedGridColumn87.Name = "bandedGridColumn87";
            this.bandedGridColumn87.Visible = true;
            // 
            // bandedGridColumn88
            // 
            this.bandedGridColumn88.Caption = "bandedGridColumn68";
            this.bandedGridColumn88.Name = "bandedGridColumn88";
            this.bandedGridColumn88.Visible = true;
            // 
            // bandedGridColumn89
            // 
            this.bandedGridColumn89.Caption = "bandedGridColumn69";
            this.bandedGridColumn89.Name = "bandedGridColumn89";
            this.bandedGridColumn89.Visible = true;
            // 
            // bandedGridColumn90
            // 
            this.bandedGridColumn90.Caption = "bandedGridColumn70";
            this.bandedGridColumn90.Name = "bandedGridColumn90";
            this.bandedGridColumn90.Visible = true;
            // 
            // bandedGridColumn91
            // 
            this.bandedGridColumn91.Caption = "bandedGridColumn71";
            this.bandedGridColumn91.Name = "bandedGridColumn91";
            this.bandedGridColumn91.Visible = true;
            // 
            // bandedGridColumn92
            // 
            this.bandedGridColumn92.Caption = "bandedGridColumn72";
            this.bandedGridColumn92.Name = "bandedGridColumn92";
            this.bandedGridColumn92.Visible = true;
            // 
            // bandedGridColumn93
            // 
            this.bandedGridColumn93.Caption = "bandedGridColumn73";
            this.bandedGridColumn93.Name = "bandedGridColumn93";
            this.bandedGridColumn93.Visible = true;
            // 
            // bandedGridColumn94
            // 
            this.bandedGridColumn94.Caption = "bandedGridColumn74";
            this.bandedGridColumn94.Name = "bandedGridColumn94";
            this.bandedGridColumn94.Visible = true;
            // 
            // bandedGridColumn95
            // 
            this.bandedGridColumn95.Caption = "bandedGridColumn75";
            this.bandedGridColumn95.Name = "bandedGridColumn95";
            this.bandedGridColumn95.Visible = true;
            // 
            // bandedGridColumn96
            // 
            this.bandedGridColumn96.Caption = "bandedGridColumn76";
            this.bandedGridColumn96.Name = "bandedGridColumn96";
            this.bandedGridColumn96.Visible = true;
            // 
            // bandedGridColumn97
            // 
            this.bandedGridColumn97.Caption = "bandedGridColumn77";
            this.bandedGridColumn97.Name = "bandedGridColumn97";
            this.bandedGridColumn97.Visible = true;
            // 
            // bandedGridColumn98
            // 
            this.bandedGridColumn98.Caption = "bandedGridColumn78";
            this.bandedGridColumn98.Name = "bandedGridColumn98";
            this.bandedGridColumn98.Visible = true;
            // 
            // bandedGridColumn99
            // 
            this.bandedGridColumn99.Caption = "bandedGridColumn79";
            this.bandedGridColumn99.Name = "bandedGridColumn99";
            this.bandedGridColumn99.Visible = true;
            // 
            // bandedGridColumn100
            // 
            this.bandedGridColumn100.Caption = "bandedGridColumn100";
            this.bandedGridColumn100.Name = "bandedGridColumn100";
            this.bandedGridColumn100.Visible = true;
            // 
            // xtp_b5
            // 
            this.xtp_b5.Controls.Add(this.gridControl5);
            this.xtp_b5.Name = "xtp_b5";
            this.xtp_b5.Size = new System.Drawing.Size(878, 508);
            this.xtp_b5.Text = "表5 吕梁市公益林按保护等级统计表";
            // 
            // gridControl5
            // 
            this.gridControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl5.Location = new System.Drawing.Point(0, 0);
            this.gridControl5.MainView = this.advBandedGridView5;
            this.gridControl5.MenuManager = this.barManager1;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.Size = new System.Drawing.Size(878, 508);
            this.gridControl5.TabIndex = 0;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView5});
            // 
            // advBandedGridView5
            // 
            this.advBandedGridView5.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn60,
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
            this.bandedGridColumn79});
            this.advBandedGridView5.GridControl = this.gridControl5;
            this.advBandedGridView5.Name = "advBandedGridView5";
            this.advBandedGridView5.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn60
            // 
            this.bandedGridColumn60.Caption = "bandedGridColumn60";
            this.bandedGridColumn60.Name = "bandedGridColumn60";
            this.bandedGridColumn60.Visible = true;
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
            // FormGylStat
            // 
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.xtcb_gyltj);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl7);
            this.Controls.Add(this.barDockControl8);
            this.Controls.Add(this.barDockControl6);
            this.Controls.Add(this.barDockControl5);
            this.Name = "FormGylStat";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公益林统计";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager3)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView4)).EndInit();
            this.xtp_b5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SumDatas(string code, string dl, string lz, ref DataRow row)
        {
            foreach (DataRow row2 in this._gylDatas.Rows)
            {
                if ((Convert.IsDBNull(row2["村"]) || Convert.IsDBNull(row2["地类"])) || (Convert.IsDBNull(row2["林种"]) || (row2[0].ToString().IndexOf(code) == -1)))
                {
                    continue;
                }
                bool flag = false;
                string str = row2["地类"].ToString();
                if (str.Length < 1)
                {
                    continue;
                }
                switch (dl)
                {
                    case "合计":
                        flag = true;
                        goto Label_0240;

                    case "有林地":
                        if (str.Substring(0, 1) != "1")
                        {
                            break;
                        }
                        flag = true;
                        goto Label_0240;

                    case "疏林地":
                        if (str.Substring(0, 1) == "2")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "灌木林地":
                        if (str.Substring(0, 1) == "3")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "未成林地":
                        if (str.Substring(0, 1) == "4")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "苗圃地":
                        if (str.Substring(0, 1) == "5")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "无立木林地":
                        if (str.Substring(0, 1) == "6")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "宜林地":
                        if (str.Substring(0, 1) == "7")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    case "辅助生产用地":
                        if (str.Substring(0, 1) == "8")
                        {
                            flag = true;
                        }
                        goto Label_0240;

                    default:
                        goto Label_0240;
                }
                flag = false;
            Label_0240:
                if (flag)
                {
                    string str2 = row2["林种"].ToString();
                    if (str2.Length >= 2)
                    {
                        switch (lz)
                        {
                            case "防护林":
                                if (str2.Substring(0, 2) != "11")
                                {
                                    flag = false;
                                }
                                break;

                            case "水源涵养林":
                                if (str2 != "111")
                                {
                                    flag = false;
                                }
                                break;

                            case "水土保持林":
                                if (str2 != "112")
                                {
                                    flag = false;
                                }
                                break;

                            case "防风固沙林":
                                if (str2 != "113")
                                {
                                    flag = false;
                                }
                                break;

                            case "农田牧场防护林":
                                if (str2 != "114")
                                {
                                    flag = false;
                                }
                                break;

                            case "护岸林":
                                if (str2 != "115")
                                {
                                    flag = false;
                                }
                                break;

                            case "护路林":
                                if (str2 != "116")
                                {
                                    flag = false;
                                }
                                break;

                            case "其它防护林":
                                if (str2 != "117")
                                {
                                    flag = false;
                                }
                                break;

                            case "特用林":
                                if (str2.Substring(0, 2) != "12")
                                {
                                    flag = false;
                                }
                                break;

                            case "国防林":
                                if (str2 != "121")
                                {
                                    flag = false;
                                }
                                break;

                            case "实验林":
                                if (str2 != "122")
                                {
                                    flag = false;
                                }
                                break;

                            case "母树林":
                                if (str2 != "123")
                                {
                                    flag = false;
                                }
                                break;

                            case "环境保护林":
                                if (str2 != "124")
                                {
                                    flag = false;
                                }
                                break;

                            case "风景林":
                                if (str2 != "125")
                                {
                                    flag = false;
                                }
                                break;

                            case "名胜古迹和纪念林":
                                if (str2 != "126")
                                {
                                    flag = false;
                                }
                                break;

                            case "自然保护林":
                                if (str2 != "127")
                                {
                                    flag = false;
                                }
                                break;
                        }
                        if (flag)
                        {
                            double result = 0.0;
                            if ((row[lz] != null) && !Convert.IsDBNull(row[lz]))
                            {
                                double.TryParse(row[lz].ToString(), out result);
                            }
                            double num2 = 0.0;
                            if (!Convert.IsDBNull(row2["面积"]))
                            {
                                double.TryParse(row2["面积"].ToString(), out num2);
                            }
                            result += num2;
                            row[lz] = result;
                        }
                    }
                }
            }
        }

        private void tBtn_ExportToExcel_Click(object sender, EventArgs e)
        {
            string srcPath = Application.StartupPath + @"\公益林统计表.xls";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel文件|*.xls";
            dialog.FileName = "公益林统计表.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string> sheets = new List<string>();
                sheets.Add("表1");
                sheets.Add("表2");
                sheets.Add("表3");
                sheets.Add("表4");
                sheets.Add("表5");
                List<DataTable> tables = new List<DataTable>();
                tables.Add(this._Dtb1);
                tables.Add(this._Dtb2);
                tables.Add(this._Dtb3);
                tables.Add(this._Dtb4);
                tables.Add(this._Dtb5);
                List<int> starts = new List<int>();
                starts.Add(7);
                starts.Add(7);
                starts.Add(7);
                starts.Add(7);
                starts.Add(7);
                List<int> cols = new List<int>();
                cols.Add(20);
                cols.Add(20);
                cols.Add(20);
                cols.Add(20);
                cols.Add(0x15);
                CommonFunctions.ExportDataToExcelFile(srcPath, dialog.FileName, sheets, tables, starts, cols);
            }
        }
    }
}

