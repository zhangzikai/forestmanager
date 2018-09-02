namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlUpdate : UserControlBase1
    {
        private CheckedListBoxControl checkedListBoxControl1;
        private IContainer components;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        private LabelControl labelControl1;
        private LabelControl labelYear;
        private bool m_bFirst = true;
        private IGeometry m_BoundaryGeo;
        private int m_Column = -1;
        private IHookHelper m_HookHelper;
        private IList<IFeatureLayer> m_LayerList;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel5;
        private Panel panelOverlap;
        private RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private SimpleButton simpleButtonUpdate;
        private TreeList treeList1;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;

        public UserControlUpdate()
        {
            this.InitializeComponent();
        }

        private void AutoUpdate(IList<IFeatureLayer> pLayerList)
        {
            if (!Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
            }
            Editor.UniqueInstance.CheckOverlap = false;
            Editor.UniqueInstance.StartEditOperation();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private IGeometry GetBoundary(string sCodes)
        {
            try
            {
                string[] strArray = sCodes.Split(new char[] { ',' });
                string str = "";
                string str2 = "";
                string str3 = "";
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string str4 = configOpt.GetConfigValue2("Sub", "CntyField");
                string str5 = configOpt.GetConfigValue2("Sub", "TownField");
                string str6 = configOpt.GetConfigValue2("Sub", "VillField");
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str7 = strArray[i];
                    if (str7.Length == 6)
                    {
                        string str11 = str;
                        str = str11 + " or " + str4 + "='" + str7 + "'";
                    }
                    else if (str7.Length == 9)
                    {
                        string str12 = str2;
                        str2 = str12 + " or " + str5 + "='" + str7 + "'";
                    }
                    else if (str7.Length == 12)
                    {
                        string str13 = str3;
                        str3 = str13 + " or " + str6 + "='" + str7 + "'";
                    }
                    else
                    {
                        return null;
                    }
                }
                IGeometry shapeCopy = null;
                if (str != "")
                {
                    str = str.Substring(4);
                    string configValue = configOpt.GetConfigValue("CountyLayerName");
                    IFeatureLayer layer = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_HookHelper.FocusMap, configValue, true);
                    IQueryFilter queryFilter = new QueryFilterClass {
                        WhereClause = str
                    };
                    shapeCopy = layer.Search(queryFilter, false).NextFeature().ShapeCopy;
                }
                else
                {
                    if (str2 != "")
                    {
                        str2 = str2.Substring(4);
                        string sLayerName = configOpt.GetConfigValue("TownLayerName");
                        IFeatureLayer layer2 = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_HookHelper.FocusMap, sLayerName, true);
                        IQueryFilter filter2 = new QueryFilterClass {
                            WhereClause = str2
                        };
                        IGeometry other = layer2.Search(filter2, false).NextFeature().ShapeCopy;
                        if (shapeCopy == null)
                        {
                            shapeCopy = other;
                        }
                        else
                        {
                            ((ITopologicalOperator2) shapeCopy).Union(other);
                        }
                    }
                    if (str3 != "")
                    {
                        str3 = str3.Substring(4);
                        string str10 = configOpt.GetConfigValue("VillageLayerName");
                        IFeatureLayer layer3 = GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_HookHelper.FocusMap, str10, true);
                        IQueryFilter filter3 = new QueryFilterClass {
                            WhereClause = str3
                        };
                        IGeometry geometry3 = layer3.Search(filter3, false).NextFeature().ShapeCopy;
                        if (shapeCopy == null)
                        {
                            shapeCopy = geometry3;
                        }
                        else
                        {
                            ((ITopologicalOperator2) shapeCopy).Union(geometry3);
                        }
                    }
                }
                return shapeCopy;
            }
            catch
            {
                return null;
            }
        }

        private IFeatureLayer GetLayer(string sLayerName)
        {
            return GISFunFactory.LayerFun.FindFeatureLayer((IBasicMap) this.m_HookHelper.FocusMap, sLayerName, true);
        }

        public void Init(object pHook)
        {
            if (this.m_HookHelper == null)
            {
                this.m_HookHelper = new HookHelperClass();
            }
            this.m_HookHelper.Hook = pHook;
            if (this.m_bFirst)
            {
                this.panelOverlap.Visible = false;
                this.labelYear.Text = "年度：" + EditTask.TaskYear;
                CheckedListBoxItem item = new CheckedListBoxItem {
                    Description = "造林",
                    Value = "造林专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "采伐",
                    Value = "采伐专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "火灾",
                    Value = "火灾专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "征占用",
                    Value = "征占用专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "自然灾害",
                    Value = "自然灾害专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "林业工程",
                    Value = "林业工程专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                item = new CheckedListBoxItem {
                    Description = "林业案件",
                    Value = "林业案件专题",
                    CheckState = CheckState.Checked
                };
                this.checkedListBoxControl1.Items.Add(item);
                this.m_bFirst = false;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlUpdate));
            this.checkedListBoxControl1 = new CheckedListBoxControl();
            this.panel1 = new Panel();
            this.panel3 = new Panel();
            this.simpleButtonUpdate = new SimpleButton();
            this.panel2 = new Panel();
            this.labelYear = new LabelControl();
            this.panelOverlap = new Panel();
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.ImageList1 = new ImageList(this.components);
            this.treeListColumn3 = new TreeListColumn();
            this.repositoryItemImageEdit2 = new RepositoryItemImageEdit();
            this.imageList2 = new ImageList(this.components);
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit2 = new RepositoryItemButtonEdit();
            this.panel5 = new Panel();
            this.labelControl1 = new LabelControl();
            ((ISupportInitialize) this.checkedListBoxControl1).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelOverlap.SuspendLayout();
            this.treeList1.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageEdit2.BeginInit();
            this.repositoryItemButtonEdit1.BeginInit();
            this.repositoryItemButtonEdit2.BeginInit();
            this.panel5.SuspendLayout();
            base.SuspendLayout();
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Dock = DockStyle.Top;
            this.checkedListBoxControl1.ItemHeight = 0x18;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(5, 5);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new Size(0x141, 0xad);
            this.checkedListBoxControl1.TabIndex = 0;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkedListBoxControl1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(5);
            this.panel1.Size = new Size(0x14b, 250);
            this.panel1.TabIndex = 1;
            this.panel3.Controls.Add(this.simpleButtonUpdate);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 0xd5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 5, 15, 5);
            this.panel3.Size = new Size(0x141, 0x24);
            this.panel3.TabIndex = 2;
            this.simpleButtonUpdate.Dock = DockStyle.Right;
            this.simpleButtonUpdate.Location = new System.Drawing.Point(0xe7, 5);
            this.simpleButtonUpdate.Name = "simpleButtonUpdate";
            this.simpleButtonUpdate.Size = new Size(0x4b, 0x1a);
            this.simpleButtonUpdate.TabIndex = 0;
            this.simpleButtonUpdate.Text = "更新";
            this.simpleButtonUpdate.Click += new EventHandler(this.simpleButtonUpdate_Click);
            this.panel2.Controls.Add(this.labelYear);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 0xb2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x141, 0x23);
            this.panel2.TabIndex = 1;
            this.labelYear.Location = new System.Drawing.Point(0x1a, 13);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new Size(0x24, 14);
            this.labelYear.TabIndex = 0;
            this.labelYear.Text = "年度：";
            this.panelOverlap.Controls.Add(this.treeList1);
            this.panelOverlap.Controls.Add(this.panel5);
            this.panelOverlap.Dock = DockStyle.Fill;
            this.panelOverlap.Location = new System.Drawing.Point(0, 250);
            this.panelOverlap.Name = "panelOverlap";
            this.panelOverlap.Size = new Size(0x14b, 0xb5);
            this.panelOverlap.TabIndex = 2;
            this.panelOverlap.Visible = false;
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0x1f);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemButtonEdit1, this.repositoryItemButtonEdit2, this.repositoryItemImageEdit1, this.repositoryItemImageEdit2 });
            this.treeList1.Size = new Size(0x14b, 150);
            this.treeList1.TabIndex = 0;
            this.treeList1.MouseUp += new MouseEventHandler(this.treeList1_MouseUp);
            this.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.treeList1_FocusedColumnChanged);
            this.treeListColumn1.Caption = "序号";
            this.treeListColumn1.FieldName = "序号";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 130;
            this.treeListColumn2.AppearanceCell.BackColor = Color.SkyBlue;
            this.treeListColumn2.AppearanceCell.Options.UseBackColor = true;
            this.treeListColumn2.ColumnEdit = this.repositoryItemImageEdit1;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 30;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemImageEdit1.Images = this.ImageList1;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "(00,17).png");
            this.treeListColumn3.AppearanceCell.BackColor = Color.SkyBlue;
            this.treeListColumn3.AppearanceCell.Options.UseBackColor = true;
            this.treeListColumn3.ColumnEdit = this.repositoryItemImageEdit2;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 30;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemImageEdit2.Images = this.imageList2;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "(30,24).png");
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.panel5.Controls.Add(this.labelControl1);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(0x14b, 0x1f);
            this.panel5.TabIndex = 1;
            this.labelControl1.Location = new System.Drawing.Point(14, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x6c, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "重叠冲突部分列表：";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelOverlap);
            base.Controls.Add(this.panel1);
            base.Name = "UserControlUpdate";
            base.Size = new Size(0x14b, 0x1af);
            ((ISupportInitialize) this.checkedListBoxControl1).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelOverlap.ResumeLayout(false);
            this.treeList1.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageEdit2.EndInit();
            this.repositoryItemButtonEdit1.EndInit();
            this.repositoryItemButtonEdit2.EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            base.ResumeLayout(false);
        }

        private void ShowSelected(TreeListNode pNode)
        {
        }

        private void simpleButtonUpdate_Click(object sender, EventArgs e)
        {
            string distCode = EditTask.DistCode;
            this.m_BoundaryGeo = this.GetBoundary(distCode);
            IList<IFeatureLayer> list = new List<IFeatureLayer>();
            for (int i = 0; i < this.checkedListBoxControl1.Items.Count; i++)
            {
                CheckedListBoxItem item = this.checkedListBoxControl1.Items[i];
                if (item.CheckState == CheckState.Checked)
                {
                    IFeatureLayer layer = this.GetLayer(item.Value.ToString());
                    if (layer == null)
                    {
                        MessageBox.Show(item.Description + "图层不存在！更新失败。");
                        break;
                    }
                    list.Add(layer);
                }
            }
            if (list.Count < 1)
            {
                MessageBox.Show("请选择专题图层！");
            }
        }

        private void StopEditing()
        {
            Editor.UniqueInstance.CheckOverlap = true;
            Editor.UniqueInstance.StopEditOperation("AutoUpdate");
            if (Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StopEdit();
            }
            if (!Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
            }
        }

        private void treeList1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.m_Column = e.Column.AbsoluteIndex;
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.X >= this.treeList1.Columns[0].Width) && (this.m_Column != 0))
                {
                    TreeListNode pNode = this.treeList1.Selection[0];
                    if (this.m_Column == 1)
                    {
                        this.ShowSelected(pNode);
                    }
                    else
                    {
                        int column = this.m_Column;
                    }
                }
            }
            catch
            {
            }
        }
    }
}

