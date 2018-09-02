using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Report
{
    public partial class ReportExporter : FormBase.FormBase3
    {
        public DataTable nodeDt;
        public DataTable stasticDt;
        public DataTable tmpDt;
        public WaitFormx waitForm;
        public bool isSuccessful=false;
        public int reportId = 0;
        public int deep;
        public BandedGridView bandView;
        public BandedGridColumn bootColumn;
        public List<BandedGridColumn> groupColumn;
        public List<BandedGridColumn> sumColumn;
        public List<BandedGridColumn> aggeColumn;
        public int ACount;
        public int BCount;
        public int CCount;
        public int DCount;
        public string sumExpresstion;
        public Dictionary<string, Dictionary<string,string>> groupBook;
        public List<string> groupExpresstion;
        public string[] c;
        public string groupExpress;
        public string groupEx;
        public DataTable xzDt;
        public string[] xz;
        public List<List<string>> groupExpresstion1;
        public double[] shi;
        public double[] xian;
        public double[] xiang;
        public int endDeep = 3;
        public string tableName;
        public SqlConnection con;
        public SqlCommand com;
        public string[] d;
        public ReportExporter(int reportId)
        {
            InitializeComponent();
            this.reportId = reportId;
            bandView = ((BandedGridView)gridControl1.MainView);
            ACount = BCount = CCount = DCount = 0;
            groupColumn = new List<BandedGridColumn>();
            sumColumn = new List<BandedGridColumn>();
            aggeColumn = new List<BandedGridColumn>();
            sumExpresstion = "1";
            groupBook = new Dictionary<string,Dictionary<string,string>>();
            xz = new string[] { "shi", "xian", "xiang", "cun" };
            nodesInit();
            stasticPrepare();
        }

        private void stasticPrepare()
        {
            foreach (BandedGridColumn column in bandView.Columns)  
                columnProcess(column);
            foreach (BandedGridColumn column in aggeColumn)
                columnProcess1(column);
            int count = 1;
            foreach (BandedGridColumn column in sumColumn) {
                DataRow dr = (DataRow)column.Tag;
                sumExpresstion += ", sum(case when " + dr["expresstion"] + " then " + dr["sumcolumn"] + " else 0 end ) as C" + count;
                count++;
            }
            groupExpress = "";
            groupEx = "";
            count =1;
            DataRow dr1 = (DataRow)bootColumn.Tag;
            if (!"shixianxiangcun".Contains(((string)dr1["bootcolumn"]).ToLower()))
            {
                Dictionary<string, string> d1 = new Dictionary<string, string>();
                using (SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString()))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("select ccode,cname from t_sys_meta_code where cdomain='" + dr1["bootcolumn"] + "'", con);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            d1.Add(reader.GetString(0), reader.GetString(1));
                        }
                    }
                    reader.Close();
                }
                groupBook.Add((string)dr1["bootcolumn"], d1);
            }
            else {
                //Dictionary<string, string> d1 = new Dictionary<string, string>();
                //groupBook.Add("xzqh", d1);
                //xzDt = ReportCustom.getDTByName("t_sys_meta_code", "cdomain in ('SHI','XIAN','XIANG','CUN')");
            }
           foreach (BandedGridColumn column in groupColumn) {
               DataRow dr = (DataRow)column.Tag;
               Dictionary<string, string> d = new Dictionary<string, string>();
               using(SqlConnection con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString())){
                   con.Open();
                   SqlCommand com = new SqlCommand("select ccode,cname from t_sys_meta_code where cdomain='" + dr["groupcolumn"] + "'", con);
                   SqlDataReader reader = com.ExecuteReader();
                   if (reader.HasRows) {
                       while (reader.Read()) {
                           d.Add(reader.GetString(0), reader.GetString(1));
                       }
                   }
                   reader.Close();
               }
               groupBook.Add((string)dr["groupcolumn"], d);
               groupExpress += dr["groupcolumn"] + " as B" + count + ",";
               groupEx += "," +dr["groupcolumn"] ;
               count++;
           }
           if ((string)((DataRow)bootColumn.Tag)["type"] != "1") {
               List<Dictionary<string, string>> a = new List<Dictionary<string, string>>();
               foreach (string b in groupBook.Keys) {
                   a.Add(groupBook[b]);
               }
               c = new string[a.Count];
               d = new string[a.Count];
               groupExpresstion = new List<string>();
               groupExpresstion1 = new List<List<string>>();
               groupExPresstionBuilder(a, 0);

           }
        }


        public void groupExPresstionBuilder(List<Dictionary<string,string>> e,int deep ) {
            Dictionary<string, string> f = e[deep];
            int count = 0;
            string cc = "";
            foreach (string b in groupBook.Keys)
            {
                if (count == deep)
                    cc = b;
                count++;
            }
            foreach (string n in f.Keys) {
                c[deep] = cc+ "='" + n + "'";
                d[deep] = f[n];
                if (deep == e.Count-1)
                {
                    List<string> a = new List<string>();
                    foreach (string b in c) {
                        a.Add(b);
                    }
                    List<string> ee = new List<string>();
                    foreach (string cd in d) {
                        ee.Add(cd);
                    }
                    groupExpresstion1.Add(ee);
                    groupExpresstion.Add(String.Join(" and ", c));
                }
                else {
                    groupExPresstionBuilder(e, deep + 1);
                }
            }
        }
        public void nodesInit() {
            nodeDt = ReportCustom.getDTByName("t_reportnode", "report=" + reportId);
            List<DataRow> rootNodes=new List<DataRow>();;
           
            foreach (DataRow dr in nodeDt.Rows) {
                if ((int)dr["pid"] == 0)
                    rootNodes.Add(dr);
            }
            if(rootNodes.Count==0)
                return;
            deep=1;
            foreach(DataRow dr in rootNodes)
                nodeVisitor(dr,1);
            if(deep==1){
                GridBand band = new GridBand();
                band.Caption = "自定义统计表";
                bandView.Bands.Add(band);
            foreach(DataRow dr in rootNodes){
                BandedGridColumn column = new BandedGridColumn();
                    column.Caption = (string)dr["name"];
                    column.Tag = dr;
                    //bandView.Columns.Add(column);
                    column.Visible=true;
                    band.Columns.Add(column);

                }

            }
             else{
                foreach(DataRow dr in rootNodes){
                    GridBand band = new GridBand();
                    band.Caption= (string)dr["name"];
                    band.Tag=dr;
                    bandView.Bands.Add(band);
                    createStruct(band, 1);
                    
                }
             }
            
               
            
        }
        public void nodeVisitor(DataRow dr,int curDeep){
            List<DataRow> li = getChildren(nodeDt,dr);
            if(li.Count!=0){
                if(curDeep==deep)
                    deep++;
                curDeep++;
                foreach(DataRow dr1 in li)
                    nodeVisitor(dr1,curDeep);
                }           
        }


        public void createStruct(GridBand band,int curDeep) { 
            List<DataRow> li = getChildren(nodeDt,(DataRow)band.Tag);
            if (li.Count != 0) { 
                    var hasSum = ((DataRow)band.Tag)["hassum"];
                    if (hasSum != DBNull.Value && (short)hasSum == 1) {
                        if (curDeep + 1 == deep)
                        {
                            BandedGridColumn column = new BandedGridColumn();
                            column.Caption = "总计";
                            column.Visible = true;
                            band.Columns.Add(column);
                            aggeColumn.Add(column);
                        }
                        else {
                            GridBand band1 = new GridBand();
                            band1.Caption = "总计";
                            band.Children.Add(band1);
                            BandedGridColumn column = new BandedGridColumn();
                            column.Caption = "总计";
                            column.Visible = true;
                            band1.Columns.Add(column);
                            aggeColumn.Add(column);
                        }

                    }
            }
            foreach (DataRow dr in li) {
                if (curDeep + 1 == deep)
                {
                    BandedGridColumn column = new BandedGridColumn();
                    column.Caption = (string)dr["name"];
                    column.Tag = dr;
                    column.Visible = true;
                    band.Columns.Add(column);
                }
                else {
                    GridBand band1 = new GridBand();
                    band1.Caption = (string)dr["name"];
                    band1.Tag = dr;
                    band.Children.Add(band1);
                    if (getChildren(nodeDt, dr).Count == 0)
                    {
                        BandedGridColumn column = new BandedGridColumn();
                        column.Caption = (string)dr["name"];
                        column.Tag = dr;
                        column.Visible = true;
                        band1.Columns.Add(column);
                    }
                    else {
                        curDeep++;
                        createStruct(band1, curDeep);
                        curDeep--;
                    }

                }
            }
        }
        public List<DataRow> getChildren(DataTable dt ,DataRow dr) { 
            List<DataRow>  li = new List<DataRow>();
            foreach(DataRow drTMP in dt.Rows){
            if((int)drTMP["pid"]==(int)dr["id"])
                li.Add(drTMP);
            }
            return li;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Title = "请选择保存路径";
            a.Filter = "Excel文件(*.xlsx)|*.xlsx";
            a.RestoreDirectory = true;
            if (a.ShowDialog() == DialogResult.OK) {
                try {
                    gridControl1.ExportToXlsx(a.FileName);
                    XtraMessageBox.Show("保存成功", "提示");
                }
                catch(Exception ee){
                    XtraMessageBox.Show("保存失败，请先关闭已打开的excel文件", "提示");
                }
            }

        }
        public void stasticAndShow(){
            waitForm = new WaitFormx();
            Thread ct= new Thread(new ThreadStart(stastic));
            ct.Start();
            if (waitForm.ShowDialog() == DialogResult.Cancel&&!isSuccessful) {
                Debug.WriteLine("continue");
                if (ct != null) {
                    ct.Abort(); ;
                }
                this.Close();
            }
            isSuccessful = false;

        }
        public void xzVisitor(DataRow dr,int deep) {
            string xzName = xz[deep];
            string xzCode = (string)dr["ccode"];
            string xzValue = (string)dr["cname"];
            double[] sum=null;
            double[] cur=null;
            if (deep == 3) {
                sum = xiang; 
            }
            else if (deep == 2) {
                sum = xian;
                cur = xiang;
            }
            else if (deep == 1) {
                sum = shi;
                cur = xian;
            }
            else if (deep == 0) {
                sum = shi;
                cur = shi;
            }
            if (deep == endDeep)
            {
                //SqlParameter a = new SqlParameter("@A1", xzValue);
                //com.Parameters.Add(a);
                //SqlParameter d = new SqlParameter("@xz", xzName);
                //com.Parameters.Add(d);
                int count = 0;
                int begin = groupColumn.Count + 1;
                foreach (string b in groupExpresstion)
                {
                    DataRow dr0 = stasticDt.NewRow();
                    List<string> bC = groupExpresstion1[count];
                    //SqlParameter c = new SqlParameter("@E", b);
                    //com.Parameters.Add(c);
                    dr0["A1"] = xzValue;
                    for(int i=0;i<bC.Count;i++) {
                        dr0["B" + (i + 1)] = bC[i];
                        //SqlParameter d2 = new SqlParameter("@B" + (i + 1), bC[i]);
                        //com.Parameters.Add(d2);
                    }
                    string newSelect = "select "+sumExpresstion + " from " + tableName + " where " +xzName+"='" + xzCode+"' and "+b;
                    com.CommandText = newSelect;
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        double num=0;
                        for (int i = 0; i < sumColumn.Count; i++)
                        {
                            if (reader.GetValue(i + 1) != DBNull.Value)
                            {
                                num = Convert.ToDouble(reader.GetValue(i+1));
                            }
                            sum[count*sumColumn.Count+i]+= num;
                            dr0["C"+(i+1)] = num;
                        }
                        stasticDt.Rows.Add(dr0);
                    }
                    reader.Close();
                    count++;
                }
            }
            else {
                List<DataRow> li = new List<DataRow>();
                foreach (List<string> b in groupExpresstion1)
                {
                    DataRow dr2 = stasticDt.NewRow();
                    dr2["A1"] = xzValue;
                    int count = 1;
                    foreach (string c in b) {
                        dr2["B" + count] = c;
                        count++;
                    }
                    stasticDt.Rows.Add(dr2);
                    li.Add(dr2);
                }
                foreach (DataRow dr1 in ReportCustom.getDTByName("t_sys_meta_code", "pcode='" + xzCode+"'").Rows) {
                    xzVisitor(dr1, deep + 1);
                }
                int count1 = 0;
                foreach (DataRow dr3 in li)
                {
                    for (int i = 0; i < sumColumn.Count; i++) {
                        dr3["C" + (i + 1)] = cur[count1 * sumColumn.Count + i];
                        sum[count1 * sumColumn.Count + i] += cur[count1 * sumColumn.Count + i];
                    }
                    Array.Clear(cur,0,cur.Length);
                    count1++;
                }
            }
        }

        public void stastic() {
            //Thread.Sleep(3000);
            tableName = "for_xiaoban_2016";
            if ((string)((DataRow)bootColumn.Tag)["type"] != "1")
            {   
                string bootColumnName  = (string)((DataRow)bootColumn.Tag)["bootcolumn"];
                int curDeep = 0;
                int count = 0;
                foreach(string tmp in xz){
                    if (tmp.ToLower() == bootColumnName) {
                        curDeep = count;
                    }
                    count++;
                }
                endDeep = (short)((DataRow)bootColumn.Tag)["deep"] + curDeep;
                if (endDeep > 3)
                    return;
                stasticDt = new DataTable();
                DataColumn a = new DataColumn();
                a.ColumnName="A1";
                a.DataType=typeof(string);
                stasticDt.Columns.Add(a);
                string groupSelect=""; 
                for(int i =1;i<groupColumn.Count+1;i++ ){
                    groupSelect+= ","+"@B"+i+" as B"+i;
                    a = new DataColumn();
                    a.ColumnName = "B" + i;
                    a.DataType = typeof(string);
                    stasticDt.Columns.Add(a);
                }
                for (int i = 1; i < sumColumn.Count + 1; i++) {
                    a = new DataColumn();
                    a.ColumnName = "C" + i;
                    a.DataType = typeof(double);
                    stasticDt.Columns.Add(a);
                }
                con = new SqlConnection(ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString());
                con.Open();
                com = new SqlCommand("select @A1 as A1"+groupSelect+sumExpresstion +" from "+tableName+" where @xz="+"@A1 and @E",con);
                shi = new double[sumColumn.Count * groupExpresstion.Count];
                xian = new double[sumColumn.Count * groupExpresstion.Count];
                xiang = new double[sumColumn.Count * groupExpresstion.Count];
                DataRow root = ReportCustom.getDTByName("t_sys_meta_code","ccode='"+(string)((DataRow)bootColumn.Tag)["bootvalue"]+"'").Rows[0];
                xzVisitor(root, curDeep);
                con.Close();
                gridControl1.Invoke((Action)(() => { gridControl1.DataSource = stasticDt; }));
            }
            else {
                SqlDataAdapter adapter = new SqlDataAdapter("select " + ((DataRow)bootColumn.Tag)["bootcolumn"] + " as A1," + groupExpress +  sumExpresstion + " from " + tableName + " group by " + ((DataRow)bootColumn.Tag)["bootcolumn"]+groupEx, ConSQLServerInfo.ConnectionSQLServerString.Get_M_Str_ConnectionString());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridControl1.Invoke((Action)(()=>{ gridControl1.DataSource=dt;}));
            }
            if (waitForm != null) {
                if(waitForm.IsHandleCreated)
                waitForm.Invoke(new Action(() => {
                    isSuccessful = true;
                    waitForm.Close();
                }));
                this.Invoke(new Action(() => {
                    this.Visible=true;
                }));
                Debug.WriteLine("threadStop");
            }         
        }
        public void columnProcess(BandedGridColumn column) {
            DataRow dr = (DataRow)column.Tag;
            if(dr!=null)
            switch ((string)dr["type"]) { 
                case "1":
                case "2":
                    bootColumn = column;
                    column.FieldName = nameGenerator("1");
                    break;
                case "3":
                    groupColumn.Add(column);
                    column.FieldName = nameGenerator("2");
                    break;
                case "5":
                    sumColumn.Add(column);
                    column.FieldName = nameGenerator("3");
                    break;
            }
        }
        public void columnProcess1(BandedGridColumn column) {
            GridBand band =null;
            if (column.OwnerBand.Columns.Count != 1)
                band = column.OwnerBand;
            else
                band = column.OwnerBand.ParentBand;
            StringBuilder sb = new StringBuilder();
            sb.Append("0");
            expresstionBuilder(band,sb);
            column.FieldName = nameGenerator("4");
            column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.UnboundExpression = sb.ToString();
        }
        public void expresstionBuilder(GridBand band, StringBuilder sb)
        {
            var columns = band.Columns;
            var bands = band.Children;
            if (columns.Count != 0)
            {
                foreach (BandedGridColumn ct in columns)
                {
                    if(!String.IsNullOrEmpty(ct.FieldName)&&ct.FieldName.StartsWith("C"))
                    sb.Append("+[" + ct.FieldName + "]");
                }
            }
            else
            {
                foreach (GridBand cb in bands) {
                    expresstionBuilder(cb, sb);
                }
            }
        }
        public String nameGenerator(string type) { 
        switch(type){
            case "1":
                ACount++;
                return "A" + ACount;
            case "2":
                BCount++;
                return "B" + BCount;
            case "3":
                CCount++;
                return "C" + CCount;
            case "4":
                DCount++;
                return "D" + DCount;
        }
        return "E" + ACount + BCount + CCount + DCount;
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string fieldName = e.Column.FieldName;
            DataRow dr = ((DataRow)e.Column.Tag);
            if (e.Value == DBNull.Value || (string)((DataRow)bootColumn.Tag)["type"] == "2" || fieldName.StartsWith("C") || fieldName.StartsWith("D"))
            {
                Debug.WriteLine("pass");
                return;
            }
            if (fieldName.StartsWith("A"))
            {
                string text = null;
                try
                {
                     text = groupBook[(string)dr["bootcolumn"]][(string)e.Value];
                }
                catch (Exception)
                {

                     text = "";
                }
                if (String.IsNullOrEmpty(text))
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = text;
                }
            }
            else
            {
                string text = null;
                try
                {
                    text = groupBook[(string)dr["groupcolumn"]][(string)e.Value];
                }
                catch (Exception)
                {
                    
                   text = "";
                }
                if (String.IsNullOrEmpty(text))
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = text;
                }
            }
            Debug.WriteLine(e.DisplayText);
        }

    }
}

