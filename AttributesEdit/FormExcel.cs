namespace AttributesEdit
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormExcel : Form
    {
        private Button buttonCancel;
        private Button buttonImport;
        private IContainer components;
        private Label label1;
        private ListBox listBoxSheet;
        private string[] m_SelectSheets;
        private string[] m_Sheets;
        private Panel panel1;

        public FormExcel()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            this.m_SelectSheets = this.GetSelectedItems();
            if (this.m_SelectSheets.Length < 1)
            {
                MessageBox.Show("请至少选中一个工作表！", "提示");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
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

        private void FormExcel_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private string[] GetSelectedItems()
        {
            string[] strArray = new string[this.listBoxSheet.SelectedItems.Count];
            for (int i = 0; i < this.listBoxSheet.SelectedItems.Count; i++)
            {
                strArray[i] = this.listBoxSheet.SelectedItems[i].ToString();
            }
            return strArray;
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.listBoxSheet = new ListBox();
            this.panel1 = new Panel();
            this.buttonImport = new Button();
            this.buttonCancel = new Button();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.label1.Location = new Point(12, 0x18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x158, 0x15);
            this.label1.TabIndex = 0;
            this.label1.Text = "电子表格文件含有一个或多个工作表，请选择要导入的工作表";
            this.listBoxSheet.FormattingEnabled = true;
            this.listBoxSheet.HorizontalScrollbar = true;
            this.listBoxSheet.ItemHeight = 12;
            this.listBoxSheet.Location = new Point(0x2c, 0x31);
            this.listBoxSheet.Name = "listBoxSheet";
            this.listBoxSheet.SelectionMode = SelectionMode.MultiSimple;
            this.listBoxSheet.Size = new Size(0x110, 0x88);
            this.listBoxSheet.TabIndex = 1;
            this.listBoxSheet.SelectedIndexChanged += new EventHandler(this.listBoxSheet_SelectedIndexChanged);
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 0xd7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x170, 0x2f);
            this.panel1.TabIndex = 2;
            this.buttonImport.Location = new Point(0xfe, 12);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new Size(0x4b, 0x17);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "确定";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new EventHandler(this.buttonImport_Click);
            this.buttonCancel.Location = new Point(0x93, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
        //    base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x170, 0x106);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.listBoxSheet);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormExcel";
            this.Text = "选择工作表";
            base.FormClosed += new FormClosedEventHandler(this.FormExcel_FormClosed);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void listBoxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.listBoxSheet.SelectedIndex >= 0) && this.listBoxSheet.SelectedItem.ToString().Contains("数据字典"))
            {
                for (int i = 0; i < this.listBoxSheet.SelectedItems.Count; i++)
                {
                    string str = this.listBoxSheet.SelectedItems[i].ToString();
                    if (str.Contains("数据字典"))
                    {
                        this.listBoxSheet.SelectedItems.Remove(str);
                    }
                }
            }
        }

        private void ShowList()
        {
            this.listBoxSheet.Items.Clear();
            for (int i = 0; i < this.m_Sheets.Length; i++)
            {
                this.listBoxSheet.Items.Add(this.m_Sheets[i]);
            }
            this.listBoxSheet.ItemHeight = 0x10;
        }

        public string[] SelectedSheets
        {
            get
            {
                return this.m_SelectSheets;
            }
        }

        public string[] Sheets
        {
            set
            {
                this.m_Sheets = value;
                this.ShowList();
            }
        }
    }
}

