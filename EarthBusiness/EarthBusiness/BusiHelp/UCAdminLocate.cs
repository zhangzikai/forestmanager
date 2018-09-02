namespace EarthBusiness.BusiHelp
{
    using EarthBusiness;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UCAdminLocate : UserControl
    {
        private IContainer components;
        private ImageList imageList1;
        private ClsDbHandler m_clsDbHandler;
        private string m_connString = string.Empty;
        private string m_updateYear = string.Empty;
        private TreeView treeView1;

        public event TreeDoubleClick OnTreeDoubleClick;

        public UCAdminLocate()
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

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UCAdminLocate));
            this.treeView1 = new TreeView();
            this.imageList1 = new ImageList(this.components);
            base.SuspendLayout();
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 3;
            this.treeView1.Size = new Size(0xda, 0x120);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.AfterExpand += new TreeViewEventHandler(this.treeView1_AfterExpand);
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderBlueNew16.png");
            this.imageList1.Images.SetKeyName(1, "FolderBlueOpenState16.png");
            this.imageList1.Images.SetKeyName(2, "leaf.gif");
            this.imageList1.Images.SetKeyName(3, "drop-yes.gif");
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.treeView1);
            base.Name = "UCAdminLocate";
            base.Size = new Size(0xda, 0x120);
            base.ResumeLayout(false);
        }

        private void InitTreeView()
        {
            List<CodeName> adminLocateTreeData = this.m_clsDbHandler.GetAdminLocateTreeData(string.Empty);
            if ((adminLocateTreeData != null) && (adminLocateTreeData.Count > 0))
            {
                foreach (CodeName name in adminLocateTreeData)
                {
                    TreeNode node = new TreeNode(name.Name);
                    node.Nodes.Add("");
                    node.Tag = name.Code;
                    this.treeView1.Nodes.Add(node);
                }
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if ((e.Node.Tag != null) && string.IsNullOrEmpty(e.Node.Nodes[0].Text.Trim()))
            {
                e.Node.Nodes.Clear();
                List<CodeName> adminLocateTreeData = this.m_clsDbHandler.GetAdminLocateTreeData(e.Node.Tag.ToString().Trim());
                if ((adminLocateTreeData != null) && (adminLocateTreeData.Count > 0))
                {
                    foreach (CodeName name in adminLocateTreeData)
                    {
                        TreeNode node = e.Node.Nodes.Add(name.Name);
                        node.Tag = name.Code;
                        node.ImageIndex = 1;
                        if (e.Node.Tag.ToString().Length == 6)
                        {
                            node.Nodes.Add("");
                        }
                        else
                        {
                            node.ImageIndex = 2;
                        }
                    }
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.Tag.ToString().Trim()))
            {
                AdminLocateStatisInfo adminLocateStaticInfo = this.m_clsDbHandler.GetAdminLocateStaticInfo(e.Node.Tag.ToString().Trim(), e.Node.Text.Trim());
                if (((adminLocateStaticInfo != null) && (adminLocateStaticInfo.GeoString.Length > 0)) && (this.OnTreeDoubleClick != null))
                {
                    this.OnTreeDoubleClick(this, adminLocateStaticInfo);
                }
            }
        }

        public ClsDbHandler ClassDbHandler
        {
            get
            {
                return this.m_clsDbHandler;
            }
            set
            {
                this.m_clsDbHandler = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.m_connString;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_connString = value;
                    if (this.m_clsDbHandler == null)
                    {
                        this.m_clsDbHandler = new ClsDbHandler();
                        this.m_clsDbHandler.SqlConnectionString = value;
                    }
                    this.InitTreeView();
                }
            }
        }

        public string UpdateYear
        {
            get
            {
                return this.m_updateYear;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_updateYear = value;
                    if (string.IsNullOrEmpty(this.m_clsDbHandler.UpdateYear))
                    {
                        this.m_clsDbHandler.UpdateYear = value;
                    }
                }
            }
        }

        public delegate void TreeDoubleClick(object sender, AdminLocateStatisInfo result);
    }
}

