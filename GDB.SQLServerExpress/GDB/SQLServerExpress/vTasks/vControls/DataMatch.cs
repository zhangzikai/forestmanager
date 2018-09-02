namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Geodatabase;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraGrid.Views.Base;

    public class DataMatch : XtraUserControl
    {
        private IWorkspace _sourceWs;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private GridColumn Source;
        private Dictionary<string, DataSetInfo> sourceFClass = new Dictionary<string, DataSetInfo>();
        private Dictionary<string, DataSetInfo> tarFClass = new Dictionary<string, DataSetInfo>();
        private GridColumn Target;

        public DataMatch()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Dictionary<DataSetInfo, DataSetInfo> GetMatch()
        {
            Dictionary<DataSetInfo, DataSetInfo> dictionary = new Dictionary<DataSetInfo, DataSetInfo>();
            for (int i = 0; i < this.gridView1.DataRowCount; i++)
            {
                string str = this.gridView1.GetRowCellValue(i, this.Source).ToString();
                string str2 = this.gridView1.GetRowCellValue(i, this.Target).ToString();
                if (str2 != "")
                {
                    dictionary.Add(this.sourceFClass[str], this.tarFClass[str2]);
                }
            }
            return dictionary;
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == this.Target)
            {
                this.repositoryItemComboBox1.Items.Clear();
                this.repositoryItemComboBox1.Items.Add("");
                string str = this.gridView1.GetRowCellValue(e.RowHandle, this.Source).ToString();
                DataSetInfo info = this.sourceFClass[str];
                if (info.Type == esriDatasetType.esriDTFeatureClass)
                {
                    foreach (KeyValuePair<string, DataSetInfo> pair in this.tarFClass)
                    {
                        if (pair.Value.Type == esriDatasetType.esriDTFeatureClass)
                        {
                            this.repositoryItemComboBox1.Items.Add(pair.Key);
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, DataSetInfo> pair2 in this.tarFClass)
                    {
                        if (pair2.Value.Type == esriDatasetType.esriDTRasterCatalog)
                        {
                            this.repositoryItemComboBox1.Items.Add(pair2.Key);
                        }
                    }
                }
            }
        }

        public void Init(IWorkspace pSourceWs, string pSourcePath, string pTarPath, Database pDb)
        {
            IDataset dataset2;
            this._sourceWs = pSourceWs;
            IEnumDataset dataset = pSourceWs.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                IEnumDataset subsets = dataset2.Subsets;
                subsets.Reset();
                IDataset dataset4 = subsets.Next();
                string str = pSourcePath + @"\" + dataset2.Name + @"\";
                while (dataset4 != null)
                {
                    if (dataset4.Name.ToUpper() == "INDEX_A_10K")
                    {
                        dataset4 = subsets.Next();
                    }
                    else
                    {
                        str = str + dataset4.Name;
                        DataSetInfo info = new DataSetInfo {
                            Path = str,
                            Type = esriDatasetType.esriDTFeatureClass
                        };
                        this.sourceFClass.Add(dataset4.Name.ToUpper(), info);
                        dataset4 = subsets.Next();
                    }
                }
            }
            dataset = pSourceWs.get_Datasets(esriDatasetType.esriDTFeatureClass);
            dataset.Reset();
            dataset2 = dataset.Next();
            while (dataset2 != null)
            {
                if (dataset2.Name.ToUpper().Contains("INDEX_A_10K"))
                {
                    dataset2 = dataset.Next();
                }
                else
                {
                    string str2 = pSourcePath + @"\" + dataset2.Name;
                    DataSetInfo info2 = new DataSetInfo {
                        Path = str2,
                        Type = esriDatasetType.esriDTFeatureClass
                    };
                    this.sourceFClass.Add(dataset2.Name.ToUpper(), info2);
                    dataset2 = dataset.Next();
                }
            }
            dataset = pSourceWs.get_Datasets(esriDatasetType.esriDTRasterDataset);
            dataset.Reset();
            for (dataset2 = dataset.Next(); dataset2 != null; dataset2 = dataset.Next())
            {
                string str3 = pSourcePath + @"\" + dataset2.Name;
                DataSetInfo info3 = new DataSetInfo {
                    Path = str3,
                    Type = esriDatasetType.esriDTRasterDataset
                };
                this.sourceFClass.Add(dataset2.Name.ToUpper(), info3);
            }
            DataTable table = pDb.ExecuteWithResults("select type,name,path from gdb_items where type='70737809-852C-4A03-9E22-2CECEA5B9BFA' or type='35B601F7-45CE-4AFF-ADB7-7702D3839B12'").Tables[0];
            foreach (DataRow row in table.Rows)
            {
                string str4 = row[1].ToString();
                int num = str4.LastIndexOf('.');
                str4 = str4.Substring(num + 1);
                DataSetInfo info4 = new DataSetInfo {
                    Path = pTarPath + row[2].ToString()
                };
                if (row[0].ToString().ToUpper() == "70737809-852C-4A03-9E22-2CECEA5B9BFA")
                {
                    info4.Type = esriDatasetType.esriDTFeatureClass;
                }
                else
                {
                    info4.Type = esriDatasetType.esriDTRasterCatalog;
                }
                this.tarFClass.Add(str4.ToUpper(), info4);
            }
            List<GDB.SQLServerExpress.vTasks.vControls.Record> list = new List<GDB.SQLServerExpress.vTasks.vControls.Record>();
            foreach (KeyValuePair<string, DataSetInfo> pair in this.sourceFClass)
            {
                GDB.SQLServerExpress.vTasks.vControls.Record item = new GDB.SQLServerExpress.vTasks.vControls.Record {
                    Source = pair.Key
                };
                if (this.tarFClass.ContainsKey(pair.Key))
                {
                    item.Target = pair.Key;
                }
                else
                {
                    item.Target = "";
                }
                list.Add(item);
            }
            this.gridControl1.BeginInit();
            this.gridControl1.DataSource = list;
            this.gridControl1.EndInit();
        }

        private void InitializeComponent()
        {
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
            this.Source = new GridColumn();
            this.Target = new GridColumn();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemCheckEdit1.BeginInit();
            this.repositoryItemComboBox1.BeginInit();
            base.SuspendLayout();
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox1, this.repositoryItemCheckEdit1 });
            this.gridControl1.Size = new Size(0x231, 0x194);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.Columns.AddRange(new GridColumn[] { this.Source, this.Target });
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomRowCellEditForEditing += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.Source.Caption = "源表";
            this.Source.FieldName = "Source";
            this.Source.Name = "Source";
            this.Source.Visible = true;
            this.Source.VisibleIndex = 0;
            this.Target.Caption = "目标表";
            this.Target.ColumnEdit = this.repositoryItemComboBox1;
            this.Target.FieldName = "Target";
            this.Target.Name = "Target";
            this.Target.Visible = true;
            this.Target.VisibleIndex = 1;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.gridControl1);
            base.Name = "DataMatch";
            base.Size = new Size(0x231, 0x194);
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemCheckEdit1.EndInit();
            this.repositoryItemComboBox1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

