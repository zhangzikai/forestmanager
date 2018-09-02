namespace AttributesEdit
{
    using ConSQLServerInfo;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 复制采伐班块窗体
    /// </summary>
    public class FormCopyHarvest : FormBase3
    {
        private CheckEdit checkEditDist;
        private CheckEdit checkEditTime;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVill;
        private IContainer components;
        private DateEdit dateEnd;
        private DateEdit dateStart;
        private Label label1;
        private LabelControl labelControl2;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private bool m_bInitDist;
        private string m_Code = "";

        private IHookHelper m_hookHelper;
        private const string mClassName = "AttributesEdit.FormCopyHarvest";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel2;
        private Panel panel3;
        private PanelControl panelControl1;
        private PanelControl panelDist;
        private PanelControl panelTime;
        private SimpleButton simpleButtonCopy;

        /// <summary>
        /// 复制采伐班块窗体：构造器
        /// </summary>
        public FormCopyHarvest()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 区划框选中状态的改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEditDist_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditDist.Checked)
            {
                this.panelDist.Enabled = true;
                if (!this.m_bInitDist)
                {
                    this.InitDist();
                }
            }
            else
            {
                this.panelDist.Enabled = false;
                this.m_Code = "";
            }
        }

        /// <summary>
        /// 事件框选中状态的改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEditTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditTime.Checked)
            {
                this.panelTime.Enabled = true;
            }
            else
            {
                this.panelTime.Enabled = false;
            }
        }

        /// <summary>
        /// 城镇下拉框下标改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxVill.Properties.Items.Clear();
            if (this.comboBoxTown.SelectedIndex != 0)
            {
                IList<string> tag = (IList<string>)this.comboBoxTown.Tag;
                string str = tag[this.comboBoxTown.SelectedIndex];
                this.m_Code = str;

                string sql = "select CCODE,CNAME from T_SYS_META_CODE where PCODE='" + str + "'";
                ///DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);

                #region 获取数据
                DataTable dataTable = GetDataTable(sql);
                #endregion

                if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                {
                    IList<string> list2 = new List<string> { "" };
                    this.comboBoxVill.Properties.Items.Add("--");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        list2.Add(dataTable.Rows[i]["CCODE"].ToString());
                        this.comboBoxVill.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                    }
                    this.comboBoxVill.Tag = list2;
                    if (list2.Count == 2)
                    {
                        this.comboBoxVill.SelectedIndex = 1;
                    }
                    else
                    {
                        this.comboBoxVill.SelectedIndex = 0;
                    }
                }

            }
        }

        /// <summary>
        /// 获取SQLServer数据库中的“乡”和“村”
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataTable GetDataTable(string sql)
        {
            DataTable table2 = null;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConnectionSQLServerString.Get_M_Str_ConnectionString();
                SqlCommand selectCommand = new SqlCommand(conn.ConnectionString);
                selectCommand = conn.CreateCommand();
                selectCommand.CommandText = sql;
                selectCommand.CommandTimeout = 60;

                System.Data.DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table2;
        }

        /// <summary>
        /// 乡村下拉框下标改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxVill.SelectedIndex == 0)
            {
                IList<string> tag = (IList<string>)this.comboBoxTown.Tag;
                this.m_Code = tag[this.comboBoxTown.SelectedIndex];
            }
            else
            {
                IList<string> list2 = (IList<string>)this.comboBoxVill.Tag;
                string str = list2[this.comboBoxVill.SelectedIndex];
                this.m_Code = str;
            }
        }

        /// <summary>
        /// 复制成果
        /// </summary>
        private void CopyHarvest()
        {
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            string sLayerName = configOpt.GetConfigValue2("Afforest", "CFLayerName");
            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.ActiveView.FocusMap as IBasicMap, sLayerName, true);
            if (layer == null)
            {
                MessageBox.Show("没找到采伐图层，无法复制！", "提示");
            }
            else
            {
                IFeatureClass featureClass = layer.FeatureClass;
                if (featureClass == null)
                {
                    MessageBox.Show("没找到采伐数据，无法复制！", "提示");
                }
                else
                {
                    IFeatureClass pAffFClass = EditTask.EditLayer.FeatureClass;
                    if (pAffFClass != null)
                    {
                        string sFieldName = configOpt.GetConfigValue2("Afforest", "CopyField");
                        string str6 = configOpt.GetConfigValue2("Afforest", "CopyWhere");
                        string str3 = str6 + " and (" + sFieldName + "<>'1' or " + sFieldName + " is null)";
                        if (this.m_Code != "")
                        {
                            if (this.m_Code.Length == 9)
                            {
                                str3 = str3 + " and (XIANG='" + this.m_Code + "')";
                            }
                            else if (this.m_Code.Length == 12)
                            {
                                str3 = str3 + " and (CUN='" + this.m_Code + "')";
                            }
                        }
                        if (this.checkEditTime.Checked)
                        {
                            string s = this.dateStart.DateTime.ToString("yyyyMMdd");
                            string str5 = this.dateEnd.DateTime.ToString("yyyyMMdd");
                            if (int.Parse(s) > int.Parse(str5))
                            {
                                MessageBox.Show("更新时间设置错误！", "提示");
                                return;
                            }
                            string str7 = str3;
                            str3 = str7 + " and (GXSJ>=" + s + " and GXSJ<=" + str5 + ")";
                        }
                        IQueryFilter filter = new QueryFilterClass
                        {
                            WhereClause = str3
                        };
                        IFeatureCursor cursor = featureClass.Search(filter, false);
                        if (cursor != null)
                        {
                            IFeature pSrcFeature = cursor.NextFeature();
                            if (pSrcFeature == null)
                            {
                                MessageBox.Show("无满足条件的采伐班块可复制！", "提示");
                            }
                            else
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                try
                                {
                                    Editor.UniqueInstance.StartEditOperation();
                                    int num = 0;
                                    while (pSrcFeature != null)
                                    {
                                        this.CreateNewFeature(pAffFClass, pSrcFeature);
                                        DataFuncs.UpdateField(pSrcFeature, sFieldName, "1");
                                        pSrcFeature.Store();
                                        num++;
                                        pSrcFeature = cursor.NextFeature();
                                    }
                                    Editor.UniqueInstance.StopEditOperation();
                                    MessageBox.Show("复制成功完成！共复制班块" + num + "个。", "提示");
                                    this.m_hookHelper.ActiveView.Refresh();
                                }
                                catch (Exception exception)
                                {
                                    Editor.UniqueInstance.AbortEditOperation();
                                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormCopyHarvest", "CopyHarvest", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                                    MessageBox.Show("复制失败！", "提示");
                                }
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建新的要素
        /// </summary>
        /// <param name="pAffFClass"></param>
        /// <param name="pSrcFeature"></param>
        private void CreateNewFeature(IFeatureClass pAffFClass, IFeature pSrcFeature)
        {
            try
            {
                IFeature pObject = pAffFClass.CreateFeature();
                pObject.Shape = pSrcFeature.ShapeCopy;
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string sFieldName = configOpt.GetConfigValue2("Afforest", "BHField");
                for (int i = 0; i < pObject.Fields.FieldCount; i++)
                {
                    IField field = pObject.Fields.get_Field(i);
                    if (field.Editable && (field.Type != esriFieldType.esriFieldTypeGeometry))
                    {
                        string name = field.Name;
                        if (name != sFieldName)
                        {
                            object fieldValue = DataFuncs.GetFieldValue(pSrcFeature, name);
                            pObject.set_Value(i, fieldValue);
                        }
                    }
                }
                string str3 = configOpt.GetConfigValue2("Harvest", "CFSZField");
                string pFieldValue = DataFuncs.GetFieldValue(pSrcFeature, str3).ToString();
                string str5 = configOpt.GetConfigValue2("Afforest", "SZField");
                DataFuncs.UpdateField(pObject, str5, pFieldValue);
                string str6 = configOpt.GetConfigValue2("Afforest", "ZLLBField");
                string str7 = "126";
                DataFuncs.UpdateField(pObject, str6, str7);
                DataFuncs.UpdateField(pObject, sFieldName, "12");
                DataFuncs.UpdateField(pObject, "DI_LEI", "111");
                string str8 = configOpt.GetConfigValue2("EditData", "CFDilei");
                DataFuncs.UpdateField(pObject, "Q_DI_LEI", str8);
                pObject.Store();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormCopyHarvest", "CreateNewFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void FormCopyHarvest_Load(object sender, EventArgs e)
        {


            this.panelDist.Enabled = false;
            this.panelTime.Enabled = false;
            this.InitTime();
        }

        /// <summary>
        /// 初始化各数据的下拉列表
        /// </summary>
        private void InitDist()
        {
            this.comboBoxTown.Properties.Items.Clear();
            this.comboBoxVill.Properties.Items.Clear();
            string distCode = EditTask.DistCode;
            if (distCode != "")
            {
                string str2 = distCode.Substring(0, 6);
                this.m_Code = str2;

                string sql = "select CCODE,CNAME from T_SYS_META_CODE where PCODE='" + str2 + "'";

                #region
                //源代码未将任何查询结果封装进DataTable表中
                ///DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                ////DataTable dataTable = null;

                DataTable dataTable = GetDataTable(sql);
                #endregion

                if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                {
                    IList<string> list = new List<string> { "" };
                    this.comboBoxTown.Properties.Items.Add("--");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        list.Add(dataTable.Rows[i]["CCODE"].ToString());
                        this.comboBoxTown.Properties.Items.Add(dataTable.Rows[i]["CNAME"].ToString());
                    }
                    this.comboBoxTown.Tag = list;
                    if (list.Count == 2)
                    {
                        this.comboBoxTown.SelectedIndex = 1;
                    }
                    else
                    {
                        this.comboBoxTown.SelectedIndex = 0;
                    }
                }

            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTime = new DevExpress.XtraEditors.PanelControl();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkEditTime = new DevExpress.XtraEditors.CheckEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDist = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxVill = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEditDist = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonCopy = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTime)).BeginInit();
            this.panelTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditTime.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDist)).BeginInit();
            this.panelDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "      自动复制符合条件的采伐班块到造林图层，复制条件为采伐树种是桉树、采伐方式是皆伐。";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelTime);
            this.panel3.Controls.Add(this.checkEditTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 67);
            this.panel3.TabIndex = 13;
            // 
            // panelTime
            // 
            this.panelTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelTime.Appearance.Options.UseBackColor = true;
            this.panelTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTime.Controls.Add(this.dateEnd);
            this.panelTime.Controls.Add(this.dateStart);
            this.panelTime.Controls.Add(this.labelControl2);
            this.panelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTime.Location = new System.Drawing.Point(0, 19);
            this.panelTime.Name = "panelTime";
            this.panelTime.Padding = new System.Windows.Forms.Padding(5, 6, 14, 8);
            this.panelTime.Size = new System.Drawing.Size(351, 35);
            this.panelTime.TabIndex = 10;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(204, 9);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(140, 20);
            this.dateEnd.TabIndex = 91;
            // 
            // dateStart
            // 
            this.dateStart.EditValue = null;
            this.dateStart.Location = new System.Drawing.Point(40, 9);
            this.dateStart.Name = "dateStart";
            this.dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateStart.Size = new System.Drawing.Size(140, 20);
            this.dateStart.TabIndex = 90;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(186, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "—";
            // 
            // checkEditTime
            // 
            this.checkEditTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkEditTime.Location = new System.Drawing.Point(0, 0);
            this.checkEditTime.Name = "checkEditTime";
            this.checkEditTime.Properties.Caption = "变更时间";
            this.checkEditTime.Size = new System.Drawing.Size(351, 19);
            this.checkEditTime.TabIndex = 11;
            this.checkEditTime.CheckedChanged += new System.EventHandler(this.checkEditTime_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelDist);
            this.panel2.Controls.Add(this.checkEditDist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 68);
            this.panel2.TabIndex = 12;
            // 
            // panelDist
            // 
            this.panelDist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelDist.Controls.Add(this.labelControl7);
            this.panelDist.Controls.Add(this.labelControl6);
            this.panelDist.Controls.Add(this.comboBoxVill);
            this.panelDist.Controls.Add(this.comboBoxTown);
            this.panelDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDist.Location = new System.Drawing.Point(0, 19);
            this.panelDist.Name = "panelDist";
            this.panelDist.Size = new System.Drawing.Size(351, 38);
            this.panelDist.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(187, 12);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "村：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 14);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "乡：";
            // 
            // comboBoxVill
            // 
            this.comboBoxVill.Location = new System.Drawing.Point(214, 10);
            this.comboBoxVill.Name = "comboBoxVill";
            this.comboBoxVill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVill.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVill.Size = new System.Drawing.Size(130, 20);
            this.comboBoxVill.TabIndex = 3;
            this.comboBoxVill.SelectedIndexChanged += new System.EventHandler(this.comboBoxVill_SelectedIndexChanged);
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Location = new System.Drawing.Point(39, 10);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(130, 20);
            this.comboBoxTown.TabIndex = 2;
            this.comboBoxTown.SelectedIndexChanged += new System.EventHandler(this.comboBoxTown_SelectedIndexChanged);
            // 
            // checkEditDist
            // 
            this.checkEditDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkEditDist.Location = new System.Drawing.Point(0, 0);
            this.checkEditDist.Name = "checkEditDist";
            this.checkEditDist.Properties.Caption = "区划";
            this.checkEditDist.Size = new System.Drawing.Size(351, 19);
            this.checkEditDist.TabIndex = 12;
            this.checkEditDist.CheckedChanged += new System.EventHandler(this.checkEditDist_CheckedChanged);
            // 
            // simpleButtonCopy
            // 
            this.simpleButtonCopy.Location = new System.Drawing.Point(246, 237);
            this.simpleButtonCopy.Name = "simpleButtonCopy";
            this.simpleButtonCopy.Size = new System.Drawing.Size(65, 23);
            this.simpleButtonCopy.TabIndex = 13;
            this.simpleButtonCopy.Text = "复制";
            this.simpleButtonCopy.Click += new System.EventHandler(this.simpleButtonCopy_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Location = new System.Drawing.Point(2, 55);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(355, 144);
            this.panelControl1.TabIndex = 14;
            // 
            // FormCopyHarvest
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(359, 281);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.simpleButtonCopy);
            this.Controls.Add(this.label1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCopyHarvest";
            this.Padding = new System.Windows.Forms.Padding(2, 10, 2, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "复制采伐班块";
            this.Load += new System.EventHandler(this.FormCopyHarvest_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTime)).EndInit();
            this.panelTime.ResumeLayout(false);
            this.panelTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditTime.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDist)).EndInit();
            this.panelDist.ResumeLayout(false);
            this.panelDist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 初始化当前时间，将之显示在指定的当前文本框中
        /// </summary>
        private void InitTime()
        {
            DateTime now = DateTime.Now;
            this.dateStart.Text = now.AddMonths(-1).Date.ToShortDateString();
            this.dateEnd.Text = now.ToShortDateString();
        }

        private void simpleButtonCopy_Click(object sender, EventArgs e)
        {
            this.CopyHarvest();
        }

        public object hook
        {
            set
            {
                if (value != null)
                {
                    if (this.m_hookHelper == null)
                    {
                        this.m_hookHelper = new HookHelperClass();
                    }
                    this.m_hookHelper.Hook = value;
                }
            }
        }
    }
}

