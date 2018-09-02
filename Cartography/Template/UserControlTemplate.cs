namespace Cartography.Template
{
    using ESRI.ArcGIS.Carto;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlTemplate : UserControlBase1
    {
        private IContainer components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ImageList imageList1;
        internal ListView ListViewFiles;
        private string m_CurrentTemplate = "";
        private Panel panel1;
        private Panel panel3;
        internal PictureBox PictureBoxPreviwe;

        public UserControlTemplate()
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

        public void InitControls()
        {
            this.InitTemplateList();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlTemplate));
            this.panel1 = new Panel();
            this.groupBox1 = new GroupBox();
            this.PictureBoxPreviwe = new PictureBox();
            this.panel3 = new Panel();
            this.groupBox2 = new GroupBox();
            this.ListViewFiles = new ListView();
            this.imageList1 = new ImageList(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.PictureBoxPreviwe).BeginInit();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(460, 0x11e);
            this.panel1.TabIndex = 0;
            this.groupBox1.Controls.Add(this.PictureBoxPreviwe);
            this.groupBox1.Dock = DockStyle.Left;
            this.groupBox1.Location = new Point(0xb6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x113, 0x11e);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            this.PictureBoxPreviwe.BackColor = Color.Transparent;
            this.PictureBoxPreviwe.Dock = DockStyle.Fill;
            this.PictureBoxPreviwe.Location = new Point(3, 0x12);
            this.PictureBoxPreviwe.Name = "PictureBoxPreviwe";
            this.PictureBoxPreviwe.Size = new Size(0x10d, 0x109);
            this.PictureBoxPreviwe.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBoxPreviwe.TabIndex = 1;
            this.PictureBoxPreviwe.TabStop = false;
            this.panel3.Dock = DockStyle.Left;
            this.panel3.Location = new Point(0xa9, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(13, 0x11e);
            this.panel3.TabIndex = 2;
            this.groupBox2.Controls.Add(this.ListViewFiles);
            this.groupBox2.Dock = DockStyle.Left;
            this.groupBox2.Location = new Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xa9, 0x11e);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模板";
//            this.ListViewFiles.BorderStyle = BorderStyle.None;
            this.ListViewFiles.Dock = DockStyle.Fill;
            this.ListViewFiles.HeaderStyle = ColumnHeaderStyle.None;
            this.ListViewFiles.HideSelection = false;
            this.ListViewFiles.LabelWrap = false;
            this.ListViewFiles.Location = new Point(3, 0x12);
            this.ListViewFiles.MultiSelect = false;
            this.ListViewFiles.Name = "ListViewFiles";
            this.ListViewFiles.Size = new Size(0xa3, 0x109);
            this.ListViewFiles.SmallImageList = this.imageList1;
            this.ListViewFiles.Sorting = SortOrder.Ascending;
            this.ListViewFiles.TabIndex = 1;
            this.ListViewFiles.UseCompatibleStateImageBehavior = false;
            this.ListViewFiles.View = View.List;
            this.ListViewFiles.SelectedIndexChanged += new EventHandler(this.ListViewFiles_SelectedIndexChanged);
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mxt.png");
            base.Appearance.BackColor = Color.Transparent;
            base.Appearance.BackColor2 = Color.Transparent;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel1);
            base.Name = "UserControlTemplate";
            base.Padding = new Padding(10);
            base.Size = new Size(480, 0x132);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.PictureBoxPreviwe).EndInit();
            this.groupBox2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitTemplateList()
        {
            this.ListViewFiles.Clear();
            string path = UtilFactory.GetConfigOpt().RootPath + @"\Template\CustomTemplate";
            if (Directory.Exists(path))
            {
                DirectoryInfo info = new DirectoryInfo(path);
                foreach (FileInfo info2 in info.GetFiles())
                {
                    string name = info2.Name;
                    ListViewItem item = new ListViewItem();
                    item.Text = "自定义模板" + name;
                    item.Tag = path + @"\" + name;
                    item.ImageIndex = 0;
                    this.ListViewFiles.Items.Add(item);
                }
                if (this.ListViewFiles.Items.Count > 0)
                {
                    this.ListViewFiles.Items[0].Selected = true;
                }
            }
        }

        private void ListViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = this.ListViewFiles.SelectedItems;
            if (selectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem();
                item = selectedItems[0];
                string sFileName = item.Tag.ToString();
                this.m_CurrentTemplate = sFileName;
                this.PreviewTemplate(sFileName);
            }
        }

        private void PreviewTemplate(string sFileName)
        {
            this.PictureBoxPreviwe.Image = null;
            IMapDocument document = new MapDocumentClass();
            if (document.get_IsMapDocument(sFileName) && !document.get_IsRestricted(sFileName))
            {
                document.Open(sFileName, "");
                Image image = Image.FromHbitmap(new IntPtr(document.Thumbnail.Handle));
                this.PictureBoxPreviwe.Image = image;
                document.Close();
                document = null;
            }
        }

        public string CurrentTemplate
        {
            get
            {
                return this.m_CurrentTemplate;
            }
        }
    }
}

