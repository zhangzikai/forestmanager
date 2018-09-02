namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class MeasureFeatureTool : BaseTool
    {
        private const string mClassName = "Measure.MeasureFeatureTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public MeasureFeatureTool()
        {
            base.m_category = "量算";
            base.m_caption = "要素量算";
            base.m_message = "要素量算工具";
            base.m_toolTip = "要素量算工具";
            base.m_name = "MeasureFeatureTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "MeasureFeatures.bmp");
                base.m_cursor = new System.Windows.Forms.Cursor(this.GetType(), "MeasureFeatures.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "New", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                ProjectData.ClearProjectError();
            }
            this.mHookHelper = new HookHelperClass();
        }

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        this.mHookHelper = null;
        //       // base.Finalize();
        //    }
        //    catch (Exception exception1)
        //    {
        //        ProjectData.SetProjectError(exception1);
        //        Exception exception = exception1;
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureFeatureTool()
        {
            try
            {
                this.mHookHelper = null;
                // base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private bool GetNearestFeature(int x, int y, ref IFeature pNearestFeature, ref IFeatureLayer pNearestFeatureLayer)
        {
            bool flag = false;
            try
            {
                IEnumLayer layer;
                IFeatureCursor cursor;
                IFeature feature;
                IFeatureLayer layer2;
                IMap focusMap = this.mHookHelper.FocusMap;
                IActiveView pActiveView = (IActiveView) focusMap;
                IPoint p = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                IEnvelope pFilterGeometry = p.Envelope;
                pFilterGeometry.Width = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 6.0, true);
                pFilterGeometry.Height = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(pActiveView, 6.0, false);
                pFilterGeometry.CenterAt(p);
                UID uid = new UIDClass();
                uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
                try
                {
                    layer = focusMap.get_Layers(uid, true);
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    flag = false;
                    ProjectData.ClearProjectError();
                    return flag;
                }
                if (layer == null)
                {
                    return false;
                }
                Collection pFeatureCollection = new Collection();
                Collection collection2 = new Collection();
                layer.Reset();
                for (layer2 = (IFeatureLayer) layer.Next(); layer2 != null; layer2 = (IFeatureLayer) layer.Next())
                {
                    if (GISFunFactory.LayerFun.CheckLayerValid(focusMap, layer2) && (layer2.FeatureClass != null))
                    {
                        cursor = GISFunFactory.FeatureFun.SearchFeatureCursorFromFeatureClass(layer2.FeatureClass, pFilterGeometry, esriSpatialRelEnum.esriSpatialRelIntersects);
                        if (cursor != null)
                        {
                            IGeoFeatureLayer layer3 = (IGeoFeatureLayer) layer2;
                            IFeatureRenderer renderer = layer3.Renderer;
                            for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                            {
                                if (renderer.get_SymbolByFeature(feature) != null)
                                {
                                    pFeatureCollection.Add(feature, null, null, null);
                                    collection2.Add(layer2, null, null, null);
                                }
                            }
                        }
                    }
                }
                feature = null;
                cursor = null;
                layer2 = null;
                layer = null;
                if (pFeatureCollection.Count <= 0)
                {
                    return false;
                }
                int num = -1;
                if (pFeatureCollection.Count > 1)
                {
                    num = GISFunFactory.FeatureFun.SearchClosestFeatureInCollection(pFeatureCollection, this.mHookHelper.FocusMap, p);
                }
                else
                {
                    num = 1;
                }
                if (num <= 0)
                {
                    return false;
                }
                pNearestFeature = (IFeature) pFeatureCollection[num];
                pNearestFeatureLayer = (IFeatureLayer) collection2[num];
                flag = true;
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "GetNearestFeature", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        private void MeasureFeature(IFeature pFeature, ISymbol pSymbol)
        {
            try
            {
                if (pFeature != null)
                {
                    IActiveView activeView = this.mHookHelper.ActiveView;
                    ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                    IGeometry pGeometry = GISFunFactory.GeometryFun.ConvertGeometrySpatialReference(pFeature.Shape, null, spatialReference);
                    GISFunFactory.FlashFun.FlashGeometry(this.mHookHelper.FocusMap, pGeometry, 200L, false);
                    if (pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        FormMeasureMarker marker = new FormMeasureMarker();
                        marker.SetMeasureResult(activeView, null, pGeometry, (IMarkerSymbol) pSymbol);
                        marker.ShowDialog();
                        marker = null;
                    }
                    else if ((pGeometry.GeometryType == esriGeometryType.esriGeometryLine) | (pGeometry.GeometryType == esriGeometryType.esriGeometryPolyline))
                    {
                        FormMeasureDistance distance = new FormMeasureDistance();
                        distance.SetMeasureResult(activeView, null, pGeometry, (ILineSymbol) pSymbol);
                        distance.ShowDialog();
                        distance = null;
                    }
                    else if (pGeometry.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        FormMeasureArea area = new FormMeasureArea();
                        area.SetMeasureResult(activeView, null, pGeometry, (IFillSymbol) pSymbol);
                        area.ShowDialog();
                        area = null;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "MeasureFeature", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnClick()
        {
            try
            {
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.mHookHelper.Hook = RuntimeHelpers.GetObjectValue(hook);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if ((this.mHookHelper.ActiveView != null) && (button == 1))
                {
                    IFeature pNearestFeature = null;
                    IFeatureLayer pNearestFeatureLayer = null;
                    if ((this.GetNearestFeature(x, y, ref pNearestFeature, ref pNearestFeatureLayer) && (pNearestFeature != null)) && (pNearestFeatureLayer != null))
                    {
                        IGeoFeatureLayer layer2 = (IGeoFeatureLayer) pNearestFeatureLayer;
                        ISymbol pSymbol = layer2.Renderer.get_SymbolByFeature(pNearestFeature);
                        this.MeasureFeature(pNearestFeature, pSymbol);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "OnMouseDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override bool Enabled
        {
            get
            {
                bool flag = false;
                try
                {
                    if (this.mHookHelper.ActiveView == null)
                    {
                        return false;
                    }
                    flag = true;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureFeatureTool", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

