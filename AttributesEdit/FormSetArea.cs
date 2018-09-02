namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class FormSetArea : FormBase3
    {
        private CheckEdit checkEdit1;
        private IContainer components;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private Label label1;
        internal Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label labelArea0;
        private Label labelMess;
        private LabelControl labelRefresh;
      
        private IHookHelper m_hookHelper;
        private string m_KindCode = "";
        private string m_TableName = "";
        private const string mClassName = "AttributesEdit.FormSetArea";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel10;
        private Panel panel12;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private PanelControl panelBar2;
        private Panel panelHDMJ;
        private Panel panelSubmit;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButtonOK;
        private SimpleButton simpleButtonOK2;
        private SpinEdit spinEdit1;
        private Thread thread;

        public FormSetArea()
        {
            this.InitializeComponent();
        }

        private void CallBack()
        {
            if (!base.InvokeRequired)
            {
                this.RefreshArea();
                this.panelBar2.Visible = false;
            }
            else
            {
                base.Invoke(new ThreadStart(this.CallBack));
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit1.Checked)
            {
                this.panelHDMJ.Enabled = true;
            }
            else
            {
                this.panelHDMJ.Enabled = false;
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

        private void ExportThread()
        {
            if (this.checkEdit1.Checked)
            {
                this.SetHDArea();
            }
            else
            {
                this.SetSubArea();
            }
            GC.Collect();
            this.CallBack();
        }

        private void FormSetArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.thread != null) && this.thread.IsAlive)
            {
                this.thread.Abort();
                this.thread.Join();
                this.thread = null;
            }
        }

        public void Init(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
                this.panel1.Visible = true;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSetArea));
            this.panel1 = new Panel();
            this.labelMess = new Label();
            this.panelSubmit = new Panel();
            this.simpleButtonOK = new SimpleButton();
            this.panel2 = new Panel();
            this.panel3 = new Panel();
            this.panelBar2 = new PanelControl();
            this.label2 = new Label();
            this.panel5 = new Panel();
            this.panel6 = new Panel();
            this.checkEdit1 = new CheckEdit();
            this.panelHDMJ = new Panel();
            this.spinEdit1 = new SpinEdit();
            this.panel7 = new Panel();
            this.panel8 = new Panel();
            this.label4 = new Label();
            this.label3 = new Label();
            this.labelArea0 = new Label();
            this.labelRefresh = new LabelControl();
            this.label1 = new Label();
            this.panel4 = new Panel();
            this.simpleButtonOK2 = new SimpleButton();
            this.groupControl1 = new GroupControl();
            this.groupControl2 = new GroupControl();
            this.groupControl3 = new GroupControl();
            this.panel9 = new Panel();
            this.panel10 = new Panel();
            this.label5 = new Label();
            this.panel12 = new Panel();
            this.simpleButton1 = new SimpleButton();
            this.panel1.SuspendLayout();
            this.panelSubmit.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelBar2.BeginInit();
            this.panelBar2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.checkEdit1.Properties.BeginInit();
            this.panelHDMJ.SuspendLayout();
            this.spinEdit1.Properties.BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupControl3.BeginInit();
            this.groupControl3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.labelMess);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(10, 0, 10, 0);
            this.panel1.Size = new Size(0x171, 0x26);
            this.panel1.TabIndex = 0;
            this.labelMess.Location = new Point(11, 6);
            this.labelMess.Name = "labelMess";
            this.labelMess.Size = new Size(0x15a, 0x1b);
            this.labelMess.TabIndex = 1;
            this.labelMess.Text = "    对年度小班所有数据，计算线状物面积与有效面积。";
            this.labelMess.TextAlign = ContentAlignment.MiddleLeft;
            this.panelSubmit.Controls.Add(this.simpleButtonOK);
            this.panelSubmit.Dock = DockStyle.Bottom;
            this.panelSubmit.Location = new Point(0, 0x3e);
            this.panelSubmit.Name = "panelSubmit";
            this.panelSubmit.Size = new Size(0x171, 0x24);
            this.panelSubmit.TabIndex = 1;
            this.simpleButtonOK.Location = new Point(0x10a, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x40, 0x17);
            this.simpleButtonOK.TabIndex = 1;
            this.simpleButtonOK.Text = "计算";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panel2.BackColor = Color.Transparent;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panelSubmit);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(2, 0x17);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(0, 5, 0, 0);
            this.panel2.Size = new Size(0x171, 0x62);
            this.panel2.TabIndex = 0;
            this.panel3.BackColor = Color.Transparent;
            this.panel3.Controls.Add(this.panelBar2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(2, 0x17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x171, 0x95);
            this.panel3.TabIndex = 0;
            this.panelBar2.BorderStyle = BorderStyles.NoBorder;
            this.panelBar2.Controls.Add(this.label2);
            this.panelBar2.Dock = DockStyle.Bottom;
            this.panelBar2.Location = new Point(0, 0x48);
            this.panelBar2.Name = "panelBar2";
            this.panelBar2.Size = new Size(0x171, 0x25);
            this.panelBar2.TabIndex = 13;
            this.panelBar2.Visible = false;
            this.label2.BackColor = Color.Transparent;
            this.label2.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.label2.Image = (Image)resources.GetObject("label2.Image");
            this.label2.ImageAlign = ContentAlignment.MiddleLeft;
            this.label2.Location = new Point(0x5f, 13);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xd7, 0x13);
            this.label2.TabIndex = 13;
            this.label2.Text = "      正在平差，请稍候...";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x171, 0x63);
            this.panel5.TabIndex = 3;
            this.panel6.Controls.Add(this.checkEdit1);
            this.panel6.Controls.Add(this.panelHDMJ);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new Point(0, 0x44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new Size(0x171, 30);
            this.panel6.TabIndex = 9;
            this.panel6.Visible = false;
            this.checkEdit1.Location = new Point(0x1f, 6);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "有核定面积";
            this.checkEdit1.Size = new Size(0x58, 0x13);
            this.checkEdit1.TabIndex = 7;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.panelHDMJ.Controls.Add(this.spinEdit1);
            this.panelHDMJ.Location = new Point(130, 0);
            this.panelHDMJ.Name = "panelHDMJ";
            this.panelHDMJ.Size = new Size(0xb0, 30);
            this.panelHDMJ.TabIndex = 8;
            int[] bits = new int[4];
            this.spinEdit1.EditValue = new decimal(bits);
            this.spinEdit1.Location = new Point(3, 4);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit1.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            this.spinEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            int[] numArray2 = new int[4];
            numArray2[0] = 0x5f5e100;
            this.spinEdit1.Properties.MaxValue = new decimal(numArray2);
            this.spinEdit1.Size = new Size(120, 0x15);
            this.spinEdit1.TabIndex = 2;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.labelArea0);
            this.panel7.Controls.Add(this.labelRefresh);
            this.panel7.Dock = DockStyle.Top;
            this.panel7.Location = new Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(0x171, 0x44);
            this.panel7.TabIndex = 10;
            this.panel8.Controls.Add(this.label4);
            this.panel8.Location = new Point(9, 0x25);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(0x15d, 0x1c);
            this.panel8.TabIndex = 2;
            this.label4.Dock = DockStyle.Fill;
            this.label4.Location = new Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x15d, 0x1c);
            this.label4.TabIndex = 1;
            this.label4.Text = "如果县界与本底相比有变，则不必执行面积平差。";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(10, 15);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x5b, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前面积总和：";
            this.labelArea0.AutoSize = true;
            this.labelArea0.Location = new Point(130, 0x11);
            this.labelArea0.Name = "labelArea0";
            this.labelArea0.Size = new Size(0x1c, 14);
            this.labelArea0.TabIndex = 3;
            this.labelArea0.Text = "111";
            this.labelRefresh.Appearance.Image = (Image)resources.GetObject("labelRefresh.Appearance.Image");
            this.labelRefresh.Cursor = Cursors.Hand;
            this.labelRefresh.ImageAlignToText = ImageAlignToText.LeftTop;
            this.labelRefresh.Location = new Point(0x62, 12);
            this.labelRefresh.Name = "labelRefresh";
            this.labelRefresh.Size = new Size(0x15, 20);
            this.labelRefresh.TabIndex = 6;
            this.labelRefresh.ToolTip = "刷新";
            this.labelRefresh.Click += new EventHandler(this.labelRefresh_Click);
            this.label1.AutoSize = true;
            this.label1.Image = (Image)resources.GetObject("label1.Image");
            this.label1.Location = new Point(0xa4, 0x36);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0, 14);
            this.label1.TabIndex = 5;
            this.panel4.Controls.Add(this.simpleButtonOK2);
            this.panel4.Dock = DockStyle.Bottom;
            this.panel4.Location = new Point(0, 0x6d);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(0x171, 40);
            this.panel4.TabIndex = 2;
            this.simpleButtonOK2.Location = new Point(0x10a, 9);
            this.simpleButtonOK2.Name = "simpleButtonOK2";
            this.simpleButtonOK2.Size = new Size(0x3b, 0x17);
            this.simpleButtonOK2.TabIndex = 1;
            this.simpleButtonOK2.Text = "平差";
            this.simpleButtonOK2.Click += new EventHandler(this.simpleButtonOK2_Click);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Dock = DockStyle.Top;
            this.groupControl1.Location = new Point(0, 0x11f);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x175, 0x7b);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "面积重算";
            this.groupControl2.Controls.Add(this.panel3);
            this.groupControl2.Dock = DockStyle.Top;
            this.groupControl2.Location = new Point(0, 0x71);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0x175, 0xae);
            this.groupControl2.TabIndex = 0x10;
            this.groupControl2.Text = "面积平差";
            this.groupControl3.Controls.Add(this.panel9);
            this.groupControl3.Dock = DockStyle.Top;
            this.groupControl3.Location = new Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new Size(0x175, 0x71);
            this.groupControl3.TabIndex = 0x11;
            this.groupControl3.Text = "清除线状物";
            this.panel9.BackColor = Color.Transparent;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Dock = DockStyle.Fill;
            this.panel9.Location = new Point(2, 0x17);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new Padding(0, 5, 0, 0);
            this.panel9.Size = new Size(0x171, 0x58);
            this.panel9.TabIndex = 0;
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = DockStyle.Top;
            this.panel10.Location = new Point(0, 5);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new Padding(10, 0, 10, 0);
            this.panel10.Size = new Size(0x171, 0x26);
            this.panel10.TabIndex = 0;
            this.label5.Dock = DockStyle.Fill;
            this.label5.Location = new Point(10, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x15d, 0x26);
            this.label5.TabIndex = 2;
            this.label5.Text = "    对变化班块（除自然增长外），清除其线状物种类、线状物长度、线状物宽度、线状物面积的值。";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            this.panel12.Controls.Add(this.simpleButton1);
            this.panel12.Dock = DockStyle.Bottom;
            this.panel12.Location = new Point(0, 0x34);
            this.panel12.Name = "panel12";
            this.panel12.Size = new Size(0x171, 0x24);
            this.panel12.TabIndex = 1;
            this.simpleButton1.Location = new Point(0x10a, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x40, 0x17);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "清除";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x175, 0x198);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.groupControl3);
            base.Controls.Add(this.groupControl2);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormSetArea";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "面积平差";
            base.FormClosing += new FormClosingEventHandler(this.FormSetArea_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panelSubmit.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelBar2.EndInit();
            this.panelBar2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.checkEdit1.Properties.EndInit();
            this.panelHDMJ.ResumeLayout(false);
            this.spinEdit1.Properties.EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl3.EndInit();
            this.groupControl3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public bool InitLayerArea(object hook)
        {
            if (hook == null)
            {
                return false;
            }
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
            string str = EditTask.KindCode.Substring(0, 2);
            this.m_KindCode = str;
            this.panel1.Visible = true;
            if (this.m_KindCode == "08")
            {
          
                IFeatureLayer editLayer = EditTask.EditLayer;
                if (editLayer == null)
                {
                    return false;
                }
                IFeatureClass featureClass = editLayer.FeatureClass;
                if (featureClass == null)
                {
                    return false;
                }
                IDataset dataset = featureClass as IDataset;
                this.m_TableName = dataset.Name;
                this.RefreshArea();
                this.panelHDMJ.Enabled = false;
            }
            return true;
        }

        private void labelRefresh_Click(object sender, EventArgs e)
        {
            this.labelArea0.Text = "";
            this.RefreshArea();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void RefreshArea()
        {
            string sCmdText = "select sum(mian_ji) from " + this.m_TableName;
            string str2 = this.ExecuteNonQuery(sCmdText).ToString();
            this.labelArea0.Text = Math.Round(Convert.ToDouble(str2), 2).ToString();
        }

        private void SetHDArea()
        {
            try
            {
                decimal num = Math.Round(this.spinEdit1.Value, 2);
                if (num <= 0M)
                {
                    MessageBox.Show("请输入核定面积和！", "提示");
                }
                else
                {
                    this.RefreshArea();
                    decimal num2 = Math.Round(Convert.ToDecimal(this.labelArea0.Text), 2);
                    if (num2 == num)
                    {
                        MessageBox.Show("核定面积和与当前面积和相同，无需平差！", "提示");
                    }
                    else
                    {
                        string sCmdText = string.Concat(new object[] { "update ", this.m_TableName, " set mian_ji=mian_ji*", num / num2 });
                        if (this.ExecuteNonQuery(sCmdText) < 0)
                        {
                            MessageBox.Show("平差失败！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("平差完成！", "提示");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetArea", "SetHDArea", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetSubArea()
        {
            try
            {
                string taskYear = EditTask.TaskYear;
                int num = Convert.ToInt16(taskYear) - 1;
                string str2 = this.m_TableName.Substring(0, this.m_TableName.LastIndexOf("_") + 1) + num.ToString();
                string sql = "";
                string str4 = "cun+lin_ban+right(XI_BAN,len(XI_BAN)-charindex('-',XI_BAN))";
                string str8 = sql + "select queryTemp1.xb1,queryTemp1.mj-queryTemp2.mj from (" + "select xb2,sum(mian_ji) as mj from (";
                sql = (((str8 + "select " + str4 + " as xb2,mian_ji from " + this.m_TableName + " where xi_ban like '%-%'") + ") as QUERYRESULT group by xb2" + ") as queryTemp2,(") + "select cun+lin_ban+xiao_ban as xb1,mian_ji as mj from " + str2) + ") as queryTemp1 where queryTemp2.xb2=queryTemp1.xb1 and queryTemp1.mj<>queryTemp2.mj";
                DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                if ((dataTable == null) || (dataTable.Rows.Count < 1))
                {
                    MessageBox.Show(string.Concat(new object[] { "数据库中", num, "年度与", taskYear, "年度总面积相等，无需平差！" }));
                }
                else
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string str6 = dataTable.Rows[i][0].ToString();
                        object obj2 = dataTable.Rows[i][1];
                        if (obj2 != null)
                        {
                            double num3 = Convert.ToDouble(obj2.ToString());
                            if (num3 != 0.0)
                            {
                                sql = string.Concat(new object[] { "update ", this.m_TableName, " set MIAN_JI=MIAN_JI+(", num3, ") where objectid=(select top 1 objectid from ", this.m_TableName, " where ", str4, "='", str6, "')" });
                                this.ExecuteNonQuery(sql);
                            }
                        }
                    }
                    MessageBox.Show("平差完成！", "提示");
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetArea", "SetSubArea", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("平差失败！", "提示");
            }
        }
        public MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        private int ExecuteNonQuery(string sSql)
        {
            try
            {
                return MDM.UpdateDB(sSql) ? 1 : -1;
            }
            catch
            {
                return -1;
            }
        }
        private void SetYXArea()
        {
            try
            {
                string sCmdText = "";
                sCmdText = "update " + this.m_TableName + " set xzwmj = cast((xzwcd * xzwkd)/cast(10000 as float) as decimal(8,1))";
                this.ExecuteNonQuery(sCmdText);
                sCmdText = "update " + this.m_TableName + " set xzwmj=0 where xzwmj is null";
                this.ExecuteNonQuery(sCmdText);
                string str2 = "MIAN_JI-(case when XZWMJ is null then 0 else XZWMJ end)";
                sCmdText = "update " + this.m_TableName + " set YXMJ=" + str2;
                this.ExecuteNonQuery(sCmdText);
                sCmdText = "select count(*) from  " + this.m_TableName + " where " + str2 + "<0.067";
                int num = Convert.ToInt32(this.ExecuteNonQuery(sCmdText).ToString());
                if (num > 0)
                {
                    MessageBox.Show("面积重算完成。有" + num + "个班块的有效面积无效！请至逻辑校验中进行校验修改。", "提示");
                }
                else
                {
                    MessageBox.Show("面积重算完成！", "提示");
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetArea", "SetYXArea", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("面积重算失败！", "提示");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string sCmdText = "update " + this.m_TableName + " set xzwzl=null,xzwcd=0,xzwkd=0,xzwmj=0 where LTRIM(RTRIM(BHYY))<>'' and BHYY<>'80' and (BHYY is not null)";
                this.ExecuteNonQuery(sCmdText);
                MessageBox.Show("清除线状物字段值完成！", "提示");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormSetArea", "simpleButton1_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("清除线状物字段值失败！", "提示");
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.SetYXArea();
        }

        private void simpleButtonOK2_Click(object sender, EventArgs e)
        {
            if (DialogResult.No != MessageBox.Show("县界变化的区县不需要进行面积平差，是否继续？", "提示", MessageBoxButtons.YesNo))
            {
                this.panelBar2.Visible = true;
                Application.DoEvents();
                this.thread = new Thread(new ThreadStart(this.ExportThread));
                this.thread.IsBackground = true;
                this.thread.SetApartmentState(ApartmentState.STA);
                this.thread.Start();
            }
        }
    }
}

