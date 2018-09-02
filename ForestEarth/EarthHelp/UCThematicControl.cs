namespace ForestEarth.EarthHelp
{

    using EvEarthDriverLib;
    using EviaEarthLib;
    using EviaEarthObjectLib;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UCThematicControl : UserControl
    {
        private IContainer components;
        private ImageList imageList1;
        private int m_count;
        private IEviaEarthControl m_earthConrol;
        private bool m_isFirstLoad = true;
        private string m_seleceMapName = string.Empty;
        private Timer timer1;
        private TreeView treeView1;

        public event GetThemAreaXJ OnThemTreeNodeCheck;

        public UCThematicControl()
        {
            this.InitializeComponent();
        }

        private string ConvertMapNameToWhereClause(string mapName)
        {
            if (string.IsNullOrEmpty(mapName))
            {
                return mapName;
            }
            string str = string.Empty;
            switch (mapName)
            {
                case "杉木":
                    return "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND LEFT(YOU_SHI_SZ,2)='12'";

                case "松树":
                    return "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND (LEFT(YOU_SHI_SZ,2)='11' OR (CAST(YOU_SHI_SZ AS INT)>130 AND CAST(YOU_SHI_SZ AS INT)<200))";

                case "桉树":
                    return "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND (CAST(YOU_SHI_SZ AS INT)>=280 AND CAST(YOU_SHI_SZ AS INT)<=307)";

                case "一般阔叶树":
                    return "(LEFT(DI_LEI,2)='11' OR DI_LEI='200') AND ((CAST(YOU_SHI_SZ AS INT)>=200 AND CAST(YOU_SHI_SZ AS INT)<280) OR ( CAST(YOU_SHI_SZ AS INT)>=310 AND CAST(YOU_SHI_SZ AS INT)<400) OR (CAST(YOU_SHI_SZ AS INT)>600 AND CAST(YOU_SHI_SZ AS INT)<800 AND YOU_SHI_SZ<>'617' AND YOU_SHI_SZ<>'661' AND YOU_SHI_SZ<>'663' AND YOU_SHI_SZ<>'681' AND YOU_SHI_SZ<>'618' AND YOU_SHI_SZ<>'619' AND YOU_SHI_SZ<>'611' AND YOU_SHI_SZ<>'612' AND YOU_SHI_SZ<>'613' AND YOU_SHI_SZ<>'614' AND YOU_SHI_SZ<>'615' AND YOU_SHI_SZ<>'621'))";

                case "红树类":
                    return "DI_LEI='120' AND LEFT(YOU_SHI_SZ,1) ='5'";

                case "竹类":
                    return "DI_LEI='130' AND LEFT(YOU_SHI_SZ,1) ='4'";

                case "灌木林":
                    return "LEFT(DI_LEI,1)='3' AND LEFT(YOU_SHI_SZ,1) = '8'";

                case "油茶板栗":
                    return "CAST(DI_LEI AS INT)<400 AND (YOU_SHI_SZ='617' OR YOU_SHI_SZ='661')";

                case "八角玉桂":
                    return "CAST(DI_LEI AS INT)<400 AND (YOU_SHI_SZ='663' OR YOU_SHI_SZ='681')";

                case "荔枝龙眼":
                    return "CAST(DI_LEI AS INT)<400 AND (YOU_SHI_SZ='618' OR YOU_SHI_SZ='619')";

                case "柑桔":
                    return "CAST(DI_LEI AS INT)<400 AND (CAST(YOU_SHI_SZ AS INT)>=611 AND CAST(YOU_SHI_SZ AS INT)<=615)";

                case "芒果":
                    return "CAST(DI_LEI AS INT)<400 AND YOU_SHI_SZ='621'";

                case "其它经济林":
                    return "(DI_LEI='301' OR DI_LEI='302') AND (YOU_SHI_SZ='616' OR YOU_SHI_SZ='620' OR (CAST(YOU_SHI_SZ AS INT)>621 AND CAST(YOU_SHI_SZ AS INT)<=703 AND YOU_SHI_SZ<>'661' AND YOU_SHI_SZ<>'662' AND YOU_SHI_SZ<>'663' AND YOU_SHI_SZ<>'681'))";

                case "乔木林地":
                    return "LEFT(DI_LEI,2) = '11'";

                case "疏林地":
                    return "DI_LEI = '200'";

                case "灌木林地":
                    return "LEFT(DI_LEI,1) = '3'";

                case "未成林地":
                    return "LEFT(DI_LEI,1)= '4'";

                case "苗圃地":
                    return "DI_LEI = '500'";

                case "无立木林地":
                    return "LEFT(DI_LEI,1)= '6'";

                case "宜林地":
                    return "LEFT(DI_LEI,1)= '7'";

                case "林业辅助用地":
                    return "DI_LEI = '800'";

                case "水域":
                    return "DI_LEI = '930'";

                case "非林地":
                    return "LEFT(DI_LEI,1)= '9' AND DI_LEI<>'930'";

                case "重点公益林":
                    return "SEN_LIN_LB='11'";

                case "重点商品林":
                    return "SEN_LIN_LB='21'";

                case "一般公益林":
                    return "SEN_LIN_LB='12'";

                case "一般商品林":
                    return "SEN_LIN_LB='22'";

                case "天然林":
                    return "LEFT(QI_YUAN,1)='1'";

                case "人工林":
                    return "LEFT(QI_YUAN,1)='2' OR LEFT(QI_YUAN,1)='3'";

                case "保护I级":
                    return "BH_DJ='1'";

                case "保护II级":
                    return "BH_DJ='2'";

                case "保护III级":
                    return "BH_DJ='3'";

                case "保护IV级":
                    return "BH_DJ='4'";

                case "保护V级":
                    return "BH_DJ='5'";

                case "质量I级":
                    return "ZL_DJ='1'";

                case "质量II级":
                    return "ZL_DJ='2'";

                case "质量III级":
                    return "ZL_DJ='3'";

                case "质量IV级":
                    return "ZL_DJ='4'";

                case "质量V级":
                    return "ZL_DJ='5'";
            }
            return str;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FlashMap(string mapName, string issz)
        {
            if (!string.IsNullOrEmpty(this.m_seleceMapName))
            {
                this.SelectNodeByText(this.m_seleceMapName, false);
            }
            if (mapName.Contains("竹"))
            {
                this.SelectNodeByText("竹类", true);
            }
            else
            {
                for (int i = 0; i < this.treeView1.Nodes.Count; i++)
                {
                    TreeNode node = this.treeView1.Nodes[i];
                    bool flag = false;
                    if (node.Nodes.Count > 0)
                    {
                        TreeNode node2 = null;
                        for (int j = 0; j < node.Nodes.Count; j++)
                        {
                            node2 = node.Nodes[j];
                            if (issz.Equals("YOU_SHI_SZ"))
                            {
                                if (node2.Text.Trim().Contains(mapName.Trim()))
                                {
                                    node2.Checked = true;
                                    this.m_seleceMapName = node2.Text;
                                    flag = true;
                                    break;
                                }
                                if (j == node.Nodes.Count)
                                {
                                    node2.Checked = true;
                                    this.m_seleceMapName = node2.Text;
                                    flag = true;
                                }
                            }
                            else if (node2.Text.Trim().Contains(mapName.Trim()))
                            {
                                node2.Checked = true;
                                this.m_seleceMapName = node2.Text;
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        return;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UCThematicControl));
            this.treeView1 = new TreeView();
            this.imageList1 = new ImageList(this.components);
            this.timer1 = new Timer(this.components);
            base.SuspendLayout();
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.Font = new Font("宋体", 11f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 2;
            this.treeView1.Size = new Size(0xa6, 0x10b);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterExpand += new TreeViewEventHandler(this.treeView1_AfterExpand);
            this.imageList1.ImageStream = (ImageListStreamer) manager.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ColorCommand.png");
            this.imageList1.Images.SetKeyName(1, "leaf.gif");
            this.imageList1.Images.SetKeyName(2, "drop-yes.gif");
            this.timer1.Interval = 500;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.treeView1);
            base.Name = "UCThematicControl";
            base.Size = new Size(0xa6, 0x10b);
            base.ResumeLayout(false);
        }

        private void InitTreeView()
        {
            try
            {
                IEvEarthFolder rootFolder = ((IEvEarthScene) this.m_earthConrol.Scene.EvEarthScene).Doc.RootFolder;
                for (int i = 0; i < rootFolder.ChildCount; i++)
                {
                    IEvEarthFolder child = rootFolder.GetChild(i) as IEvEarthFolder;
                    if ((child != null) && child.Name.Equals("资源专题"))
                    {
                        TreeNode node = null;
                        for (int j = 0; j < child.ChildCount; j++)
                        {
                            IEvEarthLayer layer2 = child.GetChild(j);
                            if (layer2 is IEvEarthFolder)
                            {
                                break;
                            }
                            node = this.treeView1.Nodes.Add(layer2.Name);
                            node.Tag = layer2;
                            node.Checked = layer2.Visible;
                            if (layer2.Name.Equals("卫星影像") || layer2.Name.Equals("地形图"))
                            {
                                node.ImageIndex = 1;
                            }
                            else
                            {
                                node.Nodes.Add("");
                                node.Expand();
                                node.Collapse();
                            }
                        }
                        this.m_isFirstLoad = false;
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        public void SelectNodeByText(string mapName, bool check)
        {
            for (int i = 0; i < this.treeView1.Nodes.Count; i++)
            {
                bool flag = false;
                TreeNode node = this.treeView1.Nodes[i];
                if (node.Nodes.Count > 0)
                {
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        TreeNode node2 = node.Nodes[j];
                        if (node2.Text.Equals(mapName))
                        {
                            node2.Checked = check;
                            flag = true;
                            if (check)
                            {
                                this.m_seleceMapName = node2.Text;
                            }
                            else
                            {
                                this.m_seleceMapName = string.Empty;
                            }
                            break;
                        }
                    }
                    if (flag)
                    {
                        return;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IImageLayer tag = this.timer1.Tag as IImageLayer;
            if (tag != null)
            {
                if (tag.Opacity == 0.0)
                {
                    tag.Opacity = 1.0;
                }
                else
                {
                    tag.Opacity = 0.0;
                }
                this.m_count++;
                if (this.m_count > 7)
                {
                    this.timer1.Enabled = false;
                    tag.Opacity = 0.0;
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.m_isFirstLoad && (e.Node.Tag != null))
            {
                if (e.Node.Nodes.Count > 0)
                {
                    IEvEarthLayer tag = e.Node.Tag as IEvEarthLayer;
                    if (!tag.Visible)
                    {
                        tag.Visible = true;
                    }
                    IImageLayer layer2 = tag as IImageLayer;
                    if (layer2 == null)
                    {
                        return;
                    }
                    if (!string.IsNullOrEmpty(e.Node.Nodes[0].Text.Trim()) && !e.Node.Checked)
                    {
                        for (int i = 0; i < e.Node.Nodes.Count; i++)
                        {
                            if (e.Node.Nodes[i].Checked)
                            {
                                e.Node.Nodes[i].Checked = false;
                            }
                        }
                    }
                    layer2.Opacity = e.Node.Checked ? 0.4 : 1.0;
                }
                else
                {
                    IEvEarthLayer layer3 = e.Node.Tag as IEvEarthLayer;
                    if (!layer3.Visible)
                    {
                        layer3.Visible = true;
                    }
                    IImageLayer layer4 = layer3 as IImageLayer;
                    if (layer4 == null)
                    {
                        return;
                    }
                    layer4.Opacity = e.Node.Checked ? ((double) 0) : ((double) 1);
                    if (e.Node.Checked)
                    {
                        TreeNode parent = e.Node.Parent;
                        for (int j = 0; j < parent.Nodes.Count; j++)
                        {
                            if (!parent.Nodes[j].Text.Equals(e.Node.Text) && parent.Nodes[j].Checked)
                            {
                                parent.Nodes[j].Checked = false;
                            }
                        }
                        this.timer1.Enabled = true;
                        this.timer1.Tag = layer4;
                        this.m_count = 0;
                        string whereClasue = this.ConvertMapNameToWhereClause(layer3.Name);
                        if (this.OnThemTreeNodeCheck != null)
                        {
                            this.OnThemTreeNodeCheck(this, whereClasue);
                        }
                    }
                }
                (this.m_earthConrol.Scene.EvEarthScene as IEvEarthScene).RequestRender();
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Node.Nodes[0].Text.Trim()) && (e.Node.Tag != null))
            {
                e.Node.Nodes.Clear();
                IEvEarthLayer tag = e.Node.Tag as IEvEarthLayer;
                try
                {
                    IEvEarthFolder rootFolder = ((IEvEarthScene) this.m_earthConrol.Scene.EvEarthScene).Doc.RootFolder;
                    for (int i = 0; i < rootFolder.ChildCount; i++)
                    {
                        IEvEarthFolder child = rootFolder.GetChild(i) as IEvEarthFolder;
                        if ((child != null) && child.Name.Equals("资源专题"))
                        {
                            TreeNode node = null;
                            this.m_isFirstLoad = true;
                            for (int j = 0; j < child.ChildCount; j++)
                            {
                                IEvEarthFolder folder3 = child.GetChild(j) as IEvEarthFolder;
                                if ((folder3 != null) && folder3.Name.Equals(tag.Name))
                                {
                                    for (int k = 0; k < folder3.ChildCount; k++)
                                    {
                                        IEvEarthLayer layer4 = folder3.GetChild(k);
                                        node = e.Node.Nodes.Add(layer4.Name);
                                        node.Tag = layer4;
                                        node.Checked = layer4.Visible;
                                        node.ImageIndex = 1;
                                    }
                                    break;
                                }
                            }
                            this.m_isFirstLoad = false;
                            return;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public IEviaEarthControl EarthControl
        {
            get
            {
                return this.m_earthConrol;
            }
            set
            {
                if (value != null)
                {
                    this.m_earthConrol = value;
                    this.InitTreeView();
                }
            }
        }

        public delegate void GetThemAreaXJ(object sender, string whereClasue);
    }
}

