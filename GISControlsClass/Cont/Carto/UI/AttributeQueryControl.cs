namespace Cont.Carto.UI
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class AttributeQueryControl : UserControl
    {
        private SimpleButton btnAnd;
        private SimpleButton btnApply;
        private SimpleButton btnBracket;
        private SimpleButton btnClear;
        private SimpleButton btnClose;
        private SimpleButton btnEqual;
        private SimpleButton btnGetUniqueValue;
        private SimpleButton btnGreat;
        private SimpleButton btnGreatEqual;
        private SimpleButton btnIs;
        private SimpleButton btnLike;
        private SimpleButton btnLittle;
        private SimpleButton btnLittleEqual;
        private SimpleButton btnMatchOneChar;
        private SimpleButton btnMatchString;
        private SimpleButton btnNot;
        private SimpleButton btnNotEqual;
        private SimpleButton btnOr;
        private SimpleButton btnValidate;
        private Container components = null;
        private ListBoxControl Fieldlist;
        private Label label2;
        private Label label4;
        private ILayer m_SelLayer = null;
        private string m_strWhereCaluse = "";
        private MemoEdit memEditWhereCaluse;
        private TextEdit textEdit1;
        private ListBoxControl UniqueValuelist;

        public AttributeQueryControl()
        {
            this.InitializeComponent();
        }

        public void Apply()
        {
            if (this.m_SelLayer != null)
            {
                this.m_strWhereCaluse = this.memEditWhereCaluse.Text;
            }
        }

        private void AttributerQueryControl_Load(object sender, EventArgs e)
        {
            this.InitControl();
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.memEditWhereCaluse.Text = "";
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
        }

        private void btnGetUniqueValue_Click(object sender, EventArgs e)
        {
            if (this.Fieldlist.SelectedItem != null)
            {
                this.UniqueValuelist.Enabled = true;
                this.Fieldlist.SelectedItem.ToString();
                this.GetUniqueValues(this.m_SelLayer, this.Fieldlist.SelectedItem.ToString(), this.UniqueValuelist.Items);
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
        }

        public void ClearWhereCaluse()
        {
            this.memEditWhereCaluse.Text = "";
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

        private void Fieldlist_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = this.Fieldlist.SelectedItem as string;
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + selectedItem + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + selectedItem.Length) + 2;
        }

        private void Fieldlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UniqueValuelist.Items.Clear();
            this.UniqueValuelist.Enabled = false;
        }

        private ILayer FindLayer(IBasicMap pMap, string LayerName)
        {
            ILayer layer = null;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                layer = pMap.get_Layer(i);
                if (layer.Name == LayerName)
                {
                    return layer;
                }
            }
            return null;
        }

        public void GetUniqueValues(ILayer pLayer, string sFieldName, ListBoxItemCollection Items)
        {
            try
            {
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
                    ICursor cursor = attributeTable.Search(null, false);
                    IDataStatistics statistics = new DataStatisticsClass();
                    statistics.Field = str;
                    statistics.Cursor = cursor;
                    IEnumerator uniqueValues = statistics.UniqueValues;
                    uniqueValues.Reset();
                    int index = cursor.Fields.FindField(str);
                    esriFieldType type = cursor.Fields.get_Field(index).Type;
                    while (uniqueValues.MoveNext())
                    {
                        Items.Add(this.ConvertFieldValueToString(type, uniqueValues.Current));
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void InitControl()
        {
            if (this.m_SelLayer != null)
            {
                this.textEdit1.Text = "Select * From " + this.m_SelLayer.Name + " Where ";
                this.UpdateFieldList(this.m_SelLayer, this.Fieldlist.Items);
                this.memEditWhereCaluse.Text = this.m_strWhereCaluse;
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
                this.UniqueValuelist.Items.Clear();
                this.UniqueValuelist.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            this.label2 = new Label();
            this.btnMatchString = new SimpleButton();
            this.btnIs = new SimpleButton();
            this.btnNot = new SimpleButton();
            this.btnBracket = new SimpleButton();
            this.btnMatchOneChar = new SimpleButton();
            this.btnOr = new SimpleButton();
            this.btnLittleEqual = new SimpleButton();
            this.btnLittle = new SimpleButton();
            this.btnAnd = new SimpleButton();
            this.btnLike = new SimpleButton();
            this.btnGreat = new SimpleButton();
            this.btnNotEqual = new SimpleButton();
            this.btnGreatEqual = new SimpleButton();
            this.btnEqual = new SimpleButton();
            this.btnClose = new SimpleButton();
            this.btnApply = new SimpleButton();
            this.memEditWhereCaluse = new MemoEdit();
            this.textEdit1 = new TextEdit();
            this.Fieldlist = new ListBoxControl();
            this.label4 = new Label();
            this.UniqueValuelist = new ListBoxControl();
            this.btnGetUniqueValue = new SimpleButton();
            this.btnClear = new SimpleButton();
            this.btnValidate = new SimpleButton();
            this.memEditWhereCaluse.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            ((ISupportInitialize) this.Fieldlist).BeginInit();
            ((ISupportInitialize) this.UniqueValuelist).BeginInit();
            base.SuspendLayout();
            this.label2.Location = new Point(0x10, 8);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x30, 0x10);
            this.label2.TabIndex = 0x2b;
            this.label2.Text = "字段";
            this.btnMatchString.Location = new Point(0x90, 120);
            this.btnMatchString.Name = "btnMatchString";
            this.btnMatchString.Size = new Size(0x10, 0x18);
            this.btnMatchString.TabIndex = 0x2a;
            this.btnMatchString.Text = "%";
            this.btnMatchString.Click += new EventHandler(this.btnMatchString_Click);
            this.btnIs.Location = new Point(0x80, 0x98);
            this.btnIs.Name = "btnIs";
            this.btnIs.Size = new Size(0x20, 0x18);
            this.btnIs.TabIndex = 0x29;
            this.btnIs.Text = "&Is";
            this.btnIs.Click += new EventHandler(this.btnIs_Click);
            this.btnNot.Location = new Point(0xd0, 120);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new Size(0x20, 0x18);
            this.btnNot.TabIndex = 40;
            this.btnNot.Text = "&Not";
            this.btnNot.Click += new EventHandler(this.btnNot_Click);
            this.btnBracket.Location = new Point(0xa8, 120);
            this.btnBracket.Name = "btnBracket";
            this.btnBracket.Size = new Size(0x20, 0x18);
            this.btnBracket.TabIndex = 0x27;
            this.btnBracket.Text = "()";
            this.btnBracket.Click += new EventHandler(this.btnBracket_Click);
            this.btnMatchOneChar.Location = new Point(0x80, 120);
            this.btnMatchOneChar.Name = "btnMatchOneChar";
            this.btnMatchOneChar.Size = new Size(0x10, 0x18);
            this.btnMatchOneChar.TabIndex = 0x26;
            this.btnMatchOneChar.Text = "_";
            this.btnMatchOneChar.Click += new EventHandler(this.btnMatchOneChar_Click);
            this.btnOr.Location = new Point(0xd0, 0x58);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new Size(0x20, 0x18);
            this.btnOr.TabIndex = 0x25;
            this.btnOr.Text = "&Or";
            this.btnOr.Click += new EventHandler(this.btnOr_Click);
            this.btnLittleEqual.Location = new Point(0xa8, 0x58);
            this.btnLittleEqual.Name = "btnLittleEqual";
            this.btnLittleEqual.Size = new Size(0x20, 0x18);
            this.btnLittleEqual.TabIndex = 0x24;
            this.btnLittleEqual.Text = "<=";
            this.btnLittleEqual.Click += new EventHandler(this.btnLittleEqual_Click);
            this.btnLittle.Location = new Point(0x80, 0x58);
            this.btnLittle.Name = "btnLittle";
            this.btnLittle.Size = new Size(0x20, 0x18);
            this.btnLittle.TabIndex = 0x23;
            this.btnLittle.Text = "<";
            this.btnLittle.Click += new EventHandler(this.btnLittle_Click);
            this.btnAnd.Location = new Point(0xd0, 0x38);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new Size(0x20, 0x18);
            this.btnAnd.TabIndex = 0x22;
            this.btnAnd.Text = "&And";
            this.btnAnd.Click += new EventHandler(this.btnAnd_Click);
            this.btnLike.Location = new Point(0xd0, 0x18);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new Size(0x20, 0x18);
            this.btnLike.TabIndex = 0x21;
            this.btnLike.Text = "Li&ke";
            this.btnLike.Click += new EventHandler(this.btnLike_Click);
            this.btnGreat.Location = new Point(0x80, 0x38);
            this.btnGreat.Name = "btnGreat";
            this.btnGreat.Size = new Size(0x20, 0x18);
            this.btnGreat.TabIndex = 0x20;
            this.btnGreat.Text = ">";
            this.btnGreat.Click += new EventHandler(this.btnGreat_Click);
            this.btnNotEqual.Location = new Point(0xa8, 0x18);
            this.btnNotEqual.Name = "btnNotEqual";
            this.btnNotEqual.Size = new Size(0x20, 0x18);
            this.btnNotEqual.TabIndex = 0x1f;
            this.btnNotEqual.Text = "<>";
            this.btnNotEqual.Click += new EventHandler(this.btnNotEqual_Click);
            this.btnGreatEqual.Location = new Point(0xa8, 0x38);
            this.btnGreatEqual.Name = "btnGreatEqual";
            this.btnGreatEqual.Size = new Size(0x20, 0x18);
            this.btnGreatEqual.TabIndex = 30;
            this.btnGreatEqual.Text = ">=";
            this.btnGreatEqual.Click += new EventHandler(this.btnGreatEqual_Click);
            this.btnEqual.Location = new Point(0x80, 0x18);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new Size(0x20, 0x18);
            this.btnEqual.TabIndex = 0x1d;
            this.btnEqual.Text = "=";
            this.btnEqual.Click += new EventHandler(this.btnEqual_Click);
            this.btnClose.Location = new Point(200, 0xb0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x38, 0x18);
            this.btnClose.TabIndex = 0x1c;
            this.btnClose.Text = "关闭";
            this.btnClose.Visible = false;
            this.btnApply.Location = new Point(0x88, 0xb0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new Size(0x38, 0x18);
            this.btnApply.TabIndex = 0x1b;
            this.btnApply.Text = "应用";
            this.btnApply.Visible = false;
            this.memEditWhereCaluse.EditValue = "";
            this.memEditWhereCaluse.Location = new Point(0x10, 0xe8);
            this.memEditWhereCaluse.Name = "memEditWhereCaluse";
            this.memEditWhereCaluse.Size = new Size(0x160, 0x68);
            this.memEditWhereCaluse.TabIndex = 0x1a;
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new Point(0x18, 200);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.BorderStyle = BorderStyles.NoBorder;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new Size(0x158, 0x13);
            this.textEdit1.TabIndex = 0x19;
            this.Fieldlist.ItemHeight = 15;
            this.Fieldlist.Location = new Point(0x10, 0x18);
            this.Fieldlist.Name = "Fieldlist";
            this.Fieldlist.Size = new Size(0x68, 160);
            this.Fieldlist.TabIndex = 0x18;
            this.Fieldlist.DoubleClick += new EventHandler(this.Fieldlist_DoubleClick);
            this.Fieldlist.SelectedIndexChanged += new EventHandler(this.Fieldlist_SelectedIndexChanged);
            this.label4.Location = new Point(0xf8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x38, 0x10);
            this.label4.TabIndex = 0x30;
            this.label4.Text = "唯一值";
            this.UniqueValuelist.Enabled = false;
            this.UniqueValuelist.ItemHeight = 15;
            this.UniqueValuelist.Location = new Point(0xf8, 0x18);
            this.UniqueValuelist.Name = "UniqueValuelist";
            this.UniqueValuelist.Size = new Size(120, 0x88);
            this.UniqueValuelist.TabIndex = 0x2f;
            this.UniqueValuelist.DoubleClick += new EventHandler(this.UniqueValuelist_DoubleClick);
            this.btnGetUniqueValue.Location = new Point(0xf8, 0xa8);
            this.btnGetUniqueValue.Name = "btnGetUniqueValue";
            this.btnGetUniqueValue.Size = new Size(120, 0x18);
            this.btnGetUniqueValue.TabIndex = 0x31;
            this.btnGetUniqueValue.Text = "获取唯一值";
            this.btnGetUniqueValue.Click += new EventHandler(this.btnGetUniqueValue_Click);
            this.btnClear.Location = new Point(8, 0xb0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x38, 0x18);
            this.btnClear.TabIndex = 50;
            this.btnClear.Text = "清除";
            this.btnClear.Visible = false;
            this.btnValidate.Location = new Point(0x48, 0xb0);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new Size(0x38, 0x18);
            this.btnValidate.TabIndex = 0x33;
            this.btnValidate.Text = "验证";
            this.btnValidate.Visible = false;
            base.Controls.Add(this.btnValidate);
            base.Controls.Add(this.btnClear);
            base.Controls.Add(this.btnGetUniqueValue);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.UniqueValuelist);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.btnMatchString);
            base.Controls.Add(this.btnIs);
            base.Controls.Add(this.btnNot);
            base.Controls.Add(this.btnBracket);
            base.Controls.Add(this.btnMatchOneChar);
            base.Controls.Add(this.btnOr);
            base.Controls.Add(this.btnLittleEqual);
            base.Controls.Add(this.btnLittle);
            base.Controls.Add(this.btnAnd);
            base.Controls.Add(this.btnLike);
            base.Controls.Add(this.btnGreat);
            base.Controls.Add(this.btnNotEqual);
            base.Controls.Add(this.btnGreatEqual);
            base.Controls.Add(this.btnEqual);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnApply);
            base.Controls.Add(this.memEditWhereCaluse);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.Fieldlist);
            base.Name = "AttributeQueryControl";
            base.Size = new Size(0x180, 0x160);
            base.Load += new EventHandler(this.AttributerQueryControl_Load);
            this.memEditWhereCaluse.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            ((ISupportInitialize) this.Fieldlist).EndInit();
            ((ISupportInitialize) this.UniqueValuelist).EndInit();
            base.ResumeLayout(false);
        }

        private void UniqueValuelist_DoubleClick(object sender, EventArgs e)
        {
            string selectedItem = this.UniqueValuelist.SelectedItem as string;
            string text = this.memEditWhereCaluse.Text;
            int selectionStart = this.memEditWhereCaluse.SelectionStart;
            this.memEditWhereCaluse.Focus();
            this.memEditWhereCaluse.Text = text.Insert(selectionStart, " " + selectedItem + " ");
            this.memEditWhereCaluse.SelectedText = "";
            this.memEditWhereCaluse.SelectionStart = (selectionStart + selectedItem.Length) + 2;
        }

        private void UpdateFieldList(ILayer pLayer, ListBoxItemCollection Items)
        {
            Items.Clear();
            IAttributeTable table = pLayer as IAttributeTable;
            if (table != null)
            {
                ITable attributeTable = table.AttributeTable;
                string str = "";
                string str2 = "";
                if ((attributeTable as IDataset).Workspace.Type == esriWorkspaceType.esriLocalDatabaseWorkspace)
                {
                    str = "[";
                    str2 = "]";
                }
                IFields fields = attributeTable.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if ((field.Type != esriFieldType.esriFieldTypeGeometry) && (field.Type != esriFieldType.esriFieldTypeBlob))
                    {
                        Items.Add(str + field.Name + str2);
                    }
                }
            }
        }

        public ILayer CurrentLayer
        {
            set
            {
                this.m_SelLayer = value;
            }
        }

        public string WhereCaluse
        {
            get
            {
                return this.memEditWhereCaluse.Text;
            }
            set
            {
                this.m_strWhereCaluse = value;
            }
        }
    }
}

