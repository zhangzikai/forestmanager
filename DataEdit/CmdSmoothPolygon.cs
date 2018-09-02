namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.CartographyTools;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using ShapeEdit;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    [ProgId("DataEdit.CmdSmoothPolygon"), ClassInterface(ClassInterfaceType.None), Guid("e1f2c33d-2bdc-468b-a8b5-b3bea48392ad")]
    public sealed class CmdSmoothPolygon : BaseCommand
    {
        private IFeatureLayer m_EditLayer = null;
        private IHookHelper m_hookHelper = null;
        private const string mClassName = "DataEdit.CmdSmoothPolygon";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public CmdSmoothPolygon()
        {
            base.m_category = "";
            base.m_caption = "平滑要素面";
            base.m_message = "平滑要素面";
            base.m_toolTip = "平滑要素面";
            base.m_name = "DataEdit.CmdSmoothPolygon";
            try
            {
            }
            catch (Exception)
            {
            }
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            MxCommands.Register(cLSID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(cLSID);
            ControlsCommands.Unregister(cLSID);
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

        public override void OnClick()
        {
            if (MessageBox.Show("确定做整个图层的平滑处理？", "平滑处理", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.m_EditLayer = EditTask.EditLayer;
                new FormSmoothPolygon(this.m_EditLayer, this.m_hookHelper).ShowDialog();
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                try
                {
                    this.m_hookHelper = new HookHelperClass();
                    this.m_hookHelper.Hook = hook;
                    if (this.m_hookHelper.ActiveView == null)
                    {
                        this.m_hookHelper = null;
                    }
                }
                catch
                {
                    this.m_hookHelper = null;
                }
                if (this.m_hookHelper == null)
                {
                    base.m_enabled = false;
                }
                else
                {
                    base.m_enabled = true;
                }
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        private void SmoothPolygon()
        {
            Exception exception;
            try
            {
                FormSmoothPolygon polygon = new FormSmoothPolygon(this.m_EditLayer, this.m_hookHelper);
                polygon.Show();
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                IGeoProcessorResult result = null;
                string parentDirectory = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath") + @"\";
                polygon.label1.Text = "    创建临时库...";
                string str2 = parentDirectory + "test.mdb";
                IWorkspaceFactory factory = null;
                if ((string.IsNullOrEmpty(str2) | !File.Exists(str2)) & (string.IsNullOrEmpty(str2) | !Directory.Exists(str2)))
                {
                    factory = new AccessWorkspaceFactoryClass();
                    IWorkspaceName name = factory.Create(parentDirectory, "test.mdb", null, 0);
                    IWorkspace workspace = factory.OpenFromFile(parentDirectory + "test.mdb", 0);
                    if (workspace == null)
                    {
                        polygon.labelinfo.Text = "    创建临时库失败";
                        return;
                    }
                    polygon.labelinfo.Text = "    创建临时库成功";
                    try
                    {
                        IFeatureWorkspace workspace2 = workspace as IFeatureWorkspace;
                        if (workspace2 != null)
                        {
                            IFeatureClass class2 = workspace2.OpenFeatureClass("smooth");
                            if (class2 != null)
                            {
                                (class2 as IDataset).Delete();
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (factory.OpenFromFile(parentDirectory + "test.mdb", 0) == null)
                {
                    polygon.labelinfo.Text = "    创建临时库失败";
                    return;
                }
                polygon.label1.Text = "    生成平滑图层...";
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
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    平滑处理成功";
                    }
                    else
                    {
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    平滑处理失败";
                        return;
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    平滑处理失败[" + exception.Message + "]";
                    return;
                }
                IDataset featureClass = this.m_EditLayer.FeatureClass as IDataset;
                polygon.label1.Text = "    清除图层要素...";
                DeleteFeatures features = new DeleteFeatures();
                features.in_features = this.m_EditLayer.FeatureClass;
                try
                {
                    result = (IGeoProcessorResult) geoprocessor.Execute(features, null);
                    if (result.Status == esriJobStatus.esriJobSucceeded)
                    {
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    清空要素成功";
                    }
                    else
                    {
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    清空要素失败";
                        return;
                    }
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    清空要素失败[" + exception.Message + "]";
                    return;
                }
                polygon.label1.Text = "    创建sde连接...";
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
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    创建sde连接成功";
                }
                catch (Exception exception4)
                {
                    exception = exception4;
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    创建sde连接失败[" + exception.Message + "]";
                    return;
                }
                polygon.label1.Text = "    加载平滑要素...";
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
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    加载平滑要素成功";
                    }
                    else
                    {
                        polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    加载平滑要素失败";
                        return;
                    }
                    object severity = null;
                    string messages = geoprocessor.GetMessages(ref severity);
                }
                catch (Exception exception5)
                {
                    exception = exception5;
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    加载平滑要素失败[" + exception.Message + "]";
                }
                if (Editor.UniqueInstance.StopEdit2())
                {
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    数据提交保存成功";
                    Editor.UniqueInstance.StartEdit(EditTask.EditWorkspace as IWorkspace, this.m_hookHelper.FocusMap);
                }
                else
                {
                    polygon.labelinfo.Text = polygon.labelinfo.Text + "/n    数据提交保存失败，需手动选择保存按钮";
                }
                int num = 0;
                for (int i = 0; i < 0x493e0; i++)
                {
                    num += i;
                }
                polygon.Close();
                polygon = null;
            }
            catch (Exception exception6)
            {
                exception = exception6;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.CmdSmoothPolygon", "SmoothPolygon", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                return Editor.UniqueInstance.IsBeingEdited;
            }
        }
    }
}

