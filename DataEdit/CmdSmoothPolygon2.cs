namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ShapeEdit;
    using System;
    using System.Runtime.InteropServices;
    using TaskManage;
    using Utilities;

    [ClassInterface(ClassInterfaceType.None), ProgId("DataEdit.CmdSmoothPolygon2"), Guid("e1f2c33d-2bdc-468b-a8b5-b3bea48395ad")]
    public sealed class CmdSmoothPolygon2 : BaseCommand
    {
        private IFeatureLayer m_EditLayer = null;
        private IHookHelper m_hookHelper = null;
        private const string mClassName = "DataEdit.CmdSmoothPolygon2";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureSelection mFeatureSelection = null;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public CmdSmoothPolygon2()
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

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            MxCommands.Register(cLSID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
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
            this.m_EditLayer = EditTask.EditLayer;
            this.mFeatureSelection = this.m_EditLayer as IFeatureSelection;
            this.SmoothPolygon();
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
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        private void SmoothPolygon()
        {
            Exception exception;
            try
            {
                ISelectionSet selectionSet = null;
                selectionSet = this.mFeatureSelection.SelectionSet;
                ICursor cursor = null;
                selectionSet.Search(null, false, out cursor);
                IFeatureCursor cursor2 = cursor as IFeatureCursor;
                IFeature feature = cursor2.NextFeature();
                Editor.UniqueInstance.AddAttribute = false;
                while (feature != null)
                {
                    IGeometry shapeCopy = feature.ShapeCopy;
                    IPolygon polygon = shapeCopy as IPolygon;
                    IPolycurve polycurve = polygon;
                    polycurve.Smooth(1E-08);
                    Editor.UniqueInstance.StartEditOperation();
                    IFeature feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                    feature2.Shape = shapeCopy;
                    for (int i = 0; i < feature2.Fields.FieldCount; i++)
                    {
                        IField field = feature2.Fields.get_Field(i);
                        if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                        {
                            int index = feature.Fields.FindField(field.Name);
                            try
                            {
                                if (((index > -1) && (feature2.get_Value(i).ToString().Trim() == "")) && (feature.get_Value(index).ToString().Trim() != ""))
                                {
                                    feature2.set_Value(i, feature.get_Value(index));
                                }
                            }
                            catch (Exception exception1)
                            {
                                exception = exception1;
                                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.CmdSmoothPolygon2", "SmoothPolygon", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                            }
                        }
                    }
                    feature2.Store();
                    Editor.UniqueInstance.StopEditOperation();
                    feature = cursor2.NextFeature();
                }
                Editor.UniqueInstance.AddAttribute = true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                Editor.UniqueInstance.AddAttribute = true;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.CmdSmoothPolygon2", "SmoothPolygon", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_EditLayer == null)
                {
                    return false;
                }
                this.mFeatureSelection = this.m_EditLayer as IFeatureSelection;
                if (this.mFeatureSelection == null)
                {
                    return false;
                }
                if (this.mFeatureSelection.SelectionSet.Count <= 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}

