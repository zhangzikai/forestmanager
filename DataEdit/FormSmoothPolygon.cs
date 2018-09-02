namespace DataEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.CartographyTools;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using ShapeEdit;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class FormSmoothPolygon : FormBase2
    {
        private IContainer components = null;
        private bool first = true;
        public Label label1;
        public Label labelinfo;
        private IFeatureLayer m_EditLayer = null;
        private IHookHelper m_hookHelper = null;
        private const string mClassName = "DataEdit.FormSmoothPolygon";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panelWaite;

        public FormSmoothPolygon(IFeatureLayer editlayer, IHookHelper hookhelper)
        {
            this.InitializeComponent();
            this.m_hookHelper = hookhelper;
            this.m_EditLayer = editlayer;
            Application.DoEvents();
        }

        private bool CheckExist(string sFileName)
        {
            try
            {
                IMap focusMap = this.m_hookHelper.FocusMap;
                return true;
            }
            catch (Exception)
            {
                return false;
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

        private void FormSmoothPolygon_Activated(object sender, EventArgs e)
        {
            if (this.first)
            {
                this.first = false;
                this.SmoothPolygon();
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSmoothPolygon));
            this.panelWaite = new Panel();
            this.labelinfo = new Label();
            this.label1 = new Label();
            this.panelWaite.SuspendLayout();
            base.SuspendLayout();
            this.panelWaite.Controls.Add(this.labelinfo);
            this.panelWaite.Controls.Add(this.label1);
            this.panelWaite.Dock = DockStyle.Top;
            this.panelWaite.Location = new Point(6, 6);
            this.panelWaite.Name = "panelWaite";
            this.panelWaite.Padding = new Padding(7);
            this.panelWaite.Size = new Size(0x149, 0x7c);
            this.panelWaite.TabIndex = 0x2d;
            this.labelinfo.Dock = DockStyle.Fill;
            this.labelinfo.ImageAlign = ContentAlignment.TopLeft;
            this.labelinfo.Location = new Point(7, 0x1f);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new Size(0x13b, 0x56);
            this.labelinfo.TabIndex = 1;
            this.labelinfo.Text = "      ";
            this.label1.Dock = DockStyle.Top;
            this.label1.ForeColor = Color.Blue;
            this.label1.Image = (Image)resources.GetObject("label1.Image");
            this.label1.ImageAlign = ContentAlignment.MiddleLeft;
            this.label1.Location = new Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x13b, 0x18);
            this.label1.TabIndex = 0;
            this.label1.Text = "      正在处理...";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 0x8b);
            base.Controls.Add(this.panelWaite);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormSmoothPolygon";
            base.Padding = new Padding(6);
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "图层平滑";
            base.Activated += new EventHandler(this.FormSmoothPolygon_Activated);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.Controls.SetChildIndex(this.panelWaite, 0);
            this.panelWaite.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void SmoothPolygon()
        {
            Exception exception;
            try
            {
                IWorkspace workspace;
                IFeatureWorkspace workspace2;
                IFeatureClass class2;
                this.labelinfo.Visible = true;
                Application.DoEvents();
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                IGeoProcessorResult result = null;
                string parentDirectory = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath") + @"\";
                this.label1.Text = "    创建临时库...";
                Application.DoEvents();
                string str2 = parentDirectory + "test.mdb";
                IWorkspaceFactory factory = null;
                if ((string.IsNullOrEmpty(str2) | !File.Exists(str2)) & (string.IsNullOrEmpty(str2) | !Directory.Exists(str2)))
                {
                    factory = new AccessWorkspaceFactoryClass();
                    IWorkspaceName name = factory.Create(parentDirectory, "test.mdb", null, 0);
                    workspace = factory.OpenFromFile(parentDirectory + "test.mdb", 0);
                    if (workspace == null)
                    {
                        this.labelinfo.Text = "    创建临时库 -- 失败";
                        return;
                    }
                    this.labelinfo.Text = "    创建临时库 -- 成功";
                    try
                    {
                        workspace2 = workspace as IFeatureWorkspace;
                        if (workspace2 != null)
                        {
                            class2 = workspace2.OpenFeatureClass("smooth");
                            if (class2 != null)
                            {
                                IDataset dataset = class2 as IDataset;
                                dataset.Delete();
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    factory = new AccessWorkspaceFactoryClass();
                    workspace = factory.OpenFromFile(parentDirectory + "test.mdb", 0);
                    if (workspace == null)
                    {
                        this.labelinfo.Text = "    创建临时库 -- 失败";
                        return;
                    }
                    this.labelinfo.Text = "    创建临时库 -- 成功";
                    workspace2 = workspace as IFeatureWorkspace;
                    if (workspace2 != null)
                    {
                        try
                        {
                            class2 = workspace2.OpenFeatureClass("smooth");
                            if (class2 != null)
                            {
                                (class2 as IDataset).Delete();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                this.label1.Text = "    生成平滑图层...";
                Application.DoEvents();
                ESRI.ArcGIS.CartographyTools.SmoothPolygon process = new ESRI.ArcGIS.CartographyTools.SmoothPolygon();
                process.algorithm = "PAEK";
                process.in_features = this.m_EditLayer.FeatureClass;
                process.out_feature_class = parentDirectory + @"test.mdb\smooth";
                process.tolerance = "0.0002";
                process.endpoint_option = "NO_FIXED";
                process.error_option = "FLAG_ERRORS";
                try
                {
                    result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                    if (result.Status == esriJobStatus.esriJobSucceeded)
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    平滑处理 -- 成功";
                    }
                    else
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    平滑处理 -- 失败";
                        return;
                    }
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    this.labelinfo.Text = this.labelinfo.Text + "\n    平滑处理 -- 失败[" + exception.Message + "]";
                    return;
                }
                IDataset featureClass = this.m_EditLayer.FeatureClass as IDataset;
                this.label1.Text = "    清除图层要素...";
                Application.DoEvents();
                DeleteFeatures features = new DeleteFeatures();
                features.in_features = this.m_EditLayer.FeatureClass;
                try
                {
                    result = (IGeoProcessorResult) geoprocessor.Execute(features, null);
                    if (result.Status == esriJobStatus.esriJobSucceeded)
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    清空要素 -- 成功";
                    }
                    else
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    清空要素 -- 失败";
                        return;
                    }
                }
                catch (Exception exception4)
                {
                    exception = exception4;
                    this.labelinfo.Text = this.labelinfo.Text + "\n    清空要素 -- 失败[" + exception.Message + "]";
                    return;
                }
                this.label1.Text = "    创建sde连接...";
                Application.DoEvents();
                CreateArcSDEConnectionFile file = new CreateArcSDEConnectionFile();
                string str3 = UtilFactory.GetConfigOpt().RootPath + @"\Temp";
                file.out_folder_path = str3;
                IVersion editWorkspace = EditTask.EditWorkspace as IVersion;
                string str4 = editWorkspace.VersionName.Substring(4, 4) + "sdeconnect.sde";
                file.out_name = str4;
                string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource").Split(new char[] { '/' })[0];
                file.server = str5;
                string str6 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
                file.service = str6;
                string str7 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                file.database = str7;
                string str9 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
                file.username = str9;
                string str10 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
                file.password = str10;
                file.save_version_info = "SAVE_VERSION";
                string versionName = editWorkspace.VersionName;
                file.version = versionName;
                try
                {
                    result = (IGeoProcessorResult) geoprocessor.Execute(file, null);
                    this.labelinfo.Text = this.labelinfo.Text + "\n    创建sde连接 -- 成功";
                }
                catch (Exception exception5)
                {
                    exception = exception5;
                    this.labelinfo.Text = this.labelinfo.Text + "\n    创建sde连接 -- 失败[" + exception.Message + "]";
                    return;
                }
                this.label1.Text = "    加载平滑要素...";
                Application.DoEvents();
                Append append = new Append();
                append.inputs = parentDirectory + @"test.mdb\smooth";
                string[] strArray = (this.m_EditLayer.FeatureClass as IDataset).Name.Split(new char[] { '.' });
                string str14 = strArray[strArray.Length - 1];
                string str15 = str3 + @"\" + str4 + @"\" + str7 + @".DBO.ZT\" + str7 + ".DBO." + str14;
                append.target = str15;
                append.schema_type = "NO_TEST";
                try
                {
                    result = (IGeoProcessorResult) geoprocessor.Execute(append, null);
                    if (result.Status == esriJobStatus.esriJobSucceeded)
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    加载平滑要素 -- 成功";
                    }
                    else
                    {
                        this.labelinfo.Text = this.labelinfo.Text + "\n    加载平滑要素 -- 失败";
                        return;
                    }
                    object severity = null;
                    string messages = geoprocessor.GetMessages(ref severity);
                }
                catch (Exception exception6)
                {
                    exception = exception6;
                    this.labelinfo.Text = this.labelinfo.Text + "\n    加载平滑要素 -- 失败[" + exception.Message + "]";
                }
                this.label1.Text = "    数据提交保存...";
                Application.DoEvents();
                if (Editor.UniqueInstance.StopEdit2())
                {
                    this.labelinfo.Text = this.labelinfo.Text + "\n    数据提交保存 -- 成功";
                    Editor.UniqueInstance.StartEdit(EditTask.EditWorkspace as IWorkspace, this.m_hookHelper.FocusMap);
                }
                else
                {
                    this.labelinfo.Text = this.labelinfo.Text + "\n    数据提交保存 -- 失败，需手动选择保存按钮";
                }
                this.label1.Text = "    平滑处理完成";
                this.label1.Image = null;
                this.m_hookHelper.ActiveView.Refresh();
            }
            catch (Exception exception7)
            {
                exception = exception7;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.FormSmoothPolygon", "SmoothPolygon", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

