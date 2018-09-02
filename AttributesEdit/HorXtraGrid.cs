namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.Collections;
    using System.Data;

    public class HorXtraGrid
    {
        private GridControl _xGrid;
        private GridView _xGridView;
        private DataTable _xTable;
        private RepositoryItemButtonEdit repositoryItemButtonEdit;
        private ZLRepositoryItemComboBox repositoryItemComboBox;
        private RepositoryItemDateEdit repositoryItemDateEdit;
        private ZLRepositoryItemSpinEdit repositoryItemSpinEdit;
        private RepositoryItemTextEdit repositoryItemTextEdit;

        public HorXtraGrid(GridControl xGrid1)
        {
            this._xGrid = xGrid1;
            this._xGridView = (GridView) this._xGrid.MainView;
            this.Init();
        }

        public RepositoryItemButtonEdit AddButtonColumn(string sColumnName, string sCaption, string sButtonCaption, int visibleIndex, bool ReadOnly, int iWidth)
        {
            this.repositoryItemButtonEdit = new RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit.AutoHeight = false;
            this.repositoryItemButtonEdit.Name = "repositoryItemButtonEdit";
            this.repositoryItemButtonEdit.ReadOnly = ReadOnly;
            this.repositoryItemButtonEdit.ButtonsStyle = BorderStyles.Flat;
            this.repositoryItemButtonEdit.Buttons[0].Caption = sButtonCaption;
            this.repositoryItemButtonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
            this.repositoryItemButtonEdit.Buttons[0].Visible = true;
            this.repositoryItemButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemButtonEdit
            };
            this._xGridView.Columns.Add(column);
            return this.repositoryItemButtonEdit;
        }

        public void AddComboBoxColumn(string sColumnName, string sCaption, IList nameList, IList valueList, int visibleIndex, bool ReadOnly, int iWidth, string[] pReadOnlyItems)
        {
            this.repositoryItemComboBox = new ZLRepositoryItemComboBox();
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemComboBox.NameItems = nameList;
            this.repositoryItemComboBox.ValueItems = valueList;
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            this.repositoryItemComboBox.ReadOnly = ReadOnly;
            this.repositoryItemComboBox.ReadOnlyItems = pReadOnlyItems;
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemComboBox
            };
            this._xGridView.Columns.Add(column);
            DataColumn column2 = new DataColumn(sColumnName, typeof(string)) {
                Caption = sColumnName
            };
            this._xTable.Columns.Add(column2);
        }

        public void AddDateColumn(string sColumnName, string sCaption, int visibleIndex, bool ReadOnly, int iWidth)
        {
            this.repositoryItemDateEdit = new RepositoryItemDateEdit();
            this.repositoryItemDateEdit.AutoHeight = false;
            this.repositoryItemDateEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemDateEdit.Mask.EditMask = "d";
            this.repositoryItemDateEdit.Mask.MaskType = MaskType.DateTime;
            this.repositoryItemDateEdit.Name = "repositoryItemDateEdit";
            this.repositoryItemDateEdit.ReadOnly = ReadOnly;
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemDateEdit
            };
            this._xGridView.Columns.Add(column);
            DataColumn column2 = new DataColumn(sColumnName, typeof(string)) {
                Caption = sColumnName
            };
            this._xTable.Columns.Add(column2);
        }

        public void AddOIDColumn(string sColumnName, string sCaption, int visibleIndex, bool ReadOnly, int iWidth)
        {
            this.repositoryItemTextEdit = new RepositoryItemTextEdit();
            this.repositoryItemTextEdit.AutoHeight = false;
            this.repositoryItemTextEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemTextEdit.Name = "ModalCodeTextEdit";
            this.repositoryItemTextEdit.ReadOnly = ReadOnly;
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemTextEdit
            };
            this._xGridView.Columns.Add(column);
            DataColumn column2 = new DataColumn(sColumnName, typeof(int)) {
                Caption = sColumnName
            };
            this._xTable.Columns.Add(column2);
        }

        public void AddSpinColumn1(string sColumnName, string sCaption, int visibleIndex, double MinValue, double MaxValue, bool ReadOnly, bool bFloat, int iDecim, int iWidth)
        {
            this.repositoryItemSpinEdit = new ZLRepositoryItemSpinEdit();
            this.repositoryItemSpinEdit.AutoHeight = false;
            this.repositoryItemSpinEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemSpinEdit.Mask.MaskType = MaskType.Numeric;
            this.repositoryItemSpinEdit.Name = "repositoryItemSpinEdit";
            this.repositoryItemSpinEdit.ReadOnly = ReadOnly;
            this.repositoryItemSpinEdit.MaxValue = (decimal) MaxValue;
            this.repositoryItemSpinEdit.MinValue = (decimal) MinValue;
            this.repositoryItemSpinEdit.IsFloatValue = bFloat;
            this.repositoryItemSpinEdit.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            this.repositoryItemSpinEdit.EditScale = iDecim;
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemSpinEdit
            };
            this._xGridView.Columns.Add(column);
            DataColumn column2 = new DataColumn(sColumnName, typeof(double)) {
                Caption = sColumnName
            };
            this._xTable.Columns.Add(column2);
        }

        public void AddTextColumn(string sColumnName, string sCaption, int visibleIndex, bool ReadOnly, int iLength, int iWidth)
        {
            this.repositoryItemTextEdit = new RepositoryItemTextEdit();
            this.repositoryItemTextEdit.AutoHeight = false;
            this.repositoryItemTextEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemTextEdit.Name = "ModalCodeTextEdit";
            this.repositoryItemTextEdit.ReadOnly = ReadOnly;
            if (iLength > 0)
            {
                this.repositoryItemTextEdit.MaxLength = iLength;
            }
            GridColumn column = new GridColumn {
                FieldName = sColumnName,
                Caption = sCaption,
                VisibleIndex = visibleIndex,
                Width = iWidth,
                ColumnEdit = this.repositoryItemTextEdit
            };
            this._xGridView.Columns.Add(column);
            DataColumn column2 = new DataColumn(sColumnName, typeof(string)) {
                Caption = sColumnName
            };
            this._xTable.Columns.Add(column2);
        }

        public void Clear()
        {
            this._xTable.Clear();
            this._xTable.Columns.Clear();
            this._xGridView.Columns.Clear();
            this._xGrid.RefreshDataSource();
        }

        public void ClearData()
        {
            this._xTable.Clear();
            this._xGrid.RefreshDataSource();
        }

        public DataRow CreateRow()
        {
            DataRow row = this._xTable.NewRow();
            this._xTable.Rows.Add(row);
            this._xGrid.RefreshDataSource();
            return row;
        }

        public int DeleteSelectedRows()
        {
            int[] selectedRows = this._xGridView.GetSelectedRows();
            if (selectedRows == null)
            {
                return 0;
            }
            if (selectedRows.Length < 1)
            {
                return 0;
            }
            int length = selectedRows.Length;
            for (int i = 0; i < length; i++)
            {
                this._xTable.Rows.RemoveAt(selectedRows[i]);
            }
            return length;
        }

        private void Init()
        {
            this._xTable = new DataTable();
        }

        public void RefreshDataSource()
        {
            this._xGrid.DataSource = this._xTable;
            this._xGrid.RefreshDataSource();
        }

        public DataTable DataSource
        {
            get
            {
                return this._xTable;
            }
            set
            {
                this._xTable = value;
                this._xGrid.DataSource = this._xTable;
                this._xGrid.RefreshDataSource();
            }
        }
    }
}

