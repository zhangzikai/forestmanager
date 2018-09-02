namespace QueryCommon
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Nodes;
    using FormBase;
    using Identify;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    

    public class UserControlIdentify : UserControlBase1
    {
        private IContainer components;
        public bool flag;
        private string lyrName;
        private DataTable pDataTable = new DataTable();
        private PopupContainerControl popupContainerControl1;
        private PopupContainerEdit popupContainerEdit1;
        public int selectedIndex;
        private TreeList treeList1;

        public UserControlIdentify()
        {
            this.InitializeComponent();
        }

        public void DisplayLayerFilters1(List<LayerFilterProperties> layerFilterSet)
        {
            this.treeList1.Nodes.Clear();
            int count = layerFilterSet.Count;
            this.pDataTable.Columns.Clear();
            this.pDataTable.Rows.Clear();
            DataRow row = null;
            this.pDataTable.Columns.Add("ID");
            this.pDataTable.Columns.Add("图层信息");
            this.pDataTable.Columns.Add("ParentID");
            for (int i = 0; i < count; i++)
            {
                LayerFilterProperties properties = layerFilterSet[i];
                if ((properties.LayerFeatureType == LayerFeatureType.None) || (properties.LayerFeatureType == LayerFeatureType.GroupLayer))
                {
                    row = this.pDataTable.NewRow();
                    this.lyrName = properties.LayerFilterName.ToString();
                    row["ID"] = this.lyrName;
                    row["图层信息"] = this.lyrName;
                    row["ParentID"] = -1;
                    this.pDataTable.Rows.Add(row);
                }
                else
                {
                    row = this.pDataTable.NewRow();
                    string str = properties.LayerFilterName.ToString();
                    row["ID"] = str + i;
                    row["图层信息"] = str;
                    row["ParentID"] = this.lyrName;
                    this.pDataTable.Rows.Add(row);
                }
            }
            this.treeList1.DataSource = this.pDataTable;
            this.treeList1.ParentFieldName = "ParentID";
            this.treeList1.ExpandAll();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.popupContainerEdit1 = new PopupContainerEdit();
            this.popupContainerControl1 = new PopupContainerControl();
            this.treeList1 = new TreeList();
            this.popupContainerEdit1.Properties.BeginInit();
            this.popupContainerControl1.BeginInit();
            this.popupContainerControl1.SuspendLayout();
            this.treeList1.BeginInit();
            base.SuspendLayout();
            this.popupContainerEdit1.Dock = DockStyle.Top;
            this.popupContainerEdit1.Location = new Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.PopupSizeable = false;
            this.popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit1.Properties.ShowPopupShadow = false;
            this.popupContainerEdit1.Size = new Size(0x126, 0x15);
            this.popupContainerEdit1.TabIndex = 0;
            this.popupContainerEdit1.QueryPopUp += new CancelEventHandler(this.popupContainerEdit1_QueryPopUp);
            this.popupContainerControl1.Controls.Add(this.treeList1);
            this.popupContainerControl1.Location = new Point(3, 0x1b);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new Size(0x120, 170);
            this.popupContainerControl1.TabIndex = 1;
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsPrint.AutoRowHeight = false;
            this.treeList1.OptionsPrint.AutoWidth = false;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new Size(0x120, 170);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.popupContainerControl1);
            base.Controls.Add(this.popupContainerEdit1);
            base.Name = "UserControlIdentify";
            base.Size = new Size(0x126, 0xe4);
            this.popupContainerEdit1.Properties.EndInit();
            this.popupContainerControl1.EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.treeList1.EndInit();
            base.ResumeLayout(false);
        }

        private void popupContainerEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            PopupContainerEdit edit = (PopupContainerEdit) sender;
            edit.Properties.PopupControl.Width = edit.Width;
        }

        public LayerFilterProperties SearchIdentifyLayers1(List<LayerFilterProperties> layerFilterSet)
        {
            if (!this.flag)
            {
                this.selectedIndex = this.treeList1.FocusedNode.Id;
                this.popupContainerEdit1.EditValue = this.treeList1.FocusedNode.GetValue(0).ToString();
                if (this.selectedIndex >= layerFilterSet.Count)
                {
                    MessageBox.Show("找不到过滤图层。");
                }
            }
            return layerFilterSet[this.selectedIndex];
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListNode node = e.Node;
            if (!this.flag)
            {
                for (int i = 0; i < this.pDataTable.Rows.Count; i++)
                {
                    if (this.pDataTable.Rows[i]["图层信息"].ToString() == "小班")
                    {
                        this.popupContainerEdit1.EditValue = this.pDataTable.Rows[i]["图层信息"].ToString();
                        this.selectedIndex = i;
                        this.flag = true;
                        break;
                    }
                }
                if (this.popupContainerEdit1.EditValue==null||string.IsNullOrEmpty(this.popupContainerEdit1.EditValue.ToString().Trim()))
                {
                    for (int j = 0; j < this.pDataTable.Rows.Count; j++)
                    {
                        if ((EditTask.EditLayer != null) && (this.pDataTable.Rows[j]["图层信息"].ToString() == EditTask.EditLayer.Name))
                        {
                            this.popupContainerEdit1.EditValue = this.pDataTable.Rows[j]["图层信息"].ToString();
                            this.selectedIndex = j;
                            this.flag = true;
                            break;
                        }
                    }
                }
            }
            IdentifyTool.identifyFrom.AfterClickQuery();
            this.popupContainerEdit1.ClosePopup();
        }
    }
}

