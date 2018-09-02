namespace GeoDataIE
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlExportZT : UserControlBase1
    {
        private SimpleButton btnCancel;
        private SimpleButton btnExport;
        private SimpleButton btnNext;
        private SimpleButton btnPre;
        private ButtonEdit buttonEditPath;
        private CheckedComboBoxEdit checkedComboBoxEdit1;
        private CheckEdit checkEditDist;
        private CheckEdit checkEditSelected;
        private CheckedListBoxControl checkedListBoxControl1;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl3;
        private LabelControl labelLayer;
        private LabelControl labelLoading;
        private const string m_ClassName = "UserControlExportZT";
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IMap m_Map;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private string m_ZTName = "";
        private Panel panel1;
        private Panel panel3;
        private Panel panel5;
        private Panel panel6;
        private Panel panelContent;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private Panel panelType;
        private RadioGroup radioGroup1;

        public UserControlExportZT()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CloseParentForm();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string text = this.buttonEditPath.Text;
            if (text == "")
            {
                MessageBox.Show("请选择导出位置！", "提示", MessageBoxButtons.OK);
            }
            else if (this.checkEditDist.Checked && (this.checkedComboBoxEdit1.Properties.Items.GetCheckedValues().Count < 1))
            {
                MessageBox.Show("请选择区划范围！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                if (this.checkEditSelected.Checked)
                {
                    IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                    if (editLayer.SelectionSet.Count < 1)
                    {
                        MessageBox.Show("当前图层无选中要素！", "提示");
                        return;
                    }
                }
                if (((this.checkEditSelected.CheckState != CheckState.Unchecked) || (this.checkEditDist.CheckState != CheckState.Unchecked)) || (DialogResult.No != MessageBox.Show("将导出当前图层所有要素，是否继续？", "提示", MessageBoxButtons.YesNo)))
                {
                    this.panelControl1.Enabled = false;
                    this.panelControl2.Visible = true;
                    this.Refresh();
                    string sType = "";
                    if (this.radioGroup1.SelectedIndex == 1)
                    {
                        sType = "gdb";
                    }
                    else
                    {
                        sType = "shape";
                    }
                    if (this.ExportData(text, sType))
                    {
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK);
                        this.CloseParentForm();
                    }
                    else
                    {
                        MessageBox.Show("导出失败！", "提示", MessageBoxButtons.OK);
                        this.panelControl1.Enabled = true;
                        this.panelControl2.Visible = false;
                        this.Refresh();
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.panelType.Visible)
            {
                if (this.checkedComboBoxEdit1.Properties.Items.Count < 1)
                {
                    this.InitDist();
                }
                this.panelType.Visible = false;
                this.panelContent.Visible = true;
                this.btnNext.Visible = false;
                this.btnPre.Visible = true;
                this.btnExport.Visible = true;
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.panelType.Visible = true;
            this.panelContent.Visible = false;
            this.btnNext.Visible = true;
            this.btnPre.Visible = false;
            this.btnExport.Visible = false;
        }

        private void buttonEditPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (this.buttonEditPath.Text != "")
            {
                try
                {
                    dialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.buttonEditPath.Text);
                }
                catch
                {
                }
            }
            if (this.radioGroup1.SelectedIndex == 1)
            {
                dialog.Filter = "专题数据 (*.gdb)|*.gdb";
            }
            else
            {
                dialog.Filter = "Shape文件 (*.shp)|*.shp";
            }
            dialog.FileName = this.m_ZTName;
            dialog.Title = "导出数据";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.buttonEditPath.Text = fileName;
            }
            dialog = null;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditSelected.Checked)
            {
                this.checkedComboBoxEdit1.Enabled = false;
                this.checkEditDist.Enabled = false;
            }
            else
            {
                this.checkedComboBoxEdit1.Enabled = true;
                this.checkEditDist.Enabled = true;
            }
        }

        private void checkEditDist_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditDist.Checked)
            {
                this.checkedComboBoxEdit1.Enabled = true;
                this.checkEditSelected.Enabled = false;
            }
            else
            {
                this.checkedComboBoxEdit1.Enabled = false;
                this.checkEditSelected.Enabled = true;
            }
        }

        private void CloseParentForm()
        {
            Form parentForm = base.ParentForm;
            if (parentForm != null)
            {
                parentForm.Close();
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

        private bool ExportData(string sZipFullPath, string sType)
        {
            try
            {
                ISpatialFilter filter = null;
                if (this.checkEditDist.Checked)
                {
                    ITopologicalOperator @operator = null;
                    IList<object> checkedValues = this.checkedComboBoxEdit1.Properties.Items.GetCheckedValues();
                    if (checkedValues.Count == this.checkedComboBoxEdit1.Properties.Items.Count)
                    {
                        @operator = null;
                    }
                    else
                    {
                        for (int i = 0; i < checkedValues.Count; i++)
                        {
                            IFeature feature = checkedValues[i] as IFeature;
                            IGeometry shapeCopy = feature.ShapeCopy;
                            if (@operator == null)
                            {
                                @operator = shapeCopy as ITopologicalOperator;
                            }
                            else
                            {
                                @operator.Union(shapeCopy);
                            }
                        }
                    }
                    if (@operator != null)
                    {
                        filter = new SpatialFilterClass();
                        filter.Geometry = @operator as IGeometry;
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    }
                }
                string sSourceFile = "";
                IWorkspace pTargetWS = null;
                int num2 = sZipFullPath.LastIndexOf('\\');
                int num3 = sZipFullPath.LastIndexOf('.');
                string path = sZipFullPath.Substring(0, num2 + 1);
                string sTargetName = sZipFullPath.Substring(num2 + 1, (num3 - num2) - 1);
                if (sType.ToLower() == "shape")
                {
                    sSourceFile = path;
                    pTargetWS = ConvertData.OpenWorkspace(sSourceFile);
                }
                else if (sType.ToLower() == "gdb")
                {
                    string dir = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                    FileZip.DeleteFolderFile(dir);
                    sSourceFile = dir + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + sType;
                    pTargetWS = ConvertData.CreateDBFile(sSourceFile);
                }
                if (pTargetWS != null)
                {
                    IWorkspace editWorkspace = (IWorkspace) EditTask.EditWorkspace;
                    string str5 = "";
                    new List<IFeatureClass>();
                    if (EditTask.KindCode.Substring(0, 2) == "04")
                    {
                        List<object> list2 = this.checkedListBoxControl1.Items.GetCheckedValues();
                        for (int j = 0; j < list2.Count; j++)
                        {
                            string sLayerName = list2[j].ToString();
                            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_Map, sLayerName, true);
                            if (layer != null)
                            {
                                IFeatureClass featureClass = layer.FeatureClass;
                                IDataset dataset1 = (IDataset) featureClass;
                                string str7 = sTargetName + "_";
                                if (featureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                {
                                    str7 = str7 + "点";
                                }
                                else if (featureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                {
                                    str7 = str7 + "线";
                                }
                                else if (featureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                {
                                    str7 = str7 + "面";
                                }
                                string str8 = path + @"\" + str7;
                                if ((sType.ToLower() == "shape") && File.Exists(path))
                                {
                                    File.Delete(str8 + ".shp");
                                    File.Delete(str8 + ".shp.xml");
                                    File.Delete(str8 + ".shx");
                                    File.Delete(str8 + ".sbx");
                                    File.Delete(str8 + ".sbn");
                                    File.Delete(str8 + ".prj");
                                    File.Delete(str8 + ".dbf");
                                }
                                IQueryFilter pQueryFilter = null;
                                if (filter != null)
                                {
                                    filter.GeometryField = featureClass.ShapeFieldName;
                                    pQueryFilter = filter;
                                }
                                if (this.checkEditSelected.Checked)
                                {
                                    string str9 = "";
                                    IFeatureSelection selection = layer as IFeatureSelection;
                                    ISelectionSet selectionSet = selection.SelectionSet;
                                    string oIDFieldName = featureClass.OIDFieldName;
                                    IEnumIDs iDs = selectionSet.IDs;
                                    iDs.Reset();
                                    int num5 = -1;
                                    while ((num5 = iDs.Next()) != -1)
                                    {
                                        object obj2 = str9;
                                        str9 = string.Concat(new object[] { obj2, " or ", oIDFieldName, "=", num5 });
                                    }
                                    if (str9.Length > 4)
                                    {
                                        str9 = str9.Substring(4);
                                    }
                                    pQueryFilter = new QueryFilterClass();
                                    pQueryFilter.WhereClause = str9;
                                }
                                str5 = ConvertData.ConvertFeatureClass(editWorkspace, featureClass, pTargetWS, str7, pQueryFilter);
                                if (str5 != "")
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((sType.ToLower() == "shape") && File.Exists(sZipFullPath))
                        {
                            File.Delete(path + @"\" + sTargetName + ".shp");
                            File.Delete(path + @"\" + sTargetName + ".shp.xml");
                            File.Delete(path + @"\" + sTargetName + ".shx");
                            File.Delete(path + @"\" + sTargetName + ".sbx");
                            File.Delete(path + @"\" + sTargetName + ".sbn");
                            File.Delete(path + @"\" + sTargetName + ".prj");
                            File.Delete(path + @"\" + sTargetName + ".dbf");
                        }
                        IFeatureLayer editLayer = EditTask.EditLayer;
                        IFeatureClass pSourceFC = editLayer.FeatureClass;
                        IQueryFilter filter3 = null;
                        if (filter != null)
                        {
                            filter.GeometryField = pSourceFC.ShapeFieldName;
                            filter3 = filter;
                        }
                        if (this.checkEditSelected.Checked)
                        {
                            string str11 = "";
                            IFeatureSelection selection2 = editLayer as IFeatureSelection;
                            ISelectionSet set2 = selection2.SelectionSet;
                            string str12 = pSourceFC.OIDFieldName;
                            IEnumIDs ds2 = set2.IDs;
                            ds2.Reset();
                            int num6 = -1;
                            while ((num6 = ds2.Next()) != -1)
                            {
                                object obj3 = str11;
                                str11 = string.Concat(new object[] { obj3, " or ", str12, "=", num6 });
                            }
                            if (str11.Length > 4)
                            {
                                str11 = str11.Substring(4);
                            }
                            filter3 = new QueryFilterClass();
                            filter3.WhereClause = str11;
                        }
                        str5 = ConvertData.ConvertFeatureClass(editWorkspace, pSourceFC, pTargetWS, sTargetName, filter3);
                    }
                    IWorkspaceName o = new WorkspaceNameClass();
                    o.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";
                    o.PathName = sSourceFile;
                    IWorkspaceFactory workspaceFactory = o.WorkspaceFactory;
                    IWorkspaceFactoryLockControl control = (IWorkspaceFactoryLockControl) workspaceFactory;
                    if (control.SchemaLockingEnabled)
                    {
                        control.DisableSchemaLocking();
                    }
                    Marshal.ReleaseComObject(control);
                    Marshal.ReleaseComObject(workspaceFactory);
                    Marshal.ReleaseComObject(o);
                    if (str5 == "")
                    {
                        if (sType == "gdb")
                        {
                            if (Directory.Exists(sZipFullPath))
                            {
                                Directory.Delete(sZipFullPath);
                            }
                            return FileZip.CopyDirectory(sSourceFile, sZipFullPath);
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetNameByCode(ICodedValueDomain pCodeDomain, string sCode)
        {
            for (int i = 0; i < pCodeDomain.CodeCount; i++)
            {
                if (pCodeDomain.get_Value(i).ToString() == sCode)
                {
                    return pCodeDomain.get_Name(i);
                }
            }
            return "";
        }

        public void Init(IMap pMap)
        {
            this.m_Map = pMap;
            this.labelLayer.Visible = false;
            this.radioGroup1.Properties.Items.Clear();
            this.radioGroup1.Properties.Items.Add(new RadioGroupItem("shape", "Shape文件"));
            this.radioGroup1.Properties.Items.Add(new RadioGroupItem("gdb", "gdb格式"));
            this.radioGroup1.SelectedIndex = 0;
            this.btnNext.Visible = true;
            this.btnPre.Visible = false;
            this.panelType.Visible = true;
            this.panelContent.Visible = false;
            this.btnExport.Visible = false;
            this.checkedComboBoxEdit1.Enabled = false;
            switch (EditTask.KindCode.Substring(0, 2))
            {
                case "01":
                    this.m_ZTName = "造林";
                    break;

                case "02":
                    this.m_ZTName = "采伐";
                    break;

                case "03":
                    this.m_ZTName = "";
                    break;

                case "04":
                {
                    this.m_ZTName = "征占用";
                    IList<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayerName2").Split(new char[] { ',' }));
                    for (int i = 0; i < list.Count; i++)
                    {
                        this.checkedListBoxControl1.Items[i].Value = list[i];
                    }
                    if (EditTask.KindCode.Length > 2)
                    {
                        this.checkEditSelected.Visible = true;
                    }
                    else
                    {
                        this.checkEditSelected.Visible = false;
                    }
                    break;
                }
                case "05":
                    this.m_ZTName = "火灾";
                    break;

                case "06":
                    this.m_ZTName = "灾害";
                    break;

                case "07":
                    this.m_ZTName = "林业案件";
                    break;
            }
            this.labelLayer.Text = this.m_ZTName + "数据导出";
            this.InitDist();
        }

        private void InitDist()
        {
            this.checkedComboBoxEdit1.Properties.Items.Clear();
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
            IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_Map, configValue, true);
            if (layer != null)
            {
                IFeatureClass featureClass = layer.FeatureClass;
                string name = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                int index = featureClass.Fields.FindField(name);
                if (index >= 0)
                {
                    IField field = featureClass.Fields.get_Field(index);
                    if (field.Domain != null)
                    {
                        ICodedValueDomain pCodeDomain = field.Domain as ICodedValueDomain;
                        IFeatureCursor o = featureClass.Search(null, false);
                        if (o != null)
                        {
                            for (IFeature feature = o.NextFeature(); feature != null; feature = o.NextFeature())
                            {
                                string sCode = feature.get_Value(index).ToString();
                                string nameByCode = this.GetNameByCode(pCodeDomain, sCode);
                                this.checkedComboBoxEdit1.Properties.Items.Add(feature, nameByCode, CheckState.Checked, true);
                            }
                            Marshal.ReleaseComObject(o);
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlExportZT));
            this.panelControl1 = new PanelControl();
            this.panel6 = new Panel();
            this.btnCancel = new SimpleButton();
            this.btnPre = new SimpleButton();
            this.panel3 = new Panel();
            this.btnExport = new SimpleButton();
            this.btnNext = new SimpleButton();
            this.panel5 = new Panel();
            this.checkedListBoxControl1 = new CheckedListBoxControl();
            this.panelContent = new Panel();
            this.checkEditDist = new CheckEdit();
            this.checkEditSelected = new CheckEdit();
            this.checkedComboBoxEdit1 = new CheckedComboBoxEdit();
            this.labelControl3 = new LabelControl();
            this.buttonEditPath = new ButtonEdit();
            this.panelType = new Panel();
            this.labelControl1 = new LabelControl();
            this.radioGroup1 = new RadioGroup();
            this.labelLayer = new LabelControl();
            this.panel1 = new Panel();
            this.panelControl2 = new PanelControl();
            this.labelLoading = new LabelControl();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((ISupportInitialize) this.checkedListBoxControl1).BeginInit();
            this.panelContent.SuspendLayout();
            this.checkEditDist.Properties.BeginInit();
            this.checkEditSelected.Properties.BeginInit();
            this.checkedComboBoxEdit1.Properties.BeginInit();
            this.buttonEditPath.Properties.BeginInit();
            this.panelType.SuspendLayout();
            this.radioGroup1.Properties.BeginInit();
            this.panel1.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel6);
            this.panelControl1.Controls.Add(this.panel5);
            this.panelControl1.Controls.Add(this.panelContent);
            this.panelControl1.Controls.Add(this.panelType);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new Padding(0, 15, 0, 0);
            this.panelControl1.Size = new Size(350, 0x107);
            this.panelControl1.TabIndex = 10;
            this.panel6.Controls.Add(this.btnCancel);
            this.panel6.Controls.Add(this.btnPre);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.btnExport);
            this.panel6.Controls.Add(this.btnNext);
            this.panel6.Dock = DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 0xe4);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(20, 4, 20, 4);
            this.panel6.Size = new Size(350, 0x23);
            this.panel6.TabIndex = 0x11;
            this.btnCancel.Dock = DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(20, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x3a, 0x1b);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnPre.Dock = DockStyle.Right;
            this.btnPre.Location = new System.Drawing.Point(0x7f, 4);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new Size(60, 0x1b);
            this.btnPre.TabIndex = 1;
            this.btnPre.Text = "上一步";
            this.btnPre.Click += new EventHandler(this.btnPre_Click);
            this.panel3.Dock = DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(0xbb, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x17, 0x1b);
            this.panel3.TabIndex = 3;
            this.btnExport.Dock = DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(210, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(60, 0x1b);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            this.btnNext.Dock = DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(270, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(60, 0x1b);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "下一步";
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            this.panel5.Controls.Add(this.checkedListBoxControl1);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0xc7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(350, 0x1a);
            this.panel5.TabIndex = 0x10;
            this.panel5.Visible = false;
            this.checkedListBoxControl1.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("point", "点", CheckState.Checked), new CheckedListBoxItem("polyline", "线", CheckState.Checked), new CheckedListBoxItem("polygon", "面", CheckState.Checked) });
            this.checkedListBoxControl1.Location = new System.Drawing.Point(0x4e, 0);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new Size(120, 60);
            this.checkedListBoxControl1.TabIndex = 0;
            this.panelContent.Controls.Add(this.checkEditDist);
            this.panelContent.Controls.Add(this.checkEditSelected);
            this.panelContent.Controls.Add(this.checkedComboBoxEdit1);
            this.panelContent.Controls.Add(this.labelControl3);
            this.panelContent.Controls.Add(this.buttonEditPath);
            this.panelContent.Dock = DockStyle.Top;
            this.panelContent.Location = new System.Drawing.Point(0, 90);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new Size(350, 0x6d);
            this.panelContent.TabIndex = 13;
            this.checkEditDist.Location = new System.Drawing.Point(0x12, 0x26);
            this.checkEditDist.Name = "checkEditDist";
            this.checkEditDist.Properties.Caption = "范围";
            this.checkEditDist.Size = new Size(0x3f, 0x13);
            this.checkEditDist.TabIndex = 12;
            this.checkEditDist.CheckedChanged += new EventHandler(this.checkEditDist_CheckedChanged);
            this.checkEditSelected.Location = new System.Drawing.Point(0x12, 4);
            this.checkEditSelected.Name = "checkEditSelected";
            this.checkEditSelected.Properties.Caption = "只导出选中要素";
            this.checkEditSelected.Size = new Size(0x79, 0x13);
            this.checkEditSelected.TabIndex = 11;
            this.checkEditSelected.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.checkedComboBoxEdit1.EditValue = "";
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(0x57, 0x26);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.checkedComboBoxEdit1.Properties.ExportMode = ExportMode.DisplayText;
            this.checkedComboBoxEdit1.Properties.SelectAllItemCaption = "(全选)";
            this.checkedComboBoxEdit1.Size = new Size(0xf1, 0x15);
            this.checkedComboBoxEdit1.TabIndex = 10;
            this.labelControl3.Location = new System.Drawing.Point(20, 0x4e);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "导出位置：";
            this.buttonEditPath.Location = new System.Drawing.Point(0x57, 0x4b);
            this.buttonEditPath.Name = "buttonEditPath";
            this.buttonEditPath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.buttonEditPath.Size = new Size(0xf1, 0x15);
            this.buttonEditPath.TabIndex = 9;
            this.buttonEditPath.Click += new EventHandler(this.buttonEditPath_Click);
            this.panelType.Controls.Add(this.labelControl1);
            this.panelType.Controls.Add(this.radioGroup1);
            this.panelType.Controls.Add(this.labelLayer);
            this.panelType.Dock = DockStyle.Top;
            this.panelType.Location = new System.Drawing.Point(0, 15);
            this.panelType.Name = "panelType";
            this.panelType.Size = new Size(350, 0x4b);
            this.panelType.TabIndex = 14;
            this.labelControl1.Location = new System.Drawing.Point(0x15, 0x2c);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "导出类型：";
            this.radioGroup1.Location = new System.Drawing.Point(0x57, 0x26);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem("shape", "Shape文件"), new RadioGroupItem("gzt", "gdb格式") });
            this.radioGroup1.Size = new Size(0xb5, 0x19);
            this.radioGroup1.TabIndex = 12;
            this.radioGroup1.SelectedIndexChanged += new EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.labelLayer.Location = new System.Drawing.Point(0x15, 15);
            this.labelLayer.Name = "labelLayer";
            this.labelLayer.Size = new Size(0x12, 14);
            this.labelLayer.TabIndex = 0;
            this.labelLayer.Text = "aaa";
            this.panel1.Controls.Add(this.panelControl2);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(350, 0x142);
            this.panel1.TabIndex = 12;
            this.panelControl2.BorderStyle = BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelLoading);
            this.panelControl2.Dock = DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0x107);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(350, 0x33);
            this.panelControl2.TabIndex = 12;
            this.panelControl2.Visible = false;
            this.labelLoading.Appearance.Image = (Image) resources.GetObject("labelLoading.Appearance.Image");
            this.labelLoading.Appearance.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelLoading.Location = new System.Drawing.Point(0x4e, 15);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new Size(0x7c, 14);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "        正在导出数据……";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel1);
            base.Name = "UserControlExportZT";
            base.Size = new Size(350, 0x142);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((ISupportInitialize) this.checkedListBoxControl1).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.checkEditDist.Properties.EndInit();
            this.checkEditSelected.Properties.EndInit();
            this.checkedComboBoxEdit1.Properties.EndInit();
            this.buttonEditPath.Properties.EndInit();
            this.panelType.ResumeLayout(false);
            this.panelType.PerformLayout();
            this.radioGroup1.Properties.EndInit();
            this.panel1.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.buttonEditPath.Text;
            if (text.Replace(" ", "").Length >= 1)
            {
                int num = text.LastIndexOf('.');
                if (this.radioGroup1.SelectedIndex == 1)
                {
                    text = text.Substring(0, num + 1) + "gzt";
                }
                else
                {
                    text = text.Substring(0, num + 1) + "shp";
                }
                this.buttonEditPath.Text = text;
            }
        }

        private bool SelectData(IFeatureClass fClass, object whereClause, string targetPath)
        {
            try
            {
                if (fClass == null)
                {
                    return false;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                return true;
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "UserControlExportZT", "SelectData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }
    }
}

