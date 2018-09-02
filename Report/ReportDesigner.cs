using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class ReportDesigner : FormBase.FormBase3
    {
        public int reportId ;
        public SqlDataAdapter adapter;
        public DataTable dt;
        public int curId;

        public ReportDesigner(int reportId)
        {
            InitializeComponent();
            this.reportId = reportId;
            XtraMessageBox.Show(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString(), "");
            adapter = new SqlDataAdapter("select * from t_reportnode where report = " + reportId, new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString()));
            SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = scb.GetInsertCommand();
            adapter.UpdateCommand = scb.GetUpdateCommand();
            adapter.DeleteCommand = scb.GetDeleteCommand();
            dt = new DataTable();
            adapter.Fill(dt);
            treeList1.KeyFieldName = "id";
            treeList1.ParentFieldName = "pid";
            treeList1.DataSource = dt;
            initRespo();
            treeList1.ExpandAll();
        }
        public void initRespo() {
            DataTable xzDt = ReportCustom.getDTByName("t_sys_meta_code", "cdomain in ('SHI','XIAN','XIANG','CUN')");
            repositoryItemTreeListLookUpEdit1.DataSource= xzDt;
            List<CVRecord> typeList = new List<CVRecord>();
            typeList.AddRange(new CVRecord[] { new CVRecord("1", "1类区划节点"), new CVRecord("2", "2类区划节点"), new CVRecord("3", "分类节点"), new CVRecord("4", "父节点"), new CVRecord("5", "统计节点") });
            repositoryItemGridLookUpEdit1.DataSource=   typeList;
            DataTable codeDt = ReportCustom.getDTByName("t_sys_meta_codeindex");
            repositoryItemGridLookUpEdit2.DataSource = codeDt;
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { 
                TreeListHitInfo info = treeList1.CalcHitInfo(e.Location);
                if (info.Node == null)
                {
                    popupMenu1.ClearLinks();
                    popupMenu1.AddItem(barButtonItem1);

                }
                else {
                    curId = (int)info.Node.GetValue("id");
                    popupMenu1.ClearLinks();
                    popupMenu1.AddItems(new BarItem[]{barButtonItem1, barButtonItem2,barButtonItem3});
                }
                if(info.HitInfoType!=HitInfoType.Column)
                popupMenu1.ShowPopup(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow dr =  dt.NewRow();
            dr["report"] = reportId;
            dr["pid"] = 0;
            dt.Rows.Add(dr);
            adapter.Update(dt);
            dt.Clear();
            adapter.Fill(dt);
            treeList1.RefreshDataSource();
            treeList1.ExpandAll();

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["report"] = reportId;
            dr["pid"] = curId;
            dt.Rows.Add(dr);
            adapter.Update(dt);
            dt.Clear();
            adapter.Fill(dt);
            treeList1.RefreshDataSource();
            treeList1.ExpandAll();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (DataRow dr in dt.Rows) {
                if ((int)dr["id"] == curId)
                    dr.Delete();
            }
            adapter.Update(dt);
            dt.Clear();
            adapter.Fill(dt);
            treeList1.RefreshDataSource();
            treeList1.ExpandAll();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            adapter.Update(dt);
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try { adapter.Update(dt);
            XtraMessageBox.Show("保存成功", "提示");

            }
            catch {
                XtraMessageBox.Show("保存失败", "失败");
            }
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            treeList1.EndCurrentEdit();
        }





    }
}
