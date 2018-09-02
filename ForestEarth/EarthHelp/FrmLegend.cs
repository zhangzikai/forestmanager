namespace ForestEarth.EarthHelp
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmLegend : Form
    {
        private IContainer components;
        private ImageList imageList1;
        private TreeView treeView1;

        public FrmLegend()
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

        private void FrmLegend_Load(object sender, EventArgs e)
        {
            string[] strArray = new string[] { 
                "杉木", "松树", "桉树", "一般阔叶树", "竹林", "灌木林", "油茶板栗", "八角玉桂", "荔枝龙眼", "柑桔", "芒果", "其它经济林", "乔木林", "灌木林地", "未成林地", "苗圃地",
                "无立木林地", "宜林地", "辅助林地", "水域", "非林地", "重点公益林", "重点商品林", "一般公益林", "一般商品林", "天然林", "人工林", "保护一级", "保护二级", "保护三级", "保护四级", "质量一级",
                "质量二级", "质量三级", "质量四级", "质量五级"
            };
            for (int i = 0; i < this.imageList1.Images.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.ImageIndex = i;
                node.Text = strArray[i];
                this.treeView1.Nodes.Add(node);
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmLegend));
            this.treeView1 = new TreeView();
            this.imageList1 = new ImageList(this.components);
            base.SuspendLayout();
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 0x15;
            this.treeView1.Location = new Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new Size(0x11c, 0x106);
            this.treeView1.TabIndex = 0;
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "杉木.jpg");
            this.imageList1.Images.SetKeyName(1, "松树.jpg");
            this.imageList1.Images.SetKeyName(2, "桉树.jpg");
            this.imageList1.Images.SetKeyName(3, "一般阔叶树.jpg");
            this.imageList1.Images.SetKeyName(4, "竹类.jpg");
            this.imageList1.Images.SetKeyName(5, "灌木类.jpg");
            this.imageList1.Images.SetKeyName(6, "油茶板栗.jpg");
            this.imageList1.Images.SetKeyName(7, "八角玉桂.jpg");
            this.imageList1.Images.SetKeyName(8, "荔枝龙眼.jpg");
            this.imageList1.Images.SetKeyName(9, "柑桔.jpg");
            this.imageList1.Images.SetKeyName(10, "芒果.jpg");
            this.imageList1.Images.SetKeyName(11, "其它经济林.jpg");
            this.imageList1.Images.SetKeyName(12, "乔木林.jpg");
            this.imageList1.Images.SetKeyName(13, "灌木林地.jpg");
            this.imageList1.Images.SetKeyName(14, "未成林地.jpg");
            this.imageList1.Images.SetKeyName(15, "苗圃地.jpg");
            this.imageList1.Images.SetKeyName(0x10, "无立木林地.jpg");
            this.imageList1.Images.SetKeyName(0x11, "宜林地.jpg");
            this.imageList1.Images.SetKeyName(0x12, "辅助林地.jpg");
            this.imageList1.Images.SetKeyName(0x13, "水域.jpg");
            this.imageList1.Images.SetKeyName(20, "非林地.jpg");
            this.imageList1.Images.SetKeyName(0x15, "重点公益林.jpg");
            this.imageList1.Images.SetKeyName(0x16, "重点商品林.jpg");
            this.imageList1.Images.SetKeyName(0x17, "一般公益林.jpg");
            this.imageList1.Images.SetKeyName(0x18, "一般商品林.jpg");
            this.imageList1.Images.SetKeyName(0x19, "天然林.jpg");
            this.imageList1.Images.SetKeyName(0x1a, "人工林.jpg");
            this.imageList1.Images.SetKeyName(0x1b, "保护一级.jpg");
            this.imageList1.Images.SetKeyName(0x1c, "保护二级.jpg");
            this.imageList1.Images.SetKeyName(0x1d, "保护三级.jpg");
            this.imageList1.Images.SetKeyName(30, "保护四级.jpg");
            this.imageList1.Images.SetKeyName(0x1f, "质量一级.jpg");
            this.imageList1.Images.SetKeyName(0x20, "质量二级.jpg");
            this.imageList1.Images.SetKeyName(0x21, "质量三级.jpg");
            this.imageList1.Images.SetKeyName(0x22, "质量四级.jpg");
            this.imageList1.Images.SetKeyName(0x23, "质量五级.jpg");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x106);
            base.Controls.Add(this.treeView1);
            base.Name = "FrmLegend";
            this.Text = "FrmLegend";
            base.Load += new EventHandler(this.FrmLegend_Load);
            base.ResumeLayout(false);
        }
    }
}

