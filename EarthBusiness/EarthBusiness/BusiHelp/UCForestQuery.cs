namespace EarthBusiness.BusiHelp
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraTab;
    using EarthBusiness;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UCForestQuery : UserControl
    {
        private SimpleButton btn_clear;
        private SimpleButton btn_clearBusiness;
        private SimpleButton btn_foreQuery;
        private SimpleButton btn_foreStatis;
        private SimpleButton btn_queryBusi;
        private System.Windows.Forms.ComboBox cb_business;
        private System.Windows.Forms.ComboBox cb_town;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.ComboBox cb_typeValue;
        private System.Windows.Forms.ComboBox cb_village;
        private IContainer components;
        private DataGridView dgv_total;
        private DataGridView dgv_xb;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private string m_busiLayerName = string.Empty;
        private ClsDbHandler m_clsDbHandler;
        private string m_connString = string.Empty;
        private string m_contyCode = string.Empty;
        private string m_djName = string.Empty;
        private FrmForestStatis m_forestStatisForm;
        private string m_mapName = string.Empty;
        private bool m_needAddField;
        private string m_pcode = string.Empty;
        private string m_updateYear = string.Empty;
        private string m_whereClause = string.Empty;
        private TextEdit te_conty;
        private XtraTabControl xtraTabControl1;
        private XtraTabControl xtraTabControl2;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPage5;

        public event LabelPoints OnBusinessQueryComplete;

        public event FlashThemMap OnForestThemQueryComplete;

        public event ClearLabelPoints OnLabelPointsClear;

        public event ClearSelectThemMap OnThemQueryResultClear;

        public event FlyToXB OnXbGridViewDoubleClick;

        public UCForestQuery()
        {
            this.InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.cb_type.SelectedIndex = -1;
            this.cb_typeValue.SelectedIndex = -1;
            this.cb_town.SelectedIndex = -1;
            this.cb_village.SelectedIndex = -1;
            if (this.dgv_total.DataSource != null)
            {
                this.dgv_total.DataSource = null;
            }
            if (this.dgv_xb.DataSource != null)
            {
                this.dgv_xb.DataSource = null;
            }
            if (!string.IsNullOrEmpty(this.m_mapName) && (this.OnThemQueryResultClear != null))
            {
                this.OnThemQueryResultClear(this, this.m_mapName);
            }
        }

        private void btn_clearBusiness_Click(object sender, EventArgs e)
        {
            this.cb_business.SelectedIndex = -1;
            if (this.dgv_total.DataSource != null)
            {
                this.dgv_total.DataSource = null;
            }
            if (this.dgv_xb.DataSource != null)
            {
                this.dgv_xb.DataSource = null;
            }
            if (this.OnLabelPointsClear != null)
            {
                this.OnLabelPointsClear(this, true);
            }
        }

        private void btn_foreQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_whereClause))
            {
                MessageBox.Show("请选择查询种类", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ForestQueryInfo forestThemQueryResult = this.m_clsDbHandler.GetForestThemQueryResult(this.m_pcode, this.m_whereClause);
                if (forestThemQueryResult != null)
                {
                    this.dgv_total.DataSource = forestThemQueryResult.Total;
                    this.dgv_xb.DataSource = forestThemQueryResult.XB;
                    this.m_mapName = this.m_djName + this.cb_typeValue.Text;
                    if (this.OnForestThemQueryComplete != null)
                    {
                        this.OnForestThemQueryComplete(this, this.m_mapName, this.cb_type.SelectedValue.ToString());
                    }
                }
            }
        }

        private void btn_foreStatis_Click(object sender, EventArgs e)
        {
            if ((this.m_forestStatisForm == null) || !this.m_forestStatisForm.Visible)
            {
                this.m_forestStatisForm = new FrmForestStatis(this.m_clsDbHandler, this.m_connString, this.m_updateYear);
                this.m_forestStatisForm.Show(this);
            }
        }

        private void btn_queryBusi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_busiLayerName))
            {
                MessageBox.Show("请选择一个专题业务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                LindQueryResult businessQueryResult = this.m_clsDbHandler.GetBusinessQueryResult(this.m_busiLayerName);
                if (businessQueryResult != null)
                {
                    this.dgv_total.DataSource = businessQueryResult.CountArea;
                    this.dgv_xb.DataSource = businessQueryResult.XB;
                    if (this.OnBusinessQueryComplete != null)
                    {
                        this.OnBusinessQueryComplete(this, businessQueryResult);
                    }
                }
            }
        }

        private void cb_business_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_business.SelectedIndex >= 0)
            {
                this.m_busiLayerName = this.cb_business.SelectedValue.ToString();
            }
        }

        private void cb_town_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_town.SelectedIndex >= 0)
            {
                this.m_pcode = this.cb_town.SelectedValue.ToString();
                DataTable adminComboSource = this.m_clsDbHandler.GetAdminComboSource(this.m_pcode);
                if ((adminComboSource != null) && (adminComboSource.Rows.Count > 0))
                {
                    this.cb_village.DataSource = adminComboSource;
                    this.cb_village.DisplayMember = "CNAME";
                    this.cb_village.ValueMember = "CCODE";
                    this.cb_village.SelectedIndex = -1;
                }
            }
        }

        private void cb_type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_type.SelectedIndex >= 0)
            {
                if (this.cb_typeValue.DataSource != null)
                {
                    this.cb_typeValue.DataSource = null;
                }
                this.m_whereClause = string.Empty;
                DataTable typeValueComboDataSource = this.GetTypeValueComboDataSource(this.cb_type.SelectedValue.ToString());
                if ((typeValueComboDataSource != null) && (typeValueComboDataSource.Rows.Count > 0))
                {
                    this.cb_typeValue.DataSource = typeValueComboDataSource;
                    if (this.m_needAddField)
                    {
                        this.cb_typeValue.DisplayMember = "CNAME";
                        this.cb_typeValue.ValueMember = "CCODE";
                    }
                    else
                    {
                        this.cb_typeValue.DisplayMember = "字段值";
                        this.cb_typeValue.ValueMember = "条件";
                    }
                    this.cb_typeValue.SelectedIndex = -1;
                }
            }
        }

        private void cb_typeValue_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_typeValue.SelectedIndex >= 0)
            {
                if (this.m_needAddField)
                {
                    this.m_whereClause = this.cb_type.SelectedValue.ToString() + "='" + this.cb_typeValue.SelectedValue.ToString() + "'";
                }
                else
                {
                    this.m_whereClause = this.cb_typeValue.SelectedValue.ToString();
                }
            }
        }

        private void cb_village_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cb_village.SelectedIndex >= 0)
            {
                this.m_pcode = this.cb_village.SelectedValue.ToString();
            }
        }

        private void dgv_xb_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int oid = 0;
                    string tableName = string.Empty;
                    if (this.dgv_xb.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                    {
                        oid = Convert.ToInt32(this.dgv_xb.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    if (this.dgv_xb.Rows[e.RowIndex].Cells[4].Value != DBNull.Value)
                    {
                        tableName = this.dgv_xb.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                    if (this.OnXbGridViewDoubleClick != null)
                    {
                        this.OnXbGridViewDoubleClick(this, oid, tableName);
                    }
                }
            }
            catch
            {
            }
        }

        private void dgv_xb_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.dgv_xb.DataSource != null)
            {
                this.dgv_xb.Columns["表名"].Visible = false;
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

        private DataTable GetDILEIValue()
        {
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add(new DataColumn("字段值"));
            table.Columns.Add(new DataColumn("条件"));
            row = table.NewRow();
            row["字段值"] = "乔木林地";
            row["条件"] = "LEFT(DI_LEI,2) = '11'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "红树林";
            row["条件"] = "DI_LEI = '120'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "竹林地";
            row["条件"] = "DI_LEI = '130'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "疏林地";
            row["条件"] = "DI_LEI = '200'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "灌木林地";
            row["条件"] = "LEFT(DI_LEI,1) = '3'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "未成林地";
            row["条件"] = "LEFT(DI_LEI,1)= '4'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "苗圃地";
            row["条件"] = "DI_LEI = '500'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "无立木林地";
            row["条件"] = "LEFT(DI_LEI,1)= '6'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "宜林地";
            row["条件"] = "LEFT(DI_LEI,1)= '7'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "林业辅助用地";
            row["条件"] = "DI_LEI = '800'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "非林地";
            row["条件"] = "LEFT(DI_LEI,1)= '9'";
            table.Rows.Add(row);
            return table;
        }

        private DataTable GetQIYUANValue()
        {
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add(new DataColumn("字段值"));
            table.Columns.Add(new DataColumn("条件"));
            row = table.NewRow();
            row["字段值"] = "天然林";
            row["条件"] = "LEFT(QI_YUAN,1)='1'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "人工林";
            row["条件"] = "LEFT(QI_YUAN,1)='2' OR LEFT(QI_YUAN,1)='3'";
            table.Rows.Add(row);
            return table;
        }

        private DataTable GetSZValue()
        {
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add(new DataColumn("字段值"));
            table.Columns.Add(new DataColumn("条件"));
            row = table.NewRow();
            row["字段值"] = "杉木";
            row["条件"] = "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND LEFT(YOU_SHI_SZ,2)='12'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "松树";
            row["条件"] = "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND (LEFT(YOU_SHI_SZ,2)='11' OR (CAST(YOU_SHI_SZ AS INT)>130 AND CAST(YOU_SHI_SZ AS INT)<200))";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "桉树";
            row["条件"] = "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND (CAST(YOU_SHI_SZ AS INT)>=280 AND CAST(YOU_SHI_SZ AS INT)<=307)";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "一般阔叶树";
            row["条件"] = "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND ((CAST(YOU_SHI_SZ AS INT)>=200 AND CAST(YOU_SHI_SZ AS INT)<280) OR ( CAST(YOU_SHI_SZ AS INT)>=310 AND CAST(YOU_SHI_SZ AS INT)<400) OR (CAST(YOU_SHI_SZ AS INT)>600 AND CAST(YOU_SHI_SZ AS INT)<800 AND YOU_SHI_SZ<>'617' AND YOU_SHI_SZ<>'661' AND YOU_SHI_SZ<>'663' AND YOU_SHI_SZ<>'681' AND YOU_SHI_SZ<>'618' AND YOU_SHI_SZ<>'619' AND YOU_SHI_SZ<>'611' AND YOU_SHI_SZ<>'612' AND YOU_SHI_SZ<>'613' AND YOU_SHI_SZ<>'614' AND YOU_SHI_SZ<>'615' AND YOU_SHI_SZ<>'621'))";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "红树类";
            row["条件"] = "DI_LEI='120' AND LEFT(YOU_SHI_SZ,1) ='5'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "竹类";
            row["条件"] = "DI_LEI='130' AND LEFT(YOU_SHI_SZ,1) ='4'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "灌木林";
            row["条件"] = "LEFT(DI_LEI,1)='3' AND LEFT(YOU_SHI_SZ,1) = '8'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "油茶";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '661'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "八角";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '663'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "玉桂";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '681'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "茶叶";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '662'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "板栗";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '617'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "荔枝";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '618'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "龙眼";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ = '619'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "柑桔";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND (CAST(YOU_SHI_SZ AS INT)>=611 AND CAST(YOU_SHI_SZ AS INT)<=615)";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "芒果";
            row["条件"] = "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ='621'";
            table.Rows.Add(row);
            row = table.NewRow();
            row["字段值"] = "其它经济林";
            row["条件"] = "(DI_LEI='301' OR DI_LEI='302') AND (YOU_SHI_SZ='616' OR YOU_SHI_SZ='620' OR (CAST(YOU_SHI_SZ AS INT)>621 AND CAST(YOU_SHI_SZ AS INT)<=703 AND YOU_SHI_SZ<>'661' AND YOU_SHI_SZ<>'662' AND YOU_SHI_SZ<>'663' AND YOU_SHI_SZ<>'681'))";
            table.Rows.Add(row);
            return table;
        }

        private DataTable GetTypeValueComboDataSource(string field)
        {
            try
            {
                string sql = string.Empty;
                switch (field)
                {
                    case "YOU_SHI_SZ":
                        this.m_needAddField = false;
                        this.m_djName = string.Empty;
                        return this.GetSZValue();

                    case "DI_LEI":
                        this.m_needAddField = false;
                        this.m_djName = string.Empty;
                        return this.GetDILEIValue();

                    case "SEN_LIN_LB":
                        this.m_needAddField = true;
                        this.m_djName = string.Empty;
                        sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='森林类别' and CCODE in (select distinct SEN_LIN_LB from FOR_XIAOBAN_" + this.UpdateYear + ") order by CCODE";
                        return this.m_clsDbHandler.GetDataBySQL(sql);

                    case "QI_YUAN":
                        this.m_needAddField = false;
                        this.m_djName = string.Empty;
                        return this.GetQIYUANValue();

                    case "BH_DJ":
                        this.m_needAddField = true;
                        this.m_djName = "保护";
                        sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='林地保护等级' and CCODE in (select distinct BH_DJ from FOR_XIAOBAN_" + this.UpdateYear + ") order by CCODE";
                        return this.m_clsDbHandler.GetDataBySQL(sql);

                    case "ZL_DJ":
                        this.m_needAddField = true;
                        this.m_djName = "质量";
                        sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='林地质量等级' and CCODE in (select distinct ZL_DJ from FOR_XIAOBAN_" + this.UpdateYear + ") order by CCODE";
                        return this.m_clsDbHandler.GetDataBySQL(sql);
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetTypeValueComboDataSource出错，返回为空，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private void InitBusiComboSource()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("TABLENAME"));
            table.Columns.Add(new DataColumn("TABLEALIAS"));
            DataRow row = null;
            row = table.NewRow();
            row["TABLENAME"] = "ZT_CF_" + this.UpdateYear;
            row["TABLEALIAS"] = "森林采伐数据";
            table.Rows.Add(row);
            row = table.NewRow();
            row["TABLENAME"] = "ZT_ZL_" + this.UpdateYear;
            row["TABLEALIAS"] = "造林数据";
            table.Rows.Add(row);
            row = table.NewRow();
            row["TABLENAME"] = "ZT_LDZZ_" + this.UpdateYear;
            row["TABLEALIAS"] = "林地征占用数据";
            table.Rows.Add(row);
            row = table.NewRow();
            row["TABLENAME"] = "ZT_HZ_" + this.UpdateYear;
            row["TABLEALIAS"] = "火灾数据";
            table.Rows.Add(row);
            row = table.NewRow();
            row["TABLENAME"] = "ZT_LYAJ_" + this.UpdateYear;
            row["TABLEALIAS"] = "林业案件数据";
            table.Rows.Add(row);
            row = table.NewRow();
            row["TABLENAME"] = "ZT_ZH_" + this.UpdateYear;
            row["TABLEALIAS"] = "灾害数据";
            table.Rows.Add(row);
            this.cb_business.DataSource = table;
            this.cb_business.DisplayMember = "TABLEALIAS";
            this.cb_business.ValueMember = "TABLENAME";
            this.cb_business.SelectedIndex = -1;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UCForestQuery));
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage3 = new XtraTabPage();
            this.btn_foreStatis = new SimpleButton();
            this.xtraTabPage1 = new XtraTabPage();
            this.btn_clear = new SimpleButton();
            this.btn_foreQuery = new SimpleButton();
            this.cb_village = new System.Windows.Forms.ComboBox();
            this.cb_town = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.te_conty = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.cb_typeValue = new System.Windows.Forms.ComboBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new LabelControl();
            this.xtraTabPage2 = new XtraTabPage();
            this.btn_clearBusiness = new SimpleButton();
            this.btn_queryBusi = new SimpleButton();
            this.cb_business = new System.Windows.Forms.ComboBox();
            this.labelControl6 = new LabelControl();
            this.xtraTabControl2 = new XtraTabControl();
            this.xtraTabPage4 = new XtraTabPage();
            this.dgv_total = new DataGridView();
            this.xtraTabPage5 = new XtraTabPage();
            this.dgv_xb = new DataGridView();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.te_conty.Properties.BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabControl2.BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((ISupportInitialize) this.dgv_total).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((ISupportInitialize) this.dgv_xb).BeginInit();
            base.SuspendLayout();
            this.xtraTabControl1.Dock = DockStyle.Top;
            this.xtraTabControl1.Location = new Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage3;
            this.xtraTabControl1.Size = new Size(0xe8, 0xd5);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage3, this.xtraTabPage1, this.xtraTabPage2 });
            this.xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabPage3.Controls.Add(this.btn_foreStatis);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0xe2, 0xb9);
            this.xtraTabPage3.Text = "资源指标";
            this.btn_foreStatis.Image = (Image) manager.GetObject("btn_foreStatis.Image");
            this.btn_foreStatis.Location = new Point(0x49, 0x40);
            this.btn_foreStatis.Name = "btn_foreStatis";
            this.btn_foreStatis.Size = new Size(0x4b, 0x17);
            this.btn_foreStatis.TabIndex = 0;
            this.btn_foreStatis.Text = "指标统计";
            this.btn_foreStatis.Click += new EventHandler(this.btn_foreStatis_Click);
            this.xtraTabPage1.Controls.Add(this.btn_clear);
            this.xtraTabPage1.Controls.Add(this.btn_foreQuery);
            this.xtraTabPage1.Controls.Add(this.cb_village);
            this.xtraTabPage1.Controls.Add(this.cb_town);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.te_conty);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.cb_typeValue);
            this.xtraTabPage1.Controls.Add(this.cb_type);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0xe2, 0xb9);
            this.xtraTabPage1.Text = "资源查询";
            this.btn_clear.Image = (Image) manager.GetObject("btn_clear.Image");
            this.btn_clear.Location = new Point(0x27, 0x98);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new Size(0x44, 20);
            this.btn_clear.TabIndex = 11;
            this.btn_clear.Text = "清除";
            this.btn_clear.Click += new EventHandler(this.btn_clear_Click);
            this.btn_foreQuery.Image = (Image) manager.GetObject("btn_foreQuery.Image");
            this.btn_foreQuery.Location = new Point(0x90, 0x98);
            this.btn_foreQuery.Name = "btn_foreQuery";
            this.btn_foreQuery.Size = new Size(0x44, 20);
            this.btn_foreQuery.TabIndex = 10;
            this.btn_foreQuery.Text = "查询";
            this.btn_foreQuery.Click += new EventHandler(this.btn_foreQuery_Click);
            this.cb_village.BackColor = Color.AliceBlue;
            this.cb_village.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_village.FormattingEnabled = true;
            this.cb_village.Location = new Point(0x90, 0x75);
            this.cb_village.Name = "cb_village";
            this.cb_village.Size = new Size(0x44, 20);
            this.cb_village.TabIndex = 9;
            this.cb_village.SelectionChangeCommitted += new EventHandler(this.cb_village_SelectionChangeCommitted);
            this.cb_town.BackColor = Color.AliceBlue;
            this.cb_town.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_town.FormattingEnabled = true;
            this.cb_town.Location = new Point(0x27, 0x75);
            this.cb_town.Name = "cb_town";
            this.cb_town.Size = new Size(0x44, 20);
            this.cb_town.TabIndex = 8;
            this.cb_town.SelectionChangeCommitted += new EventHandler(this.cb_town_SelectionChangeCommitted);
            this.labelControl5.Location = new Point(0x76, 0x77);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x1d, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "|村：";
            this.labelControl4.Location = new Point(14, 0x77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x1d, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "|乡：";
            this.te_conty.Location = new Point(0x4b, 0x54);
            this.te_conty.Name = "te_conty";
            this.te_conty.Size = new Size(0x89, 0x15);
            this.te_conty.TabIndex = 5;
            this.te_conty.Click += new EventHandler(this.te_conty_Click);
            this.labelControl3.Location = new Point(14, 0x57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "查询范围：";
            this.labelControl2.Location = new Point(14, 0x37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "查询种类：";
            this.cb_typeValue.BackColor = Color.AliceBlue;
            this.cb_typeValue.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_typeValue.FormattingEnabled = true;
            this.cb_typeValue.Location = new Point(0x4b, 0x34);
            this.cb_typeValue.Name = "cb_typeValue";
            this.cb_typeValue.Size = new Size(0x89, 20);
            this.cb_typeValue.TabIndex = 2;
            this.cb_typeValue.SelectionChangeCommitted += new EventHandler(this.cb_typeValue_SelectionChangeCommitted);
            this.cb_type.BackColor = Color.AliceBlue;
            this.cb_type.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new Point(0x4b, 20);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new Size(0x89, 20);
            this.cb_type.TabIndex = 1;
            this.cb_type.SelectionChangeCommitted += new EventHandler(this.cb_type_SelectionChangeCommitted);
            this.labelControl1.Location = new Point(14, 0x17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "查询类型：";
            this.xtraTabPage2.Controls.Add(this.btn_clearBusiness);
            this.xtraTabPage2.Controls.Add(this.btn_queryBusi);
            this.xtraTabPage2.Controls.Add(this.cb_business);
            this.xtraTabPage2.Controls.Add(this.labelControl6);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0xe2, 0xb9);
            this.xtraTabPage2.Text = "业务查询";
            this.btn_clearBusiness.Image = (Image) manager.GetObject("btn_clearBusiness.Image");
            this.btn_clearBusiness.Location = new Point(0x11, 0x61);
            this.btn_clearBusiness.Name = "btn_clearBusiness";
            this.btn_clearBusiness.Size = new Size(0x4b, 0x17);
            this.btn_clearBusiness.TabIndex = 3;
            this.btn_clearBusiness.Text = "清除";
            this.btn_clearBusiness.Click += new EventHandler(this.btn_clearBusiness_Click);
            this.btn_queryBusi.Image = (Image) manager.GetObject("btn_queryBusi.Image");
            this.btn_queryBusi.Location = new Point(0x87, 0x61);
            this.btn_queryBusi.Name = "btn_queryBusi";
            this.btn_queryBusi.Size = new Size(0x4b, 0x17);
            this.btn_queryBusi.TabIndex = 2;
            this.btn_queryBusi.Text = "查询";
            this.btn_queryBusi.Click += new EventHandler(this.btn_queryBusi_Click);
            this.cb_business.BackColor = Color.AliceBlue;
            this.cb_business.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cb_business.FormattingEnabled = true;
            this.cb_business.Location = new Point(110, 0x20);
            this.cb_business.Name = "cb_business";
            this.cb_business.Size = new Size(100, 20);
            this.cb_business.TabIndex = 1;
            this.cb_business.SelectionChangeCommitted += new EventHandler(this.cb_business_SelectionChangeCommitted);
            this.labelControl6.Location = new Point(0x11, 0x23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x54, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "选择专题业务：";
            this.xtraTabControl2.Dock = DockStyle.Fill;
            this.xtraTabControl2.Location = new Point(0, 0xd5);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage4;
            this.xtraTabControl2.Size = new Size(0xe8, 0xb5);
            this.xtraTabControl2.TabIndex = 2;
            this.xtraTabControl2.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage4, this.xtraTabPage5 });
            this.xtraTabPage4.Controls.Add(this.dgv_total);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new Size(0xe2, 0x99);
            this.xtraTabPage4.Text = "总体信息";
            this.dgv_total.AllowUserToAddRows = false;
            this.dgv_total.AllowUserToDeleteRows = false;
            this.dgv_total.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_total.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_total.Dock = DockStyle.Fill;
            this.dgv_total.Location = new Point(0, 0);
            this.dgv_total.Name = "dgv_total";
            this.dgv_total.ReadOnly = true;
            this.dgv_total.RowHeadersWidth = 12;
            this.dgv_total.RowTemplate.Height = 0x17;
            this.dgv_total.Size = new Size(0xe2, 0x99);
            this.dgv_total.TabIndex = 0;
            this.xtraTabPage5.Controls.Add(this.dgv_xb);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new Size(0xe2, 0x99);
            this.xtraTabPage5.Text = "详细信息";
            this.dgv_xb.AllowUserToAddRows = false;
            this.dgv_xb.AllowUserToDeleteRows = false;
            this.dgv_xb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_xb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_xb.Dock = DockStyle.Fill;
            this.dgv_xb.Location = new Point(0, 0);
            this.dgv_xb.Name = "dgv_xb";
            this.dgv_xb.ReadOnly = true;
            this.dgv_xb.RowHeadersWidth = 12;
            this.dgv_xb.RowTemplate.Height = 0x17;
            this.dgv_xb.Size = new Size(0xe2, 0x99);
            this.dgv_xb.TabIndex = 0;
            this.dgv_xb.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgv_xb_CellMouseDoubleClick);
            this.dgv_xb.DataSourceChanged += new EventHandler(this.dgv_xb_DataSourceChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.xtraTabControl2);
            base.Controls.Add(this.xtraTabControl1);
            base.Name = "UCForestQuery";
            base.Size = new Size(0xe8, 0x18a);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.te_conty.Properties.EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabControl2.EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_total).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((ISupportInitialize) this.dgv_xb).EndInit();
            base.ResumeLayout(false);
        }

        private void InitType()
        {
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add(new DataColumn("类型"));
            table.Columns.Add(new DataColumn("字段"));
            row = table.NewRow();
            row["类型"] = "树种";
            row["字段"] = "YOU_SHI_SZ";
            table.Rows.Add(row);
            row = table.NewRow();
            row["类型"] = "地类";
            row["字段"] = "DI_LEI";
            table.Rows.Add(row);
            row = table.NewRow();
            row["类型"] = "森林类别";
            row["字段"] = "SEN_LIN_LB";
            table.Rows.Add(row);
            row = table.NewRow();
            row["类型"] = "林木起源";
            row["字段"] = "QI_YUAN";
            table.Rows.Add(row);
            row = table.NewRow();
            row["类型"] = "林地保护等级";
            row["字段"] = "BH_DJ";
            table.Rows.Add(row);
            row = table.NewRow();
            row["类型"] = "林地质量等级";
            row["字段"] = "ZL_DJ";
            table.Rows.Add(row);
            this.cb_type.DataSource = table;
            this.cb_type.DisplayMember = "类型";
            this.cb_type.ValueMember = "字段";
            this.cb_type.SelectedIndex = -1;
        }

        private void te_conty_Click(object sender, EventArgs e)
        {
            this.m_pcode = this.m_contyCode;
            this.cb_town.SelectedIndex = -1;
            this.cb_village.SelectedIndex = -1;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPage.Text.Equals("资源查询"))
            {
                if (this.cb_type.DataSource == null)
                {
                    this.InitType();
                }
                if (string.IsNullOrEmpty(this.te_conty.Text.Trim()))
                {
                    DataTable adminComboSource = this.m_clsDbHandler.GetAdminComboSource(this.m_pcode);
                    if ((adminComboSource != null) && (adminComboSource.Rows.Count > 0))
                    {
                        this.te_conty.Text = adminComboSource.Rows[0][1].ToString();
                        this.m_pcode = adminComboSource.Rows[0][0].ToString();
                        this.m_contyCode = this.m_pcode;
                    }
                }
                if (this.cb_town.DataSource == null)
                {
                    DataTable table2 = this.m_clsDbHandler.GetAdminComboSource(this.m_pcode);
                    if ((table2 != null) && (table2.Rows.Count > 0))
                    {
                        this.cb_town.DataSource = table2;
                        this.cb_town.DisplayMember = "CNAME";
                        this.cb_town.ValueMember = "CCODE";
                        this.cb_town.SelectedIndex = -1;
                    }
                }
            }
            else if (this.xtraTabControl1.SelectedTabPage.Text.Equals("业务查询") && (this.cb_business.DataSource == null))
            {
                this.InitBusiComboSource();
            }
        }

        public ClsDbHandler ClassDbHandler
        {
            get
            {
                return this.m_clsDbHandler;
            }
            set
            {
                if (value != null)
                {
                    this.m_clsDbHandler = value;
                }
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.m_connString;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_connString = value;
                    if (this.m_clsDbHandler == null)
                    {
                        this.m_clsDbHandler = new ClsDbHandler();
                    }
                    this.m_clsDbHandler.SqlConnectionString = this.m_connString;
                }
            }
        }

        public string UpdateYear
        {
            get
            {
                return this.m_updateYear;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_updateYear = value;
                    if (this.m_clsDbHandler == null)
                    {
                        this.m_clsDbHandler = new ClsDbHandler();
                    }
                    this.m_clsDbHandler.UpdateYear = this.m_updateYear;
                }
            }
        }

        public delegate void ClearLabelPoints(object sender, bool clear);

        public delegate void ClearSelectThemMap(object sender, string mapName);

        public delegate void FlashThemMap(object sender, string mapName, string issz);

        public delegate void FlyToXB(object sender, int oid, string tableName);

        public delegate void LabelPoints(object sender, LindQueryResult result);
    }
}

