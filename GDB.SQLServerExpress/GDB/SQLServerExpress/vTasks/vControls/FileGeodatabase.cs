namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Windows.Forms;

    public class FileGeodatabase : UserControlBase1
    {
        private bool _isLocal = true;
        private bool _loadFile;
        private IContainer components;
        private ImageList imageList1;
        private TreeList treeList_drivers;
        private TreeListColumn treeListColumn_database;

        public FileGeodatabase()
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

        public IWorkspace GetFeatureWorkspace()
        {
            try
            {
                string path = this.GetPath();
                path = path.Remove(path.Length - 1, 1);
                IWorkspaceFactory factory = new FileGDBWorkspaceFactoryClass();
                if (!factory.IsWorkspace(path))
                {
                    XtraMessageBox.Show("选择的目录不是文件地里数据库！");
                    return null;
                }
                return factory.OpenFromFile(path, 0);
            }
            catch
            {
                return null;
            }
        }

        public string GetPath()
        {
            TreeListNode focusedNode = this.treeList_drivers.FocusedNode;
            string str = "";
            while (focusedNode != null)
            {
                str = focusedNode.GetValue(0).ToString() + @"\" + str;
                focusedNode = focusedNode.ParentNode;
            }
            return str.ToString();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FileGeodatabase));
            this.imageList1 = new ImageList(this.components);
            this.treeList_drivers = new TreeList();
            this.treeListColumn_database = new TreeListColumn();
            this.treeList_drivers.BeginInit();
            base.SuspendLayout();
            this.imageList1.ImageStream = (ImageListStreamer) resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.gif");
            this.imageList1.Images.SetKeyName(1, "drive.gif");
            this.imageList1.Images.SetKeyName(2, "database.gif");
            this.imageList1.Images.SetKeyName(3, "Server.gif");
            this.imageList1.Images.SetKeyName(4, "mdf.png");
            this.treeList_drivers.Appearance.FocusedCell.BackColor = Color.CornflowerBlue;
            this.treeList_drivers.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList_drivers.Columns.AddRange(new TreeListColumn[] { this.treeListColumn_database });
            this.treeList_drivers.Dock = DockStyle.Fill;
            this.treeList_drivers.Location = new Point(0, 0);
            this.treeList_drivers.Name = "treeList_drivers";
            this.treeList_drivers.OptionsBehavior.Editable = false;
            this.treeList_drivers.OptionsView.ShowColumns = false;
            this.treeList_drivers.OptionsView.ShowHorzLines = false;
            this.treeList_drivers.OptionsView.ShowIndicator = false;
            this.treeList_drivers.OptionsView.ShowVertLines = false;
            this.treeList_drivers.SelectImageList = this.imageList1;
            this.treeList_drivers.Size = new Size(0xe0, 0x111);
            this.treeList_drivers.TabIndex = 3;
            this.treeList_drivers.DoubleClick += new EventHandler(this.treeList_drivers_DoubleClick);
            this.treeList_drivers.GetSelectImage += new GetSelectImageEventHandler(this.treeList_drivers_GetSelectImage);
            this.treeListColumn_database.Caption = "treeListColumn1";
            this.treeListColumn_database.FieldName = "treeListColumn1";
            this.treeListColumn_database.Name = "treeListColumn_database";
            this.treeListColumn_database.OptionsColumn.AllowEdit = false;
            this.treeListColumn_database.Visible = true;
            this.treeListColumn_database.VisibleIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xb0, 0xcf, 0xf7);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            base.Appearance.GradientMode = LinearGradientMode.Vertical;
            base.Appearance.Options.UseBackColor = true;
            base.Appearance.Options.UseBorderColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.treeList_drivers);
            this.LookAndFeel.SkinName = "Money Twins";
            base.Name = "FileGeodatabase";
            base.Size = new Size(0xe0, 0x111);
            this.treeList_drivers.EndInit();
            base.ResumeLayout(false);
        }

        public void LoadDriver()
        {
            if (this.treeList_drivers.Nodes.Count <= 0)
            {
                this._isLocal = true;
                foreach (DriveInfo info in DriveInfo.GetDrives())
                {
                    TreeListNode node = this.treeList_drivers.AppendNode(null, -1);
                    node.SetValue(0, info.Name.Remove(info.Name.Length - 1));
                    node.Tag = info.RootDirectory;
                }
            }
        }

        private void LoadFolder(TreeListNode pNode, DirectoryInfo pDi)
        {
            if (pNode.Nodes.Count <= 0)
            {
                foreach (DirectoryInfo info in pDi.GetDirectories())
                {
                    if (((info.Attributes & FileAttributes.Hidden) == 0) && ((info.Attributes & FileAttributes.Encrypted) == 0))
                    {
                        TreeListNode node = this.treeList_drivers.AppendNode(null, pNode);
                        node.SetValue(0, info.Name);
                        node.Tag = info;
                    }
                }
                if (this._loadFile)
                {
                    foreach (FileInfo info2 in pDi.GetFiles("*.MDF"))
                    {
                        this.treeList_drivers.AppendNode(null, pNode).SetValue(0, info2.Name);
                    }
                }
                pNode.ExpandAll();
            }
        }

        private void LoadServerDirectory(TreeListNode pNode, Server pServer, string pParentPath)
        {
            if (pNode.Nodes.Count <= 0)
            {
                pNode.GetValue(0).ToString();
                foreach (DataRow row in pServer.EnumDirectories(pParentPath).Rows)
                {
                    TreeListNode node = this.treeList_drivers.AppendNode(null, pNode);
                    node.SetValue(0, row["Name"]);
                    node.Tag = pServer;
                }
                pNode.ExpandAll();
            }
        }

        public void LoadServerDriver(ServerConnection pConnection)
        {
            Server server = new Server(pConnection);
            DataRowCollection rows=server.EnumAvailableMedia(MediaTypes.FixedDisk).Rows;
            foreach (DataRow row in rows)
            {
                TreeListNode node = this.treeList_drivers.AppendNode(null, -1);
                node.SetValue(0, row["Name"]);
                node.Tag = server;
            }
        }

        private void treeList_drivers_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeList_drivers.FocusedNode.Tag != null)
            {
                if (this._isLocal)
                {
                    this.LoadFolder(this.treeList_drivers.FocusedNode, this.treeList_drivers.FocusedNode.Tag as DirectoryInfo);
                }
                else
                {
                    string pParentPath = "";
                    for (TreeListNode node = this.treeList_drivers.FocusedNode; node != null; node = node.ParentNode)
                    {
                        pParentPath = node.GetValue(0).ToString() + @"\" + pParentPath;
                    }
                    this.LoadServerDirectory(this.treeList_drivers.FocusedNode, this.treeList_drivers.FocusedNode.Tag as Server, pParentPath);
                }
            }
        }

        private void treeList_drivers_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                e.NodeImageIndex = 1;
            }
            else if (e.Node.Tag != null)
            {
                e.NodeImageIndex = 0;
            }
            else
            {
                e.NodeImageIndex = 4;
            }
        }

        public bool HasSelected
        {
            get
            {
                if (this.treeList_drivers.FocusedNode == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsLocal
        {
            set
            {
                this._isLocal = value;
            }
        }

        public bool LoadFile
        {
            set
            {
                this._loadFile = true;
            }
        }
    }
}

