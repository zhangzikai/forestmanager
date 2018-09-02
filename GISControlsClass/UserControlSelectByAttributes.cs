namespace GISControlsClass
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FormBase;
    using ProxyButton;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;
    using System.Data.SqlClient;
    using System.Data;
using ConSQLServerInfo;


    public class UserControlSelectByAttributes : UserControlBase1
    {
        public SimpleButton btnAnd;
        private SimpleButton btnApply;
        public SimpleButton btnBracket;
        private SimpleButton btnClear;
        private SimpleButton btnClose;
        public SimpleButton btnEqual;
        public SimpleButton btnGreat;
        public SimpleButton btnGreatEqual;
        public SimpleButton btnIs;
        public SimpleButton btnLike;
        public SimpleButton btnLittle;
        public SimpleButton btnLittleEqual;
        public SimpleButton btnMatchOneChar;
        public SimpleButton btnMatchString;
        public SimpleButton btnNot;
        public SimpleButton btnNotEqual;
        public SimpleButton btnOr;
        private SimpleButton btnValidate;
        private SimpleButton btnZoom;
        private CheckEdit checkQuery;
        private IContainer components;
        private GridColumn gridColumn2;
        private GridControl gridControl1;
        private GridView gridView1;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private ImageList imageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelInfo;
        private Label labelLocation;
        private ListBoxControl listBoxFields;
        private ListBoxControl listBoxUniqueValues;
        private ILayer m_SelLayer = null;
        private string m_strWhereCaluse = "";
        private const string mClassName = "QueryAnalysic.UserControlSelectByAttributes";
        private MemoEdit memEditWhereCaluse;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mGroupList;
        private HookHelper mHookHelper;
        private ArrayList mLayerList;
        private ArrayList mSelLayerList;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private GridColumn OID;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        internal Panel PanelButton;
        private PopupContainerEdit popEditLayer;
        private PopupContainerControl popupContainerControl1;
        private SimpleButton simpleButtonGetUniqueValues;
        private SimpleButton simpleButtonSelectAll;
        private SimpleButton simpleButtonSelectClear;
        private TextEdit textEdit1;
        private TreeListColumn treeListColumn1;
        private TreeList treeListLayer;

        public UserControlSelectByAttributes()
        {
            this.InitializeComponent();
            this.popEditLayer.ButtonClick += new ButtonPressedEventHandler(this.popEditLayer_ButtonClick);
            this.treeListLayer.MouseUp += new MouseEventHandler(this.treeListLayer_MouseUp);
            this.treeListLayer.MouseDoubleClick += new MouseEventHandler(this.treeListLayer_MouseDoubleClick);
            this.listBoxFields.DoubleClick += new EventHandler(this.listBoxFields_DoubleClick);
            this.listBoxFields.SelectedIndexChanged += new EventHandler(this.listBoxFields_SelectedIndexChanged);
            this.listBoxUniqueValues.DoubleClick += new EventHandler(this.listBoxUniqueValues_DoubleClick);
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            string str = "AND";
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + str + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + str.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.btnZoom.Visible = false;
            if (this.memEditWhereCaluse.Text.Trim() != "")
            {
                this.DoApply();
            }
            else
            {
                MessageBox.Show("请输入查询条件", "要素选择", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnBracket_Click(object sender, EventArgs e)
        {
            string text = this.btnBracket.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, text);
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 1;
            this.labelInfo.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.memEditWhereCaluse.Text = "";
            this.labelInfo.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string text = this.btnEqual.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnGetUniqueValue_Click(object sender, EventArgs e)
        {
            if (this.listBoxFields.SelectedItem != null)
            {
                this.listBoxUniqueValues.Enabled = true;
                this.listBoxFields.SelectedItem.ToString();
                var items = this.listBoxUniqueValues.Items;
                items.Clear();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from t_sys_meta_code where cdomain ='" + this.listBoxFields.SelectedItem.ToString().Substring(0, this.listBoxFields.SelectedItem.ToString().IndexOf("[")) + "'", ConnectionSQLServerString.Get_M_Str_ConnectionString());
                da.Fill(dt);
                ArrayList al = new ArrayList();
                foreach (DataRow dr in dt.Rows) {
                    al.Add(dr["ccode"]);
                    items.Add(dr["cname"]);
                }
                this.listBoxUniqueValues.Tag = al;
                //this.GetUniqueValues(this.m_SelLayer, this.listBoxFields.SelectedItem.ToString(), this.listBoxUniqueValues.Items);
            }
        }

        private void btnGreat_Click(object sender, EventArgs e)
        {
            string text = this.btnGreat.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnGreatEqual_Click(object sender, EventArgs e)
        {
            string text = this.btnGreatEqual.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnIs_Click(object sender, EventArgs e)
        {
            string str = "IS";
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + str + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + str.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            string str = "LIKE";
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + str + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + str.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnLittle_Click(object sender, EventArgs e)
        {
            string text = this.btnLittle.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnLittleEqual_Click(object sender, EventArgs e)
        {
            string text = this.btnLittleEqual.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnMatchOneChar_Click(object sender, EventArgs e)
        {
            string text = this.btnMatchOneChar.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, text);
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 1;
            this.labelInfo.Text = "";
        }

        private void btnMatchString_Click(object sender, EventArgs e)
        {
            string text = this.btnMatchString.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, text);
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 1;
            this.labelInfo.Text = "";
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            string str = "NOT";
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + str + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + str.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnNotEqual_Click(object sender, EventArgs e)
        {
            string text = this.btnNotEqual.Text;
            string str2 = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = str2.Insert(selectionStart, " " + text + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + text.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            string str = "OR";
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + str + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + str.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            ICommand command = (ICommand)new FeatureSelectionZoomToSelectedCommand();
            command.OnCreate(this.mHookHelper.Hook);
            command.OnClick();
        }

        private void checkQuery_CheckedChanged(object sender, EventArgs e)
        {
        }

        public string ConvertFieldValueToString(esriFieldType type, object pValue)
        {
            switch (type)
            {
                case esriFieldType.esriFieldTypeInteger:
                case esriFieldType.esriFieldTypeSingle:
                case esriFieldType.esriFieldTypeDouble:
                case esriFieldType.esriFieldTypeOID:
                    return pValue.ToString();

                case esriFieldType.esriFieldTypeString:
                    return ("'" + pValue.ToString() + "'");

                case esriFieldType.esriFieldTypeDate:
                    return pValue.ToString();

                case esriFieldType.esriFieldTypeGeometry:
                    return "几何数据";

                case esriFieldType.esriFieldTypeBlob:
                    return "长二进制串";
            }
            return "";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DoApply()
        {
            try
            {
                IAttributeTable selLayer = this.m_SelLayer as IAttributeTable;
                if (selLayer != null)
                {
                    ITable attributeTable = selLayer.AttributeTable;
                    IFeatureSelection selection = null;
                    selection = (this.m_SelLayer as IFeatureLayer) as IFeatureSelection;
                    selection.Clear();
                    IFeatureLayerDefinition definition = (IFeatureLayerDefinition) this.m_SelLayer;
                    string definitionExpression = definition.DefinitionExpression;
                    IFeatureClass featureClass = (this.m_SelLayer as IFeatureLayer).FeatureClass;
                    IDataset dataset = (IDataset) featureClass;
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = this.memEditWhereCaluse.Text;
                    if (definitionExpression != "")
                    {
                        queryFilter.WhereClause = this.memEditWhereCaluse.Text + " and (" + definitionExpression + ")";
                    }
                    try
                    {
                        if (attributeTable.RowCount(queryFilter) > 0)
                        {
                            ISelectionSet set = featureClass.Select(queryFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, dataset.Workspace);
                            selection.SelectionSet = set;
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                            this.labelInfo.Text = "有" + set.Count + "个要素被选中";
                            this.btnZoom.Visible = true;
                        }
                        else
                        {
                            this.labelInfo.Text = "没有符合条件的要素可以选中";
                            this.btnZoom.Visible = false;
                        }
                    }
                    catch (Exception)
                    {
                        this.labelInfo.Text = "语法错误，请重新输入查询条件。";
                        this.btnZoom.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "DoApply", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool GetLayerColn()
        {
            try
            {
                if (this.mHookHelper == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap.LayerCount == 0)
                {
                    return false;
                }
                IEnumLayer layer = null;
                try
                {
                    layer = this.mHookHelper.FocusMap.get_Layers(null, false);
                }
                catch (Exception)
                {
                    return false;
                }
                layer.Reset();
                ICompositeLayer layer2 = null;
                IGroupLayer layer3 = null;
                ILayer layer4 = null;
                layer4 = layer.Next();
                if (layer4 == null)
                {
                    return false;
                }
                this.mSelLayerList = new ArrayList();
                this.mLayerList = new ArrayList();
                this.mGroupList = new ArrayList();
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                this.treeListLayer.ClearNodes();
                while (layer4 != null)
                {
                    if (layer4 is IGroupLayer)
                    {
                        layer3 = layer4 as IGroupLayer;
                        layer2 = layer3 as ICompositeLayer;
                        this.mGroupList.Add(layer3);
                        node3 = this.treeListLayer.AppendNode(layer4.Name, node4);
                        node3.SetValue(0, layer4.Name);
                        node3.Tag = layer3;
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = 0;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                        for (int i = 0; i < layer2.Count; i++)
                        {
                            ILayer layer5 = layer2.get_Layer(i);
                            if (layer5 is IGroupLayer)
                            {
                                ICompositeLayer layer6 = null;
                                IGroupLayer layer7 = null;
                                layer7 = layer5 as IGroupLayer;
                                layer6 = layer7 as ICompositeLayer;
                                parentNode = this.treeListLayer.AppendNode(layer7.Name, node3);
                                parentNode.SetValue(0, layer7.Name);
                                parentNode.Tag = layer7;
                                parentNode.ImageIndex = -1;
                                node3.StateImageIndex = 0;
                                node3.SelectImageIndex = -1;
                                parentNode.ExpandAll();
                                for (int j = 0; j < layer6.Count; j++)
                                {
                                    ILayer layer8 = layer6.get_Layer(j);
                                    if ((!(layer8 is IGroupLayer) && (layer8 is IFeatureLayer)) && ((layer8 as IFeatureLayer).FeatureClass != null))
                                    {
                                        node = this.treeListLayer.AppendNode(layer8.Name, parentNode);
                                        node.SetValue(0, layer8.Name);
                                        node.Tag = layer8 as IFeatureLayer;
                                        int num3 = 0;
                                        if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                        {
                                            num3 = 1;
                                        }
                                        else if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                        {
                                            num3 = 2;
                                        }
                                        else if ((layer8 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                        {
                                            num3 = 3;
                                        }
                                        node.ImageIndex = -1;
                                        node.StateImageIndex = num3;
                                        node.SelectImageIndex = -1;
                                        node.ExpandAll();
                                        this.mLayerList.Add(layer8);
                                        if ((layer8.Valid && layer8.Visible) && (layer8 as IFeatureLayer).Selectable)
                                        {
                                            this.mSelLayerList.Add(layer8);
                                        }
                                    }
                                }
                                if (parentNode.Nodes.Count == 0)
                                {
                                    this.treeListLayer.DeleteNode(parentNode);
                                }
                            }
                            else if ((layer5 is IFeatureLayer) && ((layer5 as IFeatureLayer).FeatureClass != null))
                            {
                                parentNode = this.treeListLayer.AppendNode(layer5.Name, node3);
                                parentNode.SetValue(0, layer5.Name);
                                parentNode.Tag = layer5 as IFeatureLayer;
                                int num4 = 0;
                                if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                                {
                                    num4 = 1;
                                }
                                else if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                                {
                                    num4 = 2;
                                }
                                else if ((layer5 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                                {
                                    num4 = 3;
                                }
                                parentNode.ImageIndex = -1;
                                parentNode.StateImageIndex = num4;
                                parentNode.SelectImageIndex = -1;
                                parentNode.ExpandAll();
                                this.mLayerList.Add(layer4);
                                if ((layer5.Valid && layer5.Visible) && (layer5 as IFeatureLayer).Selectable)
                                {
                                    this.mSelLayerList.Add(layer5);
                                }
                            }
                        }
                        if (node3.Nodes.Count == 0)
                        {
                            this.treeListLayer.DeleteNode(node3);
                        }
                    }
                    else if ((layer4 is IFeatureLayer) && ((layer4 as IFeatureLayer).FeatureClass != null))
                    {
                        node3 = this.treeListLayer.AppendNode(layer4.Name, node4);
                        node3.SetValue(0, layer4.Name);
                        node3.Tag = layer4;
                        int num5 = 0;
                        if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                        {
                            num5 = 1;
                        }
                        else if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                        {
                            num5 = 2;
                        }
                        else if ((layer4 as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                        {
                            num5 = 3;
                        }
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = num5;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                        this.mLayerList.Add(layer4);
                        if ((layer4.Valid && layer4.Visible) && (layer4 as IFeatureLayer).Selectable)
                        {
                            this.mSelLayerList.Add(layer4);
                        }
                    }
                    layer4 = layer.Next();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "GetLayerColn", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool GetLayerColn2()
        {
            try
            {
                if (this.mHookHelper == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap == null)
                {
                    return false;
                }
                if (this.mHookHelper.FocusMap.LayerCount == 0)
                {
                    return false;
                }
                IEnumLayer layer = null;
                try
                {
                    layer = this.mHookHelper.FocusMap.get_Layers(null, false);
                }
                catch (Exception)
                {
                    return false;
                }
                layer.Reset();
                ILayer pLayer = layer.Next();
                if (pLayer == null)
                {
                    return false;
                }
                this.mSelLayerList = new ArrayList();
                this.mLayerList = new ArrayList();
                this.mGroupList = new ArrayList();
                TreeListNode parentnode = null;
                this.treeListLayer.ClearNodes();
                while (pLayer != null)
                {
                    if (pLayer is IGroupLayer)
                    {
                        this.SetGroupLayer(pLayer, this.mGroupList, parentnode);
                    }
                    else if (pLayer is IFeatureLayer)
                    {
                        this.SetFeatureLayer(pLayer, this.mLayerList, parentnode);
                    }
                    pLayer = layer.Next();
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "GetLayerColn2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public void GetUniqueValues(ILayer pLayer, string sFieldName, ListBoxItemCollection Items)
        {
            try
            {
                Items.Clear();
                sFieldName = sFieldName.Split(new char[] { '[' })[0];
                ArrayList list = new ArrayList();
                IAttributeTable table = pLayer as IAttributeTable;
                if (table != null)
                {
                    string str;
                    ITable attributeTable = table.AttributeTable;
                    if ((sFieldName[0] == '\'') || (sFieldName[0] == '['))
                    {
                        str = sFieldName.Substring(1, sFieldName.Length - 2);
                    }
                    else
                    {
                        str = sFieldName;
                    }
                    IFeatureLayerDefinition definition = (IFeatureLayerDefinition) pLayer;
                    string definitionExpression = definition.DefinitionExpression;
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = definitionExpression;
                    IQueryFilterDefinition definition2 = (IQueryFilterDefinition) queryFilter;
                    definition2.PostfixClause = "ORDER BY " + sFieldName;
                    ICursor cursor = attributeTable.Search(queryFilter, false);
                    IDataStatistics statistics = new DataStatisticsClass();
                    statistics.Field = str;
                    statistics.Cursor = cursor;
                    IEnumerator uniqueValues = statistics.UniqueValues;
                    uniqueValues.Reset();
                    int index = cursor.Fields.FindField(str);
                    esriFieldType type = cursor.Fields.get_Field(index).Type;
                    IField field = cursor.Fields.get_Field(index);
                    while (uniqueValues.MoveNext())
                    {
                        if ((field.Domain == null) || (field.Domain.Type != esriDomainType.esriDTCodedValue))
                        {
                            goto Label_01D2;
                        }
                        string item = "";
                        try
                        {
                            ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                            long num2 = Convert.ToInt64(uniqueValues.Current);
                            for (int i = 0; i < domain.CodeCount; i++)
                            {
                                if (num2 == Convert.ToInt64(domain.get_Value(i)))
                                {
                                    item = this.ConvertFieldValueToString(type, uniqueValues.Current) + "-" + domain.get_Name(i);
                                    goto Label_01B1;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            item = this.ConvertFieldValueToString(type, uniqueValues.Current);
                        }
                    Label_01B1:
                        Items.Add(item);
                        list.Add(this.ConvertFieldValueToString(type, uniqueValues.Current));
                        continue;
                    Label_01D2:
                        Items.Add(this.ConvertFieldValueToString(type, uniqueValues.Current));
                        list.Add(this.ConvertFieldValueToString(type, uniqueValues.Current));
                    }
                }
                this.listBoxUniqueValues.Tag = list;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "UpdateFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show(exception.Message);
            }
        }

        private void InitControl()
        {
            try
            {
                this.InitialLayer();
                if (this.m_SelLayer != null)
                {
                    this.textEdit1.Text = "Select * From " + this.m_SelLayer.Name + " Where ";
                    this.UpdateFieldList(this.m_SelLayer, this.listBoxFields.Items);
                    this.memEditWhereCaluse.Text = this.m_strWhereCaluse;
                    this.labelInfo.Text = "";
                    if (((this.m_SelLayer as IFeatureLayer).FeatureClass as IDataset).Workspace.Type == esriWorkspaceType.esriLocalDatabaseWorkspace)
                    {
                        this.btnMatchOneChar.Text = "?";
                        this.btnMatchString.Text = "*";
                    }
                    else
                    {
                        this.btnMatchOneChar.Text = "_";
                        this.btnMatchString.Text = "%";
                    }
                    this.listBoxUniqueValues.Items.Clear();
                    this.listBoxUniqueValues.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "InitControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSelectByAttributes));
            this.PanelButton = new System.Windows.Forms.Panel();
            this.simpleButtonSelectClear = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.listBoxFields = new DevExpress.XtraEditors.ListBoxControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxUniqueValues = new DevExpress.XtraEditors.ListBoxControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButtonGetUniqueValues = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLike = new DevExpress.XtraEditors.SimpleButton();
            this.btnEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnOr = new DevExpress.XtraEditors.SimpleButton();
            this.btnIs = new DevExpress.XtraEditors.SimpleButton();
            this.btnGreatEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnNot = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnBracket = new DevExpress.XtraEditors.SimpleButton();
            this.btnLittle = new DevExpress.XtraEditors.SimpleButton();
            this.btnGreat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLittleEqual = new DevExpress.XtraEditors.SimpleButton();
            this.btnMatchString = new DevExpress.XtraEditors.SimpleButton();
            this.btnMatchOneChar = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.OID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkQuery = new DevExpress.XtraEditors.CheckEdit();
            this.popEditLayer = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListLayer = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.memEditWhereCaluse = new DevExpress.XtraEditors.MemoEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnZoom = new DevExpress.XtraEditors.SimpleButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnValidate = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.PanelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFields)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxUniqueValues)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEditLayer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayer)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memEditWhereCaluse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButton
            // 
            this.PanelButton.Controls.Add(this.simpleButtonSelectClear);
            this.PanelButton.Controls.Add(this.simpleButtonSelectAll);
            this.PanelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButton.Location = new System.Drawing.Point(4, 642);
            this.PanelButton.Name = "PanelButton";
            this.PanelButton.Padding = new System.Windows.Forms.Padding(6, 6, 0, 4);
            this.PanelButton.Size = new System.Drawing.Size(272, 34);
            this.PanelButton.TabIndex = 6;
            this.PanelButton.Visible = false;
            // 
            // simpleButtonSelectClear
            // 
            this.simpleButtonSelectClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelectClear.Location = new System.Drawing.Point(128, 6);
            this.simpleButtonSelectClear.Name = "simpleButtonSelectClear";
            this.simpleButtonSelectClear.Size = new System.Drawing.Size(72, 24);
            this.simpleButtonSelectClear.TabIndex = 5;
            this.simpleButtonSelectClear.Text = "清空(&C)";
            // 
            // simpleButtonSelectAll
            // 
            this.simpleButtonSelectAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelectAll.Location = new System.Drawing.Point(200, 6);
            this.simpleButtonSelectAll.Name = "simpleButtonSelectAll";
            this.simpleButtonSelectAll.Size = new System.Drawing.Size(72, 24);
            this.simpleButtonSelectAll.TabIndex = 4;
            this.simpleButtonSelectAll.Text = "全选(&S)";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.listBoxFields);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(4, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.groupControl1.Size = new System.Drawing.Size(272, 300);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "条件设置";
            // 
            // listBoxFields
            // 
            this.listBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFields.Location = new System.Drawing.Point(6, 46);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new System.Drawing.Size(260, 102);
            this.listBoxFields.TabIndex = 123;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBoxUniqueValues);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(6, 148);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel2.Size = new System.Drawing.Size(260, 150);
            this.panel2.TabIndex = 124;
            // 
            // listBoxUniqueValues
            // 
            this.listBoxUniqueValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUniqueValues.HorizontalScrollbar = true;
            this.listBoxUniqueValues.Location = new System.Drawing.Point(120, 6);
            this.listBoxUniqueValues.Name = "listBoxUniqueValues";
            this.listBoxUniqueValues.Size = new System.Drawing.Size(140, 110);
            this.listBoxUniqueValues.TabIndex = 124;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simpleButtonGetUniqueValues);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(120, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 28);
            this.panel3.TabIndex = 125;
            // 
            // simpleButtonGetUniqueValues
            // 
            this.simpleButtonGetUniqueValues.Location = new System.Drawing.Point(0, 4);
            this.simpleButtonGetUniqueValues.Name = "simpleButtonGetUniqueValues";
            this.simpleButtonGetUniqueValues.Size = new System.Drawing.Size(72, 24);
            this.simpleButtonGetUniqueValues.TabIndex = 6;
            this.simpleButtonGetUniqueValues.Text = "获取唯一值";
            this.simpleButtonGetUniqueValues.Click += new System.EventHandler(this.btnGetUniqueValue_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLike);
            this.panel6.Controls.Add(this.btnEqual);
            this.panel6.Controls.Add(this.btnAnd);
            this.panel6.Controls.Add(this.btnOr);
            this.panel6.Controls.Add(this.btnIs);
            this.panel6.Controls.Add(this.btnGreatEqual);
            this.panel6.Controls.Add(this.btnNot);
            this.panel6.Controls.Add(this.btnNotEqual);
            this.panel6.Controls.Add(this.btnBracket);
            this.panel6.Controls.Add(this.btnLittle);
            this.panel6.Controls.Add(this.btnGreat);
            this.panel6.Controls.Add(this.btnLittleEqual);
            this.panel6.Controls.Add(this.btnMatchString);
            this.panel6.Controls.Add(this.btnMatchOneChar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(120, 138);
            this.panel6.TabIndex = 126;
            // 
            // btnLike
            // 
            this.btnLike.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLike.Appearance.Options.UseForeColor = true;
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLike.Location = new System.Drawing.Point(80, 0);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(34, 24);
            this.btnLike.TabIndex = 19;
            this.btnLike.Text = "&Like";
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEqual.Appearance.Options.UseForeColor = true;
            this.btnEqual.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEqual.Location = new System.Drawing.Point(0, 0);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(34, 24);
            this.btnEqual.TabIndex = 17;
            this.btnEqual.Text = "=";
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnd.Appearance.Options.UseForeColor = true;
            this.btnAnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAnd.Location = new System.Drawing.Point(80, 28);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(34, 24);
            this.btnAnd.TabIndex = 22;
            this.btnAnd.Text = "&And";
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnOr
            // 
            this.btnOr.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOr.Appearance.Options.UseForeColor = true;
            this.btnOr.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOr.Location = new System.Drawing.Point(80, 56);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(34, 24);
            this.btnOr.TabIndex = 25;
            this.btnOr.Text = "&Or";
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnIs
            // 
            this.btnIs.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIs.Appearance.Options.UseForeColor = true;
            this.btnIs.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnIs.Location = new System.Drawing.Point(0, 112);
            this.btnIs.Name = "btnIs";
            this.btnIs.Size = new System.Drawing.Size(34, 24);
            this.btnIs.TabIndex = 30;
            this.btnIs.Text = "&Is";
            this.btnIs.Click += new System.EventHandler(this.btnIs_Click);
            // 
            // btnGreatEqual
            // 
            this.btnGreatEqual.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGreatEqual.Appearance.Options.UseForeColor = true;
            this.btnGreatEqual.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGreatEqual.Location = new System.Drawing.Point(40, 28);
            this.btnGreatEqual.Name = "btnGreatEqual";
            this.btnGreatEqual.Size = new System.Drawing.Size(34, 24);
            this.btnGreatEqual.TabIndex = 21;
            this.btnGreatEqual.Text = ">=";
            this.btnGreatEqual.Click += new System.EventHandler(this.btnGreatEqual_Click);
            // 
            // btnNot
            // 
            this.btnNot.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNot.Appearance.Options.UseForeColor = true;
            this.btnNot.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNot.Location = new System.Drawing.Point(80, 84);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(34, 24);
            this.btnNot.TabIndex = 29;
            this.btnNot.Text = "&Not";
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnNotEqual
            // 
            this.btnNotEqual.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNotEqual.Appearance.Options.UseForeColor = true;
            this.btnNotEqual.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNotEqual.Location = new System.Drawing.Point(40, 0);
            this.btnNotEqual.Name = "btnNotEqual";
            this.btnNotEqual.Size = new System.Drawing.Size(34, 24);
            this.btnNotEqual.TabIndex = 18;
            this.btnNotEqual.Text = "<>";
            this.btnNotEqual.Click += new System.EventHandler(this.btnNotEqual_Click);
            // 
            // btnBracket
            // 
            this.btnBracket.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBracket.Appearance.Options.UseForeColor = true;
            this.btnBracket.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBracket.Location = new System.Drawing.Point(40, 84);
            this.btnBracket.Name = "btnBracket";
            this.btnBracket.Size = new System.Drawing.Size(34, 24);
            this.btnBracket.TabIndex = 28;
            this.btnBracket.Text = "( )";
            this.btnBracket.Click += new System.EventHandler(this.btnBracket_Click);
            // 
            // btnLittle
            // 
            this.btnLittle.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLittle.Appearance.Options.UseForeColor = true;
            this.btnLittle.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLittle.Location = new System.Drawing.Point(0, 56);
            this.btnLittle.Name = "btnLittle";
            this.btnLittle.Size = new System.Drawing.Size(34, 24);
            this.btnLittle.TabIndex = 23;
            this.btnLittle.Text = "<";
            this.btnLittle.Click += new System.EventHandler(this.btnLittle_Click);
            // 
            // btnGreat
            // 
            this.btnGreat.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGreat.Appearance.Options.UseForeColor = true;
            this.btnGreat.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGreat.Location = new System.Drawing.Point(0, 28);
            this.btnGreat.Name = "btnGreat";
            this.btnGreat.Size = new System.Drawing.Size(34, 24);
            this.btnGreat.TabIndex = 20;
            this.btnGreat.Text = ">";
            this.btnGreat.Click += new System.EventHandler(this.btnGreat_Click);
            // 
            // btnLittleEqual
            // 
            this.btnLittleEqual.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLittleEqual.Appearance.Options.UseForeColor = true;
            this.btnLittleEqual.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLittleEqual.Location = new System.Drawing.Point(40, 56);
            this.btnLittleEqual.Name = "btnLittleEqual";
            this.btnLittleEqual.Size = new System.Drawing.Size(34, 24);
            this.btnLittleEqual.TabIndex = 24;
            this.btnLittleEqual.Text = "<=";
            this.btnLittleEqual.Click += new System.EventHandler(this.btnLittleEqual_Click);
            // 
            // btnMatchString
            // 
            this.btnMatchString.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMatchString.Appearance.Options.UseForeColor = true;
            this.btnMatchString.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMatchString.Location = new System.Drawing.Point(18, 84);
            this.btnMatchString.Name = "btnMatchString";
            this.btnMatchString.Size = new System.Drawing.Size(18, 24);
            this.btnMatchString.TabIndex = 27;
            this.btnMatchString.Text = "%";
            this.btnMatchString.Click += new System.EventHandler(this.btnMatchString_Click);
            // 
            // btnMatchOneChar
            // 
            this.btnMatchOneChar.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMatchOneChar.Appearance.Options.UseForeColor = true;
            this.btnMatchOneChar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMatchOneChar.Location = new System.Drawing.Point(0, 84);
            this.btnMatchOneChar.Name = "btnMatchOneChar";
            this.btnMatchOneChar.Size = new System.Drawing.Size(16, 24);
            this.btnMatchOneChar.TabIndex = 26;
            this.btnMatchOneChar.Text = "_";
            this.btnMatchOneChar.Click += new System.EventHandler(this.btnMatchOneChar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 122;
            this.label1.Text = "字段名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(6, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(260, 74);
            this.gridControl1.TabIndex = 121;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.OID,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // OID
            // 
            this.OID.Caption = "参数";
            this.OID.Name = "OID";
            this.OID.Visible = true;
            this.OID.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "值";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkQuery);
            this.panel1.Controls.Add(this.popEditLayer);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(272, 30);
            this.panel1.TabIndex = 11;
            // 
            // checkQuery
            // 
            this.checkQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkQuery.Location = new System.Drawing.Point(80, 24);
            this.checkQuery.Name = "checkQuery";
            this.checkQuery.Properties.Caption = "仅显示可选图层列表";
            this.checkQuery.Size = new System.Drawing.Size(188, 19);
            this.checkQuery.TabIndex = 36;
            this.checkQuery.Visible = false;
            this.checkQuery.CheckedChanged += new System.EventHandler(this.checkQuery_CheckedChanged);
            // 
            // popEditLayer
            // 
            this.popEditLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.popEditLayer.Location = new System.Drawing.Point(80, 4);
            this.popEditLayer.Name = "popEditLayer";
            this.popEditLayer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popEditLayer.Properties.PopupControl = this.popupContainerControl1;
            this.popEditLayer.Size = new System.Drawing.Size(188, 20);
            this.popEditLayer.TabIndex = 33;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListLayer);
            this.popupContainerControl1.Location = new System.Drawing.Point(150, 88);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(200, 200);
            this.popupContainerControl1.TabIndex = 34;
            // 
            // treeListLayer
            // 
            this.treeListLayer.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.treeListLayer.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.treeListLayer.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListLayer.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeListLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLayer.Location = new System.Drawing.Point(0, 0);
            this.treeListLayer.Name = "treeListLayer";
            this.treeListLayer.BeginUnboundLoad();
            this.treeListLayer.AppendNode(new object[] {
            "图层组"}, -1, 0, 0, 0);
            this.treeListLayer.AppendNode(new object[] {
            "图层"}, 0, 0, 0, 1);
            this.treeListLayer.AppendNode(new object[] {
            "图层组"}, -1, 0, 0, 0);
            this.treeListLayer.AppendNode(new object[] {
            "图层"}, 2, 0, 0, 2);
            this.treeListLayer.EndUnboundLoad();
            this.treeListLayer.OptionsBehavior.Editable = false;
            this.treeListLayer.OptionsView.ShowColumns = false;
            this.treeListLayer.OptionsView.ShowHorzLines = false;
            this.treeListLayer.OptionsView.ShowIndicator = false;
            this.treeListLayer.OptionsView.ShowVertLines = false;
            this.treeListLayer.Size = new System.Drawing.Size(200, 200);
            this.treeListLayer.StateImageList = this.imageList1;
            this.treeListLayer.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 69;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "layer2.png");
            this.imageList1.Images.SetKeyName(1, "point.png");
            this.imageList1.Images.SetKeyName(2, "polyine.png");
            this.imageList1.Images.SetKeyName(3, "polygon.png");
            this.imageList1.Images.SetKeyName(4, "layers_0.bmp");
            this.imageList1.Images.SetKeyName(5, "application_Arc.png");
            this.imageList1.Images.SetKeyName(6, "layer7.png");
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.panel7.Size = new System.Drawing.Size(76, 22);
            this.panel7.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = " 选择图层:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(4, 4);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(272, 30);
            this.labelLocation.TabIndex = 21;
            this.labelLocation.Text = "      属性选择          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(4, 516);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl2.Size = new System.Drawing.Size(272, 126);
            this.groupControl2.TabIndex = 22;
            this.groupControl2.Text = "查询结果";
            this.groupControl2.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 20);
            this.label3.TabIndex = 122;
            this.label3.Text = "要素列表:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 364);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 6);
            this.panel4.TabIndex = 23;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.memEditWhereCaluse);
            this.groupControl3.Controls.Add(this.textEdit1);
            this.groupControl3.Controls.Add(this.panel5);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(4, 370);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl3.Size = new System.Drawing.Size(272, 146);
            this.groupControl3.TabIndex = 24;
            this.groupControl3.Text = "选择条件";
            // 
            // memEditWhereCaluse
            // 
            this.memEditWhereCaluse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memEditWhereCaluse.EditValue = "";
            this.memEditWhereCaluse.Location = new System.Drawing.Point(6, 44);
            this.memEditWhereCaluse.Name = "memEditWhereCaluse";
            this.memEditWhereCaluse.Size = new System.Drawing.Size(260, 44);
            this.memEditWhereCaluse.TabIndex = 127;
            this.memEditWhereCaluse.UseOptimizedRendering = true;
            // 
            // textEdit1
            // 
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(6, 26);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(260, 18);
            this.textEdit1.TabIndex = 128;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnZoom);
            this.panel5.Controls.Add(this.labelInfo);
            this.panel5.Controls.Add(this.btnValidate);
            this.panel5.Controls.Add(this.btnClear);
            this.panel5.Controls.Add(this.btnClose);
            this.panel5.Controls.Add(this.btnApply);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(6, 88);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 52);
            this.panel5.TabIndex = 126;
            // 
            // btnZoom
            // 
            this.btnZoom.Location = new System.Drawing.Point(126, 6);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(56, 24);
            this.btnZoom.TabIndex = 57;
            this.btnZoom.Text = "定位";
            this.btnZoom.ToolTip = "缩放到选中范围";
            this.btnZoom.Visible = false;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.Location = new System.Drawing.Point(0, 34);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(260, 18);
            this.labelInfo.TabIndex = 56;
            this.labelInfo.Text = " ";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(232, 6);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(56, 24);
            this.btnValidate.TabIndex = 55;
            this.btnValidate.Text = "验证";
            this.btnValidate.Visible = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(0, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 24);
            this.btnClear.TabIndex = 54;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(192, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 24);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "关闭";
            this.btnClose.Visible = false;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(64, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(56, 24);
            this.btnApply.TabIndex = 52;
            this.btnApply.Text = "应用";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // UserControlSelectByAttributes
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.PanelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlSelectByAttributes";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(280, 680);
            this.PanelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFields)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxUniqueValues)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEditLayer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayer)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memEditWhereCaluse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitialLayer()
        {
            try
            {
                this.GetLayerColn2();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "InitialLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue(object hook)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                if (hook != null)
                {
                    this.mHookHelper.Hook = hook;
                }
                this.popEditLayer.Text = "";
                this.listBoxFields.Items.Clear();
                this.listBoxUniqueValues.Items.Clear();
                this.m_SelLayer = null;
                this.InitControl();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = this.listBoxFields.SelectedItem as string;
            selectedItem = selectedItem.Split(new char[] { '[' })[0];
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + selectedItem + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + selectedItem.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxUniqueValues.Items.Clear();
            this.listBoxUniqueValues.Enabled = false;
        }

        private void listBoxUniqueValues_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = this.listBoxUniqueValues.SelectedItem as string;
            if (this.listBoxUniqueValues.Tag != null)
            {
                selectedItem = ((ArrayList) this.listBoxUniqueValues.Tag)[this.listBoxUniqueValues.SelectedIndex].ToString();
            }
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + selectedItem + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + selectedItem.Length) + 2;
            this.labelInfo.Text = "";
        }

        private void popEditLayer_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.treeListLayer.Dock = DockStyle.Fill;
        }

        private bool SetFeatureLayer(ILayer pLayer, ArrayList layerList, TreeListNode parentnode)
        {
            try
            {
                if ((pLayer as IFeatureLayer).FeatureClass != null)
                {
                    TreeListNode node = this.treeListLayer.AppendNode(pLayer.Name, parentnode);
                    node.SetValue(0, pLayer.Name);
                    node.Tag = pLayer as IFeatureLayer;
                    int num = 0;
                    if ((pLayer as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        num = 1;
                    }
                    else if ((pLayer as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {
                        num = 2;
                    }
                    else if ((pLayer as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        num = 3;
                    }
                    node.ImageIndex = -1;
                    node.StateImageIndex = num;
                    node.SelectImageIndex = -1;
                    node.ExpandAll();
                    this.mLayerList.Add(pLayer as IFeatureLayer);
                    if ((pLayer.Valid && pLayer.Visible) && (pLayer as IFeatureLayer).Selectable)
                    {
                        this.mSelLayerList.Add(pLayer as IFeatureLayer);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "SetFeatureLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool SetGroupLayer(ILayer pLayer, ArrayList GroupList, TreeListNode parentnode)
        {
            try
            {
                ICompositeLayer layer = null;
                IGroupLayer layer2 = null;
                layer2 = pLayer as IGroupLayer;
                layer = layer2 as ICompositeLayer;
                this.mGroupList.Add(layer2);
                TreeListNode node = this.treeListLayer.AppendNode(pLayer.Name, parentnode);
                node.SetValue(0, pLayer.Name);
                node.Tag = layer2;
                node.ImageIndex = -1;
                node.StateImageIndex = 0;
                node.SelectImageIndex = -1;
                node.ExpandAll();
                for (int i = 0; i < layer.Count; i++)
                {
                    ILayer layer3 = layer.get_Layer(i);
                    if (layer3 is IGroupLayer)
                    {
                        this.SetGroupLayer(layer3, this.mGroupList, node);
                    }
                    else if (layer3 is IFeatureLayer)
                    {
                        this.SetFeatureLayer(layer3, this.mLayerList, node);
                    }
                }
                if (node.Nodes.Count == 0)
                {
                    this.treeListLayer.DeleteNode(node);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "SetGroupLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void treeListLayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.treeListLayer.Selection.Count > 0)
            {
                TreeListNode node = this.treeListLayer.Selection[0];
                if (node.Tag is IFeatureLayer)
                {
                    this.m_SelLayer = node.Tag as ILayer;
                }
            }
            if (this.popEditLayer.Text != "")
            {
                this.popEditLayer.ClosePopup();
            }
        }

        private void treeListLayer_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.treeListLayer.Selection.Count != 0)
            {
                TreeListNode node = this.treeListLayer.Selection[0];
                if (node.Tag is IGroupLayer)
                {
                    this.popEditLayer.Text = "";
                    this.popEditLayer.Tag = null;
                }
                else if (node.Tag is IFeatureLayer)
                {
                    this.m_SelLayer = node.Tag as ILayer;
                    this.popEditLayer.Text = this.m_SelLayer.Name;
                    this.popEditLayer.Tag = node.Tag as IFeatureLayer;
                    this.textEdit1.Text = "Select * From " + this.m_SelLayer.Name + " Where ";
                    this.UpdateFieldList(this.m_SelLayer, this.listBoxFields.Items);
                    this.memEditWhereCaluse.Text = this.m_strWhereCaluse;
                    this.labelInfo.Text = "";
                    if (((this.m_SelLayer as IFeatureLayer).FeatureClass as IDataset).Workspace.Type == esriWorkspaceType.esriLocalDatabaseWorkspace)
                    {
                        this.btnMatchOneChar.Text = "?";
                        this.btnMatchString.Text = "*";
                    }
                    else
                    {
                        this.btnMatchOneChar.Text = "_";
                        this.btnMatchString.Text = "%";
                    }
                    this.listBoxUniqueValues.Items.Clear();
                    this.listBoxUniqueValues.Enabled = false;
                }
            }
        }

        private void UpdateFieldList(ILayer pLayer, ListBoxItemCollection Items)
        {
            try
            {
                Items.Clear();
                IAttributeTable table = pLayer as IAttributeTable;
                if (table != null)
                {
                    ITable attributeTable = table.AttributeTable;
                    esriWorkspaceType type = (attributeTable as IDataset).Workspace.Type;
                    IFields fields = attributeTable.Fields;
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if ((field.Type != esriFieldType.esriFieldTypeGeometry) && (field.Type != esriFieldType.esriFieldTypeBlob))
                        {
                            if (field.AliasName != field.Name)
                            {
                                Items.Add(field.Name + "[" + field.AliasName + "]");
                            }
                            else
                            {
                                Items.Add(field.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlSelectByAttributes", "UpdateFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

