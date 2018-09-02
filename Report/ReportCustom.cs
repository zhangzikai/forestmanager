using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Report
{
    public partial class ReportCustom : FormBase.FormBase3
    {
        public GridView gv;
        public SqlDataAdapter adapter;
        public DataTable dt;
        public ReportCustom()
        {
            this.InitializeComponent();
            this.treeList1.KeyFieldName = "ID";
            this.treeList1.ParentFieldName = "PID";
            gv = (this.gridControl1.DefaultView) as GridView;
            //MessageBox.Show(this, Application.ExecutablePath + Application.StartupPath);
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gv.GetFocusedDataRow() == null) {
                XtraMessageBox.Show("请选择要设计的报表", "提示");
            }
            else {
                ReportDesigner rpDesigner = new ReportDesigner((int)gv.GetFocusedDataRow()["ID"]);
                rpDesigner.Show();
            }
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            if(gv.GetFocusedDataRow() == null){
                XtraMessageBox.Show("请选择要统计的报表", "提示");
                return;
            }
            ReportExporter rpExporter = new ReportExporter((int)gv.GetFocusedDataRow()["id"]);
            rpExporter.Show();
            rpExporter.Visible = false;
            rpExporter.stasticAndShow();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            FrmDetail frmDetail = new FrmDetail(dr);
            DialogResult result =  frmDetail.ShowDialog();
            if (result == DialogResult.OK)
            {
                dt.Rows.Add(dr);
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
                gridControl1.RefreshDataSource();
            }

        }

        private void ReportCustom_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = initAdapter("t_report");

        }


        public DataTable initAdapter(string tbName)
        {
            //XtraMessageBox.Show(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString(), "");
            SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString());
            dt = new DataTable();
            adapter = new SqlDataAdapter("select * from " + tbName, con);
            SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = scb.GetUpdateCommand();
            adapter.InsertCommand = scb.GetInsertCommand();
            adapter.DeleteCommand = scb.GetDeleteCommand();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable getDTByName(string tbName) {
          
            SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString());
            DataTable tmp = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from "+tbName,con);
            adapter.Fill(tmp);
            return tmp;
        }
        public static DataTable getDTByName(string tbName, string whereClause) {
            SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString());
            DataTable tmp = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from " + tbName+" where "+whereClause, con);
            adapter.Fill(tmp);
            return tmp;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gv.GetFocusedDataRow() == null)
                XtraMessageBox.Show("请先选择要删除的报表行", "提示");
            else {
                gv.GetFocusedDataRow().Delete();
                adapter.Update(dt);
                dt.Clear();
                adapter.Fill(dt);
                gridControl1.RefreshDataSource();

            }
                
                
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gv.GetFocusedDataRow() == null)
                XtraMessageBox.Show("请先选择要更新的报表行", "提示");
            else
            {
                DataRow dr = gv.GetFocusedDataRow();
                FrmDetail frmDetail = new FrmDetail(dr);
                DialogResult result = frmDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    adapter.Update(dt);
                    dt.Clear();
                    adapter.Fill(dt);
                    gridControl1.RefreshDataSource();
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            DataRow dr = gv.GetFocusedDataRow();
            treeList1.DataSource = getDTByName("t_reportnode", "report=" + dr["id"]);
            treeList1.ExpandAll();
        }






    }
}
