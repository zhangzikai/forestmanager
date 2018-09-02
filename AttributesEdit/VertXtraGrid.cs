namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;
    using System;
    using System.Collections;
    using System.Data;
    using System.Drawing;

    public class VertXtraGrid
    {
        private string _gridEditorName;
        private string _gridEditorValue;
        private GridControl _xGrid;
        private GridView _xGridView;
        private GridColumn gridEditorName;
        private GridEditorCollection gridEditors;
        private GridColumn gridEditorValue;
        private RepositoryItemButtonEdit repositoryItemButtonEdit;
        private RepositoryItemCalcEdit repositoryItemCalcEdit;
        private RepositoryItemCheckEdit repositoryItemCheckEdit;
        private RepositoryItemColorEdit repositoryItemColorEdit;
        private ZLRepositoryItemComboBox repositoryItemComboBox;
        private RepositoryItemDateEdit repositoryItemDateEdit;
        private RepositoryItemImageEdit repositoryItemImageEdit;
        private RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private RepositoryItemMemoEdit repositoryItemMemoEdit;
        private RepositoryItemMemoExEdit repositoryItemMemoExEdit;
        private ZLRepositoryItemSpinEdit repositoryItemSpinEdit;
        private RepositoryItemTextEdit repositoryItemTextEdit;
        private RepositoryItemTimeEdit repositoryItemTimeEdit;

        public VertXtraGrid(GridControl xGrid1)
        {
            this._xGrid = xGrid1;
            this._xGridView = (GridView) this._xGrid.MainView;
            this.gridEditorName = new GridColumn();
            this.gridEditorValue = new GridColumn();
            this.Init();
            this.gridEditors = new GridEditorCollection();
            this._xGrid.DataSource = this.gridEditors;
        }

        public void AddButtonEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemButtonEdit = new RepositoryItemButtonEdit();
            this.gridEditors.Add(this.repositoryItemButtonEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemButtonEdit.AutoHeight = false;
            this.repositoryItemButtonEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemButtonEdit.Name = "repositoryItemButtonEdit";
            this.repositoryItemButtonEdit.ReadOnly = ReadOnly;
        }

        public RepositoryItemButtonEdit AddButtonEdit1(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemButtonEdit = new RepositoryItemButtonEdit();
            this.gridEditors.Add(this.repositoryItemButtonEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemButtonEdit.AutoHeight = false;
            this.repositoryItemButtonEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemButtonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit.Name = "repositoryItemButtonEdit";
            this.repositoryItemButtonEdit.ReadOnly = ReadOnly;
            return this.repositoryItemButtonEdit;
        }

        public void AddCalcEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemCalcEdit = new RepositoryItemCalcEdit();
            this.gridEditors.Add(this.repositoryItemCalcEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemCalcEdit.AutoHeight = false;
            this.repositoryItemCalcEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemCalcEdit.Mask.MaskType = MaskType.Numeric;
            this.repositoryItemCalcEdit.Name = "repositoryItemCalcEdit";
        }

        public void AddCheckEdit(string ColumnName, bool ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemCheckEdit = new RepositoryItemCheckEdit();
            this.gridEditors.Add(this.repositoryItemCheckEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemCheckEdit.AutoHeight = false;
            this.repositoryItemCheckEdit.Name = "repositoryItemCheckEdit";
            this.repositoryItemCheckEdit.ReadOnly = ReadOnly;
        }

        public void AddColorEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemColorEdit = new RepositoryItemColorEdit();
            this.gridEditors.Add(this.repositoryItemColorEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemColorEdit.AutoHeight = false;
            this.repositoryItemColorEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemColorEdit.Name = "repositoryItemColorEdit";
            this.repositoryItemColorEdit.ReadOnly = ReadOnly;
        }

        public void AddComBoBox(string ColumnName, object ColumnValue, IList nameList, IList valueList, bool ReadOnly, object tag, string[] pReadOnlyItems)
        {
            this.repositoryItemComboBox = new ZLRepositoryItemComboBox();
            this.gridEditors.Add(this.repositoryItemComboBox, ColumnName, ColumnValue, tag);
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemComboBox.SelectedValue = ColumnValue;
            this.repositoryItemComboBox.NameItems = nameList;
            this.repositoryItemComboBox.ValueItems = valueList;
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            this.repositoryItemComboBox.ReadOnly = ReadOnly;
            this.repositoryItemComboBox.ReadOnlyItems = pReadOnlyItems;
        }

        public void AddDateEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemDateEdit = new RepositoryItemDateEdit();
            this.gridEditors.Add(this.repositoryItemDateEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemDateEdit.AutoHeight = false;
            this.repositoryItemDateEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemDateEdit.Mask.EditMask = "d";
            this.repositoryItemDateEdit.Mask.MaskType = MaskType.DateTime;
            this.repositoryItemDateEdit.Name = "repositoryItemDateEdit";
            this.repositoryItemDateEdit.ReadOnly = ReadOnly;
        }

        public void AddImageEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemImageEdit = new RepositoryItemImageEdit();
            this.gridEditors.Add(this.repositoryItemImageEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemImageEdit.AutoHeight = false;
            this.repositoryItemImageEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemImageEdit.Name = "repositoryItemImageEdit";
            this.repositoryItemImageEdit.PopupStartSize = new Size(250, 300);
        }

        public void AddLookUpEdit(DataTable dataTableLookup, string ColumnName, object sDisplayMember, object sValueMember, object pDisplayMember, object pValueMember, bool ReadOnly)
        {
            this.repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
            this.gridEditors.Add(this.repositoryItemLookUpEdit, ColumnName, sDisplayMember);
            this.repositoryItemLookUpEdit.AutoHeight = false;
            this.repositoryItemLookUpEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemLookUpEdit.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo((string) pDisplayMember, (string) pDisplayMember, 160, FormatType.None, "", true, HorzAlignment.Near), new LookUpColumnInfo((string) sDisplayMember, (string) sValueMember, 140, FormatType.None, "", true, HorzAlignment.Near) });
            this.repositoryItemLookUpEdit.DataSource = dataTableLookup;
            this.repositoryItemLookUpEdit.DisplayMember = (string) pDisplayMember;
            this.repositoryItemLookUpEdit.Name = "repositoryItemLookUpEdit";
            this.repositoryItemLookUpEdit.PopupWidth = 290;
            this.repositoryItemLookUpEdit.ValueMember = (string) pValueMember;
        }

        public void AddMemoEdit(string ColumnName, object ColumnValue, bool ReadOnly)
        {
            this.repositoryItemMemoEdit = new RepositoryItemMemoEdit();
            this.gridEditors.Add(this.repositoryItemMemoEdit, ColumnName, ColumnValue);
            this.repositoryItemMemoEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemMemoEdit.Name = "repositoryItemMemoEdit";
            this.repositoryItemMemoEdit.WordWrap = true;
            this.repositoryItemMemoEdit.ReadOnly = ReadOnly;
        }

        public void AddMemoExEdit(string ColumnName, object ColumnValue, bool ReadOnly)
        {
            this.repositoryItemMemoExEdit = new RepositoryItemMemoExEdit();
            this.gridEditors.Add(this.repositoryItemMemoExEdit, ColumnName, ColumnValue);
            this.repositoryItemMemoExEdit.AutoHeight = false;
            this.repositoryItemMemoExEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemMemoExEdit.Name = "repositoryItemMemoExEdit";
            this.repositoryItemMemoExEdit.PopupStartSize = new Size(250, 150);
            this.repositoryItemMemoExEdit.ReadOnly = ReadOnly;
        }

        public void AddSpinEdit(string ColumnName, object ColumnValue, bool ReadOnly, double MinValue, double MaxValue, bool bFloat, int iDecim, object tag)
        {
            this.repositoryItemSpinEdit = new ZLRepositoryItemSpinEdit();
            this.gridEditors.Add(this.repositoryItemSpinEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemSpinEdit.AutoHeight = false;
            this.repositoryItemSpinEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemSpinEdit.Mask.MaskType = MaskType.Numeric;
            this.repositoryItemSpinEdit.Name = "repositoryItemSpinEdit";
            this.repositoryItemSpinEdit.ReadOnly = ReadOnly;
            this.repositoryItemSpinEdit.MaxValue = (decimal) MaxValue;
            this.repositoryItemSpinEdit.MinValue = (decimal) MinValue;
            this.repositoryItemSpinEdit.IsFloatValue = bFloat;
            this.repositoryItemSpinEdit.EditScale = iDecim;
        }

        public void AddTextEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag, int iLength)
        {
            this.repositoryItemTextEdit = new RepositoryItemTextEdit();
            this.gridEditors.Add(this.repositoryItemTextEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemTextEdit.AutoHeight = false;
            this.repositoryItemTextEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemTextEdit.Name = "repositoryItemTextEdit";
            this.repositoryItemTextEdit.ReadOnly = ReadOnly;
            if (iLength > 0)
            {
                this.repositoryItemTextEdit.MaxLength = iLength;
            }
        }

        public RepositoryItemTextEdit AddTextEdit1(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemTextEdit = new RepositoryItemTextEdit();
            this.gridEditors.Add(this.repositoryItemTextEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemTextEdit.AutoHeight = false;
            this.repositoryItemTextEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemTextEdit.Name = "ModalCodeTextEdit";
            this.repositoryItemTextEdit.ReadOnly = ReadOnly;
            return this.repositoryItemTextEdit;
        }

        public void AddTimeEdit(string ColumnName, object ColumnValue, bool ReadOnly, object tag)
        {
            this.repositoryItemTimeEdit = new RepositoryItemTimeEdit();
            this.gridEditors.Add(this.repositoryItemTimeEdit, ColumnName, ColumnValue, tag);
            this.repositoryItemTimeEdit.AutoHeight = false;
            this.repositoryItemTimeEdit.BorderStyle = BorderStyles.NoBorder;
            this.repositoryItemTimeEdit.Mask.EditMask = "T";
            this.repositoryItemTimeEdit.Mask.MaskType = MaskType.DateTime;
            this.repositoryItemTimeEdit.Name = "repositoryItemTimeEdit";
        }

        public void ChangeItem(int nRowIndex, ColumnAttribute att, object array, double min, double max)
        {
            GridEditorItem item = this.gridEditors[nRowIndex];
            RepositoryItem repositoryItem = item.RepositoryItem;
            if (att == ColumnAttribute.CA_COMBOBOX)
            {
                this.repositoryItemComboBox = new ZLRepositoryItemComboBox();
                this.repositoryItemComboBox.AutoHeight = false;
                this.repositoryItemComboBox.BorderStyle = BorderStyles.NoBorder;
                for (int i = 0; i < ((IList) array).Count; i++)
                {
                    this.repositoryItemComboBox.Items.Add(((IList) array)[i]);
                }
                this.repositoryItemComboBox.Name = "repositoryItemComboBox";
                this.repositoryItemComboBox.ReadOnly = repositoryItem.ReadOnly;
                item.RepositoryItem = this.repositoryItemComboBox;
            }
            else if (repositoryItem is RepositoryItemComboBox)
            {
                if (att == ColumnAttribute.CA_TEXTEDIT)
                {
                    this.repositoryItemTextEdit = new RepositoryItemTextEdit();
                    this.repositoryItemTextEdit.AutoHeight = false;
                    this.repositoryItemTextEdit.BorderStyle = BorderStyles.NoBorder;
                    this.repositoryItemTextEdit.Name = "repositoryItemTextEdit";
                    this.repositoryItemTextEdit.ReadOnly = repositoryItem.ReadOnly;
                    item.RepositoryItem = this.repositoryItemTextEdit;
                }
                else if (att == ColumnAttribute.CA_SPINEDIT)
                {
                    this.repositoryItemSpinEdit = new ZLRepositoryItemSpinEdit();
                    this.repositoryItemSpinEdit.AutoHeight = false;
                    this.repositoryItemSpinEdit.BorderStyle = BorderStyles.NoBorder;
                    this.repositoryItemSpinEdit.Mask.MaskType = MaskType.Numeric;
                    this.repositoryItemSpinEdit.Name = "repositoryItemSpinEdit";
                    this.repositoryItemSpinEdit.ReadOnly = repositoryItem.ReadOnly;
                    this.repositoryItemSpinEdit.MaxValue = (decimal) max;
                    this.repositoryItemSpinEdit.MinValue = (decimal) min;
                    item.RepositoryItem = this.repositoryItemSpinEdit;
                }
            }
        }

        public void Clear()
        {
            this.gridEditors.Clear();
            this._xGrid.RefreshDataSource();
        }

        public void DeleteRow(object obj)
        {
            this.gridEditors.Remove(obj);
            this._xGrid.RefreshDataSource();
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == this.gridEditorValue)
            {
                GridEditorItem row = this._xGridView.GetRow(e.RowHandle) as GridEditorItem;
                if (row != null)
                {
                    e.RepositoryItem = row.RepositoryItem;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this._xGridView.GetRow(e.FocusedRowHandle);
        }

        private void Init()
        {
            this._xGridView.Columns.AddRange(new GridColumn[] { this.gridEditorName, this.gridEditorValue });
            this._xGridView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this._xGridView.CustomRowCellEdit += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            if ((this._gridEditorName == null) || (this._gridEditorName.Trim() == ""))
            {
                this._gridEditorName = "字段";
            }
            this.gridEditorName.Caption = this._gridEditorName;
            this.gridEditorName.FieldName = "Name";
            this.gridEditorName.Name = "gridEditorName";
            this.gridEditorName.OptionsColumn.AllowEdit = false;
            this.gridEditorName.OptionsColumn.AllowGroup = DefaultBoolean.False;
            this.gridEditorName.OptionsColumn.ReadOnly = true;
            this.gridEditorName.OptionsFilter.AllowAutoFilter = false;
            this.gridEditorName.OptionsFilter.AllowFilter = false;
            this.gridEditorName.Visible = true;
            this.gridEditorName.VisibleIndex = 0;
            this.gridEditorName.Width = 150;
            if ((this._gridEditorValue == null) || (this._gridEditorValue.Trim() == ""))
            {
                this._gridEditorValue = "值";
            }
            this.gridEditorValue.Caption = this._gridEditorValue;
            this.gridEditorValue.FieldName = "Value";
            this.gridEditorValue.Name = "gridEditorValue";
            this.gridEditorValue.OptionsColumn.AllowGroup = DefaultBoolean.False;
            this.gridEditorValue.OptionsColumn.AllowSort = DefaultBoolean.False;
            this.gridEditorValue.OptionsFilter.AllowAutoFilter = false;
            this.gridEditorValue.OptionsFilter.AllowFilter = false;
            this.gridEditorValue.Visible = true;
            this.gridEditorValue.VisibleIndex = 1;
            this.gridEditorValue.Width = 0xea;
        }

        public string EditorName
        {
            get
            {
                return this._gridEditorName;
            }
            set
            {
                this._gridEditorName = value;
            }
        }

        public string EditorValue
        {
            get
            {
                return this._gridEditorValue;
            }
            set
            {
                this._gridEditorValue = value;
            }
        }
    }
}

