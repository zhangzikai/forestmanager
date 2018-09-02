namespace LDZY_ZTZL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;
    using td.db.gis;
    using td.db.mid.sys;
    using td.db.orm;
    using td.forest.zl.tj;
    using td.logic.sys;
    using td.logic.forest;
    using Microsoft.Office.Interop.Excel;

    /// <summary>
    /// 造林统计表窗体
    /// </summary>
    public class dlgTJMain : Form
    {
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReverseSel;
        private System.Windows.Forms.Button buttonSelAll;
        private System.Windows.Forms.Button buttonSelNone;
        private System.Windows.Forms.Button buttonTJ;
        private System.Windows.Forms.CheckBox checkBoxB1SCQK1;
        private System.Windows.Forms.CheckBox checkBoxB2SCQK2;
        private System.Windows.Forms.CheckBox checkBoxB3SCQK3;
        private System.Windows.Forms.CheckBox checkBoxB4SCQK4;
        private System.Windows.Forms.CheckBox checkBoxB5HSZL;
        private System.Windows.Forms.CheckBox checkBoxB6NDHZ;
        private System.Windows.Forms.CheckBox checkBoxGCJDB;
        private ComboBox comboSelXZHName;
        private IContainer components = null;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private ClassTongJiZL pClassTongJi = new ClassTongJiZL();
        private string pzltable;
        private RadioButton rdobtnTJXianToXiang;
        private RadioButton rdobtnXiangCun;
        private RadioButton rdobtnXianXiangCun;
        private string xianname = "";
        private string ZLTABLE = "";
        public FindMidFromLayer<Forst_ZL_Mid> FindFromLayer { get; set; }
        /// <summary>
        /// 造林统计表窗体：构造器
        /// </summary>
        public dlgTJMain()
        {
            this.InitializeComponent();
        }
        protected MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonReverseSel_Click(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                    box = control as System.Windows.Forms.CheckBox;
                    box.Checked = !box.Checked;
                }
            }
        }

        private void buttonSelAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                    box = control as System.Windows.Forms.CheckBox;
                    if (box.CheckState == CheckState.Unchecked)
                    {
                        box.Checked = true;
                    }
                }
            }
        }

        private void buttonSelNone_Click(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                    box = control as System.Windows.Forms.CheckBox;
                    if (box.CheckState == CheckState.Checked)
                    {
                        box.Checked = false;
                    }
                }
            }
        }
        /// <summary>
        /// 判断选择了几个报表
        /// </summary>
        /// <returns></returns>
        private bool IfSelectOne()
        {
            
                int num = 0;
           
                foreach (Control control in base.Controls)
                {
                    if (control is System.Windows.Forms.CheckBox)
                    {
                        System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                        box = control as System.Windows.Forms.CheckBox;
                        if (box.CheckState == CheckState.Checked)
                        {
                            num++;
                            //if (box.Name != "checkBoxGCJDB")
                            //{
                            //    flag = true;
                            //}
                        }
                    }
                }
                if (num == 0)
                {
                    MessageBox.Show("请选择要统计的表！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                return true;
        }

        /// <summary>
        /// 点击确定的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTJ_Click(object sender, EventArgs e)
        {
            
            string gxnd = "";
            DateTime time = dateTimePickerStart.Value; //Convert.ToDateTime(this.dateTimePickerStart.Value.ToString("yyyy-MM"));
            DateTime time2 = dateTimePickerEnd.Value.AddMonths(1);// Convert.ToDateTime(this.dateTimePickerEnd.Value.ToString("yyyy-MM"));

            if (time > time2)
            {
                MessageBox.Show("请选择正确的起止年月！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (!IfSelectOne()) return;

            int count;
            int num3;
            int num4;
            int num5;
            System.Data.DataTable table2;
            System.Data.DataTable table3;
            System.Data.DataTable table4;
            SaveFileDialog dialog;
            Exception exception;
            Microsoft.Office.Interop.Excel.Application application;
            object obj3;
            Workbook workbook;
            Worksheet worksheet;
            int num7;
            Exception exception2;
            Process process;
            IntPtr mainWindowHandle;
            System.Data.DataTable table = null;
            object[,] objArray = null;
            object[,] objArray2 = null;
            object[,] objArray3 = null;
            object[,] objArray4 = null;
            object[,] objArray5 = null;
            object[,] objArray6 = null;
            DataSet set = new DataSet("fhlds");
            string str2 = "";
            if (time == time2)
            {
                gxnd = "='" + time.ToString("yyyyMM") + "'";
                str2 = string.Concat(new object[] { time.Year.ToString(), "年", time.Month, "月" });
            }
            else
            {
                gxnd = ">='" + time.ToString("yyyyMM") + "' AND LEFT(GXSJ,6)<='" + time2.ToString("yyyyMM") + "'";
                if (time.Year == time2.Year)
                {
                    str2 = string.Concat(new object[] { time.Year.ToString(), "年", time.Month, "月 至 ", time2.Month, "月" });
                }
                else
                {
                    str2 = string.Concat(new object[] { time.Year.ToString(), "年", time.Month, "月 至 ", time2.Year.ToString(), "年", time2.Month, "月" });
                }
            }
            string subField = "SHI,XIAN,XIANG,CUN,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB,G_CHENG_LB,ZJLY,GXSJ";
            string wheresql = "GXSJ>='" + time.ToString("yyyyMM") + "00" + "' and GXSJ<='" + time2.ToString("yyyyMM") + "00" + "'";
            List<Forst_ZL_Mid> data = this.FindFromLayer.Find(subField, wheresql, "Order By Cun");
            string path = "";
            string fileName = "";
            if (this.rdobtnTJXianToXiang.Checked)
            {
                path = "营造林统计表市县_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                //path = "营造林统计表县乡_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                if (this.checkBoxB1SCQK1.Checked)
                {
                    ShengChanQK1 scqk1 = new ShengChanQK1();
                    table = scqk1.ComputeXianXiang(data);
                    objArray = scqk1.Compute2ObjAry(table);
                }
                if (this.checkBoxB2SCQK2.Checked)
                {
                    ShengChanQK2 scqk2 = new ShengChanQK2();
                    table = scqk2.ComputeXianXiang(data);
                    objArray2 = scqk2.Compute2ObjAry(table);
                }
                if (this.checkBoxB3SCQK3.Checked)
                {
                    ShengChanQK3 scqk3 = new ShengChanQK3();
                    table = scqk3.ComputeXianXiang(data);
                    objArray3 = scqk3.Compute2ObjAry(table);
                }
                if (this.checkBoxB4SCQK4.Checked)
                {
                    ShengChanQK4 scqk4 = new ShengChanQK4();
                    table = scqk4.ComputeXianXiang(data);
                    objArray4 = scqk4.Compute2ObjAry(table);
                }
                if (this.checkBoxB5HSZL.Checked)
                {
                    HSZL hszl = new HSZL();
                    table = hszl.ComputeXianXiang(data);
                    objArray5 = hszl.Compute2ObjAry(table);

                }
                if (this.checkBoxB6NDHZ.Checked)
                {
                    TJB6 tjb6 = new TJB6();
                    table = tjb6.ComputeXianXiang(data);
                    objArray6 = tjb6.Compute2ObjAry(table);
                }

                ////if (this.checkBoxGCJDB.Checked)
                ////{
                ////    fileName = "防护林进度表县乡_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                ////    table2 = this.pClassTongJi.TJZFLJDByXianXiang(gxnd);
                ////    table2.TableName = "zfl";
                ////    set.Tables.Add(table2);
                ////    table3 = this.pClassTongJi.TJHFLJDByXianXiang(gxnd);
                ////    table3.TableName = "hfl";
                ////    set.Tables.Add(table3);
                ////    table4 = this.pClassTongJi.TJSMHJDByXianXiang(gxnd);
                ////    table4.TableName = "smh";
                ////    set.Tables.Add(table4);
                ////}
            }
            if (this.rdobtnXianXiangCun.Checked)
            {
                path = "营造林统计表市县乡_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                //path = "营造林统计表县乡村_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";

                if (this.checkBoxB1SCQK1.Checked)
                {
                    ShengChanQK1 scqk1 = new ShengChanQK1();
                    table = scqk1.ComputeXianXiangCun(data);
                    objArray = scqk1.Compute2ObjAry(table);
                }
                if (this.checkBoxB2SCQK2.Checked)
                {
                    ShengChanQK2 scqk2 = new ShengChanQK2();
                    table = scqk2.ComputeXianXiangCun(data);
                    objArray2 = scqk2.Compute2ObjAry(table);
                }
                if (this.checkBoxB3SCQK3.Checked)
                {
                    ShengChanQK3 etl = new ShengChanQK3();
                    table = etl.ComputeXianXiangCun(data);
                    objArray3 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB4SCQK4.Checked)
                {
                    ShengChanQK4 etl = new ShengChanQK4();
                    table = etl.ComputeXianXiangCun(data);
                    objArray4 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB5HSZL.Checked)
                {
                    HSZL etl = new HSZL();
                    table = etl.ComputeXianXiangCun(data);
                    objArray5 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB6NDHZ.Checked)
                {
                    TJB6 etl = new TJB6();
                    table = etl.ComputeXianXiangCun(data);
                    objArray6 = etl.Compute2ObjAry(table);
                }

                if (this.checkBoxGCJDB.Checked)
                {
                    fileName = "防护林进度表市县乡_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                    //fileName = "防护林进度表县乡村_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                    table2 = this.pClassTongJi.TJZFLJDByXianXiangCun(gxnd);
                    table2.TableName = "zfl";
                    set.Tables.Add(table2);
                    table3 = this.pClassTongJi.TJHFLJDByXianXiangCun(gxnd);
                    table3.TableName = "hfl";
                    set.Tables.Add(table3);
                    table4 = this.pClassTongJi.TJSMHJDByXianXiangCun(gxnd);
                    table4.TableName = "smh";
                    set.Tables.Add(table4);
                }
            }
            if (this.rdobtnXiangCun.Checked && (this.comboSelXZHName.SelectedItem != null))
            {
                object selectedItem = this.comboSelXZHName.SelectedItem;
                if (selectedItem == null)
                {
                    this.comboSelXZHName.Focus();
                    MessageBox.Show("无效的县级名称，请从列表中选择！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                T_SYS_META_CODE_Mid view = selectedItem as T_SYS_META_CODE_Mid;

                path = "营造林统计表" + view.CNAME + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";

                if (this.checkBoxB1SCQK1.Checked)
                {
                    ShengChanQK1 scqk1 = new ShengChanQK1();
                    table = scqk1.ComputeXiangCun(data, view.CCODE);
                    objArray = scqk1.Compute2ObjAry(table);
                }
                if (this.checkBoxB2SCQK2.Checked)
                {
                    ShengChanQK2 etl = new ShengChanQK2();
                    table = etl.ComputeXiangCun(data, view.CCODE);
                    objArray2 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB3SCQK3.Checked)
                {
                    ShengChanQK3 etl = new ShengChanQK3();
                    table = etl.ComputeXiangCun(data, view.CCODE);
                    objArray3 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB4SCQK4.Checked)
                {
                    ShengChanQK4 etl = new ShengChanQK4();
                    table = etl.ComputeXiangCun(data, view.CCODE);
                    objArray4 = etl.Compute2ObjAry(table);

                }
                if (this.checkBoxB5HSZL.Checked)
                {
                    HSZL etl = new HSZL();
                    table = etl.ComputeXiangCun(data, view.CCODE);
                    objArray5 = etl.Compute2ObjAry(table);
                }
                if (this.checkBoxB6NDHZ.Checked)
                {
                    TJB6 etl = new TJB6();
                    table = etl.ComputeXiangCun(data, view.CCODE);
                    objArray6 = etl.Compute2ObjAry(table);
                }

                if (this.checkBoxGCJDB.Checked)
                {
                    fileName = "防护林进度表" + view.CNAME.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                    table2 = this.pClassTongJi.TJZFLJDByXiangCun(gxnd, view.CCODE);
                    table2.TableName = "zfl";
                    set.Tables.Add(table2);
                    table3 = this.pClassTongJi.TJHFLJDByXiangCun(gxnd, view.CCODE);
                    table3.TableName = "hfl";
                    set.Tables.Add(table3);
                    table4 = this.pClassTongJi.TJSMHJDByXiangCun(gxnd, view.CCODE);
                    table4.TableName = "smh";
                    set.Tables.Add(table4);
                }
            }
            string str6 = "";
            string str7 = "统计日期：" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";

            string sourceFileName = System.Windows.Forms.Application.StartupPath + @"\营造林统计表.xls";
            dialog = new SaveFileDialog();
            dialog.Title = "保存营造林统计表";
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel电子表(*.xls)|*.xls";
            dialog.FileName = path;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            path = dialog.FileName;
            str6 = Path.GetDirectoryName(path) + @"\";
            try
            {
                File.Copy(sourceFileName, path, true);
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageBox.Show("复制统计表模板文件出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            application = new ApplicationClass();
            try
            {
                if (application == null)
                {
                    MessageBox.Show("不能建立EXCEL对象，请在机器上安装Office。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                workbook = application.Workbooks.Open(path);
                Sheets sheets = workbook.Sheets;
                for (int i = 1; i < (application.Sheets.Count + 1); i++)
                {
                    worksheet = application.Sheets[i] as Worksheet;
                    if (worksheet.Visible == XlSheetVisibility.xlSheetHidden)
                    {
                        worksheet.Visible = XlSheetVisibility.xlSheetVisible;
                    }
                }
                if (this.checkBoxB1SCQK1.Checked)
                {
                    worksheet = application.Sheets[1] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray != null)
                    {
                        worksheet.get_Range("B2", "B2").Value2 = this.xianname + "林业局";
                        worksheet.get_Range("H2", "H2").Value2 = "更新年月：" + str2;
                        worksheet.get_Range("Y2", "Y2").Value2 = str7;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, 0x1f]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1f]).Value2 = objArray;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1f]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1f]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1f]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                if (this.checkBoxB2SCQK2.Checked)
                {
                    worksheet = application.Sheets[2] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray2 != null)
                    {
                        worksheet.get_Range("B2", "B2").Value2 = this.xianname + "林业局";
                        worksheet.get_Range("H2", "H2").Value2 = "更新年月：" + str2;
                        worksheet.get_Range("AB2", "AB2").Value2 = str7;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, 0x21]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray2.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x21]).Value2 = objArray2;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x21]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x21]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x21]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                if (this.checkBoxB3SCQK3.Checked)
                {
                    worksheet = application.Sheets[3] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray3 != null)
                    {
                        worksheet.get_Range("B2", "B2").Value2 = this.xianname + "林业局";
                        worksheet.get_Range("H2", "H2").Value2 = "更新年月：" + str2;
                        worksheet.get_Range("W2", "W2").Value2 = str7;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, 0x1c]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray3.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1c]).Value2 = objArray3;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1c]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1c]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x1c]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                if (this.checkBoxB4SCQK4.Checked)
                {
                    worksheet = application.Sheets[4] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray4 != null)
                    {
                        worksheet.get_Range("B2", "B2").Value2 = "编制单位：" + this.xianname + "林业局";
                        worksheet.get_Range("H2", "H2").Value2 = "更新年月：" + str2;
                        worksheet.get_Range("P2", "P2").Value2 = str7;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, 0x13]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray4.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x13]).Value2 = objArray4;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x13]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x13]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[count + 7, 0x13]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                if (this.checkBoxB5HSZL.Checked)
                {
                    worksheet = application.Sheets[5] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray5 != null)
                    {
                        worksheet.get_Range("A2", "A2").Value2 = "编制单位：" + this.xianname + "林业局";
                        worksheet.get_Range("F2", "F2").Value2 = "更新年月：" + str2;
                        worksheet.get_Range("Q2", "Q2").Value2 = str7;
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num7 + 5, 0x19]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray5.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, 0x19]).Value2 = objArray5;
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, 0x19]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, 0x19]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, 0x19]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                if (this.checkBoxB6NDHZ.Checked)
                {
                    worksheet = application.Sheets[6] as Worksheet;
                    num7 = worksheet.UsedRange.Rows.Count;
                    if (objArray6 != null)
                    {
                        worksheet.get_Range("A1", "A1").Value2 = str2 + " 汇总表";
                        worksheet.get_Range("A2", "B2").MergeCells = true;
                        worksheet.get_Range("A2", "A2").Value2 = "编制单位：" + this.xianname + "林业局";
                        worksheet.get_Range("A3", "A3").Value2 = "统计单位";
                        worksheet.get_Range("I2", "I2").Value2 = str7;
                        num3 = Convert.ToInt32(objArray6.GetLongLength(1));
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num7 + 5, num3]).EntireRow.Delete();
                        count = Convert.ToInt32(objArray6.GetLongLength(0));
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, num3]).Value2 = objArray6;
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, num3]).Font.Name = "Arial";
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, num3]).Font.Size = 10;
                        worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[count + 5, num3]).Borders.LineStyle = 1;
                        worksheet.Select();
                        worksheet.get_Range("A1", "A1").Select();
                        application.ActiveWindow.DisplayZeros = false;
                    }
                }
                workbook.Save();
                MessageBox.Show("营造林统计表统计完成，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                application.Visible = true;
                worksheet = null;
            }
            catch (Exception exception3)
            {
                exception2 = exception3;
                MessageBox.Show("填充电子表出错，错误：" + exception2.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            finally
            {
                process = new Process();
                Process[] processesByName = Process.GetProcessesByName("EXCEL");
                try
                {
                    foreach (Process process2 in processesByName)
                    {
                        mainWindowHandle = process2.MainWindowHandle;
                        if (string.IsNullOrEmpty(process2.MainWindowTitle))
                        {
                            process2.Kill();
                        }
                    }
                }
                catch (Exception exception4)
                {
                    exception2 = exception4;
                    exception2.ToString();
                }
                GC.Collect();
            }

            if (this.checkBoxGCJDB.Checked)
            {
                string str10 = System.Windows.Forms.Application.StartupPath + @"\珠防海防石漠化进度表.xls";
                string destFileName = "";
                if (str6.Trim().Length == 0)
                {
                    dialog = new SaveFileDialog();
                    dialog.Title = "保存防护林进度表";
                    dialog.DefaultExt = ".xls";
                    dialog.Filter = "Excel电子表(*.xls)|*.xls";
                    dialog.FileName = fileName;
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    fileName = dialog.FileName;
                    str6 = Path.GetDirectoryName(fileName) + @"\";
                    destFileName = fileName;
                }
                else
                {
                    destFileName = str6 + fileName;
                }
                try
                {
                    File.Copy(str10, destFileName, true);
                }
                catch (Exception exception5)
                {
                    exception = exception5;
                    MessageBox.Show("复制防护林进度表模板文件出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    obj3 = Missing.Value;
                    string filename = destFileName;
                    workbook = application.Workbooks.Open(filename, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3);
                    application.Visible = false;
                    application.DisplayAlerts = false;
                    application.ActiveWindow.DisplayZeros = false;
                    worksheet = null;
                    for (int j = 0; j < set.Tables.Count; j++)
                    {
                        System.Data.DataTable table5 = set.Tables[j];
                        string tableName = table5.TableName;
                        count = table5.Rows.Count;
                        num3 = table5.Columns.Count;
                        object[,] objArray7 = new object[count, num3];
                        object[] objArray8 = new object[table5.Columns.Count];
                        for (int k = 0; k < table5.Columns.Count; k++)
                        {
                            objArray8[k] = table5.Columns[k].ToString();
                        }
                        for (num4 = 0; num4 < count; num4++)
                        {
                            for (num5 = 0; num5 < num3; num5++)
                            {
                                objArray7[num4, num5] = table5.Rows[num4][num5];
                            }
                        }
                        if ((objArray7 != null) && (objArray7.GetLength(0) > 0))
                        {
                            int num10;
                            int num11;
                            int num12;
                            if (tableName.Trim().ToUpper() == "zfl")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                num7 = worksheet.UsedRange.Rows.Count;
                                num10 = 7;
                                num11 = (count + num10) - 1;
                                num12 = (num7 + num10) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = this.xianname + "林业局";
                                worksheet.get_Range("G2", "G2").Value2 = "更新年月：" + str2;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num12, num3]).EntireRow.Delete(obj3);
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Value2 = objArray7;
                                worksheet.get_Range(worksheet.Cells[num11 + 1, num3 - 4], worksheet.Cells[num11 + 1, num3 - 4]).Value2 = str7;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Name = "Arial Narrow";
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11 + 1, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Borders.LineStyle = 1;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).RowHeight = 0x12;
                                worksheet.Select(obj3);
                                worksheet.get_Range("A1", "A1").Select();
                                application.ActiveWindow.DisplayZeros = false;
                            }
                            else if (tableName.Trim().ToUpper() == "hfl")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                num7 = worksheet.UsedRange.Rows.Count;
                                num10 = 7;
                                num11 = (count + num10) - 1;
                                num12 = (num7 + num10) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = this.xianname + "林业局";
                                worksheet.get_Range("G2", "G2").Value2 = "更新年月：" + str2;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num12, num3]).EntireRow.Delete(obj3);
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Value2 = objArray7;
                                worksheet.get_Range(worksheet.Cells[num11 + 1, num3 - 4], worksheet.Cells[num11 + 1, num3 - 4]).Value2 = str7;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Name = "Arial Narrow";
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Borders.LineStyle = 1;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).RowHeight = 0x12;
                                worksheet.Select(obj3);
                                worksheet.get_Range("A1", "A1").Select();
                                application.ActiveWindow.DisplayZeros = false;
                            }
                            else if (tableName.Trim().ToUpper() == "smh")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                num7 = worksheet.UsedRange.Rows.Count;
                                num10 = 7;
                                num11 = (count + num10) - 1;
                                num12 = (num7 + num10) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = this.xianname + "林业局";
                                worksheet.get_Range("G2", "G2").Value2 = "更新年月：" + str2;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num12, num3]).EntireRow.Delete(obj3);
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Value2 = objArray7;
                                worksheet.get_Range(worksheet.Cells[num11 + 1, num3 - 4], worksheet.Cells[num11 + 1, num3 - 4]).Value2 = str7;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Name = "Arial Narrow";
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Borders.LineStyle = 1;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 1]).RowHeight = 0x12;
                                worksheet.Select(obj3);
                                worksheet.get_Range("A1", "A1").Select();
                                application.ActiveWindow.DisplayZeros = false;
                            }
                        }
                    }
                    application.ActiveWindow.DisplayZeros = false;
                    worksheet = null;
                    workbook.Save();
                    MessageBox.Show("防护林进度表统计完成，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    application.Visible = true;
                    worksheet = null;
                }
                catch (Exception exception6)
                {
                    exception2 = exception6;
                    MessageBox.Show(exception2.Message.ToString(), "导出EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    process = new Process();
                    Process[] processArray2 = Process.GetProcessesByName("Excel");
                    try
                    {
                        foreach (Process process2 in processArray2)
                        {
                            mainWindowHandle = process2.MainWindowHandle;
                            if (string.IsNullOrEmpty(process2.MainWindowTitle))
                            {
                                process2.Kill();
                            }
                        }
                    }
                    catch (Exception exception7)
                    {
                        exception7.ToString();
                    }
                    GC.Collect();
                }
            }
            base.Close();


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dlgTJMain_Load(object sender, EventArgs e)
        {
            this.dateTimePickerStart.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-01");
            this.dateTimePickerEnd.Value = DateTime.Now;
            DirectoryInfo pt = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            pt = this.GetParentDirectory(pt, "Config");
            if (pt != null)
            {
                string filename = pt.FullName + @"\Config\AppConfig.xml";
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                XmlNode node = document.SelectSingleNode("//DataBase//SqlServer");
                if (node.HasChildNodes)
                {
                    XmlNodeList childNodes = node.ChildNodes;
                    string[] strArray = new string[childNodes.Count];
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        strArray[i] = childNodes.Item(i).InnerText;
                    }
                    ClassTongJiZL.M_Str_ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                    ClassTongJiZL.TABLE_XZDWTABLE = "T_SYS_META_CODE";
                    ClassTongJiZL.TABLE_ZLDATATABLE = this.pzltable;
                    this.ZLTABLE = ClassTongJiZL.TABLE_ZLDATATABLE;
                    this.comboSelXZHName.DisplayMember = "CNAME";
                    this.comboSelXZHName.ValueMember = "CCODE";
                    this.comboSelXZHName.DataSource = MDM.XianList;
                    //this.comboSelXZHName.DataSource = MDM.FindXiang("142326");
                    this.xianname = "吕梁市";
                    //this.xianname = MDM.FindXianName("142326");             
                }
            }
        }

        private DirectoryInfo GetParentDirectory(DirectoryInfo pt, string name)
        {
            try
            {
                if (pt.Parent.GetDirectories(name).Length > 0)
                {
                    return pt.Parent;
                }
                return this.GetParentDirectory(pt.Parent, name);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "获取Config目录错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private void InitializeComponent()
        {
            this.checkBoxB1SCQK1 = new System.Windows.Forms.CheckBox();
            this.checkBoxB2SCQK2 = new System.Windows.Forms.CheckBox();
            this.checkBoxB3SCQK3 = new System.Windows.Forms.CheckBox();
            this.checkBoxB4SCQK4 = new System.Windows.Forms.CheckBox();
            this.checkBoxB5HSZL = new System.Windows.Forms.CheckBox();
            this.checkBoxB6NDHZ = new System.Windows.Forms.CheckBox();
            this.buttonSelAll = new System.Windows.Forms.Button();
            this.buttonReverseSel = new System.Windows.Forms.Button();
            this.buttonSelNone = new System.Windows.Forms.Button();
            this.buttonTJ = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdobtnXiangCun = new System.Windows.Forms.RadioButton();
            this.rdobtnXianXiangCun = new System.Windows.Forms.RadioButton();
            this.rdobtnTJXianToXiang = new System.Windows.Forms.RadioButton();
            this.comboSelXZHName = new System.Windows.Forms.ComboBox();
            this.checkBoxGCJDB = new System.Windows.Forms.CheckBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxB1SCQK1
            // 
            this.checkBoxB1SCQK1.AutoSize = true;
            this.checkBoxB1SCQK1.Location = new System.Drawing.Point(16, 63);
            this.checkBoxB1SCQK1.Name = "checkBoxB1SCQK1";
            this.checkBoxB1SCQK1.Size = new System.Drawing.Size(152, 18);
            this.checkBoxB1SCQK1.TabIndex = 4;
            this.checkBoxB1SCQK1.Text = "林业生产情况（一）";
            this.checkBoxB1SCQK1.UseVisualStyleBackColor = true;
            // 
            // checkBoxB2SCQK2
            // 
            this.checkBoxB2SCQK2.AutoSize = true;
            this.checkBoxB2SCQK2.Location = new System.Drawing.Point(16, 89);
            this.checkBoxB2SCQK2.Name = "checkBoxB2SCQK2";
            this.checkBoxB2SCQK2.Size = new System.Drawing.Size(152, 18);
            this.checkBoxB2SCQK2.TabIndex = 5;
            this.checkBoxB2SCQK2.Text = "林业生产情况（二）";
            this.checkBoxB2SCQK2.UseVisualStyleBackColor = true;
            // 
            // checkBoxB3SCQK3
            // 
            this.checkBoxB3SCQK3.AutoSize = true;
            this.checkBoxB3SCQK3.Location = new System.Drawing.Point(16, 115);
            this.checkBoxB3SCQK3.Name = "checkBoxB3SCQK3";
            this.checkBoxB3SCQK3.Size = new System.Drawing.Size(152, 18);
            this.checkBoxB3SCQK3.TabIndex = 6;
            this.checkBoxB3SCQK3.Text = "林业生产情况（三）";
            this.checkBoxB3SCQK3.UseVisualStyleBackColor = true;
            // 
            // checkBoxB4SCQK4
            // 
            this.checkBoxB4SCQK4.AutoSize = true;
            this.checkBoxB4SCQK4.Location = new System.Drawing.Point(16, 140);
            this.checkBoxB4SCQK4.Name = "checkBoxB4SCQK4";
            this.checkBoxB4SCQK4.Size = new System.Drawing.Size(152, 18);
            this.checkBoxB4SCQK4.TabIndex = 7;
            this.checkBoxB4SCQK4.Text = "林业生产情况（四）";
            this.checkBoxB4SCQK4.UseVisualStyleBackColor = true;
            // 
            // checkBoxB5HSZL
            // 
            this.checkBoxB5HSZL.AutoSize = true;
            this.checkBoxB5HSZL.Location = new System.Drawing.Point(16, 166);
            this.checkBoxB5HSZL.Name = "checkBoxB5HSZL";
            this.checkBoxB5HSZL.Size = new System.Drawing.Size(292, 18);
            this.checkBoxB5HSZL.TabIndex = 8;
            this.checkBoxB5HSZL.Text = "本年度检查验收合格荒山荒地造林面积统计";
            this.checkBoxB5HSZL.UseVisualStyleBackColor = true;
            // 
            // checkBoxB6NDHZ
            // 
            this.checkBoxB6NDHZ.AutoSize = true;
            this.checkBoxB6NDHZ.Location = new System.Drawing.Point(16, 192);
            this.checkBoxB6NDHZ.Name = "checkBoxB6NDHZ";
            this.checkBoxB6NDHZ.Size = new System.Drawing.Size(68, 18);
            this.checkBoxB6NDHZ.TabIndex = 9;
            this.checkBoxB6NDHZ.Text = "汇总表";
            this.checkBoxB6NDHZ.UseVisualStyleBackColor = true;
            this.checkBoxB6NDHZ.CheckedChanged += new System.EventHandler(this.checkBoxB6NDHZ_CheckedChanged);
            // 
            // buttonSelAll
            // 
            this.buttonSelAll.Location = new System.Drawing.Point(19, 294);
            this.buttonSelAll.Name = "buttonSelAll";
            this.buttonSelAll.Size = new System.Drawing.Size(59, 27);
            this.buttonSelAll.TabIndex = 16;
            this.buttonSelAll.Text = "全选";
            this.buttonSelAll.UseVisualStyleBackColor = true;
            this.buttonSelAll.Click += new System.EventHandler(this.buttonSelAll_Click);
            // 
            // buttonReverseSel
            // 
            this.buttonReverseSel.Location = new System.Drawing.Point(87, 294);
            this.buttonReverseSel.Name = "buttonReverseSel";
            this.buttonReverseSel.Size = new System.Drawing.Size(59, 27);
            this.buttonReverseSel.TabIndex = 17;
            this.buttonReverseSel.Text = "反选";
            this.buttonReverseSel.UseVisualStyleBackColor = true;
            this.buttonReverseSel.Click += new System.EventHandler(this.buttonReverseSel_Click);
            // 
            // buttonSelNone
            // 
            this.buttonSelNone.Location = new System.Drawing.Point(153, 294);
            this.buttonSelNone.Name = "buttonSelNone";
            this.buttonSelNone.Size = new System.Drawing.Size(59, 27);
            this.buttonSelNone.TabIndex = 18;
            this.buttonSelNone.Text = "不选";
            this.buttonSelNone.UseVisualStyleBackColor = true;
            this.buttonSelNone.Click += new System.EventHandler(this.buttonSelNone_Click);
            // 
            // buttonTJ
            // 
            this.buttonTJ.Location = new System.Drawing.Point(220, 294);
            this.buttonTJ.Name = "buttonTJ";
            this.buttonTJ.Size = new System.Drawing.Size(59, 27);
            this.buttonTJ.TabIndex = 19;
            this.buttonTJ.Text = "确定";
            this.buttonTJ.UseVisualStyleBackColor = true;
            this.buttonTJ.Click += new System.EventHandler(this.buttonTJ_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(291, 294);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 27);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdobtnXiangCun);
            this.groupBox1.Controls.Add(this.rdobtnXianXiangCun);
            this.groupBox1.Controls.Add(this.rdobtnTJXianToXiang);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(9, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 38);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计方式";
            // 
            // rdobtnXiangCun
            // 
            this.rdobtnXiangCun.AutoSize = true;
            this.rdobtnXiangCun.Location = new System.Drawing.Point(245, 16);
            this.rdobtnXiangCun.Name = "rdobtnXiangCun";
            this.rdobtnXiangCun.Size = new System.Drawing.Size(123, 18);
            this.rdobtnXiangCun.TabIndex = 15;
            this.rdobtnXiangCun.TabStop = true;
            this.rdobtnXiangCun.Text = "按县-乡-村统计";
            this.rdobtnXiangCun.UseVisualStyleBackColor = true;
            this.rdobtnXiangCun.CheckedChanged += new System.EventHandler(this.rdobtnXiangCun_CheckedChanged);
            // 
            // rdobtnXianXiangCun
            // 
            this.rdobtnXianXiangCun.AutoSize = true;
            this.rdobtnXianXiangCun.Location = new System.Drawing.Point(112, 16);
            this.rdobtnXianXiangCun.Name = "rdobtnXianXiangCun";
            this.rdobtnXianXiangCun.Size = new System.Drawing.Size(123, 18);
            this.rdobtnXianXiangCun.TabIndex = 14;
            this.rdobtnXianXiangCun.TabStop = true;
            this.rdobtnXianXiangCun.Text = "按市-县-乡统计";
            this.rdobtnXianXiangCun.UseVisualStyleBackColor = true;
            this.rdobtnXianXiangCun.CheckedChanged += new System.EventHandler(this.rdobtnXianXiangCun_CheckedChanged);
            // 
            // rdobtnTJXianToXiang
            // 
            this.rdobtnTJXianToXiang.AutoSize = true;
            this.rdobtnTJXianToXiang.Checked = true;
            this.rdobtnTJXianToXiang.Location = new System.Drawing.Point(5, 16);
            this.rdobtnTJXianToXiang.Name = "rdobtnTJXianToXiang";
            this.rdobtnTJXianToXiang.Size = new System.Drawing.Size(102, 18);
            this.rdobtnTJXianToXiang.TabIndex = 13;
            this.rdobtnTJXianToXiang.TabStop = true;
            this.rdobtnTJXianToXiang.Text = "按市-县统计";
            this.rdobtnTJXianToXiang.UseVisualStyleBackColor = true;
            this.rdobtnTJXianToXiang.CheckedChanged += new System.EventHandler(this.rdobtnTJXianToXiang_CheckedChanged);
            // 
            // comboSelXZHName
            // 
            this.comboSelXZHName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSelXZHName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSelXZHName.FormattingEnabled = true;
            this.comboSelXZHName.Location = new System.Drawing.Point(248, 240);
            this.comboSelXZHName.Name = "comboSelXZHName";
            this.comboSelXZHName.Size = new System.Drawing.Size(107, 22);
            this.comboSelXZHName.TabIndex = 11;
            this.comboSelXZHName.Visible = false;
            this.comboSelXZHName.SelectedIndexChanged += new System.EventHandler(this.comboSelXZHName_SelectedIndexChanged);
            // 
            // checkBoxGCJDB
            // 
            this.checkBoxGCJDB.AutoSize = true;
            this.checkBoxGCJDB.Location = new System.Drawing.Point(16, 218);
            this.checkBoxGCJDB.Name = "checkBoxGCJDB";
            this.checkBoxGCJDB.Size = new System.Drawing.Size(306, 18);
            this.checkBoxGCJDB.TabIndex = 10;
            this.checkBoxGCJDB.Text = "珠防林、海防林和石漠化综合治理工程进度表";
            this.checkBoxGCJDB.UseVisualStyleBackColor = true;
            this.checkBoxGCJDB.Visible = false;
            this.checkBoxGCJDB.CheckedChanged += new System.EventHandler(this.checkBoxGCJDB_CheckedChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "yyyy年MM月";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(21, 18);
            this.dateTimePickerStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(105, 23);
            this.dateTimePickerStart.TabIndex = 1;
            this.dateTimePickerStart.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "yyyy年MM月";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(159, 18);
            this.dateTimePickerEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(105, 23);
            this.dateTimePickerEnd.TabIndex = 3;
            this.dateTimePickerEnd.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePickerEnd);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "起止年月";
            // 
            // dlgTJMain
            // 
            this.ClientSize = new System.Drawing.Size(376, 332);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxGCJDB);
            this.Controls.Add(this.comboSelXZHName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTJ);
            this.Controls.Add(this.buttonSelNone);
            this.Controls.Add(this.buttonReverseSel);
            this.Controls.Add(this.buttonSelAll);
            this.Controls.Add(this.checkBoxB6NDHZ);
            this.Controls.Add(this.checkBoxB5HSZL);
            this.Controls.Add(this.checkBoxB4SCQK4);
            this.Controls.Add(this.checkBoxB3SCQK3);
            this.Controls.Add(this.checkBoxB2SCQK2);
            this.Controls.Add(this.checkBoxB1SCQK1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgTJMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "营造林数据统计(按小班更新时间)";
            this.Load += new System.EventHandler(this.dlgTJMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void rdobtnTJXianToXiang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdobtnTJXianToXiang.Checked && this.comboSelXZHName.Visible)
            {
                this.comboSelXZHName.Visible = false;
            }
        }

        private void rdobtnXiangCun_CheckedChanged(object sender, EventArgs e)
        {
            if (!(!this.rdobtnXiangCun.Checked || this.comboSelXZHName.Visible))
            {
                this.comboSelXZHName.Visible = true;
            }
        }

        private void rdobtnXianXiangCun_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdobtnXianXiangCun.Checked && this.comboSelXZHName.Visible)
            {
                this.comboSelXZHName.Visible = false;
            }
        }

        public string ZLTableName
        {
            set
            {
                this.pzltable = value;
            }
        }

        private void checkBoxGCJDB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboSelXZHName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxB6NDHZ_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

