namespace DataEdit
{
    using AttributesEdit;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
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
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlXBSet : UserControlBase1
    {
        private BarButtonItem barButtonItemChange;
        private BarButtonItem barButtonItemDelete;
        private BarButtonItem barButtonItemInput;
        private BarButtonItem barButtonItemInput2;
        private BarButtonItem barButtonItemInput3;
        private BarButtonItem barButtonItemReadValue;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private int checkcolumn;
        private int column = -1;
        private int columnlist = -1;
        private int columnlist2 = -1;
        private int columnlist3 = -1;
        private IContainer components = null;
        public bool EditFlag = false;
        private GroupControl groupControlCheck;
        private GroupControl groupControlCombine;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ImageCollection imageCollection3;
        internal ImageList imageList0;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        internal ImageList imageList3;
        private ImageList imageList4;
        private ImageList imageList5;
        internal ImageList imageList6;
        internal ImageList imageList7;
        private ImageList imageList8;
        internal ImageList imageList9;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelChkprogress;
        private Label labelIdentify;
        public Label labelinfo;
        private Label labelprogress;
        private Label labelprogress2;
        private Label labelProgressj;
        private Label labelXBInfo;
        private Label labelZTCount;
        private ListBoxControl listBoxDateEque;
        private IFeature m_CountyFeature;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private ITable m_QueryTable;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_UnderLayer;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private IActiveViewEvents_Event mActiveViewEvents;
        private RepositoryItemButtonEdit mButton;
        private TreeListNode mCheckNode;
        private TreeListNode mCheckNode2;
        private const string mClassName = "DataEdit.UserControlXBSet2";
        private ArrayList mConflictList = null;
        private ArrayList mConflictList2 = null;
        private RepositoryItemImageEdit mCurItemImageEdit;
        private RepositoryItemImageEdit mCurItemImageEdit0;
        private RepositoryItemImageEdit mCurItemImageEdit2;
        private RepositoryItemImageEdit mCurItemImageEdit22;
        private RepositoryItemImageEdit mCurItemImageEdit4;
        private RepositoryItemImageEdit mCurItemImageEdit5;
        private RepositoryItemImageEdit mCurItemImageEdit6;
        private RepositoryItemImageEdit mCurItemImageEdit7;
        private RepositoryItemImageEdit mCurItemImageEdit8;
        private RepositoryItemImageEdit mCurItemImageEdit9;
       
        private DockPanel mDockPanel;
        private string mEditKindCode;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private IHookHelper mHookHelper;
        private string mKindCode;
        private DataTable mKindTable;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private TreeListNode mNodeList;
        private TreeListNode mNodeList2;
        private TreeListNode mNodeList3;
        private ArrayList mQueryList = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private DataTable mStateTable;
        private bool mStopFlag = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IFeatureLayer mXBLayer;
        private bool mYaoGan = false;
        private DataTable mZTtable;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel16;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        public Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelClear;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        public Panel panelIDList;
        private Panel panelInfo;
        private Panel panelList;
        private Panel panelLog;
        private Panel panelLog2;
        private Panel panelLogChk;
        private PopupMenu popupMenu1;
        private TreeListNode PopupNode;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit10;
        private RepositoryItemImageEdit repositoryItemImageEdit11;
        private RepositoryItemImageEdit repositoryItemImageEdit12;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private RepositoryItemImageEdit repositoryItemImageEdit3;
        private RepositoryItemImageEdit repositoryItemImageEdit33;
        private RepositoryItemImageEdit repositoryItemImageEdit4;
        private RepositoryItemImageEdit repositoryItemImageEdit5;
        private RepositoryItemImageEdit repositoryItemImageEdit6;
        private RepositoryItemImageEdit repositoryItemImageEdit7;
        private RepositoryItemImageEdit repositoryItemImageEdit8;
        private RepositoryItemImageEdit repositoryItemImageEdit9;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private RichTextBox richTextBox;
        private RichTextBox richTextBoxj;
        private RichTextBox richTextChk;
        private string sDesKeyField;
        public SimpleButton simpleButton2;
        public SimpleButton simpleButton3;
        private SimpleButton simpleButtonAuto;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonBack2;
        public SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonCheck;
        private SimpleButton simpleButtonCheckAll;
        public SimpleButton simpleButtonClearLayer;
        public SimpleButton simpleButtonFinish;
        public SimpleButton simpleButtonInfo;
        public SimpleButton simpleButtonInput;
        public SimpleButton simpleButtonOK;
        public SimpleButton simpleButtonRefresh;
        public SimpleButton simpleButtonSelAll;
        public SimpleButton simpleButtonStop;
        private SimpleButton simpleButtonZTOverlap;
        public SplitterControl splitterControl1;
        public bool StartFlag = false;
        private TreeList tList;
        private TreeList tList2;
        private TreeList tList3;
        private TreeListColumn tListCol1;
        private TreeListColumn tListCol2;
        private TreeListColumn tListCol3;
        private TreeListColumn tListCol4;
        private TreeListColumn tListCol5;
        private TreeListColumn tListCol6;
        private TreeListColumn tListCol7;
        public TreeList tListKind;
        public TreeList tListKind2;
        private ToolTipController toolTipController1;
        private TreeListColumn treeListCol1;
        private TreeListColumn treeListCol2;
        private TreeListColumn treeListCol3;
        private TreeListColumn treeListCol4;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn10;
        private TreeListColumn treeListColumn11;
        private TreeListColumn treeListColumn12;
        private TreeListColumn treeListColumn13;
        private TreeListColumn treeListColumn14;
        private TreeListColumn treeListColumn15;
        private TreeListColumn treeListColumn16;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeListColumn treeListColumn6;
        private TreeListColumn treeListColumn7;
        private TreeListColumn treeListColumn8;
        private TreeListColumn treeListColumn9;
        public XtraTabControl xtraTabControl1;
        public XtraTabPage xtraTabPage1;
        public XtraTabPage xtraTabPage2;
        public XtraTabPage xtraTabPage3;

        public UserControlXBSet()
        {
            this.InitializeComponent();
        }

        private void barButtonItemChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pFeature = tag[0] as IFeature;
                    ArrayList plist = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    IFeature feature = null;
                    for (int i = 1; i < tag.Count; i++)
                    {
                        IFeature pf = tag[i] as IFeature;
                        try
                        {
                            pFeature.Delete();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("删除变更小班——失败", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        IFeature feature4 = this.getHasFeature(plist, pf, list3);
                        if (feature4 != null)
                        {
                            feature = feature4;
                            feature = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                        }
                        else
                        {
                            feature = this.m_EditLayer.FeatureClass.CreateFeature();
                            IGeometry shapeCopy = pf.ShapeCopy;
                            feature.Shape = shapeCopy;
                            plist.Add(pf);
                            list3.Add(feature);
                        }
                        this.ReadValue(feature, pf);
                        this.SetAreaXJ(feature);
                        pFeature.Store();
                        feature.Store();
                        if ((feature != null) && !feature.Shape.IsEmpty)
                        {
                            this.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                        }
                        IGeometry geometry2 = null;
                        if (!pFeature.Shape.IsEmpty)
                        {
                            geometry2 = pFeature.ShapeCopy;
                            if (geometry2.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry2.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry2.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pFeature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry2.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry2.Envelope);
                        }
                        if ((feature != null) && !feature.Shape.IsEmpty)
                        {
                            geometry2 = feature.ShapeCopy;
                            if (geometry2.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry2.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry2.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, feature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry2.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry2.Envelope);
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        MessageBox.Show("导入专题小班——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemInput3_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pFeature = tag[0] as IFeature;
                    ArrayList list2 = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    pFeature.Delete();
                    pFeature.Store();
                    this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        MessageBox.Show("删除变更小班——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemDelete_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pFeature = tag[0] as IFeature;
                    int index = pFeature.Fields.FindField("DT_SRC");
                    ArrayList plist = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    IFeature feature = null;
                    for (int i = 1; i < tag.Count; i++)
                    {
                        IFeature pf = tag[i] as IFeature;
                        IGeometry shapeCopy = pFeature.ShapeCopy;
                        IGeometry other = pf.ShapeCopy;
                        if (shapeCopy.SpatialReference != other.SpatialReference)
                        {
                            shapeCopy.Project(other.SpatialReference);
                        }
                        IFeature feature4 = this.getHasFeature(plist, pf, list3);
                        bool flag = false;
                        if (feature4 != null)
                        {
                            feature = feature4;
                            feature = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                            other = feature.ShapeCopy;
                            flag = true;
                        }
                        ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        try
                        {
                            IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                            if (!geometry3.IsEmpty)
                            {
                                ITopologicalOperator2 operator2 = geometry3 as ITopologicalOperator2;
                                operator2.IsKnownSimple_2 = false;
                                operator2.Simplify();
                                IGeometry geometry4 = (other as ITopologicalOperator2).Difference(geometry3);
                                if (!geometry4.IsEmpty)
                                {
                                    if (!flag)
                                    {
                                        feature = this.m_EditLayer.FeatureClass.CreateFeature();
                                        feature.Shape = geometry4;
                                        list3.Add(feature);
                                        plist.Add(pf);
                                    }
                                    else
                                    {
                                        feature.Shape = geometry4;
                                        for (int j = 0; j < plist.Count; j++)
                                        {
                                            IFeature feature5 = plist[j] as IFeature;
                                            if (feature5.OID == pf.OID)
                                            {
                                                list3[j] = feature;
                                            }
                                        }
                                    }
                                    this.ReadValue(feature, pf);
                                    this.SetAreaXJ(feature);
                                    feature.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature.Store();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("裁切专题小班,并导入图形和属性——失败", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        if (feature != null)
                        {
                            if (!feature.Shape.IsEmpty)
                            {
                                this.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                            }
                        }
                        else
                        {
                            this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                        }
                        IGeometry geometry5 = null;
                        if (!pFeature.Shape.IsEmpty)
                        {
                            geometry5 = pFeature.ShapeCopy;
                            if (geometry5.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry5.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry5.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pFeature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry5.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry5.Envelope);
                        }
                        if ((feature != null) && !feature.Shape.IsEmpty)
                        {
                            geometry5 = feature.ShapeCopy;
                            if (geometry5.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry5.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry5.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, feature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry5.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry5.Envelope);
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        MessageBox.Show("裁切专题小班,并导入图形和属性——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemInput_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemInput2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pFeature = tag[0] as IFeature;
                    int index = pFeature.Fields.FindField("DT_SRC");
                    ArrayList plist = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    IFeature feature = null;
                    for (int i = 1; i < tag.Count; i++)
                    {
                        IFeature pf = tag[i] as IFeature;
                        IGeometry shapeCopy = pFeature.ShapeCopy;
                        IGeometry other = pf.ShapeCopy;
                        if (shapeCopy.SpatialReference != other.SpatialReference)
                        {
                            shapeCopy.Project(other.SpatialReference);
                        }
                        ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        try
                        {
                            IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                            if (!geometry3.IsEmpty)
                            {
                                ITopologicalOperator2 operator2 = geometry3 as ITopologicalOperator2;
                                operator2.IsKnownSimple_2 = false;
                                operator2.Simplify();
                                IGeometry geometry4 = (shapeCopy as ITopologicalOperator2).Difference(geometry3);
                                if (geometry4.IsEmpty)
                                {
                                    pFeature.Delete();
                                }
                                else
                                {
                                    pFeature.Shape = geometry4;
                                }
                                this.SetAreaXJ(pFeature);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("裁切变更小班,导入专题班块——失败", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        IFeature feature4 = this.getHasFeature(plist, pf, list3);
                        if (feature4 != null)
                        {
                            feature = feature4;
                            feature = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                        }
                        else
                        {
                            feature = this.m_EditLayer.FeatureClass.CreateFeature();
                            IGeometry geometry5 = pf.ShapeCopy;
                            feature.Shape = geometry5;
                            plist.Add(pf);
                            list3.Add(feature);
                        }
                        this.ReadValue(feature, pf);
                        this.SetAreaXJ(feature);
                        feature.set_Value(index, EditTask.KindCode.Substring(2, 2));
                        pFeature.Store();
                        feature.Store();
                        this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                        IGeometry geometry6 = null;
                        if (!pFeature.Shape.IsEmpty)
                        {
                            geometry6 = pFeature.ShapeCopy;
                            if (geometry6.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry6.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry6.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pFeature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry6.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry6.Envelope);
                        }
                        if ((feature != null) && !feature.Shape.IsEmpty)
                        {
                            geometry6 = feature.ShapeCopy;
                            if (geometry6.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry6.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry6.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, feature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry6.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry6.Envelope);
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        MessageBox.Show("裁切变更小班,导入专题班块——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemInput2_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemInput3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pFeature = tag[0] as IFeature;
                    int index = pFeature.Fields.FindField("DT_SRC");
                    ArrayList plist = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    IFeature feature = null;
                    for (int i = 1; i < tag.Count; i++)
                    {
                        IFeature pf = tag[i] as IFeature;
                        IFeature feature4 = this.getHasFeature(plist, pf, list3);
                        if (feature4 != null)
                        {
                            feature = feature4;
                            feature = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                        }
                        else
                        {
                            feature = this.m_EditLayer.FeatureClass.CreateFeature();
                            IGeometry shapeCopy = pf.ShapeCopy;
                            feature.Shape = shapeCopy;
                            plist.Add(pf);
                            list3.Add(feature);
                        }
                        this.ReadValue(feature, pf);
                        this.SetAreaXJ(feature);
                        feature.set_Value(index, EditTask.KindCode.Substring(2, 2));
                        feature.Store();
                        if (feature != null)
                        {
                            if (!feature.Shape.IsEmpty)
                            {
                                this.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                            }
                            else
                            {
                                this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                            }
                        }
                        else
                        {
                            this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                        }
                        IGeometry geometry2 = null;
                        if (!pFeature.Shape.IsEmpty)
                        {
                            geometry2 = pFeature.ShapeCopy;
                            if (geometry2.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry2.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry2.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pFeature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry2.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry2.Envelope);
                        }
                        if ((feature != null) && !feature.Shape.IsEmpty)
                        {
                            geometry2 = feature.ShapeCopy;
                            if (geometry2.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                geometry2.Project(this.mHookHelper.FocusMap.SpatialReference);
                                geometry2.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, feature, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, geometry2.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, geometry2.Envelope);
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        MessageBox.Show("导入专题小班——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemInput3_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemReadValue_ItemClick(object sender, ItemClickEventArgs e)
        {
            Exception exception;
            try
            {
                if (this.PopupNode == null)
                {
                    this.PopupNode = this.tList.Selection[0];
                }
                if (this.PopupNode != null)
                {
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    Application.DoEvents();
                    Editor.UniqueInstance.AddAttribute = false;
                    editWorkspace.StartEditing(false);
                    editWorkspace.StartEditOperation();
                    ArrayList tag = this.PopupNode.Tag as ArrayList;
                    IFeature pf = tag[0] as IFeature;
                    ArrayList list2 = new ArrayList();
                    ArrayList list3 = new ArrayList();
                    for (int i = 1; i < tag.Count; i++)
                    {
                        IFeature psf = tag[i] as IFeature;
                        this.ReadValue(pf, psf);
                        this.SetAreaXJ(pf);
                        pf.Store();
                        this.ZoomToFeature(this.mHookHelper.FocusMap, pf);
                        IGeometry shapeCopy = null;
                        if (!pf.Shape.IsEmpty)
                        {
                            shapeCopy = pf.ShapeCopy;
                            if (shapeCopy.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                            {
                                shapeCopy.Project(this.mHookHelper.FocusMap.SpatialReference);
                                shapeCopy.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                            }
                            GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pf, 300L, true);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, this.m_EditLayer, shapeCopy.Envelope);
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground, this.m_EditLayer, shapeCopy.Envelope);
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        editWorkspace.StopEditing(true);
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        MessageBox.Show("读取专题小班属性——失败(" + exception.Message + ")", "手动处理冲突", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "barButtonItemReadValue_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool CheckHasFeature(IGeometry g, int bhyy, int bhyy2, IFeature psf)
        {
            try
            {
                IQueryFilter filter = new QueryFilterClass();
                ISpatialFilter queryFilter = new SpatialFilterClass();
                queryFilter.GeometryField = this.m_EditLayer.FeatureClass.ShapeFieldName;
                queryFilter.Geometry = g;
                queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                IFeature feature = this.m_EditLayer.Search(queryFilter, false).NextFeature();
                if (feature != null)
                {
                    IGeometry shape = feature.Shape;
                    IArea area = shape as IArea;
                    IPointCollection points = shape as IPointCollection;
                    if ((((area.Area == (g as IArea).Area) && (points.PointCount == (g as IPointCollection).PointCount)) && (area.Centroid.X == (g as IArea).Centroid.X)) && (area.Centroid.Y == (g as IArea).Centroid.Y))
                    {
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

        private double ConvertToDouble(object pObj)
        {
            if (pObj == null)
            {
                return 0.0;
            }
            try
            {
                return Convert.ToDouble(pObj);
            }
            catch
            {
                return 0.0;
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

        private void DoAutoInput()
        {
            TreeListNode node = null;
            Exception exception;
            IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
            try
            {
                int num2;
                IFeature feature;
                Process process;
                ProcessStartInfo info;
                Application.DoEvents();
                this.panelList.Visible = false;
                this.panelLog2.Visible = true;
                this.panelLog2.BringToFront();
                this.simpleButtonBack2.Visible = true;
                this.simpleButtonAuto.Visible = false;
                this.simpleButtonCancel.Enabled = false;
                this.simpleButtonFinish.Enabled = false;
                this.simpleButtonBack2.Enabled = false;
                this.simpleButtonRefresh.Enabled = false;
                this.labelProgressj.Text = "";
                this.richTextBoxj.Text = "";
                this.labelProgressj.Text = "自动处理" + this.m_UnderLayer.Name + "相交数据";
                this.labelProgressj.Visible = true;
                this.richTextBoxj.Text = "";
                ArrayList plist = new ArrayList();
                ArrayList list2 = new ArrayList();
                this.mConflictList = new ArrayList();
                this.mConflictList2 = new ArrayList();
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                editWorkspace.StartEditing(false);
                int num = 0;
                for (num2 = 0; num2 < this.tList.Nodes.Count; num2++)
                {
                    Application.DoEvents();
                    num++;
                    node = this.tList.Nodes[num2];
                    ArrayList tag = node.Tag as ArrayList;
                    feature = tag[0] as IFeature;
                    if (!feature.Shape.IsEmpty)
                    {
                    }
                    IFeature feature2 = null;
                    int index = feature.Fields.FindField("DT_SRC");
                    int num4 = feature.Fields.FindField("BHYY");
                    int num5 = feature.Fields.FindField("GXSJ");
                    string[] strArray = node.GetDisplayText(5).Split(new char[] { ',' });
                    bool flag = true;
                    object[] objArray = new object[] { "处理相交数据共 ", this.tList.Nodes.Count, "个 , 第 ", (num2 + 1).ToString(), " 个" };
                    this.labelProgressj.Text = string.Concat(objArray);
                    this.labelProgressj.Refresh();
                    Editor.UniqueInstance.AddAttribute = false;
                    Editor.UniqueInstance.CheckOverlap = false;
                    editWorkspace.StartEditOperation();
                    for (int i = 1; i < tag.Count; i++)
                    {
                        int num7;
                        IGeometry shapeCopy;
                        IGeometry geometry2;
                        IFeature feature4;
                        bool flag2;
                        ITopologicalOperator2 @operator;
                        IGeometry geometry3;
                        ITopologicalOperator2 operator2;
                        ITopologicalOperator2 operator3;
                        IGeometry geometry4;
                        int num8;
                        IFeature feature5;
                        IGeometry geometry5;
                        string str;
                        IFeature pf = tag[i] as IFeature;
                        if (feature.get_Value(index).ToString().Trim() == "99")
                        {
                            num7 = pf.Fields.FindField("BHYY");
                            if (pf.get_Value(num7).ToString().Trim() == "")
                            {
                                if (this.richTextBoxj.Text != "")
                                {
                                    this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为空--忽略" }));
                                }
                                else
                                {
                                    this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为空--忽略" });
                                }
                                this.richTextBoxj.Refresh();
                                flag = false;
                                continue;
                            }
                            if (feature.get_Value(num4).ToString() != "")
                            {
                                if ((((int.Parse(feature.get_Value(num4).ToString()) >= 10) && (int.Parse(feature.get_Value(num4).ToString()) < 20)) && (int.Parse(pf.get_Value(num7).ToString()) >= 20)) && (int.Parse(pf.get_Value(num7).ToString()) < 30))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与来自遥感判读的变更小班[要素", feature.OID, "]变化原因为造林相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为采伐--忽略" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "与来自遥感判读的变更小班[要素", feature.OID, "]变化原因为造林相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为采伐--忽略" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    flag2 = false;
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        geometry2 = feature2.ShapeCopy;
                                        flag2 = true;
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (geometry3.IsEmpty)
                                        {
                                            continue;
                                        }
                                        operator2 = geometry3 as ITopologicalOperator2;
                                        operator2.IsKnownSimple_2 = false;
                                        operator2.Simplify();
                                        operator3 = geometry2 as ITopologicalOperator2;
                                        geometry4 = operator3.Difference(geometry3);
                                        if (geometry4.IsEmpty)
                                        {
                                            continue;
                                        }
                                        if (!flag2)
                                        {
                                            if (this.CheckHasFeature(geometry4, num4, num7, pf))
                                            {
                                                this.richTextBoxj.AppendText("——相同位置已存在变更小班，可能已导入过，忽略");
                                                continue;
                                            }
                                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                            feature2.Shape = geometry4;
                                            list2.Add(feature2);
                                            plist.Add(pf);
                                        }
                                        else
                                        {
                                            feature2.Shape = geometry4;
                                            num8 = 0;
                                            while (num8 < plist.Count)
                                            {
                                                feature5 = plist[num8] as IFeature;
                                                if (feature5.OID == pf.OID)
                                                {
                                                    list2[num8] = feature2;
                                                }
                                                num8++;
                                            }
                                        }
                                        this.ReadValue(feature2, pf);
                                        this.SetAreaXJ(feature2);
                                        feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                        feature2.Store();
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                }
                                if ((((int.Parse(feature.get_Value(num4).ToString()) >= 20) && (int.Parse(feature.get_Value(num4).ToString()) < 30)) && (int.Parse(pf.get_Value(num7).ToString()) >= 1)) && (int.Parse(pf.get_Value(num7).ToString()) < 20))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n来自遥感判读的变化原因为采伐的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "来自遥感判读的变化原因为采伐的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("，导入造林小班[要素" + pf.OID + "]");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "导入造林小班[要素" + pf.OID + "]";
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                    }
                                    else
                                    {
                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                        geometry5 = pf.ShapeCopy;
                                        feature2.Shape = geometry5;
                                        plist.Add(pf);
                                        list2.Add(feature2);
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature.Store();
                                    feature2.Store();
                                }
                                else if ((int.Parse(feature.get_Value(num4).ToString()) == 10) && (int.Parse(pf.get_Value(num7).ToString()) < 20))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变化原因为造林的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变化原因为造林的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("，导入造林小班[要素" + pf.OID + "]");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "导入造林小班[要素" + pf.OID + "]";
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                    }
                                    else
                                    {
                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                        geometry5 = pf.ShapeCopy;
                                        feature2.Shape = geometry5;
                                        plist.Add(pf);
                                        list2.Add(feature2);
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature.Store();
                                    feature2.Store();
                                }
                                else if ((feature.get_Value(num4).ToString() != "") && (feature.get_Value(index).ToString() == "99"))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n是遥感变化检测带有变化原因的小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "是遥感变化检测带有变化原因的小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    flag2 = false;
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        geometry2 = feature2.ShapeCopy;
                                        flag2 = true;
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = geometry2 as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (!geometry4.IsEmpty)
                                            {
                                                if (!flag2)
                                                {
                                                    feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                    feature2.Shape = geometry4;
                                                    list2.Add(feature2);
                                                    plist.Add(pf);
                                                }
                                                else
                                                {
                                                    feature2.Shape = geometry4;
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                this.ReadValue(feature2, pf);
                                                this.SetAreaXJ(feature2);
                                                feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                feature2.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                }
                                else
                                {
                                    geometry5 = null;
                                    str = pf.get_Value(pf.Fields.FindField("GXSJ")).ToString();
                                    if (str.Trim() == "")
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        flag = false;
                                        continue;
                                    }
                                    if (feature.get_Value(num5).ToString().Trim() == "")
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分";
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                operator3 = shapeCopy as ITopologicalOperator2;
                                                geometry4 = operator3.Difference(geometry3);
                                                if (geometry4.IsEmpty)
                                                {
                                                    feature.Delete();
                                                }
                                                else
                                                {
                                                    feature.Shape = geometry4;
                                                    this.SetAreaXJ(feature);
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        }
                                        else
                                        {
                                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                            geometry5 = pf.ShapeCopy;
                                            feature2.Shape = geometry5;
                                            plist.Add(pf);
                                            list2.Add(feature2);
                                        }
                                        this.ReadValue(feature2, pf);
                                        this.SetAreaXJ(feature2);
                                        feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                        feature.Store();
                                        feature2.Store();
                                    }
                                    else if (int.Parse(str) > int.Parse(feature.get_Value(num5).ToString()))
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分";
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                operator3 = shapeCopy as ITopologicalOperator2;
                                                geometry4 = operator3.Difference(geometry3);
                                                if (geometry4.IsEmpty)
                                                {
                                                    feature.Delete();
                                                }
                                                else
                                                {
                                                    feature.Shape = geometry4;
                                                    this.SetAreaXJ(feature);
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        }
                                        else
                                        {
                                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                            geometry5 = pf.ShapeCopy;
                                            feature2.Shape = geometry5;
                                            plist.Add(pf);
                                            list2.Add(feature2);
                                        }
                                        this.ReadValue(feature2, pf);
                                        this.SetAreaXJ(feature2);
                                        feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                        feature.Store();
                                        feature2.Store();
                                    }
                                    else if (int.Parse(str) == int.Parse(feature.get_Value(num5).ToString()))
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间相同的变更小班[要素" + feature.OID + "]--忽略");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间相同的变更小班[要素" + feature.OID + "]--忽略";
                                        }
                                        this.richTextBoxj.Refresh();
                                        flag = false;
                                    }
                                    else
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "\n变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        flag2 = false;
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                            geometry2 = feature2.ShapeCopy;
                                            flag2 = true;
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                operator3 = geometry2 as ITopologicalOperator2;
                                                geometry4 = operator3.Difference(geometry3);
                                                if (!geometry4.IsEmpty)
                                                {
                                                    if (!flag2)
                                                    {
                                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                        feature2.Shape = geometry4;
                                                        list2.Add(feature2);
                                                        plist.Add(pf);
                                                    }
                                                    else
                                                    {
                                                        feature2.Shape = geometry4;
                                                        num8 = 0;
                                                        while (num8 < plist.Count)
                                                        {
                                                            feature5 = plist[num8] as IFeature;
                                                            if (feature5.OID == pf.OID)
                                                            {
                                                                list2[num8] = feature2;
                                                            }
                                                            num8++;
                                                        }
                                                    }
                                                    this.ReadValue(feature2, pf);
                                                    this.SetAreaXJ(feature2);
                                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                    feature2.Store();
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                geometry5 = null;
                                str = pf.get_Value(pf.Fields.FindField("GXSJ")).ToString();
                                if (str.Trim() == "")
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    flag = false;
                                    continue;
                                }
                                if (feature.get_Value(num5).ToString() == "")
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                    }
                                    else
                                    {
                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                        geometry5 = pf.ShapeCopy;
                                        feature2.Shape = geometry5;
                                        plist.Add(pf);
                                        list2.Add(feature2);
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature.Store();
                                    feature2.Store();
                                }
                                else if (int.Parse(str) > int.Parse(feature.get_Value(num5).ToString()))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                    }
                                    else
                                    {
                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                        geometry5 = pf.ShapeCopy;
                                        feature2.Shape = geometry5;
                                        plist.Add(pf);
                                        list2.Add(feature2);
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature.Store();
                                    feature2.Store();
                                }
                                else if (int.Parse(str) == int.Parse(feature.get_Value(num5).ToString()))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变更时间相同的变更小班[要素" + feature.OID + "]--忽略");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变更时间相同的变更小班[要素" + feature.OID + "]--忽略";
                                    }
                                    this.richTextBoxj.Refresh();
                                    flag = false;
                                }
                                else
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    flag2 = false;
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        geometry2 = feature2.ShapeCopy;
                                        flag2 = true;
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = geometry2 as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (!geometry4.IsEmpty)
                                            {
                                                if (!flag2)
                                                {
                                                    feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                    feature2.Shape = geometry4;
                                                    list2.Add(feature2);
                                                    plist.Add(pf);
                                                }
                                                else
                                                {
                                                    feature2.Shape = geometry4;
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                this.ReadValue(feature2, pf);
                                                this.SetAreaXJ(feature2);
                                                feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                feature2.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (feature.get_Value(index).ToString().Trim() != "99")
                            {
                                IFeature feature6;
                                num7 = pf.Fields.FindField("BHYY");
                                if (pf.get_Value(num7).ToString().Trim() == "")
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为空--忽略" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]变化原因为空--忽略" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    flag = false;
                                    continue;
                                }
                                if (((int.Parse(feature.get_Value(num4).ToString()) >= 40) && (int.Parse(feature.get_Value(num4).ToString()) < 50)) && ((int.Parse(pf.get_Value(num7).ToString()) >= 50) || (int.Parse(pf.get_Value(num7).ToString()) < 40)))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]变化原因为征占用相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]裁切相交部分，导入图形和属性" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]变化原因为征占用相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]裁切相交部分，导入图形和属性" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    flag2 = false;
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        geometry2 = feature2.ShapeCopy;
                                        flag2 = true;
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = geometry2 as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                if (feature2 != null)
                                                {
                                                    try
                                                    {
                                                        feature2.Shape = geometry4;
                                                        feature2.Store();
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                            goto Label_46AB;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                else
                                                {
                                                    this.richTextBoxj.AppendText("——" + this.m_UnderLayer.Name + "小班被包括，忽略");
                                                }
                                            }
                                            else
                                            {
                                                if (!flag2)
                                                {
                                                    feature6 = this.GetHasFeature(geometry4, num4, num7, pf);
                                                    if (feature6 != null)
                                                    {
                                                        feature2 = feature6;
                                                    }
                                                    else
                                                    {
                                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                        feature2.Shape = geometry4;
                                                        list2.Add(feature2);
                                                        plist.Add(pf);
                                                    }
                                                }
                                                else
                                                {
                                                    feature2.Shape = geometry4;
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                this.ReadValue(feature2, pf);
                                                this.SetAreaXJ(feature2);
                                                feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                if (feature2.Shape.IsEmpty)
                                                {
                                                    feature2.Delete();
                                                }
                                                feature2.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                }
                                else if ((((int.Parse(feature.get_Value(num4).ToString()) >= 50) || (int.Parse(feature.get_Value(num4).ToString()) < 40)) && (int.Parse(pf.get_Value(num7).ToString()) >= 40)) && (int.Parse(pf.get_Value(num7).ToString()) < 50))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变化原因为非征占用的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变化原因为非征占用的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                                feature.Store();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                                feature.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("，导入征占用小班[要素" + pf.OID + "]");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "导入征占用小班[要素" + pf.OID + "]";
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                    }
                                    else
                                    {
                                        feature6 = this.GetHasFeature(pf.ShapeCopy, num4, num7, pf);
                                        if (feature6 != null)
                                        {
                                            feature2 = feature6;
                                        }
                                        else
                                        {
                                            geometry5 = pf.ShapeCopy;
                                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                            feature2.Shape = geometry5;
                                            plist.Add(pf);
                                            list2.Add(feature2);
                                        }
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature2.Store();
                                }
                                else if ((((int.Parse(feature.get_Value(num4).ToString()) >= 10) && (int.Parse(feature.get_Value(num4).ToString()) < 20)) && (int.Parse(pf.get_Value(num7).ToString()) >= 20)) && (int.Parse(pf.get_Value(num7).ToString()) < 30))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]变化原因为造林相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]裁切相交部分，导入图形和属性" }));
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]变化原因为造林相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]裁切相交部分，导入图形和属性" });
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    flag2 = false;
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                        feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        geometry2 = feature2.ShapeCopy;
                                        flag2 = true;
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = geometry2 as ITopologicalOperator2;
                                            operator3.IsKnownSimple_2 = false;
                                            operator3.Simplify();
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                if (feature2 != null)
                                                {
                                                    try
                                                    {
                                                        feature2.Shape = geometry4;
                                                        feature2.Store();
                                                    }
                                                    catch (Exception)
                                                    {
                                                    }
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                            break;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                else
                                                {
                                                    this.richTextBoxj.AppendText("——" + this.m_UnderLayer.Name + "小班被包括，忽略");
                                                }
                                            }
                                            else
                                            {
                                                if (!flag2)
                                                {
                                                    feature6 = this.GetHasFeature(geometry4, num4, num7, pf);
                                                    if (feature6 != null)
                                                    {
                                                        feature2 = feature6;
                                                    }
                                                    else
                                                    {
                                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                        feature2.Shape = geometry4;
                                                        feature2.Store();
                                                        list2.Add(feature2);
                                                        plist.Add(pf);
                                                    }
                                                }
                                                else
                                                {
                                                    feature2.Shape = geometry4;
                                                    feature2.Store();
                                                    IArea area = geometry4 as IArea;
                                                    double num9 = area.Area;
                                                    num8 = 0;
                                                    while (num8 < plist.Count)
                                                    {
                                                        feature5 = plist[num8] as IFeature;
                                                        if (feature5.OID == pf.OID)
                                                        {
                                                            list2[num8] = feature2;
                                                            break;
                                                        }
                                                        num8++;
                                                    }
                                                }
                                                this.ReadValue(feature2, pf);
                                                this.SetAreaXJ(feature2);
                                                feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                if (feature2.Shape.IsEmpty)
                                                {
                                                    feature2.Delete();
                                                }
                                                feature2.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                }
                                else if ((((int.Parse(feature.get_Value(num4).ToString()) >= 20) && (int.Parse(feature.get_Value(num4).ToString()) < 30)) && (int.Parse(pf.get_Value(num7).ToString()) >= 1)) && (int.Parse(pf.get_Value(num7).ToString()) < 20))
                                {
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("\n变化原因为采伐的变更小班[要素" + feature.OID + "]裁切相交部分");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "变化原因为采伐的变更小班[要素" + feature.OID + "]裁切相交部分";
                                    }
                                    this.richTextBoxj.Refresh();
                                    shapeCopy = feature.ShapeCopy;
                                    geometry2 = pf.ShapeCopy;
                                    if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                    {
                                        shapeCopy.Project(geometry2.SpatialReference);
                                    }
                                    @operator = shapeCopy as ITopologicalOperator2;
                                    @operator.IsKnownSimple_2 = false;
                                    @operator.Simplify();
                                    try
                                    {
                                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                        if (!geometry3.IsEmpty)
                                        {
                                            operator2 = geometry3 as ITopologicalOperator2;
                                            operator2.IsKnownSimple_2 = false;
                                            operator2.Simplify();
                                            operator3 = shapeCopy as ITopologicalOperator2;
                                            geometry4 = operator3.Difference(geometry3);
                                            if (geometry4.IsEmpty)
                                            {
                                                feature.Delete();
                                                feature.Store();
                                            }
                                            else
                                            {
                                                feature.Shape = geometry4;
                                                this.SetAreaXJ(feature);
                                                feature.Store();
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("——失败");
                                        }
                                        this.richTextBoxj.Refresh();
                                    }
                                    if (this.richTextBoxj.Text != "")
                                    {
                                        this.richTextBoxj.AppendText("，导入造林小班[要素" + pf.OID + "]");
                                    }
                                    else
                                    {
                                        this.richTextBoxj.Text = "导入造林小班[要素" + pf.OID + "]";
                                    }
                                    this.richTextBoxj.Refresh();
                                    feature4 = this.getHasFeature(plist, pf, list2);
                                    if (feature4 != null)
                                    {
                                        feature2 = feature4;
                                    }
                                    else
                                    {
                                        feature6 = this.GetHasFeature(pf.ShapeCopy, num4, num7, pf);
                                        if (feature6 != null)
                                        {
                                            feature2 = feature6;
                                        }
                                        else
                                        {
                                            geometry5 = pf.ShapeCopy;
                                            feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                            feature2.Shape = geometry5;
                                            plist.Add(pf);
                                            list2.Add(feature2);
                                        }
                                    }
                                    this.ReadValue(feature2, pf);
                                    this.SetAreaXJ(feature2);
                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    feature2.Store();
                                }
                                else
                                {
                                    geometry5 = null;
                                    str = pf.get_Value(pf.Fields.FindField("GXSJ")).ToString();
                                    if (str.Trim() == "")
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "\n与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "与变更小班[要素", feature.OID, "]相交的", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]更新时间为空--忽略" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        flag = false;
                                        continue;
                                    }
                                    if (feature.get_Value(num5).ToString().Trim() == "")
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间为空的变更小班[要素" + feature.OID + "]裁切相交部分";
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                operator3 = shapeCopy as ITopologicalOperator2;
                                                geometry4 = operator3.Difference(geometry3);
                                                if (geometry4.IsEmpty)
                                                {
                                                    feature.Delete();
                                                    feature.Store();
                                                }
                                                else
                                                {
                                                    feature.Shape = geometry4;
                                                    this.SetAreaXJ(feature);
                                                    feature.Store();
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        }
                                        else
                                        {
                                            feature6 = this.GetHasFeature(pf.ShapeCopy, num4, num7, pf);
                                            if (feature6 != null)
                                            {
                                                feature2 = feature6;
                                            }
                                            else
                                            {
                                                feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                geometry5 = pf.ShapeCopy;
                                                feature2.Shape = geometry5;
                                                plist.Add(pf);
                                                list2.Add(feature2);
                                            }
                                        }
                                        this.ReadValue(feature2, pf);
                                        this.SetAreaXJ(feature2);
                                        if (feature2.Shape.IsEmpty)
                                        {
                                            feature2.Delete();
                                        }
                                        feature2.Store();
                                    }
                                    else if (int.Parse(str) > int.Parse(feature.get_Value(num5).ToString()))
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间较早的变更小班[要素" + feature.OID + "]裁切相交部分";
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                operator3 = shapeCopy as ITopologicalOperator2;
                                                geometry4 = operator3.Difference(geometry3);
                                                if (geometry4.IsEmpty)
                                                {
                                                    feature.Delete();
                                                    feature.Store();
                                                }
                                                else
                                                {
                                                    feature.Shape = geometry4;
                                                    this.SetAreaXJ(feature);
                                                    feature.Store();
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "，导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "导入", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                        }
                                        else
                                        {
                                            feature6 = this.GetHasFeature(pf.ShapeCopy, num4, num7, pf);
                                            if (feature6 != null)
                                            {
                                                feature2 = feature6;
                                            }
                                            else
                                            {
                                                feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                geometry5 = pf.ShapeCopy;
                                                feature2.Shape = geometry5;
                                                plist.Add(pf);
                                                list2.Add(feature2);
                                            }
                                        }
                                        this.ReadValue(feature2, pf);
                                        this.SetAreaXJ(feature2);
                                        feature2.Store();
                                    }
                                    else if (int.Parse(str) == int.Parse(feature.get_Value(num5).ToString()))
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText("\n变更时间相同的变更小班[要素" + feature.OID + "]--忽略");
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = "变更时间相同的变更小班[要素" + feature.OID + "]--忽略";
                                        }
                                        this.richTextBoxj.Refresh();
                                        flag = false;
                                        this.mConflictList.Add(feature);
                                        this.mConflictList2.Add(pf);
                                    }
                                    else
                                    {
                                        if (this.richTextBoxj.Text != "")
                                        {
                                            this.richTextBoxj.AppendText(string.Concat(new object[] { "\n变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" }));
                                        }
                                        else
                                        {
                                            this.richTextBoxj.Text = string.Concat(new object[] { "变更时间较晚的变更小班[要素", feature.OID, "]，裁切", this.m_UnderLayer.Name, "小班[要素", pf.OID, "]相交部分，导入图形和属性" });
                                        }
                                        this.richTextBoxj.Refresh();
                                        shapeCopy = feature.ShapeCopy;
                                        geometry2 = pf.ShapeCopy;
                                        if (shapeCopy.SpatialReference != geometry2.SpatialReference)
                                        {
                                            shapeCopy.Project(geometry2.SpatialReference);
                                        }
                                        feature4 = this.getHasFeature(plist, pf, list2);
                                        flag2 = false;
                                        if (feature4 != null)
                                        {
                                            feature2 = feature4;
                                            feature2 = this.m_EditLayer.FeatureClass.GetFeature(feature4.OID);
                                            geometry2 = feature2.ShapeCopy;
                                            flag2 = true;
                                        }
                                        @operator = shapeCopy as ITopologicalOperator2;
                                        @operator.IsKnownSimple_2 = false;
                                        @operator.Simplify();
                                        try
                                        {
                                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                                            if (!geometry3.IsEmpty)
                                            {
                                                operator2 = geometry3 as ITopologicalOperator2;
                                                operator2.IsKnownSimple_2 = false;
                                                operator2.Simplify();
                                                geometry4 = (geometry2 as ITopologicalOperator2).Difference(geometry3);
                                                if (geometry4.IsEmpty)
                                                {
                                                    if (feature2 != null)
                                                    {
                                                        try
                                                        {
                                                            feature2.Shape = geometry4;
                                                            feature2.Store();
                                                        }
                                                        catch (Exception)
                                                        {
                                                        }
                                                        num8 = 0;
                                                        while (num8 < plist.Count)
                                                        {
                                                            feature5 = plist[num8] as IFeature;
                                                            if (feature5.OID == pf.OID)
                                                            {
                                                                list2[num8] = feature2;
                                                                goto Label_46AB;
                                                            }
                                                            num8++;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (!flag2)
                                                    {
                                                        if (this.CheckHasFeature(geometry4, num4, num7, pf))
                                                        {
                                                            this.richTextBoxj.AppendText("——相同位置已存在变更小班，可能已导入过，忽略");
                                                            continue;
                                                        }
                                                        feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                                                        feature2.Shape = geometry4;
                                                        list2.Add(feature2);
                                                        plist.Add(pf);
                                                    }
                                                    else
                                                    {
                                                        feature2.Shape = geometry4;
                                                        for (num8 = 0; num8 < plist.Count; num8++)
                                                        {
                                                            feature5 = plist[num8] as IFeature;
                                                            if (feature5.OID == pf.OID)
                                                            {
                                                                list2[num8] = feature2;
                                                            }
                                                        }
                                                    }
                                                    this.ReadValue(feature2, pf);
                                                    this.SetAreaXJ(feature2);
                                                    feature2.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                                    if (feature2.Shape.IsEmpty)
                                                    {
                                                        feature2.Delete();
                                                    }
                                                    feature2.Store();
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            if (this.richTextBoxj.Text != "")
                                            {
                                                this.richTextBoxj.AppendText("——失败");
                                            }
                                            this.richTextBoxj.Refresh();
                                        }
                                    }
                                }
                            }
                        Label_46AB:;
                        }
                    }
                    try
                    {
                        editWorkspace.StopEditOperation();
                        Editor.UniqueInstance.AddAttribute = true;
                        Editor.UniqueInstance.CheckOverlap = true;
                        this.richTextBoxj.ScrollToCaret();
                        if (num >= 50)
                        {
                            editWorkspace.StopEditing(true);
                            editWorkspace.StartEditing(false);
                            if (flag)
                            {
                                this.richTextBoxj.AppendText("--[成功]");
                            }
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
                            this.richTextBoxj.Text = "";
                            num = 0;
                        }
                    }
                    catch (Exception exception22)
                    {
                        exception = exception22;
                        this.richTextBoxj.AppendText("--[失败]");
                        this.richTextBoxj.AppendText("[错误来源" + exception.Source + "错误描述" + exception.Message + "]");
                        this.richTextBoxj.ScrollToCaret();
                        editWorkspace.StopEditOperation();
                        Editor.UniqueInstance.AddAttribute = true;
                        Editor.UniqueInstance.CheckOverlap = true;
                        if (num >= 50)
                        {
                            editWorkspace.StopEditing(true);
                            editWorkspace.StartEditing(false);
                            num = 0;
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
                        }
                    }
                }
                editWorkspace.StopEditing(true);
                Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                this.labelProgressj.Text = "导入" + this.m_UnderLayer.Name + "数据 - 完成";
                this.labelProgressj.Visible = true;
                if (this.mConflictList.Count > 0)
                {
                    MessageBox.Show(string.Concat(new object[] { this.m_UnderLayer.Name, "数据完成导入,有", this.mConflictList.Count, "个变更班块与", this.m_UnderLayer.Name, this.mConflictList2.Count, "个班块更新时间相同，需要手动处理。" }), "自动处理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.listBoxDateEque.Items.Clear();
                    this.panelList.Visible = true;
                    this.panelList.Height = this.panelLog2.Height / 2;
                    for (num2 = 0; num2 < this.mConflictList.Count; num2++)
                    {
                        feature = this.mConflictList[num2] as IFeature;
                        this.listBoxDateEque.Items.Add(feature.OID);
                    }
                    this.simpleButtonCancel.Enabled = true;
                    this.simpleButtonFinish.Enabled = true;
                    this.simpleButtonBack2.Enabled = true;
                    this.simpleButtonRefresh.Enabled = true;
                }
                else
                {
                    MessageBox.Show(this.m_UnderLayer.Name + "数据完成导入", "自动处理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.simpleButtonCancel.Enabled = true;
                    this.simpleButtonFinish.Enabled = true;
                    this.simpleButtonBack2.Enabled = true;
                    this.simpleButtonRefresh.Enabled = true;
                }
                this.mHookHelper.ActiveView.Refresh();
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
            }
            catch (Exception exception25)
            {
                exception = exception25;
                try
                {
                    editWorkspace.StopEditOperation();
                    editWorkspace.StopEditing(true);
                    Editor.UniqueInstance.AddAttribute = true;
                    Editor.UniqueInstance.StartEdit(this.m_EditLayer.FeatureClass.FeatureDataset.Workspace, this.mHookHelper.ActiveView.FocusMap);
                    Editor.UniqueInstance.TargetLayer = this.m_EditLayer;
                }
                catch (Exception)
                {
                }
                this.labelProgressj.Text = "导入" + this.m_UnderLayer.Name + "数据 - 中断(错误" + exception.Message + ")";
                this.labelProgressj.Visible = true;
                MessageBox.Show(this.m_UnderLayer.Name + "数据导入中断(错误" + exception.Message + ")", "自动处理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.simpleButtonCancel.Enabled = true;
                this.simpleButtonFinish.Enabled = true;
                this.simpleButtonBack2.Enabled = true;
                this.simpleButtonRefresh.Enabled = true;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "DoAutoInput", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DoCheckLayer(IFeatureLayer pLayer)
        {
            try
            {
                bool flag2 = true;
                bool flag3 = true;
                IFeatureClass featureClass = pLayer.FeatureClass;
                if (pLayer.FeatureClass.FeatureCount(null) == 0)
                {
                    this.richTextChk.AppendText(pLayer.Name + "图层无班块，无需校验重叠相交小班和变化原因与变更时间是否有值。");
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.panelLogChk.Visible = true;
                    this.panelLogChk.BringToFront();
                    this.labelChkprogress.Text = "检查是否有重叠相交小班...";
                    this.labelprogress.Visible = true;
                    IList<IFeatureClass> pFCList = new List<IFeatureClass>();
                    pFCList.Add(pLayer.FeatureClass);
                    string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                    string sFile = str + @"\ztintersect.shp";
                    if (File.Exists(str + "ztintersect.shp"))
                    {
                        File.Delete(str + "ztintersect.shp");
                    }
                    if (File.Exists(str + "ztintersect.dbf"))
                    {
                        File.Delete(str + "ztintersect.dbf");
                    }
                    if (File.Exists(str + "ztintersect.sbn"))
                    {
                        File.Delete(str + "ztintersect.sbn");
                    }
                    if (File.Exists(str + "ztintersect.sbx"))
                    {
                        File.Delete(str + "ztintersect.sbx");
                    }
                    if (File.Exists(str + "ztintersect.shx"))
                    {
                        File.Delete(str + "ztintersect.shx");
                    }
                    if (File.Exists(str + "ztintersect.shp.xml"))
                    {
                        File.Delete(str + "ztintersect.shp.xml");
                    }
                    if (File.Exists(str + "ztintersect.prj"))
                    {
                        File.Delete(str + "ztintersect.prj");
                    }
                    if (this.richTextChk.Text != "")
                    {
                        this.richTextChk.AppendText("\n计算" + pLayer.Name + "图层相交班块");
                    }
                    else
                    {
                        this.richTextChk.Text = "计算" + pLayer.Name + "图层相交班块";
                    }
                    Application.DoEvents();
                    IFeatureClass class3 = this.Intersect(pFCList, sFile);
                    this.Cursor = Cursors.Default;
                    int num = class3.FeatureCount(null);
                    if (num > 0)
                    {
                        if (this.richTextChk.Text != "")
                        {
                            this.richTextChk.Text = string.Concat(new object[] { this.richTextChk.Text, "\n", pLayer.Name, "图层有", num, "个相交班块" });
                        }
                        else
                        {
                            this.richTextChk.Text = string.Concat(new object[] { pLayer.Name, "图层有", num, "个相交班块" });
                        }
                        this.richTextChk.Refresh();
                        flag3 = false;
                    }
                    else
                    {
                        if (this.richTextChk.Text != "")
                        {
                            this.richTextChk.Text = this.richTextChk.Text + "\n" + pLayer.Name + "图层无相交要素";
                        }
                        else
                        {
                            this.richTextChk.Text = pLayer.Name + "图层无相交要素";
                        }
                        this.richTextChk.Refresh();
                        flag3 = true;
                    }
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "ltrim(rtrim(BHYY))='' or BHYY is null or ltrim(rtrim(GXSJ))='' or GXSJ is null";
                    int num2 = featureClass.FeatureCount(queryFilter);
                    if (num2 > 0)
                    {
                        if (this.richTextChk.Text != "")
                        {
                            this.richTextChk.Text = string.Concat(new object[] { this.richTextChk.Text, "\n", pLayer.Name, "图层有", num2, "个变化原因或更新时间未填写的班块" });
                        }
                        else
                        {
                            this.richTextChk.Text = string.Concat(new object[] { pLayer.Name, "图层有", num2, "个变化原因或更新时间未填写的班块" });
                        }
                    }
                    else if (this.richTextChk.Text != "")
                    {
                        this.richTextChk.Text = this.richTextChk.Text + "\n" + pLayer.Name + "图层无变化原因或更新时间未填写的班块";
                    }
                    else
                    {
                        this.richTextChk.Text = pLayer.Name + "图层无变化原因或更新时间未填写的班块";
                    }
                    this.richTextChk.Refresh();
                    if (num2 > 0)
                    {
                        flag2 = false;
                    }
                    if (flag2 && flag3)
                    {
                        this.richTextChk.AppendText("\n" + pLayer.Name + "校验完成--通过校验，可导入小班变更图层。");
                        this.labelChkprogress.Text = pLayer.Name + "校验完成--通过校验，可导入小班变更图层。";
                    }
                    else
                    {
                        this.richTextChk.AppendText("\n" + pLayer.Name + "校验完成--未通过校验，请进入" + pLayer.Name + "专题修改后再做更新。");
                        this.labelChkprogress.Text = pLayer.Name + "校验完成--未通过校验，请进入" + pLayer.Name + "专题修改后再做更新。";
                    }
                }
                string[] strArray = (featureClass as IDataset).Name.Split(new char[] { '.' });
                string str3 = strArray[strArray.Length - 1];
                str3 = str3.Replace("_" + EditTask.TaskYear, "");
                string sCmdText = "";
                if (flag2)
                {
                    sCmdText = "update T_EditTask  set logiccheckstate='1' where layername = '" + str3 + "'";
                }
                else
                {
                    sCmdText = "update T_EditTask  set logiccheckstate='0' where layername = '" + str3 + "'";
                }
             //   this.mDBAccess.ExecuteScalar(sCmdText);
                if (flag3)
                {
                    sCmdText = "update T_EditTask  set toplogiccheckstate='1' where layername = '" + str3 + "'";
                }
                else
                {
                    sCmdText = "update T_EditTask  set toplogiccheckstate='0' where layername = '" + str3 + "'";
                }
             //   this.mDBAccess.ExecuteScalar(sCmdText);
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "DoCheckLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DoInput(IWorkspaceEdit pWorkspaceEdit, IFeatureClass pSFeatureClass, IFeatureClass pTFeatureClass)
        {
            try
            {
                string aliasName = pSFeatureClass.AliasName;
                IFeature pFeature = null;
                pWorkspaceEdit.StartEditing(false);
                pWorkspaceEdit.StartEditOperation();
                Application.DoEvents();
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.simpleButtonBack.Visible = true;
                this.simpleButtonInput.Visible = false;
                this.labelprogress.Text = "";
                this.richTextBox.Text = "";
                this.labelprogress.Text = "导入" + this.m_UnderLayer.Name + "数据";
                this.labelprogress.Visible = true;
                for (int i = 0; i < this.tList2.Nodes.Count; i++)
                {
                    Application.DoEvents();
                    if (this.tList2.Nodes[i].Checked && (this.tList2.Nodes[i].Tag != null))
                    {
                        pFeature = this.tList2.Nodes[i].Tag as IFeature;
                        if (pFeature != null)
                        {
                            string[] strArray2 = new string[] { "导入", this.m_UnderLayer.Name, "数据 , 第 ", (i + 1).ToString(), " 个" };
                            this.labelprogress.Text = string.Concat(strArray2);
                            this.labelprogress.Refresh();
                            if (this.richTextBox.Text != "")
                            {
                                this.richTextBoxj.AppendText("\n导入要素" + pFeature.OID);
                            }
                            else
                            {
                                this.richTextBox.Text = "导入要素" + pFeature.OID;
                            }
                            this.richTextBox.Refresh();
                            this.richTextBox.Refresh();
                            IFeatureClass pSubFClass = this.mFeatureWorkspace.OpenFeatureClass(UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + EditTask.TaskYear);
                            UpdateSub.ImportZTFeature(EditTask.KindCode.Substring(2, 2), pFeature, this.m_EditLayer.FeatureClass, pSubFClass, this.mHookHelper.FocusMap.SpatialReference);
                            IFeature feature2 = this.m_EditLayer.FeatureClass.CreateFeature();
                            IClone shape = (IClone) pFeature.Shape;
                            if (shape == null)
                            {
                                return;
                            }
                            IPolygon polygon = (IPolygon) shape.Clone();
                            try
                            {
                                feature2.Shape = new PolygonClass();
                                feature2.Shape = polygon;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                continue;
                            }
                            string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "InputFieldName").Split(new char[] { ',' });
                            for (int j = 0; j < strArray.Length; j++)
                            {
                                int index = pFeature.Fields.FindField(strArray[j]);
                                int num4 = feature2.Fields.FindField(strArray[j]);
                                if ((index > -1) && (num4 > -1))
                                {
                                    feature2.set_Value(num4, pFeature.get_Value(index));
                                }
                                else if ((index > -1) && (num4 < 0))
                                {
                                    if ((strArray[j] == "ZHMJ") && ((this.mEditKindCode == "Fire") || (this.mEditKindCode == "ZRZH")))
                                    {
                                        num4 = feature2.Fields.FindField("Mian_JI");
                                    }
                                    if (num4 > -1)
                                    {
                                        feature2.set_Value(num4, pFeature.get_Value(index));
                                    }
                                }
                            }
                            try
                            {
                                Editor.UniqueInstance.AddAttribute = false;
                                feature2.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                            catch (Exception)
                            {
                                this.richTextBox.Text = this.richTextBox.Text + "[失败]";
                                Editor.UniqueInstance.AddAttribute = false;
                                feature2.Store();
                                Editor.UniqueInstance.AddAttribute = true;
                            }
                        }
                    }
                }
                try
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                catch (Exception)
                {
                    pWorkspaceEdit.StopEditOperation();
                }
                pWorkspaceEdit.StopEditing(true);
                this.labelprogress.Text = "导入" + this.m_UnderLayer.Name + "数据 - 完成";
                this.labelprogress.Visible = true;
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "DoInput", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DoInput2(IWorkspaceEdit pWorkspaceEdit, IFeatureClass pSFeatureClass, IFeatureClass pTFeatureClass)
        {
            try
            {
                string aliasName = pSFeatureClass.AliasName;
                IFeature psf = null;
                Application.DoEvents();
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.simpleButtonBack.Visible = true;
                this.simpleButtonInput.Visible = false;
                this.simpleButtonStop.Enabled = false;
                this.simpleButtonOK.Enabled = false;
                this.labelinfo.Text = "";
                this.simpleButtonRefresh.Enabled = false;
                this.simpleButtonBack2.Enabled = false;
                this.labelprogress.Text = "";
                this.richTextBox.Text = "";
                this.labelprogress.Text = "导入" + this.m_UnderLayer.Name + "数据";
                this.labelprogress.Visible = true;
                Editor.UniqueInstance.AddAttribute = false;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1");
                int num7 = int.Parse(EditTask.TaskYear) - 1;
                IFeatureClass class2 = this.mFeatureWorkspace.OpenFeatureClass(configValue + "_" + num7.ToString());
                pWorkspaceEdit = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(WorkspaceSource.esriWSSdeWorkspaceFactory) as IWorkspaceEdit;
                if (pWorkspaceEdit != null)
                {
                    Process process;
                    ProcessStartInfo info;
                    pWorkspaceEdit.StartEditing(false);
                    int num = 0;
                    int num2 = 0;
                    for (int i = 0; i < this.tList2.Nodes.Count; i++)
                    {
                        Application.DoEvents();
                        if (this.tList2.Nodes[i].Checked && (this.tList2.Nodes[i].Tag != null))
                        {
                            psf = this.tList2.Nodes[i].Tag as IFeature;
                            if (psf != null)
                            {
                                string[] strArray = new string[] { "导入", this.m_UnderLayer.Name, "数据 , 第 ", (i + 1).ToString(), " 个" };
                                this.labelprogress.Text = string.Concat(strArray);
                                this.labelprogress.Refresh();
                                if (this.richTextBox.Text != "")
                                {
                                    this.richTextBox.AppendText("\n导入要素" + psf.OID);
                                }
                                else
                                {
                                    this.richTextBox.Text = "导入要素" + psf.OID;
                                }
                                this.richTextBox.Refresh();
                                this.richTextBox.ScrollToCaret();
                                IFeature pf = null;
                                try
                                {
                                    pWorkspaceEdit.StartEditOperation();
                                    pf = this.m_EditLayer.FeatureClass.CreateFeature();
                                    pf.Shape = psf.ShapeCopy;
                                    if (!this.ReadValue(pf, psf) && !this.ReadValue(pf, psf))
                                    {
                                        pf.Delete();
                                        pf.Store();
                                        pWorkspaceEdit.StopEditOperation();
                                        pWorkspaceEdit.StopEditing(true);
                                        this.richTextBox.AppendText("[获取二类本底属性失败]");
                                        this.richTextBox.ScrollToCaret();
                                        MessageBox.Show("获取二类本底属性失败," + this.m_UnderLayer.Name + "数据导入中断。", "导入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        Editor.UniqueInstance.AddAttribute = true;
                                        return;
                                    }
                                    GC.Collect();
                                    this.SetAreaXJ(pf);
                                    int index = pf.Fields.FindField("DT_SRC");
                                    int num5 = pf.Fields.FindField("BHYY");
                                    int num6 = pf.Fields.FindField("GXSJ");
                                    pf.set_Value(index, EditTask.KindCode.Substring(2, 2));
                                    if (pf.Shape.IsEmpty)
                                    {
                                        pf.Delete();
                                    }
                                    pf.Store();
                                    pWorkspaceEdit.StopEditOperation();
                                }
                                catch (Exception)
                                {
                                    if (pf != null)
                                    {
                                        pf.Delete();
                                        pf.Store();
                                    }
                                    pWorkspaceEdit.StopEditOperation();
                                    pWorkspaceEdit.StopEditing(true);
                                    this.richTextBox.AppendText("[失败]");
                                    this.richTextBox.ScrollToCaret();
                                    MessageBox.Show(string.Concat(new object[] { "导入班块", psf.OID, "失败,", this.m_UnderLayer.Name, "数据导入中断。" }), "导入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Editor.UniqueInstance.AddAttribute = true;
                                    return;
                                }
                                num++;
                                num2++;
                                if (num == 100)
                                {
                                    pWorkspaceEdit.StopEditing(true);
                                    if (num2 >= 0x3e8)
                                    {
                                        pWorkspaceEdit = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(WorkspaceSource.esriWSSdeWorkspaceFactory) as IWorkspaceEdit;
                                        num2 = 0;
                                    }
                                    pWorkspaceEdit.StartEditing(false);
                                    num = 0;
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
                                }
                                this.richTextBox.AppendText("[成功]");
                                this.richTextBox.ScrollToCaret();
                            }
                        }
                        GC.Collect();
                    }
                    Editor.UniqueInstance.AddAttribute = true;
                    pWorkspaceEdit.StopEditing(true);
                    if (num == 0)
                    {
                        MessageBox.Show("请选择导入要素", "导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.panelLog.Visible = false;
                        this.simpleButtonBack.Visible = false;
                        this.simpleButtonInput.Visible = true;
                        this.simpleButtonSelAll.Visible = true;
                        this.simpleButton2.Visible = true;
                        this.simpleButtonRefresh.Enabled = true;
                    }
                    else
                    {
                        this.labelprogress.Text = "导入" + this.m_UnderLayer.Name + "数据 - 完成";
                        this.labelprogress.Visible = true;
                        MessageBox.Show(this.m_UnderLayer.Name + "数据完成导入", "导入", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.mHookHelper.ActiveView.Refresh();
                        this.simpleButtonStop.Enabled = true;
                        this.simpleButtonOK.Enabled = true;
                        this.simpleButtonRefresh.Enabled = true;
                        this.simpleButtonBack2.Enabled = true;
                        this.simpleButtonRefresh.Enabled = true;
                    }
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
                }
            }
            catch (Exception exception)
            {
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.AddAttribute = true;
                }
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "DoInput2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.simpleButtonStop.Enabled = true;
                this.simpleButtonOK.Enabled = true;
                this.simpleButtonRefresh.Enabled = true;
                this.simpleButtonBack2.Enabled = true;
                this.simpleButtonRefresh.Enabled = true;
            }
        }

        private double GetArea(ISpatialReference pSrf, IGeometry pGeo)
        {
            if (pGeo == null)
            {
                return 0.0;
            }
            try
            {
                pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pSrf);
                return Math.Round(Math.Abs((double) (((IArea) pGeo).Area / 10000.0)), 2);
            }
            catch
            {
                return 0.0;
            }
        }

        private void GetFeatureList(object pObject)
        {
            try
            {
                this.m_QueryTable = null;
                this.m_QueryLayer = null;
                this.mQueryList = null;
                this.mQueryList = new ArrayList();
                ArrayList tag = null;
                TreeList list2 = null;
                ITable table = null;
                if (pObject is ArrayList)
                {
                    tag = pObject as ArrayList;
                }
                else if (pObject is TreeList)
                {
                    list2 = pObject as TreeList;
                }
                if ((tag != null) || (list2 != null))
                {
                    int num;
                    IFeatureClass featureClass = null;
                    IFeatureLayer layer = null;
                    IFeature feature = null;
                    if (tag != null)
                    {
                        for (num = 0; num < tag.Count; num++)
                        {
                            if (tag[num] is IFeatureLayer)
                            {
                                layer = tag[num] as IFeatureLayer;
                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                this.m_QueryLayer = layer;
                            }
                            else if (tag[num] is IFeatureClass)
                            {
                                featureClass = tag[num] as IFeatureClass;
                                layer = new FeatureLayerClass();
                                layer.FeatureClass = featureClass;
                                layer.Name = "";
                                this.m_QueryLayer = layer;
                            }
                            else
                            {
                                if (tag[num] is IFeature)
                                {
                                    featureClass = this.m_EditLayer.FeatureClass;
                                    this.m_QueryLayer = this.m_EditLayer;
                                    break;
                                }
                                if (tag[num] is IFeature)
                                {
                                    featureClass = this.m_EditLayer.FeatureClass;
                                    this.m_QueryLayer = this.m_EditLayer;
                                    break;
                                }
                                if (!(tag[num] is string) && (tag[num] is ITable))
                                {
                                    table = tag[num] as ITable;
                                    this.m_QueryTable = table;
                                }
                            }
                        }
                        IQueryFilter filter = new QueryFilterClass();
                        string str2 = "";
                        if (feature != null)
                        {
                            int index = feature.Fields.FindField("OBJECTID");
                            if (index != -1)
                            {
                                str2 = "OBJECTID=" + feature.get_Value(index).ToString();
                            }
                        }
                        filter.WhereClause = str2;
                        GC.Collect();
                        IFeatureCursor cursor = featureClass.Search(filter, false);
                        for (IFeature feature2 = cursor.NextFeature(); feature2 != null; feature2 = cursor.NextFeature())
                        {
                            this.mQueryList.Add(feature2);
                        }
                    }
                    else if (list2 != null)
                    {
                        this.m_QueryLayer = this.m_EditLayer;
                        for (num = 0; num < list2.Nodes.Count; num++)
                        {
                            if (list2.Nodes[num].Tag is ArrayList)
                            {
                                tag = list2.Nodes[num].Tag as ArrayList;
                                if (tag != null)
                                {
                                    for (int i = 0; i < tag.Count; i++)
                                    {
                                        if (tag[i] is IFeature)
                                        {
                                            this.mQueryList.Add(tag[i] as IFeature);
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (list2.Nodes[num].Tag is IFeature)
                            {
                                this.mQueryList.Add(list2.Nodes[num].Tag as IFeature);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private object GetFieldValue(IObject pObj, string sFieldName)
        {
            try
            {
                if (pObj == null)
                {
                    return null;
                }
                int index = pObj.Fields.FindField(sFieldName);
                if (index < 0)
                {
                    return null;
                }
                return pObj.get_Value(index);
            }
            catch
            {
                return null;
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

        private IFeature getHasFeature(ArrayList plist, IFeature pf, ArrayList plist2)
        {
            try
            {
                for (int i = 0; i < plist.Count; i++)
                {
                    IFeature feature = plist[i] as IFeature;
                    if (feature.OID == pf.OID)
                    {
                        return (plist2[i] as IFeature);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IFeature GetHasFeature(IGeometry g, int bhyy, int bhyy2, IFeature psf)
        {
            try
            {
                IQueryFilter filter = new QueryFilterClass();
                ISpatialFilter queryFilter = new SpatialFilterClass();
                queryFilter.GeometryField = this.m_EditLayer.FeatureClass.ShapeFieldName;
                queryFilter.Geometry = g;
                queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                IFeature feature = this.m_EditLayer.Search(queryFilter, false).NextFeature();
                if (feature != null)
                {
                    IGeometry shape = feature.Shape;
                    IArea area = shape as IArea;
                    IPointCollection points = shape as IPointCollection;
                    if (((((area.Area == (g as IArea).Area) && (points.PointCount == (g as IPointCollection).PointCount)) && (area.Centroid.X == (g as IArea).Centroid.X)) && (area.Centroid.Y == (g as IArea).Centroid.Y)) && (psf.get_Value(bhyy2) == feature.get_Value(bhyy)))
                    {
                        return feature;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetNode(string sKindCode)
        {
            if (sKindCode == "01")
            {
                return "Afforest";
            }
            if (sKindCode == "02")
            {
                return "Harvest";
            }
            if (sKindCode == "05")
            {
                return "Disaster";
            }
            if (sKindCode == "07")
            {
                return "ForestCase";
            }
            if (sKindCode == "04")
            {
                return "Expropriation";
            }
            if (sKindCode == "03")
            {
                return "Fire";
            }
            if (sKindCode == "08")
            {
                return "Sub";
            }
            return "Other";
        }

        private IList<IFeature> GetOverlapList(IFeature pFeature, IFeatureClass pFClass)
        {
            try
            {
                IList<IFeature> list = new List<IFeature>();
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pFeature.ShapeCopy;
                GC.Collect();
                filter.GeometryField = pFClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                IFeatureCursor o = pFClass.Search(filter, false);
                IFeature item = o.NextFeature();
                if (item != null)
                {
                    while (item != null)
                    {
                        list.Add(item);
                        item = o.NextFeature();
                    }
                    Marshal.ReleaseComObject(o);
                }
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                o = pFClass.Search(filter, false);
                item = o.NextFeature();
                if (item != null)
                {
                    while (item != null)
                    {
                        list.Add(item);
                        item = o.NextFeature();
                    }
                    Marshal.ReleaseComObject(o);
                }
                else
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    o = pFClass.Search(filter, false);
                    item = o.NextFeature();
                    if (item != null)
                    {
                        while (item != null)
                        {
                            list.Add(item);
                            item = o.NextFeature();
                        }
                        Marshal.ReleaseComObject(o);
                    }
                }
                GC.Collect();
                return list;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "GetOverlapList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private IList<IFeature> GetOverlapList(IFeature pFeature, IFeatureClass pFClass, out IList<double> pAreaList)
        {
            pAreaList = new List<double>();
            try
            {
                IGeometry shapeCopy;
                IGeometry geometry2;
                double area;
                ITopologicalOperator2 @operator;
                IGeometry geometry3;
                double num3;
                IList<IFeature> list = new List<IFeature>();
                ISpatialFilter filter = new SpatialFilterClass();
                filter.Geometry = pFeature.ShapeCopy;
                GC.Collect();
                filter.GeometryField = pFClass.ShapeFieldName;
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                IFeatureCursor o = pFClass.Search(filter, false);
                IFeature item = o.NextFeature();
                if (item != null)
                {
                    while (item != null)
                    {
                        list.Add(item);
                        shapeCopy = item.ShapeCopy;
                        geometry2 = pFeature.ShapeCopy;
                        area = ((IArea) shapeCopy).Area;
                        if (((IArea) shapeCopy).Area < ((IArea) geometry2).Area)
                        {
                            area = ((IArea) geometry2).Area;
                        }
                        @operator = shapeCopy as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                        if (geometry3.IsEmpty)
                        {
                            pAreaList.Add(0.0);
                        }
                        double num2 = ((IArea) geometry3).Area;
                        num3 = Math.Round((double) ((num2 / area) * 100.0), 2);
                        if (num3 == 0.0)
                        {
                            num3 = Math.Round((double) ((num2 / area) * 100.0), 3);
                        }
                        if (num3 == 0.0)
                        {
                            num3 = Math.Round((double) ((num2 / area) * 100.0), 4);
                        }
                        if (num3 == 0.0)
                        {
                            num3 = Math.Round((double) ((num2 / area) * 100.0), 5);
                        }
                        if (num3 == 0.0)
                        {
                            num3 = Math.Round((double) ((num2 / area) * 100.0), 6);
                        }
                        if (num3 == 0.0)
                        {
                            num3 = (num2 / area) * 100.0;
                        }
                        pAreaList.Add(num3);
                        item = o.NextFeature();
                    }
                    Marshal.ReleaseComObject(o);
                }
                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                o = pFClass.Search(filter, false);
                item = o.NextFeature();
                if (item != null)
                {
                    while (item != null)
                    {
                        list.Add(item);
                        shapeCopy = item.ShapeCopy;
                        geometry2 = pFeature.ShapeCopy;
                        area = ((IArea) shapeCopy).Area;
                        if (((IArea) shapeCopy).Area < ((IArea) geometry2).Area)
                        {
                            area = ((IArea) geometry2).Area;
                        }
                        @operator = shapeCopy as ITopologicalOperator2;
                        @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                        if (geometry3.IsEmpty)
                        {
                            pAreaList.Add(0.0);
                        }
                        num3 = Math.Round((double) ((((IArea) geometry3).Area / area) * 100.0), 2);
                        pAreaList.Add(num3);
                        item = o.NextFeature();
                    }
                    Marshal.ReleaseComObject(o);
                }
                else
                {
                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    o = pFClass.Search(filter, false);
                    item = o.NextFeature();
                    if (item != null)
                    {
                        while (item != null)
                        {
                            list.Add(item);
                            shapeCopy = item.ShapeCopy;
                            geometry2 = pFeature.ShapeCopy;
                            area = ((IArea) shapeCopy).Area;
                            if (((IArea) shapeCopy).Area < ((IArea) geometry2).Area)
                            {
                                area = ((IArea) geometry2).Area;
                            }
                            @operator = shapeCopy as ITopologicalOperator2;
                            @operator.IsKnownSimple_2 = false;
                            @operator.Simplify();
                            geometry3 = @operator.Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                            if (geometry3.IsEmpty)
                            {
                                pAreaList.Add(0.0);
                            }
                            num3 = Math.Round((double) ((((IArea) geometry3).Area / area) * 100.0), 2);
                            pAreaList.Add(num3);
                            item = o.NextFeature();
                        }
                        Marshal.ReleaseComObject(o);
                    }
                }
                return list;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "GetOverlapList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private TreeListNode GetParentNode(string code)
        {
            try
            {
                for (int i = 0; i < this.tListKind.Nodes.Count; i++)
                {
                    if (this.tListKind.Nodes[i].Tag == code)
                    {
                        return this.tListKind.Nodes[i];
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "GetParentNode", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private IFeatureLayer getUnderLayer(string name)
        {
            ArrayList underLayers = EditTask.UnderLayers;
            for (int i = 0; i < underLayers.Count; i++)
            {
                IFeatureLayer layer = underLayers[i] as IFeatureLayer;
                if (layer.Name == name)
                {
                    return layer;
                }
            }
            return null;
        }

        private void GetXBInfo()
        {
            try
            {
                this.panelInfo.Height = 0x6a;
                string name = "BHYY";
                string str2 = "DT_SRC";
                int num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.labelXBInfo.Text = "已有变更小班 共计" + num + "个";
                IQueryFilter queryFilter = new QueryFilterClass();
                int num2 = 0;
                string configValue = "";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                queryFilter.WhereClause = name + " is not null and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') and " + str2 + " < '08'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n六专题导入班块", num2, "个" });
                queryFilter.WhereClause = str2 + " = '01' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中数据来源为造林专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '02' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",采伐专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '03' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",火灾专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '04' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",征占用专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '05' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",灾害专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '07' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",案件专题的", num2, "个" });
                this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num3 = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                queryFilter.WhereClause = configValue + " <> ''";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n遥感判读导入班块", num2, "个" });
                int num4 = this.m_EditLayer.FeatureClass.Fields.FindField(name);
                if (num2 > 0)
                {
                    queryFilter.WhereClause = name + " like '1%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中变化原因为植树造林的", num2, "个" });
                    queryFilter.WhereClause = name + " like '2%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，森林采伐的", num2, "个" });
                    queryFilter.WhereClause = name + " like '3%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，规划调整的", num2, "个" });
                    queryFilter.WhereClause = name + " like '4%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，占用征收的", num2, "个" });
                    queryFilter.WhereClause = name + " like '5%' and " + configValue + "<>'0'and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，毁林开荒的", num2, "个" });
                    queryFilter.WhereClause = name + " = '71' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，火灾的", num2, "个" });
                    queryFilter.WhereClause = "(" + name + " = '70' or " + name + " = '72' or " + name + " = '73') and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，灾害因素的", num2, "个" });
                    queryFilter.WhereClause = name + " like '7%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，自然因素的", num2, "个" });
                    queryFilter.WhereClause = name + " like '9%' and " + configValue + "<>'0'";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "，调查因素的", num2, "个" });
                    this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
                    this.panelInfo.Height = 0xa6;
                }
                queryFilter.WhereClause = str2 + " = '88'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n公益林导入班块", num2, "个" });
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "GetXBInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Hook(object hook, IFeatureLayer pEditFLayer, IFeature pCountyFeature, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_EditLayer = pEditFLayer;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlXBSet));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipItem item3 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipItem item4 = new ToolTipItem();
            SuperToolTip tip5 = new SuperToolTip();
            ToolTipItem item5 = new ToolTipItem();
            SuperToolTip tip6 = new SuperToolTip();
            ToolTipItem item6 = new ToolTipItem();
            this.ImageList1 = new ImageList(this.components);
            this.imageList5 = new ImageList(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.panel6 = new Panel();
            this.simpleButtonFinish = new SimpleButton();
            this.panel7 = new Panel();
            this.simpleButtonOK = new SimpleButton();
            this.panel1 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.imageList2 = new ImageList(this.components);
            this.imageList3 = new ImageList(this.components);
            this.imageList4 = new ImageList(this.components);
            this.imageList6 = new ImageList(this.components);
            this.imageList0 = new ImageList(this.components);
            this.repositoryItemImageEdit4 = new RepositoryItemImageEdit();
            this.imageList7 = new ImageList(this.components);
            this.repositoryItemImageEdit5 = new RepositoryItemImageEdit();
            this.tListKind = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.treeListColumn6 = new TreeListColumn();
            this.repositoryItemImageEdit2 = new RepositoryItemImageEdit();
            this.repositoryItemImageComboBox1 = new RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemImageEdit3 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit33 = new RepositoryItemImageEdit();
            this.imageList8 = new ImageList(this.components);
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelIDList = new Panel();
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.panel9 = new Panel();
            this.simpleButtonBack2 = new SimpleButton();
            this.panel12 = new Panel();
            this.simpleButtonAuto = new SimpleButton();
            this.panel10 = new Panel();
            this.simpleButton3 = new SimpleButton();
            this.tList = new TreeList();
            this.tListCol1 = new TreeListColumn();
            this.tListCol2 = new TreeListColumn();
            this.tListCol3 = new TreeListColumn();
            this.tListCol4 = new TreeListColumn();
            this.tListCol5 = new TreeListColumn();
            this.tListCol6 = new TreeListColumn();
            this.tListCol7 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit6 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit7 = new RepositoryItemImageEdit();
            this.panelLog2 = new Panel();
            this.panelControl2 = new PanelControl();
            this.richTextBoxj = new RichTextBox();
            this.panelList = new Panel();
            this.listBoxDateEque = new ListBoxControl();
            this.label4 = new Label();
            this.panel13 = new Panel();
            this.labelProgressj = new Label();
            this.xtraTabPage2 = new XtraTabPage();
            this.tList2 = new TreeList();
            this.treeListColumn11 = new TreeListColumn();
            this.treeListColumn12 = new TreeListColumn();
            this.treeListColumn13 = new TreeListColumn();
            this.treeListColumn14 = new TreeListColumn();
            this.treeListColumn15 = new TreeListColumn();
            this.repositoryItemImageEdit8 = new RepositoryItemImageEdit();
            this.panel3 = new Panel();
            this.simpleButtonBack = new SimpleButton();
            this.simpleButtonInput = new SimpleButton();
            this.panel5 = new Panel();
            this.simpleButtonSelAll = new SimpleButton();
            this.panel4 = new Panel();
            this.simpleButton2 = new SimpleButton();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel2 = new Panel();
            this.labelprogress = new Label();
            this.xtraTabPage3 = new XtraTabPage();
            this.tList3 = new TreeList();
            this.treeListCol1 = new TreeListColumn();
            this.treeListCol2 = new TreeListColumn();
            this.treeListCol3 = new TreeListColumn();
            this.treeListCol4 = new TreeListColumn();
            this.repositoryItemImageEdit9 = new RepositoryItemImageEdit();
            this.panel8 = new Panel();
            this.labelprogress2 = new Label();
            this.simpleButtonZTOverlap = new SimpleButton();
            this.labelZTCount = new Label();
            this.simpleButtonRefresh = new SimpleButton();
            this.simpleButtonStop = new SimpleButton();
            this.simpleButtonInfo = new SimpleButton();
            this.labelinfo = new Label();
            this.toolTipController1 = new ToolTipController(this.components);
            this.labelIdentify = new Label();
            this.splitterControl1 = new SplitterControl();
            this.imageList9 = new ImageList(this.components);
            this.popupMenu1 = new PopupMenu(this.components);
            this.barButtonItemInput = new BarButtonItem();
            this.barButtonItemInput2 = new BarButtonItem();
            this.barButtonItemChange = new BarButtonItem();
            this.barButtonItemInput3 = new BarButtonItem();
            this.barButtonItemReadValue = new BarButtonItem();
            this.barButtonItemDelete = new BarButtonItem();
            this.barManager1 = new BarManager(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.panelInfo = new Panel();
            this.labelXBInfo = new Label();
            this.groupControlCheck = new GroupControl();
            this.panel11 = new Panel();
            this.simpleButtonCheckAll = new SimpleButton();
            this.panel14 = new Panel();
            this.simpleButtonCheck = new SimpleButton();
            this.panelLogChk = new Panel();
            this.panelControl3 = new PanelControl();
            this.richTextChk = new RichTextBox();
            this.panel16 = new Panel();
            this.labelChkprogress = new Label();
            this.tListKind2 = new TreeList();
            this.treeListColumn7 = new TreeListColumn();
            this.treeListColumn8 = new TreeListColumn();
            this.treeListColumn9 = new TreeListColumn();
            this.treeListColumn10 = new TreeListColumn();
            this.treeListColumn16 = new TreeListColumn();
            this.repositoryItemImageEdit10 = new RepositoryItemImageEdit();
            this.repositoryItemImageComboBox2 = new RepositoryItemImageComboBox();
            this.repositoryItemPictureEdit2 = new RepositoryItemPictureEdit();
            this.repositoryItemButtonEdit2 = new RepositoryItemButtonEdit();
            this.repositoryItemImageEdit11 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit12 = new RepositoryItemImageEdit();
            this.label2 = new Label();
            this.groupControlCombine = new GroupControl();
            this.label1 = new Label();
            this.simpleButtonClearLayer = new SimpleButton();
            this.panelClear = new Panel();
            this.label3 = new Label();
            this.imageCollection1.BeginInit();
            this.imageCollection2.BeginInit();
            this.panel6.SuspendLayout();
            this.repositoryItemImageEdit4.BeginInit();
            this.repositoryItemImageEdit5.BeginInit();
            this.tListKind.BeginInit();
            this.repositoryItemImageEdit2.BeginInit();
            this.repositoryItemImageComboBox1.BeginInit();
            this.repositoryItemPictureEdit1.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemImageEdit3.BeginInit();
            this.repositoryItemImageEdit33.BeginInit();
            this.imageCollection3.BeginInit();
            this.panelIDList.SuspendLayout();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageEdit6.BeginInit();
            this.repositoryItemImageEdit7.BeginInit();
            this.panelLog2.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.panelList.SuspendLayout();
            ((ISupportInitialize) this.listBoxDateEque).BeginInit();
            this.panel13.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.tList2.BeginInit();
            this.repositoryItemImageEdit8.BeginInit();
            this.panel3.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.tList3.BeginInit();
            this.repositoryItemImageEdit9.BeginInit();
            this.panel8.SuspendLayout();
            this.popupMenu1.BeginInit();
            this.barManager1.BeginInit();
            this.panelInfo.SuspendLayout();
            this.groupControlCheck.BeginInit();
            this.groupControlCheck.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panelLogChk.SuspendLayout();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tListKind2.BeginInit();
            this.repositoryItemImageEdit10.BeginInit();
            this.repositoryItemImageComboBox2.BeginInit();
            this.repositoryItemPictureEdit2.BeginInit();
            this.repositoryItemButtonEdit2.BeginInit();
            this.repositoryItemImageEdit11.BeginInit();
            this.repositoryItemImageEdit12.BeginInit();
            this.groupControlCombine.BeginInit();
            this.groupControlCombine.SuspendLayout();
            this.panelClear.SuspendLayout();
            base.SuspendLayout();
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "(14,37).png");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "");
            this.ImageList1.Images.SetKeyName(0x10, "(30,24).png");
            this.ImageList1.Images.SetKeyName(0x11, "(00,02).png");
            this.ImageList1.Images.SetKeyName(0x12, "(00,17).png");
            this.ImageList1.Images.SetKeyName(0x13, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(0x15, "(01,25).png");
            this.ImageList1.Images.SetKeyName(0x16, "(05,32).png");
            this.ImageList1.Images.SetKeyName(0x17, "(06,32).png");
            this.ImageList1.Images.SetKeyName(0x18, "(07,32).png");
            this.ImageList1.Images.SetKeyName(0x19, "(08,32).png");
            this.ImageList1.Images.SetKeyName(0x1a, "(08,36).png");
            this.ImageList1.Images.SetKeyName(0x1b, "(09,36).png");
            this.ImageList1.Images.SetKeyName(0x1c, "(10,26).png");
            this.ImageList1.Images.SetKeyName(0x1d, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x1f, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x20, "(11,32).png");
            this.ImageList1.Images.SetKeyName(0x21, "(11,36).png");
            this.ImageList1.Images.SetKeyName(0x22, "(13,32).png");
            this.ImageList1.Images.SetKeyName(0x23, "(19,31).png");
            this.ImageList1.Images.SetKeyName(0x24, "(22,18).png");
            this.ImageList1.Images.SetKeyName(0x25, "(25,27).png");
            this.ImageList1.Images.SetKeyName(0x26, "(29,43).png");
            this.ImageList1.Images.SetKeyName(0x27, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(0x29, "10.png");
            this.ImageList1.Images.SetKeyName(0x2a, "11.png");
            this.ImageList1.Images.SetKeyName(0x2b, "16.png");
            this.ImageList1.Images.SetKeyName(0x2c, "17.png");
            this.ImageList1.Images.SetKeyName(0x2d, "18.png");
            this.ImageList1.Images.SetKeyName(0x2e, "19.png");
            this.ImageList1.Images.SetKeyName(0x2f, "20.png");
            this.ImageList1.Images.SetKeyName(0x30, "21.png");
            this.ImageList1.Images.SetKeyName(0x31, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(0x33, "31.png");
            this.ImageList1.Images.SetKeyName(0x34, "41.png");
            this.ImageList1.Images.SetKeyName(0x35, "add.png");
            this.ImageList1.Images.SetKeyName(0x36, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(0x37, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x38, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x3a, "cross.png");
            this.ImageList1.Images.SetKeyName(0x3b, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(0x42, "flag blue.png");
            this.ImageList1.Images.SetKeyName(0x43, "flag red.png");
            this.ImageList1.Images.SetKeyName(0x44, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(0x45, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x47, "(34,00).png");
            this.ImageList1.Images.SetKeyName(0x48, "(03,02).png");
            this.ImageList1.Images.SetKeyName(0x49, "(49,06).png");
            this.ImageList1.Images.SetKeyName(0x4a, "(09,13).png");
            this.ImageList1.Images.SetKeyName(0x4b, "(16,47).png");
            this.ImageList1.Images.SetKeyName(0x4c, "(13,47).png");
            this.ImageList1.Images.SetKeyName(0x4d, "(18,01).png");
            this.ImageList1.Images.SetKeyName(0x4e, "(18,13).png");
            this.ImageList1.Images.SetKeyName(0x4f, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(0x51, "(39,47).png");
            this.ImageList1.Images.SetKeyName(0x52, "(45,12).png");
            this.ImageList1.Images.SetKeyName(0x53, "(45,17).png");
            this.ImageList1.Images.SetKeyName(0x54, "(45,41).png");
            this.ImageList1.Images.SetKeyName(0x55, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(0x56, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x57, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x58, "(12,11).png");
            this.ImageList1.Images.SetKeyName(0x59, "(24,28).png");
            this.ImageList1.Images.SetKeyName(90, "");
            this.ImageList1.Images.SetKeyName(0x5b, "home_16.png");
            this.ImageList1.Images.SetKeyName(0x5c, "(00,41).png");
            this.imageList5.ImageStream = (ImageListStreamer) resources.GetObject("imageList5.ImageStream");
            this.imageList5.TransparentColor = Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "170503292.gif");
            this.imageCollection1.ImageSize = new Size(0x20, 0x20);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "document-open.png");
            this.imageCollection1.Images.SetKeyName(1, "lincity-ng.png");
            this.imageCollection1.Images.SetKeyName(2, "kde-folder-txt.png");
            this.imageCollection1.Images.SetKeyName(3, "old-go-home.png");
            this.imageCollection1.Images.SetKeyName(4, "go-home.png");
            this.imageCollection1.Images.SetKeyName(5, "stock_task-recurring.png");
            this.imageCollection1.Images.SetKeyName(6, "old-openofficeorg-math.png");
            this.imageCollection1.Images.SetKeyName(7, "okteta.png");
            this.imageCollection1.Images.SetKeyName(8, "gconfeditor.png");
            this.imageCollection1.Images.SetKeyName(9, "gddccontrol.png");
            this.imageCollection1.Images.SetKeyName(10, "gnome-klotski.png");
            this.imageCollection1.Images.SetKeyName(11, "layer.png");
            this.imageCollection1.Images.SetKeyName(12, "chart_bullseye.png");
            this.imageCollection1.Images.SetKeyName(13, "draw_polyline.png");
            this.imageCollection1.Images.SetKeyName(14, "large_tiles.png");
            this.imageCollection1.Images.SetKeyName(15, "layers2.png");
            this.imageCollection1.Images.SetKeyName(0x10, "small_tiles.png");
            this.imageCollection1.Images.SetKeyName(0x11, "layers.png");
            this.imageCollection1.Images.SetKeyName(0x12, "application_view_tile.png");
            this.imageCollection1.Images.SetKeyName(0x13, "chart_stock.png");
            this.imageCollection1.Images.SetKeyName(20, "preferences-desktop-theme.png");
            this.imageCollection1.Images.SetKeyName(0x15, "grass.png");
            this.imageCollection1.Images.SetKeyName(0x16, "house_one.png");
            this.imageCollection1.Images.SetKeyName(0x17, "plotchart.png");
            this.imageCollection1.Images.SetKeyName(0x18, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(0x19, "illustration.png");
            this.imageCollection1.Images.SetKeyName(0x1a, "google_map.png");
            this.imageCollection1.Images.SetKeyName(0x1b, "color_swatches.png");
            this.imageCollection1.Images.SetKeyName(0x1c, "openofficeorg-draw.png");
            this.imageCollection1.Images.SetKeyName(0x1d, "green_wormhole.png");
            this.imageCollection1.Images.SetKeyName(30, "applix.png");
            this.imageCollection1.Images.SetKeyName(0x1f, "abiword.png");
            this.imageCollection1.Images.SetKeyName(0x20, "Text-Document.png");
            this.imageCollection1.Images.SetKeyName(0x21, "Xcode.png");
            this.imageCollection1.Images.SetKeyName(0x22, "Application.png");
            this.imageCollection1.Images.SetKeyName(0x23, "leaves.png");
            this.imageCollection1.Images.SetKeyName(0x24, "folder_edit.png");
            this.imageCollection1.Images.SetKeyName(0x25, "color_swatch.png");
            this.imageCollection1.Images.SetKeyName(0x26, "house.png");
            this.imageCollection1.Images.SetKeyName(0x27, "images.png");
            this.imageCollection1.Images.SetKeyName(40, "tree2.png");
            this.imageCollection1.Images.SetKeyName(0x29, "tree_1.png");
            this.imageCollection1.Images.SetKeyName(0x2a, "img-portrait-edit.png");
            this.imageCollection1.Images.SetKeyName(0x2b, "tree.png");
            this.imageCollection1.Images.SetKeyName(0x2c, "20071126112025469.png");
            this.imageCollection1.Images.SetKeyName(0x2d, "mb5u3_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(0x2e, "mb5u6_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(0x2f, "20071127000637768.png");
            this.imageCollection1.Images.SetKeyName(0x30, "sc0905281_3.png");
            this.imageCollection1.Images.SetKeyName(0x31, "sc0905281_4.png");
            this.imageCollection1.Images.SetKeyName(50, "20071127000640731.png");
            this.imageCollection1.Images.SetKeyName(0x33, "20071127112435759.png");
            this.imageCollection1.Images.SetKeyName(0x34, "20071206144123734.png");
            this.imageCollection1.Images.SetKeyName(0x35, "icontexto-green-01.png");
            this.imageCollection1.Images.SetKeyName(0x36, "fire.png");
            this.imageCollection1.Images.SetKeyName(0x37, "house.png");
            this.imageCollection1.Images.SetKeyName(0x38, "images.png");
            this.imageCollection1.Images.SetKeyName(0x39, "layers.png");
            this.imageCollection1.Images.SetKeyName(0x3a, "layers_map.png");
            this.imageCollection1.Images.SetKeyName(0x3b, "Plant.png");
            this.imageCollection1.Images.SetKeyName(60, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(0x3d, "sun_rain.png");
            this.imageCollection1.Images.SetKeyName(0x3e, "tree.png");
            this.imageCollection1.Images.SetKeyName(0x3f, "weather_rain.png");
            this.imageCollection1.Images.SetKeyName(0x40, "weather_snow.png");
            this.imageCollection1.Images.SetKeyName(0x41, "widgets.png");
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection2.ImageStream");
            this.imageCollection2.Images.SetKeyName(0, "1259760497_color_swatch_2.png");
            this.imageCollection2.Images.SetKeyName(1, "arrow_circle_double.png");
            this.imageCollection2.Images.SetKeyName(2, "edit_16x16.gif");
            this.imageCollection2.Images.SetKeyName(3, "map.png");
            this.imageCollection2.Images.SetKeyName(4, "map_add2.png");
            this.imageCollection2.Images.SetKeyName(5, "map_delete.png");
            this.imageCollection2.Images.SetKeyName(6, "map_edit2.png");
            this.imageCollection2.Images.SetKeyName(7, "map_go.png");
            this.imageCollection2.Images.SetKeyName(8, "map_magnify2.png");
            this.imageCollection2.Images.SetKeyName(9, "map2.png");
            this.imageCollection2.Images.SetKeyName(10, "map4.png");
            this.imageCollection2.Images.SetKeyName(11, "map--arrow.png");
            this.imageCollection2.Images.SetKeyName(12, "map--minus.png");
            this.imageCollection2.Images.SetKeyName(13, "map--pencil.png");
            this.imageCollection2.Images.SetKeyName(14, "map-pin.png");
            this.imageCollection2.Images.SetKeyName(15, "map--plus.png");
            this.imageCollection2.Images.SetKeyName(0x10, "maps.png");
            this.imageCollection2.Images.SetKeyName(0x11, "maps--arrow.png");
            this.imageCollection2.Images.SetKeyName(0x12, "maps--exclamation.png");
            this.imageCollection2.Images.SetKeyName(0x13, "maps--minus.png");
            this.imageCollection2.Images.SetKeyName(20, "maps--pencil.png");
            this.imageCollection2.Images.SetKeyName(0x15, "maps--pencil2.png");
            this.imageCollection2.Images.SetKeyName(0x16, "maps--pencil3.png");
            this.imageCollection2.Images.SetKeyName(0x17, "maps--plus.png");
            this.imageCollection2.Images.SetKeyName(0x18, "maps-stack.png");
            this.imageCollection2.Images.SetKeyName(0x19, "pathing3.png");
            this.imageCollection2.Images.SetKeyName(0x1a, "picture_pencil.png");
            this.imageCollection2.Images.SetKeyName(0x1b, "table__arrow.png");
            this.imageCollection2.Images.SetKeyName(0x1c, "arrow_large_up.png");
            this.imageCollection2.Images.SetKeyName(0x1d, "web design_16_hot.png");
            this.imageCollection2.Images.SetKeyName(30, "ksirtet16.png");
            this.imageCollection2.Images.SetKeyName(0x1f, "node-select-child.png");
            this.imageCollection2.Images.SetKeyName(0x20, "flag blue.png");
            this.imageCollection2.Images.SetKeyName(0x21, "flag red.png");
            this.imageCollection2.Images.SetKeyName(0x22, "flag yellow.png");
            this.imageCollection2.Images.SetKeyName(0x23, "image.png");
            this.imageCollection2.Images.SetKeyName(0x24, "image_edit.png");
            this.imageCollection2.Images.SetKeyName(0x25, "image_magnify.png");
            this.imageCollection2.Images.SetKeyName(0x26, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(0x27, "page_paintbrush.png");
            this.imageCollection2.Images.SetKeyName(40, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(0x29, "pencil.png");
            this.imageCollection2.Images.SetKeyName(0x2a, "photo.png");
            this.imageCollection2.Images.SetKeyName(0x2b, "photos.png");
            this.imageCollection2.Images.SetKeyName(0x2c, "picture.png");
            this.imageCollection2.Images.SetKeyName(0x2d, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(0x2e, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(0x2f, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(0x30, "search.gif");
            this.imageCollection2.Images.SetKeyName(0x31, "table.png");
            this.imageCollection2.Images.SetKeyName(50, "table_edit.png");
            this.imageCollection2.Images.SetKeyName(0x33, "(01,40).png");
            this.imageCollection2.Images.SetKeyName(0x34, "(01,46).png");
            this.imageCollection2.Images.SetKeyName(0x35, "(09,46).png");
            this.imageCollection2.Images.SetKeyName(0x36, "(12,11).png");
            this.imageCollection2.Images.SetKeyName(0x37, "(14,36).png");
            this.imageCollection2.Images.SetKeyName(0x38, "(14,37).png");
            this.imageCollection2.Images.SetKeyName(0x39, "(15,25).png");
            this.imageCollection2.Images.SetKeyName(0x3a, "(15,40).png");
            this.imageCollection2.Images.SetKeyName(0x3b, "(16,32).png");
            this.imageCollection2.Images.SetKeyName(60, "(17,49).png");
            this.imageCollection2.Images.SetKeyName(0x3d, "(19,01).png");
            this.imageCollection2.Images.SetKeyName(0x3e, "(24,04).png");
            this.imageCollection2.Images.SetKeyName(0x3f, "(24,32).png");
            this.imageCollection2.Images.SetKeyName(0x40, "(28,09).png");
            this.imageCollection2.Images.SetKeyName(0x41, "(29,04).png");
            this.imageCollection2.Images.SetKeyName(0x42, "(30,24).png");
            this.imageCollection2.Images.SetKeyName(0x43, "(32,04).png");
            this.imageCollection2.Images.SetKeyName(0x44, "(32,24).png");
            this.imageCollection2.Images.SetKeyName(0x45, "(33,14).png");
            this.imageCollection2.Images.SetKeyName(70, "(35,29).png");
            this.imageCollection2.Images.SetKeyName(0x47, "(35,31).png");
            this.imageCollection2.Images.SetKeyName(0x48, "(35,45).png");
            this.imageCollection2.Images.SetKeyName(0x49, "(36,04).png");
            this.imageCollection2.Images.SetKeyName(0x4a, "(36,47).png");
            this.imageCollection2.Images.SetKeyName(0x4b, "(39,47).png");
            this.imageCollection2.Images.SetKeyName(0x4c, "(40,05).png");
            this.imageCollection2.Images.SetKeyName(0x4d, "(44,27).png");
            this.imageCollection2.Images.SetKeyName(0x4e, "(45,28).png");
            this.imageCollection2.Images.SetKeyName(0x4f, "(49,06).png");
            this.imageCollection2.Images.SetKeyName(80, "(49,48).png");
            this.imageCollection2.Images.SetKeyName(0x51, "(15,49).png");
            this.imageCollection2.Images.SetKeyName(0x52, "(27,15).png");
            this.imageCollection2.Images.SetKeyName(0x53, "(00,41).png");
            this.imageCollection2.Images.SetKeyName(0x54, "(00,47).png");
            this.imageCollection2.Images.SetKeyName(0x55, "(02,10).png");
            this.imageCollection2.Images.SetKeyName(0x56, "(02,40).png");
            this.imageCollection2.Images.SetKeyName(0x57, "(03,18).png");
            this.imageCollection2.Images.SetKeyName(0x58, "(06,02).png");
            this.imageCollection2.Images.SetKeyName(0x59, "(08,40).png");
            this.imageCollection2.Images.SetKeyName(90, "(10,41).png");
            this.imageCollection2.Images.SetKeyName(0x5b, "(11,49).png");
            this.imageCollection2.Images.SetKeyName(0x5c, "(13,15).png");
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonFinish);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.simpleButtonOK);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 0x81);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 4, 0, 4);
//            this.panel6.RightToLeft = RightToLeft.Yes;
            this.panel6.Size = new Size(0x11c, 0x20);
            this.panel6.TabIndex = 0x16;
            this.simpleButtonFinish.Dock = DockStyle.Right;
            this.simpleButtonFinish.ImageIndex = 0x53;
            this.simpleButtonFinish.ImageList = this.ImageList1;
            this.simpleButtonFinish.Location = new System.Drawing.Point(0x5c, 4);
            this.simpleButtonFinish.Name = "simpleButtonFinish";
            this.simpleButtonFinish.Size = new Size(60, 0x18);
            this.simpleButtonFinish.TabIndex = 12;
            this.simpleButtonFinish.Text = "完成";
            this.simpleButtonFinish.ToolTip = "完成编辑";
            this.simpleButtonFinish.Visible = false;
            this.simpleButtonFinish.Click += new EventHandler(this.simpleButtonFinish_Click);
            this.panel7.Dock = DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(0x98, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(6, 0x18);
            this.panel7.TabIndex = 13;
            this.simpleButtonOK.Dock = DockStyle.Right;
            this.simpleButtonOK.ImageIndex = 90;
            this.simpleButtonOK.ImageList = this.imageCollection2;
            this.simpleButtonOK.Location = new System.Drawing.Point(0x9e, 4);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(60, 0x18);
            this.simpleButtonOK.TabIndex = 10;
            this.simpleButtonOK.Text = "编辑";
            this.simpleButtonOK.ToolTip = "开始编辑";
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(0xda, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(6, 0x18);
            this.panel1.TabIndex = 11;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.Enabled = false;
            this.simpleButtonCancel.ImageIndex = 0x58;
            this.simpleButtonCancel.ImageList = this.imageCollection2;
            this.simpleButtonCancel.Location = new System.Drawing.Point(0xe0, 4);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(60, 0x18);
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "停止";
            this.simpleButtonCancel.ToolTip = "停止编辑";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "layers_map.png");
            this.imageList2.Images.SetKeyName(1, "(28,08).png");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "(01,49).png");
            this.imageList2.Images.SetKeyName(4, "(18,13).png");
            this.imageList2.Images.SetKeyName(5, "(01,46).png");
            this.imageList2.Images.SetKeyName(6, "(05,49).png");
            this.imageList2.Images.SetKeyName(7, "(06,30).png");
            this.imageList2.Images.SetKeyName(8, "(07,30).png");
            this.imageList2.Images.SetKeyName(9, "(09,13).png");
            this.imageList2.Images.SetKeyName(10, "(09,24).png");
            this.imageList2.Images.SetKeyName(11, "(11,49).png");
            this.imageList2.Images.SetKeyName(12, "(18,29).png");
            this.imageList2.Images.SetKeyName(13, "(34,00).png");
            this.imageList2.Images.SetKeyName(14, "(47,25).png");
            this.imageList2.Images.SetKeyName(15, "(48,48).png");
            this.imageList3.ImageStream = (ImageListStreamer) resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "(04,42).png");
            this.imageList3.Images.SetKeyName(1, "(03,42).png");
            this.imageList3.Images.SetKeyName(2, "(01,46).png");
            this.imageList3.Images.SetKeyName(3, "(01,49).png");
            this.imageList3.Images.SetKeyName(4, "(02,27).png");
            this.imageList3.Images.SetKeyName(5, "(03,42).png");
            this.imageList4.ImageStream = (ImageListStreamer) resources.GetObject("imageList4.ImageStream");
            this.imageList4.TransparentColor = Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "001_45.gif");
            this.imageList4.Images.SetKeyName(1, "001_38.gif");
            this.imageList4.Images.SetKeyName(2, "blue_view_24x24.gif");
            this.imageList4.Images.SetKeyName(3, "gtk-edit.png");
            this.imageList4.Images.SetKeyName(4, "ico6.gif");
            this.imageList6.ImageStream = (ImageListStreamer) resources.GetObject("imageList6.ImageStream");
            this.imageList6.TransparentColor = Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "(03,42).png");
            this.imageList6.Images.SetKeyName(1, "(04,42).png");
            this.imageList6.Images.SetKeyName(2, "(01,46).png");
            this.imageList6.Images.SetKeyName(3, "(01,49).png");
            this.imageList6.Images.SetKeyName(4, "(02,27).png");
            this.imageList6.Images.SetKeyName(5, "(03,42).png");
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
            this.repositoryItemImageEdit4.AutoHeight = false;
            this.repositoryItemImageEdit4.Name = "repositoryItemImageEdit4";
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
            this.repositoryItemImageEdit5.AutoHeight = false;
            this.repositoryItemImageEdit5.Name = "repositoryItemImageEdit5";
            this.tListKind.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tListKind.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tListKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListKind.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tListKind.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tListKind.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tListKind.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListKind.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListKind.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tListKind.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tListKind.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tListKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListKind.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5, this.treeListColumn6 });
            this.tListKind.Dock = DockStyle.Top;
            this.tListKind.Location = new System.Drawing.Point(4, 0x2d);
            this.tListKind.Name = "tListKind";
            this.tListKind.BeginUnboundLoad();
            object[] nodeData = new object[6];
            nodeData[0] = "造林";
            nodeData[1] = "编辑";
            this.tListKind.AppendNode(nodeData, -1, 0, 0, 0x24);
            object[] nodeData1 = new object[6];
            nodeData1[0] = "采伐";
            nodeData1[1] = "";
            this.tListKind.AppendNode(nodeData1, -1, -1, -1, 0x25);
            object[] nodeData2 = new object[6];
            nodeData2[0] = "森林火灾";
            nodeData2[1] = "完成";
            this.tListKind.AppendNode(nodeData2, -1, -1, -1, 0x2b);
            object[]  nodeData11 = new object[6];
            nodeData11[0] = "林地征占用";
            this.tListKind.AppendNode(nodeData11, -1, -1, -1, 0x2a);
            object[] nodeData3 = new object[6];
            nodeData3[0] = "自然灾害";
            this.tListKind.AppendNode(nodeData3, -1, -1, -1, 0x2d);
            object[] nodeData4 = new object[6];
            nodeData4[0] = "林业案件";
            this.tListKind.AppendNode(nodeData4, -1, -1, -1, 0x12);
            object[] nodeData5 = new object[6];
            nodeData5[0] = "冲突专题数据";
            nodeData5[2] = "";
            this.tListKind.AppendNode(nodeData5, -1, -1, -1, 0x20);
            this.tListKind.EndUnboundLoad();
            this.tListKind.OptionsBehavior.Editable = false;
            this.tListKind.OptionsView.AutoWidth = false;
            this.tListKind.OptionsView.ShowColumns = false;
            this.tListKind.OptionsView.ShowHorzLines = false;
            this.tListKind.OptionsView.ShowIndicator = false;
            this.tListKind.OptionsView.ShowRoot = false;
            this.tListKind.OptionsView.ShowVertLines = false;
            this.tListKind.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit2, this.repositoryItemImageComboBox1, this.repositoryItemPictureEdit1, this.repositoryItemButtonEdit1, this.repositoryItemImageEdit3, this.repositoryItemImageEdit33 });
            this.tListKind.RowHeight = 0x1a;
            this.tListKind.SelectImageList = this.imageList8;
            this.tListKind.Size = new Size(0x11c, 0x54);
            this.tListKind.StateImageList = this.imageCollection3;
            this.tListKind.TabIndex = 0x17;
            this.tListKind.TreeLevelWidth = 12;
            this.tListKind.TreeLineStyle = LineStyle.None;
            this.tListKind.MouseUp += new MouseEventHandler(this.tListKind_MouseUp);
            this.tListKind.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tListKind_CustomNodeCellEdit);
            this.tListKind.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tListKind_FocusedNodeChanged);
            this.tListKind.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tListKind_FocusedColumnChanged);
            this.tListKind.ColumnChanged += new ColumnChangedEventHandler(this.tListKind_ColumnChanged);
            this.tListKind.MouseDoubleClick += new MouseEventHandler(this.tListKind_MouseDoubleClick);
            this.treeListColumn1.Caption = "专题";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 0x5c;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 110;
            this.treeListColumn2.Caption = "状态";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.MinWidth = 0x10;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 0x25;
            this.treeListColumn3.Caption = "可见";
            this.treeListColumn3.FieldName = "treeListColumn3";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 0x22;
            this.treeListColumn4.Caption = "定位";
            this.treeListColumn4.FieldName = "treeListColumn4";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 0x24;
            this.treeListColumn5.Caption = "信息";
            this.treeListColumn5.FieldName = "treeListColumn5";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 0x22;
            this.treeListColumn6.Caption = "treeListColumn6";
            this.treeListColumn6.FieldName = "treeListColumn6";
            this.treeListColumn6.Name = "treeListColumn6";
            this.repositoryItemImageEdit2.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit2.Appearance.Image");
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = ShowDropDown.Never;
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
            this.imageList8.ImageStream = (ImageListStreamer) resources.GetObject("imageList8.ImageStream");
            this.imageList8.TransparentColor = Color.Transparent;
            this.imageList8.Images.SetKeyName(0, "drawing_pen-24.png");
            this.imageList8.Images.SetKeyName(1, "misc_53.png");
            this.imageList8.Images.SetKeyName(2, "001_45.gif");
            this.imageList8.Images.SetKeyName(3, "icn_best.gif");
            this.imageList8.Images.SetKeyName(4, "001_38.gif");
            this.imageList8.Images.SetKeyName(5, "edit3.png");
            this.imageCollection3.ImageSize = new Size(0x18, 0x18);
            this.imageCollection3.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection3.ImageStream");
            this.imageCollection3.Images.SetKeyName(0, "001_45.gif");
            this.imageCollection3.Images.SetKeyName(1, "large_tiles.png");
            this.imageCollection3.Images.SetKeyName(2, "layers2.png");
            this.imageCollection3.Images.SetKeyName(3, "31.png");
            this.imageCollection3.Images.SetKeyName(4, "small_tiles.png");
            this.imageCollection3.Images.SetKeyName(5, "color-layers.png");
            this.imageCollection3.Images.SetKeyName(6, "Sync.png");
            this.imageCollection3.Images.SetKeyName(7, "fire5.png");
            this.imageCollection3.Images.SetKeyName(8, "widgets.png");
            this.imageCollection3.Images.SetKeyName(9, "gkdebconf-icon.png");
            this.imageCollection3.Images.SetKeyName(10, "openofficeorg-draw.png");
            this.imageCollection3.Images.SetKeyName(11, "fire3.png");
            this.imageCollection3.Images.SetKeyName(12, "green_wormhole.png");
            this.imageCollection3.Images.SetKeyName(13, "globe_download2.png");
            this.imageCollection3.Images.SetKeyName(14, "globe_process2.png");
            this.imageCollection3.Images.SetKeyName(15, "hot.png");
            this.imageCollection3.Images.SetKeyName(0x10, "kde-folder-development.png");
            this.imageCollection3.Images.SetKeyName(0x11, "image-svg.png");
            this.imageCollection3.Images.SetKeyName(0x12, "document-open.png");
            this.imageCollection3.Images.SetKeyName(0x13, "image-svg+xml.png");
            this.imageCollection3.Images.SetKeyName(20, "application-x-tgif.png");
            this.imageCollection3.Images.SetKeyName(0x15, "gnome-mime-application-vnd_oasis_opendocument_graphics-template.png");
            this.imageCollection3.Images.SetKeyName(0x16, "x-kde-nsplugin-generated.png");
            this.imageCollection3.Images.SetKeyName(0x17, "kde-folder-image.png");
            this.imageCollection3.Images.SetKeyName(0x18, "applications-accessories.png");
            this.imageCollection3.Images.SetKeyName(0x19, "application-x-krita.png");
            this.imageCollection3.Images.SetKeyName(0x1a, "preferences-certificates.png");
            this.imageCollection3.Images.SetKeyName(0x1b, "applications-utilities.png");
            this.imageCollection3.Images.SetKeyName(0x1c, "insert-image.png");
            this.imageCollection3.Images.SetKeyName(0x1d, "tomboy.png");
            this.imageCollection3.Images.SetKeyName(30, "Burn.png");
            this.imageCollection3.Images.SetKeyName(0x1f, "gtk-execute.png");
            this.imageCollection3.Images.SetKeyName(0x20, "images24.png");
            this.imageCollection3.Images.SetKeyName(0x21, "Application.png");
            this.imageCollection3.Images.SetKeyName(0x22, "ksirtet24.png");
            this.imageCollection3.Images.SetKeyName(0x23, "Notes.png");
            this.imageCollection3.Images.SetKeyName(0x24, "icontexto-green-01.png");
            this.imageCollection3.Images.SetKeyName(0x25, "tree_1.png");
            this.imageCollection3.Images.SetKeyName(0x26, "img-portrait-edit.png");
            this.imageCollection3.Images.SetKeyName(0x27, "20071126112025469.png");
            this.imageCollection3.Images.SetKeyName(40, "mb5u3_mb5ucom.png");
            this.imageCollection3.Images.SetKeyName(0x29, "sc0905281_3.png");
            this.imageCollection3.Images.SetKeyName(0x2a, "20071206144123734.png");
            this.imageCollection3.Images.SetKeyName(0x2b, "fire.png");
            this.imageCollection3.Images.SetKeyName(0x2c, "rain.png");
            this.imageCollection3.Images.SetKeyName(0x2d, "snow_rain.png");
            this.imageCollection3.Images.SetKeyName(0x2e, "sun_rain.png");
            this.imageCollection3.Images.SetKeyName(0x2f, "weather_snow.png");
            this.panelIDList.Controls.Add(this.xtraTabControl1);
            this.panelIDList.Controls.Add(this.labelZTCount);
            this.panelIDList.Controls.Add(this.simpleButtonRefresh);
            this.panelIDList.Controls.Add(this.simpleButtonStop);
            this.panelIDList.Controls.Add(this.simpleButtonInfo);
            this.panelIDList.Controls.Add(this.labelinfo);
            this.panelIDList.Dock = DockStyle.Fill;
            this.panelIDList.Location = new System.Drawing.Point(4, 0xa1);
            this.panelIDList.Name = "panelIDList";
            this.panelIDList.Padding = new Padding(0, 4, 0, 2);
            this.panelIDList.Size = new Size(0x11c, 280);
            this.panelIDList.TabIndex = 0x18;
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0x16);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Padding = new Padding(4);
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0x11c, 0xee);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3 });
            this.xtraTabControl1.TabIndexChanged += new EventHandler(this.xtraTabControl1_TabIndexChanged);
            this.xtraTabPage1.Controls.Add(this.panel9);
            this.xtraTabPage1.Controls.Add(this.tList);
            this.xtraTabPage1.Controls.Add(this.panelLog2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new Padding(4);
            this.xtraTabPage1.Size = new Size(0x117, 0xd3);
            item.Text = "与造林专题相交班块";
            tip.Items.Add(item);
            this.xtraTabPage1.SuperTip = tip;
            this.xtraTabPage1.Text = "相交";
            this.panel9.BackColor = Color.Transparent;
            this.panel9.Controls.Add(this.simpleButtonBack2);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.simpleButtonAuto);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.simpleButton3);
            this.panel9.Dock = DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(4, 0xb3);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new Padding(0, 4, 0, 0);
            this.panel9.Size = new Size(0x10f, 0x1c);
            this.panel9.TabIndex = 0x18;
            this.simpleButtonBack2.Dock = DockStyle.Right;
            this.simpleButtonBack2.ImageIndex = 0x2f;
            this.simpleButtonBack2.ImageList = this.ImageList1;
            this.simpleButtonBack2.Location = new System.Drawing.Point(0x41, 4);
            this.simpleButtonBack2.Name = "simpleButtonBack2";
            this.simpleButtonBack2.Size = new Size(60, 0x18);
            this.simpleButtonBack2.TabIndex = 0x10;
            this.simpleButtonBack2.Text = "返回";
            this.simpleButtonBack2.ToolTip = "返回再导入数据";
            this.simpleButtonBack2.Visible = false;
            this.simpleButtonBack2.Click += new EventHandler(this.simpleButtonBack2_Click);
            this.panel12.Dock = DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(0x7d, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new Size(6, 0x18);
            this.panel12.TabIndex = 15;
            this.simpleButtonAuto.Dock = DockStyle.Right;
            this.simpleButtonAuto.ImageIndex = 6;
            this.simpleButtonAuto.ImageList = this.ImageList1;
            this.simpleButtonAuto.Location = new System.Drawing.Point(0x83, 4);
            this.simpleButtonAuto.Name = "simpleButtonAuto";
            this.simpleButtonAuto.Size = new Size(0x4a, 0x18);
            this.simpleButtonAuto.TabIndex = 14;
            this.simpleButtonAuto.Text = "自动处理";
            this.simpleButtonAuto.ToolTip = "自动批量处理相交班块";
            this.simpleButtonAuto.Click += new EventHandler(this.simpleButtonAuto_Click);
            this.panel10.Dock = DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(0xcd, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(6, 0x18);
            this.panel10.TabIndex = 13;
            this.panel10.Visible = false;
            this.simpleButton3.Dock = DockStyle.Right;
            this.simpleButton3.ImageIndex = 11;
            this.simpleButton3.ImageList = this.imageCollection2;
            this.simpleButton3.Location = new System.Drawing.Point(0xd3, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(60, 0x18);
            this.simpleButton3.TabIndex = 12;
            this.simpleButton3.Text = "导入";
            this.simpleButton3.Visible = false;
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
            this.tList.Columns.AddRange(new TreeListColumn[] { this.tListCol1, this.tListCol2, this.tListCol3, this.tListCol4, this.tListCol5, this.tListCol6, this.tListCol7 });
            this.tList.Dock = DockStyle.Fill;
            this.tList.Location = new System.Drawing.Point(4, 4);
            this.tList.Name = "tList";
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageEdit6, this.repositoryItemImageEdit7 });
            this.tList.Size = new Size(0x10f, 0xcb);
            this.tList.TabIndex = 6;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.MouseUp += new MouseEventHandler(this.tList_MouseUp);
            this.tList.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList_CustomNodeCellEdit);
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.tListCol1.Caption = "编号";
            this.tListCol1.FieldName = "ID";
            this.tListCol1.Name = "tListCol1";
            this.tListCol1.Visible = true;
            this.tListCol1.VisibleIndex = 0;
            this.tListCol1.Width = 0x24;
            this.tListCol2.Caption = "定位";
            this.tListCol2.FieldName = "定位";
            this.tListCol2.Name = "tListCol2";
            this.tListCol2.Visible = true;
            this.tListCol2.VisibleIndex = 1;
            this.tListCol2.Width = 0x27;
            this.tListCol3.Caption = "信息";
            this.tListCol3.FieldName = "信息";
            this.tListCol3.Name = "tListCol3";
            this.tListCol3.Visible = true;
            this.tListCol3.VisibleIndex = 2;
            this.tListCol3.Width = 0x2c;
            this.tListCol4.Caption = "状态";
            this.tListCol4.FieldName = "状态";
            this.tListCol4.Name = "tListCol4";
            this.tListCol4.Visible = true;
            this.tListCol4.VisibleIndex = 3;
            this.tListCol4.Width = 0x44;
            this.tListCol5.Caption = "专题小班";
            this.tListCol5.FieldName = "专题小班";
            this.tListCol5.Name = "tListCol5";
            this.tListCol5.Visible = true;
            this.tListCol5.VisibleIndex = 4;
            this.tListCol5.Width = 60;
            this.tListCol6.Caption = "相交比率";
            this.tListCol6.FieldName = "相交比率";
            this.tListCol6.Name = "tListCol6";
            this.tListCol6.Visible = true;
            this.tListCol6.VisibleIndex = 5;
            this.tListCol7.Caption = "遥感编号";
            this.tListCol7.FieldName = "遥感小班";
            this.tListCol7.Name = "tListCol7";
            this.tListCol7.Visible = true;
            this.tListCol7.VisibleIndex = 6;
            this.tListCol7.Width = 0x3e;
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit6.AutoHeight = false;
            this.repositoryItemImageEdit6.Name = "repositoryItemImageEdit6";
            this.repositoryItemImageEdit6.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit7.AutoHeight = false;
            this.repositoryItemImageEdit7.Name = "repositoryItemImageEdit7";
            this.panelLog2.BackColor = Color.Transparent;
            this.panelLog2.Controls.Add(this.panelControl2);
            this.panelLog2.Controls.Add(this.panelList);
            this.panelLog2.Controls.Add(this.panel13);
            this.panelLog2.Dock = DockStyle.Fill;
            this.panelLog2.Location = new System.Drawing.Point(4, 4);
            this.panelLog2.Name = "panelLog2";
            this.panelLog2.Padding = new Padding(0, 6, 0, 0);
            this.panelLog2.Size = new Size(0x10f, 0xcb);
            this.panelLog2.TabIndex = 0x1f;
            this.panelLog2.Visible = false;
            this.panelControl2.Controls.Add(this.richTextBoxj);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0x20);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x10f, 0x71);
            this.panelControl2.TabIndex = 0x10;
//            this.richTextBoxj.BorderStyle = BorderStyle.None;
            this.richTextBoxj.Dock = DockStyle.Fill;
            this.richTextBoxj.Location = new System.Drawing.Point(2, 2);
            this.richTextBoxj.Name = "richTextBoxj";
            this.richTextBoxj.Size = new Size(0x10b, 0x6d);
            this.richTextBoxj.TabIndex = 0;
            this.richTextBoxj.Text = "";
            this.panelList.Controls.Add(this.listBoxDateEque);
            this.panelList.Controls.Add(this.label4);
            this.panelList.Dock = DockStyle.Bottom;
            this.panelList.Location = new System.Drawing.Point(0, 0x91);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new Padding(0, 0, 0, 4);
            this.panelList.Size = new Size(0x10f, 0x3a);
            this.panelList.TabIndex = 1;
            this.panelList.Visible = false;
            this.listBoxDateEque.Dock = DockStyle.Fill;
            this.listBoxDateEque.Location = new System.Drawing.Point(0, 0x16);
            this.listBoxDateEque.Name = "listBoxDateEque";
            this.listBoxDateEque.Size = new Size(0x10f, 0x20);
            this.listBoxDateEque.TabIndex = 0;
            this.listBoxDateEque.DoubleClick += new EventHandler(this.listBoxDateEque_DoubleClick);
            this.listBoxDateEque.MouseDoubleClick += new MouseEventHandler(this.listBoxDateEque_MouseDoubleClick);
            this.listBoxDateEque.MouseUp += new MouseEventHandler(this.listBoxDateEque_MouseUp);
            this.label4.BackColor = Color.Transparent;
            this.label4.Dock = DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x10f, 0x16);
            this.label4.TabIndex = 9;
            this.label4.Text = "与专题相交且变更时间相同的班块:";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.panel13.Controls.Add(this.labelProgressj);
            this.panel13.Dock = DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 6);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new Padding(0, 2, 0, 2);
            this.panel13.Size = new Size(0x10f, 0x1a);
            this.panel13.TabIndex = 15;
            this.labelProgressj.BackColor = Color.Transparent;
            this.labelProgressj.Dock = DockStyle.Fill;
            this.labelProgressj.Location = new System.Drawing.Point(0, 2);
            this.labelProgressj.Name = "labelProgressj";
            this.labelProgressj.Size = new Size(0x10f, 0x16);
            this.labelProgressj.TabIndex = 8;
            this.labelProgressj.Text = "生成进度:";
            this.xtraTabPage2.Controls.Add(this.tList2);
            this.xtraTabPage2.Controls.Add(this.panel3);
            this.xtraTabPage2.Controls.Add(this.panelLog);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new Padding(4);
            this.xtraTabPage2.Size = new Size(0x117, 0xd3);
            item2.Text = "造林专题独有班块";
            tip2.Items.Add(item2);
            this.xtraTabPage2.SuperTip = tip2;
            this.xtraTabPage2.Text = "独有";
            this.tList2.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList2.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList2.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList2.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList2.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList2.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList2.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList2.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList2.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList2.Columns.AddRange(new TreeListColumn[] { this.treeListColumn11, this.treeListColumn12, this.treeListColumn13, this.treeListColumn14, this.treeListColumn15 });
            this.tList2.Dock = DockStyle.Fill;
            this.tList2.Location = new System.Drawing.Point(4, 4);
            this.tList2.Name = "tList2";
            this.tList2.OptionsBehavior.Editable = false;
            this.tList2.OptionsView.AutoWidth = false;
            this.tList2.OptionsView.ShowCheckBoxes = true;
            this.tList2.OptionsView.ShowHorzLines = false;
            this.tList2.OptionsView.ShowIndicator = false;
            this.tList2.OptionsView.ShowRoot = false;
            this.tList2.OptionsView.ShowVertLines = false;
            this.tList2.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit8 });
            this.tList2.Size = new Size(0x10f, 0xaf);
            this.tList2.TabIndex = 7;
            this.tList2.TreeLevelWidth = 12;
            this.tList2.TreeLineStyle = LineStyle.None;
            this.tList2.MouseUp += new MouseEventHandler(this.tList2_MouseUp);
            this.tList2.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList2_CustomNodeCellEdit);
            this.tList2.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList2_FocusedNodeChanged);
            this.tList2.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList2_FocusedColumnChanged);
            this.treeListColumn11.Caption = "编号";
            this.treeListColumn11.FieldName = "ID";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            this.treeListColumn11.Width = 60;
            this.treeListColumn12.Caption = "县";
            this.treeListColumn12.FieldName = "县";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 0x2e;
            this.treeListColumn13.Caption = "乡";
            this.treeListColumn13.FieldName = "乡";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 2;
            this.treeListColumn13.Width = 0x2c;
            this.treeListColumn14.Caption = "村";
            this.treeListColumn14.FieldName = "村";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 3;
            this.treeListColumn14.Width = 0x2e;
            this.treeListColumn15.Caption = "定位";
            this.treeListColumn15.FieldName = "定位";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 4;
            this.treeListColumn15.Width = 0x2e;
            this.repositoryItemImageEdit8.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit8.Appearance.Image");
            this.repositoryItemImageEdit8.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit8.AutoHeight = false;
            this.repositoryItemImageEdit8.Name = "repositoryItemImageEdit8";
            this.repositoryItemImageEdit8.ShowDropDown = ShowDropDown.Never;
            this.panel3.BackColor = Color.Transparent;
            this.panel3.Controls.Add(this.simpleButtonBack);
            this.panel3.Controls.Add(this.simpleButtonInput);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.simpleButtonSelAll);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.simpleButton2);
            this.panel3.Dock = DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(4, 0xb3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 4, 0, 0);
            this.panel3.Size = new Size(0x10f, 0x1c);
            this.panel3.TabIndex = 0x17;
            this.simpleButtonBack.Dock = DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 0x2f;
            this.simpleButtonBack.ImageList = this.ImageList1;
            this.simpleButtonBack.Location = new System.Drawing.Point(0x13, 4);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new Size(60, 0x18);
            this.simpleButtonBack.TabIndex = 14;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new EventHandler(this.simpleButtonBack_Click);
            this.simpleButtonInput.Dock = DockStyle.Right;
            this.simpleButtonInput.ImageIndex = 11;
            this.simpleButtonInput.ImageList = this.imageCollection2;
            this.simpleButtonInput.Location = new System.Drawing.Point(0x4f, 4);
            this.simpleButtonInput.Name = "simpleButtonInput";
            this.simpleButtonInput.Size = new Size(60, 0x18);
            this.simpleButtonInput.TabIndex = 12;
            this.simpleButtonInput.Text = "导入";
            this.simpleButtonInput.Click += new EventHandler(this.simpleButtonInput_Click);
            this.panel5.Dock = DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(0x8b, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(6, 0x18);
            this.panel5.TabIndex = 13;
            this.simpleButtonSelAll.Dock = DockStyle.Right;
            this.simpleButtonSelAll.ImageIndex = 0x3a;
            this.simpleButtonSelAll.ImageList = this.imageCollection2;
            this.simpleButtonSelAll.Location = new System.Drawing.Point(0x91, 4);
            this.simpleButtonSelAll.Name = "simpleButtonSelAll";
            this.simpleButtonSelAll.Size = new Size(60, 0x18);
            this.simpleButtonSelAll.TabIndex = 10;
            this.simpleButtonSelAll.Text = "全选";
            this.simpleButtonSelAll.Click += new EventHandler(this.simpleButtonSelAll_Click);
            this.panel4.Dock = DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(0xcd, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(6, 0x18);
            this.panel4.TabIndex = 11;
            this.simpleButton2.Dock = DockStyle.Right;
            this.simpleButton2.ImageIndex = 1;
            this.simpleButton2.ImageList = this.imageList2;
            this.simpleButton2.Location = new System.Drawing.Point(0xd3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(60, 0x18);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "反选";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel2);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(4, 4);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0x10f, 0xcb);
            this.panelLog.TabIndex = 30;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0x20);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x10f, 0xab);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x10b, 0xa7);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel2.Controls.Add(this.labelprogress);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(0, 2, 0, 2);
            this.panel2.Size = new Size(0x10f, 0x1a);
            this.panel2.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0x10f, 0x16);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            this.xtraTabPage3.Controls.Add(this.tList3);
            this.xtraTabPage3.Controls.Add(this.panel8);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0x117, 0xcd);
            item3.Text = "专题间冲突班块";
            tip3.Items.Add(item3);
            this.xtraTabPage3.SuperTip = tip3;
            this.xtraTabPage3.Text = "冲突";
            this.tList3.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList3.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList3.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList3.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList3.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList3.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList3.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList3.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList3.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList3.Columns.AddRange(new TreeListColumn[] { this.treeListCol1, this.treeListCol2, this.treeListCol3, this.treeListCol4 });
            this.tList3.Dock = DockStyle.Fill;
            this.tList3.Location = new System.Drawing.Point(0, 0x26);
            this.tList3.Name = "tList3";
            this.tList3.OptionsBehavior.Editable = false;
            this.tList3.OptionsView.AutoWidth = false;
            this.tList3.OptionsView.ShowHorzLines = false;
            this.tList3.OptionsView.ShowIndicator = false;
            this.tList3.OptionsView.ShowRoot = false;
            this.tList3.OptionsView.ShowVertLines = false;
            this.tList3.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit9 });
            this.tList3.Size = new Size(0x117, 0xa7);
            this.tList3.TabIndex = 7;
            this.tList3.TreeLevelWidth = 12;
            this.tList3.TreeLineStyle = LineStyle.None;
            this.tList3.MouseUp += new MouseEventHandler(this.tList3_MouseUp);
            this.tList3.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList3_CustomNodeCellEdit);
            this.tList3.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList3_FocusedNodeChanged);
            this.tList3.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList3_FocusedColumnChanged);
            this.tList3.MouseDoubleClick += new MouseEventHandler(this.tList3_MouseDoubleClick);
            this.treeListCol1.Caption = "编号";
            this.treeListCol1.FieldName = "ID";
            this.treeListCol1.Name = "treeListCol1";
            this.treeListCol1.Visible = true;
            this.treeListCol1.VisibleIndex = 0;
            this.treeListCol1.Width = 0x24;
            this.treeListCol2.Caption = "定位";
            this.treeListCol2.FieldName = "定位";
            this.treeListCol2.Name = "treeListCol2";
            this.treeListCol2.Visible = true;
            this.treeListCol2.VisibleIndex = 1;
            this.treeListCol2.Width = 0x27;
            this.treeListCol3.Caption = "冲突专题";
            this.treeListCol3.FieldName = "treeListCol3";
            this.treeListCol3.Name = "treeListCol3";
            this.treeListCol3.Visible = true;
            this.treeListCol3.VisibleIndex = 2;
            this.treeListCol3.Width = 0x63;
            this.treeListCol4.Caption = "冲突对象";
            this.treeListCol4.FieldName = "状态";
            this.treeListCol4.Name = "treeListCol4";
            this.treeListCol4.Visible = true;
            this.treeListCol4.VisibleIndex = 3;
            this.treeListCol4.Width = 0x2e;
            this.repositoryItemImageEdit9.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit9.Appearance.Image");
            this.repositoryItemImageEdit9.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit9.AutoHeight = false;
            this.repositoryItemImageEdit9.Name = "repositoryItemImageEdit9";
            this.repositoryItemImageEdit9.ShowDropDown = ShowDropDown.Never;
            this.panel8.BackColor = Color.Transparent;
            this.panel8.Controls.Add(this.labelprogress2);
            this.panel8.Controls.Add(this.simpleButtonZTOverlap);
            this.panel8.Dock = DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new Padding(4, 6, 0, 6);
            this.panel8.Size = new Size(0x117, 0x26);
            this.panel8.TabIndex = 0x18;
            this.labelprogress2.BackColor = Color.Transparent;
            this.labelprogress2.Dock = DockStyle.Fill;
            this.labelprogress2.Location = new System.Drawing.Point(80, 6);
            this.labelprogress2.Name = "labelprogress2";
            this.labelprogress2.Size = new Size(0xc7, 0x1a);
            this.labelprogress2.TabIndex = 14;
            this.labelprogress2.Text = "  进度:";
            this.labelprogress2.TextAlign = ContentAlignment.MiddleLeft;
            this.simpleButtonZTOverlap.Dock = DockStyle.Left;
            this.simpleButtonZTOverlap.ImageIndex = 0;
            this.simpleButtonZTOverlap.ImageList = this.imageList2;
            this.simpleButtonZTOverlap.Location = new System.Drawing.Point(4, 6);
            this.simpleButtonZTOverlap.Name = "simpleButtonZTOverlap";
            this.simpleButtonZTOverlap.Size = new Size(0x4c, 0x1a);
            this.simpleButtonZTOverlap.TabIndex = 13;
            this.simpleButtonZTOverlap.Text = "重叠计算";
            this.simpleButtonZTOverlap.ToolTip = "遥感数据与专题数据重叠计算";
            this.simpleButtonZTOverlap.Visible = false;
            this.simpleButtonZTOverlap.Click += new EventHandler(this.simpleButtonZTOverlap_Click);
            this.labelZTCount.Dock = DockStyle.Top;
            this.labelZTCount.Location = new System.Drawing.Point(0, 4);
            this.labelZTCount.Name = "labelZTCount";
            this.labelZTCount.Size = new Size(0x11c, 0x12);
            this.labelZTCount.TabIndex = 0x29;
            this.labelZTCount.Text = "  造林专题共计 100个班块";
            this.labelZTCount.TextAlign = ContentAlignment.MiddleLeft;
            this.simpleButtonRefresh.ImageIndex = 0x55;
            this.simpleButtonRefresh.ImageList = this.ImageList1;
            this.simpleButtonRefresh.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonRefresh.Location = new System.Drawing.Point(0xaf, 0x15);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new Size(0x30, 20);
            item4.Text = "计算列表";
            tip4.Items.Add(item4);
            this.simpleButtonRefresh.SuperTip = tip4;
            this.simpleButtonRefresh.TabIndex = 0x27;
            this.simpleButtonRefresh.Text = "计算";
            this.simpleButtonRefresh.Click += new EventHandler(this.simpleButtonRefresh_Click);
            this.simpleButtonStop.ImageIndex = 0x3a;
            this.simpleButtonStop.ImageList = this.ImageList1;
            this.simpleButtonStop.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonStop.Location = new System.Drawing.Point(0xaf, 0x15);
            this.simpleButtonStop.Name = "simpleButtonStop";
            this.simpleButtonStop.Size = new Size(0x30, 20);
            item5.Text = "停止计算";
            tip5.Items.Add(item5);
            this.simpleButtonStop.SuperTip = tip5;
            this.simpleButtonStop.TabIndex = 0x26;
            this.simpleButtonStop.Text = "停止";
            this.simpleButtonStop.Visible = false;
            this.simpleButtonStop.Click += new EventHandler(this.simpleButtonStop_Click);
            this.simpleButtonInfo.ImageIndex = 4;
            this.simpleButtonInfo.ImageList = this.imageList2;
            this.simpleButtonInfo.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(0xe3, 0x15);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(50, 20);
            item6.Text = "详细信息";
            tip6.Items.Add(item6);
            this.simpleButtonInfo.SuperTip = tip6;
            this.simpleButtonInfo.TabIndex = 2;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.labelinfo.Dock = DockStyle.Bottom;
            this.labelinfo.ImageAlign = ContentAlignment.TopLeft;
            this.labelinfo.ImageIndex = 0x13;
            this.labelinfo.ImageList = this.ImageList1;
            this.labelinfo.Location = new System.Drawing.Point(0, 260);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new Size(0x11c, 0x12);
            this.labelinfo.TabIndex = 40;
            this.labelinfo.Text = "    ";
            this.labelinfo.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(4, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(0x124, 0x1a);
            this.labelIdentify.TabIndex = 0x19;
            this.labelIdentify.Text = "      专题数据合并";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            this.splitterControl1.Dock = DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(4, 0xa1);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new Size(0x11c, 6);
            this.splitterControl1.TabIndex = 0x1b;
            this.splitterControl1.TabStop = false;
            this.splitterControl1.Visible = false;
            this.imageList9.ImageStream = (ImageListStreamer) resources.GetObject("imageList9.ImageStream");
            this.imageList9.TransparentColor = Color.Transparent;
            this.imageList9.Images.SetKeyName(0, "(01,49).png");
            this.imageList9.Images.SetKeyName(1, "");
            this.imageList9.Images.SetKeyName(2, "(18,13).png");
            this.imageList9.Images.SetKeyName(3, "(01,46).png");
            this.imageList9.Images.SetKeyName(4, "(05,49).png");
            this.imageList9.Images.SetKeyName(5, "(06,30).png");
            this.imageList9.Images.SetKeyName(6, "(07,30).png");
            this.imageList9.Images.SetKeyName(7, "(09,13).png");
            this.imageList9.Images.SetKeyName(8, "(09,24).png");
            this.imageList9.Images.SetKeyName(9, "(11,49).png");
            this.imageList9.Images.SetKeyName(10, "(18,29).png");
            this.imageList9.Images.SetKeyName(11, "(34,00).png");
            this.imageList9.Images.SetKeyName(12, "(47,25).png");
            this.imageList9.Images.SetKeyName(13, "(48,48).png");
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barButtonItemInput), new LinkPersistInfo(this.barButtonItemInput2), new LinkPersistInfo(this.barButtonItemChange, true), new LinkPersistInfo(this.barButtonItemInput3, true), new LinkPersistInfo(this.barButtonItemReadValue, true), new LinkPersistInfo(this.barButtonItemDelete, true) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.barButtonItemInput.Caption = "导入专题小班并裁去相交部分";
            this.barButtonItemInput.Id = 0;
            this.barButtonItemInput.Name = "barButtonItemInput";
            this.barButtonItemInput.ItemClick += new ItemClickEventHandler(this.barButtonItemInput_ItemClick);
            this.barButtonItemInput2.Caption = "导入专题小班，裁去变更小班相交部分";
            this.barButtonItemInput2.Id = 1;
            this.barButtonItemInput2.Name = "barButtonItemInput2";
            this.barButtonItemInput2.ItemClick += new ItemClickEventHandler(this.barButtonItemInput2_ItemClick);
            this.barButtonItemChange.Caption = "导入专题小班，删除变更小班";
            this.barButtonItemChange.Id = 3;
            this.barButtonItemChange.Name = "barButtonItemChange";
            this.barButtonItemChange.ItemClick += new ItemClickEventHandler(this.barButtonItemChange_ItemClick);
            this.barButtonItemInput3.Caption = "导入专题小班";
            this.barButtonItemInput3.Id = 4;
            this.barButtonItemInput3.Name = "barButtonItemInput3";
            this.barButtonItemInput3.ItemClick += new ItemClickEventHandler(this.barButtonItemInput3_ItemClick);
            this.barButtonItemReadValue.Caption = "读取专题小班属性值";
            this.barButtonItemReadValue.Id = 2;
            this.barButtonItemReadValue.Name = "barButtonItemReadValue";
            this.barButtonItemReadValue.ItemClick += new ItemClickEventHandler(this.barButtonItemReadValue_ItemClick);
            this.barButtonItemDelete.Caption = "删除变更小班";
            this.barButtonItemDelete.Id = 5;
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.ItemClick += new ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.barButtonItemInput, this.barButtonItemInput2, this.barButtonItemReadValue, this.barButtonItemChange, this.barButtonItemInput3, this.barButtonItemDelete });
            this.barManager1.MaxItemId = 6;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(4, 0);
            this.barDockControlTop.Size = new Size(0x124, 0);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(4, 0x38c);
            this.barDockControlBottom.Size = new Size(0x124, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(4, 0);
            this.barDockControlLeft.Size = new Size(0, 0x38c);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(0x128, 0);
            this.barDockControlRight.Size = new Size(0, 0x38c);
            this.panelInfo.Controls.Add(this.labelXBInfo);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(4, 0x1a);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(0, 4, 0, 4);
            this.panelInfo.Size = new Size(0x124, 0x5e);
            this.panelInfo.TabIndex = 0x27;
            this.panelInfo.Visible = false;
            this.labelXBInfo.Dock = DockStyle.Fill;
            this.labelXBInfo.Location = new System.Drawing.Point(0, 4);
            this.labelXBInfo.Name = "labelXBInfo";
            this.labelXBInfo.Size = new Size(0x124, 0x56);
            this.labelXBInfo.TabIndex = 0;
            this.labelXBInfo.Text = "已有变更小班 共计0个  \r\n导入遥感判读班块0个,已确定变化原因班块0个(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n非遥感判读导入班块0个,(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n\r\n\r\n";
            this.labelXBInfo.DoubleClick += new EventHandler(this.labelXBInfo_DoubleClick);
            this.groupControlCheck.Controls.Add(this.panel11);
            this.groupControlCheck.Controls.Add(this.panelLogChk);
            this.groupControlCheck.Controls.Add(this.tListKind2);
            this.groupControlCheck.Controls.Add(this.label2);
            this.groupControlCheck.Dock = DockStyle.Top;
            this.groupControlCheck.Location = new System.Drawing.Point(4, 0x255);
            this.groupControlCheck.Name = "groupControlCheck";
            this.groupControlCheck.Padding = new Padding(2);
            this.groupControlCheck.Size = new Size(0x124, 300);
            this.groupControlCheck.TabIndex = 40;
            this.groupControlCheck.Text = "专题校验";
            this.panel11.BackColor = Color.Transparent;
            this.panel11.Controls.Add(this.simpleButtonCheckAll);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.simpleButtonCheck);
            this.panel11.Dock = DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(4, 0xa8);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new Padding(0, 4, 0, 0);
            this.panel11.Size = new Size(0x11c, 30);
            this.panel11.TabIndex = 0x19;
            this.simpleButtonCheckAll.Dock = DockStyle.Right;
            this.simpleButtonCheckAll.ImageIndex = 1;
            this.simpleButtonCheckAll.ImageList = this.imageList2;
            this.simpleButtonCheckAll.Location = new System.Drawing.Point(0x86, 4);
            this.simpleButtonCheckAll.Name = "simpleButtonCheckAll";
            this.simpleButtonCheckAll.Size = new Size(0x48, 0x1a);
            this.simpleButtonCheckAll.TabIndex = 15;
            this.simpleButtonCheckAll.Text = "全部校验";
            this.simpleButtonCheckAll.ToolTip = "校验专题数据是否有重叠班块";
            this.simpleButtonCheckAll.Click += new EventHandler(this.simpleButtonCheckAll_Click);
            this.panel14.Dock = DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(0xce, 4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new Size(6, 0x1a);
            this.panel14.TabIndex = 0x10;
            this.simpleButtonCheck.Dock = DockStyle.Right;
            this.simpleButtonCheck.ImageIndex = 15;
            this.simpleButtonCheck.ImageList = this.imageList2;
            this.simpleButtonCheck.Location = new System.Drawing.Point(0xd4, 4);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x48, 0x1a);
            this.simpleButtonCheck.TabIndex = 14;
            this.simpleButtonCheck.Text = "指定校验";
            this.simpleButtonCheck.ToolTip = "校验遥感数据是否有重叠班块";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            this.panelLogChk.BackColor = Color.Transparent;
            this.panelLogChk.Controls.Add(this.panelControl3);
            this.panelLogChk.Controls.Add(this.panel16);
            this.panelLogChk.Dock = DockStyle.Fill;
            this.panelLogChk.Location = new System.Drawing.Point(4, 0xa8);
            this.panelLogChk.Name = "panelLogChk";
            this.panelLogChk.Padding = new Padding(0, 6, 0, 0);
            this.panelLogChk.Size = new Size(0x11c, 0x80);
            this.panelLogChk.TabIndex = 0x2b;
            this.panelLogChk.Visible = false;
            this.panelControl3.Controls.Add(this.richTextChk);
            this.panelControl3.Dock = DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0x20);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(0x11c, 0x60);
            this.panelControl3.TabIndex = 0x10;
//            this.richTextChk.BorderStyle = BorderStyle.None;
            this.richTextChk.Dock = DockStyle.Fill;
            this.richTextChk.Location = new System.Drawing.Point(2, 2);
            this.richTextChk.Name = "richTextChk";
            this.richTextChk.Size = new Size(280, 0x5c);
            this.richTextChk.TabIndex = 0;
            this.richTextChk.Text = "";
            this.panel16.Controls.Add(this.labelChkprogress);
            this.panel16.Dock = DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 6);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new Padding(0, 2, 0, 2);
            this.panel16.Size = new Size(0x11c, 0x1a);
            this.panel16.TabIndex = 15;
            this.labelChkprogress.BackColor = Color.Transparent;
            this.labelChkprogress.Dock = DockStyle.Fill;
            this.labelChkprogress.Location = new System.Drawing.Point(0, 2);
            this.labelChkprogress.Name = "labelChkprogress";
            this.labelChkprogress.Size = new Size(0x11c, 0x16);
            this.labelChkprogress.TabIndex = 8;
            this.labelChkprogress.Text = "校验中:";
            this.tListKind2.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tListKind2.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tListKind2.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tListKind2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListKind2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListKind2.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tListKind2.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tListKind2.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tListKind2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListKind2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListKind2.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tListKind2.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tListKind2.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tListKind2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListKind2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListKind2.Columns.AddRange(new TreeListColumn[] { this.treeListColumn7, this.treeListColumn8, this.treeListColumn9, this.treeListColumn10, this.treeListColumn16 });
            this.tListKind2.Dock = DockStyle.Top;
            this.tListKind2.Location = new System.Drawing.Point(4, 0x31);
            this.tListKind2.Name = "tListKind2";
            this.tListKind2.BeginUnboundLoad();
            object[] nodeData6 = new object[5];
            nodeData6[0] = "造林";
            nodeData6[1] = "未通过";
            this.tListKind2.AppendNode(nodeData6, -1, 0, 0, 0x24);
            object[] nodeData7 = new object[5];
            nodeData7[0] = "采伐";
            nodeData7[1] = "未通过";
            this.tListKind2.AppendNode(nodeData7, -1, -1, -1, 0x25);
            object[] nodeData8 = new object[5];
            nodeData8[0] = "森林火灾";
            nodeData8[1] = "未通过";
            this.tListKind2.AppendNode(nodeData8, -1, -1, -1, 0x2b);
            object[] nodeData9 = new object[5];
            nodeData9[0] = "林地征占用";
            this.tListKind2.AppendNode(nodeData9, -1, -1, -1, 0x2a);
            object[] nodeData10 = new object[5];
            nodeData10[0] = "自然灾害";
            this.tListKind2.AppendNode(nodeData10, -1, -1, -1, 0x2d);
            object[] nodeData15 = new object[5];
            nodeData15[0] = "林业案件";
            this.tListKind2.AppendNode(nodeData15, -1, -1, -1, 0x12);
            this.tListKind2.EndUnboundLoad();
            this.tListKind2.OptionsBehavior.Editable = false;
            this.tListKind2.OptionsView.AutoWidth = false;
            this.tListKind2.OptionsView.ShowColumns = false;
            this.tListKind2.OptionsView.ShowHorzLines = false;
            this.tListKind2.OptionsView.ShowIndicator = false;
            this.tListKind2.OptionsView.ShowRoot = false;
            this.tListKind2.OptionsView.ShowVertLines = false;
            this.tListKind2.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit10, this.repositoryItemImageComboBox2, this.repositoryItemPictureEdit2, this.repositoryItemButtonEdit2, this.repositoryItemImageEdit11, this.repositoryItemImageEdit12 });
            this.tListKind2.RowHeight = 0x1a;
            this.tListKind2.SelectImageList = this.imageList8;
            this.tListKind2.Size = new Size(0x11c, 0x77);
            this.tListKind2.StateImageList = this.imageCollection3;
            this.tListKind2.TabIndex = 0x18;
            this.tListKind2.TreeLevelWidth = 12;
            this.tListKind2.TreeLineStyle = LineStyle.None;
            this.tListKind2.MouseUp += new MouseEventHandler(this.tListKind2_MouseUp);
            this.tListKind2.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tListKind2_CustomNodeCellEdit);
            this.tListKind2.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tListKind2_FocusedNodeChanged);
            this.tListKind2.Resize += new EventHandler(this.tListKind2_Resize);
            this.tListKind2.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tListKind2_FocusedColumnChanged);
            this.tListKind2.MouseDoubleClick += new MouseEventHandler(this.tListKind2_MouseDoubleClick);
            this.tListKind2.DoubleClick += new EventHandler(this.tListKind2_DoubleClick);
            this.treeListColumn7.Caption = "专题";
            this.treeListColumn7.FieldName = "treeListColumn1";
            this.treeListColumn7.MinWidth = 0x5c;
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 0;
            this.treeListColumn7.Width = 120;
            this.treeListColumn8.Caption = "状态";
            this.treeListColumn8.FieldName = "treeListColumn2";
            this.treeListColumn8.MinWidth = 0x10;
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 1;
            this.treeListColumn8.Width = 0x2a;
            this.treeListColumn9.Caption = "可见";
            this.treeListColumn9.FieldName = "treeListColumn3";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 2;
            this.treeListColumn9.Width = 0x22;
            this.treeListColumn10.Caption = "定位";
            this.treeListColumn10.FieldName = "treeListColumn4";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 3;
            this.treeListColumn10.Width = 0x24;
            this.treeListColumn16.Caption = "信息";
            this.treeListColumn16.FieldName = "treeListColumn5";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 4;
            this.treeListColumn16.Width = 0x22;
            this.repositoryItemImageEdit10.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit10.Appearance.Image");
            this.repositoryItemImageEdit10.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit10.AutoHeight = false;
            this.repositoryItemImageEdit10.Name = "repositoryItemImageEdit10";
            this.repositoryItemImageEdit10.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageComboBox2.Appearance.Image = (Image) resources.GetObject("repositoryItemImageComboBox2.Appearance.Image");
            this.repositoryItemImageComboBox2.Appearance.Options.UseImage = true;
            this.repositoryItemImageComboBox2.AppearanceFocused.Image = (Image) resources.GetObject("repositoryItemImageComboBox2.AppearanceFocused.Image");
            this.repositoryItemImageComboBox2.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox2.ButtonsStyle = BorderStyles.NoBorder;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemPictureEdit2.Appearance.Image = (Image) resources.GetObject("repositoryItemPictureEdit2.Appearance.Image");
            this.repositoryItemPictureEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Plus) });
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.repositoryItemImageEdit11.AutoHeight = false;
            this.repositoryItemImageEdit11.Name = "repositoryItemImageEdit11";
            this.repositoryItemImageEdit11.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit12.AutoHeight = false;
            this.repositoryItemImageEdit12.Name = "repositoryItemImageEdit12";
            this.label2.Dock = DockStyle.Top;
            this.label2.ForeColor = Color.Navy;
            this.label2.Location = new System.Drawing.Point(4, 0x19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x11c, 0x18);
            this.label2.TabIndex = 0x2a;
            this.label2.Text = "  选择专题类型，开始校验专题数据";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            this.groupControlCombine.Controls.Add(this.splitterControl1);
            this.groupControlCombine.Controls.Add(this.panelIDList);
            this.groupControlCombine.Controls.Add(this.panel6);
            this.groupControlCombine.Controls.Add(this.tListKind);
            this.groupControlCombine.Controls.Add(this.label1);
            this.groupControlCombine.Dock = DockStyle.Top;
            this.groupControlCombine.Location = new System.Drawing.Point(4, 0x98);
            this.groupControlCombine.Name = "groupControlCombine";
            this.groupControlCombine.Padding = new Padding(2);
            this.groupControlCombine.Size = new Size(0x124, 0x1bd);
            this.groupControlCombine.TabIndex = 0x29;
            this.groupControlCombine.Text = "专题合并";
            this.label1.Dock = DockStyle.Top;
            this.label1.ForeColor = Color.Navy;
            this.label1.Location = new System.Drawing.Point(4, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x11c, 20);
            this.label1.TabIndex = 0x1c;
            this.label1.Text = "  选择专题类型，开始编辑、导入数据";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            this.simpleButtonClearLayer.Dock = DockStyle.Right;
            this.simpleButtonClearLayer.ImageIndex = 0x51;
            this.simpleButtonClearLayer.ImageList = this.ImageList1;
            this.simpleButtonClearLayer.Location = new System.Drawing.Point(230, 4);
            this.simpleButtonClearLayer.Name = "simpleButtonClearLayer";
            this.simpleButtonClearLayer.Size = new Size(60, 0x18);
            this.simpleButtonClearLayer.TabIndex = 30;
            this.simpleButtonClearLayer.Text = "清空";
            this.simpleButtonClearLayer.ToolTip = "清空图层";
            this.simpleButtonClearLayer.Click += new EventHandler(this.simpleButtonClearLayer_Click);
            this.panelClear.Controls.Add(this.simpleButtonClearLayer);
            this.panelClear.Controls.Add(this.label3);
            this.panelClear.Dock = DockStyle.Top;
            this.panelClear.Location = new System.Drawing.Point(4, 120);
            this.panelClear.Name = "panelClear";
            this.panelClear.Padding = new Padding(0, 4, 2, 4);
            this.panelClear.Size = new Size(0x124, 0x20);
            this.panelClear.TabIndex = 0x2a;
            this.label3.Dock = DockStyle.Left;
            this.label3.ForeColor = Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new Size(220, 0x18);
            this.label3.TabIndex = 30;
            this.label3.Text = "清空小班变更图层重新开始专题合并";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.groupControlCheck);
            base.Controls.Add(this.groupControlCombine);
            base.Controls.Add(this.panelClear);
            base.Controls.Add(this.panelInfo);
            base.Controls.Add(this.labelIdentify);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "UserControlXBSet";
            base.Padding = new Padding(4, 0, 4, 0);
            base.Size = new Size(300, 0x38c);
            this.imageCollection1.EndInit();
            this.imageCollection2.EndInit();
            this.panel6.ResumeLayout(false);
            this.repositoryItemImageEdit4.EndInit();
            this.repositoryItemImageEdit5.EndInit();
            this.tListKind.EndInit();
            this.repositoryItemImageEdit2.EndInit();
            this.repositoryItemImageComboBox1.EndInit();
            this.repositoryItemPictureEdit1.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemImageEdit3.EndInit();
            this.repositoryItemImageEdit33.EndInit();
            this.imageCollection3.EndInit();
            this.panelIDList.ResumeLayout(false);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageEdit6.EndInit();
            this.repositoryItemImageEdit7.EndInit();
            this.panelLog2.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            ((ISupportInitialize) this.listBoxDateEque).EndInit();
            this.panel13.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.tList2.EndInit();
            this.repositoryItemImageEdit8.EndInit();
            this.panel3.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.tList3.EndInit();
            this.repositoryItemImageEdit9.EndInit();
            this.panel8.ResumeLayout(false);
            this.popupMenu1.EndInit();
            this.barManager1.EndInit();
            this.panelInfo.ResumeLayout(false);
            this.groupControlCheck.EndInit();
            this.groupControlCheck.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panelLogChk.ResumeLayout(false);
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.tListKind2.EndInit();
            this.repositoryItemImageEdit10.EndInit();
            this.repositoryItemImageComboBox2.EndInit();
            this.repositoryItemPictureEdit2.EndInit();
            this.repositoryItemButtonEdit2.EndInit();
            this.repositoryItemImageEdit11.EndInit();
            this.repositoryItemImageEdit12.EndInit();
            this.groupControlCombine.EndInit();
            this.groupControlCombine.ResumeLayout(false);
            this.panelClear.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void InitialKindList(bool flag)
        {
            try
            {
                int num;
                int num2;
                ArrayList list;
                int num3;
                TreeListNode node2 = null;
                TreeListNode node3 = null;
                this.tListKind.Columns[0].Width = 0x92;
                this.tListKind.Columns[1].Width = 0x2c;
                this.tListKind.Columns[2].Width = 20;
                this.tListKind.Columns[3].Width = 20;
                this.tListKind.Columns[4].Width = 20;
                this.tListKind.OptionsView.ShowRoot = true;
                this.tListKind.SelectImageList = this.imageList8;
                this.tListKind.StateImageList = this.imageCollection3;
                this.tListKind.OptionsView.ShowButtons = true;
                this.tListKind.TreeLineStyle = LineStyle.None;
                this.tListKind.RowHeight = 0x1a;
                this.tListKind.OptionsBehavior.AutoPopulateColumns = true;
                this.tListKind.Height = 0xa6;
                for (num = 0; num < (this.tListKind.Nodes.Count - 1); num++)
                {
                    if ((this.tListKind.Nodes[num].ParentNode == null) && (this.tListKind.Nodes[num].Nodes.Count > 0))
                    {
                        num2 = 0;
                        while (num2 < this.tListKind.Nodes[num].Nodes.Count)
                        {
                            this.tListKind.Nodes[num].Nodes[num2].SetValue(1, "");
                            this.tListKind.Nodes[num].Nodes[num2].SelectImageIndex = -1;
                            this.tListKind.Nodes[num].Nodes[num2].ImageIndex = -1;
                            if ((this.tListKind.Nodes[num].Nodes[num2].Nodes.Count > 0) && (this.tListKind.Nodes[num].ParentNode == null))
                            {
                                this.tListKind.Nodes[num].Nodes[num2].Nodes.Clear();
                            }
                            list = new ArrayList();
                            num3 = num2 + 1;
                            list.Add("0" + num3.ToString());
                            this.tListKind.Nodes[num].Nodes[num2].Tag = list;
                            num2++;
                        }
                    }
                    else
                    {
                        this.tListKind.Nodes[num].SetValue(1, "");
                        this.tListKind.Nodes[num].SelectImageIndex = -1;
                        this.tListKind.Nodes[num].ImageIndex = -1;
                        if ((this.tListKind.Nodes[num].Nodes.Count > 0) && (this.tListKind.Nodes[num].ParentNode == null))
                        {
                            this.tListKind.Nodes[num].Nodes.Clear();
                        }
                        list = new ArrayList();
                        num3 = num + 1;
                        list.Add("0" + num3.ToString());
                        this.tListKind.Nodes[num].Tag = list;
                    }
                }
                if (flag)
                {
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName2").Split(new char[] { ',' });
                    string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName3").Split(new char[] { ',' });
                    string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName4").Split(new char[] { ',' });
                    ArrayList underLayers = EditTask.UnderLayers;
                    list = null;
                    bool flag2 = true;
                    for (num = 0; num < (this.tListKind.Nodes.Count - 1); num++)
                    {
                        string str;
                        string str2;
                        string str3;
                        IFeatureLayer layer;
                        node3 = this.tListKind.Nodes[num];
                        node3.ExpandAll();
                        node3.SelectImageIndex = -1;
                        node3.ImageIndex = -1;
                        if (node3.Nodes.Count == 0)
                        {
                            if (num <= (strArray.Length - 1))
                            {
                                str = strArray[num];
                                str2 = strArray2[num];
                                str3 = strArray3[num];
                                layer = underLayers[num] as IFeatureLayer;
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                list.Add(layer);
                                list.Add(str3);
                                node3.Tag = list;
                                node3.Nodes.Clear();
                                if (this.mStateTable.Rows[num]["EditState"].ToString() == "0")
                                {
                                    node3.SetValue(1, "未编辑");
                                    flag2 = false;
                                }
                                else if (this.mStateTable.Rows[num]["EditState"].ToString() == "1")
                                {
                                    node3.SetValue(1, "编辑");
                                    flag2 = false;
                                }
                                else if (this.mStateTable.Rows[num]["EditState"].ToString() == "2")
                                {
                                    node3.SetValue(1, "已完成");
                                }
                                if (layer.Visible)
                                {
                                    node3.SetValue(5, "可见");
                                }
                                else
                                {
                                    node3.SetValue(5, "不可见");
                                }
                            }
                            else
                            {
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                node3.Tag = list;
                            }
                        }
                        else
                        {
                            switch (num)
                            {
                                case 0:
                                    num2 = 0;
                                    while (num2 < node3.Nodes.Count)
                                    {
                                        node2 = node3.Nodes[num2];
                                        if (num2 <= (strArray.Length - 1))
                                        {
                                            str = strArray[num2];
                                            str2 = strArray2[num2];
                                            str3 = strArray3[num2];
                                            layer = underLayers[num2] as IFeatureLayer;
                                            list = new ArrayList();
                                            num3 = num2 + 1;
                                            list.Add("0" + num3.ToString());
                                            list.Add(layer);
                                            list.Add(str3);
                                            node2.Tag = list;
                                            node2.Nodes.Clear();
                                            if (layer.Visible)
                                            {
                                                node2.SetValue(2, "可见");
                                            }
                                            else
                                            {
                                                node2.SetValue(2, "不可见");
                                            }
                                        }
                                        else
                                        {
                                            list = new ArrayList();
                                            num3 = num + 1;
                                            list.Add("0" + num3.ToString());
                                            node2.Tag = list;
                                        }
                                        num2++;
                                    }
                                    break;

                                case 1:
                                    for (num2 = 0; num2 < node3.Nodes.Count; num2++)
                                    {
                                        node2 = node3.Nodes[num2];
                                        list = new ArrayList();
                                        list.Add("0" + (((node2.Id - 2) + 1)).ToString());
                                        node2.Tag = list;
                                        node2.SetValue(3, "");
                                    }
                                    break;
                            }
                        }
                    }
                    node3 = this.tListKind.Nodes[this.tListKind.Nodes.Count - 1];
                    node3.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialListCheck(bool flag)
        {
            try
            {
                int num;
                int num2;
                ArrayList list;
                int num3;
                TreeListNode node2 = null;
                TreeListNode node3 = null;
                this.tListKind2.Columns[0].Width = 140;
                this.tListKind2.Columns[1].Width = 130;
                this.tListKind2.Columns[2].Width = 0;
                this.tListKind2.Columns[3].Width = 0;
                this.tListKind2.Columns[4].Width = 0;
                this.tListKind2.Columns[2].Visible = false;
                this.tListKind2.Columns[3].Visible = false;
                this.tListKind2.Columns[4].Visible = false;
                this.tListKind2.OptionsView.ShowRoot = true;
                this.tListKind2.SelectImageList = this.imageList8;
                this.tListKind2.StateImageList = this.imageCollection3;
                this.tListKind2.OptionsView.ShowButtons = true;
                this.tListKind2.TreeLineStyle = LineStyle.None;
                this.tListKind2.RowHeight = 0x1a;
                this.tListKind2.OptionsBehavior.AutoPopulateColumns = true;
                this.tListKind2.Height = 0xa6;
                for (num = 0; num < (this.tListKind2.Nodes.Count - 1); num++)
                {
                    if ((this.tListKind2.Nodes[num].ParentNode == null) && (this.tListKind2.Nodes[num].Nodes.Count > 0))
                    {
                        num2 = 0;
                        while (num2 < this.tListKind2.Nodes[num].Nodes.Count)
                        {
                            this.tListKind2.Nodes[num].Nodes[num2].SetValue(1, "");
                            this.tListKind2.Nodes[num].Nodes[num2].SelectImageIndex = -1;
                            this.tListKind2.Nodes[num].Nodes[num2].ImageIndex = -1;
                            if ((this.tListKind2.Nodes[num].Nodes[num2].Nodes.Count > 0) && (this.tListKind2.Nodes[num].ParentNode == null))
                            {
                                this.tListKind2.Nodes[num].Nodes[num2].Nodes.Clear();
                            }
                            list = new ArrayList();
                            num3 = num2 + 1;
                            list.Add("0" + num3.ToString());
                            this.tListKind2.Nodes[num].Nodes[num2].Tag = list;
                            num2++;
                        }
                    }
                    else
                    {
                        this.tListKind2.Nodes[num].SetValue(1, "");
                        this.tListKind2.Nodes[num].SelectImageIndex = -1;
                        this.tListKind2.Nodes[num].ImageIndex = -1;
                        if ((this.tListKind2.Nodes[num].Nodes.Count > 0) && (this.tListKind2.Nodes[num].ParentNode == null))
                        {
                            this.tListKind2.Nodes[num].Nodes.Clear();
                        }
                        list = new ArrayList();
                        num3 = num + 1;
                        list.Add("0" + num3.ToString());
                        this.tListKind2.Nodes[num].Tag = list;
                    }
                }
                if (flag)
                {
                    this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName2").Split(new char[] { ',' });
                    string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName3").Split(new char[] { ',' });
                    string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName4").Split(new char[] { ',' });
                    ArrayList underLayers = EditTask.UnderLayers;
                    list = null;
                    bool flag2 = true;
                    for (num = 0; num < this.tListKind2.Nodes.Count; num++)
                    {
                        string str;
                        string str2;
                        string str3;
                        IFeatureLayer layer;
                        node3 = this.tListKind2.Nodes[num];
                        node3.ExpandAll();
                        node3.SelectImageIndex = -1;
                        node3.ImageIndex = -1;
                        if (node3.Nodes.Count == 0)
                        {
                            if (num <= (strArray.Length - 1))
                            {
                                str = strArray[num];
                                str2 = strArray2[num];
                                str3 = strArray3[num];
                                layer = underLayers[num] as IFeatureLayer;
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                list.Add(layer);
                                list.Add(str3);
                                node3.Tag = list;
                                node3.Nodes.Clear();
                                DataRow[] rowArray = this.mStateTable.Select("taskname='" + node3.GetDisplayText(0) + "'");
                                if ((rowArray.Length == 0) && (node3.GetDisplayText(0).Length > 3))
                                {
                                    rowArray = this.mStateTable.Select("taskname='" + node3.GetDisplayText(0).Substring(node3.GetDisplayText(0).Length - 2, 2) + "'");
                                }
                                if ((rowArray.Length == 0) && (node3.GetDisplayText(0).Length > 4))
                                {
                                    rowArray = this.mStateTable.Select("taskname='" + node3.GetDisplayText(0).Substring(node3.GetDisplayText(0).Length - 3, 3) + "'");
                                }
                                if (rowArray.Length > 0)
                                {
                                    if ((rowArray[0]["logiccheckstate"].ToString() == "0") && (rowArray[0]["toplogiccheckstate"].ToString() == "0"))
                                    {
                                        node3.SetValue(1, "未校验或校验未通过");
                                        flag2 = false;
                                    }
                                    else if ((rowArray[0]["logiccheckstate"].ToString() == "1") && (rowArray[0]["toplogiccheckstate"].ToString() == "1"))
                                    {
                                        node3.SetValue(1, "校验通过");
                                    }
                                    else if (rowArray[0]["logiccheckstate"].ToString() == "0")
                                    {
                                        node3.SetValue(1, "逻辑校验未通过");
                                        flag2 = false;
                                    }
                                    else if (rowArray[0]["toplogiccheckstate"].ToString() == "1")
                                    {
                                        node3.SetValue(1, "拓扑校验未通过");
                                        flag2 = false;
                                    }
                                }
                                if (layer.Visible)
                                {
                                    node3.SetValue(5, "可见");
                                }
                                else
                                {
                                    node3.SetValue(5, "不可见");
                                }
                            }
                            else
                            {
                                list = new ArrayList();
                                num3 = num + 1;
                                list.Add("0" + num3.ToString());
                                node3.Tag = list;
                            }
                        }
                        else
                        {
                            switch (num)
                            {
                                case 0:
                                    num2 = 0;
                                    while (num2 < node3.Nodes.Count)
                                    {
                                        node2 = node3.Nodes[num2];
                                        if (num2 <= (strArray.Length - 1))
                                        {
                                            str = strArray[num2];
                                            str2 = strArray2[num2];
                                            str3 = strArray3[num2];
                                            layer = underLayers[num2] as IFeatureLayer;
                                            list = new ArrayList();
                                            num3 = num2 + 1;
                                            list.Add("0" + num3.ToString());
                                            list.Add(layer);
                                            list.Add(str3);
                                            node2.Tag = list;
                                            node2.Nodes.Clear();
                                            if (layer.Visible)
                                            {
                                                node2.SetValue(2, "可见");
                                            }
                                            else
                                            {
                                                node2.SetValue(2, "不可见");
                                            }
                                        }
                                        else
                                        {
                                            list = new ArrayList();
                                            num3 = num + 1;
                                            list.Add("0" + num3.ToString());
                                            node2.Tag = list;
                                        }
                                        num2++;
                                    }
                                    break;

                                case 1:
                                    for (num2 = 0; num2 < node3.Nodes.Count; num2++)
                                    {
                                        node2 = node3.Nodes[num2];
                                        list = new ArrayList();
                                        list.Add("0" + (((node2.Id - 2) + 1)).ToString());
                                        node2.Tag = list;
                                        node2.SetValue(3, "");
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialListCheck", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialListID()
        {
            try
            {
                string configValue;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                this.tList.BringToFront();
                this.m_UnderLayer = EditTask.UnderLayer;
                this.xtraTabPage1.Tooltip = "与" + this.m_UnderLayer.Name + "相交班块";
                ToolTipItem item = this.xtraTabPage1.SuperTip.Items[0] as ToolTipItem;
                item.Text = "与" + this.m_UnderLayer.Name + "相交班块";
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                this.tList.Columns[0].Width = 40;
                this.tList.Columns[1].Width = 0x24;
                this.tList.Columns[2].Width = 0x24;
                this.tList.Columns[3].Width = 0x2c;
                this.tList.Columns[4].Width = 0x48;
                this.tList.Columns[4].Caption = this.m_UnderLayer.Name.Replace("专题", "班块");
                this.tList.Columns[5].Caption = "相交比率";
                this.tList.Columns[5].Width = 0x48;
                this.tListCol3.Visible = false;
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.Nodes.Clear();
                    }
                    this.tList.Refresh();
                }
                catch (Exception)
                {
                    this.tList.Refresh();
                }
                IFeatureCursor cursor = this.m_UnderLayer.FeatureClass.Search(null, false);
                IFeatureCursor cursor2 = this.m_EditLayer.FeatureClass.Search(null, false);
                GC.Collect();
                IFeature pFeature = cursor2.NextFeature();
                int index = -1;
                int num2 = -1;
                int num3 = -1;
                int num4 = -1;
                if (pFeature != null)
                {
                    configValue = "OBJECTID";
                    index = pFeature.Fields.FindField(configValue);
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                    num4 = pFeature.Fields.FindField(configValue);
                    num2 = pFeature.Fields.FindField("BHYY");
                }
                this.labelinfo.Text = "    计算变更小班与" + this.m_UnderLayer.Name + "相交班块...";
                int num5 = 0;
                ArrayList list = new ArrayList();
                while (pFeature != null)
                {
                    num5++;
                    Application.DoEvents();
                    this.labelinfo.Height = 0x1c;
                    if (list.Count > 0)
                    {
                        this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班,", list.Count, "个", this.m_UnderLayer.Name, "小班" });
                    }
                    else
                    {
                        this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班" });
                    }
                    IList<double> pAreaList = null;
                    IList<IFeature> list3 = this.GetOverlapList(pFeature, this.m_UnderLayer.FeatureClass, out pAreaList);
                    Application.DoEvents();
                    if ((list3 != null) && (list3.Count > 0))
                    {
                        string nodeData = pFeature.get_Value(index).ToString();
                        node3 = this.tList.AppendNode(nodeData, parentNode);
                        node3.SetValue(0, nodeData);
                        ArrayList list4 = new ArrayList();
                        list4.Add(pFeature);
                        if (pFeature.get_Value(num4).ToString() != "0")
                        {
                            node3.SetValue(6, pFeature.get_Value(num4).ToString());
                        }
                        if (list.Count > 0)
                        {
                            this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班,", list.Count, "个", this.m_UnderLayer.Name, "小班" });
                        }
                        else
                        {
                            this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班" });
                        }
                        configValue = "OBJECTID";
                        num3 = list3[0].Fields.FindField(configValue);
                        string val = "";
                        string str4 = "";
                        for (int i = 0; i < list3.Count; i++)
                        {
                            list4.Add(list3[i]);
                            if (val != "")
                            {
                                val = val + "," + list3[i].get_Value(num3).ToString();
                            }
                            else
                            {
                                val = list3[i].get_Value(num3).ToString();
                            }
                            if (str4 != "")
                            {
                                double num10 = pAreaList[i];
                                str4 = str4 + "," + num10.ToString();
                            }
                            else
                            {
                                str4 = pAreaList[i].ToString();
                            }
                            bool flag = false;
                            for (int j = 0; j < list.Count; j++)
                            {
                                if (list[j] == list3[i].get_Value(num3).ToString())
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                list.Add(list3[i].get_Value(num3).ToString());
                            }
                        }
                        node3.Tag = list4;
                        if (list.Count > 0)
                        {
                            this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班,", list.Count, "个", this.m_UnderLayer.Name, "小班" });
                        }
                        else
                        {
                            this.labelinfo.Text = string.Concat(new object[] { "    计算变更小班与", this.m_UnderLayer.Name, "相交班块 搜索第", num5, "个 找到", this.tList.Nodes.Count, "个变更小班" });
                        }
                        if (pFeature.get_Value(num2).ToString() != "")
                        {
                            string str5 = pFeature.get_Value(num2).ToString();
                            ICodedValueDomain domain = (ICodedValueDomain) pFeature.Fields.get_Field(num2).Domain;
                            if (pFeature.get_Value(num2).ToString().Trim() != "")
                            {
                                long num8 = Convert.ToInt64(pFeature.get_Value(num2));
                                for (int k = 0; k < domain.CodeCount; k++)
                                {
                                    if (num8 == Convert.ToInt64(domain.get_Value(k)))
                                    {
                                        str5 = domain.get_Name(k);
                                        break;
                                    }
                                }
                                if (node3.GetDisplayText(6) != "")
                                {
                                    node3.SetValue(3, "已核实为" + str5 + "班块");
                                }
                                else
                                {
                                    node3.SetValue(3, "已核实为" + str5 + "班块");
                                }
                            }
                        }
                        else if (node3.GetDisplayText(6) != "")
                        {
                            node3.SetValue(3, "遥感班块未核实");
                        }
                        else
                        {
                            node3.SetValue(3, "");
                        }
                        node3.SetValue(4, val);
                        node3.SetValue(5, str4);
                    }
                    if (this.mStopFlag)
                    {
                        this.mStopFlag = false;
                        break;
                    }
                    pFeature = cursor2.NextFeature();
                }
                this.labelinfo.Text = string.Concat(new object[] { "    变更小班与", this.m_UnderLayer.Name, "相交班块共计", this.tList.Nodes.Count, "个变更小班,", list.Count, "个", this.m_UnderLayer.Name, "小班" });
                if (this.tList.Nodes.Count > 0)
                {
                    this.panel9.Visible = true;
                    this.simpleButtonAuto.Visible = true;
                    this.simpleButtonBack2.Visible = false;
                }
                else
                {
                    this.panel9.Visible = false;
                }
                this.tList.BringToFront();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialListID", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialListID0()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                this.tList3.BringToFront();
                this.xtraTabPage1.Tooltip = "专题间冲突班块";
                ToolTipItem item = this.xtraTabPage1.SuperTip.Items[0] as ToolTipItem;
                item.Text = "专题数据间相交班块";
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                this.tList3.Columns[0].Width = 0x26;
                this.tList3.Columns[1].Width = 0x24;
                this.tList3.Columns[2].Width = 100;
                this.tList3.Columns[3].Width = 0x44;
                try
                {
                    if (this.tList3.Nodes.Count > 0)
                    {
                        this.tList3.Nodes.Clear();
                    }
                }
                catch (Exception)
                {
                }
                string nodeData = "";
                bool flag = false;
                ArrayList list = null;
                this.labelinfo.Text = "    专题数据间相交班块记录" + this.mZTtable.Rows.Count + "条";
                for (int i = 0; i < this.mZTtable.Rows.Count; i++)
                {
                    Application.DoEvents();
                    if (nodeData == "")
                    {
                        nodeData = this.mZTtable.Rows[i]["Overlap_ID"].ToString();
                        flag = true;
                    }
                    else if (nodeData != this.mZTtable.Rows[i]["Overlap_ID"].ToString())
                    {
                        flag = true;
                        nodeData = this.mZTtable.Rows[i]["Overlap_ID"].ToString();
                    }
                    else
                    {
                        flag = false;
                    }
                    IFeatureLayer layer = this.getUnderLayer(this.mZTtable.Rows[i]["Layer_Name"].ToString());
                    IFeature feature = null;
                    if (layer != null)
                    {
                        int iD = int.Parse(this.mZTtable.Rows[i]["Feature_ID"].ToString());
                        feature = layer.FeatureClass.GetFeature(iD);
                        if (flag)
                        {
                            node3 = this.tList3.AppendNode(nodeData, parentNode);
                            node3.SetValue(0, nodeData);
                            node3.SetValue(2, this.mZTtable.Rows[i]["Layer_Name"].ToString());
                            node3.SetValue(3, iD);
                            list = new ArrayList();
                            node3.Tag = list;
                            list.Add(feature);
                        }
                        else
                        {
                            string displayText = node3.GetDisplayText(2);
                            node3.SetValue(2, displayText + "," + this.mZTtable.Rows[i]["Layer_Name"].ToString());
                            node3.SetValue(3, node3.GetDisplayText(3) + "," + iD);
                            (node3.Tag as ArrayList).Add(feature);
                        }
                    }
                    this.labelinfo.Text = "    专题数据间相交班块" + this.tList3.Nodes.Count;
                    if (this.mStopFlag)
                    {
                        this.mStopFlag = false;
                        break;
                    }
                }
                this.Cursor = Cursors.Default;
                this.labelinfo.Text = "    专题数据间相交班块共计" + this.tList3.Nodes.Count + "个";
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialListID0", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialListID2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                this.simpleButtonStop.Enabled = true;
                this.m_UnderLayer = EditTask.UnderLayer;
                this.tList2.BringToFront();
                this.xtraTabPage2.Tooltip = this.m_UnderLayer.Name + "独有班块";
                ToolTipItem item = this.xtraTabPage2.SuperTip.Items[0] as ToolTipItem;
                item.Text = this.m_UnderLayer.Name + "独有班块";
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                this.tList2.Columns[0].Width = 40;
                this.tList2.Columns[1].Width = 0x2c;
                this.tList2.Columns[2].Width = 50;
                this.tList2.Columns[3].Width = 50;
                this.tList2.Columns[4].Width = 0x24;
                this.tList2.BringToFront();
                this.simpleButtonBack.Visible = false;
                try
                {
                    if (this.tList2.Nodes.Count > 0)
                    {
                        this.tList2.Nodes.Clear();
                    }
                    this.tList2.Refresh();
                }
                catch (Exception)
                {
                    this.tList2.Refresh();
                }
                this.tList2.Refresh();
                this.m_UnderLayer = EditTask.UnderLayer;
                IFeatureCursor cursor = this.m_UnderLayer.FeatureClass.Search(null, false);
                IFeatureCursor cursor2 = this.m_EditLayer.FeatureClass.Search(null, false);
                IFeature pFeature = cursor.NextFeature();
                GC.Collect();
                int index = -1;
                string name = "";
                string[] strArray = null;
                if (pFeature != null)
                {
                    name = "OBJECTID";
                    index = pFeature.Fields.FindField(name);
                    strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "FieldDist").Split(new char[] { ',' });
                }
                this.labelinfo.Text = "    计算" + this.m_UnderLayer.Name + "独有班块...";
                int num4 = this.m_EditLayer.FeatureClass.FeatureCount(null);
                int num5 = 0;
                while (pFeature != null)
                {
                    num5++;
                    Application.DoEvents();
                    this.tList2.Refresh();
                    if (num4 > 0)
                    {
                        this.labelinfo.Text = string.Concat(new object[] { "    计算", this.m_UnderLayer.Name, "独有班块 搜索第", num5, "个,找到", this.tList2.Nodes.Count, "个" });
                        IList<IFeature> overlapList = this.GetOverlapList(pFeature, this.m_EditLayer.FeatureClass);
                        Application.DoEvents();
                        if ((overlapList == null) || (overlapList.Count != 0))
                        {
                            goto Label_0494;
                        }
                    }
                    string nodeData = pFeature.get_Value(index).ToString();
                    try
                    {
                        node3 = this.tList2.AppendNode(nodeData, parentNode);
                    }
                    catch (Exception)
                    {
                        node3 = this.tList2.AppendNode(nodeData, parentNode);
                    }
                    node3.SetValue(0, nodeData);
                    node3.Tag = pFeature;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        int num7 = pFeature.Fields.FindField(strArray[i]);
                        if (num7 > -1)
                        {
                            node3.SetValue(i + 1, this.GetFiledValue(num7, pFeature));
                        }
                    }
                    this.labelinfo.Text = string.Concat(new object[] { "    计算", this.m_UnderLayer.Name, "独有班块 搜索第", num5, "个,找到", this.tList2.Nodes.Count, "个" });
                    this.labelinfo.Height = 0x1c;
                    this.labelinfo.Refresh();
                Label_0494:
                    if (this.mStopFlag)
                    {
                        this.mStopFlag = false;
                        break;
                    }
                    pFeature = cursor.NextFeature();
                }
                this.labelinfo.Text = string.Concat(new object[] { "    计算", this.m_UnderLayer.Name, "独有班块共计", this.tList2.Nodes.Count, "个" });
                if (this.tList2.Nodes.Count > 0)
                {
                    this.panel3.Visible = true;
                    this.simpleButtonInput.Visible = true;
                    this.simpleButtonSelAll.Visible = true;
                    this.simpleButton2.Visible = true;
                }
                else
                {
                    this.panel3.Visible = false;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialListID2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IMap focusMap = this.mHookHelper.FocusMap;
                  //  this.mDBAccess = UtilFactory.GetDBAccess("Access");
                    this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
                    this.mZTtable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_ZT_Overlap");
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                    this.m_CountyLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                    if (this.m_CountyLayer != null)
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                        this.m_TownLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                        if (this.m_TownLayer != null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                            this.m_VillageLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                            if (this.m_VillageLayer != null)
                            {
                                this.mFeatureWorkspace = EditTask.EditWorkspace;
                                if (this.mFeatureWorkspace != null)
                                {
                                    string name = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                                    this.m_CountyTable = this.mFeatureWorkspace.OpenTable(name);
                                    if (this.m_CountyTable != null)
                                    {
                                        name = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                                        this.m_TownTable = this.mFeatureWorkspace.OpenTable(name);
                                        if (this.m_TownTable != null)
                                        {
                                            name = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                                            this.m_VillageTable = this.mFeatureWorkspace.OpenTable(name);
                                            if (this.m_VillageTable != null)
                                            {
                                                this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                                                this.mCurItemImageEdit0.Images = this.imageList0;
                                                this.mCurItemImageEdit = this.repositoryItemImageEdit2;
                                                this.mCurItemImageEdit.Images = this.imageList2;
                                                this.mCurItemImageEdit2 = this.repositoryItemImageEdit3;
                                                this.mCurItemImageEdit2.Images = this.imageList6;
                                                this.mCurItemImageEdit22 = this.repositoryItemImageEdit33;
                                                this.mCurItemImageEdit22.Images = this.imageList3;
                                                this.mCurItemImageEdit4 = this.repositoryItemImageEdit4;
                                                this.mCurItemImageEdit4.Images = this.imageList0;
                                                this.mCurItemImageEdit5 = this.repositoryItemImageEdit5;
                                                this.mCurItemImageEdit5.Images = this.imageList7;
                                                this.mCurItemImageEdit6 = this.repositoryItemImageEdit6;
                                                this.mCurItemImageEdit6.Images = this.imageList0;
                                                this.mCurItemImageEdit7 = this.repositoryItemImageEdit7;
                                                this.mCurItemImageEdit7.Images = this.imageList7;
                                                this.mCurItemImageEdit8 = this.repositoryItemImageEdit8;
                                                this.mCurItemImageEdit8.Images = this.imageList0;
                                                this.mCurItemImageEdit9 = this.repositoryItemImageEdit9;
                                                this.mCurItemImageEdit9.Images = this.imageList9;
                                                this.InitialKindList(true);
                                                if (this.panelInfo.Visible)
                                                {
                                                    this.GetXBInfo();
                                                }
                                                this.splitterControl1.Visible = false;
                                                this.panel6.Dock = DockStyle.Top;
                                                this.panelIDList.Visible = false;
                                                this.simpleButtonOK.Enabled = false;
                                                this.panelLog.Visible = false;
                                                this.panelLog2.Visible = false;
                                                this.labelinfo.Text = "";
                                                this.label3.Text = "清空变更小班数据重新开始专题合并";
                                                if (this.mStateTable.Select("(taskname='造林' or taskname='采伐' or taskname='火灾' or taskname='征占用' or taskname='自然灾害' or taskname='林业案件') and (logiccheckstate='0' or toplogiccheckstate='0')").Length > 0)
                                                {
                                                    this.groupControlCombine.Visible = false;
                                                    this.groupControlCheck.Visible = true;
                                                    this.groupControlCheck.Dock = DockStyle.Fill;
                                                    this.groupControlCheck.BringToFront();
                                                    this.simpleButtonCheck.Enabled = false;
                                                    this.InitialListCheck(true);
                                                    this.labelChkprogress.Text = "";
                                                    this.richTextChk.Text = "";
                                                }
                                                else
                                                {
                                                    this.groupControlCheck.Visible = false;
                                                    this.simpleButtonCheck.Enabled = false;
                                                    this.groupControlCombine.Visible = true;
                                                    this.groupControlCombine.Dock = DockStyle.Fill;
                                                    this.groupControlCombine.BringToFront();
                                                }
                                                this.mSelected = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void labelXBInfo_DoubleClick(object sender, EventArgs e)
        {
        }

        private void listBoxDateEque_DoubleClick(object sender, EventArgs e)
        {
        }

        private void listBoxDateEque_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((this.mConflictList.Count != 0) && (this.listBoxDateEque.SelectedIndex != -1))
            {
                IFeature pFeature = this.mConflictList[this.listBoxDateEque.SelectedIndex] as IFeature;
                GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
            }
        }

        private void listBoxDateEque_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private bool ReadValue(IFeature pf, IFeature psf)
        {
            Exception exception;
            try
            {
                int num3;
                int num4;
                IFeature pObj = null;
                string sKindCode = EditTask.KindCode.Substring(2, 2);
                string node = GetNode(sKindCode);
                IList<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXFields").Split(new char[] { ',' }));
                IList<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXMatchFields").Split(new char[] { ',' }));
                IList<string> list3 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ZTImportFields").Split(new char[] { ',' }));
                IList<string> list4 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "SubImportFields").Split(new char[] { ',' }));
                if (this.mXBLayer == null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    this.mXBLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true);
                }
                if (this.mXBLayer != null)
                {
                    ISpatialFilter filter;
                    IGeometry geometry;
                    double num2;
                    try
                    {
                        filter = new SpatialFilterClass();
                        filter.Geometry = psf.ShapeCopy;
                        filter.GeometryField = this.mXBLayer.FeatureClass.ShapeFieldName;
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        IFeatureCursor cursor = this.mXBLayer.FeatureClass.Search(filter, false);
                        if (cursor == null)
                        {
                            goto Label_049A;
                        }
                        IFeature feature2 = cursor.NextFeature();
                        if (feature2 == null)
                        {
                            goto Label_049A;
                        }
                        ITopologicalOperator2 shapeCopy = psf.ShapeCopy as ITopologicalOperator2;
                        shapeCopy.IsKnownSimple_2 = false;
                        shapeCopy.Simplify();
                        double num = 0.0;
                        while (feature2 != null)
                        {
                            geometry = shapeCopy.Intersect(feature2.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                            if (geometry.IsEmpty)
                            {
                                feature2 = cursor.NextFeature();
                            }
                            else
                            {
                                IArea area = geometry as IArea;
                                num2 = area.Area;
                                if (num2 > num)
                                {
                                    num = num2;
                                    pObj = feature2;
                                }
                                feature2 = cursor.NextFeature();
                            }
                        }
                        GC.Collect();
                        cursor = null;
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "ReadValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    if (pObj == null)
                    {
                        GC.Collect();
                        filter = new SpatialFilterClass();
                        filter.Geometry = psf.Shape;
                        filter.GeometryField = this.mXBLayer.FeatureClass.ShapeFieldName;
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        IFeature feature3 = this.mXBLayer.FeatureClass.Search(filter, false).NextFeature();
                        num2 = 0.0;
                        if (feature3 != null)
                        {
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                            IFeatureCursor cursor2 = this.mXBLayer.FeatureClass.Search(filter, false);
                            feature3 = cursor2.NextFeature();
                            if (feature3 == null)
                            {
                                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                                cursor2 = this.mXBLayer.FeatureClass.Search(filter, false);
                                feature3 = cursor2.NextFeature();
                                if (feature3 == null)
                                {
                                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                                    cursor2 = this.mXBLayer.FeatureClass.Search(filter, false);
                                    feature3 = cursor2.NextFeature();
                                    if (feature3 == null)
                                    {
                                    }
                                }
                            }
                            while (feature3 != null)
                            {
                                IGeometry geometry2 = feature3.ShapeCopy;
                                IGeometry other = psf.ShapeCopy;
                                ITopologicalOperator2 operator2 = geometry2 as ITopologicalOperator2;
                                operator2.IsKnownSimple_2 = false;
                                operator2.Simplify();
                                geometry = operator2.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                                if (!geometry.IsEmpty)
                                {
                                    if (num2 == 0.0)
                                    {
                                        num2 = ((IArea) geometry).Area;
                                        pObj = feature3;
                                    }
                                    else if (num2 < ((IArea) geometry).Area)
                                    {
                                        num2 = ((IArea) geometry).Area;
                                        pObj = feature3;
                                    }
                                }
                                feature3 = cursor2.NextFeature();
                            }
                        }
                    }
                }
            Label_049A:
                num3 = 0;
                while (num3 < pf.Fields.FieldCount)
                {
                    IField field = pf.Fields.get_Field(num3);
                    if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                    {
                        object fieldValue;
                        string name = field.Name;
                        if (list4.Contains(name))
                        {
                            fieldValue = this.GetFieldValue(pObj, name);
                            this.UpdateField(pf, name, fieldValue);
                        }
                        else if (list3.Contains(name))
                        {
                            num4 = list.IndexOf(name);
                            if (num4 >= 0)
                            {
                                fieldValue = this.GetFieldValue(psf, list2[num4]);
                                this.UpdateField(pf, name, fieldValue);
                            }
                        }
                        else
                        {
                            num4 = list.IndexOf(name);
                            if (num4 >= 0)
                            {
                                fieldValue = this.GetFieldValue(psf, list2[num4]);
                                if ((fieldValue == null) || (fieldValue.ToString() == ""))
                                {
                                    fieldValue = this.GetFieldValue(pObj, name);
                                    this.UpdateField(pf, name, fieldValue);
                                }
                                else
                                {
                                    this.UpdateField(pf, name, fieldValue);
                                }
                            }
                            else
                            {
                                fieldValue = this.GetFieldValue(pObj, name);
                                this.UpdateField(pf, name, fieldValue);
                            }
                        }
                    }
                    num3++;
                }
                if (sKindCode != "01")
                {
                    IList<string> list5 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ClearFields").Split(new char[] { ',' }));
                    for (num3 = 0; num3 < list5.Count; num3++)
                    {
                        num4 = this.m_EditLayer.FeatureClass.FindField(list5[num3]);
                        if (num4 >= 0)
                        {
                            pf.set_Value(num4, DBNull.Value);
                        }
                    }
                }
                int index = pf.Fields.FindField("DT_SRC");
                if (index > -1)
                {
                    pf.set_Value(index, this.mKindCode);
                }
                if (pObj == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "ReadValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void repositoryItemImageEdit1_Click(object sender, EventArgs e)
        {
            if (this.mNode.Tag != null)
            {
                IFeature tag = this.mNode.Tag as IFeature;
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                IEnvelope envelope = tag.Shape.Envelope;
                envelope.Expand(1.2, 1.2, true);
                focusMap.FullExtent = envelope;
                focusMap.Refresh();
            }
        }

        private void repositoryItemImageEdit2_Click(object sender, EventArgs e)
        {
            if (this.mNode2.Tag != null)
            {
                IFeature tag = this.mNode.Tag as IFeature;
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                IEnvelope envelope = tag.Shape.Envelope;
                envelope.Expand(1.2, 1.2, true);
                focusMap.FullExtent = envelope;
                focusMap.Refresh();
            }
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.mHookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        private void SetAreaXJ(IFeature pFeature)
        {
            try
            {
                double pFieldValue = 0.0;
                pFieldValue = this.GetArea(this.mHookHelper.FocusMap.SpatialReference, pFeature.ShapeCopy);
                this.UpdateField(pFeature, "MIAN_JI", pFieldValue);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "SetAreaXJ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tList2.Nodes.Count; i++)
            {
                this.tList2.Nodes[i].Checked = !this.tList2.Nodes[i].Checked;
            }
        }

        private void simpleButtonAuto_Click(object sender, EventArgs e)
        {
            if (this.tList.Nodes.Count == 0)
            {
                MessageBox.Show("未搜索出相交班块", "专题合并", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            }
            else
            {
                this.DoAutoInput();
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.tList2.BringToFront();
            this.simpleButtonRefresh.Visible = false;
            this.simpleButtonStop.Visible = true;
            this.InitialListID2();
            this.simpleButtonRefresh.Visible = true;
            this.simpleButtonStop.Visible = false;
        }

        private void simpleButtonBack2_Click(object sender, EventArgs e)
        {
            this.panelLog2.Visible = false;
            this.tList.BringToFront();
            this.simpleButtonRefresh.Visible = false;
            this.simpleButtonStop.Visible = true;
            this.InitialListID();
            this.simpleButtonBack2.Visible = false;
            this.simpleButtonAuto.Visible = true;
            this.simpleButtonRefresh.Visible = true;
            this.simpleButtonStop.Visible = false;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.panelIDList.Visible = false;
            this.splitterControl1.Visible = false;
            this.tListKind.Height = 0xa6;
            this.simpleButtonOK.Visible = true;
            this.panel6.Dock = DockStyle.Top;
            this.simpleButtonCancel.Enabled = false;
            this.simpleButtonFinish.Visible = false;
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            this.DoCheckLayer(EditTask.UnderLayer);
            this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
            if (this.mStateTable.Select("(taskname='造林' or taskname='采伐' or taskname='火灾' or taskname='征占用' or taskname='自然灾害' or taskname='林业案件') and (logiccheckstate='0' or toplogiccheckstate='0')").Length > 0)
            {
                this.InitialListCheck(true);
            }
            else
            {
                MessageBox.Show("专题校验已通过，可进入专题合并。", "专题合并", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.groupControlCheck.Visible = false;
                this.groupControlCombine.Visible = true;
                this.groupControlCombine.Dock = DockStyle.Fill;
                this.groupControlCombine.BringToFront();
                this.label3.Text = "清空变更小班数据重新开始专题合并";
            }
        }

        private void simpleButtonCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tListKind2.Nodes.Count; i++)
            {
                if (this.tListKind2.Nodes[i].Tag is ArrayList)
                {
                    IFeatureLayer pLayer = (this.tListKind2.Nodes[i].Tag as ArrayList)[1] as IFeatureLayer;
                    this.DoCheckLayer(pLayer);
                }
            }
            this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
            if (this.mStateTable.Select("(taskname='造林' or taskname='采伐' or taskname='火灾' or taskname='征占用' or taskname='自然灾害' or taskname='林业案件') and (logiccheckstate='0' or toplogiccheckstate='0')").Length > 0)
            {
                this.InitialListCheck(true);
            }
            else
            {
                MessageBox.Show("专题校验已通过，可进入专题合并。", "专题合并", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.groupControlCheck.Visible = false;
                this.groupControlCombine.Visible = true;
                this.groupControlCombine.Dock = DockStyle.Fill;
                this.groupControlCombine.BringToFront();
                this.label3.Text = "清空变更小班数据重新开始专题合并";
            }
        }

        private void simpleButtonClearLayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除变更小班图层中所有班块?", "专题合并", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    IFeatureClass featureClass = this.m_EditLayer.FeatureClass;
                    IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (editWorkspace != null)
                    {
                        editWorkspace.StartEditing(false);
                        editWorkspace.StartEditOperation();
                        Application.DoEvents();
                        this.label3.Text = " 清除变更小班数据...";
                        this.label3.Refresh();
                        Application.DoEvents();
                        IDataset dataset = featureClass as IDataset;
                        dataset.Workspace.ExecuteSQL("delete from " + dataset.Name);
                        IFeatureCursor cursor = featureClass.Search(null, false);
                        for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            feature.Delete();
                            feature.Store();
                        }
                        try
                        {
                            editWorkspace.StopEditOperation();
                            editWorkspace.StopEditing(true);
                            editWorkspace.StartEditing(false);
                            editWorkspace.StartEditOperation();
                            this.label3.Text = "清除变更小班数据- 成功";
                        }
                        catch (Exception)
                        {
                            this.label3.Text = "清除变更小班数据- 失败";
                        }
                        try
                        {
                            editWorkspace.StopEditOperation();
                        }
                        catch (Exception)
                        {
                            editWorkspace.StopEditOperation();
                        }
                        editWorkspace.StopEditing(true);
                        this.mHookHelper.ActiveView.Refresh();
                    //    IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                        DataTable dataTable = null;
                        dataTable = null;// dBAccess.GetDataTable(dBAccess, "select * from T_EditTask  ORDER BY ID ASC");
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string str = "update T_EditTask set EditState='0' where ID= " + dataTable.Rows[i]["ID"].ToString();
                           // dBAccess.ExecuteScalar(str);
                            str = "update T_EditTask  set logiccheckstate='0' where ID= " + dataTable.Rows[i]["ID"].ToString();
                          //  dBAccess.ExecuteScalar(str);
                            str = "update T_EditTask  set toplogiccheckstate='0' where ID= " + dataTable.Rows[i]["ID"].ToString();
                           // dBAccess.ExecuteScalar(str);
                        }
                        string sCmdText = "DELETE * FROM T_Input_YGFeature";
                      //  dBAccess.ExecuteScalar(sCmdText);
                   //     this.mStateTable = this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
                        this.InitialKindList(true);
                        if (this.panelInfo.Visible)
                        {
                            this.GetXBInfo();
                        }
                        this.splitterControl1.Visible = false;
                        this.panel6.Dock = DockStyle.Top;
                        this.panelIDList.Visible = false;
                        this.simpleButtonOK.Enabled = false;
                        this.panelLog.Visible = false;
                        this.panelLog2.Visible = false;
                        this.labelinfo.Text = "";
                        if (this.mStateTable.Select("(taskname='造林' or taskname='采伐' or taskname='火灾' or taskname='征占用' or taskname='自然灾害' or taskname='林业案件') and (logiccheckstate='0' or toplogiccheckstate='0')").Length > 0)
                        {
                            this.groupControlCombine.Visible = false;
                            this.groupControlCheck.Visible = true;
                            this.groupControlCheck.Dock = DockStyle.Fill;
                            this.groupControlCheck.BringToFront();
                            this.simpleButtonCheck.Enabled = false;
                            this.InitialListCheck(true);
                            this.labelChkprogress.Text = "";
                            this.richTextChk.Text = "";
                        }
                        else
                        {
                            this.groupControlCheck.Visible = false;
                            this.simpleButtonCheck.Enabled = false;
                            this.groupControlCombine.Visible = true;
                            this.groupControlCombine.Dock = DockStyle.Fill;
                            this.groupControlCombine.BringToFront();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "simpleButtonClearLayer_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonFinish_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                IFeature feature;
                XtraTabControl control;
                if (this.xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    if (this.mNodeList != null)
                    {
                        this.GetFeatureList(this.mNodeList.TreeList);
                        if (this.mQueryList != null)
                        {
                            feature = null;
                            if ((this.mNodeList.Tag is ArrayList) && ((this.mNodeList.Tag as ArrayList).Count > 0))
                            {
                                feature = (this.mNodeList.Tag as ArrayList)[0] as IFeature;
                            }
                            this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, feature, null);
                            this.mDockPanel.Visibility = DockVisibility.Visible;
                            if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                            {
                                control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                                if (control != null)
                                {
                                    control.TabPages[1].PageVisible = true;
                                    control.TabPages[1].Text = this.m_EditLayer.Name;
                                    control.SelectedTabPage = control.TabPages[1];
                                }
                            }
                        }
                    }
                }
                else if ((this.xtraTabControl1.SelectedTabPageIndex == 1) && (this.mNodeList2 != null))
                {
                    this.GetFeatureList(this.mNodeList2.TreeList);
                    if (this.mQueryList != null)
                    {
                        feature = null;
                        if ((this.mNodeList2.Tag is ArrayList) && ((this.mNodeList2.Tag as ArrayList).Count > 0))
                        {
                            feature = (this.mNodeList2.Tag as ArrayList)[0] as IFeature;
                        }
                        this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_UnderLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, feature, null);
                        this.mDockPanel.Visibility = DockVisibility.Visible;
                        if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                        {
                            control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                            if (control != null)
                            {
                                control.TabPages[1].PageVisible = true;
                                control.TabPages[1].Text = this.m_UnderLayer.Name.Replace("专题", "");
                                control.SelectedTabPage = control.TabPages[1];
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "simpleButtonInfo_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonInput_Click(object sender, EventArgs e)
        {
            try
            {
                this.simpleButtonSelAll.Visible = false;
                this.simpleButton2.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (editWorkspace != null)
                {
                    this.DoInput2(editWorkspace, this.m_UnderLayer.FeatureClass, this.m_EditLayer.FeatureClass);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (this.mNode2 != null)
            {
                bool flag = false;
                if (EditTask.UnderLayer == null)
                {
                    if ((this.mEditKindCode != "CTZT") || (EditTask.KindCode != "0810"))
                    {
                        return;
                    }
                    flag = true;
                }
                this.panel6.Dock = DockStyle.Bottom;
                this.panelIDList.Visible = true;
                this.splitterControl1.Visible = true;
                this.tListKind.Height = 0xa6;
                this.simpleButtonInfo.Left = (this.xtraTabControl1.Left + this.xtraTabControl1.Width) - this.simpleButtonInfo.Width;
                this.simpleButtonRefresh.BringToFront();
                this.simpleButtonStop.BringToFront();
                this.simpleButtonRefresh.Left = (this.simpleButtonInfo.Left - this.simpleButtonRefresh.Width) - 4;
                this.simpleButtonStop.Left = (this.simpleButtonInfo.Left - this.simpleButtonStop.Width) - 4;
                this.simpleButtonOK.Enabled = false;
                if (this.mNode2 != null)
                {
                    this.mNode2.SetValue(1, "编辑");
                }
                if (!flag)
                {
                    this.xtraTabPage1.PageVisible = true;
                    this.xtraTabPage2.PageVisible = true;
                    this.xtraTabPage3.PageVisible = false;
                    this.simpleButtonInfo.Visible = true;
                    this.simpleButtonRefresh.Visible = false;
                    this.simpleButtonStop.Visible = true;
                    int num = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                    this.labelZTCount.Text = string.Concat(new object[] { this.labelZTCount.Text, " 共计", num, "个班块" });
                    this.labelZTCount.Tag = num;
                    if (num == 0)
                    {
                        this.xtraTabControl1.Enabled = false;
                        this.simpleButtonRefresh.Enabled = false;
                    }
                    else
                    {
                        this.xtraTabControl1.Enabled = true;
                        this.simpleButtonRefresh.Enabled = true;
                    }
                    this.tList.Nodes.Clear();
                    this.tList.Refresh();
                    this.tList2.Nodes.Clear();
                    this.tList2.Refresh();
                    this.tList3.Nodes.Clear();
                    this.tList3.Refresh();
                    this.simpleButtonRefresh.Visible = true;
                    this.simpleButtonStop.Visible = false;
                }
                else
                {
                    this.xtraTabPage1.PageVisible = false;
                    this.xtraTabPage2.PageVisible = false;
                    this.xtraTabPage3.PageVisible = true;
                    this.simpleButtonInfo.Visible = false;
                    this.simpleButtonZTOverlap.Visible = true;
                    this.labelprogress2.Text = "";
                    if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage3)
                    {
                        this.InitialListID0();
                    }
                }
                this.simpleButtonOK.Enabled = true;
                this.simpleButtonOK.Visible = false;
                this.simpleButtonCancel.Enabled = true;
                this.simpleButtonFinish.Enabled = true;
                this.simpleButtonFinish.Visible = true;
            }
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            this.simpleButtonStop.Visible = true;
            this.simpleButtonRefresh.Visible = false;
            this.simpleButtonCancel.Enabled = false;
            this.simpleButtonFinish.Enabled = false;
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage1)
            {
                this.InitialListID();
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage2)
            {
                this.InitialListID2();
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPage3)
            {
                this.InitialListID0();
            }
            this.simpleButtonCancel.Enabled = true;
            this.simpleButtonFinish.Enabled = true;
            this.simpleButtonStop.Visible = false;
            this.simpleButtonRefresh.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void simpleButtonSelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tList2.Nodes.Count; i++)
            {
                this.tList2.Nodes[i].Checked = true;
            }
        }

        private void simpleButtonStop_Click(object sender, EventArgs e)
        {
            this.mStopFlag = true;
        }

        private void simpleButtonZTOverlap_Click(object sender, EventArgs e)
        {
            try
            {
                int num2;
                this.labelprogress.Text = this.labelprogress.Text + "\n计算专题数据相交情况...";
                this.labelprogress.Visible = true;
                this.richTextBox.Visible = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                IList<IFeatureLayer> pLayerList = new List<IFeatureLayer>();
                for (num2 = 0; num2 < EditTask.UnderLayers.Count; num2++)
                {
                    IFeatureLayer item = EditTask.UnderLayers[num2] as IFeatureLayer;
                    if (!item.Name.Contains("遥感"))
                    {
                        pLayerList.Add(item);
                    }
                }
                this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask  ORDER BY ID ASC");
                for (num2 = 0; num2 < this.mStateTable.Rows.Count; num2++)
                {
                    string sCmdText = "update T_EditTask set EditState='0' where ID= " + this.mStateTable.Rows[num2]["ID"].ToString();
                  //  this.mDBAccess.ExecuteScalar(sCmdText);
                }
                Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.labelprogress2.Text = "计算专题数据相交情况...";
                UpdateSub.FindZTOverlap2(pLayerList);
                this.Cursor = Cursors.Default;
                this.labelprogress2.Text = "计算专题数据相交情况 - 完成";
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "simpleButtonZTOverlap_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "tListCol1")
                {
                    e.RepositoryItem = null;
                }
                else if (e.Column.Name == "tListCol2")
                {
                    e.RepositoryItem = this.mCurItemImageEdit6;
                }
                else if (e.Column.Name == "tListCol3")
                {
                    e.RepositoryItem = this.mCurItemImageEdit7;
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (e.Column != null)
            {
                this.columnlist = e.Column.AbsoluteIndex;
            }
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList = e.Node;
        }

        private void tList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((this.EditFlag && (this.tList.Columns.Count != 0)) && ((e.X + this.tList.LeftCoord) >= this.tList.Columns[0].Width))
                {
                    System.Drawing.Point p = new System.Drawing.Point();
                    p.X = 14 + e.X;
                    p.Y = ((((base.Parent.Parent.Parent.Parent.Top + base.Parent.Parent.Parent.Top) + base.Parent.Top) + 0x36) + this.tListKind.Height) + e.Y;
                    if (e.Button == MouseButtons.Right)
                    {
                        if (this.tList.Selection.Count >= 1)
                        {
                            this.PopupNode = this.tList.Selection[0].FirstNode;
                            this.popupMenu1.ShowPopup(p);
                        }
                        else
                        {
                            this.PopupNode = null;
                        }
                    }
                    if (this.columnlist == 1)
                    {
                        ArrayList tag = this.mNodeList.Tag as ArrayList;
                        for (int i = 0; i < tag.Count; i++)
                        {
                            IFeature pFeature = null;
                            if (tag[i] is IFeature)
                            {
                                pFeature = tag[i] as IFeature;
                                this.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                                (this.m_EditLayer as IFeatureSelection).Clear();
                                this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, pFeature);
                                return;
                            }
                        }
                    }
                    else if ((this.columnlist == 2) && (this.mNodeList != null))
                    {
                        this.GetFeatureList(this.mNodeList.TreeList);
                        if (this.mQueryList != null)
                        {
                            IFeature selFeature = null;
                            if ((this.mNodeList.Tag is ArrayList) && ((this.mNodeList.Tag as ArrayList).Count > 0))
                            {
                                selFeature = (this.mNodeList.Tag as ArrayList)[0] as IFeature;
                            }
                            this.mQueryResult2.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, selFeature, null);
                            this.mDockPanel.Visibility = DockVisibility.Visible;
                            if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                            {
                                XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                                if (control != null)
                                {
                                    control.TabPages[1].PageVisible = true;
                                    control.TabPages[1].Text = this.m_UnderLayer.Name.Replace("专题", "");
                                    ToolTipItem item = control.TabPages[1].SuperTip.Items[0] as ToolTipItem;
                                    item.Text = this.m_UnderLayer.Name + this.xtraTabPage1.Text + "属性信息";
                                    control.SelectedTabPage = control.TabPages[1];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "tList_MouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tList2_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListColumn15")
                {
                    e.RepositoryItem = this.mCurItemImageEdit8;
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tList2_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            try
            {
                this.columnlist2 = e.Column.AbsoluteIndex;
            }
            catch (Exception)
            {
            }
        }

        private void tList2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList2 = e.Node;
        }

        private void tList2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((this.EditFlag && (e.X >= this.tList2.Columns[0].Width)) && (this.columnlist2 == 4))
                {
                    IFeature tag = this.mNodeList2.Tag as IFeature;
                    this.ZoomToFeature(this.mHookHelper.FocusMap, tag);
                    GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, tag, 100L, false);
                }
            }
            catch (Exception)
            {
            }
        }

        private void tList3_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListCol2")
                {
                    e.RepositoryItem = this.mCurItemImageEdit9;
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tList3_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.columnlist3 = e.Column.AbsoluteIndex;
        }

        private void tList3_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList3 = e.Node;
        }

        private void tList3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void tList3_MouseUp(object sender, MouseEventArgs e)
        {
            if ((this.EditFlag && (e.X >= this.tList3.Columns[0].Width)) && (this.columnlist3 == 1))
            {
                IFeature pFeature = (this.mNodeList3.Tag as ArrayList)[0] as IFeature;
                GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                GISFunFactory.FlashFun.FlashFeature(this.mHookHelper.FocusMap, pFeature, 200L, false);
                (this.m_EditLayer as IFeatureSelection).Clear();
                this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, pFeature);
            }
        }

        private void tListDist_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn2")
            {
                e.RepositoryItem = this.mCurItemImageEdit0;
            }
        }

        private void tListKind_ColumnChanged(object sender, ColumnChangedEventArgs e)
        {
        }

        private void tListKind_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListColumn3")
                {
                    if (e.Node != this.mNode2)
                    {
                        if ((e.Node.ParentNode == this.mNode2) || (e.Node.ParentNode == null))
                        {
                            if (e.Node.GetDisplayText(5) == "可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit22;
                            }
                            else if (e.Node.GetDisplayText(5) == "不可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit2;
                            }
                            else
                            {
                                e.RepositoryItem = null;
                            }
                        }
                        else
                        {
                            e.RepositoryItem = null;
                        }
                        this.mSelected = false;
                        return;
                    }
                    if ((e.Node.Tag != null) && (e.Node.Tag is ArrayList))
                    {
                        if (this.mEditKindCode == "CTZT")
                        {
                            if (e.Node.GetDisplayText(5) == "可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit2;
                            }
                            else if (e.Node.GetDisplayText(5) == "不可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit22;
                            }
                        }
                        else if (e.Node.GetDisplayText(5) == "可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit22;
                        }
                        else if (e.Node.GetDisplayText(5) == "不可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit2;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn4")
                {
                    if (((e.Node.Tag != null) && ((e.Node == this.mNode2) || (e.Node.ParentNode == null))) && (e.Node.GetDisplayText(5) == "可见"))
                    {
                        if ((e.Node.Tag as ArrayList).Count > 3)
                        {
                            e.RepositoryItem = null;
                        }
                        else
                        {
                            e.RepositoryItem = this.mCurItemImageEdit4;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn5")
                {
                    if ((((e.Node.Tag != null) && (e.Node.Nodes.Count == 0)) && ((e.Node == this.mNode2) || (e.Node.ParentNode == null))) && (e.Node.GetDisplayText(5) == "可见"))
                    {
                        if ((e.Node.Tag as ArrayList).Count > 3)
                        {
                            e.RepositoryItem = null;
                        }
                        else
                        {
                            e.RepositoryItem = this.mCurItemImageEdit5;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tListKind_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tListKind_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.column = e.Column.AbsoluteIndex;
        }

        private void tListKind_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNode3 = e.Node;
        }

        private void tListKind_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num;
                if (!this.StartFlag && (this.tListKind.Selection.Count != 0))
                {
                    if (this.tListKind.Selection[0].ParentNode == null)
                    {
                        if (this.tListKind.Selection[0].Tag != null)
                        {
                            this.tListKind.Selection[0].SelectImageIndex = 0;
                            this.tListKind.Selection[0].ImageIndex = 0;
                            this.EditFlag = true;
                            this.StartFlag = false;
                            goto Label_00F3;
                        }
                    }
                    else
                    {
                        this.tListKind.Selection[0].SelectImageIndex = -1;
                        this.tListKind.Selection[0].ImageIndex = -1;
                    }
                }
                return;
            Label_00F3:
                this.mNode2 = this.tListKind.Selection[0];
                this.mNode2.ExpandAll();
                if (this.mNode2.Nodes.Count > 0)
                {
                    this.mNode3 = this.mNode2.Nodes[0];
                }
                else
                {
                    this.mNode3 = this.mNode2;
                }
                this.simpleButtonOK.Enabled = true;
                if (this.mNode2.Tag != null)
                {
                    EditTask.UnderLayer = null;
                    if ((this.mNode2.Tag as ArrayList).Count == 3)
                    {
                        if (this.mNode2.Tag is IFeatureLayer)
                        {
                            EditTask.UnderLayer = this.mNode2.Tag as IFeatureLayer;
                        }
                        else if (this.mNode2.Tag is ArrayList)
                        {
                            ArrayList tag = this.mNode2.Tag as ArrayList;
                            for (num = 0; num < tag.Count; num++)
                            {
                                if (tag[num] is IFeatureLayer)
                                {
                                    EditTask.UnderLayer = tag[num] as IFeatureLayer;
                                    this.m_UnderLayer = EditTask.UnderLayer;
                                }
                            }
                        }
                    }
                }
                this.mEditKindCode = "";
                EditTask.KindCode = "08";
                if (this.mNode3.GetDisplayText(0).Contains("造林"))
                {
                    this.mEditKindCode = "ZaoLin";
                    EditTask.KindCode = "0801";
                    this.mKindCode = "01";
                    this.labelZTCount.Text = "造林专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("采伐"))
                {
                    this.mEditKindCode = "CaiFa";
                    EditTask.KindCode = "0802";
                    this.mKindCode = "02";
                    this.labelZTCount.Text = "采伐专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("火灾"))
                {
                    this.mEditKindCode = "Fire";
                    EditTask.KindCode = "0803";
                    this.mKindCode = "03";
                    this.labelZTCount.Text = "火灾专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("征占用"))
                {
                    this.mEditKindCode = "ZZY";
                    EditTask.KindCode = "0804";
                    this.mKindCode = "04";
                    this.labelZTCount.Text = "征占用专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("自然灾害"))
                {
                    this.mEditKindCode = "ZRZH";
                    EditTask.KindCode = "0805";
                    this.mKindCode = "05";
                    this.labelZTCount.Text = "自然灾害专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("林业工程"))
                {
                    this.mEditKindCode = "LYGC";
                    EditTask.KindCode = "0806";
                }
                if (this.mNode3.GetDisplayText(0).Contains("林业案件"))
                {
                    this.mEditKindCode = "AnJian";
                    EditTask.KindCode = "0807";
                    this.mKindCode = "07";
                    this.labelZTCount.Text = "林业案件专题数据";
                }
                if (this.mNode3.GetDisplayText(0).Contains("自然因素"))
                {
                    this.mEditKindCode = "ZRYS";
                    EditTask.KindCode = "0808";
                }
                if (this.mNode3.GetDisplayText(0).Contains("调查因素"))
                {
                    this.mEditKindCode = "DCYS";
                    EditTask.KindCode = "0809";
                }
                if (this.mNode3.GetDisplayText(0).Contains("冲突专题数据"))
                {
                    this.mEditKindCode = "CTZT";
                    EditTask.KindCode = "0810";
                }
                EditTask.TaskName = this.mNode2.GetDisplayText(0);
                for (num = 0; num < this.tListKind.Nodes.Count; num++)
                {
                    if (!this.tListKind.Nodes[num].Equals(this.mNode2))
                    {
                        this.tListKind.Nodes[num].SelectImageIndex = -1;
                        this.tListKind.Nodes[num].ImageIndex = -1;
                    }
                }
                this.simpleButtonBack.Visible = false;
                this.panelLog.Visible = false;
                this.simpleButtonBack2.Visible = false;
                this.panelLog2.Visible = false;
                this.simpleButtonAuto.Visible = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "tListKind_MouseDoubleClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListKind_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditFlag && (e.X >= this.tListKind.Columns[0].Width))
                {
                    ArrayList tag;
                    if (this.column == 1)
                    {
                        if ((((this.mNode2 != null) && (this.mNode2 == this.mNode3)) && (this.mNode3.Nodes.Count == 0)) && ((this.mNode3.Tag as ArrayList).Count < 3))
                        {
                            FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                            data.ShowDialog(this);
                            if (data.LayerList != null)
                            {
                                tag = this.mNode3.Tag as ArrayList;
                                if (data.LayerList.Count > 0)
                                {
                                    if (tag.Count == 1)
                                    {
                                        tag.Add(data.LayerList[0]);
                                    }
                                    else
                                    {
                                        tag[1] = data.LayerList[0];
                                    }
                                    this.mNode3.SetValue(3, "不可见");
                                }
                            }
                            if (this.mNode2.Tag == null)
                            {
                            }
                        }
                    }
                    else
                    {
                        int num;
                        IFeatureLayer layer2;
                        if (this.column == 2)
                        {
                            if (this.mNode2 != null)
                            {
                                tag = this.mNode2.Tag as ArrayList;
                                string str = "";
                                if (this.mNode2.Tag != null)
                                {
                                    if (tag != null)
                                    {
                                        str = tag[0].ToString();
                                    }
                                    else
                                    {
                                        str = this.mNode2.Tag.ToString();
                                    }
                                }
                                if (this.mNode3 != null)
                                {
                                    tag = this.mNode3.Tag as ArrayList;
                                }
                                if (tag != null)
                                {
                                    IFeatureClass featureClass;
                                    ILayer layer3;
                                    string str2 = "XB";
                                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "GroupName");
                                    IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                                    if (this.mNode3.GetDisplayText(5) == "不可见")
                                    {
                                        for (num = 0; num < tag.Count; num++)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer2 = tag[num] as IFeatureLayer;
                                                layer3 = tag[num] as ILayer;
                                                if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, layer3.Name, true) == null)
                                                {
                                                    pGroupLayer.Add(layer3);
                                                }
                                                layer3.Visible = true;
                                            }
                                            else if (tag[num] is IFeatureClass)
                                            {
                                            }
                                        }
                                        pGroupLayer.Visible = true;
                                        this.mHookHelper.ActiveView.Refresh();
                                        this.mNode3.SetValue(5, "可见");
                                    }
                                    else
                                    {
                                        num = 0;
                                        while (num < tag.Count)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer3 = tag[num] as ILayer;
                                                layer3.Visible = false;
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            else if (tag[num] is IFeatureClass)
                                            {
                                                featureClass = tag[num] as IFeatureClass;
                                                layer3 = null;
                                                ICompositeLayer layer5 = pGroupLayer as ICompositeLayer;
                                                for (int i = 0; i < layer5.Count; i++)
                                                {
                                                    layer3 = layer5.get_Layer(i);
                                                    layer2 = layer3 as IFeatureLayer;
                                                    if (layer2.FeatureClass.Equals(featureClass))
                                                    {
                                                        layer3.Visible = false;
                                                    }
                                                }
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            num++;
                                        }
                                        this.mNode3.SetValue(5, "不可见");
                                    }
                                }
                            }
                        }
                        else if (this.column == 3)
                        {
                            tag = this.mNode3.Tag as ArrayList;
                            for (num = 0; num < tag.Count; num++)
                            {
                                IEnvelope areaOfInterest;
                                IFeatureClass class3 = null;
                                layer2 = null;
                                if (tag[num] is IFeatureLayer)
                                {
                                    layer2 = tag[num] as IFeatureLayer;
                                    areaOfInterest = layer2.AreaOfInterest;
                                    areaOfInterest.Expand(1.25, 1.25, true);
                                    this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                    this.mHookHelper.ActiveView.Refresh();
                                    return;
                                }
                                if (tag[num] is IFeatureClass)
                                {
                                    class3 = tag[num] as IFeatureClass;
                                    areaOfInterest = (class3 as IGeoDataset).Extent;
                                    if (!areaOfInterest.IsEmpty)
                                    {
                                        areaOfInterest.Expand(1.25, 1.25, true);
                                        this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                        this.mHookHelper.ActiveView.Refresh();
                                    }
                                    return;
                                }
                            }
                        }
                        else if (((this.column == 4) && (this.mNode3 == this.mNode2)) && (this.m_UnderLayer != null))
                        {
                            this.GetFeatureList(this.mNode2.Tag);
                            if (this.mQueryList != null)
                            {
                                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, null, null);
                                this.mDockPanel.Visibility = DockVisibility.Visible;
                                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                                {
                                    XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                                    if (control != null)
                                    {
                                        control.TabPages[0].PageVisible = true;
                                        control.TabPages[0].Text = this.m_UnderLayer.Name.Replace("专题", "");
                                        ToolTipItem item = control.TabPages[0].SuperTip.Items[0] as ToolTipItem;
                                        item.Text = this.m_UnderLayer.Name + "属性信息";
                                        control.SelectedTabPage = control.TabPages[0];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void tListKind_Resize(object sender, EventArgs e)
        {
            try
            {
                this.tListKind.Columns[0].Width = this.tListKind.Width - 0x76;
                this.tListKind.Columns[1].Width = 0x18;
                this.tListKind.Columns[2].Width = 0x16;
                this.tListKind.Columns[4].Width = 0x16;
                this.tListKind.Columns[5].Width = 0x16;
            }
            catch (Exception)
            {
            }
        }

        private void tListKind2_ColumnChanged(object sender, ColumnChangedEventArgs e)
        {
        }

        private void tListKind2_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (this.EditFlag && !this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListColumn3")
                {
                    if (e.Node != this.mNode2)
                    {
                        if ((e.Node.ParentNode == this.mNode2) || (e.Node.ParentNode == null))
                        {
                            if (e.Node.GetDisplayText(5) == "可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit22;
                            }
                            else if (e.Node.GetDisplayText(5) == "不可见")
                            {
                                e.RepositoryItem = this.mCurItemImageEdit2;
                            }
                            else
                            {
                                e.RepositoryItem = null;
                            }
                        }
                        else
                        {
                            e.RepositoryItem = null;
                        }
                        this.mSelected = false;
                        return;
                    }
                    if ((e.Node.Tag != null) && (e.Node.Tag is ArrayList))
                    {
                        if (e.Node.GetDisplayText(5) == "可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit22;
                        }
                        else if (e.Node.GetDisplayText(5) == "不可见")
                        {
                            e.RepositoryItem = this.mCurItemImageEdit2;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn4")
                {
                    if (((e.Node.Tag != null) && ((e.Node == this.mNode2) || (e.Node.ParentNode == null))) && (e.Node.GetDisplayText(5) == "可见"))
                    {
                        if ((e.Node.Tag as ArrayList).Count > 3)
                        {
                            e.RepositoryItem = null;
                        }
                        else
                        {
                            e.RepositoryItem = this.mCurItemImageEdit4;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else if (e.Column.Name == "treeListColumn5")
                {
                    if ((((e.Node.Tag != null) && (e.Node.Nodes.Count == 0)) && ((e.Node == this.mNode2) || (e.Node.ParentNode == null))) && (e.Node.GetDisplayText(5) == "可见"))
                    {
                        if ((e.Node.Tag as ArrayList).Count > 3)
                        {
                            e.RepositoryItem = null;
                        }
                        else
                        {
                            e.RepositoryItem = this.mCurItemImageEdit5;
                        }
                    }
                    else
                    {
                        e.RepositoryItem = null;
                    }
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tListKind2_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tListKind2_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.checkcolumn = e.Column.AbsoluteIndex;
        }

        private void tListKind2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mCheckNode = e.Node;
        }

        private void tListKind2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int num;
                if (this.tListKind2.Selection.Count != 0)
                {
                    if (this.tListKind2.Selection[0].ParentNode == null)
                    {
                        if (this.tListKind2.Selection[0].Tag != null)
                        {
                            this.tListKind2.Selection[0].SelectImageIndex = 0;
                            this.tListKind2.Selection[0].ImageIndex = 0;
                            this.simpleButtonCheck.Enabled = true;
                            goto Label_00E0;
                        }
                    }
                    else
                    {
                        this.tListKind2.Selection[0].SelectImageIndex = -1;
                        this.tListKind2.Selection[0].ImageIndex = -1;
                    }
                }
                return;
            Label_00E0:
                this.mCheckNode = this.tListKind2.Selection[0];
                this.mCheckNode.ExpandAll();
                if (this.mCheckNode.Nodes.Count > 0)
                {
                    this.mCheckNode2 = this.mCheckNode.Nodes[0];
                }
                else
                {
                    this.mCheckNode2 = this.mCheckNode;
                }
                if (this.mCheckNode.Tag != null)
                {
                    EditTask.UnderLayer = null;
                    if ((this.mCheckNode.Tag as ArrayList).Count == 3)
                    {
                        if (this.mCheckNode.Tag is IFeatureLayer)
                        {
                            EditTask.UnderLayer = this.mCheckNode.Tag as IFeatureLayer;
                        }
                        else if (this.mCheckNode.Tag is ArrayList)
                        {
                            ArrayList tag = this.mCheckNode.Tag as ArrayList;
                            for (num = 0; num < tag.Count; num++)
                            {
                                if (tag[num] is IFeatureLayer)
                                {
                                    EditTask.UnderLayer = tag[num] as IFeatureLayer;
                                    this.m_UnderLayer = EditTask.UnderLayer;
                                    this.simpleButtonCheck.Enabled = true;
                                }
                            }
                        }
                    }
                }
                for (num = 0; num < this.tListKind2.Nodes.Count; num++)
                {
                    if (!this.tListKind2.Nodes[num].Equals(this.mCheckNode))
                    {
                        this.tListKind2.Nodes[num].SelectImageIndex = -1;
                        this.tListKind2.Nodes[num].ImageIndex = -1;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "tListKind2_MouseDoubleClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void tListKind2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditFlag && (e.X >= this.tListKind2.Columns[0].Width))
                {
                    ArrayList tag;
                    if (this.column == 1)
                    {
                        if ((((this.mNode2 != null) && (this.mNode2 == this.mNode3)) && (this.mNode3.Nodes.Count == 0)) && ((this.mNode3.Tag as ArrayList).Count < 3))
                        {
                            FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                            data.ShowDialog(this);
                            if (data.LayerList != null)
                            {
                                tag = this.mNode3.Tag as ArrayList;
                                if (data.LayerList.Count > 0)
                                {
                                    if (tag.Count == 1)
                                    {
                                        tag.Add(data.LayerList[0]);
                                    }
                                    else
                                    {
                                        tag[1] = data.LayerList[0];
                                    }
                                    this.mNode3.SetValue(3, "不可见");
                                }
                            }
                            if (this.mNode2.Tag == null)
                            {
                            }
                        }
                    }
                    else
                    {
                        int num;
                        IFeatureLayer layer2;
                        if (this.column == 2)
                        {
                            if (this.mNode2 != null)
                            {
                                tag = this.mNode2.Tag as ArrayList;
                                string str = "";
                                if (this.mNode2.Tag != null)
                                {
                                    if (tag != null)
                                    {
                                        str = tag[0].ToString();
                                    }
                                    else
                                    {
                                        str = this.mNode2.Tag.ToString();
                                    }
                                }
                                if (this.mNode3 != null)
                                {
                                    tag = this.mNode3.Tag as ArrayList;
                                }
                                if (tag != null)
                                {
                                    IFeatureClass featureClass;
                                    ILayer layer3;
                                    string str2 = "XB";
                                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "GroupName");
                                    IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                                    if (this.mNode3.GetDisplayText(5) == "不可见")
                                    {
                                        for (num = 0; num < tag.Count; num++)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer2 = tag[num] as IFeatureLayer;
                                                layer3 = tag[num] as ILayer;
                                                if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, layer3.Name, true) == null)
                                                {
                                                    pGroupLayer.Add(layer3);
                                                }
                                                layer3.Visible = true;
                                            }
                                            else if (tag[num] is IFeatureClass)
                                            {
                                            }
                                        }
                                        pGroupLayer.Visible = true;
                                        this.mHookHelper.ActiveView.Refresh();
                                        this.mNode3.SetValue(5, "可见");
                                    }
                                    else
                                    {
                                        num = 0;
                                        while (num < tag.Count)
                                        {
                                            if (tag[num] is IFeatureLayer)
                                            {
                                                featureClass = (tag[num] as IFeatureLayer).FeatureClass;
                                                layer3 = tag[num] as ILayer;
                                                layer3.Visible = false;
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            else if (tag[num] is IFeatureClass)
                                            {
                                                featureClass = tag[num] as IFeatureClass;
                                                layer3 = null;
                                                ICompositeLayer layer5 = pGroupLayer as ICompositeLayer;
                                                for (int i = 0; i < layer5.Count; i++)
                                                {
                                                    layer3 = layer5.get_Layer(i);
                                                    layer2 = layer3 as IFeatureLayer;
                                                    if (layer2.FeatureClass.Equals(featureClass))
                                                    {
                                                        layer3.Visible = false;
                                                    }
                                                }
                                                this.mHookHelper.ActiveView.Refresh();
                                            }
                                            num++;
                                        }
                                        this.mNode3.SetValue(5, "不可见");
                                    }
                                }
                            }
                        }
                        else if (this.column == 3)
                        {
                            tag = this.mNode3.Tag as ArrayList;
                            for (num = 0; num < tag.Count; num++)
                            {
                                IEnvelope areaOfInterest;
                                IFeatureClass class3 = null;
                                layer2 = null;
                                if (tag[num] is IFeatureLayer)
                                {
                                    layer2 = tag[num] as IFeatureLayer;
                                    areaOfInterest = layer2.AreaOfInterest;
                                    areaOfInterest.Expand(1.25, 1.25, true);
                                    this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                    this.mHookHelper.ActiveView.Refresh();
                                    return;
                                }
                                if (tag[num] is IFeatureClass)
                                {
                                    class3 = tag[num] as IFeatureClass;
                                    areaOfInterest = (class3 as IGeoDataset).Extent;
                                    if (!areaOfInterest.IsEmpty)
                                    {
                                        areaOfInterest.Expand(1.25, 1.25, true);
                                        this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                                        this.mHookHelper.ActiveView.Refresh();
                                    }
                                    return;
                                }
                            }
                        }
                        else if (((this.column == 4) && (this.mNode3 == this.mNode2)) && (this.m_UnderLayer != null))
                        {
                            this.GetFeatureList(this.mNode2.Tag);
                            if (this.mQueryList != null)
                            {
                                this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, null, null);
                                this.mDockPanel.Visibility = DockVisibility.Visible;
                                if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                                {
                                    XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                                    if (control != null)
                                    {
                                        control.TabPages[0].PageVisible = true;
                                        control.TabPages[0].Text = this.m_UnderLayer.Name.Replace("专题", "");
                                        ToolTipItem item = control.TabPages[0].SuperTip.Items[0] as ToolTipItem;
                                        item.Text = this.m_UnderLayer.Name + "属性信息";
                                        control.SelectedTabPage = control.TabPages[0];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void tListKind2_Resize(object sender, EventArgs e)
        {
            try
            {
                this.tListKind2.Columns[0].Width = 140;
                this.tListKind2.Columns[1].Width = 130;
                this.tListKind2.Columns[2].Width = 0;
                this.tListKind2.Columns[4].Width = 0;
                this.tListKind2.Columns[5].Width = 0;
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

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void ZoomToFeature(IMap pMap, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shapeCopy = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.SpatialReference != this.mHookHelper.FocusMap.SpatialReference)
                    {
                        shapeCopy.Project(this.mHookHelper.FocusMap.SpatialReference);
                        shapeCopy.SpatialReference = this.mHookHelper.FocusMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shapeCopy.Envelope;
                    view = pMap as IActiveView;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shapeCopy as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.FullExtent = envelope;
                        view.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet2", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

