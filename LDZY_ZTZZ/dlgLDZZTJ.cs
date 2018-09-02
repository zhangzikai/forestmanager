namespace LDZY_ZTZZ
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;
    using td.db.mid.sys;
    using td.db.orm;
    using td.forest.ldzy.tj;
    using td.logic.forest;
    using td.logic.sys;
    using td.db.mid.forest;
    using LDZY_ZTZZ.tj;

    /// <summary>
    /// 统计--调查成果统计表
    /// </summary>
    public class dlgLDZZTJ : Form
    {
        private System.Windows.Forms.CheckBox B1TJ;
        private System.Windows.Forms.CheckBox B2TJ;
        private System.Windows.Forms.CheckBox B3_1TJ;
        private System.Windows.Forms.CheckBox B3TJ;
        private System.Windows.Forms.CheckBox B4_1TJ;
        private System.Windows.Forms.CheckBox B4TJ;
        private System.Windows.Forms.CheckBox B5_1TJ;
        private System.Windows.Forms.CheckBox B5TJ;
        private System.Windows.Forms.CheckBox B6TJ;
        private System.Windows.Forms.CheckBox B7TJ;
        private System.Windows.Forms.CheckBox BHDJcheckBox;
        private BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnBuDYu;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDayu;
        private System.Windows.Forms.Button btnDYDengyu;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnReverseSel;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Button btnSelNone;
        private System.Windows.Forms.Button btnXiaoYu;
        private System.Windows.Forms.Button btnXYDengyu;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSame;
        private ComboBox comboBoxBCFXMMC;
        private ComboBox comboBoxSelBCLX;
        /// <summary>
        /// 报表统计--选择工程项目
        /// </summary>
        private ComboBox comboBoxSelXMMC;
        private ToolStripComboBox ComBoSelXmmcInBZB;
        private IContainer components;
        private System.Windows.Forms.Label CurXMMC_label;
        private DataGridView dataGridViewBCFInfo;
        /// <summary>
        /// 调查因子
        /// </summary>
        private System.Windows.Forms.ListBox FldslistBox;
        private System.Windows.Forms.ListBox FldValueslistBox;
        private System.Windows.Forms.CheckBox GNFQcheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelUnit;
        private System.Data.DataTable mdccoltable = new System.Data.DataTable("dccoldt");
        private Class_ZZYTJ pClass_ZZYTJ = new Class_ZZYTJ();
        private System.Data.DataTable pmetatable = new System.Data.DataTable("meta");
        private System.Data.DataTable pselfldmetatable = new System.Data.DataTable("flddt");
        private System.Data.DataTable pxmxbtable = new System.Data.DataTable("xmxb");
        /// <summary>
        /// 征占用图层表名
        /// </summary>
        private string pzzytablename;
        private System.Windows.Forms.CheckBox SYLDLXcheckBox;
        private TabControl tabControlZZY;
        private TabPage tabPageBCFYWH;
        private TabPage tabPageTJ;
        private System.Windows.Forms.TextBox textBoxBCDJ;
        private System.Windows.Forms.TextBox textBoxBZ;
        private System.Windows.Forms.TextBox textBoxTJBDS;
        private ToolStripButton tlbBrow;
        private ToolStripButton tlbDel;
        private ToolStripButton tlbExportXLS;
        private ToolStripButton tlbJSFY;
        private ToolStripButton tlbSave;
        private ToolStripButton toolStripBtnExportXB;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckBox ZLDJcheckBox;
        private System.Windows.Forms.CheckBox ZTGNQcheckBox;
        ////public FindMidFromLayer<Forest_LDZY_Mid> FindFromLayer { get; set; }
        //test
        public FindMidFromLayer<ZT_LDZZ_2016_Mid> FindFromLayer { get; set; }
        /// <summary>
        /// 统计--调查成果统计表:构造器
        /// </summary>
        public dlgLDZZTJ()
        {
            this.InitializeComponent();
        }

        private void bindcboXMMCInBZB()
        {
            string text = this.ComBoSelXmmcInBZB.Text;
            System.Data.DataTable pTable = this.pClass_ZZYTJ.GetTable("SELECT DISTINCT XMMC AS XMMC FROM " + Class_ZZYTJ.TABLE_BCFBZB, "DT");
            this.pClass_ZZYTJ.BindToolBarComboBox(pTable, this.ComBoSelXmmcInBZB, "XMMC");
            if (text.Trim().Length > 0)
            {
                this.ComBoSelXmmcInBZB.Text = text;
            }
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            this.SetTxtFocusLocation(" AND ");
        }

        private void btnBuDYu_Click(object sender, EventArgs e)
        {
            string mytxt = " <> ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnDayu_Click(object sender, EventArgs e)
        {
            string mytxt = " > ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void btnDYDengyu_Click(object sender, EventArgs e)
        {
            string mytxt = " >= ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string mytxt = " = ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            string mytxt = " LIKE '%%' ";
            this.SetTxtFocusLocation(mytxt);
            int start = this.textBoxTJBDS.Text.Length - 3;
            this.textBoxTJBDS.Select(start, 0);
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            this.SetTxtFocusLocation(" NOT LIKE '%%' ");
            int start = this.textBoxTJBDS.Text.Length - 3;
            this.textBoxTJBDS.Select(start, 0);
        }

        /// <summary>
        /// 摘要:
        ///     表示 2 元组，即二元组。
        ///
        /// 类型参数:
        ///   T1:
        ///     此元组的第一个组件的类型。
        ///
        ///   T2:
        ///     此元组的第二个组件的类型。
        /// </summary>
        /// <returns></returns>
        private Tuple<int, bool> CheckTableValidate()
        {
            bool flag = false;
            int num2 = 0;
            foreach (Control control in this.groupBox2.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                    box = control as System.Windows.Forms.CheckBox;
                    if (box.CheckState == CheckState.Checked)
                    {
                        num2++;
                        if (box.Name != "SYLDLXcheckBox")
                        {
                            flag = true;
                        }
                    }
                }
            }
            return new Tuple<int, bool>(num2, flag);
        }

        /// <summary>
        /// 点击确定的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            T_EDITTASK_ZT_Mid taskMid = comboBoxSelXMMC.SelectedItem as T_EDITTASK_ZT_Mid;
            if (null == taskMid)
            {
                MessageBox.Show("请先选择有效的项目名称！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                Tuple<int, bool> res = CheckTableValidate();
                if (res.Item1 == 0)
                {
                    MessageBox.Show("请勾选要统计的表！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {//2016年铁路项目
                    Class_ZZYTJ.TABLE_ZZYXMMC = taskMid.taskname;
                    string selectedPath = "";
                    if (res.Item2)
                    {
                        System.Data.DataTable table = this.pClass_ZZYTJ.GetTable("SELECT DISTINCT YDZL AS YDZL FROM " + Class_ZZYTJ.TABLE_ZZYTableName + " WHERE LTRIM(RTRIM(XMMC))='" + Class_ZZYTJ.TABLE_ZZYXMMC + "' ORDER BY YDZL DESC", "xmydzldt");
                        if (table == null)
                        {
                            MessageBox.Show("获取项目用地种类信息出错，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("获取项目没有有效调查数据，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        DataSet tjds = new DataSet("csyd");
                        DataSet set2 = new DataSet("lsyd");
                        foreach (DataRow row in table.Rows)
                        {
                            //根据用地种类判断
                            string ydzl = row[0].ToString();
                            ////string ydzl = taskMid.taskstate;
                            ///在这里我想沿用之前的方法。对空间数据属性表进行查询，而不再对SQLite库进行查询。
                            switch (ydzl)
                            {
                                case "2":
                                    {//表1 按林地类型
                                        
                                        System.Data.DataTable table4 = null;
                                        if (this.B1TJ.Checked)//表1 按林地类型面积蓄积统计表
                                        {
                                            ///SQLite
                                            ////B1 b1 = new B1();
                                            ////table4 = b1.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B1TJByXianXiangCun(ydzl);
                                            table4.TableName = "B1";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B2TJ.Checked)//表2 地按权属各地类面积统计表
                                        {
                                            ///SQLite
                                            ////B2 b2 = new B2();
                                            ////table4 = b2.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B2TJByXianXiangCun(ydzl);
                                            table4.TableName = "B2";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B3TJ.Checked)//表3 按土地权属、起源、林种各龄组面积蓄积统计表
                                        {
                                            ///SQLite
                                            ////B3 b3 = new B3();
                                            ////table4 = b3.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B3TJByXianXiangCun(ydzl);
                                            table4.TableName = "B3";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B3_1TJ.Checked)//表3-1 按土地权属、起源、优势树种（组）各龄组面积蓄积统计表
                                        {

                                            ///SQLite
                                            ////B3_1 b3_1 = new B3_1();
                                            ////table4 = b3_1.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B3_1TJByXianXiangCun(ydzl);
                                            table4.TableName = "B3_1";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B4TJ.Checked)//表4 按土地权属、起源、优势树种（组）各龄组面积蓄积统计表
                                        {
                                            ///SQLite
                                            ////B4 b4 = new B4();
                                            ////table4 = b4.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B4TJByXianXiangCun(ydzl);
                                            table4.TableName = "B4";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B4_1TJ.Checked)//表4-1 按林木权属、起源、优势树种（组）各龄组面积蓄积统计表
                                        {
                                            ///SQLite
                                            ////B4_1 b4_1 = new B4_1();
                                            ////table4 = b4_1.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B4_1TJByXianXiangCun(ydzl);
                                            table4.TableName = "B4_1";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B5TJ.Checked)//表5 经济林按土地权属、产期面积统计表
                                        {
                                            ///SQLite
                                            ////B5 b5 = new B5();
                                            ////table4 = b5.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B5TJByXianXiangCun(ydzl);
                                            table4.TableName = "B5";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B5_1TJ.Checked)//表5-1 经济林按林木权属、产期面积统计表
                                        {
                                            ///SQLite
                                            ////B5_1 b5_1 = new B5_1();
                                            ////table4 = b5_1.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B5_1TJByXianXiangCun(ydzl);
                                            table4.TableName = "B5_1";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B6TJ.Checked)//表6 植被恢复费统计计算结果表
                                        {
                                            ///SQLite
                                            ////B6 b6 = new B6();
                                            ////table4 = b6.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B6TJByXianXiangCun(ydzl);
                                            table4.TableName = "B6";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.B7TJ.Checked)//表7 项目占用征用林地小班一览表
                                        {
                                            ///SQLite
                                            ////B7 b7 = new B7();
                                            ////table4 = b7.ComputeXianXiang(data);

                                            ///SQLServer
                                            table4 = this.pClass_ZZYTJ.B7XMXBTable(ydzl);
                                            table4.TableName = "B7";
                                            tjds.Tables.Add(table4);
                                        }
                                        if (this.ZTGNQcheckBox.Checked)//按林地主体功能区面积蓄积统计表
                                        {
                                            table4 = this.pClass_ZZYTJ.ZTGNQTJTableXianXiangCun(ydzl);
                                            if (table4 != null)
                                            {
                                                ///SQLite
                                                ////ZTGNQ ztgnq = new ZTGNQ();
                                                ////table4 = ztgnq.ComputeXianXiang(data);

                                                ///SQLServer
                                                table4.TableName = "B8";
                                                tjds.Tables.Add(table4);
                                            }
                                        }
                                        if (this.GNFQcheckBox.Checked)//按林地功能分区面积蓄积统计表
                                        {
                                            table4 = this.pClass_ZZYTJ.LDGNFQTJTable(ydzl);
                                            if (table4 != null)
                                            {
                                                ///SQLite
                                                ////GNQ gnq = new GNQ();
                                                ////table4 = gnq.ComputeXianXiang(data);

                                                ///SQLServer
                                                table4.TableName = "B9";
                                                tjds.Tables.Add(table4);
                                            }
                                        }
                                        if (this.BHDJcheckBox.Checked)//按林地保护等级面积蓄积统计表
                                        {
                                            table4 = this.pClass_ZZYTJ.BHDJTJTableXianXiangCun(ydzl);
                                            if (table4 != null)
                                            {
                                                ///SQLite
                                                ////BHDJ bhdj = new BHDJ();
                                                ////table4 = bhdj.ComputeXianXiang(data);

                                                ///SQLServer
                                                table4.TableName = "B10";
                                                tjds.Tables.Add(table4);
                                            }
                                        }
                                        if (this.ZLDJcheckBox.Checked)//按林地质量等级面积蓄积统计表
                                        {
                                            table4 = this.pClass_ZZYTJ.ZLDJTJTableXianXiangCun(ydzl);
                                            if (table4 != null)
                                            {
                                                ///SQLite
                                                ////ZZDJ zzdj = new ZZDJ();
                                                ////table4 = zzdj.ComputeXianXiang(data);

                                                ///SQLServer
                                                table4.TableName = "B11";
                                                tjds.Tables.Add(table4);
                                            }
                                        }
                                        break;
                                    }
                                case "1":
                                    {
                                        System.Data.DataTable table3 = null;
                                        if (this.B1TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B1TJByXianXiangCun(ydzl);
                                            table3.TableName = "B1";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B2TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B2TJByXianXiangCun(ydzl);
                                            table3.TableName = "B2";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B3TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B3TJByXianXiangCun(ydzl);
                                            table3.TableName = "B3";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B3_1TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B3_1TJByXianXiangCun(ydzl);
                                            table3.TableName = "B3_1";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B4TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B4TJByXianXiangCun(ydzl);
                                            table3.TableName = "B4";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B4_1TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B4_1TJByXianXiangCun(ydzl);
                                            table3.TableName = "B4_1";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B5TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B5TJByXianXiangCun(ydzl);
                                            table3.TableName = "B5";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B5_1TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B5_1TJByXianXiangCun(ydzl);
                                            table3.TableName = "B5_1";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B6TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B6TJByXianXiangCun(ydzl);
                                            table3.TableName = "B6";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.B7TJ.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.B7XMXBTable(ydzl);
                                            table3.TableName = "B7";
                                            set2.Tables.Add(table3);
                                        }
                                        if (this.ZTGNQcheckBox.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.ZTGNQTJTableXianXiangCun(ydzl);
                                            if (table3 != null)
                                            {
                                                table3.TableName = "B8";
                                                set2.Tables.Add(table3);
                                            }
                                        }
                                        if (this.GNFQcheckBox.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.LDGNFQTJTable(ydzl);
                                            if (table3 != null)
                                            {
                                                table3.TableName = "B9";
                                                set2.Tables.Add(table3);
                                            }
                                        }
                                        if (this.BHDJcheckBox.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.BHDJTJTableXianXiangCun(ydzl);
                                            if (table3 != null)
                                            {
                                                table3.TableName = "B10";
                                                set2.Tables.Add(table3);
                                            }
                                        }
                                        if (this.ZLDJcheckBox.Checked)
                                        {
                                            table3 = this.pClass_ZZYTJ.ZLDJTJTableXianXiangCun(ydzl);
                                            if (table3 == null)
                                            {
                                                break;
                                            }
                                            table3.TableName = "B11";
                                            set2.Tables.Add(table3);
                                        }
                                        break;
                                    }
                            }
                        }
                        string destFileName = "";
                        string str2 = "";
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            selectedPath = dialog.SelectedPath;
                            destFileName = selectedPath + @"\征占用附表_长期用地结果_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                            str2 = selectedPath + @"\征占用附表_临时用地结果_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                            //长期用地
                            if ((tjds.Tables.Count > 0) && (set2.Tables.Count == 0))
                            {
                                File.Copy(System.Windows.Forms.Application.StartupPath + @"\林地附表模板-长期.xls", destFileName, true);
                                if (!File.Exists(destFileName))
                                {
                                    MessageBox.Show("不能生成文件 " + destFileName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                this.pClass_ZZYTJ.SaveTJB(Class_ZZYTJ.TABLE_ZZYXMMC, tjds, System.Windows.Forms.Application.StartupPath + @"\林地附表模板-长期.xls", destFileName);
                                MessageBox.Show("统计完成，请查看：" + destFileName, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Microsoft.Office.Interop.Excel.Application application3 = new ApplicationClass();
                                object updateLinks = Missing.Value;
                                try
                                {
                                    application3.Workbooks.Open(destFileName, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                                    application3.Visible = true;
                                }
                                catch (Exception exception5)
                                {
                                    MessageBox.Show(exception5.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                finally
                                {
                                    new Process();
                                    Process[] processesByName = Process.GetProcessesByName("Excel");
                                    try
                                    {
                                        foreach (Process process3 in processesByName)
                                        {
                                            IntPtr mainWindowHandle = process3.MainWindowHandle;
                                            if (string.IsNullOrEmpty(process3.MainWindowTitle))
                                            {
                                                process3.Kill();
                                            }
                                        }
                                    }
                                    catch (Exception exception6)
                                    {
                                        exception6.ToString();
                                    }
                                    GC.Collect();
                                }
                            }
                            //短期用地
                            if ((tjds.Tables.Count == 0) && (set2.Tables.Count > 0))
                            {
                                File.Copy(System.Windows.Forms.Application.StartupPath + @"\林地附表模板-临时.xls", str2, true);
                                if (!File.Exists(str2))
                                {
                                    MessageBox.Show("不能生成文件 " + str2, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                this.pClass_ZZYTJ.SaveTJB(Class_ZZYTJ.TABLE_ZZYXMMC, set2, System.Windows.Forms.Application.StartupPath + @"\林地附表模板-临时.xls", str2);
                                MessageBox.Show("统计完成，请查看：" + str2, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Microsoft.Office.Interop.Excel.Application application5 = new ApplicationClass();
                                object obj6 = Missing.Value;
                                try
                                {
                                    application5.Workbooks.Open(str2, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6, obj6);
                                    application5.Visible = true;
                                }
                                catch (Exception exception7)
                                {
                                    MessageBox.Show(exception7.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                finally
                                {
                                    new Process();
                                    Process[] processArray5 = Process.GetProcessesByName("Excel");
                                    try
                                    {
                                        foreach (Process process4 in processArray5)
                                        {
                                            IntPtr ptr2 = process4.MainWindowHandle;
                                            if (string.IsNullOrEmpty(process4.MainWindowTitle))
                                            {
                                                process4.Kill();
                                            }
                                        }
                                    }
                                    catch (Exception exception8)
                                    {
                                        exception8.ToString();
                                    }
                                    GC.Collect();
                                }
                            }
                            if ((tjds.Tables.Count > 0) && (set2.Tables.Count > 0))
                            {
                                File.Copy(System.Windows.Forms.Application.StartupPath + @"\林地附表模板-长期.xls", destFileName, true);
                                File.Copy(System.Windows.Forms.Application.StartupPath + @"\林地附表模板-临时.xls", str2, true);
                                if (!File.Exists(destFileName) && !File.Exists(str2))
                                {
                                    MessageBox.Show("不能生成统计文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                this.pClass_ZZYTJ.SaveTJB(Class_ZZYTJ.TABLE_ZZYXMMC, tjds, System.Windows.Forms.Application.StartupPath + @"\林地附表模板-长期.xls", destFileName);
                                this.pClass_ZZYTJ.SaveTJB(Class_ZZYTJ.TABLE_ZZYXMMC, set2, System.Windows.Forms.Application.StartupPath + @"\林地附表模板-临时.xls", str2);
                                MessageBox.Show("统计完成，共生成2个文件，请查看：" + destFileName + "\n\r" + str2, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Microsoft.Office.Interop.Excel.Application application4 = new ApplicationClass();
                                object obj5 = Missing.Value;
                                try
                                {
                                    application4.Workbooks.Open(destFileName, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5);
                                    application4.Workbooks.Open(str2, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5, obj5);
                                    application4.Visible = true;
                                }
                                catch (Exception exception9)
                                {
                                    MessageBox.Show(exception9.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                finally
                                {
                                    new Process();
                                    Process[] processArray6 = Process.GetProcessesByName("Excel");
                                    try
                                    {
                                        foreach (Process process5 in processArray6)
                                        {
                                            IntPtr ptr3 = process5.MainWindowHandle;
                                            if (string.IsNullOrEmpty(process5.MainWindowTitle))
                                            {
                                                process5.Kill();
                                            }
                                        }
                                    }
                                    catch (Exception exception10)
                                    {
                                        exception10.ToString();
                                    }
                                    GC.Collect();
                                }
                            }
                            if ((tjds.Tables.Count == 0) && (set2.Tables.Count == 0))
                            {
                                MessageBox.Show("没有有效数据，请检查调查表用地种类是否填写完整！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    if (this.SYLDLXcheckBox.Checked)
                    {
                        System.Data.DataTable table2 = this.pClass_ZZYTJ.SYLDLXTJTable();
                        if (table2 != null)
                        {
                            DataSet set3 = new DataSet("ldlxds");
                            set3.Tables.Add(table2);
                            if (selectedPath.Trim().Length == 0)
                            {
                                FolderBrowserDialog dialog2 = new FolderBrowserDialog();
                                if (dialog2.ShowDialog() != DialogResult.OK)
                                {
                                    return;
                                }
                                string str3 = dialog2.SelectedPath + @"\使用林地类型表_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                                File.Copy(System.Windows.Forms.Application.StartupPath + @"\使用林地类型表.xls", str3, true);
                                if (!File.Exists(str3))
                                {
                                    MessageBox.Show("不能生成文件 " + str3, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                                this.pClass_ZZYTJ.SaveSYLDLXTABLE(set3, System.Windows.Forms.Application.StartupPath + @"\使用林地类型表.xls", str3);
                                MessageBox.Show("统计完成，请查看：" + str3, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                                object obj2 = Missing.Value;
                                try
                                {
                                    try
                                    {
                                        application.Workbooks.Open(str3, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2);
                                        application.Visible = true;
                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show(exception.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                    return;
                                }
                                finally
                                {
                                    new Process();
                                    Process[] processArray = Process.GetProcessesByName("Excel");
                                    try
                                    {
                                        foreach (Process process in processArray)
                                        {
                                            IntPtr ptr4 = process.MainWindowHandle;
                                            if (string.IsNullOrEmpty(process.MainWindowTitle))
                                            {
                                                process.Kill();
                                            }
                                        }
                                    }
                                    catch (Exception exception2)
                                    {
                                        exception2.ToString();
                                    }
                                    GC.Collect();
                                }
                            }
                            string str5 = selectedPath + @"\使用林地类型表_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
                            File.Copy(System.Windows.Forms.Application.StartupPath + @"\使用林地类型表.xls", str5, true);
                            if (!File.Exists(str5))
                            {
                                MessageBox.Show("不能生成文件 " + str5, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            else
                            {
                                this.pClass_ZZYTJ.SaveSYLDLXTABLE(set3, System.Windows.Forms.Application.StartupPath + @"\使用林地类型表.xls", str5);
                                MessageBox.Show("统计完成，请查看：" + str5, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Microsoft.Office.Interop.Excel.Application application2 = new ApplicationClass();
                                object obj3 = Missing.Value;
                                try
                                {
                                    application2.Workbooks.Open(str5, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3, obj3);
                                    application2.Visible = true;
                                }
                                catch (Exception exception3)
                                {
                                    MessageBox.Show(exception3.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                finally
                                {
                                    new Process();
                                    Process[] processArray3 = Process.GetProcessesByName("Excel");
                                    try
                                    {
                                        foreach (Process process2 in processArray3)
                                        {
                                            IntPtr ptr5 = process2.MainWindowHandle;
                                            if (string.IsNullOrEmpty(process2.MainWindowTitle))
                                            {
                                                process2.Kill();
                                            }
                                        }
                                    }
                                    catch (Exception exception4)
                                    {
                                        exception4.ToString();
                                    }
                                    GC.Collect();
                                }
                            }
                        }
                    }                 
                }
            }
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            this.SetTxtFocusLocation(" OR ");
        }

        private void btnReverseSel_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.groupBox2.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox box = new System.Windows.Forms.CheckBox();
                    box = control as System.Windows.Forms.CheckBox;
                    if (box.CheckState == CheckState.Unchecked)
                    {
                        box.Checked = true;
                    }
                    else
                    {
                        box.Checked = false;
                    }
                }
            }
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.groupBox2.Controls)
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

        private void btnSelNone_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.groupBox2.Controls)
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

        private void btnXiaoYu_Click(object sender, EventArgs e)
        {
            string mytxt = " < ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void btnXYDengyu_Click(object sender, EventArgs e)
        {
            string mytxt = " <= ";
            this.SetTxtFocusLocation(mytxt);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (this.textBoxTJBDS.Text.Trim().Length > 0)
            {
                this.textBoxTJBDS.Text = "";
                this.textBoxTJBDS.Focus();
            }
        }

        private void buttonSame_Click(object sender, EventArgs e)
        {
            string text = this.comboBoxBCFXMMC.Text;
            string pxmmc = this.comboBoxSelXMMC.Text;
            if (text.Trim().Length == 0)
            {
                MessageBox.Show("没有可选的项目补偿标准，不能添加！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string cmdtxt = "SELECT BCLXBH1,BCLXBH1,BCLXCODE,BCLXNAME,BCDJ,TJBDS,XIAN,BCBZJLND,BZ,XMMC FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE LEN(LTRIM(RTRIM(XMMC)))>0";
                System.Data.DataTable table = this.pClass_ZZYTJ.GetTable(cmdtxt, "bcb");
                if ((table != null) && (table.Rows.Count != 0))
                {
                    System.Data.DataTable dataTabeBySelRows = this.pClass_ZZYTJ.GetDataTabeBySelRows(table, "XMMC='" + text + "'");
                    System.Data.DataTable table4 = this.pClass_ZZYTJ.GetDataTabeBySelRows(table, "XMMC='" + pxmmc + "'");
                    foreach (DataRow row2 in table4.Rows)
                    {
                        row2["TJBDS"] = row2["TJBDS"].ToString().Trim().Replace("'", "");
                    }
                    int num = 0;
                    SqlConnection connection = null;
                    SqlTransaction transaction = null;
                    try
                    {
                        connection = new SqlConnection(Class_ZZYTJ.M_Str_ConnectionString);
                        connection.Open();
                        SqlCommand command = connection.CreateCommand();
                        transaction = connection.BeginTransaction("pTransaction");
                        command.Connection = connection;
                        command.Transaction = transaction;
                        foreach (DataRow row in dataTabeBySelRows.Rows)
                        {
                            string str4 = row["BCLXCODE"].ToString().Trim();
                            string str5 = row["BCLXNAME"].ToString().Trim();
                            double num2 = Convert.ToDouble(row["BCDJ"].ToString());
                            string str6 = row["BZ"].ToString().Trim();
                            string str7 = row["TJBDS"].ToString().Trim().Replace("'", "");
                            if (table4.Select("BCLXCODE='" + str4 + "' AND TJBDS='" + str7 + "'").Length == 0)
                            {
                                string s = this.pClass_ZZYTJ.pGetReaderStr(" SELECT MAX(BCLXBH1) + 1 FROM " + Class_ZZYTJ.TABLE_BCFBZB);
                                int result = 0;
                                int.TryParse(s, out result);
                                object obj2 = " INSERT INTO " + Class_ZZYTJ.TABLE_BCFBZB + "(BCLXCODE,BCLXNAME,BCDJ,TJBDS,XMMC,BCBZJLND,BZ) VALUES(";
                                string str10 = string.Concat(new object[] { obj2, "'", str4, "','", str5, "', ", num2, ",'", row["TJBDS"].ToString().Trim().Replace("'", "''"), "'," });
                                string str9 = str10 + "'" + pxmmc + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + str6 + "') ";
                                command.CommandText = str9;
                                command.ExecuteNonQuery();
                                num++;
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("撤销添加补偿标准操作出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    finally
                    {
                        if ((connection != null) && (connection.State == ConnectionState.Open))
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }
                    if (num == 0)
                    {
                        MessageBox.Show("已存在相同的补偿标准，不用再添加，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.bindcboXMMCInBZB();
                        this.ComBoSelXmmcInBZB.Text = pxmmc;
                        this.dataGridViewBCFInfo.DataSource = null;
                        System.Data.DataTable bCBZTableByXMMC = this.GetBCBZTableByXMMC(pxmmc);
                        if (bCBZTableByXMMC != null)
                        {
                            this.dataGridViewBCFInfo.DataSource = bCBZTableByXMMC;
                            this.dataGridViewBCFInfo.Columns["编号"].Visible = false;
                        }
                        MessageBox.Show("补偿标准添加完成，共添加" + num.ToString() + "个记录，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        private void comboBoxSelBCLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxSelBCLX.SelectedIndex == 3)
            {
                this.labelUnit.Text = "(元/平方米)";
            }
            else
            {
                this.labelUnit.Text = "(元/亩)";
            }
        }

        private void ComBoSelXmmcInBZB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ComBoSelXmmcInBZB.SelectedIndex > -1)
            {
                this.comboBoxBCFXMMC.DataSource = null;
                string text = this.ComBoSelXmmcInBZB.Text;
                if (text != "System.Data.DataRowView")
                {
                    System.Data.DataTable dataSource = (System.Data.DataTable)this.ComBoSelXmmcInBZB.ComboBox.DataSource;
                    System.Data.DataTable dataTabeBySelRows = this.pClass_ZZYTJ.GetDataTabeBySelRows(dataSource, "XMMC<>'" + text + "'");
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        this.pClass_ZZYTJ.BindComboBox(dataTabeBySelRows, this.comboBoxBCFXMMC, "XMMC");
                        this.comboBoxBCFXMMC.Enabled = true;
                        this.buttonSame.Enabled = true;
                    }
                    else
                    {
                        this.comboBoxBCFXMMC.DataSource = null;
                        this.comboBoxBCFXMMC.Enabled = false;
                        this.buttonSame.Enabled = false;
                    }
                }
            }
        }

        private void dataGridViewBCFInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.FillTextBoxBySelRow();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public ProjectManager PM
        {
            get { return DBServiceFactory<ProjectManager>.Service; }
        }

        /// <summary>
        /// 加载窗体时触发此应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlgLDZZTJ_Load(object sender, EventArgs e)
        {
            DirectoryInfo parentDirectory = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            parentDirectory = this.GetParentDirectory(parentDirectory, "Config");
            if (parentDirectory != null)
            {
                string filename = parentDirectory.FullName + @"\Config\AppConfig.xml";
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                //连接SQlite数据库
                ////XmlNode node = document.SelectSingleNode("//DataBase//SQLite");
                //连接SQLServer数据库
                XmlNode node = document.SelectSingleNode("//DataBase//SqlServer");

                if (node.HasChildNodes)
                {
                    XmlNodeList childNodes = node.ChildNodes;
                    string[] strArray = new string[childNodes.Count];
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        strArray[i] = childNodes.Item(i).InnerText;
                    }
                    Class_ZZYTJ.M_Str_ConnectionString = "Data Source=" + strArray[2] + ";Initial Catalog=" + strArray[3] + ";User ID=" + strArray[0] + ";Password=" + strArray[1] + ";Persist Security Info=false;";
                    Class_ZZYTJ.TABLE_XZDWTABLE = "T_SYS_META_CODE";
                    Class_ZZYTJ.TABLE_ZZYTableName = this.pzzytablename;
                    string cmdText = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET SLXJ=0 WHERE SLXJ IS NULL";
                    string str5 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LDBCDJ=0 WHERE LDBCDJ IS NULL";
                    string str6 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LDBCF=0 WHERE LDBCF IS NULL";
                    string str7 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LDAZFDJ=0 WHERE LDAZFDJ IS NULL";
                    string str8 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LDAZF=0 WHERE LDAZF IS NULL";
                    string str9 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LMBCDJ=0 WHERE LMBCDJ IS NULL";
                    string str10 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET LMBCF=0 WHERE LMBCF IS NULL";
                    string str11 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET BCFHJ=0 WHERE BCFHJ IS NULL";
                    string str12 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET ZBHFDJ=0 WHERE ZBHFDJ IS NULL";
                    string str13 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET ZBHFF=0 WHERE ZBHFF IS NULL";
                    string str14 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET ZFYHJ=0 WHERE ZFYHJ IS NULL";

                    ///没有使用SQLServer数据库,因此注销
                    SqlConnection connection = new SqlConnection(Class_ZZYTJ.M_Str_ConnectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(cmdText, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str5, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str6, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str7, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str8, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str9, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str10, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str11, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str12, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(str13, connection);
                    command.ExecuteNonQuery();
                    new SqlCommand(str14, connection).ExecuteNonQuery();
                    connection.Close();
                    IList<T_EDITTASK_ZT_Mid> pjLst = PM.FindByKindCode("4");
                    if (pjLst.Count > 0)
                    {
                        comboBoxSelXMMC.DisplayMember = "taskname";
                        comboBoxSelXMMC.ValueMember = "ID";
                        comboBoxSelXMMC.DataSource = pjLst;
                        this.comboBoxSelBCLX.SelectedIndex = 0;
                        this.mdccoltable = this.pDCColTable();
                        string str17 = " SELECT CCODE,CNAME,CSNAME,CDOMAIN,CINDEX FROM " + Class_ZZYTJ.TABLE_XZDWTABLE + " WHERE ";
                        string str3 = "";
                        foreach (DataRow row in this.mdccoltable.Rows)
                        {
                            string str2 = row["dccolname"].ToString();
                            str3 = str3 + "CDOMAIN = '" + str2 + "' OR ";
                        }
                        this.pmetatable = this.pClass_ZZYTJ.GetTable(str17 + str3.Substring(0, str3.Length - 3), "meta");
                        if (this.pmetatable != null)
                        {

                            this.FldslistBox.BeginUpdate();
                            for (int j = 0; j < this.mdccoltable.Rows.Count; j++)
                            {
                                this.FldslistBox.Items.Add(this.mdccoltable.Rows[j][2].ToString());
                            }
                            this.FldslistBox.EndUpdate();
                        }
                    }
                }
            }
        }

        private void FillTextBoxByFirstRow()
        {
            this.dataGridViewBCFInfo.CurrentCell = this.dataGridViewBCFInfo[2, 0];
            if (this.dataGridViewBCFInfo.CurrentCell.RowIndex > -1)
            {
                string str = this.dataGridViewBCFInfo["费用名称", 0].Value.ToString();
                switch (str)
                {
                    case "植被恢复费":
                        this.comboBoxSelBCLX.SelectedIndex = 3;
                        break;

                    case "林地补偿费":
                        this.comboBoxSelBCLX.SelectedIndex = 0;
                        break;

                    case "林地安置费":
                        this.comboBoxSelBCLX.SelectedIndex = 1;
                        break;

                    case "林木补偿费":
                        this.comboBoxSelBCLX.SelectedIndex = 2;
                        break;
                }
                string str2 = this.dataGridViewBCFInfo["项目名称", 0].Value.ToString();
                if (str != "植被恢复费")
                {
                    if (str2.Trim().Length <= 0)
                    {
                    }
                }
                else
                {
                    this.comboBoxBCFXMMC.Text = "";
                    this.ComBoSelXmmcInBZB.Text = "";
                }
                this.textBoxBCDJ.Text = this.dataGridViewBCFInfo["补偿标准", 0].Value.ToString();
                this.textBoxTJBDS.Text = this.dataGridViewBCFInfo["统计条件", 0].Value.ToString();
                this.textBoxBZ.Text = this.dataGridViewBCFInfo["备注", 0].Value.ToString();
            }
        }

        private void FillTextBoxBySelRow()
        {
            if (this.dataGridViewBCFInfo.CurrentCell.RowIndex > -1)
            {
                string str = this.dataGridViewBCFInfo["费用名称", this.dataGridViewBCFInfo.CurrentCell.RowIndex].Value.ToString();
                switch (str)
                {
                    case "植被恢复费":
                        this.comboBoxSelBCLX.SelectedIndex = 3;
                        break;

                    case "林地补偿费":
                        this.comboBoxSelBCLX.SelectedIndex = 0;
                        break;

                    case "林地安置费":
                        this.comboBoxSelBCLX.SelectedIndex = 1;
                        break;

                    case "林木补偿费":
                        this.comboBoxSelBCLX.SelectedIndex = 2;
                        break;
                }
                string text = this.dataGridViewBCFInfo["项目名称", this.dataGridViewBCFInfo.CurrentCell.RowIndex].Value.ToString();
                if (str != "植被恢复费")
                {
                    if (text.Trim().Length <= 0)
                    {
                    }
                }
                else
                {
                    this.comboBoxBCFXMMC.Text = "";
                    this.ComBoSelXmmcInBZB.Text = "";
                }
                if (text.Trim().Length == 0)
                {
                    text = this.comboBoxSelXMMC.Text;
                }
                this.textBoxBCDJ.Text = this.dataGridViewBCFInfo["补偿标准", this.dataGridViewBCFInfo.CurrentCell.RowIndex].Value.ToString();
                this.textBoxTJBDS.Text = this.dataGridViewBCFInfo["统计条件", this.dataGridViewBCFInfo.CurrentCell.RowIndex].Value.ToString();
                this.textBoxBZ.Text = this.dataGridViewBCFInfo["备注", this.dataGridViewBCFInfo.CurrentCell.RowIndex].Value.ToString();
            }
        }

        private void FldslistBox_DoubleClick(object sender, EventArgs e)
        {
            string myselfld = this.FldslistBox.SelectedItem.ToString();
            string colName = this.GetColName(myselfld);
            this.SetTxtFocusLocation(colName);
        }

        private void FldslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FldValueslistBox.Items.Clear();
            if (this.FldslistBox.SelectedItem != null)
            {
                string myselfld = this.FldslistBox.SelectedItem.ToString();
                if (this.pxmxbtable.Rows.Count > 0)
                {
                    string str3 = this.GetColName(myselfld).Trim();
                    this.pxmxbtable.DefaultView.Sort = str3;
                    System.Data.DataTable table = this.pxmxbtable.DefaultView.ToTable(true, new string[] { str3 });
                    this.pselfldmetatable = table.Clone();
                    this.pselfldmetatable.Columns.Add("CNAME", typeof(string));
                    DataRow[] rowArray = this.mdccoltable.Select("colname='" + str3 + "'");
                    if (rowArray.Length > 0)
                    {
                        string str4 = rowArray[0][1].ToString().Trim();
                        if (table != null)
                        {
                            this.FldValueslistBox.BeginUpdate();
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                string item = table.Rows[i][0].ToString();
                                DataRow[] rowArray2 = this.pmetatable.Select("cdomain='" + str4 + "' AND  CCODE='" + item + "'");
                                if (rowArray2.Length > 0)
                                {
                                    this.FldValueslistBox.Items.Add("'" + rowArray2[0][1].ToString() + "'");
                                    DataRow row = this.pselfldmetatable.NewRow();
                                    this.pselfldmetatable.Rows.Add(row);
                                    row[0] = item;
                                    row[1] = rowArray2[0][1].ToString();
                                }
                                else if (str3 == "SFTGD")
                                {
                                    this.FldValueslistBox.Items.Add("'" + item + "'");
                                }
                                else
                                {
                                    this.FldValueslistBox.Items.Add(item);
                                }
                            }
                            this.FldValueslistBox.EndUpdate();
                            this.FldValueslistBox.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void FldValueslistBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.FldValueslistBox.SelectedItem != null)
            {
                string mytxt = this.FldValueslistBox.SelectedItem.ToString();
                if (mytxt.IndexOf("'") < 0)
                {
                    this.SetTxtFocusLocation(mytxt);
                }
                else
                {
                    string str2 = mytxt.Substring(1, mytxt.Length - 2);
                    DataRow[] rowArray = this.mdccoltable.Select("cname='" + this.FldslistBox.SelectedItem.ToString() + "'");
                    string str3 = rowArray[0][0].ToString();
                    if (str2.Trim().Length == 0)
                    {
                        this.SetTxtFocusLocation(mytxt);
                    }
                    else if (str3 == "SFTGD")
                    {
                        this.SetTxtFocusLocation(mytxt);
                    }
                    else
                    {
                        rowArray[0][2].ToString();
                        DataRow[] rowArray2 = this.pselfldmetatable.Select("cname='" + str2 + "'");
                        if (rowArray2.Length > 0)
                        {
                            this.SetTxtFocusLocation("'" + rowArray2[0][str3].ToString() + "'");
                        }
                        else
                        {
                            this.SetTxtFocusLocation(mytxt);
                        }
                    }
                }
            }
        }

        private System.Data.DataTable GetBCBZTableByXMMC(string pxmmc)
        {
            System.Data.DataTable table = new System.Data.DataTable("xmbcb");
            string cmdtxt = " SELECT  BCLXBH1 AS 编号,XMMC AS 项目名称,BCLXNAME AS 费用名称, CONVERT(numeric(14, 2), BCDJ) AS 补偿标准, TJBDS AS 统计条件,BZ AS 备注 FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(XMMC))='" + pxmmc + "') ORDER BY BCLXCODE";
            table = this.pClass_ZZYTJ.GetTable(cmdtxt, "DT");
            if ((table == null) || (table.Rows.Count == 0))
            {
                MessageBox.Show("数据库没有 " + pxmmc + " 补偿标准数据,请录入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return table;
        }

        private string GetColName(string myselfld)
        {
            string str = myselfld;
            DataRow[] rowArray = this.pDCColTable().Select("cname='" + myselfld + "'");
            if (rowArray.Length > 0)
            {
                str = rowArray[0][0].ToString();
            }
            return str;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgLDZZTJ));
            this.tabControlZZY = new System.Windows.Forms.TabControl();
            this.tabPageTJ = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnReverseSel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelNone = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSelXMMC = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SYLDLXcheckBox = new System.Windows.Forms.CheckBox();
            this.BHDJcheckBox = new System.Windows.Forms.CheckBox();
            this.ZLDJcheckBox = new System.Windows.Forms.CheckBox();
            this.GNFQcheckBox = new System.Windows.Forms.CheckBox();
            this.ZTGNQcheckBox = new System.Windows.Forms.CheckBox();
            this.B7TJ = new System.Windows.Forms.CheckBox();
            this.B6TJ = new System.Windows.Forms.CheckBox();
            this.B5_1TJ = new System.Windows.Forms.CheckBox();
            this.B5TJ = new System.Windows.Forms.CheckBox();
            this.B4_1TJ = new System.Windows.Forms.CheckBox();
            this.B4TJ = new System.Windows.Forms.CheckBox();
            this.B3_1TJ = new System.Windows.Forms.CheckBox();
            this.B3TJ = new System.Windows.Forms.CheckBox();
            this.B2TJ = new System.Windows.Forms.CheckBox();
            this.B1TJ = new System.Windows.Forms.CheckBox();
            this.tabPageBCFYWH = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CurXMMC_label = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.FldValueslistBox = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnXYDengyu = new System.Windows.Forms.Button();
            this.btnXiaoYu = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnDYDengyu = new System.Windows.Forms.Button();
            this.btnDayu = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnBuDYu = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.FldslistBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTJBDS = new System.Windows.Forms.TextBox();
            this.buttonSame = new System.Windows.Forms.Button();
            this.labelUnit = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewBCFInfo = new System.Windows.Forms.DataGridView();
            this.textBoxBZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBCFXMMC = new System.Windows.Forms.ComboBox();
            this.textBoxBCDJ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSelBCLX = new System.Windows.Forms.ComboBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.ComBoSelXmmcInBZB = new System.Windows.Forms.ToolStripComboBox();
            this.tlbBrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbDel = new System.Windows.Forms.ToolStripButton();
            this.tlbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbJSFY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExportXB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbExportXLS = new System.Windows.Forms.ToolStripButton();
            this.tabControlZZY.SuspendLayout();
            this.tabPageTJ.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageBCFYWH.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBCFInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlZZY
            // 
            this.tabControlZZY.Controls.Add(this.tabPageTJ);
            this.tabControlZZY.Controls.Add(this.tabPageBCFYWH);
            this.tabControlZZY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlZZY.Location = new System.Drawing.Point(0, 0);
            this.tabControlZZY.Name = "tabControlZZY";
            this.tabControlZZY.SelectedIndex = 0;
            this.tabControlZZY.Size = new System.Drawing.Size(828, 562);
            this.tabControlZZY.TabIndex = 0;
            this.tabControlZZY.SelectedIndexChanged += new System.EventHandler(this.tabControlZZY_SelectedIndexChanged);
            // 
            // tabPageTJ
            // 
            this.tabPageTJ.Controls.Add(this.groupBox4);
            this.tabPageTJ.Controls.Add(this.label1);
            this.tabPageTJ.Controls.Add(this.comboBoxSelXMMC);
            this.tabPageTJ.Controls.Add(this.groupBox2);
            this.tabPageTJ.Location = new System.Drawing.Point(4, 24);
            this.tabPageTJ.Name = "tabPageTJ";
            this.tabPageTJ.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTJ.Size = new System.Drawing.Size(820, 534);
            this.tabPageTJ.TabIndex = 0;
            this.tabPageTJ.Text = "报表统计";
            this.tabPageTJ.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSelAll);
            this.groupBox4.Controls.Add(this.btnReverseSel);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnSelNone);
            this.groupBox4.Controls.Add(this.btnOK);
            this.groupBox4.Location = new System.Drawing.Point(476, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 131);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作区";
            // 
            // btnSelAll
            // 
            this.btnSelAll.Location = new System.Drawing.Point(17, 22);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(66, 30);
            this.btnSelAll.TabIndex = 19;
            this.btnSelAll.Text = "全选";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnReverseSel
            // 
            this.btnReverseSel.Location = new System.Drawing.Point(17, 58);
            this.btnReverseSel.Name = "btnReverseSel";
            this.btnReverseSel.Size = new System.Drawing.Size(66, 30);
            this.btnReverseSel.TabIndex = 20;
            this.btnReverseSel.Text = "反选";
            this.btnReverseSel.UseVisualStyleBackColor = true;
            this.btnReverseSel.Click += new System.EventHandler(this.btnReverseSel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(96, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelNone
            // 
            this.btnSelNone.Location = new System.Drawing.Point(17, 94);
            this.btnSelNone.Name = "btnSelNone";
            this.btnSelNone.Size = new System.Drawing.Size(66, 30);
            this.btnSelNone.TabIndex = 21;
            this.btnSelNone.Text = "全不选";
            this.btnSelNone.UseVisualStyleBackColor = true;
            this.btnSelNone.Click += new System.EventHandler(this.btnSelNone_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(96, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 30);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择工程项目:";
            // 
            // comboBoxSelXMMC
            // 
            this.comboBoxSelXMMC.FormattingEnabled = true;
            this.comboBoxSelXMMC.Location = new System.Drawing.Point(127, 14);
            this.comboBoxSelXMMC.Name = "comboBoxSelXMMC";
            this.comboBoxSelXMMC.Size = new System.Drawing.Size(332, 22);
            this.comboBoxSelXMMC.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SYLDLXcheckBox);
            this.groupBox2.Controls.Add(this.BHDJcheckBox);
            this.groupBox2.Controls.Add(this.ZLDJcheckBox);
            this.groupBox2.Controls.Add(this.GNFQcheckBox);
            this.groupBox2.Controls.Add(this.ZTGNQcheckBox);
            this.groupBox2.Controls.Add(this.B7TJ);
            this.groupBox2.Controls.Add(this.B6TJ);
            this.groupBox2.Controls.Add(this.B5_1TJ);
            this.groupBox2.Controls.Add(this.B5TJ);
            this.groupBox2.Controls.Add(this.B4_1TJ);
            this.groupBox2.Controls.Add(this.B4TJ);
            this.groupBox2.Controls.Add(this.B3_1TJ);
            this.groupBox2.Controls.Add(this.B3TJ);
            this.groupBox2.Controls.Add(this.B2TJ);
            this.groupBox2.Controls.Add(this.B1TJ);
            this.groupBox2.Location = new System.Drawing.Point(12, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 451);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表类型";
            // 
            // SYLDLXcheckBox
            // 
            this.SYLDLXcheckBox.AutoSize = true;
            this.SYLDLXcheckBox.Location = new System.Drawing.Point(15, 415);
            this.SYLDLXcheckBox.Name = "SYLDLXcheckBox";
            this.SYLDLXcheckBox.Size = new System.Drawing.Size(194, 18);
            this.SYLDLXcheckBox.TabIndex = 17;
            this.SYLDLXcheckBox.Text = "被征用占用林地使用类型表";
            this.SYLDLXcheckBox.UseVisualStyleBackColor = true;
            // 
            // BHDJcheckBox
            // 
            this.BHDJcheckBox.AutoSize = true;
            this.BHDJcheckBox.Location = new System.Drawing.Point(15, 361);
            this.BHDJcheckBox.Name = "BHDJcheckBox";
            this.BHDJcheckBox.Size = new System.Drawing.Size(222, 18);
            this.BHDJcheckBox.TabIndex = 15;
            this.BHDJcheckBox.Text = "按林地保护等级面积蓄积统计表";
            this.BHDJcheckBox.UseVisualStyleBackColor = true;
            // 
            // ZLDJcheckBox
            // 
            this.ZLDJcheckBox.AutoSize = true;
            this.ZLDJcheckBox.Location = new System.Drawing.Point(15, 387);
            this.ZLDJcheckBox.Name = "ZLDJcheckBox";
            this.ZLDJcheckBox.Size = new System.Drawing.Size(222, 18);
            this.ZLDJcheckBox.TabIndex = 16;
            this.ZLDJcheckBox.Text = "按林地质量等级面积蓄积统计表";
            this.ZLDJcheckBox.UseVisualStyleBackColor = true;
            // 
            // GNFQcheckBox
            // 
            this.GNFQcheckBox.AutoSize = true;
            this.GNFQcheckBox.Location = new System.Drawing.Point(15, 335);
            this.GNFQcheckBox.Name = "GNFQcheckBox";
            this.GNFQcheckBox.Size = new System.Drawing.Size(222, 18);
            this.GNFQcheckBox.TabIndex = 14;
            this.GNFQcheckBox.Text = "按林地功能分区面积蓄积统计表";
            this.GNFQcheckBox.UseVisualStyleBackColor = true;
            // 
            // ZTGNQcheckBox
            // 
            this.ZTGNQcheckBox.AutoSize = true;
            this.ZTGNQcheckBox.Location = new System.Drawing.Point(15, 308);
            this.ZTGNQcheckBox.Name = "ZTGNQcheckBox";
            this.ZTGNQcheckBox.Size = new System.Drawing.Size(236, 18);
            this.ZTGNQcheckBox.TabIndex = 13;
            this.ZTGNQcheckBox.Text = "按林地主体功能区面积蓄积统计表";
            this.ZTGNQcheckBox.UseVisualStyleBackColor = true;
            // 
            // B7TJ
            // 
            this.B7TJ.AutoSize = true;
            this.B7TJ.Location = new System.Drawing.Point(15, 281);
            this.B7TJ.Name = "B7TJ";
            this.B7TJ.Size = new System.Drawing.Size(236, 18);
            this.B7TJ.TabIndex = 12;
            this.B7TJ.Text = "表7 项目占用征用林地小班一览表";
            this.B7TJ.UseVisualStyleBackColor = true;
            // 
            // B6TJ
            // 
            this.B6TJ.AutoSize = true;
            this.B6TJ.Location = new System.Drawing.Point(15, 253);
            this.B6TJ.Name = "B6TJ";
            this.B6TJ.Size = new System.Drawing.Size(222, 18);
            this.B6TJ.TabIndex = 11;
            this.B6TJ.Text = "表6 植被恢复费统计计算结果表";
            this.B6TJ.UseVisualStyleBackColor = true;
            // 
            // B5_1TJ
            // 
            this.B5_1TJ.AutoSize = true;
            this.B5_1TJ.Location = new System.Drawing.Point(15, 225);
            this.B5_1TJ.Name = "B5_1TJ";
            this.B5_1TJ.Size = new System.Drawing.Size(292, 18);
            this.B5_1TJ.TabIndex = 10;
            this.B5_1TJ.Text = "表5-1 经济林按林木权属、产期面积统计表";
            this.B5_1TJ.UseVisualStyleBackColor = true;
            // 
            // B5TJ
            // 
            this.B5TJ.AutoSize = true;
            this.B5TJ.Location = new System.Drawing.Point(15, 195);
            this.B5TJ.Name = "B5TJ";
            this.B5TJ.Size = new System.Drawing.Size(278, 18);
            this.B5TJ.TabIndex = 9;
            this.B5TJ.Text = "表5 经济林按土地权属、产期面积统计表";
            this.B5TJ.UseVisualStyleBackColor = true;
            // 
            // B4_1TJ
            // 
            this.B4_1TJ.AutoSize = true;
            this.B4_1TJ.Location = new System.Drawing.Point(15, 165);
            this.B4_1TJ.Name = "B4_1TJ";
            this.B4_1TJ.Size = new System.Drawing.Size(432, 18);
            this.B4_1TJ.TabIndex = 8;
            this.B4_1TJ.Text = "表4-1 按林木权属、起源、优势树种（组）各龄组面积蓄积统计表";
            this.B4_1TJ.UseVisualStyleBackColor = true;
            // 
            // B4TJ
            // 
            this.B4TJ.AutoSize = true;
            this.B4TJ.Location = new System.Drawing.Point(15, 133);
            this.B4TJ.Name = "B4TJ";
            this.B4TJ.Size = new System.Drawing.Size(418, 18);
            this.B4TJ.TabIndex = 7;
            this.B4TJ.Text = "表4 按土地权属、起源、优势树种（组）各龄组面积蓄积统计表";
            this.B4TJ.UseVisualStyleBackColor = true;
            // 
            // B3_1TJ
            // 
            this.B3_1TJ.AutoSize = true;
            this.B3_1TJ.Location = new System.Drawing.Point(15, 103);
            this.B3_1TJ.Name = "B3_1TJ";
            this.B3_1TJ.Size = new System.Drawing.Size(362, 18);
            this.B3_1TJ.TabIndex = 6;
            this.B3_1TJ.Text = "表3-1 按林木权属、起源、林种各龄组面积蓄积统计表";
            this.B3_1TJ.UseVisualStyleBackColor = true;
            // 
            // B3TJ
            // 
            this.B3TJ.AutoSize = true;
            this.B3TJ.Location = new System.Drawing.Point(15, 75);
            this.B3TJ.Name = "B3TJ";
            this.B3TJ.Size = new System.Drawing.Size(348, 18);
            this.B3TJ.TabIndex = 5;
            this.B3TJ.Text = "表3 按土地权属、起源、林种各龄组面积蓄积统计表";
            this.B3TJ.UseVisualStyleBackColor = true;
            // 
            // B2TJ
            // 
            this.B2TJ.AutoSize = true;
            this.B2TJ.Location = new System.Drawing.Point(15, 47);
            this.B2TJ.Name = "B2TJ";
            this.B2TJ.Size = new System.Drawing.Size(222, 18);
            this.B2TJ.TabIndex = 4;
            this.B2TJ.Text = "表2 地按权属各地类面积统计表";
            this.B2TJ.UseVisualStyleBackColor = true;
            // 
            // B1TJ
            // 
            this.B1TJ.AutoSize = true;
            this.B1TJ.Location = new System.Drawing.Point(15, 20);
            this.B1TJ.Name = "B1TJ";
            this.B1TJ.Size = new System.Drawing.Size(222, 18);
            this.B1TJ.TabIndex = 3;
            this.B1TJ.Text = "表1 按林地类型面积蓄积统计表";
            this.B1TJ.UseVisualStyleBackColor = true;
            // 
            // tabPageBCFYWH
            // 
            this.tabPageBCFYWH.Controls.Add(this.groupBox1);
            this.tabPageBCFYWH.Controls.Add(this.bindingNavigator1);
            this.tabPageBCFYWH.Location = new System.Drawing.Point(4, 24);
            this.tabPageBCFYWH.Name = "tabPageBCFYWH";
            this.tabPageBCFYWH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBCFYWH.Size = new System.Drawing.Size(820, 534);
            this.tabPageBCFYWH.TabIndex = 1;
            this.tabPageBCFYWH.Text = "设置补偿标准";
            this.tabPageBCFYWH.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CurXMMC_label);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.buttonSame);
            this.groupBox1.Controls.Add(this.labelUnit);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.textBoxBZ);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxBCFXMMC);
            this.groupBox1.Controls.Add(this.textBoxBCDJ);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSelBCLX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 503);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "各项补偿费用";
            // 
            // CurXMMC_label
            // 
            this.CurXMMC_label.AutoSize = true;
            this.CurXMMC_label.BackColor = System.Drawing.Color.White;
            this.CurXMMC_label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurXMMC_label.ForeColor = System.Drawing.Color.Red;
            this.CurXMMC_label.Location = new System.Drawing.Point(337, 1);
            this.CurXMMC_label.Name = "CurXMMC_label";
            this.CurXMMC_label.Size = new System.Drawing.Size(84, 14);
            this.CurXMMC_label.TabIndex = 35;
            this.CurXMMC_label.Text = "当前项目名:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonClear);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.textBoxTJBDS);
            this.groupBox6.Location = new System.Drawing.Point(4, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(804, 191);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "设置统计条件";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(595, 13);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(60, 27);
            this.buttonClear.TabIndex = 30;
            this.buttonClear.Text = "清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.FldValueslistBox);
            this.groupBox5.Location = new System.Drawing.Point(349, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(153, 164);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "调查值列表";
            // 
            // FldValueslistBox
            // 
            this.FldValueslistBox.FormattingEnabled = true;
            this.FldValueslistBox.HorizontalScrollbar = true;
            this.FldValueslistBox.ItemHeight = 14;
            this.FldValueslistBox.Location = new System.Drawing.Point(8, 15);
            this.FldValueslistBox.Name = "FldValueslistBox";
            this.FldValueslistBox.Size = new System.Drawing.Size(137, 144);
            this.FldValueslistBox.TabIndex = 28;
            this.FldValueslistBox.DoubleClick += new System.EventHandler(this.FldValueslistBox_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnLike);
            this.groupBox7.Controls.Add(this.btnNot);
            this.groupBox7.Controls.Add(this.btnXYDengyu);
            this.groupBox7.Controls.Add(this.btnXiaoYu);
            this.groupBox7.Controls.Add(this.btnOr);
            this.groupBox7.Controls.Add(this.btnDYDengyu);
            this.groupBox7.Controls.Add(this.btnDayu);
            this.groupBox7.Controls.Add(this.btnAnd);
            this.groupBox7.Controls.Add(this.btnBuDYu);
            this.groupBox7.Controls.Add(this.btnEqual);
            this.groupBox7.Location = new System.Drawing.Point(168, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(175, 166);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "操作符";
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(7, 138);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(69, 27);
            this.btnLike.TabIndex = 25;
            this.btnLike.Text = "包含";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(87, 137);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(82, 27);
            this.btnNot.TabIndex = 26;
            this.btnNot.Text = "不包含";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnXYDengyu
            // 
            this.btnXYDengyu.Location = new System.Drawing.Point(87, 77);
            this.btnXYDengyu.Name = "btnXYDengyu";
            this.btnXYDengyu.Size = new System.Drawing.Size(82, 27);
            this.btnXYDengyu.TabIndex = 21;
            this.btnXYDengyu.Text = "小于等于";
            this.btnXYDengyu.UseVisualStyleBackColor = true;
            this.btnXYDengyu.Click += new System.EventHandler(this.btnXYDengyu_Click);
            // 
            // btnXiaoYu
            // 
            this.btnXiaoYu.Location = new System.Drawing.Point(8, 77);
            this.btnXiaoYu.Name = "btnXiaoYu";
            this.btnXiaoYu.Size = new System.Drawing.Size(69, 27);
            this.btnXiaoYu.TabIndex = 20;
            this.btnXiaoYu.Text = "小于";
            this.btnXiaoYu.UseVisualStyleBackColor = true;
            this.btnXiaoYu.Click += new System.EventHandler(this.btnXiaoYu_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(87, 108);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(82, 27);
            this.btnOr.TabIndex = 23;
            this.btnOr.Text = "或者";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnDYDengyu
            // 
            this.btnDYDengyu.Location = new System.Drawing.Point(87, 46);
            this.btnDYDengyu.Name = "btnDYDengyu";
            this.btnDYDengyu.Size = new System.Drawing.Size(82, 27);
            this.btnDYDengyu.TabIndex = 19;
            this.btnDYDengyu.Text = "大于等于";
            this.btnDYDengyu.UseVisualStyleBackColor = true;
            this.btnDYDengyu.Click += new System.EventHandler(this.btnDYDengyu_Click);
            // 
            // btnDayu
            // 
            this.btnDayu.Location = new System.Drawing.Point(8, 46);
            this.btnDayu.Name = "btnDayu";
            this.btnDayu.Size = new System.Drawing.Size(69, 27);
            this.btnDayu.TabIndex = 18;
            this.btnDayu.Text = "大于";
            this.btnDayu.UseVisualStyleBackColor = true;
            this.btnDayu.Click += new System.EventHandler(this.btnDayu_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(8, 108);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(69, 27);
            this.btnAnd.TabIndex = 22;
            this.btnAnd.Text = "并且";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnBuDYu
            // 
            this.btnBuDYu.Location = new System.Drawing.Point(87, 17);
            this.btnBuDYu.Name = "btnBuDYu";
            this.btnBuDYu.Size = new System.Drawing.Size(82, 27);
            this.btnBuDYu.TabIndex = 17;
            this.btnBuDYu.Text = "不等于";
            this.btnBuDYu.UseVisualStyleBackColor = true;
            this.btnBuDYu.Click += new System.EventHandler(this.btnBuDYu_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(8, 17);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(69, 27);
            this.btnEqual.TabIndex = 16;
            this.btnEqual.Text = "等于";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.FldslistBox);
            this.groupBox8.Location = new System.Drawing.Point(8, 17);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(156, 166);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "调查因子";
            // 
            // FldslistBox
            // 
            this.FldslistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FldslistBox.FormattingEnabled = true;
            this.FldslistBox.HorizontalScrollbar = true;
            this.FldslistBox.ItemHeight = 14;
            this.FldslistBox.Location = new System.Drawing.Point(3, 19);
            this.FldslistBox.Name = "FldslistBox";
            this.FldslistBox.Size = new System.Drawing.Size(150, 144);
            this.FldslistBox.TabIndex = 14;
            this.FldslistBox.SelectedIndexChanged += new System.EventHandler(this.FldslistBox_SelectedIndexChanged);
            this.FldslistBox.DoubleClick += new System.EventHandler(this.FldslistBox_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(512, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "统计条件：";
            // 
            // textBoxTJBDS
            // 
            this.textBoxTJBDS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTJBDS.Location = new System.Drawing.Point(508, 40);
            this.textBoxTJBDS.Multiline = true;
            this.textBoxTJBDS.Name = "textBoxTJBDS";
            this.textBoxTJBDS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTJBDS.Size = new System.Drawing.Size(290, 144);
            this.textBoxTJBDS.TabIndex = 31;
            // 
            // buttonSame
            // 
            this.buttonSame.Location = new System.Drawing.Point(282, 16);
            this.buttonSame.Name = "buttonSame";
            this.buttonSame.Size = new System.Drawing.Size(54, 27);
            this.buttonSame.TabIndex = 6;
            this.buttonSame.Text = "相同";
            this.buttonSame.UseVisualStyleBackColor = true;
            this.buttonSame.Click += new System.EventHandler(this.buttonSame_Click);
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUnit.ForeColor = System.Drawing.Color.Red;
            this.labelUnit.Location = new System.Drawing.Point(731, 22);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(84, 14);
            this.labelUnit.TabIndex = 11;
            this.labelUnit.Text = "(元/平方米)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewBCFInfo);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(3, 269);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 230);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "补偿标准表";
            // 
            // dataGridViewBCFInfo
            // 
            this.dataGridViewBCFInfo.AllowUserToAddRows = false;
            this.dataGridViewBCFInfo.AllowUserToDeleteRows = false;
            this.dataGridViewBCFInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewBCFInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBCFInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBCFInfo.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewBCFInfo.Name = "dataGridViewBCFInfo";
            this.dataGridViewBCFInfo.ReadOnly = true;
            this.dataGridViewBCFInfo.RowTemplate.Height = 23;
            this.dataGridViewBCFInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBCFInfo.Size = new System.Drawing.Size(802, 210);
            this.dataGridViewBCFInfo.TabIndex = 35;
            this.dataGridViewBCFInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBCFInfo_CellClick);
            // 
            // textBoxBZ
            // 
            this.textBoxBZ.Location = new System.Drawing.Point(65, 240);
            this.textBoxBZ.Name = "textBoxBZ";
            this.textBoxBZ.Size = new System.Drawing.Size(743, 23);
            this.textBoxBZ.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "备注：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "与项目：";
            // 
            // comboBoxBCFXMMC
            // 
            this.comboBoxBCFXMMC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBCFXMMC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBCFXMMC.FormattingEnabled = true;
            this.comboBoxBCFXMMC.Location = new System.Drawing.Point(65, 19);
            this.comboBoxBCFXMMC.Name = "comboBoxBCFXMMC";
            this.comboBoxBCFXMMC.Size = new System.Drawing.Size(213, 22);
            this.comboBoxBCFXMMC.TabIndex = 5;
            // 
            // textBoxBCDJ
            // 
            this.textBoxBCDJ.Location = new System.Drawing.Point(633, 18);
            this.textBoxBCDJ.Name = "textBoxBCDJ";
            this.textBoxBCDJ.Size = new System.Drawing.Size(96, 23);
            this.textBoxBCDJ.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "补偿标准：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "费用类型：";
            // 
            // comboBoxSelBCLX
            // 
            this.comboBoxSelBCLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelBCLX.FormattingEnabled = true;
            this.comboBoxSelBCLX.Items.AddRange(new object[] {
            "1-林地补偿费",
            "2-林地安置费",
            "3-林木补偿费",
            "4-植被恢复费"});
            this.comboBoxSelBCLX.Location = new System.Drawing.Point(414, 18);
            this.comboBoxSelBCLX.Name = "comboBoxSelBCLX";
            this.comboBoxSelBCLX.Size = new System.Drawing.Size(124, 22);
            this.comboBoxSelBCLX.TabIndex = 8;
            this.comboBoxSelBCLX.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelBCLX_SelectedIndexChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComBoSelXmmcInBZB,
            this.tlbBrow,
            this.toolStripSeparator1,
            this.tlbDel,
            this.tlbSave,
            this.toolStripSeparator2,
            this.tlbJSFY,
            this.toolStripSeparator4,
            this.toolStripBtnExportXB,
            this.toolStripSeparator3,
            this.tlbExportXLS});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(814, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // ComBoSelXmmcInBZB
            // 
            this.ComBoSelXmmcInBZB.Name = "ComBoSelXmmcInBZB";
            this.ComBoSelXmmcInBZB.Size = new System.Drawing.Size(250, 25);
            this.ComBoSelXmmcInBZB.SelectedIndexChanged += new System.EventHandler(this.ComBoSelXmmcInBZB_SelectedIndexChanged);
            // 
            // tlbBrow
            // 
            this.tlbBrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbBrow.Image = ((System.Drawing.Image)(resources.GetObject("tlbBrow.Image")));
            this.tlbBrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbBrow.Name = "tlbBrow";
            this.tlbBrow.Size = new System.Drawing.Size(23, 22);
            this.tlbBrow.Text = "浏览";
            this.tlbBrow.Click += new System.EventHandler(this.tlbBrow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbDel
            // 
            this.tlbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbDel.Image = ((System.Drawing.Image)(resources.GetObject("tlbDel.Image")));
            this.tlbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbDel.Name = "tlbDel";
            this.tlbDel.Size = new System.Drawing.Size(23, 22);
            this.tlbDel.Text = "删除";
            this.tlbDel.Click += new System.EventHandler(this.tlbDel_Click);
            // 
            // tlbSave
            // 
            this.tlbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbSave.Image = ((System.Drawing.Image)(resources.GetObject("tlbSave.Image")));
            this.tlbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSave.Name = "tlbSave";
            this.tlbSave.Size = new System.Drawing.Size(23, 22);
            this.tlbSave.Text = "保存";
            this.tlbSave.Click += new System.EventHandler(this.tlbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbJSFY
            // 
            this.tlbJSFY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbJSFY.Image = ((System.Drawing.Image)(resources.GetObject("tlbJSFY.Image")));
            this.tlbJSFY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbJSFY.Name = "tlbJSFY";
            this.tlbJSFY.Size = new System.Drawing.Size(23, 22);
            this.tlbJSFY.Text = "计算该项目各项补偿费用";
            this.tlbJSFY.Click += new System.EventHandler(this.tlbJSFY_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnExportXB
            // 
            this.toolStripBtnExportXB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExportXB.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExportXB.Image")));
            this.toolStripBtnExportXB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExportXB.Name = "toolStripBtnExportXB";
            this.toolStripBtnExportXB.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnExportXB.Text = "导出";
            this.toolStripBtnExportXB.ToolTipText = "导出小班表";
            this.toolStripBtnExportXB.Click += new System.EventHandler(this.toolStripBtnExportXB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbExportXLS
            // 
            this.tlbExportXLS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbExportXLS.Image = ((System.Drawing.Image)(resources.GetObject("tlbExportXLS.Image")));
            this.tlbExportXLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbExportXLS.Name = "tlbExportXLS";
            this.tlbExportXLS.Size = new System.Drawing.Size(23, 22);
            this.tlbExportXLS.Text = "导出当前补偿标准表到电子表";
            this.tlbExportXLS.Click += new System.EventHandler(this.tlbExportXLS_Click);
            // 
            // dlgLDZZTJ
            // 
            this.ClientSize = new System.Drawing.Size(828, 562);
            this.Controls.Add(this.tabControlZZY);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "dlgLDZZTJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "林地征用占用附表统计";
            this.Load += new System.EventHandler(this.dlgLDZZTJ_Load);
            this.tabControlZZY.ResumeLayout(false);
            this.tabPageTJ.ResumeLayout(false);
            this.tabPageTJ.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageBCFYWH.ResumeLayout(false);
            this.tabPageBCFYWH.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBCFInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Data.DataTable pDCColTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("dt");
            table.Columns.Add("colname");
            table.Columns.Add("dccolname");
            table.Columns.Add("cname");
            string str = "XIAN,XIANG,CUN,Q_DI_LEI,Q_LD_QS,TDJYQ,LMSYQ,LMJYQ,LDLX,YDZL,YDFW,Q_SEN_LB,SHI_QUAN_D,Q_LIN_ZHONG,QYKZ,LYFQ,";
            str = str + "GJGYL_BHDJ,BH_DJ,ZL_DJ,YOU_SHI_SZ,QI_YUAN,YU_BI_DU,PINGJUN_NL,PINGJUN_XJ,PINGJUN_SG,MEI_GQ_ZS,LING_ZU,JJLCQ,XZWZL,SFTGD";
            string str2 = "县(区),乡(镇),村,前期地类,前期土地权属,林地使用权,林木所有权,林木经营权,林地类型,用地种类,用地范围,前期森林类别,";
            str2 = str2 + "事权级,前期林种,主体功能区,林地功能分区,国家公益林保护等级,林地保护等级,林地质量等级,优势树种," + "起源,郁闭度,平均年龄,平均胸径,平均树高,每公顷株数,龄组,经济林产期,线状物种类,是否退耕地";
            string str3 = "XIAN,XIANG,CUN,DI_LEI,LD_QS,TDJYQ,LMSYQ,LMJYQ,LDLX,YDZL,YDFW,SEN_LIN_LB,SHI_QUAN_D,LIN_ZHONG,QYKZ,LYFQ,";
            str3 = str3 + "GJGYL_BHDJ,BH_DJ,ZL_DJ,SHU_ZHONG,QI_YUAN,YU_BI_DU,PINGJUN_NL,PINGJUN_XJ,PINGJUN_SG,MEI_GQ_ZS,LING_ZU,JJLCQ,XZWZL,SFTGD";
            string str4 = "103,104,105,211,207,208,209,210,258,260,261,214,215,212,227,225,226,216,224,223,219,213,";
            str4 = str4 + "0,0,0,0,0,218,275,249,0";
            string[] strArray = str.Split(new char[] { ',' });
            string[] strArray2 = str2.Split(new char[] { ',' });
            string[] strArray3 = str3.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                row[0] = strArray[i];
                row[1] = strArray3[i];
                row[2] = strArray2[i];
            }
            return table;
        }

        private void SetTxtFocusLocation(string mytxt)
        {
            if (this.textBoxTJBDS.SelectedText.Length > 0)
            {
                this.textBoxTJBDS.SelectedText = "";
            }
            int selectionStart = this.textBoxTJBDS.SelectionStart;
            this.textBoxTJBDS.Text = this.textBoxTJBDS.Text.Insert(selectionStart, mytxt);
            this.textBoxTJBDS.Focus();
            this.textBoxTJBDS.Select(selectionStart + mytxt.Length, 0);
        }

        private void tabControlZZY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlZZY.SelectedIndex == 1)
            {
                this.FldValueslistBox.Items.Clear();
                this.textBoxTJBDS.Text = "";
                this.FldslistBox.SelectedItem = null;
                this.comboBoxSelBCLX.SelectedIndex = 0;
                string text = this.comboBoxSelXMMC.Text;
                Class_ZZYTJ.TABLE_ZZYXMMC = text;
                this.CurXMMC_label.Text = "当前项目名:" + text;
                string cmdtxt = "SELECT DISTINCT XMMC AS XMMC FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE LTRIM(RTRIM(XMMC))>''";
                System.Data.DataTable pTable = this.pClass_ZZYTJ.GetTable(cmdtxt, "xmmcdt");
                if (pTable != null)
                {
                    if (pTable.Rows.Count == 0)
                    {
                        this.ComBoSelXmmcInBZB.ComboBox.DataSource = null;
                    }
                    if (pTable.Rows.Count > 0)
                    {
                        this.pClass_ZZYTJ.BindToolBarComboBox(pTable, this.ComBoSelXmmcInBZB, "XMMC");
                    }
                    this.comboBoxBCFXMMC.Enabled = false;
                    this.buttonSame.Enabled = false;
                    System.Data.DataTable dataTabeBySelRows = this.pClass_ZZYTJ.GetDataTabeBySelRows(pTable, "XMMC<>'" + text + "'");
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        this.pClass_ZZYTJ.BindComboBox(dataTabeBySelRows, this.comboBoxBCFXMMC, "XMMC");
                        this.comboBoxBCFXMMC.Enabled = true;
                        this.buttonSame.Enabled = true;
                    }
                    string str6 = " XIAN,XIANG,CUN,Q_DI_LEI,LDLX,YDZL,YDFW,Q_SEN_LB,SHI_QUAN_D,Q_LIN_ZHONG,YOU_SHI_SZ,";
                    str6 = str6 + "QI_YUAN,YU_BI_DU,PINGJUN_NL,PINGJUN_XJ,PINGJUN_SG,MEI_GQ_ZS,LING_ZU,JJLCQ,XZWZL,SFTGD," + "Q_LD_QS,TDJYQ,LMSYQ,LMJYQ,QYKZ,LYFQ,GJGYL_BHDJ,BH_DJ,ZL_DJ";
                    this.pxmxbtable = this.pClass_ZZYTJ.GetTable("SELECT " + str6 + " FROM " + Class_ZZYTJ.TABLE_ZZYTableName + " WHERE LTRIM(RTRIM(XMMC))='" + text + "'", "dcb");
                    if ((this.pxmxbtable != null) && (text.Trim().Length > 0))
                    {
                        this.pClass_ZZYTJ.GetExecute((" if exists(select name from syscolumns where id=object_id('" + Class_ZZYTJ.TABLE_BCFBZB + "') and name='BCLXBH') ALTER TABLE " + Class_ZZYTJ.TABLE_BCFBZB + "  DROP COLUMN BCLXBH ") + ";" + (" if not exists(select name from syscolumns where id=object_id('" + Class_ZZYTJ.TABLE_BCFBZB + "') and name='BCLXBH1') ALTER TABLE " + Class_ZZYTJ.TABLE_BCFBZB + " ADD BCLXBH1 bigint PRIMARY KEY IDENTITY(1,1) NOT NULL; "));
                        System.Data.DataTable table = this.pClass_ZZYTJ.GetTable((" SELECT * FROM (SELECT TOP 99.999999 PERCENT BCLXBH1 AS 编号,XMMC AS 项目名称,BCLXNAME AS 费用名称, CONVERT(numeric(14, 2), BCDJ) AS 补偿标准, TJBDS AS 统计条件,BZ AS 备注 FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(XMMC))='" + text + "') ORDER BY BCLXCODE) B ") + " UNION ALL " + (" SELECT * FROM (SELECT TOP 99.999999 PERCENT BCLXBH1 AS 编号,XMMC AS 项目名称,BCLXNAME AS 费用名称, CONVERT(numeric(14, 2), BCDJ) AS 补偿标准, TJBDS AS 统计条件,BZ AS 备注 FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(BCLXCODE))='4') ORDER BY BCLXBH1) A  "), "DT");
                        this.dataGridViewBCFInfo.DataSource = null;
                        if ((table != null) && (table.Rows.Count != 0))
                        {
                            this.dataGridViewBCFInfo.DataSource = table;
                            this.dataGridViewBCFInfo.Columns["编号"].Visible = false;
                            this.ComBoSelXmmcInBZB.Text = text;
                        }
                    }
                }
            }
        }

        private void tlbBrow_Click(object sender, EventArgs e)
        {
            string text = this.comboBoxSelXMMC.Text;
            this.ComBoSelXmmcInBZB.Text = text;
            this.CurXMMC_label.Text = "当前项目名:" + text;
            if (text.Trim().Length == 0)
            {
                if (this.dataGridViewBCFInfo.Rows.Count > 0)
                {
                    this.dataGridViewBCFInfo.DataSource = null;
                }
                MessageBox.Show("补偿标准数据库未保存有该项目的数据，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                System.Data.DataTable table = this.pClass_ZZYTJ.GetTable((" SELECT * FROM (SELECT TOP 99.999999 PERCENT BCLXBH1 AS 编号,XMMC AS 项目名称,BCLXNAME AS 费用名称, CONVERT(numeric(14, 2), BCDJ) AS 补偿标准, TJBDS AS 统计条件,BZ AS 备注 FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(XMMC))='" + text + "') ORDER BY BCLXCODE) B ") + " UNION ALL " + (" SELECT * FROM (SELECT TOP 99.999999 PERCENT BCLXBH1 AS 编号,XMMC AS 项目名称,BCLXNAME AS 费用名称, CONVERT(numeric(14, 2), BCDJ) AS 补偿标准, TJBDS AS 统计条件,BZ AS 备注 FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(BCLXCODE))='4') ORDER BY BCLXBH1) A  "), "DT");
                this.dataGridViewBCFInfo.DataSource = null;
                if ((table != null) && (table.Rows.Count != 0))
                {
                    this.dataGridViewBCFInfo.DataSource = table;
                    this.dataGridViewBCFInfo.Columns["编号"].Visible = false;
                    this.FillTextBoxByFirstRow();
                    System.Data.DataTable dataSource = (System.Data.DataTable)this.ComBoSelXmmcInBZB.ComboBox.DataSource;
                    this.ComBoSelXmmcInBZB.Text = text;
                    System.Data.DataTable dataTabeBySelRows = this.pClass_ZZYTJ.GetDataTabeBySelRows(dataSource, "XMMC<>'" + text + "'");
                    if (dataTabeBySelRows == null)
                    {
                        this.comboBoxBCFXMMC.DataSource = null;
                        this.comboBoxBCFXMMC.Enabled = false;
                        this.buttonSame.Enabled = false;
                    }
                    else
                    {
                        if (dataTabeBySelRows.Rows.Count > 0)
                        {
                            this.pClass_ZZYTJ.BindComboBox(dataTabeBySelRows, this.comboBoxBCFXMMC, "XMMC");
                            this.comboBoxBCFXMMC.Enabled = true;
                            this.buttonSame.Enabled = true;
                        }
                        else
                        {
                            this.comboBoxBCFXMMC.DataSource = null;
                            this.comboBoxBCFXMMC.Enabled = false;
                            this.buttonSame.Enabled = false;
                        }
                        MessageBox.Show("数据读取完成，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    if (this.dataGridViewBCFInfo.Rows.Count > 0)
                    {
                        this.dataGridViewBCFInfo.DataSource = null;
                    }
                    MessageBox.Show("数据库没有有效数据，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void tlbDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBCFInfo.RowCount == 0)
            {
                MessageBox.Show("当前数据区没有数据，请先进行浏览，再进行操作！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string text = this.ComBoSelXmmcInBZB.Text;
                List<int> list = new List<int>();
                int cellCount = this.dataGridViewBCFInfo.GetCellCount(DataGridViewElementStates.Selected);
                if (cellCount > 0)
                {
                    for (int i = 0; i < cellCount; i++)
                    {
                        if (this.dataGridViewBCFInfo["费用名称", this.dataGridViewBCFInfo.SelectedCells[i].RowIndex].Value.ToString().Trim() != "植被恢复费")
                        {
                            int item = Convert.ToInt16(this.dataGridViewBCFInfo["编号", this.dataGridViewBCFInfo.SelectedCells[i].RowIndex].Value);
                            if (!list.Contains(item))
                            {
                                list.Add(item);
                            }
                        }
                        else
                        {
                            MessageBox.Show("植被恢复费标准不能删除！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                if ((list.Count > 0) && (MessageBox.Show("是否删除选中行，该操作不可恢复？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    this.Cursor = Cursors.WaitCursor;
                    SqlConnection connection = new SqlConnection(Class_ZZYTJ.M_Str_ConnectionString);
                    connection.Open();
                    int count = list.Count;
                    for (int j = 0; j < list.Count; j++)
                    {
                        new SqlCommand(string.Concat(new object[] { " DELETE FROM ", Class_ZZYTJ.TABLE_BCFBZB, " WHERE BCLXBH1 =", list[j] }), connection).ExecuteNonQuery();
                    }
                    connection.Close();
                    this.Cursor = Cursors.Default;
                    this.bindcboXMMCInBZB();
                    MessageBox.Show("操作完成，共删除" + count.ToString() + "行！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.tlbBrow.PerformClick();
                }
            }
        }

        private void tlbExportXLS_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewBCFInfo.RowCount == 0)
            {
                MessageBox.Show("当前数据区没有数据，请先进行浏览，再进行操作！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.pClass_ZZYTJ.ExportDataGridview(this.dataGridViewBCFInfo);
            }
        }

        private void tlbJSFY_Click(object sender, EventArgs e)
        {
            string text = this.ComBoSelXmmcInBZB.Text;
            if (text.Trim().Length > 0)
            {
                System.Data.DataTable table = null;
                string str3 = " SELECT XMMC,BCLXCODE,BCLXNAME,BCDJ,TJBDS FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE LTRIM(RTRIM(BCLXCODE))=4 AND (LTRIM(RTRIM(XMMC))='') ";
                string cmdtxt = str3 + " UNION ALL SELECT XMMC,BCLXCODE,BCLXNAME, BCDJ, TJBDS FROM " + Class_ZZYTJ.TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(XMMC))='" + text + "')";
                table = this.pClass_ZZYTJ.GetTable(cmdtxt, "jsdt");
                if (table == null)
                {
                    MessageBox.Show("读取数据出错，请与管理员联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    try
                    {
                        if (table.Rows.Count > 0)
                        {
                            string str4 = " UPDATE " + Class_ZZYTJ.TABLE_ZZYTableName + " SET ";
                            string str5 = " LTRIM(RTRIM(XMMC))='" + text + "' AND ";
                            this.Cursor = Cursors.WaitCursor;
                            SqlConnection connection = new SqlConnection(Class_ZZYTJ.M_Str_ConnectionString);
                            connection.Open();
                            new SqlCommand(str4 + " LDBCDJ=0,LDBCF=0,LDAZFDJ=0,LDAZF=0,LMBCDJ=0,LMBCF=0,BCFHJ=0,ZBHFDJ=0,ZBHFF=0,ZFYHJ=0 WHERE LTRIM(RTRIM(XMMC))='" + text + "'", connection).ExecuteNonQuery();
                            foreach (DataRow row in table.Rows)
                            {
                                string str8 = row["BCLXCODE"].ToString().Trim();
                                double num = Convert.ToDouble(row["bcdj"]);
                                string str9 = row["tjbds"].ToString().Trim();
                                switch (str8)
                                {
                                    case "1":
                                        new SqlCommand(string.Concat(new object[] { str4, " LDBCDJ =", num, ",LDBCF=CONVERT(numeric(14,2),", num, "*15*MIAN_JI) WHERE ", str5, str9 }), connection).ExecuteNonQuery();
                                        break;

                                    case "2":
                                        new SqlCommand(string.Concat(new object[] { str4, " LDAZFDJ =", num, ",LDAZF=CONVERT(numeric(14,2),", num, "*15*MIAN_JI) WHERE ", str5, str9 }), connection).ExecuteNonQuery();
                                        break;

                                    case "3":
                                        new SqlCommand(string.Concat(new object[] { str4, " LMBCDJ =", num, ",LMBCF=CONVERT(numeric(14,2),", num, "*15*MIAN_JI) WHERE ", str5, str9 }), connection).ExecuteNonQuery();
                                        break;

                                    case "4":
                                        {
                                            SqlCommand command6 = new SqlCommand(string.Concat(new object[] { str4, " ZBHFDJ =", num * 2.0, ",ZBHFF=CONVERT(numeric(14,2),", num * 2.0, "*10000*MIAN_JI) WHERE ", str5, " (LTRIM(RTRIM(YDFW))='1') AND ", str9 }), connection);
                                            command6.ExecuteNonQuery();
                                            new SqlCommand(string.Concat(new object[] { str4, " ZBHFDJ =", num, ",ZBHFF=CONVERT(numeric(14,2),", num, "*10000*MIAN_JI) WHERE ", str5, " (LTRIM(RTRIM(YDFW))='2') AND ", str9 }), connection).ExecuteNonQuery();
                                            break;
                                        }
                                }
                            }
                            new SqlCommand(str4 + " BCFHJ =LDBCF+LDAZF+LMBCF,ZFYHJ=LDBCF+LDAZF+LMBCF+ZBHFF WHERE LTRIM(RTRIM(XMMC))='" + text + "'", connection).ExecuteNonQuery();
                            connection.Close();
                            this.Cursor = Cursors.Default;
                            MessageBox.Show(text + " 补偿费用计算完成，可以点击输出小班表查看。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("补偿标准表没有可用的数据，请先录入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("补偿费用计算出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择工程项目名称！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ComBoSelXmmcInBZB.Focus();
            }
        }

        private void tlbSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxBCDJ.Text.Trim().Length == 0)
            {
                MessageBox.Show("补偿标准必须填写完整！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.textBoxBCDJ.Focus();
            }
            else
            {
                double result = 0.0;
                if (!double.TryParse(this.textBoxBCDJ.Text.Trim(), out result))
                {
                    MessageBox.Show("补偿标准只能填写数字！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textBoxBCDJ.Focus();
                }
                else if (this.textBoxTJBDS.Text.Trim().Length == 0)
                {
                    MessageBox.Show("统计表达式必须填写完整！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textBoxTJBDS.Focus();
                }
                else
                {
                    string text = this.comboBoxSelBCLX.Text;
                    if (text.Trim() == "4-植被恢复费")
                    {
                        MessageBox.Show("植被恢复费不需要修改保存！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        string[] strArray = text.Split(new char[] { '-' });
                        string str2 = " WHERE (XMMC='" + this.comboBoxSelXMMC.Text + "' AND BCLXCODE='" + strArray[0] + "' AND TJBDS='" + this.textBoxTJBDS.Text.Replace("'", "''") + "')";
                        string sql = "SELECT XMMC FROM " + Class_ZZYTJ.TABLE_BCFBZB + str2;
                        if (this.pClass_ZZYTJ.intRecordsInTable(sql) > 0)
                        {
                            if (MessageBox.Show("数据库已存在该补偿标准，是否更新？\n\r该操作不可恢复！", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string str7 = this.dataGridViewBCFInfo.Rows[this.dataGridViewBCFInfo.CurrentCell.RowIndex].Cells[0].Value.ToString();
                                object obj3 = " UPDATE " + Class_ZZYTJ.TABLE_BCFBZB + " SET XMMC='" + this.comboBoxSelXMMC.Text + "',BCLXCODE='" + strArray[0] + "', BCLXNAME='" + strArray[1] + "',";
                                string cmdtxt = string.Concat(new object[] { obj3, "BCDJ=", result, ", TJBDS='", this.textBoxTJBDS.Text.Trim().Replace("'", "''"), "',BZ ='", this.textBoxBZ.Text.Trim(), "' WHERE BCLXBH1=", str7 });
                                if (!this.pClass_ZZYTJ.GetExecute(cmdtxt))
                                {
                                    MessageBox.Show("数据保存出错，请与管理员联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                                else
                                {
                                    MessageBox.Show("数据已成功保存到数据库！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    this.bindcboXMMCInBZB();
                                    this.ComBoSelXmmcInBZB.Text = this.comboBoxSelXMMC.Text;
                                    if (this.ComBoSelXmmcInBZB.Text.Trim().Length > 0)
                                    {
                                        this.tlbBrow.PerformClick();
                                    }
                                }
                            }
                        }
                        else
                        {
                            string s = this.pClass_ZZYTJ.pGetReaderStr(" SELECT MAX(BCLXBH1) + 1 FROM " + Class_ZZYTJ.TABLE_BCFBZB);
                            int num3 = 0;
                            int.TryParse(s, out num3);
                            object obj2 = " INSERT INTO " + Class_ZZYTJ.TABLE_BCFBZB + "(BCLXCODE,BCLXNAME,BCDJ,TJBDS,XMMC,BCBZJLND,BZ,XIAN) VALUES(";
                            string str6 = string.Concat(new object[] { obj2, "'", strArray[0], "','", strArray[1], "', ", result, ",'", this.textBoxTJBDS.Text.Trim().Replace("'", "''"), "'," });
                            string str5 = str6 + "'" + this.comboBoxSelXMMC.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + this.textBoxBZ.Text.Trim() + "','') ";
                            if (this.pClass_ZZYTJ.GetExecute(str5))
                            {
                                MessageBox.Show("数据已成功保存到数据库！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.bindcboXMMCInBZB();
                                this.ComBoSelXmmcInBZB.Text = this.comboBoxSelXMMC.Text;
                                if (this.ComBoSelXmmcInBZB.Text.Trim().Length > 0)
                                {
                                    this.tlbBrow.PerformClick();
                                }
                            }
                            else
                            {
                                MessageBox.Show("数据保存出错，请与管理员联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置补偿标准--导出小班表的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnExportXB_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = this.pClass_ZZYTJ.GetTable("SELECT DISTINCT YDZL AS YDZL FROM " + Class_ZZYTJ.TABLE_ZZYTableName + " WHERE LTRIM(RTRIM(XMMC))='" + Class_ZZYTJ.TABLE_ZZYXMMC + "' ORDER BY YDZL DESC", "xmydzldt");
            if (table == null)
            {
                MessageBox.Show("获取项目用地种类信息出错，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("获取项目没有有效调查数据，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DataSet tjds = new DataSet("csyd");
            DataSet set2 = new DataSet("lsyd");
            foreach (DataRow row in table.Rows)
            {
                switch (row[0].ToString())
                {
                    case "2":
                        {
                            System.Data.DataTable table3 = this.pClass_ZZYTJ.JSSXFYJSB("2");
                            if (table3 != null)
                            {
                                tjds.Tables.Add(table3);
                            }
                            break;
                        }
                    case "1":
                        {
                            System.Data.DataTable table2 = this.pClass_ZZYTJ.JSSXFYJSB("1");
                            if (table2 != null)
                            {
                                set2.Tables.Add(table2);
                            }
                            break;
                        }
                }
            }
            string destFileName = "";
            string str3 = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string sourceFileName = System.Windows.Forms.Application.StartupPath + @"\四项费用计算结果表.xls";
            destFileName = dialog.SelectedPath + @"\四项费用计算结果表_长期用地_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            str3 = dialog.SelectedPath + @"\四项费用计算结果表_临时用地_" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            if ((tjds.Tables.Count > 0) && (set2.Tables.Count == 0))
            {
                File.Copy(sourceFileName, destFileName, true);
                if (!File.Exists(destFileName))
                {
                    MessageBox.Show("不能生成文件 " + destFileName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.pClass_ZZYTJ.SaveSXFYXBTABLE(Class_ZZYTJ.TABLE_ZZYXMMC, tjds, sourceFileName, destFileName);
                MessageBox.Show("四项费用计算结果表已保存到：" + destFileName + "，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Microsoft.Office.Interop.Excel.Application application2 = new ApplicationClass();
                try
                {
                    if (application2 == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装Office。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    object updateLinks = Missing.Value;
                    application2.Workbooks.Open(destFileName, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                    application2.Visible = true;
                }
                catch (Exception exception3)
                {
                    MessageBox.Show("填充电子表出错，错误：" + exception3.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                finally
                {
                    new Process();
                    Process[] processesByName = Process.GetProcessesByName("EXCEL");
                    try
                    {
                        foreach (Process process2 in processesByName)
                        {
                            IntPtr mainWindowHandle = process2.MainWindowHandle;
                            if (string.IsNullOrEmpty(process2.MainWindowTitle))
                            {
                                process2.Kill();
                            }
                        }
                    }
                    catch (Exception exception4)
                    {
                        exception4.ToString();
                    }
                    GC.Collect();
                }
            }
            if ((tjds.Tables.Count == 0) && (set2.Tables.Count > 0))
            {
                File.Copy(sourceFileName, str3, true);
                if (!File.Exists(str3))
                {
                    MessageBox.Show("不能生成文件 " + str3, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    this.pClass_ZZYTJ.SaveSXFYXBTABLE(Class_ZZYTJ.TABLE_ZZYXMMC, set2, sourceFileName, str3);
                    MessageBox.Show("四项费用计算结果表已保存到：" + str3 + "，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Microsoft.Office.Interop.Excel.Application application3 = new ApplicationClass();
                    try
                    {
                        try
                        {
                            if (application3 == null)
                            {
                                MessageBox.Show("不能建立EXCEL对象，请在机器上安装Office。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            object obj4 = Missing.Value;
                            application3.Workbooks.Open(str3, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4, obj4);
                            application3.Visible = true;
                        }
                        catch (Exception exception5)
                        {
                            MessageBox.Show("填充电子表出错，错误：" + exception5.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        goto Label_04BB;
                    }
                    finally
                    {
                        new Process();
                        Process[] processArray5 = Process.GetProcessesByName("EXCEL");
                        try
                        {
                            foreach (Process process3 in processArray5)
                            {
                                IntPtr ptr2 = process3.MainWindowHandle;
                                if (string.IsNullOrEmpty(process3.MainWindowTitle))
                                {
                                    process3.Kill();
                                }
                            }
                        }
                        catch (Exception exception6)
                        {
                            exception6.ToString();
                        }
                        GC.Collect();
                    }
                }
                return;
            }
        Label_04BB:
            if ((tjds.Tables.Count > 0) && (set2.Tables.Count > 0))
            {
                File.Copy(sourceFileName, destFileName, true);
                File.Copy(sourceFileName, str3, true);
                if (!File.Exists(destFileName) && !File.Exists(str3))
                {
                    MessageBox.Show("不能生成统计文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                this.pClass_ZZYTJ.SaveSXFYXBTABLE(Class_ZZYTJ.TABLE_ZZYXMMC, tjds, sourceFileName, destFileName);
                this.pClass_ZZYTJ.SaveSXFYXBTABLE(Class_ZZYTJ.TABLE_ZZYXMMC, set2, sourceFileName, str3);
                MessageBox.Show("统计完成，共生成2个文件，请查看：" + destFileName + "\n\r" + str3, "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                object obj2 = Missing.Value;
                try
                {
                    application.Workbooks.Open(destFileName, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2);
                    application.Workbooks.Open(str3, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2, obj2);
                    application.Visible = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "打开EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    new Process();
                    Process[] processArray = Process.GetProcessesByName("Excel");
                    try
                    {
                        foreach (Process process in processArray)
                        {
                            IntPtr ptr3 = process.MainWindowHandle;
                            if (string.IsNullOrEmpty(process.MainWindowTitle))
                            {
                                process.Kill();
                            }
                        }
                    }
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
            if ((tjds.Tables.Count == 0) && (set2.Tables.Count == 0))
            {
                MessageBox.Show("没有有效数据，请检查调查表用地种类是否填写完整！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// 设置窗体查询的图层
        /// </summary>
        public string ZZYTableName
        {
            set
            {
                this.pzzytablename = value;
            }
        }
    }
}

