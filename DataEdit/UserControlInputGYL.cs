namespace DataEdit
{
    using AttributesEdit;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using ShapeEdit;
    using stdole;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlInputGYL : UserControlBase1
    {
        private ButtonEdit buttonEditDataPath;
        private int column = -1;
        private int column0 = -1;
        private IContainer components = null;
        internal ImageList imageList0;
        private ImageList imageList1;
        internal ImageList imageList2;
        internal ImageList imageList7;
        private Label label1;
        private Label label6;
        private Label labelCount;
        private Label labelIdentify;
        private Label labelprogress;
        private Label labelXBInfo;
        private IFeature m_CountyFeature;
        private IFeatureLayer m_DistLayer;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_GYLLayer;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "DataEdit.UserControlInputGYL";
        private RepositoryItemImageEdit mCurItemImageEdit;
        private RepositoryItemImageEdit mCurItemImageEdit0;
        private RepositoryItemImageEdit mCurItemImageEdit2;
        private RepositoryItemImageEdit mCurItemImageEdit22;
        private RepositoryItemImageEdit mCurItemImageEdit4;
        private RepositoryItemImageEdit mCurItemImageEdit5;
      
        private DockPanel mDockPanel;
        private string mEditKindCode;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mGYLTable = null;
        private IHookHelper mHookHelper;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private ArrayList mQueryList = null;
        private ArrayList mQueryList2 = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private bool mStopList = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IFeatureLayer mXBLayer;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PanelControl panelControl1;
        private Panel panelInfo;
        private Panel panelList;
        private Panel panelLog;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        public SimpleButton simpleButtonAddLayer;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonCheck;
        public SimpleButton simpleButtonInfo;
        public SimpleButton simpleButtonlist;
        public SimpleButton simpleButtonOK;
        private TreeList tList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;

        public UserControlInputGYL()
        {
            this.InitializeComponent();
        }

        private ILayer AddLayer2(string sname, IFeatureClass pFClass, IGroupLayer pGLayer)
        {
            try
            {
                ICompositeLayer layer = pGLayer as ICompositeLayer;
                for (int i = 0; i < layer.Count; i++)
                {
                    ILayer layer2 = layer.get_Layer(i);
                    if (layer2.Name == sname)
                    {
                        pGLayer.Delete(layer2);
                    }
                }
                IFeatureLayer gYLLayer = this.m_GYLLayer;
                this.m_GYLLayer.DisplayField = gYLLayer.FeatureClass.OIDFieldName;
                ILayer layer4 = gYLLayer;
                pGLayer.Add(this.m_GYLLayer);
                IGeoFeatureLayer layer6 = (IGeoFeatureLayer) this.m_GYLLayer;
                ISimpleRenderer renderer = (ISimpleRenderer) layer6.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = 0;
                color2.Blue = 0;
                color2.Green = 0xff;
                symbol3.Color = color2;
                symbol3.Width = 1.1;
                symbol2.Outline = symbol3;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer2 = new SimpleRendererClass();
                renderer2.Symbol = symbol;
                layer6.Renderer = renderer2 as IFeatureRenderer;
                IAnnotateLayerPropertiesCollection annotationProperties = layer6.AnnotationProperties;
                annotationProperties.Clear();
                ILineLabelPosition position = new LineLabelPositionClass();
                position.Parallel = false;
                position.Perpendicular = true;
                ILineLabelPlacementPriorities priorities = new LineLabelPlacementPrioritiesClass();
                IBasicOverposterLayerProperties properties2 = new BasicOverposterLayerPropertiesClass();
                properties2.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                properties2.LineLabelPlacementPriorities = priorities;
                properties2.LineLabelPosition = position;
                properties2.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
                ILabelEngineLayerProperties properties3 = new LabelEngineLayerPropertiesClass();
                properties3.BasicOverposterLayerProperties = properties2;
                properties3.Expression = "[" + gYLLayer.DisplayField + "]";
                ITextSymbol symbol4 = new TextSymbolClass();
                symbol4.Size = 8.0;
                IColor color3 = symbol4.Color;
                stdole.IFontDisp font = symbol4.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 8M;
                IRgbColor color4 = new RgbColorClass();
                color4.Red = 0;
                color4.Blue = 0;
                color4.Green = 0xff;
                color3 = color4;
                symbol4.Color = color3;
                properties3.Symbol = symbol4;
                IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                annotationProperties.Add(item);
                layer6.DisplayAnnotation = true;
                return layer4;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void buttonEditDataPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                data.ShowDialog(this);
                ArrayList layerList = data.LayerList;
                if (layerList != null)
                {
                    if (layerList.Count > 0)
                    {
                        int num = 0;
                        while (num < layerList.Count)
                        {
                            IFeatureLayer layer = layerList[num] as IFeatureLayer;
                            IDataset featureClass = layer.FeatureClass as IDataset;
                            if (num == 0)
                            {
                                this.buttonEditDataPath.Text = featureClass.Workspace.PathName + @"\" + featureClass.Name;
                            }
                            else
                            {
                                this.buttonEditDataPath.Text = this.buttonEditDataPath.Text + "," + featureClass.Workspace.PathName + @"\" + featureClass.Name;
                            }
                            this.m_GYLLayer = layer;
                            int num2 = this.m_GYLLayer.FeatureClass.FeatureCount(null);
                            this.labelCount.Text = "公益林变化数据 共计" + num2 + "个班块";
                            break;
                        }
                        this.buttonEditDataPath.Tag = layerList;
                        this.simpleButtonCheck.Enabled = true;
                        this.simpleButtonlist.Enabled = true;
                        this.simpleButtonAddLayer.Enabled = true;
                    }
                    else
                    {
                        this.buttonEditDataPath.Tag = null;
                        this.simpleButtonCheck.Enabled = false;
                        this.simpleButtonlist.Enabled = false;
                        this.simpleButtonAddLayer.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "buttonEditDataPath_ButtonClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool ClipXBCreateFeature(IFeatureCursor pFCursor, IFeature pf, IFeature pSFeature)
        {
            Exception exception2;
            try
            {
                List<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                List<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                bool flag = false;
                while (pf != null)
                {
                    GC.Collect();
                    Application.DoEvents();
                    int index = pf.Fields.FindField("BHYY");
                    double pFieldValue = 0.0;
                    IGeometry shapeCopy = pf.ShapeCopy;
                    IGeometry other = pSFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    try
                    {
                        IGeometry geometry3;
                        IGeometry geometry4;
                        ITopologicalOperator2 operator2;
                        IFeature feature;
                        string[] strArray;
                        int num3;
                        int num4;
                        int num5;
                        DataRow[] rowArray;
                        IFeature xBFeature;
                        int num6;
                        IField field;
                        string name;
                        int num7;
                        int num8;
                        int num9;
                        if (((pf.get_Value(index).ToString() == "40") || (pf.get_Value(index).ToString() == "41")) || (pf.get_Value(index).ToString() == "42"))
                        {
                            ITopologicalOperator2 @operator = other as ITopologicalOperator2;
                            @operator.IsKnownSimple_2 = false;
                            @operator.Simplify();
                            try
                            {
                                geometry3 = null;
                                geometry4 = @operator.Intersect(shapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                                if (geometry4.IsEmpty)
                                {
                                    geometry3 = other;
                                }
                                else
                                {
                                    operator2 = geometry4 as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    ITopologicalOperator2 operator3 = other as ITopologicalOperator2;
                                    geometry3 = operator3.Difference(geometry4);
                                }
                                if (!geometry3.IsEmpty)
                                {
                                    feature = this.m_EditLayer.FeatureClass.CreateFeature();
                                    feature.Shape = geometry3;
                                    strArray = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldName2").Split(new char[] { ',' });
                                    num3 = 0;
                                    while (num3 < strArray.Length)
                                    {
                                        num4 = pSFeature.Fields.FindField(strArray[num3]);
                                        num5 = feature.Fields.FindField(strArray[num3]);
                                        if (((num5 > -1) && (num4 > -1)) && (pSFeature.get_Value(num4).ToString() != ""))
                                        {
                                            rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num3] + "' and P_CODE_GJ='" + pSFeature.get_Value(num4).ToString() + "'");
                                            if (rowArray.Length > 0)
                                            {
                                                feature.set_Value(num5, rowArray[0]["P_CODE"].ToString());
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    feature.set_Value(num5, pSFeature.get_Value(num4));
                                                }
                                                catch (Exception)
                                                {
                                                }
                                            }
                                        }
                                        num3++;
                                    }
                                    xBFeature = this.GetXBFeature(pSFeature);
                                    GC.Collect();
                                    if (xBFeature != null)
                                    {
                                        num6 = 0;
                                        while (num6 < feature.Fields.FieldCount)
                                        {
                                            field = feature.Fields.get_Field(num6);
                                            name = field.Name;
                                            if (feature.get_Value(num6).ToString().Trim() == "")
                                            {
                                                if (list2.Contains(name))
                                                {
                                                    num7 = list2.IndexOf(name);
                                                    name = list[num7];
                                                    num8 = xBFeature.Fields.FindField(name);
                                                    if (num8 > -1)
                                                    {
                                                        feature.set_Value(num6, xBFeature.get_Value(num8));
                                                    }
                                                }
                                                else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                                {
                                                    num8 = xBFeature.Fields.FindField(field.Name);
                                                    if (num8 > -1)
                                                    {
                                                        feature.set_Value(num6, xBFeature.get_Value(num8));
                                                    }
                                                }
                                            }
                                            else if (feature.get_Value(num6) == null)
                                            {
                                            }
                                            num6++;
                                        }
                                        GC.Collect();
                                    }
                                    pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, geometry3);
                                    this.UpdateField(feature, "MIAN_JI", pFieldValue);
                                    num9 = feature.Fields.FindField("BHYY");
                                    if (num9 > -1)
                                    {
                                        feature.set_Value(num9, "99");
                                    }
                                    num9 = feature.Fields.FindField("DT_SRC");
                                    if (num9 > -1)
                                    {
                                        feature.set_Value(num9, "88");
                                    }
                                    Editor.UniqueInstance.AddAttribute = false;
                                    feature.Store();
                                    flag = true;
                                    Editor.UniqueInstance.AddAttribute = true;
                                }
                            }
                            catch (Exception)
                            {
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("——失败");
                                }
                                this.richTextBox.Refresh();
                            }
                        }
                        else
                        {
                            ITopologicalOperator2 operator4 = shapeCopy as ITopologicalOperator2;
                            operator4.IsKnownSimple_2 = false;
                            operator4.Simplify();
                            try
                            {
                                geometry4 = operator4.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                                if (!geometry4.IsEmpty)
                                {
                                    operator2 = geometry4 as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    geometry3 = (shapeCopy as ITopologicalOperator2).Difference(geometry4);
                                    if (geometry3.IsEmpty)
                                    {
                                        pf.Delete();
                                    }
                                    else
                                    {
                                        pf.Shape = geometry3;
                                        pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, geometry3);
                                        this.UpdateField(pf, "MIAN_JI", pFieldValue);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("——失败");
                                }
                                this.richTextBox.Refresh();
                            }
                            Editor.UniqueInstance.AddAttribute = false;
                            feature = this.m_EditLayer.FeatureClass.CreateFeature();
                            feature.Shape = other;
                            strArray = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldName2").Split(new char[] { ',' });
                            for (num3 = 0; num3 < strArray.Length; num3++)
                            {
                                num4 = pSFeature.Fields.FindField(strArray[num3]);
                                num5 = feature.Fields.FindField(strArray[num3]);
                                if (((num5 > -1) && (num4 > -1)) && (pSFeature.get_Value(num4).ToString() != ""))
                                {
                                    rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num3] + "' and P_CODE_GJ='" + pSFeature.get_Value(num4).ToString() + "'");
                                    if (rowArray.Length > 0)
                                    {
                                        feature.set_Value(num5, rowArray[0]["P_CODE"].ToString());
                                    }
                                    else
                                    {
                                        try
                                        {
                                            feature.set_Value(num5, pSFeature.get_Value(num4));
                                        }
                                        catch (Exception exception)
                                        {
                                            this.richTextBox.AppendText(" " + strArray[num3] + "字段值赋值出错——" + exception.Message);
                                        }
                                    }
                                }
                            }
                            xBFeature = this.GetXBFeature(pSFeature);
                            GC.Collect();
                            if (xBFeature != null)
                            {
                                for (num6 = 0; num6 < feature.Fields.FieldCount; num6++)
                                {
                                    field = feature.Fields.get_Field(num6);
                                    name = field.Name;
                                    if (feature.get_Value(num6).ToString().Trim() == "")
                                    {
                                        if (list2.Contains(name))
                                        {
                                            num7 = list2.IndexOf(name);
                                            name = list[num7];
                                            num8 = xBFeature.Fields.FindField(name);
                                            if (num8 > -1)
                                            {
                                                feature.set_Value(num6, xBFeature.get_Value(num8));
                                            }
                                        }
                                        else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                        {
                                            num8 = xBFeature.Fields.FindField(field.Name);
                                            if (num8 > -1)
                                            {
                                                feature.set_Value(num6, xBFeature.get_Value(num8));
                                            }
                                        }
                                    }
                                    else if (feature.get_Value(num6) == null)
                                    {
                                    }
                                }
                                GC.Collect();
                            }
                            pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, other);
                            this.UpdateField(feature, "MIAN_JI", pFieldValue);
                            num9 = feature.Fields.FindField("BHYY");
                            if (num9 > -1)
                            {
                                feature.set_Value(num9, "99");
                            }
                            num9 = feature.Fields.FindField("DT_SRC");
                            if (num9 > -1)
                            {
                                feature.set_Value(num9, "88");
                            }
                            feature.Store();
                            flag = true;
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                        GC.Collect();
                    }
                    catch (Exception exception6)
                    {
                        exception2 = exception6;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "ClipXBCreateFeature", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                    }
                    pf = pFCursor.NextFeature();
                }
                return flag;
            }
            catch (Exception exception7)
            {
                exception2 = exception7;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "ClipXBCreateFeature", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                return false;
            }
        }

        private bool ClipXBCreateFeature2(IFeature pSFeature)
        {
            Exception exception2;
            try
            {
                List<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                List<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldName2").Split(new char[] { ',' });
                int index = -1;
                IFeature pObject = null;
                bool flag = false;
                for (int i = 0; i < this.mQueryList2.Count; i++)
                {
                    GC.Collect();
                    IFeature feature2 = this.mQueryList2[i] as IFeature;
                    IGeometry pGeo = null;
                    IGeometry geometry2 = null;
                    IGeometry other = null;
                    Application.DoEvents();
                    int num3 = feature2.Fields.FindField("BHYY");
                    double pFieldValue = 0.0;
                    IGeometry shapeCopy = feature2.ShapeCopy;
                    IGeometry geometry5 = pSFeature.ShapeCopy;
                    if (geometry5.SpatialReference != shapeCopy.SpatialReference)
                    {
                        geometry5.Project(shapeCopy.SpatialReference);
                    }
                    try
                    {
                        ITopologicalOperator2 @operator;
                        IGeometry geometry6;
                        IGeometry geometry7;
                        ITopologicalOperator2 operator2;
                        IGeometry geometry8;
                        int num5;
                        int num6;
                        int num7;
                        DataRow[] rowArray;
                        IFeature xBFeature;
                        int num8;
                        IField field;
                        string name;
                        int num9;
                        int num10;
                        int num11;
                        if (((feature2.get_Value(num3).ToString() == "40") || (feature2.get_Value(num3).ToString() == "41")) || (feature2.get_Value(num3).ToString() == "42"))
                        {
                            @operator = geometry5 as ITopologicalOperator2;
                            @operator.IsKnownSimple_2 = false;
                            @operator.Simplify();
                            try
                            {
                                geometry6 = null;
                                geometry7 = @operator.Intersect(shapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                                if (geometry7.IsEmpty)
                                {
                                    geometry6 = geometry5;
                                }
                                else
                                {
                                    operator2 = geometry7 as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    geometry6 = (geometry5 as ITopologicalOperator2).Difference(geometry7);
                                }
                                if (geometry6.IsEmpty)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    if (pObject == null)
                                    {
                                        pObject = this.m_EditLayer.FeatureClass.CreateFeature();
                                        pObject.Shape = geometry6;
                                    }
                                    else
                                    {
                                        if (pObject.ShapeCopy.SpatialReference != geometry6.SpatialReference)
                                        {
                                            pObject.Shape.Project(geometry6.SpatialReference);
                                        }
                                        ITopologicalOperator2 operator4 = pObject.ShapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        operator2 = geometry6 as ITopologicalOperator2;
                                        operator2.IsKnownSimple_2 = false;
                                        operator2.Simplify();
                                        geometry8 = operator4.Intersect(geometry6, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry8.IsEmpty)
                                        {
                                            pObject.Shape = geometry8;
                                            pObject.Store();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                pObject.Delete();
                                                pObject.Store();
                                            }
                                            catch (Exception)
                                            {
                                            }
                                            break;
                                        }
                                    }
                                    num5 = 0;
                                    while (num5 < strArray.Length)
                                    {
                                        num6 = pSFeature.Fields.FindField(strArray[num5]);
                                        num7 = pObject.Fields.FindField(strArray[num5]);
                                        if (((num7 > -1) && (num6 > -1)) && (pSFeature.get_Value(num6).ToString() != ""))
                                        {
                                            rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num5] + "' and P_CODE_GJ='" + pSFeature.get_Value(num6).ToString() + "'");
                                            if (rowArray.Length > 0)
                                            {
                                                pObject.set_Value(num7, rowArray[0]["P_CODE"].ToString());
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    pObject.set_Value(num7, pSFeature.get_Value(num6));
                                                }
                                                catch (Exception)
                                                {
                                                }
                                            }
                                        }
                                        num5++;
                                    }
                                    xBFeature = this.GetXBFeature(pSFeature);
                                    GC.Collect();
                                    if (xBFeature != null)
                                    {
                                        num8 = 0;
                                        while (num8 < pObject.Fields.FieldCount)
                                        {
                                            field = pObject.Fields.get_Field(num8);
                                            name = field.Name;
                                            num9 = 0;
                                            while (num9 < strArray.Length)
                                            {
                                                if (strArray[num9] == name)
                                                {
                                                    goto Label_0614;
                                                }
                                                num9++;
                                            }
                                            if (pObject.get_Value(num8).ToString().Trim() == "")
                                            {
                                                if (list2.Contains(name))
                                                {
                                                    num10 = list2.IndexOf(name);
                                                    name = list[num10];
                                                    num11 = xBFeature.Fields.FindField(name);
                                                    if (num11 > -1)
                                                    {
                                                        pObject.set_Value(num8, xBFeature.get_Value(num11));
                                                    }
                                                }
                                                else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                                {
                                                    num11 = xBFeature.Fields.FindField(field.Name);
                                                    if (num11 > -1)
                                                    {
                                                        pObject.set_Value(num8, xBFeature.get_Value(num11));
                                                    }
                                                }
                                            }
                                            else if (pObject.get_Value(num8) == null)
                                            {
                                            }
                                        Label_0614:
                                            num8++;
                                        }
                                        GC.Collect();
                                    }
                                    pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, geometry6);
                                    this.UpdateField(pObject, "MIAN_JI", pFieldValue);
                                    index = pObject.Fields.FindField("BHYY");
                                    if (index > -1)
                                    {
                                        pObject.set_Value(index, "99");
                                    }
                                    index = pObject.Fields.FindField("DT_SRC");
                                    if (index > -1)
                                    {
                                        pObject.set_Value(index, "88");
                                    }
                                    Editor.UniqueInstance.AddAttribute = false;
                                    pObject.Store();
                                    flag = true;
                                    Editor.UniqueInstance.AddAttribute = true;
                                }
                            }
                            catch (Exception)
                            {
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("——失败");
                                }
                                this.richTextBox.Refresh();
                            }
                        }
                        else
                        {
                            Exception exception;
                            ITopologicalOperator2 operator5 = shapeCopy as ITopologicalOperator2;
                            operator5.IsKnownSimple_2 = false;
                            operator5.Simplify();
                            try
                            {
                                geometry7 = operator5.Intersect(geometry5, esriGeometryDimension.esriGeometry2Dimension);
                                if (geometry7.IsEmpty)
                                {
                                    other = geometry5;
                                }
                                else
                                {
                                    IGeometry geometry9;
                                    operator2 = geometry7 as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    geometry6 = operator5.Difference(geometry7);
                                    if (geometry6.IsEmpty)
                                    {
                                        @operator = geometry5 as ITopologicalOperator2;
                                        geometry9 = @operator.Difference(geometry7);
                                        if (!geometry9.IsEmpty)
                                        {
                                            other = geometry9;
                                        }
                                    }
                                    else
                                    {
                                        if (!geometry7.IsEmpty)
                                        {
                                            pGeo = geometry7;
                                        }
                                        if (!geometry6.IsEmpty)
                                        {
                                            geometry2 = geometry6;
                                        }
                                        @operator = geometry5 as ITopologicalOperator2;
                                        geometry9 = @operator.Difference(geometry7);
                                        if (!geometry9.IsEmpty)
                                        {
                                            other = geometry9;
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("——失败");
                                }
                                this.richTextBox.Refresh();
                            }
                            if ((pGeo == null) && (geometry2 == null))
                            {
                                num5 = 0;
                                while (num5 < strArray.Length)
                                {
                                    num6 = pSFeature.Fields.FindField(strArray[num5]);
                                    num7 = feature2.Fields.FindField(strArray[num5]);
                                    if (((num7 > -1) && (num6 > -1)) && (pSFeature.get_Value(num6).ToString() != ""))
                                    {
                                        rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num5] + "' and P_CODE_GJ='" + pSFeature.get_Value(num6).ToString() + "'");
                                        if (rowArray.Length > 0)
                                        {
                                            feature2.set_Value(num7, rowArray[0]["P_CODE"].ToString());
                                        }
                                        else
                                        {
                                            try
                                            {
                                                feature2.set_Value(num7, pSFeature.get_Value(num6));
                                            }
                                            catch (Exception exception6)
                                            {
                                                exception = exception6;
                                                this.richTextBox.AppendText(" " + strArray[num5] + "字段值赋值出错——" + exception.Message);
                                            }
                                        }
                                    }
                                    num5++;
                                }
                                feature2.Store();
                                flag = true;
                            }
                            if (pGeo != null)
                            {
                                feature2.Shape = pGeo;
                                num5 = 0;
                                while (num5 < strArray.Length)
                                {
                                    num6 = pSFeature.Fields.FindField(strArray[num5]);
                                    num7 = feature2.Fields.FindField(strArray[num5]);
                                    if (((num7 > -1) && (num6 > -1)) && (pSFeature.get_Value(num6).ToString() != ""))
                                    {
                                        rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num5] + "' and P_CODE_GJ='" + pSFeature.get_Value(num6).ToString() + "'");
                                        if (rowArray.Length > 0)
                                        {
                                            feature2.set_Value(num7, rowArray[0]["P_CODE"].ToString());
                                        }
                                        else
                                        {
                                            try
                                            {
                                                feature2.set_Value(num7, pSFeature.get_Value(num6));
                                            }
                                            catch (Exception exception7)
                                            {
                                                exception = exception7;
                                                this.richTextBox.AppendText(" " + strArray[num5] + "字段值赋值出错——" + exception.Message);
                                            }
                                        }
                                    }
                                    num5++;
                                }
                                pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, pGeo);
                                this.UpdateField(feature2, "MIAN_JI", pFieldValue);
                                feature2.Store();
                                flag = true;
                            }
                            if (geometry2 != null)
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                IFeature feature4 = this.m_EditLayer.FeatureClass.CreateFeature();
                                feature4.Shape = geometry2;
                                num5 = 0;
                                while (num5 < feature2.Fields.FieldCount)
                                {
                                    field = feature2.Fields.get_Field(num5);
                                    if (((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name)) && (feature2.get_Value(num5).ToString().Trim() != ""))
                                    {
                                        feature4.set_Value(num5, feature2.get_Value(num5));
                                    }
                                    num5++;
                                }
                                num5 = 0;
                                while (num5 < strArray.Length)
                                {
                                    num6 = pSFeature.Fields.FindField(strArray[num5]);
                                    num7 = feature2.Fields.FindField(strArray[num5]);
                                    if (((num7 > -1) && (num6 > -1)) && (pSFeature.get_Value(num6).ToString() != ""))
                                    {
                                        rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num5] + "' and P_CODE_GJ='" + pSFeature.get_Value(num6).ToString() + "'");
                                        if (rowArray.Length > 0)
                                        {
                                            feature2.set_Value(num7, rowArray[0]["P_CODE"].ToString());
                                        }
                                        else
                                        {
                                            try
                                            {
                                                feature2.set_Value(num7, pSFeature.get_Value(num6));
                                            }
                                            catch (Exception exception8)
                                            {
                                                exception = exception8;
                                                this.richTextBox.AppendText(" " + strArray[num5] + "字段值赋值出错——" + exception.Message);
                                            }
                                        }
                                    }
                                    num5++;
                                }
                                pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, geometry2);
                                this.UpdateField(feature4, "MIAN_JI", pFieldValue);
                                feature4.Store();
                                flag = true;
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                            if (other != null)
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                if (pObject == null)
                                {
                                    pObject = this.m_EditLayer.FeatureClass.CreateFeature();
                                    pObject.Shape = other;
                                }
                                else
                                {
                                    if (pObject.ShapeCopy.SpatialReference != other.SpatialReference)
                                    {
                                        pObject.Shape.Project(other.SpatialReference);
                                    }
                                    @operator = pObject.ShapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    operator2 = other as ITopologicalOperator2;
                                    operator2.IsKnownSimple_2 = false;
                                    operator2.Simplify();
                                    geometry8 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                                    if (!geometry8.IsEmpty)
                                    {
                                        pObject.Shape = geometry8;
                                        pObject.Store();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            pObject.Delete();
                                            pObject.Store();
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        break;
                                    }
                                }
                                for (num5 = 0; num5 < strArray.Length; num5++)
                                {
                                    num6 = pSFeature.Fields.FindField(strArray[num5]);
                                    num7 = pObject.Fields.FindField(strArray[num5]);
                                    if (((num7 > -1) && (num6 > -1)) && (pSFeature.get_Value(num6).ToString() != ""))
                                    {
                                        rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num5] + "' and P_CODE_GJ='" + pSFeature.get_Value(num6).ToString() + "'");
                                        if (rowArray.Length > 0)
                                        {
                                            pObject.set_Value(num7, rowArray[0]["P_CODE"].ToString());
                                        }
                                        else
                                        {
                                            try
                                            {
                                                pObject.set_Value(num7, pSFeature.get_Value(num6));
                                            }
                                            catch (Exception exception10)
                                            {
                                                exception = exception10;
                                                this.richTextBox.AppendText(" " + strArray[num5] + "字段值赋值出错——" + exception.Message);
                                            }
                                        }
                                    }
                                }
                                xBFeature = this.GetXBFeature(pSFeature);
                                GC.Collect();
                                if (xBFeature != null)
                                {
                                    for (num8 = 0; num8 < pObject.Fields.FieldCount; num8++)
                                    {
                                        field = pObject.Fields.get_Field(num8);
                                        name = field.Name;
                                        for (num9 = 0; num9 < strArray.Length; num9++)
                                        {
                                            if (strArray[num9] == name)
                                            {
                                                continue;
                                            }
                                        }
                                        if (pObject.get_Value(num8).ToString().Trim() == "")
                                        {
                                            if (list2.Contains(name))
                                            {
                                                num10 = list2.IndexOf(name);
                                                name = list[num10];
                                                num11 = xBFeature.Fields.FindField(name);
                                                if (num11 > -1)
                                                {
                                                    pObject.set_Value(num8, xBFeature.get_Value(num11));
                                                }
                                            }
                                            else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                            {
                                                num11 = xBFeature.Fields.FindField(field.Name);
                                                if (num11 > -1)
                                                {
                                                    pObject.set_Value(num8, xBFeature.get_Value(num11));
                                                }
                                            }
                                        }
                                        else if (pObject.get_Value(num8) == null)
                                        {
                                        }
                                    }
                                    GC.Collect();
                                }
                                pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, pObject.ShapeCopy);
                                this.UpdateField(pObject, "MIAN_JI", pFieldValue);
                                index = pObject.Fields.FindField("BHYY");
                                if (index > -1)
                                {
                                    pObject.set_Value(index, "99");
                                }
                                index = pObject.Fields.FindField("DT_SRC");
                                if (index > -1)
                                {
                                    pObject.set_Value(index, "88");
                                }
                                index = pObject.Fields.FindField("GXSJ");
                                if (index > -1)
                                {
                                    pObject.set_Value(index, EditTask.TaskYear + "1231");
                                }
                                pObject.Store();
                                flag = true;
                            }
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                        GC.Collect();
                    }
                    catch (Exception exception11)
                    {
                        exception2 = exception11;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "ClipXBCreateFeature2", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                    }
                }
                return flag;
            }
            catch (Exception exception12)
            {
                exception2 = exception12;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "ClipXBCreateFeature2", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
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

        private void DoInput(IWorkspaceEdit pWorkspaceEdit, IFeatureClass pSFeatureClass, IFeatureClass pTFeatureClass)
        {
            try
            {
                Process process;
                ProcessStartInfo info;
                List<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields").Split(new char[] { ',' }));
                List<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields").Split(new char[] { ',' }));
                IFeatureCursor cursor = pSFeatureClass.Search(null, false);
                IFeature pSFeature = cursor.NextFeature();
                pWorkspaceEdit.StartEditing(false);
                Editor.UniqueInstance.AddAttribute = false;
                Editor.UniqueInstance.CheckOverlap = false;
                pWorkspaceEdit.StartEditOperation();
                Application.DoEvents();
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.simpleButtonOK.Visible = false;
                this.richTextBox.AppendText("\n开始导入公益林变化图层数据");
                int num = 0;
                int num2 = 0;
                while (pSFeature != null)
                {
                    this.labelprogress.Text = "导入公益林变化图层数据...";
                    this.labelprogress.Visible = true;
                    this.richTextBox.AppendText("\n导入要素" + pSFeature.OID);
                    this.richTextBox.Refresh();
                    num++;
                    num2++;
                    this.labelprogress.Text = "导入公益林变化图层数据第" + num + "个班块";
                    Application.DoEvents();
                    GC.Collect();
                    bool flag = false;
                    if (pSFeature.ShapeCopy.IsEmpty)
                    {
                        this.richTextBox.AppendText("[图形为空忽略]");
                    }
                    else
                    {
                        int num3;
                        GC.Collect();
                        IGeometry shapeCopy = pSFeature.ShapeCopy;
                        if (shapeCopy.SpatialReference != (this.m_EditLayer.FeatureClass as IGeoDataset).SpatialReference)
                        {
                            shapeCopy.Project((this.m_EditLayer.FeatureClass as IGeoDataset).SpatialReference);
                        }
                        this.mQueryList2 = new ArrayList();
                        ISpatialFilter filter = new SpatialFilterClass();
                        filter.Geometry = shapeCopy;
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                        IFeatureCursor cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                        IFeature feature2 = cursor2.NextFeature();
                        while (feature2 != null)
                        {
                            if (this.mQueryList2.Count > 0)
                            {
                                num3 = 0;
                                while (num3 < this.mQueryList2.Count)
                                {
                                    if ((this.mQueryList2[num3] as IFeature).OID == feature2.OID)
                                    {
                                        goto Label_02B9;
                                    }
                                    num3++;
                                }
                                this.mQueryList2.Add(feature2);
                            }
                            else
                            {
                                this.mQueryList2.Add(feature2);
                            }
                        Label_02B9:
                            feature2 = cursor2.NextFeature();
                        }
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        GC.Collect();
                        cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                        feature2 = cursor2.NextFeature();
                        while (feature2 != null)
                        {
                            if (this.mQueryList2.Count > 0)
                            {
                                num3 = 0;
                                while (num3 < this.mQueryList2.Count)
                                {
                                    if ((this.mQueryList2[num3] as IFeature).OID == feature2.OID)
                                    {
                                        goto Label_038B;
                                    }
                                    num3++;
                                }
                                this.mQueryList2.Add(feature2);
                            }
                            else
                            {
                                this.mQueryList2.Add(feature2);
                            }
                        Label_038B:
                            feature2 = cursor2.NextFeature();
                        }
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                        GC.Collect();
                        cursor2 = this.m_EditLayer.FeatureClass.Search(filter, false);
                        for (feature2 = cursor2.NextFeature(); feature2 != null; feature2 = cursor2.NextFeature())
                        {
                            if (this.mQueryList2.Count > 0)
                            {
                                num3 = 0;
                                while (num3 < this.mQueryList2.Count)
                                {
                                    if ((this.mQueryList2[num3] as IFeature).OID == feature2.OID)
                                    {
                                        continue;
                                    }
                                    num3++;
                                }
                                this.mQueryList2.Add(feature2);
                            }
                            else
                            {
                                this.mQueryList2.Add(feature2);
                            }
                        }
                        if (this.mQueryList2.Count > 0)
                        {
                            flag = this.ClipXBCreateFeature2(pSFeature);
                        }
                        if (!flag)
                        {
                            IFeature pObject = this.m_EditLayer.FeatureClass.CreateFeature();
                            IClone shape = (IClone) pSFeature.Shape;
                            if (shape == null)
                            {
                                return;
                            }
                            IPolygon pGeo = (IPolygon) shape.Clone();
                            try
                            {
                                pObject.Shape = new PolygonClass();
                                pObject.Shape = pGeo;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                goto Label_0AF9;
                            }
                            string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldName2").Split(new char[] { ',' });
                            for (num3 = 0; num3 < strArray.Length; num3++)
                            {
                                int num4 = pSFeature.Fields.FindField(strArray[num3]);
                                int num5 = pObject.Fields.FindField(strArray[num3]);
                                if (((num5 > -1) && (num4 > -1)) && (pSFeature.get_Value(num4).ToString() != ""))
                                {
                                    DataRow[] rowArray = this.mGYLTable.Select("CCATOG='" + strArray[num3] + "' and P_CODE_GJ='" + pSFeature.get_Value(num4).ToString() + "'");
                                    if (rowArray.Length > 0)
                                    {
                                        pObject.set_Value(num5, rowArray[0]["P_CODE"].ToString());
                                    }
                                    else
                                    {
                                        try
                                        {
                                            pObject.set_Value(num5, pSFeature.get_Value(num4));
                                        }
                                        catch (Exception exception)
                                        {
                                            this.richTextBox.AppendText(" " + strArray[num3] + "字段值赋值出错——" + exception.Message);
                                        }
                                    }
                                }
                            }
                            IFeature xBFeature = this.GetXBFeature(pSFeature);
                            GC.Collect();
                            if (xBFeature != null)
                            {
                                for (int i = 0; i < pObject.Fields.FieldCount; i++)
                                {
                                    IField field = pObject.Fields.get_Field(i);
                                    string name = field.Name;
                                    for (int j = 0; j < strArray.Length; j++)
                                    {
                                        if (strArray[j] == name)
                                        {
                                            continue;
                                        }
                                    }
                                    if (pObject.get_Value(i).ToString().Trim() == "")
                                    {
                                        int num9;
                                        if (list2.Contains(name))
                                        {
                                            int num8 = list2.IndexOf(name);
                                            name = list[num8];
                                            num9 = xBFeature.Fields.FindField(name);
                                            if (num9 > -1)
                                            {
                                                pObject.set_Value(i, xBFeature.get_Value(num9));
                                            }
                                        }
                                        else if ((((field.Name != "") && (field.Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.m_EditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.m_EditLayer.FeatureClass.AreaField.Name))
                                        {
                                            num9 = xBFeature.Fields.FindField(field.Name);
                                            if (num9 > -1)
                                            {
                                                pObject.set_Value(i, xBFeature.get_Value(num9));
                                            }
                                        }
                                    }
                                    else if (pObject.get_Value(i) == null)
                                    {
                                    }
                                }
                                GC.Collect();
                            }
                            double pFieldValue = 0.0;
                            pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, pGeo);
                            this.UpdateField(pObject, "MIAN_JI", pFieldValue);
                            int index = pObject.Fields.FindField("BHYY");
                            if (index > -1)
                            {
                                pObject.set_Value(index, "99");
                            }
                            index = pObject.Fields.FindField("DT_SRC");
                            if (index > -1)
                            {
                                pObject.set_Value(index, "88");
                            }
                            index = pObject.Fields.FindField("GXSJ");
                            if (index > -1)
                            {
                                pObject.set_Value(index, EditTask.TaskYear + "1231");
                            }
                            Application.DoEvents();
                            try
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                pObject.Store();
                                if (num2 >= 50)
                                {
                                    try
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    catch (Exception)
                                    {
                                        pWorkspaceEdit.StopEditOperation();
                                    }
                                    Editor.UniqueInstance.AddAttribute = true;
                                    Editor.UniqueInstance.CheckOverlap = true;
                                    pWorkspaceEdit.StopEditing(true);
                                    Editor.UniqueInstance.AddAttribute = false;
                                    Editor.UniqueInstance.CheckOverlap = false;
                                    pWorkspaceEdit.StartEditing(false);
                                    pWorkspaceEdit.StartEditOperation();
                                    try
                                    {
                                        if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                                        {
                                            process = new Process();
                                            info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                                            process.StartInfo = info;
                                            process.StartInfo.UseShellExecute = false;
                                            process.Start();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    this.richTextBox.Text = "";
                                    num2 = 0;
                                }
                            }
                            catch (Exception exception2)
                            {
                                this.richTextBox.AppendText("\n数据保存失败——" + exception2.Message);
                                Editor.UniqueInstance.AddAttribute = false;
                                pObject.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                        }
                    }
                Label_0AF9:
                    pSFeature = cursor.NextFeature();
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                catch (Exception)
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                Editor.UniqueInstance.AddAttribute = true;
                Editor.UniqueInstance.CheckOverlap = true;
                pWorkspaceEdit.StopEditing(true);
                this.labelprogress.Text = "导入公益林变化数据 - 完成";
                this.labelprogress.Visible = true;
                MessageBox.Show("导入公益林变化数据完成,成功导入" + num + "个", "数据导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                GC.Collect();
                try
                {
                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                    {
                        process = new Process();
                        info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                        process.StartInfo = info;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                    }
                }
                catch (Exception)
                {
                }
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception3)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "DoInput", exception3.GetHashCode().ToString(), exception3.Source, exception3.Message, "", "", "");
            }
        }

        private double GetArea(ISpatialReference pSrf, IGeometry pGeo)
        {
            if (pGeo == null)
            {
                return 0.0;
            }
            IClone clone = (IClone) pGeo;
            IPolygon polygon = (IPolygon) clone.Clone();
            IGeometry pGeometry = polygon;
            try
            {
                pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeometry, pSrf);
                return Math.Round(Math.Abs((double) (((IArea) pGeometry).Area / 10000.0)), 2);
            }
            catch
            {
                return 0.0;
            }
        }

        private void GetFeatureList()
        {
            try
            {
                this.mQueryList = null;
                IFeatureClass class2 = null;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = "";
                GC.Collect();
                IFeatureCursor cursor = class2.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                this.mQueryList = new ArrayList();
                while (feature != null)
                {
                    this.mQueryList.Add(feature);
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string GetFiledValue(int index, IFeature pf)
        {
            string str2;
            string str = "";
            try
            {
                if (index == -1)
                {
                    return "";
                }
                IField field = pf.Fields.get_Field(index);
                str = pf.get_Value(index).ToString();
                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                {
                    str = "";
                    try
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                        long num = Convert.ToInt64(pf.get_Value(index));
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            if (num == Convert.ToInt64(domain.get_Value(i)))
                            {
                                str = domain.get_Name(i);
                                goto Label_00E9;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        str = pf.get_Value(index).ToString();
                    }
                }
                else
                {
                    str = pf.get_Value(index).ToString();
                }
            Label_00E9:
                str2 = str;
            }
            catch (Exception)
            {
                str2 = str;
            }
            return str2;
        }

        private IFeature GetXBFeature(IFeature pFeature)
        {
            Exception exception;
            try
            {
                if (this.mXBLayer == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    this.mXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                }
                if (this.mXBLayer == null)
                {
                    return null;
                }
                if (this.mXBLayer.FeatureClass == null)
                {
                    return null;
                }
                GC.Collect();
                IFeature feature = null;
                IFeature feature2 = null;
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pFeature.Shape;
                filter.GeometryField = this.mXBLayer.FeatureClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                IFeatureCursor cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                feature = cursor.NextFeature();
                double area = 0.0;
                if (feature == null)
                {
                    GC.Collect();
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                    cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                    feature = cursor.NextFeature();
                    if (feature == null)
                    {
                        GC.Collect();
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                        feature = cursor.NextFeature();
                        if (feature == null)
                        {
                            GC.Collect();
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                            feature = cursor.NextFeature();
                            if (feature == null)
                            {
                            }
                        }
                    }
                }
                GC.Collect();
                while (feature != null)
                {
                    GC.Collect();
                    IGeometry shapeCopy = feature.ShapeCopy;
                    IGeometry other = pFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                    @operator.IsKnownSimple_2 = false;
                    IGeometry geometry3 = null;
                    try
                    {
                        @operator.Simplify();
                        geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    if ((geometry3 != null) && !geometry3.IsEmpty)
                    {
                        if (area == 0.0)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                        else if (area < ((IArea) geometry3).Area)
                        {
                            area = ((IArea) geometry3).Area;
                            feature2 = feature;
                        }
                    }
                    feature = cursor.NextFeature();
                }
                GC.Collect();
                return feature2;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "GetXBFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void GetXBInfo()
        {
            try
            {
                this.panelInfo.Height = 0x7e;
                string name = "BHYY";
                string str2 = "DT_SRC";
                int num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.labelXBInfo.Text = "已有变更小班 共计" + num + "个";
                IQueryFilter queryFilter = new QueryFilterClass();
                int num2 = 0;
                queryFilter.WhereClause = str2 + " = '88'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n公益林导入班块", num2, "个" });
                string configValue = "";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num3 = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                queryFilter.WhereClause = configValue + " <> '' and " + str2 + " = '99'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n遥感判读导入班块", num2, "个" });
                int num4 = this.m_EditLayer.FeatureClass.Fields.FindField(name);
                queryFilter.WhereClause = name + " is not null and " + name + "<>'' and " + str2 + " < '08'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n六专题导入班块", num2, "个" });
                queryFilter.WhereClause = str2 + " = '01' and " + name + "<>''";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中数据来源为造林专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '02' and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为采伐专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '03' and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为火灾专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '04' and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为征占用专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '05' and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为灾害专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '07' and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为案件专题的", num2, "个" });
                this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "GetXBInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Hook(object hook, IFeature pCountyFeature, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_CountyFeature = pCountyFeature;
                this.mQueryResult = pResult;
                this.mQueryResult2 = pResult2;
                this.mDockPanel = pDockPanel;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                    }
                    this.InitialValue();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlInputGYL));
            this.label1 = new Label();
            this.labelCount = new Label();
            this.tList = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new RepositoryItemImageEdit();
            this.panel6 = new Panel();
            this.simpleButtonCheck = new SimpleButton();
            this.imageList2 = new ImageList(this.components);
            this.panel2 = new Panel();
            this.simpleButtonBack = new SimpleButton();
            this.simpleButtonOK = new SimpleButton();
            this.imageList1 = new ImageList(this.components);
            this.panel1 = new Panel();
            this.simpleButtonInfo = new SimpleButton();
            this.imageList0 = new ImageList(this.components);
            this.imageList7 = new ImageList(this.components);
            this.labelIdentify = new Label();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel4 = new Panel();
            this.labelprogress = new Label();
            this.panelList = new Panel();
            this.panel3 = new Panel();
            this.simpleButtonlist = new SimpleButton();
            this.buttonEditDataPath = new ButtonEdit();
            this.label6 = new Label();
            this.panelInfo = new Panel();
            this.labelXBInfo = new Label();
            this.simpleButtonAddLayer = new SimpleButton();
            this.panel5 = new Panel();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageComboBox1.BeginInit();
            this.repositoryItemPictureEdit1.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemImageEdit3.BeginInit();
            this.repositoryItemImageEdit33.BeginInit();
            this.panel6.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.buttonEditDataPath.Properties.BeginInit();
            this.panelInfo.SuspendLayout();
            base.SuspendLayout();
            this.label1.Dock = DockStyle.Top;
            this.label1.ForeColor = Color.Navy;
            this.label1.Location = new System.Drawing.Point(6, 0x7c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x10c, 0x18);
            this.label1.TabIndex = 0;
            this.label1.Text = "请在遥感导入完成后，导入公益林变化数据";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCount.Dock = DockStyle.Bottom;
            this.labelCount.ForeColor = Color.Navy;
            this.labelCount.Location = new System.Drawing.Point(0, 2);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new Size(220, 0x16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "公益林变化数据  共计n个班块";
            this.labelCount.TextAlign = ContentAlignment.MiddleLeft;
            this.tList.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5 });
            this.tList.Dock = DockStyle.Fill;
            this.tList.Location = new System.Drawing.Point(0, 0x4d);
            this.tList.Name = "tList";
            this.tList.BeginUnboundLoad();
            object[] nodeData = new object[5];
            nodeData[0] = "1";
            nodeData[1] = "XX县";
            this.tList.AppendNode(nodeData, -1, 0, 0, 5);
            this.tList.EndUnboundLoad();
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageComboBox1, this.repositoryItemPictureEdit1, this.repositoryItemButtonEdit1, this.repositoryItemImageEdit3, this.repositoryItemImageEdit33 });
            this.tList.Size = new Size(0x10c, 200);
            this.tList.TabIndex = 5;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.MouseUp += new MouseEventHandler(this.tList_MouseUp);
            this.tList.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList_CustomNodeCellEdit);
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.treeListColumn1.Caption = "公益林ID";
            this.treeListColumn1.FieldName = "公益林ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 60;
            this.treeListColumn2.Caption = "县";
            this.treeListColumn2.FieldName = "县";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 70;
            this.treeListColumn3.Caption = "乡";
            this.treeListColumn3.FieldName = "乡";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 70;
            this.treeListColumn4.Caption = "村";
            this.treeListColumn4.FieldName = "村";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 70;
            this.treeListColumn5.Caption = "定位";
            this.treeListColumn5.FieldName = "定位";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 30;
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageComboBox1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.Appearance.Image");
            this.repositoryItemImageComboBox1.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AppearanceFocused.Image = (Image) resources.GetObject("repositoryItemImageComboBox1.AppearanceFocused.Image");
            this.repositoryItemImageComboBox1.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.ButtonsStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemPictureEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemPictureEdit1.Appearance.Image");
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Plus) });
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            this.repositoryItemImageEdit3.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit33.AutoHeight = false;
            this.repositoryItemImageEdit33.Name = "repositoryItemImageEdit33";
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonCheck);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonInfo);
            this.panel6.Dock = DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(6, 0x1a9);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 6, 0, 6);
            this.panel6.Size = new Size(0x10c, 0x26);
            this.panel6.TabIndex = 0x17;
            this.simpleButtonCheck.Dock = DockStyle.Right;
            this.simpleButtonCheck.ImageIndex = 6;
            this.simpleButtonCheck.ImageList = this.imageList2;
            this.simpleButtonCheck.Location = new System.Drawing.Point(0, 6);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x48, 0x1a);
            this.simpleButtonCheck.TabIndex = 13;
            this.simpleButtonCheck.Text = "数据校验";
            this.simpleButtonCheck.ToolTip = "校验公益林数据是否有重叠班块,变化原因是否填写";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "blank16.ico");
            this.imageList2.Images.SetKeyName(1, "tick16.ico");
            this.imageList2.Images.SetKeyName(2, "PART16.ICO");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            this.imageList2.Images.SetKeyName(0x10, "(30,24).png");
            this.imageList2.Images.SetKeyName(0x11, "(00,02).png");
            this.imageList2.Images.SetKeyName(0x12, "(00,17).png");
            this.imageList2.Images.SetKeyName(0x13, "(00,46).png");
            this.imageList2.Images.SetKeyName(20, "(01,10).png");
            this.imageList2.Images.SetKeyName(0x15, "(01,25).png");
            this.imageList2.Images.SetKeyName(0x16, "(05,32).png");
            this.imageList2.Images.SetKeyName(0x17, "(06,32).png");
            this.imageList2.Images.SetKeyName(0x18, "(07,32).png");
            this.imageList2.Images.SetKeyName(0x19, "(08,32).png");
            this.imageList2.Images.SetKeyName(0x1a, "(08,36).png");
            this.imageList2.Images.SetKeyName(0x1b, "(09,36).png");
            this.imageList2.Images.SetKeyName(0x1c, "(10,26).png");
            this.imageList2.Images.SetKeyName(0x1d, "(11,26).png");
            this.imageList2.Images.SetKeyName(30, "(11,29).png");
            this.imageList2.Images.SetKeyName(0x1f, "(12,29).png");
            this.imageList2.Images.SetKeyName(0x20, "(11,32).png");
            this.imageList2.Images.SetKeyName(0x21, "(11,36).png");
            this.imageList2.Images.SetKeyName(0x22, "(13,32).png");
            this.imageList2.Images.SetKeyName(0x23, "(19,31).png");
            this.imageList2.Images.SetKeyName(0x24, "(22,18).png");
            this.imageList2.Images.SetKeyName(0x25, "(25,27).png");
            this.imageList2.Images.SetKeyName(0x26, "(29,43).png");
            this.imageList2.Images.SetKeyName(0x27, "(30,14).png");
            this.imageList2.Images.SetKeyName(40, "5.png");
            this.imageList2.Images.SetKeyName(0x29, "10.png");
            this.imageList2.Images.SetKeyName(0x2a, "11.png");
            this.imageList2.Images.SetKeyName(0x2b, "16.png");
            this.imageList2.Images.SetKeyName(0x2c, "17.png");
            this.imageList2.Images.SetKeyName(0x2d, "18.png");
            this.imageList2.Images.SetKeyName(0x2e, "19.png");
            this.imageList2.Images.SetKeyName(0x2f, "20.png");
            this.imageList2.Images.SetKeyName(0x30, "21.png");
            this.imageList2.Images.SetKeyName(0x31, "22.png");
            this.imageList2.Images.SetKeyName(50, "25.png");
            this.imageList2.Images.SetKeyName(0x33, "31.png");
            this.imageList2.Images.SetKeyName(0x34, "41.png");
            this.imageList2.Images.SetKeyName(0x35, "add.png");
            this.imageList2.Images.SetKeyName(0x36, "bullet_minus.png");
            this.imageList2.Images.SetKeyName(0x37, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x38, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x3a, "cross.png");
            this.imageList2.Images.SetKeyName(0x3b, "down.png");
            this.imageList2.Images.SetKeyName(60, "draw_tools.png");
            this.imageList2.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.imageList2.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.imageList2.Images.SetKeyName(0x42, "flag blue.png");
            this.imageList2.Images.SetKeyName(0x43, "flag red.png");
            this.imageList2.Images.SetKeyName(0x44, "flag yellow.png");
            this.imageList2.Images.SetKeyName(0x45, "31.png");
            this.imageList2.Images.SetKeyName(70, "42.png");
            this.imageList2.Images.SetKeyName(0x47, "control_add_blue.png");
            this.imageList2.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.imageList2.Images.SetKeyName(0x49, "cursor.png");
            this.imageList2.Images.SetKeyName(0x4a, "cursor_small.png");
            this.imageList2.Images.SetKeyName(0x4b, "cut.png");
            this.imageList2.Images.SetKeyName(0x4c, "cut_red.png");
            this.imageList2.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.imageList2.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.imageList2.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.imageList2.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.imageList2.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.imageList2.Images.SetKeyName(0x52, "key.png");
            this.imageList2.Images.SetKeyName(0x53, "page_add.png");
            this.imageList2.Images.SetKeyName(0x54, "page_delete.png");
            this.imageList2.Images.SetKeyName(0x55, "page_white_world.png");
            this.imageList2.Images.SetKeyName(0x56, "page_world.png");
            this.imageList2.Images.SetKeyName(0x57, "reload.png");
            this.imageList2.Images.SetKeyName(0x58, "world_add.png");
            this.imageList2.Images.SetKeyName(0x59, "world_delete.png");
            this.imageList2.Images.SetKeyName(90, "zoom_in.png");
            this.imageList2.Images.SetKeyName(0x5b, "zoom_out.png");
            this.imageList2.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.imageList2.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.imageList2.Images.SetKeyName(0x5e, "Exit.png");
            this.panel2.Dock = DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0x48, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(8, 0x1a);
            this.panel2.TabIndex = 14;
            this.simpleButtonBack.Dock = DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 0x2e;
            this.simpleButtonBack.ImageList = this.imageList2;
            this.simpleButtonBack.Location = new System.Drawing.Point(80, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new Size(60, 0x1a);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new EventHandler(this.simpleButtonBack_Click);
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonOK.ImageIndex = 7;
            this.simpleButtonOK.ImageList = this.imageList1;
            this.simpleButtonOK.Location = new System.Drawing.Point(140, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(60, 0x1a);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "导入";
            this.simpleButtonOK.ToolTip = "导入公益林修正数据";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "20.bmp");
            this.imageList1.Images.SetKeyName(1, "AppDocSave_16.bmp");
            this.imageList1.Images.SetKeyName(2, "BD21298_.GIF");
            this.imageList1.Images.SetKeyName(3, "BPosE.gif");
            this.imageList1.Images.SetKeyName(4, "layer_7_.bmp");
            this.imageList1.Images.SetKeyName(5, "digilin.bmp");
            this.imageList1.Images.SetKeyName(6, "digipnt.bmp");
            this.imageList1.Images.SetKeyName(7, "digipol.bmp");
            this.imageList1.Images.SetKeyName(8, "DisplayXBList.bmp");
            this.imageList1.Images.SetKeyName(9, "EditorsUnboundMode3.bmp");
            this.imageList1.Images.SetKeyName(10, "Fault.bmp");
            this.imageList1.Images.SetKeyName(11, "查看.bmp");
            this.imageList1.Images.SetKeyName(12, "图标10.ico");
            this.imageList1.Images.SetKeyName(13, "PushMsgInfo.ico");
            this.imageList1.Images.SetKeyName(14, "complain.ico");
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(200, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(8, 0x1a);
            this.panel1.TabIndex = 11;
            this.simpleButtonInfo.Dock = DockStyle.Right;
            this.simpleButtonInfo.ImageIndex = 13;
            this.simpleButtonInfo.ImageList = this.imageList1;
            this.simpleButtonInfo.Location = new System.Drawing.Point(0xd0, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(60, 0x1a);
            this.simpleButtonInfo.TabIndex = 9;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.ToolTip = "详细信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.imageList0.ImageStream = (ImageListStreamer) resources.GetObject("imageList0.ImageStream");
            this.imageList0.TransparentColor = Color.Transparent;
            this.imageList0.Images.SetKeyName(0, "(01,49).png");
            this.imageList0.Images.SetKeyName(1, "");
            this.imageList0.Images.SetKeyName(2, "(18,13).png");
            this.imageList0.Images.SetKeyName(3, "(01,46).png");
            this.imageList0.Images.SetKeyName(4, "(05,49).png");
            this.imageList0.Images.SetKeyName(5, "(06,30).png");
            this.imageList0.Images.SetKeyName(6, "(07,30).png");
            this.imageList0.Images.SetKeyName(7, "(09,13).png");
            this.imageList0.Images.SetKeyName(8, "(09,24).png");
            this.imageList0.Images.SetKeyName(9, "(11,49).png");
            this.imageList0.Images.SetKeyName(10, "(18,29).png");
            this.imageList0.Images.SetKeyName(11, "(34,00).png");
            this.imageList0.Images.SetKeyName(12, "(47,25).png");
            this.imageList0.Images.SetKeyName(13, "(48,48).png");
            this.imageList7.ImageStream = (ImageListStreamer) resources.GetObject("imageList7.ImageStream");
            this.imageList7.TransparentColor = Color.Transparent;
            this.imageList7.Images.SetKeyName(0, "(01,49).png");
            this.imageList7.Images.SetKeyName(1, "(18,13).png");
            this.imageList7.Images.SetKeyName(2, "");
            this.imageList7.Images.SetKeyName(3, "(01,46).png");
            this.imageList7.Images.SetKeyName(4, "(05,49).png");
            this.imageList7.Images.SetKeyName(5, "(06,30).png");
            this.imageList7.Images.SetKeyName(6, "(07,30).png");
            this.imageList7.Images.SetKeyName(7, "(09,13).png");
            this.imageList7.Images.SetKeyName(8, "(09,24).png");
            this.imageList7.Images.SetKeyName(9, "(11,49).png");
            this.imageList7.Images.SetKeyName(10, "(18,29).png");
            this.imageList7.Images.SetKeyName(11, "(34,00).png");
            this.imageList7.Images.SetKeyName(12, "(47,25).png");
            this.imageList7.Images.SetKeyName(13, "(48,48).png");
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(6, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(0x10c, 30);
            this.labelIdentify.TabIndex = 0x18;
            this.labelIdentify.Text = "      导入公益林数据";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel4);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(6, 0x94);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0x10c, 0x115);
            this.panelLog.TabIndex = 0x1d;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x10c, 0xdf);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x108, 0xdb);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new Padding(0, 4, 0, 4);
            this.panel4.Size = new Size(0x10c, 0x30);
            this.panel4.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 4);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0x10c, 40);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            this.panelList.Controls.Add(this.tList);
            this.panelList.Controls.Add(this.panel3);
            this.panelList.Controls.Add(this.buttonEditDataPath);
            this.panelList.Controls.Add(this.label6);
            this.panelList.Dock = DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(6, 0x94);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new Padding(0, 2, 0, 0);
            this.panelList.Size = new Size(0x10c, 0x115);
            this.panelList.TabIndex = 30;
            this.panel3.Controls.Add(this.labelCount);
            this.panel3.Controls.Add(this.simpleButtonAddLayer);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.simpleButtonlist);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0x33);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 2, 0, 2);
            this.panel3.Size = new Size(0x10c, 0x1a);
            this.panel3.TabIndex = 6;
            this.simpleButtonlist.Dock = DockStyle.Right;
            this.simpleButtonlist.ImageIndex = 7;
            this.simpleButtonlist.ImageList = this.imageList2;
            this.simpleButtonlist.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonlist.Location = new System.Drawing.Point(0xf6, 2);
            this.simpleButtonlist.Name = "simpleButtonlist";
            this.simpleButtonlist.Size = new Size(0x16, 0x16);
            this.simpleButtonlist.TabIndex = 10;
            this.simpleButtonlist.ToolTip = "显示公益林班块列表";
            this.simpleButtonlist.Click += new EventHandler(this.simpleButtonlist_Click);
            this.buttonEditDataPath.Dock = DockStyle.Top;
            this.buttonEditDataPath.Location = new System.Drawing.Point(0, 30);
            this.buttonEditDataPath.Name = "buttonEditDataPath";
            this.buttonEditDataPath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.buttonEditDataPath.Size = new Size(0x10c, 0x15);
            this.buttonEditDataPath.TabIndex = 15;
            this.buttonEditDataPath.ButtonClick += new ButtonPressedEventHandler(this.buttonEditDataPath_ButtonClick);
            this.label6.BackColor = Color.Transparent;
            this.label6.Dock = DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 2);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x10c, 0x1c);
            this.label6.TabIndex = 0x10;
            this.label6.Text = "导入数据路径:";
            this.label6.TextAlign = ContentAlignment.MiddleLeft;
            this.panelInfo.Controls.Add(this.labelXBInfo);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(6, 30);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(0, 4, 0, 4);
            this.panelInfo.Size = new Size(0x10c, 0x5e);
            this.panelInfo.TabIndex = 0x29;
            this.panelInfo.Visible = false;
            this.labelXBInfo.Dock = DockStyle.Fill;
            this.labelXBInfo.Location = new System.Drawing.Point(0, 4);
            this.labelXBInfo.Name = "labelXBInfo";
            this.labelXBInfo.Size = new Size(0x10c, 0x56);
            this.labelXBInfo.TabIndex = 0;
            this.labelXBInfo.Text = "已有变更小班 共计0个  \r\n导入遥感判读班块0个,已确定变化原因班块0个(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n非遥感判读导入班块0个,(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n\r\n\r\n";
            this.simpleButtonAddLayer.Dock = DockStyle.Right;
            this.simpleButtonAddLayer.ImageIndex = 0x58;
            this.simpleButtonAddLayer.ImageList = this.imageList2;
            this.simpleButtonAddLayer.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonAddLayer.Location = new System.Drawing.Point(220, 2);
            this.simpleButtonAddLayer.Name = "simpleButtonAddLayer";
            this.simpleButtonAddLayer.Size = new Size(0x16, 0x16);
            this.simpleButtonAddLayer.TabIndex = 11;
            this.simpleButtonAddLayer.ToolTip = "加载公益林图层";
            this.simpleButtonAddLayer.Click += new EventHandler(this.simpleButtonAddLayer_Click);
            this.panel5.Dock = DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(0xf2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(4, 0x16);
            this.panel5.TabIndex = 12;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelList);
            base.Controls.Add(this.panelLog);
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.panelInfo);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlInputGYL";
            base.Padding = new Padding(6, 0, 6, 0);
            base.Size = new Size(280, 0x1cf);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageComboBox1.EndInit();
            this.repositoryItemPictureEdit1.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemImageEdit3.EndInit();
            this.repositoryItemImageEdit33.EndInit();
            this.panel6.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.buttonEditDataPath.Properties.EndInit();
            this.panelInfo.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitialTreeList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
                this.mQueryList.Clear();
                IQueryFilter filter = new QueryFilterClass();
                IFeatureCursor cursor = this.m_GYLLayer.FeatureClass.Search(filter, false);
                IFeature pf = cursor.NextFeature();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldName");
                int index = pf.Fields.FindField(configValue);
                if (index == -1)
                {
                    index = 0;
                }
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("GYLFieldDist").Split(new char[] { ',' });
                while (pf != null)
                {
                    node3 = this.tList.AppendNode(pf.get_Value(index).ToString(), parentNode);
                    node3.ImageIndex = 1;
                    node3.StateImageIndex = 3;
                    node3.SelectImageIndex = 1;
                    node3.SetValue(0, pf.get_Value(index).ToString());
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num3 = pf.Fields.FindField(strArray[i]);
                        if (num3 > -1)
                        {
                            node3.SetValue(i + 1, this.GetFiledValue(num3, pf));
                        }
                    }
                    node3.Tag = pf;
                    this.mQueryList.Add(pf);
                    Application.DoEvents();
                    if (this.mStopList)
                    {
                        this.simpleButtonlist.ImageIndex = 7;
                        this.simpleButtonlist.Text = "列表";
                        this.simpleButtonlist.ToolTip = "显示公益林班块列表";
                        break;
                    }
                    pf = cursor.NextFeature();
                }
                this.Cursor = Cursors.Default;
                if (this.mQueryList.Count > 0)
                {
                    this.simpleButtonInfo.Enabled = true;
                }
                else
                {
                    this.simpleButtonInfo.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                this.panelLog.Visible = false;
                this.panelList.BringToFront();
                this.simpleButtonBack.Visible = false;
                this.simpleButtonOK.Visible = true;
                this.simpleButtonOK.Enabled = false;
                this.simpleButtonCheck.Visible = true;
                this.simpleButtonCheck.Enabled = false;
                this.simpleButtonInfo.Enabled = false;
                this.simpleButtonlist.Enabled = false;
                this.simpleButtonAddLayer.Enabled = false;
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
            //    this.mGYLTable = dBAccess.GetDataTable(dBAccess, "select * from T_GYL_SUB");
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_CountyFeature == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.m_DistLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IFeatureLayer;
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    if (this.m_DistLayer != null)
                    {
                        GC.Collect();
                        IQueryFilter queryFilter = new QueryFilterClass();
                        string str3 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                        queryFilter.WhereClause = str3 + "='" + EditTask.DistCode.Substring(0, 6) + "'";
                        this.m_CountyFeature = this.m_DistLayer.Search(queryFilter, false).NextFeature();
                    }
                }
                this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                this.mCurItemImageEdit0.Images = this.imageList0;
                this.mQueryList = new ArrayList();
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tList.Columns[0].Width = (this.tList.Width - 0x26) / 2;
                this.tList.Columns[1].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[2].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[3].Width = (this.tList.Width - 0x26) / 4;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[1].Visible = false;
                this.tList.Columns[2].Visible = false;
                this.tList.Columns[3].Visible = false;
                this.tList.OptionsView.ShowRoot = true;
                this.tList.SelectImageList = null;
                this.tList.StateImageList = null;
                this.tList.OptionsView.ShowButtons = true;
                this.tList.TreeLineStyle = LineStyle.None;
                this.tList.RowHeight = 20;
                this.tList.OptionsBehavior.AutoPopulateColumns = true;
                this.buttonEditDataPath.Text = "";
                this.labelCount.Text = "";
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private IFeatureClass Intersect(IList<IFeatureClass> pFCList, string sFile)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                if ((pFCList == null) || (pFCList.Count < 1))
                {
                    return null;
                }
                IGpValueTableObject obj2 = new GpValueTableObjectClass();
                obj2.SetColumns(1);
                object row = null;
                for (int i = 0; i < pFCList.Count; i++)
                {
                    row = pFCList[i];
                    obj2.AddRow(ref row);
                }
                if (!(Directory.Exists(System.IO.Path.GetDirectoryName(sFile)) && (".shp" == System.IO.Path.GetExtension(sFile))))
                {
                    return null;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Intersect process = new ESRI.ArcGIS.AnalysisTools.Intersect(obj2, sFile);
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                return class2;
            }
            catch
            {
                return null;
            }
        }

        private void labelIdentify_Click(object sender, EventArgs e)
        {
            this.panelInfo.Visible = !this.panelInfo.Visible;
            if (this.panelInfo.Visible)
            {
                this.GetXBInfo();
            }
        }

        private void SetFeatureArea(IFeature pFeature)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        double area = ((IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.mHookHelper.FocusMap.SpatialReference)).Area;
                        string str = EditTask.KindCode.Substring(0, 2);
                        string name = "";
                        string str3 = "";
                        string str4 = "";
                        if (str == "01")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Afforest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "02")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Harvest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "06")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Disaster";
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "07")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "ForestCase";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "04")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 4);
                            name = "Expropriation";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "05")
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                            name = "Fire";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else
                        {
                            area = Math.Round(Math.Abs((double) (area / 10000.0)), 2);
                        }
                        int index = pFeature.Fields.FindField(str3);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        index = pFeature.Fields.FindField(str4);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        pFeature.Store();
                    }
                }
                catch
                {
                }
            }
        }

        private void simpleButtonAddLayer_Click(object sender, EventArgs e)
        {
            IGroupLayer pGLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "公益林", true) as IGroupLayer;
            if (pGLayer == null)
            {
                GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, "公益林");
                pGLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, "公益林", true) as IGroupLayer;
            }
            this.AddLayer2(this.m_GYLLayer.Name, this.m_GYLLayer.FeatureClass, pGLayer);
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.panelList.BringToFront();
            this.simpleButtonBack.Visible = false;
            this.simpleButtonOK.Visible = true;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                bool flag = true;
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.labelprogress.Text = "检查是否有重叠相交小班...";
                this.labelprogress.Visible = true;
                IList<IFeatureClass> pFCList = new List<IFeatureClass>();
                pFCList.Add(this.m_GYLLayer.FeatureClass);
                string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                string sFile = str + @"\gylintersect.shp";
                if (File.Exists(str + "gylintersect.shp"))
                {
                    File.Delete(str + "gylintersect.shp");
                }
                if (File.Exists(str + "gylintersect.dbf"))
                {
                    File.Delete(str + "gylintersect.dbf");
                }
                if (File.Exists(str + "gylintersect.sbn"))
                {
                    File.Delete(str + "gylintersect.sbn");
                }
                if (File.Exists(str + "gylintersect.sbx"))
                {
                    File.Delete(str + "gylintersect.sbx");
                }
                if (File.Exists(str + "gylintersect.shx"))
                {
                    File.Delete(str + "gylintersect.shx");
                }
                if (File.Exists(str + "gylintersect.shp.xml"))
                {
                    File.Delete(str + "gylintersect.shp.xml");
                }
                if (File.Exists(str + "gylintersect.prj"))
                {
                    File.Delete(str + "gylintersect.prj");
                }
                this.richTextBox.Text = "计算公益林图层相交班块";
                Application.DoEvents();
                IFeatureClass class2 = this.Intersect(pFCList, sFile);
                this.Cursor = Cursors.Default;
                int num = class2.FeatureCount(null);
                if (num > 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n公益林图层有", num, "个相交班块" });
                    }
                    else
                    {
                        this.richTextBox.Text = "公益林图层有" + num + "个相交班块";
                    }
                    this.richTextBox.Refresh();
                    this.simpleButtonOK.Enabled = false;
                    flag = false;
                }
                else
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n公益林图层无相交要素";
                    }
                    else
                    {
                        this.richTextBox.Text = "公益林图层无相交要素";
                    }
                    this.richTextBox.Refresh();
                }
                IFeatureClass featureClass = this.m_GYLLayer.FeatureClass;
                this.simpleButtonOK.Enabled = flag;
                if (this.simpleButtonOK.Enabled)
                {
                    this.labelprogress.Text = "公益林校验完成--通过校验，可导入小班变更图层。";
                }
                else
                {
                    this.labelprogress.Text = "公益林校验完成--未通过校验，请进入公益林专题修改后再做更新。";
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "simpleButtonCheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            XtraTabControl control;
            if (this.mQueryList != null)
            {
                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_GYLLayer, this.mQueryList, null, this.sDesKeyField, null, null);
                this.mDockPanel.Visibility = DockVisibility.Visible;
                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                {
                    control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                    if (control != null)
                    {
                        this.mDockPanel.Text = "公益林班块信息";
                        if (control.TabPages[0].Tooltip == "作业设计信息")
                        {
                            control.TabPages[0].PageVisible = false;
                        }
                        if (control.TabPages[1].Tooltip == "查询结果列表")
                        {
                            control.TabPages[1].PageVisible = true;
                            control.SelectedTabPage = control.TabPages[1];
                        }
                    }
                    else
                    {
                        this.mDockPanel.Text = "公益林班块信息";
                    }
                }
            }
            this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_EditLayer, null, null, this.sDesKeyField, null, null);
            if (this.mDockPanel.Controls[0].Controls.Count > 0)
            {
                control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                if (control != null)
                {
                    control.TabPages[1].PageVisible = true;
                }
                else
                {
                    this.mDockPanel.Text = "公益林班块信息";
                }
            }
        }

        private void simpleButtonlist_Click(object sender, EventArgs e)
        {
            if (this.simpleButtonlist.ImageIndex == 7)
            {
                this.simpleButtonlist.ImageIndex = 0x17;
                this.simpleButtonlist.Text = "停止";
                this.simpleButtonlist.ToolTip = "停止显示公益林班块列表";
                this.mStopList = false;
                this.mQueryList = new ArrayList();
                this.InitialTreeList();
            }
            else if (this.simpleButtonlist.ImageIndex == 0x17)
            {
                this.simpleButtonInfo.Enabled = true;
                this.mStopList = true;
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace != null)
                {
                    this.DoInput(editWorkspace, this.m_GYLLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                    this.Cursor = Cursors.Default;
                    this.simpleButtonBack.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "simpleButtonOK_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn5")
            {
                e.RepositoryItem = this.mCurItemImageEdit0;
            }
        }

        private void tList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.column = e.Column.AbsoluteIndex;
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                this.mNode = e.Node;
            }
        }

        private void tList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (((e.X >= this.tList.Columns[0].Width) && (this.column != 1)) && (this.column != 2))
                {
                    if (this.column == 4)
                    {
                        IFeature pFeature = null;
                        pFeature = this.mNode.Tag as IFeature;
                        GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                    }
                    else if (this.column == 5)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool UpdateField(IObject pObject, string sFieldName, object pFieldValue)
        {
            try
            {
                int index = pObject.Fields.FindField(sFieldName);
                if (index > 0)
                {
                    pObject.set_Value(index, pFieldValue);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void ZTOverlap()
        {
            try
            {
                int num2;
                this.labelprogress.Text = this.labelprogress.Text + "\n计算公益林变化小班与专题数据相交情况...";
                this.labelprogress.Visible = true;
                this.richTextBox.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                IList<IFeatureLayer> pLayerList = new List<IFeatureLayer>();
                for (num2 = 0; num2 < EditTask.UnderLayers.Count; num2++)
                {
                    IFeatureLayer item = EditTask.UnderLayers[num2] as IFeatureLayer;
                    if (!item.Name.Contains("公益林"))
                    {
                        pLayerList.Add(item);
                    }
                }
            //    IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                DataTable dataTable = null;
            //    dataTable = dBAccess.GetDataTable(dBAccess, "select * from T_EditTask");
                for (num2 = 0; num2 < dataTable.Rows.Count; num2++)
                {
                    string sCmdText = "update T_EditTask set EditState='0' where ID= " + dataTable.Rows[num2]["ID"].ToString();
                    //dBAccess.ExecuteScalar(sCmdText);
                }
                Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.labelprogress.Text = "计算公益林变化小班与专题数据相交情况...";
                UpdateSub.FindZTOverlap(pLayerList);
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputGYL", "ZTOverlap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

