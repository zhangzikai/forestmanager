namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using OperateLog;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    [Guid("e1f2c33d-2bdc-468b-a8b5-b3bea48392ad"), ProgId("DataEdit.CmdAddDXT"), ClassInterface(ClassInterfaceType.None)]
    public sealed class CmdAddDXT : BaseCommand
    {
        private string m_GroupLayerName = "工作底图";
        private IHookHelper m_hookHelper = null;
        private const string mClassName = "DataEdit.CmdAddDXT";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public CmdAddDXT()
        {
            base.m_category = "";
            base.m_caption = "添加地形图";
            base.m_message = "添加地形图";
            base.m_toolTip = "添加地形图";
            base.m_name = "DataEdit.CmdAddDXT";
            try
            {
            }
            catch (Exception)
            {
            }
        }

        private void AddDXT()
        {
            string path = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTPath");
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTType");
            if ((path == "") || (str2 == ""))
            {
                if (this.ShowSetForm())
                {
                    path = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTPath");
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTType");
                }
                else
                {
                    return;
                }
            }
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                if (this.ShowSetForm())
                {
                    path = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTPath");
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue2("DXT", "DXTType");
                }
                else
                {
                    return;
                }
            }
            try
            {
                IList<string> pFileTypes = new List<string> { "img", "bmp", "gif", "tif", "tiff", "png", "jpg", "jpeg" };
                if (str2 == "1")
                {
                    FileInfo[] files = new DirectoryInfo(path).GetFiles();
                    if (files.Length < 1)
                    {
                        MessageBox.Show("文件夹中没有任何文件。", "添加地形图");
                    }
                    else
                    {
                        string sFileName = "";
                        for (int i = 0; i < files.Length; i++)
                        {
                            sFileName = files[i].Name;
                            string str4 = sFileName.Substring(sFileName.LastIndexOf(".") + 1);
                            if (pFileTypes.Contains(str4.ToLower()))
                            {
                                this.AddRasterDataset(path, sFileName);
                            }
                        }
                    }
                }
                else
                {
                    IActiveView focusMap = this.m_hookHelper.ActiveView.FocusMap as IActiveView;
                    IEnvelope extent = focusMap.Extent;
                    ISpatialFilter filter = new SpatialFilterClass();
                    filter.Geometry = extent;
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("TfhClassName");
                    IFeatureClass class2 = EditTask.EditWorkspace.OpenFeatureClass(configValue);
                    if (class2 == null)
                    {
                        MessageBox.Show("找不到图幅数据，无法加载。", "添加地形图");
                    }
                    else
                    {
                        IGeoDataset dataset = class2 as IGeoDataset;
                        filter.Geometry.Project(dataset.SpatialReference);
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;
                        IList<string> pFileNames = new List<string>();
                        IList<string> list2 = new List<string>();
                        IFeatureCursor cursor = class2.Search(filter, false);
                        for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            object obj2 = feature.get_Value(feature.Fields.FindField("新图幅号"));
                            if (obj2 != null)
                            {
                                pFileNames.Add(obj2.ToString());
                            }
                            object obj3 = feature.get_Value(feature.Fields.FindField("旧图幅号"));
                            if (obj3 != null)
                            {
                                list2.Add(obj3.ToString());
                            }
                        }
                        if ((pFileNames.Count < 1) && (list2.Count < 1))
                        {
                            MessageBox.Show("找不到当前地图范围的地形图。", "添加地形图");
                        }
                        else
                        {
                            this.AddDXTFile(path, pFileTypes, pFileNames, list2);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.CmdAddDXT", "AddDXT", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("加载地形图出错！", "添加地形图");
            }
        }

        private void AddDXTFile(string sPath, IList<string> pFileTypes, IList<string> pFileNames, IList<string> pFileNames1)
        {
            if (((pFileNames.Count <= 10) && (pFileNames1.Count <= 10)) || (DialogResult.No != MessageBox.Show("需加载的地形图张数较多，全部加载需要一些时间。是否继续？", "添加地形图", MessageBoxButtons.YesNo)))
            {
                string str = "";
                FileInfo[] files = new DirectoryInfo(sPath).GetFiles();
                for (int i = 0; i < pFileNames.Count; i++)
                {
                    string str5;
                    string sFileName = "";
                    bool flag = false;
                    string str3 = pFileNames[i];
                    string name = "";
                    int index = 0;
                    while (index < files.Length)
                    {
                        name = files[index].Name;
                        if (name.Replace(" ", "").ToLower().IndexOf(str3.Replace(" ", "").ToLower()) > -1)
                        {
                            str5 = name.Substring(name.LastIndexOf(".") + 1);
                            if (pFileTypes.Contains(str5.ToLower()))
                            {
                                sFileName = name;
                                flag = true;
                                break;
                            }
                        }
                        index++;
                    }
                    string str6 = "";
                    bool flag2 = false;
                    string str7 = pFileNames1[i];
                    for (index = 0; index < files.Length; index++)
                    {
                        name = files[index].Name;
                        if (name.Replace(" ", "").ToLower().IndexOf(str7.Replace(" ", "").ToLower()) > -1)
                        {
                            str5 = name.Substring(name.LastIndexOf(".") + 1);
                            if (pFileTypes.Contains(str5.ToLower()))
                            {
                                str6 = name;
                                flag2 = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        this.AddRasterDataset(sPath, sFileName);
                    }
                    else if (flag2)
                    {
                        this.AddRasterDataset(sPath, str6);
                    }
                    else
                    {
                        string str8 = str;
                        str = str8 + "、" + str3 + "（" + str7 + "）";
                    }
                }
                if (str != "")
                {
                    MessageBox.Show("文件" + str.Substring(1) + "不存在或格式不支持！", "添加地形图");
                }
            }
        }

        private void AddRasterDataset(string sPath, string sFileName)
        {
            if (this.CheckExist(sFileName))
            {
                this.m_hookHelper.ActiveView.Refresh();
            }
            else
            {
                try
                {
                    IWorkspaceFactory factory = new RasterWorkspaceFactoryClass();
                    IRasterDataset rasterDataset = null;
                    rasterDataset = ((IRasterWorkspace) factory.OpenFromFile(sPath, 0)).OpenRasterDataset(sFileName);
                    IRasterLayer layer = new RasterLayerClass();
                    layer.SpatialReference = this.m_hookHelper.FocusMap.SpatialReference;
                    layer.CreateFromDataset(rasterDataset);
                    IMap focusMap = this.m_hookHelper.FocusMap;
                    ILayer layer2 = GISFunFactory.LayerFun.FindLayer((IBasicMap) focusMap, this.m_GroupLayerName, true);
                    if (layer2 == null)
                    {
                        GISFunFactory.LayerFun.AddGroupLayer((IBasicMap) focusMap, null, this.m_GroupLayerName);
                        layer2 = GISFunFactory.LayerFun.FindLayer((IBasicMap) focusMap, this.m_GroupLayerName, true);
                        focusMap.MoveLayer(layer2, focusMap.LayerCount - 4);
                        layer2.MinimumScale = 10000.0;
                    }
                    layer2.SpatialReference = this.m_hookHelper.FocusMap.SpatialReference;
                    ((IGroupLayer) layer2).Add(layer);
                    this.m_hookHelper.ActiveView.Refresh();
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.CmdAddDXT", "AddRasterDataset", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
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
                ILayer layer = GISFunFactory.LayerFun.FindLayer((IBasicMap) focusMap, this.m_GroupLayerName, true);
                if ((layer != null) && (layer is GroupLayer))
                {
                    ILayer layer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer((IGroupLayer) layer, sFileName, true);
                    if (layer2 == null)
                    {
                        return false;
                    }
                    layer2.Visible = true;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void OnClick()
        {
            this.AddDXT();
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

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        private bool ShowSetForm()
        {
            FormDXTSet set = new FormDXTSet();
            return (set.ShowDialog() == DialogResult.OK);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                return true;
            }
        }
    }
}

