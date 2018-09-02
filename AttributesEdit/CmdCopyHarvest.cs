namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    /// <summary>
    /// 复制采伐班块
    /// </summary>
    [Guid("f70a1818-e5f0-4407-a0aa-79c81404509e"), ClassInterface(ClassInterfaceType.None), ProgId("AttributesEdit.CmdCopyHarvest")]
    public sealed class CmdCopyHarvest : BaseCommand
    {
        private IHookHelper m_hookHelper;
        private const string mClassName = "AttributesEdit.CmdCopyHarvest";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        /// <summary>
        /// 复制采伐班块：构造器
        /// </summary>
        public CmdCopyHarvest()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "复制桉树采伐班块";
            base.m_name = "";
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

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
                        string str4 = configOpt.GetConfigValue2("Afforest", "CopyWhere");
                        string str3 = str4 + " and (" + sFieldName + "<>'1' or " + sFieldName + " is null)";
                        IQueryFilter filter = new QueryFilterClass {
                            WhereClause = str3
                        };
                        IFeatureCursor cursor = featureClass.Search(filter, false);
                        if (cursor != null)
                        {
                            Editor.UniqueInstance.AddAttribute = false;
                            IFeature pSrcFeature = cursor.NextFeature();
                            if (pSrcFeature == null)
                            {
                                MessageBox.Show("无满足条件的采伐班块可复制！", "提示");
                            }
                            else
                            {
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
                                    Editor.UniqueInstance.StopEdit();
                                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                                    MessageBox.Show("复制成功完成！共复制班块" + num + "个。", "提示");
                                    this.m_hookHelper.ActiveView.Refresh();
                                }
                                catch (Exception exception)
                                {
                                    Editor.UniqueInstance.AbortEditOperation();
                                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.CmdCopyHarvest", "CopyHarvest", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.CmdCopyHarvest", "CreateNewFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public override void OnClick()
        {
            new FormCopyHarvest { hook = this.m_hookHelper.Hook }.ShowDialog();
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
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
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    return false;
                }
                if ((Editor.UniqueInstance.TargetLayer == null) || (Editor.UniqueInstance.TargetLayer.FeatureClass == null))
                {
                    return false;
                }
                if (!Editor.UniqueInstance.TargetLayer.Name.Contains("造林"))
                {
                    return false;
                }
                return base.Enabled;
            }
        }
    }
}

