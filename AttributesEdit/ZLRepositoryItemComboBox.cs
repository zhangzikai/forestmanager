namespace AttributesEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class ZLRepositoryItemComboBox : RepositoryItemComboBox
    {
        private IContainer components;
        private RepositoryItemComboBox fProperties;
        private IList m_NameList;
        private IList m_NameList0;
        private string[] m_ReadOnlyItems;
        private int m_SelectedIndex = -1;
        private object m_SelectedValue = DBNull.Value;
        private IList m_ValueList;
        private IList m_ValueList0;

        public ZLRepositoryItemComboBox()
        {
            this.InitializeComponent();
        }

        public void ClearCombobox()
        {
            if (this.m_NameList != null)
            {
                this.m_NameList.Clear();
            }
            if (this.m_ValueList != null)
            {
                this.m_ValueList.Clear();
            }
            this.m_ValueList.Add(this.m_ValueList0[0]);
            this.m_NameList.Add(this.m_NameList0[0]);
            this.FillComboBox();
        }

        public void ClearItems()
        {
            if (this.m_NameList != null)
            {
                this.m_NameList.Clear();
            }
            if (this.m_ValueList != null)
            {
                this.m_ValueList.Clear();
            }
            this.FillComboBox();
            this.m_ValueList0 = new ArrayList();
            this.m_NameList0 = new ArrayList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillComboBox()
        {
            RepositoryItemComboBox box = this;
            box.Items.Clear();
            for (int i = 0; i < this.m_NameList.Count; i++)
            {
                box.Items.Add(this.m_NameList[i]);
                if (this.m_NameList[i].ToString() == this.m_SelectedValue.ToString())
                {
                    this.m_SelectedIndex = i;
                }
            }
            if ((this.m_SelectedValue == DBNull.Value) || (this.m_SelectedValue.ToString() == ""))
            {
                this.m_SelectedIndex = 0;
            }
        }

        public void Filter(string sFilterValue)
        {
            IList list = new ArrayList();
            IList list2 = new ArrayList();
            list.Add(this.m_ValueList0[0]);
            list2.Add(this.m_NameList0[0]);
            if (sFilterValue != "")
            {
                for (int i = 1; i < this.m_ValueList0.Count; i++)
                {
                    if (this.m_ValueList0[i].ToString().IndexOf(sFilterValue) == 0)
                    {
                        list2.Add(this.m_NameList0[i]);
                        list.Add(this.m_ValueList0[i]);
                    }
                }
            }
            this.m_ValueList = list;
            this.m_NameList = list2;
            this.FillComboBox();
        }

        public object GetValue(int index)
        {
            if (index >= 0)
            {
                return this.m_ValueList[index];
            }
            return DBNull.Value;
        }

        private void InitializeComponent()
        {
            this.fProperties = new RepositoryItemComboBox();
            this.fProperties.BeginInit();
            this.fProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.fProperties.Name = "fProperties";
            this.fProperties.EndInit();
        }

        private void ZLRepositoryItemComboBox_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            string str = e.Item.ToString();
            if ((this.m_ReadOnlyItems != null) && this.m_ReadOnlyItems.Contains<string>(str))
            {
                e.Appearance.BackColor = Color.FromArgb(240, 240, 240);
                e.Appearance.ForeColor = Color.Gray;
            }
            else if (e.State == DrawItemState.Selected)
            {
                e.Appearance.BackColor = Color.FromArgb(0x33, 0x99, 0xff);
            }
            else
            {
                e.Appearance.BackColor = Color.White;
            }
        }

        private void ZLRepositoryItemComboBox_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((this.m_ReadOnlyItems != null) && this.m_ReadOnlyItems.Contains<string>(e.NewValue.ToString()))
            {
                e.Cancel = true;
                ((ComboBoxEdit) sender).Refresh();
            }
        }

        private void ZLRepositoryItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit edit = (ComboBoxEdit) sender;
            this.m_SelectedIndex = edit.SelectedIndex;
        }

        public IList NameItems
        {
            set
            {
                this.m_NameList0 = value;
                this.m_NameList = new ArrayList();
                for (int i = 0; i < this.m_NameList0.Count; i++)
                {
                    this.m_NameList.Add(this.m_NameList0[i]);
                }
                this.FillComboBox();
            }
        }

        public string[] ReadOnlyItems
        {
            get
            {
                return this.m_ReadOnlyItems;
            }
            set
            {
                this.m_ReadOnlyItems = value;
                base.EditValueChanging += new ChangingEventHandler(this.ZLRepositoryItemComboBox_EditValueChanging);
                base.DrawItem += new ListBoxDrawItemEventHandler(this.ZLRepositoryItemComboBox_DrawItem);
                base.SelectedIndexChanged += new EventHandler(this.ZLRepositoryItemComboBox_SelectedIndexChanged);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.m_SelectedIndex;
            }
            set
            {
                this.m_SelectedIndex = value;
            }
        }

        public object SelectedValue
        {
            get
            {
                if (this.m_ValueList == null)
                {
                    return DBNull.Value;
                }
                if (this.m_SelectedIndex < 0)
                {
                    return DBNull.Value;
                }
                return this.m_ValueList[this.m_SelectedIndex];
            }
            set
            {
                this.m_SelectedValue = value;
            }
        }

        public IList ValueItems
        {
            set
            {
                this.m_ValueList0 = value;
                this.m_ValueList = new ArrayList();
                for (int i = 0; i < this.m_ValueList0.Count; i++)
                {
                    this.m_ValueList.Add(this.m_ValueList0[i]);
                }
            }
        }
    }
}

